﻿using System;
using System.Windows.Data;
using NuPattern.Runtime.UI.ViewModels;

namespace NuPattern.Runtime.UI
{
    /// <summary>
    /// Returns the element icon from NamedElementSchema or the default IconPath if the Icon doesn't exist
    /// </summary>
    internal class ItemIconWithDefaultConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var model = value as ProductElementViewModel;
            if (model != null)
            {
                var element = model.Data.Info as IPatternElementSchema;
                if (element != null)
                {
                    if (!string.IsNullOrEmpty(element.Icon))
                    {
                        return element.Icon;
                    }
                }

                return model.IconPath;
            }

            return null;
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
