﻿using System.ComponentModel;
using System.Linq;
using NuPattern.Runtime.Schema.Design;

namespace NuPattern.Runtime.Schema
{
    /// <summary>
    /// Customizes the CustomizationPolicy domain class.
    /// </summary>
    [TypeDescriptionProvider(typeof(CustomizationPolicyTypeDescriptionProvider))]
    partial class CustomizationPolicySchemaBase
    {
        /// <summary>
        /// Returns the value of the IsModified property.
        /// </summary>
        internal bool GetIsModifiedValue()
        {
            return this.Settings.Any(setting => setting.IsModified);
        }

        /// <summary>
        /// Returns the value of the CustomizedLevel porperty.
        /// </summary>
        internal CustomizedLevel GetCustomizationLevelValue()
        {
            // No settings, means no customization
            var settingsCount = this.Settings.Count();
            if (settingsCount == 0)
            {
                return CustomizedLevel.None;
            }

            // Determine level from remaining enabled settings.
            var enabledSettingsCount = this.Settings.Count(setting => setting.IsEnabled);
            var enabledCustomizedSettingsCount = this.Settings.Count(setting => setting.IsEnabled && setting.Value == true);
            if (enabledSettingsCount == 0)
            {
                return CustomizedLevel.None;
            }

            if (enabledCustomizedSettingsCount == enabledSettingsCount)
            {
                return CustomizedLevel.All;
            }

            return enabledCustomizedSettingsCount == 0 ? CustomizedLevel.None : CustomizedLevel.Partially;
        }
    }
}