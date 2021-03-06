using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TemplateWizard;
using NuPattern.Diagnostics;
using NuPattern.VisualStudio.Properties;
using NuPattern.VisualStudio.Solution.Templates;

namespace NuPattern.VisualStudio.TemplateWizards
{
    /// <summary>
    /// Custom template wizard extension that parses custom wizard data 
    /// looking for additional guid entries and create new guids to use during template unfolding.
    /// </summary>
    [CLSCompliant(false)]
    public class GuidGeneratorTemplateWizard : TemplateWizard
    {
        private static readonly ITracer tracer = Tracer.Get<GuidGeneratorTemplateWizard>();

        private const string NewGuidElementName = "NewGuid";
        private const string NewGuidKeyName = "Key";

        /// <summary>
        /// Runs custom wizard logic at the beginning of a template wizard run.
        /// </summary>
        /// <param name="automationObject">The automation object being used by the template wizard.</param>
        /// <param name="replacementsDictionary">The list of standard parameters to be replaced.</param>
        /// <param name="runKind">A <see cref="T:Microsoft.VisualStudio.TemplateWizard.WizardRunKind"/> indicating the type of wizard run.</param>
        /// <param name="customParams">The custom parameters with which to perform parameter replacement in the project.</param>
        public override void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            base.RunStarted(automationObject, replacementsDictionary, runKind, customParams);

            Guard.NotNull(() => replacementsDictionary, replacementsDictionary);
            Guard.NotNull(() => customParams, customParams);

            var wizardData = Enumerable.FirstOrDefault<IVsTemplateWizardData>(this.TemplateSchema.WizardData);
            if (wizardData != null)
            {
                var additionalReplacements = from element in wizardData.Elements
                                             where element.Name.Equals(NewGuidElementName, StringComparison.OrdinalIgnoreCase) &&
                                                 !string.IsNullOrEmpty(element.GetAttribute(NewGuidKeyName))
                                             select new
                                             {
                                                 Key = element.GetAttribute(NewGuidKeyName),
                                                 Value = Guid.NewGuid().ToString()
                                             };

                foreach (var replacement in additionalReplacements)
                {
                    tracer.Verbose(Resources.GuidGeneratorTemplateWizard_GeneratedNewGuid, replacement.Key);
                    replacementsDictionary[replacement.Key] = replacement.Value;
                }
            }
        }
    }
}