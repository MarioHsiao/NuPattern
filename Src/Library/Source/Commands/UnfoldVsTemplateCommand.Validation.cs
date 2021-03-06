﻿using System;
using Microsoft.VisualStudio.Modeling;
using NuPattern.Diagnostics;
using NuPattern.Library.Automation;
using NuPattern.Library.Automation.Template;
using NuPattern.Library.Properties;
using NuPattern.Reflection;
using NuPattern.Runtime;

namespace NuPattern.Library.Commands
{
    /// <summary>
    /// Validations for the <see cref="UnfoldVsTemplateCommand"/> command
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "VsTemplate"), CommandValidationRule(typeof(UnfoldVsTemplateCommand))]
    public class UnfoldVsTemplateCommandValidation : ICommandValidationRule
    {
        private static readonly ITracer tracer = Tracer.Get<UnfoldVsTemplateCommandValidation>();

        /// <summary>
        /// Called when validations are needed for the command
        /// </summary>
        /// <param name="context">Validation Context where to add validation errors</param>
        /// <param name="settingsElement">The settings element in the model being validated</param>
        /// <param name="settings">Settings for the command</param>
        public void Validate(Microsoft.VisualStudio.Modeling.Validation.ValidationContext context, IAutomationSettingsSchema settingsElement, ICommandSettings settings)
        {
            try
            {
                Guard.NotNull(() => settings, settings);

                var templateValidator = new TemplateValidator(settings.Name,
                        new UnfoldVsTemplateCommand.UnfoldVsTemplateSettings
                        {
                            SanitizeName = settings.GetPropertyValue<bool>(Reflector<UnfoldVsTemplateCommand>.GetPropertyName(u => u.SanitizeName)),
                            SyncName = settings.GetPropertyValue<bool>(Reflector<UnfoldVsTemplateCommand>.GetPropertyName(u => u.SyncName)),
                            TemplateAuthoringUri = settings.GetPropertyValue<string>(Reflector<UnfoldVsTemplateCommand>.GetPropertyName(u => u.TemplateAuthoringUri)),
                            TemplateUri = settings.GetPropertyValue<string>(Reflector<UnfoldVsTemplateCommand>.GetPropertyName(u => u.TemplateUri)),
                            SettingsElement = settingsElement,
                            OwnerElement = settings.Owner,
                        }, context, ((ModelElement)settings).Store);
                templateValidator.ValidateCommandSettings(tracer);
            }
            catch (Exception ex)
            {
                tracer.Error(
                    ex,
                    Resources.ValidationMethodFailed_Error,
                    Reflector<TemplateValidator>.GetMethod(n => n.ValidateCommandSettings(null)).Name);

                throw;
            }
        }
    }
}
