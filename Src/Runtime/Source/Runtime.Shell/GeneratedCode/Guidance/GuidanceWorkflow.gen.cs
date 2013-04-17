﻿//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by a tool.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Shell;
using NuPattern.Runtime.Composition;
using NuPattern.Runtime.Guidance;
using NuPattern.Runtime.Guidance.Extensions;
using NuPattern.Runtime.Guidance.Workflow;

namespace NuPattern.Runtime.Shell.Guidance
{
    /// <summary>
    /// Defines a base class for the guidance workflow for this feature.
    /// </summary>
    [CLSCompliant(false)]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [System.CodeDom.Compiler.GeneratedCode("NuPattern Toolkit Builder VS2012", "1.3.20.0")]
    public partial class ProcessWorkflow : GuidanceWorkflow
    {
        /// <summary>
        /// Gets the feature composition service.
        /// </summary>
        [Import]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        private IFeatureCompositionService FeatureComposition
        {
            get;
            set;
        }

        /// <summary>
        /// Gets whether to ignore all post conditions and enable all actions.
        /// </summary>
        public override bool IgnorePostConditions
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Initializes the workflow.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1809:AvoidExcessiveLocals")]
        protected override void OnInitialize()
        {
            base.OnInitialize();
            this.Name = "GuidanceWorkflow";
            var initial1 = new Initial
            {
                Name = "Solution Builder Guidance",
            };
            this.ConnectTo(initial1);
            var fork2 = new Fork
            {
                Name = "First Time Users",
                Description = "These topics are aimed at the first time users of Solution Builder.",
            };
            initial1.ConnectTo(fork2);
            var fork3 = new Fork
            {
                Name = "Understanding",
                Description = "This section helps you understand what Solution Builder is, what Pattern Toolkits are, why they are useful, and who should use them.",
            };
            fork2.ConnectTo(fork3);
            var guidanceaction4 = new GuidanceAction
            {
                Name = "What is Solution Builder?",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/WhatisSolutionBuilder.mht",
            };
            fork3.ConnectTo(guidanceaction4);
            var fork5 = new Fork
            {
                Name = "Using Pattern Toolkits",
            };
            guidanceaction4.ConnectTo(fork5);
            var guidanceaction6 = new GuidanceAction
            {
                Name = "Pre-requisites for Using Pattern Toolkits",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/PrerequisitesforUsingPatternToolkits.mht",
            };
            fork5.ConnectTo(guidanceaction6);
            var guidanceaction7 = new GuidanceAction
            {
                Name = "Installing a Pattern Toolkit",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/InstallingaPatternToolkit.mht",
            };
            guidanceaction6.ConnectTo(guidanceaction7);
            var guidanceaction8 = new GuidanceAction
            {
                Name = "Browsing & Managing Installed Pattern Toolkits",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/BrowsingManagingInstalledPatternToolkits.mht",
            };
            guidanceaction7.ConnectTo(guidanceaction8);
            var guidanceaction9 = new GuidanceAction
            {
                Name = "Using Pattern Toolkits",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/UsingPatternToolkits.mht",
            };
            guidanceaction8.ConnectTo(guidanceaction9);
            var guidanceaction10 = new GuidanceAction
            {
                Name = "Viewing & Configuring Solution Elements ",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/ViewingConfiguringSolutionElements.mht",
            };
            guidanceaction9.ConnectTo(guidanceaction10);
            var guidanceaction11 = new GuidanceAction
            {
                Name = "Running Automation",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/RunningAutomation.mht",
            };
            guidanceaction10.ConnectTo(guidanceaction11);
            var join12 = new Join
            {
                Name = "Join1",
            };
            guidanceaction11.ConnectTo(join12);
            var join13 = new Join
            {
                Name = "Join2",
            };
            join12.ConnectTo(join13);
            var fork14 = new Fork
            {
                Name = "Concepts",
            };
            join13.ConnectTo(fork14);
            var guidanceaction15 = new GuidanceAction
            {
                Name = "What are Patterns?",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/WhatarePatterns.mht",
            };
            fork14.ConnectTo(guidanceaction15);
            var guidanceaction16 = new GuidanceAction
            {
                Name = "What are Pattern Toolkits?",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/WhatarePatternToolkits.mht",
            };
            guidanceaction15.ConnectTo(guidanceaction16);
            var guidanceaction17 = new GuidanceAction
            {
                Name = "What is a Solution Element?",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/WhatisaSolutionElement.mht",
            };
            guidanceaction16.ConnectTo(guidanceaction17);
            var guidanceaction18 = new GuidanceAction
            {
                Name = "What are Related Items?",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/WhatareRelatedItems.mht",
            };
            guidanceaction17.ConnectTo(guidanceaction18);
            var fork19 = new Fork
            {
                Name = "Guidance",
            };
            guidanceaction18.ConnectTo(fork19);
            var guidanceaction20 = new GuidanceAction
            {
                Name = "What is Guidance?",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/WhatisGuidance.mht",
            };
            fork19.ConnectTo(guidanceaction20);
            var guidanceaction21 = new GuidanceAction
            {
                Name = "What is a Guidance Workflow?",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/WhatisaGuidanceWorkflow.mht",
            };
            guidanceaction20.ConnectTo(guidanceaction21);
            var guidanceaction22 = new GuidanceAction
            {
                Name = "What is a Guidance Document?",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/WhatisaGuidanceDocument.mht",
            };
            guidanceaction21.ConnectTo(guidanceaction22);
            var guidanceaction23 = new GuidanceAction
            {
                Name = "What is the Guidance Explorer?",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/WhatistheGuidanceExplorer.mht",
            };
            guidanceaction22.ConnectTo(guidanceaction23);
            var guidanceaction24 = new GuidanceAction
            {
                Name = "What is the Guidance Browser?",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/WhatistheGuidanceBrowser.mht",
            };
            guidanceaction23.ConnectTo(guidanceaction24);
            var join25 = new Join
            {
                Name = "Join3",
            };
            guidanceaction24.ConnectTo(join25);
            var fork26 = new Fork
            {
                Name = "Automation",
            };
            join25.ConnectTo(fork26);
            var guidanceaction27 = new GuidanceAction
            {
                Name = "What is Automation?",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/WhatisAutomation.mht",
            };
            fork26.ConnectTo(guidanceaction27);
            var guidanceaction28 = new GuidanceAction
            {
                Name = "What are Artifact Links?",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/WhatareArtifactLinks.mht",
            };
            guidanceaction27.ConnectTo(guidanceaction28);
            var join29 = new Join
            {
                Name = "Join4",
            };
            guidanceaction28.ConnectTo(join29);
            var join30 = new Join
            {
                Name = "Join5",
            };
            join29.ConnectTo(join30);
            var join31 = new Join
            {
                Name = "Join6",
            };
            join30.ConnectTo(join31);
            var fork32 = new Fork
            {
                Name = "How To: Guides",
                Description = "The ‘How To’ guides provide background information, tips and instructions for performing the most common activities with the Solution Builder tool window.",
            };
            join31.ConnectTo(fork32);
            var fork33 = new Fork
            {
                Name = "Using",
                Description = "Installing and developing solutions with pattern toolkits using Solution Builder.",
            };
            fork32.ConnectTo(fork33);
            var guidanceaction34 = new GuidanceAction
            {
                Name = "Understanding: What are Pattern Toolkits?",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/UnderstandingWhatarePatternToolkits.mht",
            };
            fork33.ConnectTo(guidanceaction34);
            var guidanceaction35 = new GuidanceAction
            {
                Name = "How To: Install/Uninstall Pattern Toolkits",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/HowToInstallUninstallPatternToolkits.mht",
            };
            guidanceaction34.ConnectTo(guidanceaction35);
            var guidanceaction36 = new GuidanceAction
            {
                Name = "How To: Use a Pattern",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/HowToUseaPattern.mht",
            };
            guidanceaction35.ConnectTo(guidanceaction36);
            var guidanceaction37 = new GuidanceAction
            {
                Name = "How To: Add New Solution Elements",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/HowToAddNewSolutionElements.mht",
            };
            guidanceaction36.ConnectTo(guidanceaction37);
            var guidanceaction38 = new GuidanceAction
            {
                Name = "How To: Control the display of Solution Elements",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/HowToControlthedisplayofSolutionElements.mht",
            };
            guidanceaction37.ConnectTo(guidanceaction38);
            var guidanceaction39 = new GuidanceAction
            {
                Name = "How To: Work with Multiple Views",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/HowToWorkwithMultipleViews.mht",
            };
            guidanceaction38.ConnectTo(guidanceaction39);
            var guidanceaction40 = new GuidanceAction
            {
                Name = "How To: Find the Guidance",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/HowToFindtheGuidance.mht",
            };
            guidanceaction39.ConnectTo(guidanceaction40);
            var guidanceaction41 = new GuidanceAction
            {
                Name = "How To: Run Automation",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/HowToRunAutomation.mht",
            };
            guidanceaction40.ConnectTo(guidanceaction41);
            var guidanceaction42 = new GuidanceAction
            {
                Name = "How To: Use Drag and Drop",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/HowToUseDragandDrop.mht",
            };
            guidanceaction41.ConnectTo(guidanceaction42);
            var guidanceaction43 = new GuidanceAction
            {
                Name = "How To: Navigate to or Open Solution Items",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/HowToNavigatetoorOpenSolutionItems.mht",
            };
            guidanceaction42.ConnectTo(guidanceaction43);
            var guidanceaction44 = new GuidanceAction
            {
                Name = "How To: Validate Solution Elements",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/HowToValidateSolutionElements.mht",
            };
            guidanceaction43.ConnectTo(guidanceaction44);
            var guidanceaction45 = new GuidanceAction
            {
                Name = "How To: Fix Related Items",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/HowToFixRelatedItems.mht",
            };
            guidanceaction44.ConnectTo(guidanceaction45);
            var guidanceaction46 = new GuidanceAction
            {
                Name = "How To: Troubleshoot Pattern Problems",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/HowToTroubleshootPatternProblems.mht",
            };
            guidanceaction45.ConnectTo(guidanceaction46);
            var join47 = new Join
            {
                Name = "Join7",
            };
            guidanceaction46.ConnectTo(join47);
            var guidanceaction48 = new GuidanceAction
            {
                Name = "Authoring",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/Authoring.mht",
            };
            join47.ConnectTo(guidanceaction48);
            var join49 = new Join
            {
                Name = "Join8",
            };
            guidanceaction48.ConnectTo(join49);
            var fork50 = new Fork
            {
                Name = "Reference",
            };
            join49.ConnectTo(fork50);
            var guidanceaction51 = new GuidanceAction
            {
                Name = "Troubleshooting Toolkits",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/TroubleshootingToolkits.mht",
            };
            fork50.ConnectTo(guidanceaction51);
            var fork52 = new Fork
            {
                Name = "Environment",
                Description = "The development and tooling environment for using, authoring and customizing Pattern Toolkits.",
            };
            guidanceaction51.ConnectTo(fork52);
            var guidanceaction53 = new GuidanceAction
            {
                Name = "Visual Studio Experimental Instance",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/VisualStudioExperimentalInstance.mht",
            };
            fork52.ConnectTo(guidanceaction53);
            var guidanceaction54 = new GuidanceAction
            {
                Name = "Solution Builder",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/SolutionBuilder.mht",
            };
            guidanceaction53.ConnectTo(guidanceaction54);
            var guidanceaction55 = new GuidanceAction
            {
                Name = "Add New Solution Element Dialog",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/AddNewSolutionElementDialog.mht",
            };
            guidanceaction54.ConnectTo(guidanceaction55);
            var guidanceaction56 = new GuidanceAction
            {
                Name = "Pattern Model Designer",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/PatternModelDesigner.mht",
            };
            guidanceaction55.ConnectTo(guidanceaction56);
            var guidanceaction57 = new GuidanceAction
            {
                Name = "Guidance Workflow Explorer",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/GuidanceWorkflowExplorer.mht",
            };
            guidanceaction56.ConnectTo(guidanceaction57);
            var guidanceaction58 = new GuidanceAction
            {
                Name = "Solution Explorer",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/SolutionExplorer.mht",
            };
            guidanceaction57.ConnectTo(guidanceaction58);
            var guidanceaction59 = new GuidanceAction
            {
                Name = "Properties Window",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/PropertiesWindow.mht",
            };
            guidanceaction58.ConnectTo(guidanceaction59);
            var guidanceaction60 = new GuidanceAction
            {
                Name = "Add/New Project/Item Dialog",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/AddNewProjectItemDialog.mht",
            };
            guidanceaction59.ConnectTo(guidanceaction60);
            var guidanceaction61 = new GuidanceAction
            {
                Name = "Extension Manager",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/ExtensionManager.mht",
            };
            guidanceaction60.ConnectTo(guidanceaction61);
            var guidanceaction62 = new GuidanceAction
            {
                Name = "Options",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/Options.mht",
            };
            guidanceaction61.ConnectTo(guidanceaction62);
            var guidanceaction63 = new GuidanceAction
            {
                Name = "Tracing Window",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/TracingWindow.mht",
            };
            guidanceaction62.ConnectTo(guidanceaction63);
            var join64 = new Join
            {
                Name = "Join9",
            };
            guidanceaction63.ConnectTo(join64);
            var join65 = new Join
            {
                Name = "Join10",
            };
            join64.ConnectTo(join65);
            var guidanceaction66 = new GuidanceAction
            {
                Name = "More Information",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/MoreInformation.mht",
            };
            join65.ConnectTo(guidanceaction66);
            var fork67 = new Fork
            {
                Name = "Known Issues",
                Description = "This is a list of the critical known issues in the current version of NuPattern.",
            };
            guidanceaction66.ConnectTo(fork67);
            var guidanceaction68 = new GuidanceAction
            {
                Name = "Build error: “store must be open for this operation”",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/Builderrorstoremustbeopenforthisoperation.mht",
            };
            fork67.ConnectTo(guidanceaction68);
            var join69 = new Join
            {
                Name = "Join11",
            };
            guidanceaction68.ConnectTo(join69);
            var guidanceaction70 = new GuidanceAction
            {
                Name = "Feedback",
                Link = "content://93373818-600f-414b-8181-3a0cb79fa785/GeneratedCode/Guidance/Content/Feedback.mht",
            };
            join69.ConnectTo(guidanceaction70);
            var final71 = new Final
            {
                Name = "ActivityFinal1",
            };
            guidanceaction70.ConnectTo(final71);

            this.OnPostInitialize();
        }

        partial void OnPostInitialize();
    }

    /// <summary>
    /// Defines the feature extension containing the guidance workflow.
    /// </summary>
    [Feature("93373818-600f-414b-8181-3a0cb79fa785", DefaultName = "Using Patterns in Solution Development")]
    [Export(typeof(IFeatureExtension))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [CLSCompliant(false)]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [System.CodeDom.Compiler.GeneratedCode("NuPattern Toolkit Builder VS2012", "1.3.20.0")]
    public partial class Feature : BlackboardFeatureExtension<ProcessWorkflow>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Feature"/> class.
        /// </summary>
        public Feature()
            : base()
        {
        }

        /// <summary>
        /// Gets or sets the ServiceProvider.
        /// </summary>
        [Import]
        public SVsServiceProvider ServiceProvider { get; set; }
    }
}

