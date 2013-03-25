﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.VisualStudio.TeamArchitect.PowerTools.Features.Diagnostics;
using NuPattern.ComponentModel.Design;
using NuPattern.Extensibility;
using NuPattern.Library.Properties;

namespace NuPattern.Library.Conditions
{
    /// <summary>
    /// Checks if the dragged data contains files that can be dropped
    /// </summary>
    [DisplayNameResource("DropFileCondition_DisplayName", typeof(Resources))]
    [DescriptionResource("DropFileCondition_Description", typeof(Resources))]
    [CategoryResource("AutomationCategory_Automation", typeof(Resources))]
    [CLSCompliant(false)]
    public class DropFileCondition : DropItemCondition
    {
        private static readonly ITraceSource tracer = Tracer.GetSourceFor<DropFileCondition>();

        /// <summary>
        /// Gets or sets the file extension which can be dropped.
        /// </summary>
        [DisplayNameResource("DropFileCondition_Extension_DisplayName", typeof(Resources))]
        [DescriptionResource("DropFileCondition_Extension_Description", typeof(Resources))]
        [Required(AllowEmptyStrings = false)]
        public virtual string Extension
        {
            get;
            set;
        }

        /// <summary>
        /// Evaluates the condition
        /// </summary>
        public override bool Evaluate()
        {
            this.ValidateObject();

            tracer.TraceInformation(
                Resources.DropFileCondition_TraceInitial, this.Extension);

            return base.Evaluate();
        }

        /// <summary>
        /// Returns the dragged items.
        /// </summary>
        /// <returns></returns>
        protected sealed override IEnumerable<string> GetDraggedItems()
        {
            var draggedFiles = GetDraggedFiles();
            if (draggedFiles != null && draggedFiles.Any())
            {
                tracer.TraceInformation(
                    Resources.DropFileCondition_TraceEvaluationManyFiles, this.Extension, draggedFiles.Count());
            }

            return draggedFiles;
        }

        /// <summary>
        /// Returns the files that can be dragged over the current element.
        /// </summary>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        protected virtual IEnumerable<string> GetDraggedFiles()
        {
            var items = this.DragArgs.GetWindowsFilePaths();
            if (items.Any())
            {
                var matchingFiles = items.GetPathsEndingWithExtensions(this.Extension);
                if (matchingFiles.Any())
                {
                    return matchingFiles;
                }
            }

            return Enumerable.Empty<string>();
        }

    }
}
