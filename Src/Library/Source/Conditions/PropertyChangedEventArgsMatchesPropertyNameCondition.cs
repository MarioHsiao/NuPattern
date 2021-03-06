﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using NuPattern.ComponentModel.Design;
using NuPattern.Diagnostics;
using NuPattern.Library.Properties;
using NuPattern.Runtime;
using NuPattern.Runtime.Events;

namespace NuPattern.Library.Conditions
{
    /// <summary>
    /// An <see cref="IEventCondition"/> that evaluates to true if the specified <see cref="PropertyName"/> is the changed property.
    /// </summary>
    [DisplayNameResource(@"PropertyChangedEventArgsMatchesPropertyNameCondition_DisplayName", typeof(Resources))]
    [DescriptionResource(@"PropertyChangedEventArgsMatchesPropertyNameCondition_Description", typeof(Resources))]
    [CategoryResource(@"AutomationCategory_Automation", typeof(Resources))]
    [CLSCompliant(false)]
    public class PropertyChangedEventArgsMatchesPropertyNameCondition : Condition, IEventCondition
    {
        private static readonly ITracer tracer = Tracer.Get<PropertyChangedEventArgsMatchesPropertyNameCondition>();

        /// <summary>
        /// Gets or sets the name of the property to filter for changes.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [DisplayNameResource(@"PropertyChangedEventArgsMatchesPropertyNameCondition_PropertyName_DisplayName", typeof(Resources))]
        [DescriptionResource(@"PropertyChangedEventArgsMatchesPropertyNameCondition_PropertyName_Description", typeof(Resources))]
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the current event.
        /// </summary>
        /// <remarks>
        /// This property belongs to the <see cref="IEventCondition"/> interface, and 
        /// is set by the event automation before invoking the condition.
        /// </remarks>
        [Browsable(false)]
        public IEvent<EventArgs> Event { get; set; }

        /// <summary>
        /// Evaluates the condition by matching the event arguments property name with the specified value.
        /// </summary>
        public override bool Evaluate()
        {
            this.ValidateObject();

            if (this.Event == null ||
                !(this.Event.EventArgs is PropertyChangedEventArgs))
                return false;

            var propertyChangedArgs = (PropertyChangedEventArgs)this.Event.EventArgs;

            if (propertyChangedArgs == null)
                return false;

            tracer.Info(
                Resources.PropertyChangedEventArgsMatchesPropertyNameCondition_TraceInitial, this.PropertyName);

            var result = propertyChangedArgs.PropertyName == this.PropertyName;

            tracer.Info(
                Resources.PropertyChangedEventArgsMatchesPropertyNameCondition_TraceEvaluate, this.PropertyName, result);

            return result;
        }
    }
}