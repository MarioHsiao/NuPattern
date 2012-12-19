﻿//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using NuPattern.Runtime;

namespace MainTestToolkit.Automation.GeneratedCode
{
	///	<summary>
	///	A Description of MainTest
	///	</summary>
	[Description("A Description of MainTest")]
	[ToolkitInterface(ExtensionId = "cb6a7b60-ec95-42dd-8f01-28ff11dcf800", DefinitionId = "815a9f7c-09bb-4970-b241-91a30b45292f", ProxyType = typeof(MainTest))]
	public partial interface IMainTest : IToolkitInterface
	{
		///	<summary>
		///	Provides registration information for the product
		///	</summary>
		[Description("Provides registration information for the product")]
		IProductToolkitInfo ToolkitInfo { get; }

		///	<summary>
		///	The name of this element instance.
		///	</summary>
		[Description("The name of this element instance.")]
		[ParenthesizePropertyName(true)]
		String InstanceName { get; set; }

		///	<summary>
		///	Description for NuPattern.Runtime.Store.ProductElementHasReferences.ProductElement
		///	</summary>
		[Description("Description for NuPattern.Runtime.Store.ProductElementHasReferences.ProductElement")]
		IEnumerable<IReference> References { get; }

		///	<summary>
		///	Notes for this element.
		///	</summary>
		[Description("Notes for this element.")]
		[Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
		String Notes { get; set; }

		///	<summary>
		///	Description for MainTest.DefaultView
		///	</summary>
		[Description("Description for MainTest.DefaultView")]
		IDefaultView DefaultView { get; }

		///	<summary>
		///	Deletes this element from the store.
		///	</summary>
		void Delete();

		/// <summary>
		/// Gets the generic <see cref="IProduct"/> underlying element.
		/// </summary>
		IProduct AsProduct();
	}
}
