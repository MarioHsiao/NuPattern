﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NuPattern.ComponentModel.Design;
using NuPattern.Diagnostics;
using NuPattern.Library.Properties;
using NuPattern.Runtime;
using NuPattern.Runtime.References;
using NuPattern.VisualStudio.Solution;

namespace NuPattern.Library.Commands
{
    /// <summary>
    /// Creates an artifact link between the owner element and the specified Items
    /// </summary>
    [DisplayNameResource(@"CreateArtifactLinkCommand_DisplayName", typeof(Resources))]
    [DescriptionResource(@"CreateArtifactLinkCommand_Description", typeof(Resources))]
    [CategoryResource(@"AutomationCategory_Automation", typeof(Resources))]
    [CLSCompliant(false)]
    public class CreateArtifactLinkCommand : Command
    {
        private static readonly ITracer tracer = Tracer.Get<CreateArtifactLinkCommand>();

        /// <summary>
        /// Gets or sets the URI reference service.
        /// </summary>
        [Required]
        [Import(AllowDefault = true)]
        public IUriReferenceService UriService { get; set; }

        /// <summary>
        /// Gets or sets the current element.
        /// </summary>
        [Required]
        [Import(AllowDefault = true)]
        public IProductElement CurrentElement { get; set; }

        /// <summary>
        /// Gets or sets the solution.
        /// </summary>
        [Required]
        [Import(AllowDefault = true)]
        public ISolution Solution { get; set; }

        /// <summary>
        /// The Items to link to the owner element.
        /// </summary>
        [Required]
        [DisplayNameResource(@"CreateArtifactLinkCommand_Items_DisplayName", typeof(Resources))]
        [DescriptionResource(@"CreateArtifactLinkCommand_Items_Description", typeof(Resources))]
        public virtual IEnumerable<string> Items { get; set; }

        /// <summary>
        /// Gets or sets an optional tag on the generated reference for each link
        /// </summary>
        [DisplayNameResource(@"CreateArtifactLinkCommand_Tag_DisplayName", typeof(Resources))]
        [DescriptionResource(@"CreateArtifactLinkCommand_Tag_Description", typeof(Resources))]
        [DefaultValue("")]
        public string Tag { get; set; }

        /// <summary>
        /// Executes the command linking the Items to the owner element.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
        public override void Execute()
        {
            this.ValidateObject();

            tracer.Info(
                Resources.CreateArtifactLinkCommand_TraceInitial, this.CurrentElement.InstanceName);

            foreach (var item in Solution.Traverse().Where(t => !string.IsNullOrEmpty(t.PhysicalPath) && Items.Contains(t.PhysicalPath.ToLowerInvariant())))
            {
                tracer.Info(
                    Resources.CreateArtifactLinkCommand_TraceCreateLink, this.CurrentElement.InstanceName, item.GetLogicalPath());

                SolutionArtifactLinkReference.AddReference(this.CurrentElement, UriService.CreateUri(item))
                    .Tag = this.Tag ?? string.Empty;
            }
        }
    }
}
