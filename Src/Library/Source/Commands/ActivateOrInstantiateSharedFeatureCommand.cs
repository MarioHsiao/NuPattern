﻿using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Design;
using System.Linq;
using Microsoft.VisualStudio.Shell;
using NuPattern.ComponentModel.Design;
using NuPattern.Diagnostics;
using NuPattern.Library.Properties;
using NuPattern.Runtime;
using NuPattern.Runtime.Design;
using NuPattern.Runtime.Guidance;

namespace NuPattern.Library.Commands
{
    /// <summary>
    /// Command that activates or instantiates a new feature.
    /// </summary>
    [DisplayNameResource("ActivateOrInstantiateSharedFeatureCommand_DisplayName", typeof(Resources))]
    [CategoryResource("AutomationCategory_Guidance", typeof(Resources))]
    [DescriptionResource("ActivateOrInstantiateSharedFeatureCommand_Description", typeof(Resources))]
    [CLSCompliant(false)]
    public class ActivateOrInstantiateSharedFeatureCommand : Command
    {
        private static readonly ITraceSource tracer = Tracer.GetSourceFor<ActivateOrInstantiateSharedFeatureCommand>();

        /// <summary>
        /// Gets or sets the feature id.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [TypeConverter(typeof(GuidanceExtensionsTypeConverter))]
        [Editor(typeof(StandardValuesEditor), typeof(UITypeEditor))]
        [DisplayNameResource("InstantiateFeatureCommand_GuidanceExtensionId_DisplayName", typeof(Resources))]
        [DescriptionResource("ActivateFeatureCommand_GuidanceExtensionId_Description", typeof(Resources))]
        public string GuidanceExtensionId { get; set; }

        /// <summary>
        /// Gets or sets the guidance extension manager.
        /// </summary>
        [Required]
        [Import]
        public IGuidanceManager GuidanceManager
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the service provider.
        /// </summary>
        [Required]
        [Import(typeof(SVsServiceProvider))]
        public IServiceProvider ServiceProvider
        {
            get;
            set;
        }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        public override void Execute()
        {
            this.ValidateObject();

            tracer.TraceInformation(
                Resources.ActivateOrInstantiateSharedFeatureCommand_TraceInitial, this.GuidanceExtensionId);

            // Ensure the feature type exists
            var featureRegistration = this.GuidanceManager.InstalledGuidanceExtensions
                .FirstOrDefault(feature => feature.ExtensionId.Equals(this.GuidanceExtensionId, StringComparison.OrdinalIgnoreCase));
            if (featureRegistration != null)
            {
                // Show the guidance windows
                if (this.ServiceProvider != null)
                {
                    tracer.TraceVerbose(
                        Resources.ActivateOrInstantiateSharedFeatureCommand_TraceShowingGuidanceExplorer);

                    this.GuidanceManager.ShowGuidanceWindows(this.ServiceProvider);
                }

                // Ensure we are not sharing
                var featureInstance = this.GuidanceManager.InstantiatedGuidanceExtensions.FirstOrDefault(f => f.ExtensionId.Equals(this.GuidanceExtensionId, StringComparison.OrdinalIgnoreCase));
                if (featureInstance == null)
                {
                    // Create a default name
                    var instanceName = this.GuidanceManager.GetUniqueInstanceName(featureRegistration.DefaultName);

                    tracer.TraceInformation(
                        Resources.ActivateOrInstantiateSharedFeatureCommand_TraceInstantiate, this.GuidanceExtensionId, instanceName);

                    // Instantiate the feature
                    featureInstance = this.GuidanceManager.Instantiate(this.GuidanceExtensionId, instanceName);
                }

                tracer.TraceInformation(
                        Resources.ActivateOrInstantiateSharedFeatureCommand_TraceActivate, featureInstance.InstanceName);

                // Activate feature
                this.GuidanceManager.ActiveGuidanceExtension = featureInstance;
            }
            else
            {
                tracer.TraceError(
                    Resources.ActivateOrInstantiateSharedFeatureCommand_TraceFeatureNotFound, this.GuidanceExtensionId);
            }
        }
    }
}
