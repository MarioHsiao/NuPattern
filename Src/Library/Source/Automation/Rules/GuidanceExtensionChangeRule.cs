﻿using Microsoft.VisualStudio.Modeling;

namespace NuPattern.Library.Automation
{
    /// <summary>
    /// Change rule for <see cref="GuidanceExtension"/> domain class.
    /// </summary>
    [RuleOn(typeof(GuidanceExtension), FireTime = TimeToFire.TopLevelCommit)]
    internal class GuidanceExtensionChangeRule : ChangeRule
    {
        /// <summary>
        /// Handles the property change event for the AssociatedGuidance properties.
        /// </summary>
        /// <param name="e">The event args.</param>
        public override void ElementPropertyChanged(ElementPropertyChangedEventArgs e)
        {
            Guard.NotNull(() => e, e);

            if ((e.DomainProperty.Id == GuidanceExtension.ExtensionIdDomainPropertyId)
                || (e.DomainProperty.Id == GuidanceExtension.GuidanceInstanceNameDomainPropertyId)
                || (e.DomainProperty.Id == GuidanceExtension.GuidanceSharedInstanceDomainPropertyId)
                || (e.DomainProperty.Id == GuidanceExtension.GuidanceActivateOnCreationDomainPropertyId))
            {
                // Ensure we are not in deserialization mode.
                if (!e.ModelElement.Store.TransactionManager.CurrentTransaction.IsSerializing)
                {
                    GuidanceExtension guidanceExtension = (GuidanceExtension)e.ModelElement;
                    if (guidanceExtension != null)
                    {
                        guidanceExtension.EnsureGuidanceExtensionAutomation();
                    }
                }
            }
        }
    }
}