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
	using global::NuPattern.Runtime.ToolkitInterface;
	using global::System;
	using global::System.Collections.Generic;
	using global::System.ComponentModel;
	using global::System.ComponentModel.Design;
	using global::System.Drawing.Design;
	using Runtime = global::NuPattern.Runtime;

	/// <summary>
	/// Description for PatternToolkitHandsOnLabs.DefaultView
	/// </summary>
	[Description("Description for PatternToolkitHandsOnLabs.DefaultView")]
	[ToolkitInterface(ExtensionId = "5d64cfe6-a6ff-4e73-a000-c6a8832740ff", DefinitionId = "ac1fde3b-bfa2-4fcf-a1c5-50167323063d", ProxyType = typeof(DefaultView))]
	[System.CodeDom.Compiler.GeneratedCode("NuPattern Toolkit Library", "1.3.21.0")]
	public partial interface IDefaultView : IToolkitInterface
	{

		/// <summary>
		/// Gets the parent element.
		/// </summary>
		IPatternToolkitHandsOnLabs Parent { get; }

		/// <summary>
		/// Deletes this element.
		/// </summary>
		void Delete();

		/// <summary>
		/// Gets the generalized interface (<see cref="Runtime.IView"/>) of this element.
		/// </summary>
		Runtime.IView AsView();
	}
}
