﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NuPattern.Runtime.Guidance.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NuPattern.Runtime.Guidance.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to End.
        /// </summary>
        internal static string DefaultWorkflowViewModel_FinalLabel {
            get {
                return ResourceManager.GetString("DefaultWorkflowViewModel_FinalLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Start.
        /// </summary>
        internal static string DefaultWorkflowViewModel_InitialLabel {
            get {
                return ResourceManager.GetString("DefaultWorkflowViewModel_InitialLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not find matching Join for Fork.
        /// </summary>
        internal static string DefaultWorkflowViewModelBuilder_ErrorNoMatchingForkOrJoin {
            get {
                return ResourceManager.GetString("DefaultWorkflowViewModelBuilder_ErrorNoMatchingForkOrJoin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Encountered Join with parent not set.
        /// </summary>
        internal static string DefaultWorkflowViewModelBuilder_ErrorOrphanJoin {
            get {
                return ResourceManager.GetString("DefaultWorkflowViewModelBuilder_ErrorOrphanJoin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Encountered Merge with parent not set.
        /// </summary>
        internal static string DefaultWorkflowViewModelBuilder_ErrorOrphanMerge {
            get {
                return ResourceManager.GetString("DefaultWorkflowViewModelBuilder_ErrorOrphanMerge", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not find matching Merge for Decision.
        /// </summary>
        internal static string DefaultWorkflowViewModelBuilder_NoMatchingMerge {
            get {
                return ResourceManager.GetString("DefaultWorkflowViewModelBuilder_NoMatchingMerge", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Post-Conditions.
        /// </summary>
        internal static string GuidanceActionViewModel_PostConditionsLabel {
            get {
                return ResourceManager.GetString("GuidanceActionViewModel_PostConditionsLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pre-Conditions.
        /// </summary>
        internal static string GuidanceActionViewModel_PreConditionsLabel {
            get {
                return ResourceManager.GetString("GuidanceActionViewModel_PreConditionsLabel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Setting state to BLOCKED &apos;{0}.{1}&apos;..
        /// </summary>
        internal static string GuidanceConditionsEvaluator_TraceBlockState {
            get {
                return ResourceManager.GetString("GuidanceConditionsEvaluator_TraceBlockState", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ========================== Evaluating Conditions for &apos;{0}.{1}&apos;..
        /// </summary>
        internal static string GuidanceConditionsEvaluator_TraceEvaluationHeader {
            get {
                return ResourceManager.GetString("GuidanceConditionsEvaluator_TraceEvaluationHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Setting state to .
        /// </summary>
        internal static string GuidanceConditionsEvaluator_TraceStateToPostConditions {
            get {
                return ResourceManager.GetString("GuidanceConditionsEvaluator_TraceStateToPostConditions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Guidance extension &apos;{0}&apos; not found.
        /// </summary>
        internal static string GuidanceContentUriReferenceProvider_ErrorExtensionNotFound {
            get {
                return ResourceManager.GetString("GuidanceContentUriReferenceProvider_ErrorExtensionNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to File &apos;{0}&apos; does not exist..
        /// </summary>
        internal static string GuidanceContentUriReferenceProvider_ErrorFileNotExist {
            get {
                return ResourceManager.GetString("GuidanceContentUriReferenceProvider_ErrorFileNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Creating uri for content with extension id {0}, path {1}.
        /// </summary>
        internal static string GuidanceContentUriReferenceProvider_TraceCreateUri {
            get {
                return ResourceManager.GetString("GuidanceContentUriReferenceProvider_TraceCreateUri", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Opening content .
        /// </summary>
        internal static string GuidanceContentUriReferenceProvider_TraceOpenUri {
            get {
                return ResourceManager.GetString("GuidanceContentUriReferenceProvider_TraceOpenUri", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Resolved to path {0}.
        /// </summary>
        internal static string GuidanceContentUriReferenceProvider_TraceResolvedToPath {
            get {
                return ResourceManager.GetString("GuidanceContentUriReferenceProvider_TraceResolvedToPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Resolving uri {0}.
        /// </summary>
        internal static string GuidanceContentUriReferenceProvider_TraceResolvingUri {
            get {
                return ResourceManager.GetString("GuidanceContentUriReferenceProvider_TraceResolvingUri", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Created uri {0}.
        /// </summary>
        internal static string GuidanceContentUriReferenceProvider_TraceUriCreated {
            get {
                return ResourceManager.GetString("GuidanceContentUriReferenceProvider_TraceUriCreated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Models.
        /// </summary>
        internal static string GuidanceManager_DefaultExtensionProjectName {
            get {
                return ResourceManager.GetString("GuidanceManager_DefaultExtensionProjectName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Guidance extension with name &apos;{0}&apos; already exists in the solution..
        /// </summary>
        internal static string GuidanceManager_DuplicateGuidanceName {
            get {
                return ResourceManager.GetString("GuidanceManager_DuplicateGuidanceName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Guidance extension&apos;{0}&apos; instance name &apos;{1}&apos; is already instantiated..
        /// </summary>
        internal static string GuidanceManager_ExtensionAlreadyInstantiated {
            get {
                return ResourceManager.GetString("GuidanceManager_ExtensionAlreadyInstantiated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Guidance extension with identifier &apos;{0}&apos; is not installed or it is not properly registered..
        /// </summary>
        internal static string GuidanceManager_ExtensionNotInstalled {
            get {
                return ResourceManager.GetString("GuidanceManager_ExtensionNotInstalled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Manager has not been initialized with a solution state yet..
        /// </summary>
        internal static string GuidanceManager_MustInitializeSolutionState {
            get {
                return ResourceManager.GetString("GuidanceManager_MustInitializeSolutionState", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The guidance workflow cannot be null..
        /// </summary>
        internal static string GuidanceManager_NullGuidanceWorkflow {
            get {
                return ResourceManager.GetString("GuidanceManager_NullGuidanceWorkflow", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to initialize guidance extension.
        /// </summary>
        internal static string GuidanceManager_TraceFailedExtensionInitialization {
            get {
                return ResourceManager.GetString("GuidanceManager_TraceFailedExtensionInitialization", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An error happened while finishing the guidance extension. State may be invalid. Continuing to remove guidance extension from solution state.
        ///{0}.
        /// </summary>
        internal static string GuidanceManager_TraceFailedFinish {
            get {
                return ResourceManager.GetString("GuidanceManager_TraceFailedFinish", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to instantiate guidance extension.
        /// </summary>
        internal static string GuidanceManager_TraceFailedInstantiate {
            get {
                return ResourceManager.GetString("GuidanceManager_TraceFailedInstantiate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Guidance extension successfully finished..
        /// </summary>
        internal static string GuidanceManager_TraceFinishCOmplete {
            get {
                return ResourceManager.GetString("GuidanceManager_TraceFinishCOmplete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Finishing guidance extension.
        /// </summary>
        internal static string GuidanceManager_TraceFinishExtension {
            get {
                return ResourceManager.GetString("GuidanceManager_TraceFinishExtension", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Initializing existing guidance extension &apos;{0}&apos; (Id: &apos;{1}&apos;)..
        /// </summary>
        internal static string GuidanceManager_TraceInitializeExtension {
            get {
                return ResourceManager.GetString("GuidanceManager_TraceInitializeExtension", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Instantiating guidance extension &apos;{0}&apos; (Id: &apos;{1}&apos;)..
        /// </summary>
        internal static string GuidanceManager_TraceInstantiateExtension {
            get {
                return ResourceManager.GetString("GuidanceManager_TraceInstantiateExtension", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Loading guidance extensions from solution state.
        /// </summary>
        internal static string GuidanceManager_TraceOpenFromSolutionState {
            get {
                return ResourceManager.GetString("GuidanceManager_TraceOpenFromSolutionState", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The guidance workflow with name &apos;{0}&apos; has not yet been created, and cannot be displayed..
        /// </summary>
        internal static string GuidanceShortcutProvider_ActivateInstanceNotFound {
            get {
                return ResourceManager.GetString("GuidanceShortcutProvider_ActivateInstanceNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The guidance extension with identifier &apos;{0}&apos; is not yet installed, and cannot be used to display or create a new instance of this workflow..
        /// </summary>
        internal static string GuidanceShortcutProvider_ActivateSharedExtensionNotFound {
            get {
                return ResourceManager.GetString("GuidanceShortcutProvider_ActivateSharedExtensionNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The guidance extension with identifier &apos;{0}&apos; is not yet installed, and cannot be used to create a new instance of this workflow..
        /// </summary>
        internal static string GuidanceShortcutProvider_InstantiateExtensionNotFound {
            get {
                return ResourceManager.GetString("GuidanceShortcutProvider_InstantiateExtensionNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The shortcut configuration is missing vital information necessary to display any guidance..
        /// </summary>
        internal static string GuidanceShortcutProvider_InvalidParameters {
            get {
                return ResourceManager.GetString("GuidanceShortcutProvider_InvalidParameters", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Registering launch point uri {0}.
        /// </summary>
        internal static string LaunchPointUriReferenceProvider_TraceRegisterLaunchPoint {
            get {
                return ResourceManager.GetString("LaunchPointUriReferenceProvider_TraceRegisterLaunchPoint", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Retrieving types from project {0}.
        /// </summary>
        internal static string ProjectTypeProvider_TraceLoadProjectTypes {
            get {
                return ResourceManager.GetString("ProjectTypeProvider_TraceLoadProjectTypes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Reloading types available in the current solution.
        /// </summary>
        internal static string ProjectTypeProvider_TraceLoadTypes {
            get {
                return ResourceManager.GetString("ProjectTypeProvider_TraceLoadTypes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Requires User Acceptance.
        /// </summary>
        internal static string UserAcceptanceBinding_UserMessage {
            get {
                return ResourceManager.GetString("UserAcceptanceBinding_UserMessage", resourceCulture);
            }
        }
    }
}
