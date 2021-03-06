﻿using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using System.Reflection;
using NuPattern.ComponentModel.Design;
using NuPattern.Properties;
#if VSVER10
using NuPattern.Reflection;
#endif

namespace NuPattern.ComponentModel
{
    /// <summary>
    /// Extensions that property and type descriptors could use.
    /// </summary>
    public static class DescriptorExtensions
    {
        /// <summary>
        /// Determines whether the specified property is imported from MEF.
        /// </summary>
        public static bool IsImported(this PropertyDescriptor property)
        {
            Guard.NotNull(() => property, property);

            return
                property.Attributes.OfType<ImportAttribute>().Any<ImportAttribute>() ||
                property.Attributes.OfType<ImportManyAttribute>().Any<ImportManyAttribute>();
        }

        /// <summary>
        /// Determined whether the instance is of the specified generic type.
        /// </summary>
        /// <param name="instanceType">The type of the object.</param>
        /// <param name="ofGenericType">The generic type of the object to compare to. (i.e. typeof(MyGeneric{}))</param>
        public static bool IsOfGenericType(this Type instanceType, Type ofGenericType)
        {
            Guard.NotNull(() => instanceType, instanceType);
            Guard.NotNull(() => ofGenericType, ofGenericType);

            if (!ofGenericType.IsGenericType)
            {
                return false;
            }

            if (instanceType.IsGenericType)
            {
                if (instanceType.GetGenericTypeDefinition() == ofGenericType.GetGenericTypeDefinition())
                {
                    return true;
                }
                else
                {
                    return (ofGenericType == instanceType.GetGenericTypeDefinition()
                            || ofGenericType.IsAssignableFrom(instanceType.GetGenericTypeDefinition()));
                }
            }
            else
            {
                // Test the inheritance chain
                var interfaces = instanceType.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == ofGenericType);
                if (interfaces.Any())
                {
                    return true;
                }
                else
                {
                    // Enumerate base interfaces
                    if (instanceType.BaseType != null)
                    {
                        return instanceType.BaseType.IsOfGenericType(ofGenericType);
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Determines whether the specified property is a generic of the specified type.
        /// </summary>
        public static bool IsPropertyTypeGeneric(this PropertyDescriptor property, Type ofType)
        {
            Guard.NotNull(() => property, property);
            Guard.NotNull(() => ofType, ofType);

            return property.PropertyType.IsOfGenericType(ofType);
        }

        /// <summary>
        /// Determines whether the specified property has a <see cref="BindableAttribute"/> set, and is not a MEF imported property.
        /// </summary>
        public static bool IsBindableDesignProperty(this PropertyDescriptor descriptor)
        {
            Guard.NotNull(() => descriptor, descriptor);

            BindableAttribute attribute = descriptor.Attributes.OfType<BindableAttribute>().FirstOrDefault();
            return (((attribute == null) || attribute.Bindable) && !descriptor.IsImported());
        }

        /// <summary>
        /// Tries to locate a custom type converter assigned via a 
        /// <see cref="DesignTypeConverterAttribute"/> or <see cref="TypeConverterAttribute"/>.
        /// </summary>
        /// <returns>The found converter or <see langword="null"/> if no custom type converter is set on the property.</returns>
        public static TypeConverter FindCustomTypeConverter(this PropertyDescriptor descriptor)
        {
            return descriptor.Attributes.FindCustomTypeConverter();
        }

        /// <summary>
        /// Tries to locate a custom type converter assigned via a 
        /// <see cref="DesignTypeConverterAttribute"/> or <see cref="TypeConverterAttribute"/>.
        /// </summary>
        /// <returns>The found converter or <see langword="null"/> if no custom type converter is set on the attributes collection.</returns>
        public static TypeConverter FindCustomTypeConverter(this AttributeCollection attributes)
        {
            return attributes.OfType<Attribute>().ToArray().FindCustomTypeConverter();
        }

        /// <summary>
        /// Tries to locate a custom type converter assigned via a 
        /// <see cref="DesignTypeConverterAttribute"/> or <see cref="TypeConverterAttribute"/>.
        /// </summary>
        /// <returns>The found converter or <see langword="null"/> if no custom type converter is set on the attributes collection.</returns>
        public static TypeConverter FindCustomTypeConverter(this Attribute[] attributes)
        {
            var designTypeConverterAttribute = attributes.OfType<DesignTypeConverterAttribute>().FirstOrDefault();

            if (designTypeConverterAttribute != null)
            {
                return (TypeConverter)Activator.CreateInstance(designTypeConverterAttribute.ConverterType);
            }

            var converterAttribute = attributes.OfType<TypeConverterAttribute>().FirstOrDefault();

            if (converterAttribute != null)
            {
                var converterType = Type.GetType(converterAttribute.ConverterTypeName);

                if (converterType != null)
                {
                    return (TypeConverter)Activator.CreateInstance(converterType);
                }
            }

            return null;
        }

        /// <summary>
        /// Checks for the presence of a <see cref="PropertyDescriptorAttribute"/>  and wraps the 
        /// descriptor using the one from the attribute, if existing.
        /// </summary>
        public static PropertyDescriptor ProcessPropertyDescriptorAttribute(this PropertyDescriptor property, object component)
        {
            Guard.NotNull(() => property, property);

            var descriptorAttribute = property.Attributes.OfType<PropertyDescriptorAttribute>().FirstOrDefault();

            if (descriptorAttribute != null)
            {
                ConstructorInfo defaultConstructor;

                if (typeof(DelegatingPropertyDescriptor).IsAssignableFrom(descriptorAttribute.DescriptorType))
                {
                    return (PropertyDescriptor)Activator.CreateInstance(descriptorAttribute.DescriptorType, property, new Attribute[0]);
                }
                else if ((defaultConstructor = descriptorAttribute.DescriptorType.GetConstructor(new[] { typeof(PropertyDescriptor) })) != null)
                {
                    return (PropertyDescriptor)defaultConstructor.Invoke(new object[] { property });
                }
                else if ((defaultConstructor = descriptorAttribute.DescriptorType.GetConstructor(new[] { typeof(PropertyDescriptor), typeof(object) })) != null)
                {
                    return (PropertyDescriptor)defaultConstructor.Invoke(new object[] { property, component });
                }
                else
                {
                    throw new NotSupportedException(String.Format(
                        CultureInfo.CurrentCulture,
                        Resources.DescriptorExtensions_MustBeDelegatingDescriptor,
                        typeof(DelegatingPropertyDescriptor).FullName,
                        typeof(PropertyDescriptor).FullName));
                }
            }

            return property;
        }

        /// <summary>
        /// Whether the type is browsable.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsBrowsable(this Type type)
        {
            var browsable = type.GetCustomAttribute<BrowsableAttribute>(true);
            return browsable == null || browsable.Browsable;
        }
    }
}
