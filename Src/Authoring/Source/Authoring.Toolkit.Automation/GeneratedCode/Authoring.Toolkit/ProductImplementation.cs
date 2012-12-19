﻿
//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NuPattern.Authoring.Authoring
{
	using global::NuPattern.Extensibility;
	using global::NuPattern.Runtime;
	using global::System;
	using global::System.Collections.Generic;
	using global::System.ComponentModel;
	using global::System.ComponentModel.Composition;
	using global::System.ComponentModel.Design;
	using global::System.Drawing.Design;
	using Runtime = global::NuPattern.Runtime;

	///	<summary>
	///	A Pattern Toolkit which captures and automates a design pattern for rapid and consistent custom solution development.
	///	</summary>
	[Description("A Pattern Toolkit which captures and automates a design pattern for rapid and consistent custom solution development.")]
	[ToolkitInterfaceProxy(ExtensionId ="84031a32-b20f-479c-a620-beacd982ea13", DefinitionId = "c034429e-01f9-48dd-a478-0321fb708dd3", ProxyType = typeof(PatternToolkit))]
	[System.CodeDom.Compiler.GeneratedCode("NuPattern Toolkit Library", "1.3.20.0")]
	[System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
	internal partial class PatternToolkit : IPatternToolkit
	{
		private Runtime.IProduct target;
		private Runtime.IProductProxy<IPatternToolkit> proxy;

		/// <summary>
		/// For MEF.
		/// </summary>
		[ImportingConstructor]
		private PatternToolkit() { }

		/// <summary>
		/// Initializes a new instance of the <see cref="PatternToolkit"/> class.
		/// </summary>
		public PatternToolkit(Runtime.IProduct target)
		{
			this.target = target;
			this.proxy = target.ProxyFor<IPatternToolkit>();
			OnCreated();
		}	

		partial void OnCreated();

		///	<summary>
		///	When to transform all code generation templates in this toolkit, to ensure that all toolkit artifacts are up to date.
		///	</summary>
		[Description("When to transform all code generation templates in this toolkit, to ensure that all toolkit artifacts are up to date.")]
		[DisplayName("Transform On Build")]
		[Category("Code Generation")]
		[TypeConverter(typeof(TransformOnBuildConverter))]
		public virtual String TransformOnBuild 
		{
			get { return this.proxy.GetValue(() => this.TransformOnBuild); }
			set { this.proxy.SetValue(() => this.TransformOnBuild, value); }
		}

		///	<summary>
		///	The initial name of the pattern
		///	</summary>
		[Description("The initial name of the pattern")]
		[DisplayName("Pattern Name")]
		[Category("General")]
		public virtual String PatternName 
		{
			get { return this.proxy.GetValue(() => this.PatternName); }
			set { this.proxy.SetValue(() => this.PatternName, value); }
		}

		///	<summary>
		///	The initial description of the pattern
		///	</summary>
		[Description("The initial description of the pattern")]
		[DisplayName("Pattern Description")]
		[Category("General")]
		public virtual String PatternDescription 
		{
			get { return this.proxy.GetValue(() => this.PatternDescription); }
			set { this.proxy.SetValue(() => this.PatternDescription, value); }
		}

		///	<summary>
		///	The ID of the tailored pattern, if this pattern is tailored
		///	</summary>
		[Description("The ID of the tailored pattern, if this pattern is tailored")]
		[DisplayName("Base Toolkit")]
		[Category("General")]
		public virtual String ExistingToolkitId 
		{
			get { return this.proxy.GetValue(() => this.ExistingToolkitId); }
			set { this.proxy.SetValue(() => this.ExistingToolkitId, value); }
		}

		///	<summary>
		///	The solution name.
		///	</summary>
		[Description("The solution name.")]
		[DisplayName("Solution Name")]
		[Category("General")]
		public virtual String SolutionName 
		{
			get { return this.proxy.GetValue(() => this.SolutionName); }
			set { this.proxy.SetValue(() => this.SolutionName, value); }
		}

		///	<summary>
		///	The project root namespace
		///	</summary>
		[Description("The project root namespace")]
		[DisplayName("Project Root Namespace")]
		[Category("General")]
		public virtual String ProjectRootNamespace 
		{
			get { return this.proxy.GetValue(() => this.ProjectRootNamespace); }
			set { this.proxy.SetValue(() => this.ProjectRootNamespace, value); }
		}

		///	<summary>
		///	The project assembly name
		///	</summary>
		[Description("The project assembly name")]
		[DisplayName("Project Assembly Name")]
		[Category("General")]
		public virtual String ProjectAssemblyName 
		{
			get { return this.proxy.GetValue(() => this.ProjectAssemblyName); }
			set { this.proxy.SetValue(() => this.ProjectAssemblyName, value); }
		}

		///	<summary>
		///	Excludes all generated code from code coverage metrics.
		///	</summary>
		[Description("Excludes all generated code from code coverage metrics.")]
		[DisplayName("Exclude From Code Coverage")]
		[Category("Code Generation")]
		public virtual Boolean ExcludeFromCodeCoverage 
		{
			get { return this.proxy.GetValue(() => this.ExcludeFromCodeCoverage); }
			set { this.proxy.SetValue(() => this.ExcludeFromCodeCoverage, value); }
		}
		
		///	<summary>
		///	The ToolkitInfo.
		///	</summary>
		public virtual IProductToolkitInfo ToolkitInfo 
		{ 
			get { return this.proxy.GetValue(() => this.ToolkitInfo); }
		}
		
		///	<summary>
		///	The CurrentView.
		///	</summary>
		public virtual IView CurrentView 
		{ 
			get { return this.proxy.GetValue(() => this.CurrentView); }
			set { this.proxy.SetValue(() => this.CurrentView, value); }
		}
		
		///	<summary>
		///	The name of this element instance.
		///	</summary>
		[ParenthesizePropertyName(true)]
		[Description("The name of this element instance.")]
		public virtual String InstanceName 
		{ 
			get { return this.proxy.GetValue(() => this.InstanceName); }
			set { this.proxy.SetValue(() => this.InstanceName, value); }
		}
		
		///	<summary>
		///	The order of this element relative to its siblings.
		///	</summary>
		[ReadOnly(true)]
		[Description("The order of this element relative to its siblings.")]
		public virtual Double InstanceOrder 
		{ 
			get { return this.proxy.GetValue(() => this.InstanceOrder); }
			set { this.proxy.SetValue(() => this.InstanceOrder, value); }
		}
		
		///	<summary>
		///	The references of this element.
		///	</summary>
		[Description("The references of this element.")]
		public virtual IEnumerable<IReference> References 
		{ 
			get { return this.proxy.GetValue(() => this.References); }
		}
		
		///	<summary>
		///	Notes for this element.
		///	</summary>
		[Description("Notes for this element.")]
		[Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
		public virtual String Notes 
		{ 
			get { return this.proxy.GetValue(() => this.Notes); }
			set { this.proxy.SetValue(() => this.Notes, value); }
		}
		
		///	<summary>
		///	The InTransaction.
		///	</summary>
		public virtual Boolean InTransaction 
		{ 
			get { return this.proxy.GetValue(() => this.InTransaction); }
		}
		
		///	<summary>
		///	The IsSerializing.
		///	</summary>
		public virtual Boolean IsSerializing 
		{ 
			get { return this.proxy.GetValue(() => this.IsSerializing); }
		}

		///	<summary>
		///	The development view of a toolkit.
		///	</summary>
		[Description("The development view of a toolkit.")]
		public virtual IDevelopment Development
		{ 
			get { return this.proxy.GetView(() => this.Development, view => new Development(view)); }
		}

		///	<summary>
		///	The design view of the toolkit.
		///	</summary>
		[Description("The design view of the toolkit.")]
		public virtual IDesign Design
		{ 
			get { return this.proxy.GetView(() => this.Design, view => new Design(view)); }
		}

		/// <summary>
		/// Gets the generic <see cref="Runtime.IProduct"/> underlying element.
		/// </summary>
		public virtual Runtime.IProduct AsProduct()
		{
			return this.target;
		}

		/// <summary>
		/// Gets the generic underlying element as the given type if possible.
		/// </summary>
		public virtual TRuntimeInterface As<TRuntimeInterface>()
			where TRuntimeInterface : class
		{
			return this.target as TRuntimeInterface;
		}

		/// <summary>
		/// Deletes this instance.
		/// </summary>
		public virtual void Delete()
		{
			this.target.Delete();
		}
	}
}