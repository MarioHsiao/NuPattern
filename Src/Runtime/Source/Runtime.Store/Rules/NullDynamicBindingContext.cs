﻿using System.ComponentModel.Composition;
using NuPattern.Runtime.Bindings;

namespace NuPattern.Runtime.Store
{
    internal class NullDynamicBindingContext : IDynamicBindingContext
    {
        static NullDynamicBindingContext()
        {
            Instance = new NullDynamicBindingContext();
        }

        private NullDynamicBindingContext()
        {
            this.CompositionService = new NullCompositionService();
        }

        public static IDynamicBindingContext Instance { get; private set; }

        public System.ComponentModel.Composition.ICompositionService CompositionService { get; private set; }

        public void AddExport<T>(T instance) where T : class
        {
        }

        public void AddExport<T>(T instance, string contractName) where T : class
        {
        }

        public void Dispose()
        {
        }

        private class NullCompositionService : ICompositionService
        {
            public void SatisfyImportsOnce(System.ComponentModel.Composition.Primitives.ComposablePart part)
            {
            }
        }
    }
}
