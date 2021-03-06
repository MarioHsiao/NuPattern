﻿using System;
using System.Linq;
using Microsoft.VisualStudio.Modeling;
using NuPattern.Diagnostics;
using NuPattern.Runtime.Store.Properties;

namespace NuPattern.Runtime.Store
{
    /// <summary>
    /// Triggers this notification rule whether a <see cref="Product"/> is added.
    /// </summary>
    [RuleOn(typeof(Property), FireTime = TimeToFire.LocalCommit)]
    internal class PropertyAddRule : AddRule
    {
        private static readonly ITracer tracer = Tracer.Get<PropertyAddRule>();

        /// <summary>
        /// Triggers this notification rule whether a <see cref="Property"/> is added.
        /// </summary>
        /// <param name="e">The provided data for this event.</param>
        public override void ElementAdded(ElementAddedEventArgs e)
        {
            Guard.NotNull(() => e, e);

            var property = (Property)e.ModelElement;

            var info = FindInfo(property.Owner, property.DefinitionId);
            if (info != null)
            {
                property.Info = info;
            }
            else
            {
                tracer.Warn(Resources.TracerWarning_PropertyInfoNotFound, property.Id);
            }
        }

        private static IPropertyInfo FindInfo(ProductElement owner, Guid id)
        {
            if (owner != null && owner.Info != null)
            {
                return owner.Info.Properties.FirstOrDefault(p => p.Id == id);
            }

            return null;
        }
    }
}