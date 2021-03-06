﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NuPattern.Authoring.Guidance;
using NuPattern.Authoring.PatternToolkit.Automation.Properties;
using NuPattern.ComponentModel.Design;
using NuPattern.Diagnostics;
using NuPattern.Runtime.Validation;
using NuPattern.VisualStudio.Solution;

namespace NuPattern.Authoring.PatternToolkit.Automation.ValidationRules
{
    /// <summary>
    /// A custom validation rule that verifies values of properties or instances of elements.
    /// </summary>
    [DisplayNameResource("ValidateGuidanceDocument_DisplayName", typeof(Resources))]
    [CategoryResource("AutomationCategory_PatternToolkitAuthoring", typeof(Resources))]
    [DescriptionResource("ValidateGuidanceDocument_Description", typeof(Resources))]
    [CLSCompliant(false)]
    public class ValidateGuidanceDocument : ValidationRule
    {
        private static readonly ITracer tracer = Tracer.Get<ValidateGuidanceDocument>();
        private IGuidanceProcessor processor;

        /// <summary>
        /// Gets the URI reference service.
        /// </summary>
        [Required]
        [Import(AllowDefault = true)]
        public IUriReferenceService UriReferenceService
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the current solution
        /// </summary>
        [Required]
        [Import(AllowDefault = true)]
        public ISolution Solution
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the current element.
        /// </summary>
        [Import(AllowDefault = true)]
        public IGuidance CurrentElement
        {
            get;
            set;
        }

        /// <summary>
        /// Evaluates the violations for the rule.
        /// </summary>
        /// <remarks></remarks>
        public override IEnumerable<ValidationResult> Validate()
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            this.ValidateObject();

            tracer.Info(
                Resources.ValidateGuidanceDocument_TraceInitial, this.CurrentElement.InstanceName);

            // Get guidance document path
            var documentFilePath = GuidanceDocumentHelper.GetDocumentPath(tracer,
                this.CurrentElement.AsElement(), this.UriReferenceService);

            if (this.processor == null)
            {
                this.processor = new TocGuidanceProcessor(documentFilePath,
                    this.CurrentElement.Parent.Parent.PatternToolkitInfo.Identifier, this.CurrentElement.ProjectContentPath);
            }

            // Validate document
            errors.AddRange(this.processor.ValidateDocument());

            tracer.Info(
                Resources.ValidateGuidanceDocument_TraceValidation, this.CurrentElement.InstanceName, !errors.Any());

            return errors;
        }
    }
}
