﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using VSShellInterop = global::Microsoft.VisualStudio.Shell.Interop;
using VSShell = global::Microsoft.VisualStudio.Shell;
using DslShell = global::Microsoft.VisualStudio.Modeling.Shell;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
using DslModeling = global::Microsoft.VisualStudio.Modeling;
using System;
using System.Diagnostics;
using System.Drawing.Design;
using System.Linq;
using System.Windows.Forms;
	
namespace Microsoft.VisualStudio.Patterning.Runtime.Schema
{
	/// <summary>
	/// This class implements the VS package that integrates this DSL into Visual Studio.
	/// </summary>
	[VSShell::DefaultRegistryRoot("Software\\Microsoft\\VisualStudio\\11.0")]
	[VSShell::PackageRegistration(RegisterUsing = VSShell::RegistrationMethod.Assembly, UseManagedResourcesOnly = true)]
	[VSShell::ProvideStaticToolboxGroup("@Pattern Model DesignerToolboxTab;Microsoft.VisualStudio.Patterning.Runtime.Schema.dll", "Microsoft.VisualStudio.Patterning.Runtime.Schema.Pattern Model DesignerToolboxTab")]
	[VSShell::ProvideStaticToolboxItem("Microsoft.VisualStudio.Patterning.Runtime.Schema.Pattern Model DesignerToolboxTab",
					"@CollectionToolboxItem;Microsoft.VisualStudio.Patterning.Runtime.Schema.dll", 
					"Microsoft.VisualStudio.Patterning.Runtime.Schema.CollectionToolboxItem", 
					"CF_TOOLBOXITEMCONTAINER,CF_TOOLBOXITEMCONTAINER_HASH,CF_TOOLBOXITEMCONTAINER_CONTENTS", 
					"Collection", 
					"@CollectionToolboxBitmap;Microsoft.VisualStudio.Patterning.Runtime.Schema.dll", 
					0xff00ff)]
	[VSShell::ProvideStaticToolboxItem("Microsoft.VisualStudio.Patterning.Runtime.Schema.Pattern Model DesignerToolboxTab",
					"@ElementToolboxItem;Microsoft.VisualStudio.Patterning.Runtime.Schema.dll", 
					"Microsoft.VisualStudio.Patterning.Runtime.Schema.ElementToolboxItem", 
					"CF_TOOLBOXITEMCONTAINER,CF_TOOLBOXITEMCONTAINER_HASH,CF_TOOLBOXITEMCONTAINER_CONTENTS", 
					"Element", 
					"@ElementToolboxBitmap;Microsoft.VisualStudio.Patterning.Runtime.Schema.dll", 
					0xff00ff)]
	[VSShell::ProvideStaticToolboxItem("Microsoft.VisualStudio.Patterning.Runtime.Schema.Pattern Model DesignerToolboxTab",
					"@ExtensionPointToolboxItem;Microsoft.VisualStudio.Patterning.Runtime.Schema.dll", 
					"Microsoft.VisualStudio.Patterning.Runtime.Schema.ExtensionPointToolboxItem", 
					"CF_TOOLBOXITEMCONTAINER,CF_TOOLBOXITEMCONTAINER_HASH,CF_TOOLBOXITEMCONTAINER_CONTENTS", 
					"ExtensionPoint", 
					"@ExtensionPointToolboxBitmap;Microsoft.VisualStudio.Patterning.Runtime.Schema.dll", 
					0xff00ff)]
	[VSShell::ProvideEditorFactory(typeof(PatternModelEditorFactory), 103, TrustLevel = VSShellInterop::__VSEDITORTRUSTLEVEL.ETL_AlwaysTrusted)]
	[VSShell::ProvideEditorExtension(typeof(PatternModelEditorFactory), "." + Constants.DesignerFileExtension, 50)]
	[VSShell::ProvideEditorLogicalView(typeof(PatternModelEditorFactory), "{7651A702-06E5-11D1-8EBD-00A0C90F26EA}")] // Designer logical view GUID i.e. VSConstants.LOGVIEWID_Designer
	[DslShell::ProvideRelatedFile("." + Constants.DesignerFileExtension, Constants.DefaultDiagramExtension,
		ProjectSystem = DslShell::ProvideRelatedFileAttribute.CSharpProjectGuid,
		FileOptions = DslShell::RelatedFileType.FileName)]
	[DslShell::ProvideRelatedFile("." + Constants.DesignerFileExtension, Constants.DefaultDiagramExtension,
		ProjectSystem = DslShell::ProvideRelatedFileAttribute.VisualBasicProjectGuid,
		FileOptions = DslShell::RelatedFileType.FileName)]
	[DslShell::RegisterAsDslToolsEditor]
	[global::System.Runtime.InteropServices.ComVisible(true)]
	[DslShell::ProvideBindingPath]
	[DslShell::ProvideXmlEditorChooserBlockSxSWithXmlEditor(@"PatternModel", typeof(PatternModelEditorFactory))]

