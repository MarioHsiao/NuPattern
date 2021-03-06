﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NuPattern.Diagnostics;
using NuPattern.Library.Properties;
using NuPattern.Runtime;

namespace NuPattern.Library.Conditions
{
    /// <summary>
    /// Checks if the dragged data contains items that can be dropped
    /// </summary>
    [CLSCompliant(false)]
    public abstract class DropItemCondition : Condition
    {
        private static readonly ITracer tracer = Tracer.Get<DropItemCondition>();

        /// <summary>
        /// Gets or sets the drag arguments
        /// </summary>
        [Required]
        [Import(AllowDefault = true)]
        protected System.Windows.DragEventArgs DragArgs
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

            tracer.Info(
                Resources.DropItemCondition_TraceInitial);

            //Get draggable items
            var draggedItems = GetDraggedItems();
            if (draggedItems != null && draggedItems.Any())
            {
                return true;
            }
            else
            {
                tracer.Info(
                    Resources.DropItemCondition_TraceEvaluationNoItems);

                return false;
            }
        }

        /// <summary>
        /// Gets the dragged items to process.
        /// </summary>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        protected abstract IEnumerable<string> GetDraggedItems();

    }
}
