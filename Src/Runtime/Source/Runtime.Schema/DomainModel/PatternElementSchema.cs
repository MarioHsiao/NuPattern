﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;
using NuPattern.Modeling;
using NuPattern.Runtime.Bindings;
using NuPattern.Runtime.Schema.Design;

namespace NuPattern.Runtime.Schema
{
    /// <summary>
    /// Base container class for elements that can have properties.
    /// </summary>
    [TypeDescriptionProvider(typeof(PatternElementSchemaTypeDescriptorProvider))]
    partial class PatternElementSchema : IInterceptorTarget
    {
        private ValidationBindingSettings[] validatorSettings;

        /// <summary>
        /// Gets the model element.
        /// </summary>
        /// <returns>The model element.</returns>
        public ModelElement Element
        {
            get { return this; }
        }

        /// <summary>
        /// Gets the validation settings.
        /// </summary>
        public IEnumerable<IBindingSettings> ValidationSettings
        {
            get { return this.validatorSettings ?? (this.validatorSettings = this.GetValidationSettings()); }
        }

        /// <summary>
        /// Gets the <see cref="PropertySchema"/> with the specified name.
        /// </summary>
        public PropertySchema this[string name]
        {
            get { return this.Properties.Single(prop => prop.Name.Equals(name, StringComparison.Ordinal)); }
        }

        /// <summary>
        /// Called by the model before the element is deleted.
        /// </summary>
        protected override void OnDeleting()
        {
            base.OnDeleting();

            if (!this.IsLocked(Locks.Delete))
            {
                this.Store.TransactionManager.DoWithinTransaction(() =>
                    this.Properties.ForEach(p => p.SetLocks(Locks.None)));
            }
        }

        private ValidationBindingSettings[] GetValidationSettings()
        {
            if (string.IsNullOrEmpty(this.ValidationRules))
            {
                return new ValidationBindingSettings[0];
            }

            return BindingSerializer.Deserialize<ValidationBindingSettings[]>(this.ValidationRules);
        }
    }
}