﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using NuPattern;
using NuPattern.Diagnostics;

namespace Microsoft.VisualStudio.TeamArchitect.PowerTools.Features
{
    /// <summary>
    /// Default implementation of <see cref="IFeatureCompositionService"/> 
    /// that delegates to a composition container.
    /// </summary>
    /// <devdoc>
    /// This class does not have a corresponding spec class as it's 
    /// essencially a facade over a CompositionContainer, a somewhat simplified 
    /// API for feature authors that also allows better testability 
    /// by implementing an interface that can be easiy mocked.
    /// </devdoc>
    public class FeatureCompositionService : IFeatureCompositionService
    {
        static readonly ITraceSource tracer = Tracer.GetSourceFor<FeatureCompositionService>();
#if DEBUG
        // Defined as internal so we can do MEF logging in our package loading.
        internal CompositionContainer container;
#else
        CompositionContainer container;
#endif

        /// <summary>
        /// Exports a singleton of the composition service, wrapping the 
        /// global <see cref="FeaturesGlobalContainer"/>.
        /// </summary>
        [Export]
        public static IFeatureCompositionService Instance { get; internal set; }

        static FeatureCompositionService()
        {
            Instance = new FeatureCompositionService(FeaturesGlobalContainer.Instance);
            // Publish our own service to the features global container.
            FeaturesGlobalContainer.Instance.ComposeExportedValue<IFeatureCompositionService>(Instance);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureCompositionService"/> class 
        /// with the given underlying container.
        /// </summary>
        public FeatureCompositionService(CompositionContainer container)
        {
            Guard.NotNull(() => container, container);

            this.container = container;
        }

        /// <summary>
        /// See <see cref="ICompositionService.SatisfyImportsOnce"/>.
        /// </summary>
        public void SatisfyImportsOnce(ComposablePart part)
        {
            this.container.SatisfyImportsOnce(part);
        }

        /// <summary>
        /// Composes the given parts together.
        /// </summary>
        public void ComposeParts(params object[] attributedParts)
        {
            this.container.ComposeParts(attributedParts);
        }

        /// <summary>
        /// Gets the export of the given type.
        /// </summary>
        public Lazy<T> GetExport<T>()
        {
            return this.container.GetExport<T>();
        }

        /// <summary>
        /// Gets the export of the given type, that matches the contract name.
        /// </summary>
        public Lazy<T> GetExport<T>(string contractName)
        {
            return this.container.GetExport<T>(contractName);
        }

        /// <summary>
        /// Gets the export of the given type, that matches the given metadat.
        /// </summary>
        public Lazy<T, TMetadataView> GetExport<T, TMetadataView>()
        {
            return this.container.GetExport<T, TMetadataView>();
        }

        /// <summary>
        /// Gets the export of the given type, that matches the given metadata and contract name.
        /// </summary>
        public Lazy<T, TMetadataView> GetExport<T, TMetadataView>(string contractName)
        {
            return this.container.GetExport<T, TMetadataView>(contractName);
        }

        /// <summary>
        /// Gets the exported value of the given type.
        /// </summary>
        public T GetExportedValue<T>()
        {
            return this.container.GetExportedValue<T>();
        }

        /// <summary>
        /// Gets the exported value of the given type, that matches the contract name.
        /// </summary>
        public T GetExportedValue<T>(string contractName)
        {
            return this.container.GetExportedValue<T>(contractName);
        }

        /// <summary>
        /// Gets the exported value of the given type.
        /// </summary>
        public T GetExportedValueOrDefault<T>()
        {
            return this.container.GetExportedValueOrDefault<T>();
        }

        /// <summary>
        /// Gets the exported value of the given type, that matches the contract name.
        /// </summary>
        public T GetExportedValueOrDefault<T>(string contractName)
        {
            return this.container.GetExportedValueOrDefault<T>(contractName);
        }

        /// <summary>
        /// Gets the exported values of the given type.
        /// </summary>
        public IEnumerable<T> GetExportedValues<T>()
        {
            return this.container.GetExportedValues<T>();
        }

        /// <summary>
        /// Gets the exported values of the given type, that matches the contract name.
        /// </summary>
        public IEnumerable<T> GetExportedValues<T>(string contractName)
        {
            return this.container.GetExportedValues<T>(contractName);
        }

        /// <summary>
        /// Gets the exports of the given type.
        /// </summary>
        public IEnumerable<Lazy<T>> GetExports<T>()
        {
            return this.container.GetExports<T>();
        }

        /// <summary>
        /// Gets the exports of the given type, that matches the contract name.
        /// </summary>
        public IEnumerable<Lazy<T>> GetExports<T>(string contractName)
        {
            return this.container.GetExports<T>(contractName);
        }

        /// <summary>
        /// Gets the exports of the given type, that matches the given metadata.
        /// </summary>
        public IEnumerable<Lazy<T, TMetadataView>> GetExports<T, TMetadataView>()
        {
            return this.container.GetExports<T, TMetadataView>();
        }

        /// <summary>
        /// Gets the exports of the given type, that matches the given metadata and contract name.
        /// </summary>
        public IEnumerable<Lazy<T, TMetadataView>> GetExports<T, TMetadataView>(string contractName)
        {
            return this.container.GetExports<T, TMetadataView>(contractName);
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            // this.container.Dispose();
        }
    }
}
