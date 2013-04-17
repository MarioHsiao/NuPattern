﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml;
using NuPattern.Diagnostics;
using NuPattern.Reflection;
using NuPattern.Runtime.Composition;
using NuPattern.Runtime.Guidance.Diagnostics;
using NuPattern.Runtime.Guidance.Extensions;
using NuPattern.Runtime.Guidance.Properties;
using NuPattern.VisualStudio.Solution;

namespace NuPattern.Runtime.Guidance
{
    /// <summary>
    /// Manages features and their lifetime.
    /// </summary>
    [Export(typeof(IFeatureManager))]
    internal class FeatureManager : IFeatureManager
    {
        private CompositionContainer featuresGlobalContainer;
        private Func<IFeatureRegistration, IFeatureExtension> featureFactory;
        private List<Tuple<IFeatureExtension, IFeatureCompositionService>> instantiatedFeatures = new List<Tuple<IFeatureExtension, IFeatureCompositionService>>();
        private ISolutionState solutionState;
        private IFeatureExtension activeFeature;
        public static string FeatureBuilderDSLPath = string.Empty;

#pragma warning disable 0414
        private int inTemplateWizard = 0;
#pragma warning restore 0414

        public int InTemplateWizard { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = (sender, args) => { };
        public event EventHandler InstantiatedFeaturesChanged = (sender, args) => { };
        public event EventHandler IsOpenedChanged = (sender, args) => { };
        public event EventHandler ActiveFeatureChanged = (sender, args) => { };

        [ImportingConstructor]
        public FeatureManager(
            [Import(typeof(FeaturesGlobalContainer))]
            CompositionContainer featuresGlobalContainer,
            IEnumerable<IFeatureRegistration> installedFeatures,
            Func<IFeatureRegistration, IFeatureExtension> featureFactory)
        {
            // Not sure it still makes much sense to have the Func factory abstraction 
            // over MEF if we are dependent on a global container anyways, and 
            // now the manager is fully aware of MEF as it creates child 
            // containers for features...

            Guard.NotNull(() => featuresGlobalContainer, featuresGlobalContainer);
            Guard.NotNull(() => installedFeatures, installedFeatures);
            Guard.NotNull(() => featureFactory, featureFactory);

            this.featuresGlobalContainer = featuresGlobalContainer;
            this.InstalledFeatures = installedFeatures.ToList();
            this.featureFactory = featureFactory;
        }

        /// <summary>
        /// Installed feature extensions.
        /// </summary>
        /// <value></value>
        public IEnumerable<IFeatureRegistration> InstalledFeatures { get; private set; }

        /// <summary>
        /// Whether the manager has been initialized for a solution.
        /// See <see cref="Open(ISolutionState)"/>.
        /// </summary>
        /// <value></value>
        public bool IsOpened
        {
            get { return solutionState != null; }
        }

        /// <summary>
        /// Gets or sets the active feature.
        /// </summary>
        public IFeatureExtension ActiveFeature
        {
            get
            {
                return this.activeFeature;
            }
            set
            {
                if (value != this.activeFeature)
                {
                    this.activeFeature = value;
                    this.ActiveFeatureChanged(this, EventArgs.Empty);
                    this.RaisePropertyChanged(x => x.ActiveFeature);
                }
            }
        }

        /// <summary>
        /// Force the active feature to change causing the workflow to refresh
        /// </summary>
        public void ForceActiveFeatureChanged()
        {
            this.ActiveFeatureChanged(this, EventArgs.Empty);
            this.RaisePropertyChanged(x => x.ActiveFeature);
        }

        /// <summary>
        /// Instantiated features in the initialized solution state, if any.
        /// </summary>
        /// <value></value>
        public IEnumerable<IFeatureExtension> InstantiatedFeatures
        {
            get { return this.instantiatedFeatures.Select(tuple => tuple.Item1); }
        }

        /// <summary>
        /// Release state and resources for all instantiated features in the current solution state.
        /// </summary>
        public void Close()
        {
            //
            // If we're really in the RunStarted portion of a template wizard, we ignore
            // Close calls which are generated by VS events
            //
            if (InTemplateWizard > 0)
                return;

            ClearAllFeatures();

            this.solutionState = null;
            this.ActiveFeature = null;

            if (BlackboardManager.Current != null)
                BlackboardManager.Current.Clear();

            InstantiatedFeaturesChanged(this, EventArgs.Empty);
            RaisePropertyChanged(x => x.InstantiatedFeatures);
            IsOpenedChanged(this, EventArgs.Empty);
            RaisePropertyChanged(x => x.IsOpened);
        }

        /// <summary>
        /// Initializes the manager with a given solution state.
        /// </summary>
        public void Open(ISolutionState solutionState)
        {
            Guard.NotNull(() => solutionState, solutionState);

            var theSolution = ((SolutionDataState)solutionState).Solution;
            SetDSLPathIfPresent();


            //
            // Ok, now let's load any features we find from the "Solution State" which is
            // stored in the .SLN file's Solution Globals
            //
            this.Close();
            this.solutionState = solutionState;

            IsOpenedChanged(this, EventArgs.Empty);
            RaisePropertyChanged(x => x.IsOpened);


            using (new TraceActivity("Loading features from solution state", Tracer.GetSourceFor<FeatureManager>()))
            {
                // Ignore features that are not installed.
                var availableSolutionFeatures = solutionState
                    .InstantiatedFeatures
                    .Where(state => this.IsInstalled(state.FeatureId))
                    .Select(state => new
                    {
                        Registration = this.InstalledFeatures.Where(reg => reg.FeatureId == state.FeatureId).First(),
                        State = state
                    });

                try
                {
                    if (availableSolutionFeatures.ToArray<object>().Length > 0)
                    {
                        InTemplateWizard = InTemplateWizard + 1;
                        ForceActiveFeatureChanged();
                        InTemplateWizard = InTemplateWizard - 1;
                    }
                }
                catch (Exception)
                {
                }
                finally
                {
                    InTemplateWizard = 0;
                }

                if (BlackboardManager.Current != null)
                    BlackboardManager.Current.Initialize();

                foreach (var feature in availableSolutionFeatures)
                {
                    var featureTracer = FeatureTracer.GetSourceFor(this, feature.State.FeatureId, feature.State.InstanceName);
                    using (new TraceActivity("Initializing existing feature", featureTracer))
                    {
                        try
                        {
                            IFeatureExtension fx = this.InitializeFeature(feature.State.FeatureId,
                                feature.State.InstanceName,
                                feature.Registration,
                                feature.State.Version,
                                false);  // isInstantiation
                            fx.PostInitialize();
                            this.ActiveFeature = fx;

                            // If feature initialized fine and there was a version mismatch, consider it upgraded.
                            if (feature.State.Version != feature.Registration.ExtensionManifest.Header.Version)
                                solutionState.Update(feature.State.FeatureId, feature.State.InstanceName, feature.Registration.ExtensionManifest.Header.Version);
                        }
                        catch (Exception ex)
                        {
                            featureTracer.TraceError(ex, "Failed to initialize feature");
                        }
                    }
                }

                if (this.instantiatedFeatures.Count == 1)
                    this.ActiveFeature = this.InstantiatedFeatures.First();
            }
        }

        /// <summary>
        /// Instantiates the given feature in the current solution.
        /// </summary>
        /// <param name="featureId">Identifier for the feature type.</param>
        /// <param name="instanceName">Name to assign to the newly created feature instance.</param>
        /// <returns>The instantiated feature.</returns>
        public IFeatureExtension Instantiate(string featureId, string instanceName)
        {
            Guard.NotNullOrEmpty(() => featureId, featureId);
            Guard.NotNullOrEmpty(() => instanceName, instanceName);

            var featureTracer = FeatureTracer.GetSourceFor(this, featureId, instanceName);

            using (new TraceActivity("Instantiating feature", featureTracer))
            {
                try
                {
                    //this.ThrowIfNoSolutionState();
                    this.ThrowIfFeatureNotInstalled(featureId);
                    this.ThrowIfAlreadyInstantiated(featureId, instanceName);

                    // Gets the installed version of the feature
                    var registration = this.InstalledFeatures.First(f => f.FeatureId == featureId);

                    var feature = this.InitializeFeature(featureId,
                        instanceName,
                        registration,
                        registration.ExtensionManifest.Header.Version,
                        true);

                    if (registration != null && feature != null)
                    {
                        feature = InitializeFeature(registration.FeatureId,
                            instanceName,
                            registration,
                            registration.ExtensionManifest.Header.Version,
                            false);
                        feature.PostInitialize();

                        //
                        // Finally, find the instance and fixup the workflow
                        //
                        foreach (var x in instantiatedFeatures.ToList())
                        {
                            if (x.Item1.InstanceName == feature.InstanceName)
                            {
                                FeatureExtension fx = x.Item1 as FeatureExtension;
                                fx.GuidanceWorkflow = feature.GuidanceWorkflow;
                                break;
                            }
                        }
                        //
                        // Update the InstantiatedFeatures list which will get the workflow into the
                        // Workflow Explorer
                        InstantiatedFeaturesChanged(this, EventArgs.Empty);
                        RaisePropertyChanged(x => x.InstantiatedFeatures);
                    }
                    return feature;
                }
                catch (Exception ex)
                {
                    featureTracer.TraceError(ex, "Failed to instantiate feature");
                    throw;
                }
            }
        }

        internal IFeatureExtension InstantiateButNotInitialize(string featureId, string instanceName)
        {
            Guard.NotNullOrEmpty(() => featureId, featureId);
            Guard.NotNullOrEmpty(() => instanceName, instanceName);

            var featureTracer = FeatureTracer.GetSourceFor(this, featureId, instanceName);
            using (new TraceActivity("Instantiating feature", featureTracer))
            {
                try
                {
                    //this.ThrowIfNoSolutionState();
                    this.ThrowIfFeatureNotInstalled(featureId);
                    this.ThrowIfAlreadyInstantiated(featureId, instanceName);

                    // Gets the installed version of the feature
                    var registration = this.InstalledFeatures.First(f => f.FeatureId == featureId);

                    var feature = this.InitializeFeature(featureId,
                        instanceName,
                        registration,
                        registration.ExtensionManifest.Header.Version,
                        true);

                    if (registration != null && feature != null)
                    {
                        feature = InitializeFeature(registration.FeatureId,
                            instanceName,
                            registration,
                            registration.ExtensionManifest.Header.Version,
                            false);
                    }

                    return feature;
                }
                catch (Exception ex)
                {
                    featureTracer.TraceError(ex, "Failed to instantiate feature");
                    throw;
                }
            }
        }

        //
        // Semi-public version which allows control over call to postInitialize
        //
        protected IFeatureExtension InitializeFeature(string featureId,
            string instanceName,
            IFeatureRegistration registration,
            Version version,
            bool isInstantiation
            )
        {
            IFeatureExtension featureInstance = this.CreateFeature(featureId);
            IFeatureCompositionService featureComposition = this.CreateFeatureCompositionService(featureInstance, featureId);

            SetDSLPathIfPresent();

            //
            // Let's check to see if the instantiation should be registered with the
            // solution
            if (featureInstance.PersistInstanceInSolution)
            {
                solutionState.AddFeature(featureId, instanceName, version);
            }

            if (isInstantiation)
            {
                featureInstance.Instantiate(registration, instanceName, this);
            }
            else
            {
                featureInstance.Initialize(registration, instanceName, version, this);
                instantiatedFeatures.Add(new Tuple<IFeatureExtension, IFeatureCompositionService>(featureInstance, featureComposition));
                InstantiatedFeaturesChanged(this, EventArgs.Empty);
                RaisePropertyChanged(x => x.InstantiatedFeatures);
            }

            return featureInstance;
        }

        internal void CompleteInitializationOfUnfoldedFeature(string featureId,
            IFeatureExtension featureInstance)
        {
            //
            // First, find the instance and fixup the workflow
            //
            foreach (var x in instantiatedFeatures.ToList())
            {
                if (x.Item1.InstanceName == featureInstance.InstanceName)
                {
                    FeatureExtension fx = x.Item1 as FeatureExtension;
                    fx.GuidanceWorkflow = featureInstance.GuidanceWorkflow;
                    break;
                }
            }

            //
            // Then add this FX to the solution (if desired)
            //
            if (featureInstance.PersistInstanceInSolution)
            {
                var registration = this.InstalledFeatures.First(f => f.FeatureId == featureId);
                solutionState.AddFeature(featureId, featureInstance.InstanceName, registration.ExtensionManifest.Header.Version);
            }

            //
            // Update the InstantiatedFeatures list which will get the workflow into the
            // Workflow Explorer
            InstantiatedFeaturesChanged(this, EventArgs.Empty);
            RaisePropertyChanged(x => x.InstantiatedFeatures);
        }

        private void RaisePropertyChanged(Expression<Func<IFeatureManager, object>> propertyExpresion)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(
                Reflect<IFeatureManager>.GetProperty(propertyExpresion).Name));
        }

