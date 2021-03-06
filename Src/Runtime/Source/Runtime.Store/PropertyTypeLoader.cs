﻿using System;
using System.Globalization;
using NuPattern.Diagnostics;
using NuPattern.Runtime.Store.Properties;

namespace NuPattern.Runtime.Store
{
    /// <summary>
    /// Loads the type of a property.
    /// </summary>
    internal static class PropertyTypeLoader
    {
        private static readonly ITracer tracer = Tracer.Get(typeof(PropertyTypeLoader));

        /// <summary>
        /// Tries to load the property type, and logs a warning for the failure if it can't.
        /// </summary>
        public static Type TryLoad(this IPropertyInfo info)
        {
            if (info == null || string.IsNullOrEmpty(info.Type))
                return null;

            var type = Type.GetType(info.Type);

            if (type == null)
            {
                tracer.Warn(string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.PropertyTypeLoader_FailedToLoadPropertyType,
                    info.Parent.Name,
                    info.Name,
                    info.Type));
            }

            return type;
        }
    }
}
