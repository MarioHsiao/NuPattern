﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using NuPattern.Runtime.ToolkitInterface;

namespace NuPattern.Runtime.UnitTests.ToolkitInterface
{
    ///	<summary>
    ///	Description for WebService.Architecture.Folder.DataContract
    ///	</summary>
    [Description("Description for WebService.Architecture.Folder.DataContract")]
    [ToolkitInterface(DefinitionId = "85a60694-1cd9-42db-b531-102c987ab947", ProxyType = typeof(DataContract))]
    public partial interface IDataContract : IToolkitInterface
    {
        [DisplayName("Xsd File")]
        [Category("General")]
        String XsdFile { get; set; }

        ///	<summary>
        ///	The name of this element instance.
        ///	</summary>
        [ParenthesizePropertyName(true)]
        [Description("The name of this element instance.")]
        String InstanceName { get; set; }

        ///	<summary>
        ///	Description for NuPattern.Runtime.Store.ProductElementHasReferences.ProductElement
        ///	</summary>
        [Description("Description for NuPattern.Runtime.Store.ProductElementHasReferences.ProductElement")]
        IEnumerable<IReference> References { get; }

        ///	<summary>
        ///	Notes for this element.
        ///	</summary>
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        [Description("Notes for this element.")]
        String Notes { get; set; }

        /// <summary>
        /// Gets all instances of <see cref="ISerializer"/> contained in this element.
        /// </summary>
        IEnumerable<ISerializer> Serializers { get; }
    }
}