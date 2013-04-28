﻿using System.ComponentModel;

namespace NuPattern.Runtime.Design
{
    /// <summary>
    ///  ValidateOnBuildConverter Typeconverter
    /// </summary>
    public class ValidateOnBuildConverter : StringConverter
    {
        /// <summary>
        /// Returns whether this object supports a standard set of values that can be picked from a list, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="ITypeDescriptorContext"/> that provides a format context.</param>
        /// <returns>
        /// true if <see cref="GetStandardValues"/> should be called to find a common set of values the object supports; otherwise, false.
        /// </returns>
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// Returns a collection of standard values for the data type this type converter is designed for when provided with a format context.
        /// </summary>
        /// <param name="context">An <see cref="ITypeDescriptorContext"/> that provides a format context that can be used to extract additional information about the environment from which this converter is invoked. This parameter or properties of this parameter can be null.</param>
        /// <returns>
        /// A <see cref="TypeConverter.StandardValuesCollection"/> that holds a standard set of valid values, or null if the data type does not support a standard set of values.
        /// </returns>
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(new string[] { @"Always", @"Never" });
        }

        /// <summary>
        ///  Returns whether the collection of standard values returned from <see cref="GetStandardValues"/> is an exclusive list.
        /// </summary>
        /// <param name="context">An <see cref="ITypeDescriptorContext"/> that provides a format context.</param>
        /// <returns>true if the System.ComponentModel.TypeConverter.StandardValuesCollection
        ///     returned from System.ComponentModel.TypeConverter.GetStandardValues() is
        ///     an exhaustive list of possible values; false if other values are possible.</returns>
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}