        private IFeatureCompositionService CreateFeatureCompositionService(IFeatureExtension featureInstance, string featureId)
        {
            var featureContainer = new CompositionContainer(featuresGlobalContainer);

            // Expose IFeatureExtension to the container
            featureContainer.ComposeExportedValue(featureInstance);
            featureContainer.ComposeExportedValue(InstalledFeatures.First(r => r.FeatureId == featureId));

            featureContainer.ComposeExportedValue<ExportProvider>(featureContainer);

            var compositionService = new FeatureCompositionService(featureContainer);
            // Expose IFeatureCompositionService to the container
            featureContainer.ComposeExportedValue<IFeatureCompositionService>(compositionService);

            // Satisfy imports at this level, so that the right feature-level stuff is injected instead 
            // (i.e. the feature might have specified an import of the IFeatureCompositionService and 
            // would have gotten the global one.
            compositionService.SatisfyImportsOnce(featureInstance);

            return compositionService;
        }

        public void RefreshWorkflow(IFeatureExtension feature)
        {
            FeatureExtension realFX = feature as FeatureExtension;

            //
            // First, remove our feature from the instantiated features list
            // and raise the event (which will cause it to be removed from the UX)
            //
            feature.Finish();
            instantiatedFeatures.RemoveAll(state => state.Item1.FeatureId == feature.FeatureId && state.Item1.InstanceName == feature.InstanceName);
            InstantiatedFeaturesChanged(this, EventArgs.Empty);
            RaisePropertyChanged(x => x.InstantiatedFeatures);

            realFX.GuidanceWorkflow = realFX.CreateWorkflow();
            if (realFX.GuidanceWorkflow != null)
                realFX.GuidanceWorkflow.OwningFeature = feature;

            //
            // Now put it back and make it active
            //
            instantiatedFeatures.Add(new Tuple<IFeatureExtension, IFeatureCompositionService>(feature, realFX.FeatureComposition));
            InstantiatedFeaturesChanged(this, EventArgs.Empty);
            RaisePropertyChanged(x => x.InstantiatedFeatures);
            this.ActiveFeature = feature;
        }

