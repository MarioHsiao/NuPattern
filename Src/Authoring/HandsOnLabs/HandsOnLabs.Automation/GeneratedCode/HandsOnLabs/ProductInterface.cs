﻿
//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Patterning.HandsOnLabs
{
	using global::Microsoft.VisualStudio.Patterning.Runtime;
	using global::System;
	using global::System.Collections.Generic;
	using global::System.ComponentModel;
	using global::System.ComponentModel.Design;
	using global::System.Drawing.Design;
	using Runtime = global::Microsoft.VisualStudio.Patterning.Runtime;

	///	<summary>
	///	Hands on Labs for Creating Pattern Toolkits
	///	</summary>
	[Description("Hands on Labs for Creating Pattern Toolkits")]
	[ToolkitInterface(ExtensionId ="5413c755-6024-4c41-ba0c-9aa3d6fd9caf", DefinitionId = "71309920-c4ac-4283-b6bf-3cec975eca86", ProxyType = typeof(PatternToolkitHOLs))]
	[System.CodeDom.Compiler.GeneratedCode("Pattern Toolkit Automation Library", "1.3.20.0")]
	public partial interface IPatternToolkitHOLs : IToolkitInterface
	{ 
		///	<summary>
		///	The ToolkitInfo.
		///	</summary>
		IProductToolkitInfo ToolkitInfo { get;  }
		
		///	<summary>
		///	The CurrentView.
		///	</summary>
		IView CurrentView { get; set; }
		
		///	<summary>
		///	The name of this element instance.
		///	</summary>
		[ParenthesizePropertyName(true)]
		[Description("The name of this element instance.")]
		String InstanceName { get; set; }
		
		///	<summary>
		///	The order of this element relative to its siblings.
		///	</summary>
		[ReadOnly(true)]
		[Description("The order of this element relative to its siblings.")]
		Double InstanceOrder { get; set; }
		
		///	<summary>
		///	The references of this element.
		///	</summary>
		[Description("The references of this element.")]
		IEnumerable<IReference> References { get;  }
		
		///	<summary>
		///	Notes for this element.
		///	</summary>
		[Description("Notes for this element.")]
		[Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
		String Notes { get; set; }
		
		///	<summary>
		///	The InTransaction.
		///	</summary>
		Boolean InTransaction { get;  }
		
		///	<summary>
		///	The IsSerializing.
		///	</summary>
		Boolean IsSerializing { get;  }

		///	<summary>
		///	Description for PatternToolkitHOLs.DefaultView
		///	</summary>
		[Description("Description for PatternToolkitHOLs.DefaultView")]
		IDefaultView DefaultView { get; }
		
		///	<summary>
		///	Deletes this element from the store.
		///	</summary>
		void Delete();

		/// <summary>
		/// Gets the generic <see cref="IProduct"/> underlying element.
		/// </summary>
		Runtime.IProduct AsProduct();
	}
}