	internal abstract partial class PatternModelPackageBase : DslShell::ModelingPackage
	{
		protected global::Microsoft.VisualStudio.Patterning.Runtime.Schema.PatternModelToolboxHelper toolboxHelper;	
		
		/// <summary>
		/// Initialization method called by the package base class when this package is loaded.
		/// </summary>
		protected override void Initialize()
		{
			base.Initialize();

			// Register the editor factory used to create the DSL editor.
			this.RegisterEditorFactory(new PatternModelEditorFactory(this));
			
			// Initialize the toolbox helper
			toolboxHelper = new global::Microsoft.VisualStudio.Patterning.Runtime.Schema.PatternModelToolboxHelper(this);

			// Create the command set that handles menu commands provided by this package.
			PatternModelCommandSet commandSet = new PatternModelCommandSet(this);
			commandSet.Initialize();
			
			// Create the command set that handles cut/copy/paste commands provided by this package.
			PatternModelClipboardCommandSet clipboardCommandSet = new PatternModelClipboardCommandSet(this);
			clipboardCommandSet.Initialize();
			
			// Initialize Extension Registars
			// this is a partial method call
			this.InitializeExtensions();

			// Add dynamic toolbox items
			this.SetupDynamicToolbox();
		}

		/// <summary>
		/// Partial method to initialize ExtensionRegistrars (if any) in the DslPackage
		/// </summary>
		partial void InitializeExtensions();
		
		/// <summary>
		/// Returns any dynamic tool items for the designer
		/// </summary>
		/// <remarks>The default implementation is to return the list of items from the generated toolbox helper.</remarks>
		protected override global::System.Collections.Generic.IList<DslDesign::ModelingToolboxItem> CreateToolboxItems()
		{
			try
			{
				Debug.Assert(toolboxHelper != null, "Toolbox helper is not initialized");
				return toolboxHelper.CreateToolboxItems();
			}
			catch(global::System.Exception e)
			{
				global::System.Diagnostics.Debug.Fail("Exception thrown during toolbox item creation.  This may result in Package Load Failure:\r\n\r\n" + e);
				throw;
			}
		}
		
		
		/// <summary>
		/// Given a toolbox item "unique ID" and a data format identifier, returns the content of
		/// the data format. 
		/// </summary>
		/// <param name="itemId">The unique ToolboxItem to retrieve data for</param>
		/// <param name="format">The desired format of the resulting data</param>
		protected override object GetToolboxItemData(string itemId, DataFormats.Format format)
		{
			Debug.Assert(toolboxHelper != null, "Toolbox helper is not initialized");
		
			// Retrieve the specified ToolboxItem from the DSL
			return toolboxHelper.GetToolboxItemData(itemId, format);
		}
	}

}

//
// Package attributes which may need to change are placed on the partial class below, rather than in the main include file.
//
namespace Microsoft.VisualStudio.Patterning.Runtime.Schema
{
	/// <summary>
	/// Double-derived class to allow easier code customization.
	/// </summary>
	[VSShell::ProvideMenuResource("1000.ctmenu", 1)]
	[VSShell::ProvideToolboxItems(1)]
    [global::Microsoft.VisualStudio.Modeling.Shell.ProvideXmlEditorChooserDesignerView(
        "PatternModel",
        Constants.DesignerFileExtension,
        EnvDTE.Constants.vsViewKindDesigner,
        1,
        CodeLogicalViewEditor = Constants.PatternModelEditorFactoryId,
        DebuggingLogicalViewEditor = Constants.PatternModelEditorFactoryId,
        DesignerLogicalViewEditor = Constants.PatternModelEditorFactoryId,
        TextLogicalViewEditor = Constants.PatternModelEditorFactoryId)]
	[global::Microsoft.VisualStudio.TextTemplating.VSHost.ProvideDirectiveProcessor(typeof(global::Microsoft.VisualStudio.Patterning.Runtime.Schema.PatternModelDirectiveProcessor), global::Microsoft.VisualStudio.Patterning.Runtime.Schema.PatternModelDirectiveProcessor.PatternModelDirectiveProcessorName, "A directive processor that provides access to PatternModel files")]
	[global::System.Runtime.InteropServices.Guid(Constants.PatternModelPackageId)]
	internal sealed partial class PatternModelPackage : PatternModelPackageBase
	{
	}
}