        public void RemoveFeatureInstance(IFeatureExtension feature)
        {
            feature.Finish();
            instantiatedFeatures.RemoveAll(state => state.Item1.FeatureId == feature.FeatureId && state.Item1.InstanceName == feature.InstanceName);
        }

        /// <summary>
        /// Finishes the given feature.
        /// </summary>
        /// <param name="instanceName">Name of the feature instance to finish.</param>
        public void Finish(string instanceName)
        {
            //ThrowIfNoSolutionState();

            var feature = instantiatedFeatures.Where(f => f.Item1.InstanceName == instanceName).FirstOrDefault();
            if (feature != null)
            {
                var featureTracer = FeatureTracer.GetSourceFor(this, feature.Item1.FeatureId, instanceName);
                using (new TraceActivity("Finishing feature", featureTracer))
                {
                    try
                    {
                        feature.Item1.Finish();
                    }
                    catch (Exception ex)
                    {
                        featureTracer.TraceWarning("An error happened while finishing the feature. State may be invalid. Continuing to remove feature from solution state.\n{0}", ex);
                    }

                    var disposable = feature.Item1 as IDisposable;
                    if (disposable != null)
                        disposable.Dispose();

                    solutionState.RemoveFeature(feature.Item1.FeatureId, instanceName);

                    InstantiatedFeaturesChanged(this, EventArgs.Empty);
                    RaisePropertyChanged(x => x.InstantiatedFeatures);

                    featureTracer.TraceInformation("Feature successfully finished.");
                }
            }
        }

