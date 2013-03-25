﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using NuPattern.ComponentModel;
using NuPattern.Extensibility.Bindings.Design;

namespace NuPattern.Extensibility
{
    /// <summary>
    /// Extensions that property and type descriptors could use.
    /// </summary>
    public static class DescriptorExtensions
    {
        /// <summary>
        /// Determines whether the specified property has a <see cref="DesignOnlyAttribute"/> set.
        /// </summary>
        public static bool IsDesignOnlyProperty(this PropertyDescriptor property)
        {
            Guard.NotNull(() => property, property);

            return
                property.Attributes.OfType<DesignOnlyAttribute>().Any<DesignOnlyAttribute>(a => a.IsDesignOnly);
        }

        /// <summary>
        /// Determines if the descriptor represents an automatic design collection property.
        /// </summary>
        public static bool IsAutoDesignCollectionProperty(this PropertyDescriptor descriptor)
        {
            var editor = descriptor.GetEditor(typeof(UITypeEditor));
            var converter = descriptor.Converter;

            // Descriptor must be using a Collection<T>
            var supportedCollectionType = descriptor.IsPropertyTypeGeneric(typeof(Collection<>));
            // Descriptor must be using a derivative of Extensibility.DesignCollectionEditor editor, 
            // or default collection editor, NOT declare an arbitrary one or a derivative of default collection editor
            var supportedEditor = ((editor is NuPattern.ComponentModel.Design.DesignCollectionEditor) ||
                                   (editor != null && editor.GetType() == typeof(System.ComponentModel.Design.CollectionEditor)));
            // Descriptor must be using a derivative of Extensibility.DesignCollectionConverter, 
            // or default collection converter, NOT declare an arbitrary one or a derivative of default collection converter
            var supportedConverter = ((converter != null && converter.GetType() == typeof(System.ComponentModel.CollectionConverter)) ||
                                      (converter is DesignCollectionConverter));

            return (supportedCollectionType && supportedEditor && supportedConverter);
        }
    }
}
