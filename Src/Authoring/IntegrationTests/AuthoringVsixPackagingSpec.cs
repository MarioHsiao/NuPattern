﻿using System.Linq;
using Microsoft.VisualStudio.Patterning.IntegrationTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.VisualStudio.Patterning.Authoring.IntegrationTests
{
    [TestClass]
    public class AuthoringVsixPackagingSpec
    {
        private static readonly IAssertion Assert = new Assertion();
        private const string DeployedContentDirectory = "Authoring.IntegrationTests.Content";
        private const string DeployedVsixItem = DeployedContentDirectory + "\\PatternToolkitBuilder.vsix";

        [TestClass]
        [DeploymentItem(DeployedContentDirectory, DeployedContentDirectory)]
        public class GivenTheCompiledVsix : VsixPackagingSpec.GivenAVsix
        {
			/// <summary>
			/// Returns the relative path to the deployed Vsix file in the project
			/// </summary>
			protected override string DeployedVsixItemPath
			{
				get
				{
					return DeployedVsixItem;
				}
			}
         
            [TestMethod, TestCategory("Integration")]
            public void ThenVsixInfoCorrect()
            {
                //Identifier, Name, Author, Version
                Assert.Equal(@"9f6dc301-6f66-4d21-9f9c-b37412b162f6", this.VsixInfo.Header.Identifier);
                Assert.Equal(@"Pattern Toolkit Builder", this.VsixInfo.Header.Name);
                Assert.Equal(@"An extension for designing and building Pattern Toolkit extensions, that combine automation and guidance with design patterns for repeatable solution development.", this.VsixInfo.Header.Description);
                Assert.Equal(@"Outercurve", this.VsixInfo.Header.Author);
                Assert.Equal("1.3.20.0", this.VsixInfo.Header.Version.ToString());
				
				//License, Icon, PreviewImage, MoreInfoUrl, GettingStartedGuide
				Assert.Equal(@"LICENSE.txt", this.VsixInfo.Header.License);
				Assert.Equal(@"Resources\AuthoringVsix.png", this.VsixInfo.Header.Icon);
				Assert.Equal(@"Resources\AuthoringVsixPreview.png", this.VsixInfo.Header.PreviewImage);
				Assert.Equal(@"http://visualstudiogallery.msdn.microsoft.com/332f060b-2352-41c9-b8dc-95d8ad21329b", this.VsixInfo.Header.MoreInfoUrl.ToString());
				Assert.Equal(@"http://visualstudiogallery.msdn.microsoft.com/332f060b-2352-41c9-b8dc-95d8ad21329b", this.VsixInfo.Header.GettingStartedGuide.ToString());

                //SupportedFrameworkRuntimeEdition
				Assert.Equal(@"4.0", this.VsixInfo.Header.SupportedFrameworkVersionRange.Minimum.ToString());
				Assert.Equal(@"4.5", this.VsixInfo.Header.SupportedFrameworkVersionRange.Maximum.ToString());

				//SupportedProducts
                Assert.Equal(3, this.VsixInfo.Targets.Count(t => t.VersionRange.Minimum.ToString() == "11.0"));
                Assert.Equal(3, this.VsixInfo.Targets.Count(t => t.VersionRange.Minimum.ToString() == "10.0"));
            }

            [TestMethod, TestCategory("Integration")]
            public void ThenContainsSchemas()
            {
                //Schema files (\GeneratedCode\*)
                Assert.True(this.FolderContainsExclusive(@"GeneratedCode",
                    new[]
                        {
                            "WorkflowDesignSchema.xsd",
                        }));
			}

			[TestMethod, TestCategory("Integration")]
            public void ThenContainsGuidance()
            {
                //Guidance (\\GeneratedCode\Gudiance\Content\*
				Assert.True(this.FolderNotEmpty(@"GeneratedCode\Guidance\Content", "*.mht"));

                //Assets (\\Assets\Guidance\*
				Assert.True(this.FolderContainsExclusive(@"Assets\Guidance",
                    new[]
                        {
							"AuthoringToolkitGuidance.pdf",
							"PatternToolkitGuidanceTemplate.dotm",
						}));
			}
                
			[TestMethod, TestCategory("Integration")]
            public void ThenContainsAssets()
            {
				 //Templates (\\Assets\Templates\*
				Assert.True(this.FolderContainsExclusive(@"Assets\Templates\Projects\Extensibility",
                    new[]
                        {
							"Authoring.zip",
						}));
				Assert.True(this.FolderContainsExclusive(@"Assets\Templates\Items\Extensibility",
                    new[]
                        {
							"ItemTemplate.zip",
							"PatternTooling.zip",
							"ProjectTemplate.zip",
							"TextTemplate.zip",
							"Wizard.zip",
							"WizardPage.zip",
						}));

				Assert.True(this.FolderContainsExclusive(@"Assets\Templates\Text",
                    new[]
                        {
							"Header.t4",
						}));

				Assert.True(this.FolderContainsExclusive(@"Assets\Templates\Text\Guidance",
                    new[]
                        {
							"GuidanceWorkflow.t4",
							"ToolkitGuidance.t4",
						}));

				Assert.True(this.FolderContainsExclusive(@"Assets\Templates\Text\ItemTemplate",
                    new[]
                        {
							"ItemTemplate.vstemplate.t4",
						}));

				Assert.True(this.FolderContainsExclusive(@"Assets\Templates\Text\PatternModel",
                    new[]
                        {
							"PatternModel.patterndefinition.t4",
						}));
				
				Assert.True(this.FolderContainsExclusive(@"Assets\Templates\Text\ProjectTemplate",
                    new[]
                        {
							"ProjectTemplate.vstemplate.t4",
						}));
				
				Assert.True(this.FolderContainsExclusive(@"Assets\Templates\Text\VsixManifest",
                    new[]
                        {
							"source.extension.t4",
							"source.include.t4",
						}));
			}

			[TestMethod, TestCategory("Integration")]
            public void ThenContainsResources()
            {
                //Schema files (\Resources\*)
                Assert.True(this.FolderContainsExclusive(@"Resources",
                    new[]
                        {
                            "RunTimeVsix.png",
                            "RunTimeVsixPreview.png",
                        }));
			}
			
			[TestMethod, TestCategory("Integration")]
            public void ThenContainsRedistributables()
            {
                //Redist files
                Assert.True(this.FolderContainsExclusive("",
                    new[]
                        {
							"extension.vsixmanifest",
							//"[Content_Types].xml",
                            "LICENSE.txt",
							"redist.txt",
							"Release%20Notes.docx",

                            //Auxillary Assemblies
							"Microsoft.VisualStudio.Patterning.Runtime.Schema.dll",

                            //Authoring Assemblies
                            "Microsoft.VisualStudio.Patterning.Authoring.Authoring.Toolkit.dll",
                            "Microsoft.VisualStudio.Patterning.Authoring.Authoring.Toolkit.pkgdef",
                            "Microsoft.VisualStudio.Patterning.Authoring.Guidance.dll",
                            "Microsoft.VisualStudio.Patterning.Authoring.PatternToolkit.targets",
                            "Microsoft.VisualStudio.Patterning.Authoring.Toolkit.Automation.dll",
                            "Microsoft.VisualStudio.Patterning.Authoring.ToolkitDesign.Shell.dll",
                            "Microsoft.VisualStudio.Patterning.Authoring.ToolkitDesign.Shell.pkgdef",
                            "Microsoft.VisualStudio.Patterning.Authoring.WorkflowDesign.dll",
                            "Microsoft.VisualStudio.Patterning.Authoring.WorkflowDesign.Interfaces.dll",
                            "Microsoft.VisualStudio.Patterning.Authoring.WorkflowDesign.Shell.dll",
							"Microsoft.VisualStudio.Patterning.Authoring.WorkflowDesign.Shell.pkgdef",

							//Embedded VSIXes
							"PatternToolkitAutomationLibrary.vsix",
							"PatternToolkitManager.vsix",
                        }));
            }
        }
    }
}