        private IFeatureExtension CreateFeature(string featureId)
        {
            return this.featureFactory(this.InstalledFeatures.First(r => r.FeatureId == featureId));
        }

        private void ClearAllFeatures()
        {
            foreach (var feature in instantiatedFeatures)
            {
                var disposable = feature.Item1 as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }

            instantiatedFeatures.Clear();
        }

        private void ThrowIfNoSolutionState()
        {
            if (this.solutionState == null)
            {
                throw new InvalidOperationException(Resources.FeatureManager_MustInitializeSolutionState);
            }
        }

        private void ThrowIfFeatureNotInstalled(string featureId)
        {
            if (!this.InstalledFeatures.Any(r => r.FeatureId == featureId))
            {
                throw new NotSupportedException(string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.FeatureManager_FeatureNotInstalled,
                    featureId));
            }
        }

        private void ThrowIfAlreadyInstantiated(string featureId, string instanceName)
        {
            if (this.instantiatedFeatures.Any(tuple => tuple.Item1.InstanceName == instanceName))
            {
                throw new InvalidOperationException(string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.FeatureManager_FeatureAlreadyInstantiated,
                    featureId,
                    instanceName));
            }
        }

        /// <summary>
        /// Finds the installed feature associated with the file
        /// </summary>
        /// <param name="filename"></param>
        public IFeatureRegistration FindFeature(string filename)
        {
            string featureId = null;

            var currentDir = Path.GetDirectoryName(filename);
            while (string.IsNullOrEmpty(featureId) && !string.IsNullOrEmpty(currentDir) && Path.GetFileName(currentDir) != "Extensions")
            {
                var manifestFile = Directory.EnumerateFiles(currentDir, "*.vsixmanifest", SearchOption.TopDirectoryOnly).FirstOrDefault();
                if (manifestFile != null && !manifestFile.ToLower().EndsWith("source.extension.vsixmanifest"))
                {
                    featureId = ReadVsixIdentifier(manifestFile);
                    if (string.IsNullOrEmpty(featureId))
                        return null;
                }
                else
                {
                    // When it's already a folder, it removes the parent path.
                    currentDir = Path.GetDirectoryName(currentDir);
                }
            }

            return this.InstalledFeatures.FirstOrDefault(feature => feature.FeatureId == featureId);
        }

        private string ReadVsixIdentifier(string vsixManifest)
        {
            using (var reader = XmlReader.Create(vsixManifest))
            {
                reader.MoveToContent();

                if (reader.ReadToDescendant("Identifier", "http://schemas.microsoft.com/developer/vsx-schema/2010"))
                {
                    return reader.GetAttribute("Id");
                }
            }

            return null;
        }

        /// <summary>
        /// Returns the installed feature associated with the type
        /// </summary>
        public IFeatureRegistration FindFeature(Type type)
        {
            if (type == null)
            {
                return null;
            }

            var featureAttribute = type.Assembly.GetCustomAttribute<FeatureAttribute>();
            if (featureAttribute != null)
            {
                return this.InstalledFeatures.FirstOrDefault(feature => feature.FeatureId == featureAttribute.FeatureId);
            }

            return this.FindFeature(type.Assembly.Location);
        }


        /// <summary>
        /// Returns the first installed feature when the predicate function returns true
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IFeatureRegistration FindFeature(Func<IFeatureRegistration, bool> predicate)
        {
            return this.InstalledFeatures
                .FirstOrDefault(predicate);
        }

        /// <summary>
        /// If this a Feature Builder Solution,
        /// save the absolute path to the Feature.command file into the
        /// FeatureCallContext so we can use it in the IElementExtensions and in the
        /// GuidanceWorkflow.t4
        /// </summary>
        public void SetDSLPathIfPresent()
        {
            if (solutionState != null)
            {
                ISolution theSolution = ((SolutionDataState)solutionState).Solution;
                var dslFile = theSolution.Find("*.commands").FirstOrDefault();
                if (dslFile != null)
                    FeatureManager.FeatureBuilderDSLPath = dslFile.PhysicalPath;
                else
                    FeatureManager.FeatureBuilderDSLPath = null;
            }
        }

    }
}
