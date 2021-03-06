﻿using System;
using System.Globalization;
using NuPattern.Properties;

namespace NuPattern.ComponentModel.Design
{
    /// <summary>
    /// Attribute to apply to editors that must be used in the 
    /// design solution itself, rather than only through library/MEF.
    /// </summary>
    public class DesignEditorAttribute : Attribute
    {
        /// <summary>
        /// Creates a new instance of the <see cref="DesignEditorAttribute"/> class.
        /// </summary>
        public DesignEditorAttribute(Type editorType, Type baseType)
        {
            if (!baseType.IsAssignableFrom(editorType))
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture,
                    Resources.DesignEditorAttribute_ErrorNotEditorType,
                    editorType, baseType));

            this.EditorType = editorType;
            this.BaseType = baseType;
        }

        /// <summary>
        /// Gets the type of the editor.
        /// </summary>
        public Type EditorType { get; private set; }

        /// <summary>
        /// Gets the base type of the editor.
        /// </summary>
        public Type BaseType { get; private set; }
    }
}
