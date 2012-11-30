﻿
//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.VisualStudio.Patterning.Authoring.Library
{
	using global::Microsoft.VisualStudio.Patterning.Extensibility;
	using global::Microsoft.VisualStudio.Patterning.Runtime;
	using global::System;
	using global::System.Collections.Generic;
	using global::System.ComponentModel;
	using global::System.ComponentModel.Design;
	using global::System.Drawing.Design;
	using Runtime = global::Microsoft.VisualStudio.Patterning.Runtime;

	///	<summary>
	///	A library containing custom automation for a pattern toolkit.
	///	</summary>
	[Description("A library containing custom automation for a pattern toolkit.")]
	[ToolkitInterface(ExtensionId ="080eb0ef-518d-4807-9b5c-aa32d0032e0b", DefinitionId = "d6139b37-9971-4834-a9dc-2b3daef962cf", ProxyType = typeof(AutomationLibrary))]
	[System.CodeDom.Compiler.GeneratedCode("Pattern Toolkit Automation Library", "1.3.20.0")]
	public partial interface IAutomationLibrary : IToolkitInterface
	{ 
		///	<summary>
		///	When to transform all code generation templates in this library, to ensure that all library artifacts are up to date.
		///	</summary>
		[Description("When to transform all code generation templates in this library, to ensure that all library artifacts are up to date.")]
		[DisplayName("Transform On Build")]
		[Category("Code Generation")]
		[TypeConverter(typeof(TransformOnBuildConverter))]
		String TransformOnBuild { get; set; }

		///	<summary>
		///	The project root namespace
		///	</summary>
		[Description("The project root namespace")]
		[DisplayName("Toolkit Project Root Namespace")]
		[Category("General")]
		String ToolkitProjectRootNamespace { get; set; }

		///	<summary>
		///	The assembly name of the automation library project.
		///	</summary>
		[Description("The assembly name of the automation library project.")]
		[DisplayName("Project Assembly Name")]
		[Category("General")]
		String ProjectAssemblyName { get; set; }

		///	<summary>
		///	Excludes all generated code from code coverage metrics.
		///	</summary>
		[Description("Excludes all generated code from code coverage metrics.")]
		[DisplayName("Exclude From Code Coverage")]
		[Category("Code Generation")]
		Boolean ExcludeFromCodeCoverage { get; set; }
		
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
		[Description("The name of this element instance.")]
		[ParenthesizePropertyName(true)]
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
		///	Description for AutomationLibrary.Development
		///	</summary>
		[Description("Description for AutomationLibrary.Development")]
		IDevelopment Development { get; }
		
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