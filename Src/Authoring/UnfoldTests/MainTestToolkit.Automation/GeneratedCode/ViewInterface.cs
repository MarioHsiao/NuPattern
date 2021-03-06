﻿
//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace MainTestToolkit.Automation.GeneratedCode
{
    using System.ComponentModel;
    using NuPattern.Runtime;
    using NuPattern.Runtime.ToolkitInterface;

    ///	<summary>
    ///	Description for MainTest.DefaultView
    ///	</summary>
    [Description("Description for MainTest.DefaultView")]
    [ToolkitInterface(ExtensionId = "cb6a7b60-ec95-42dd-8f01-28ff11dcf800", DefinitionId = "27b6576e-dbb8-481b-aa4a-573f595a380a", ProxyType = typeof(DefaultView))]
    public partial interface IDefaultView : IToolkitInterface
    {
        /// <summary>
        /// Gets the parent element.
        /// </summary>
        IMainTest Parent { get; }

        /// <summary>
        /// Gets the <see cref="IExtensionItem"/> contained in this element.
        /// </summary>
        IExtensionItem ExtensionItem { get; }

        ///	<summary>
        ///	Deletes this element from the store.
        ///	</summary>
        void Delete();

        /// <summary>
        /// Gets the generic <see cref="IView"/> underlying element.
        /// </summary>
        IView AsView();
    }
}

