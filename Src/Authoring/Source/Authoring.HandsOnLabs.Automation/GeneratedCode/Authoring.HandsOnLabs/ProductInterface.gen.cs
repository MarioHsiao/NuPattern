﻿//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NuPattern.Authoring.HandsOnLabs
{
	using global::NuPattern.Runtime;
	using global::NuPattern.Runtime.Bindings;
	using global::NuPattern.Runtime.ToolkitInterface;
	using global::System;
	using global::System.Collections.Generic;
	using global::System.ComponentModel;
	using global::System.ComponentModel.Design;
	using global::System.Drawing.Design;
	using Runtime = global::NuPattern.Runtime;

	/// <summary>
	/// Hands on Labs that guides you through creating and customizing your first Pattern Toolkit project.
	/// </summary>
	[Description("Hands on Labs that guides you through creating and customizing your first Pattern Toolkit project.")]
	[ToolkitInterface(ExtensionId = "5d64cfe6-a6ff-4e73-a000-c6a8832740ff", DefinitionId = "71309920-c4ac-4283-b6bf-3cec975eca86", ProxyType = typeof(PatternToolkitHandsOnLabs))]
	[System.CodeDom.Compiler.GeneratedCode("NuPattern Toolkit Library", "1.3.21.0")]
	public partial interface IPatternToolkitHandsOnLabs : IToolkitInterface
	{

		/// <summary>
		/// Gets or sets the ToolkitInfo property.
		/// </summary>
		IProductToolkitInfo ToolkitInfo { get; }

		/// <summary>
		/// Gets or sets the CurrentView property.
		/// </summary>
		IView CurrentView { get; set; }

		/// <summary>
		/// The name of this element instance.
		/// </summary>
		[Description("The name of this element instance.")]
		[ParenthesizePropertyName(true)]
		String InstanceName { get; set; }

		/// <summary>
		/// The order of this element relative to its siblings.
		/// </summary>
		[Description("The order of this element relative to its siblings.")]
		[ReadOnly(true)]
		Double InstanceOrder { get; set; }

		/// <summary>
		/// The references of this element.
		/// </summary>
		[Description("The references of this element.")]
		IEnumerable<IReference> References { get; }

		/// <summary>
		/// Notes for this element.
		/// </summary>
		[Description("Notes for this element.")]
		[Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
		String Notes { get; set; }

		/// <summary>
		/// Gets or sets the InTransaction property.
		/// </summary>
		Boolean InTransaction { get; }

		/// <summary>
		/// Gets or sets the IsSerializing property.
		/// </summary>
		Boolean IsSerializing { get; }

		/// <summary>
		/// Description for PatternToolkitHandsOnLabs.DefaultView
		/// </summary>
		[Description("Description for PatternToolkitHandsOnLabs.DefaultView")]
		IDefaultView DefaultView { get; }

		/// <summary>
		/// Deletes this element.
		/// </summary>
		void Delete();

		/// <summary>
		/// Gets the generalized interface (<see cref="Runtime.IProduct"/>) of this element.
		/// </summary>
		Runtime.IProduct AsProduct();
	}
}
