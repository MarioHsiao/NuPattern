﻿using System;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
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
    /// Saves the linked artifacts associated to current element.
    /// </summary>
    [DisplayNameResource(@"SaveArtifactCommand_DisplayName", typeof(Resources))]
    [DescriptionResource(@"SaveArtifactCommand_Description", typeof(Resources))]
    [CategoryResource(@"AutomationCategory_Automation", typeof(Resources))]
    [CLSCompliant(false)]
    public class SaveArtifactCommand : Command
    {
        private static readonly ITraceSource tracer = Tracer.GetSourceFor<SaveArtifactCommand>();

        /// <summary>
        /// Gets or sets the current element.
        /// </summary>
        [Required]
        [Import(AllowDefault = true)]
        public IProductElement CurrentElement { get; set; }

        /// <summary>
        /// Gets or sets the URI reference service.
        /// </summary>
        [Required]
        [Import(AllowDefault = true)]
        public IUriReferenceService UriReferenceService { get; set; }

        /// <summary>
        /// Executes the command.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public override void Execute()
        {
            this.ValidateObject();

            tracer.TraceInformation(
                Resources.SaveArtifactCommand_TraceInitial, this, CurrentElement.InstanceName);

            var items = SolutionArtifactLinkReference.GetResolvedReferences(this.CurrentElement, this.UriReferenceService)
                .OfType<IItem>().ToList();
            foreach (var item in items)
            {
                try
                {
                    tracer.TraceInformation(
                        Resources.SaveArtifactCommand_TraceSave, this.CurrentElement.InstanceName, item.GetLogicalPath());

                    item.Save();
                }
                catch (Exception e)
                {
                    tracer.TraceWarning(
                        Resources.SaveArtifactCommand_TraceSaveFailed, this.CurrentElement.InstanceName, item.GetLogicalPath(), e);
                }
            }
        }
    }
}