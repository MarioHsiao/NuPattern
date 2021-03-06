﻿using System;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using NuPattern.ComponentModel.Design;
using NuPattern.Diagnostics;
using NuPattern.Library.Properties;
using NuPattern.Runtime;

namespace NuPattern.Library.ValueProviders
{
    /// <summary>
    /// A custom value provider that is used to provide values at runtime for other types of configured automation.
    /// </summary>
    [DisplayNameResource(@"RemoveForbiddenCharsExpressionValueProvider_DisplayName", typeof(Resources))]
    [DescriptionResource(@"RemoveForbiddenCharsExpressionValueProvider_Description", typeof(Resources))]
    [CategoryResource(@"AutomationCategory_General", typeof(Resources))]
    [CLSCompliant(false)]
    public class RemoveForbiddenCharsExpressionValueProvider : ValueProvider
    {
        private static readonly ITracer tracer = Tracer.Get<RemoveForbiddenCharsExpressionValueProvider>();

        /// <summary>
        /// Gets the current element in the pattern model upon which this ValueProvider is configured.
        /// </summary>
        [Import(AllowDefault = true)]
        public IInstanceBase CurrentElement
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the expression to evaluate.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [DisplayNameResource(@"RemoveForbiddenCharsExpressionValueProvider_Expression_DisplayName", typeof(Resources))]
        [DescriptionResource(@"RemoveForbiddenCharsExpressionValueProvider_Expression_Description", typeof(Resources))]
        public string Expression
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the characters that are forbidden.
        /// </summary>
        [DescriptionResource(@"RemoveForbiddenCharsExpressionValueProvider_ForbiddenChars_Description", typeof(Resources))]
        [DisplayNameResource(@"RemoveForbiddenCharsExpressionValueProvider_ForbiddenChars_DisplayName", typeof(Resources))]
        public string ForbiddenChars
        {
            get;
            set;
        }

        /// <summary>
        /// Returns the result of evaluation of this provider.
        /// </summary>
        public override object Evaluate()
        {
            this.ValidateObject();

            var productElement = this.CurrentElement as IProductElement;
            var elementName = (productElement != null) ? productElement.InstanceName : this.CurrentElement.Info.DisplayName;

            tracer.Info(
                Resources.RemoveForbiddenCharsExpressionValueProvider_TraceInitial, this.Expression, this.ForbiddenChars, elementName);

            var result = ExpressionEvaluator.Evaluate(this.CurrentElement, this.Expression);
            if (result == null)
            {
                tracer.Warn(
                    Resources.RemoveForbiddenCharsExpressionValueProvider_TraceResolvedNullExpression, this.Expression, elementName);
            }
            else
            {
                //Remove forbidden chars
                if (!string.IsNullOrEmpty(this.ForbiddenChars)
                    && !string.IsNullOrEmpty(result))
                {
                    foreach (var character in this.ForbiddenChars)
                    {
                        result = result.Replace(character.ToString(), string.Empty);
                    }
                }
            }

            tracer.Info(
                Resources.RemoveForbiddenCharsExpressionValueProvider_TraceEvaluation, this.Expression, this.ForbiddenChars, elementName, result);

            return result;
        }
    }
}
