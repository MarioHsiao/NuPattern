﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
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
        ///   Looks up a localized string similar to The focused activity can only be set for the root of the diagram (that is, the guidance workflow itself)..
        /// </summary>
        internal static string ActivityDiagramFocusedActionStorage_InvalidNode {
            get {
                return ResourceManager.GetString("ActivityDiagramFocusedActionStorage_InvalidNode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The given guidance node identifier &apos;{0}&apos; could not be found in the source activity diagram. Generated code may be out of sync. Please re-apply the text transformation to the source diagram..
        /// </summary>
        internal static string ActivityDiagramNodeStateStorage_InvalidNodeId {
            get {
                return ResourceManager.GetString("ActivityDiagramNodeStateStorage_InvalidNodeId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Storage implementation supports the root activity or actions..
        /// </summary>
        internal static string ActivityDiagramNodeStateStorage_InvalidNodeType {
            get {
                return ResourceManager.GetString("ActivityDiagramNodeStateStorage_InvalidNodeType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Models.
        /// </summary>
        internal static string FeatureManager_DefaultFeaturesProjectName {
            get {
                return ResourceManager.GetString("FeatureManager_DefaultFeaturesProjectName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Feature with name &apos;{0}&apos; already exists in the solution..
        /// </summary>
        internal static string FeatureManager_DuplicateFeatureName {
            get {
                return ResourceManager.GetString("FeatureManager_DuplicateFeatureName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Feature &apos;{0}&apos; instance name &apos;{1}&apos; is already instantiated..
        /// </summary>
        internal static string FeatureManager_FeatureAlreadyInstantiated {
            get {
                return ResourceManager.GetString("FeatureManager_FeatureAlreadyInstantiated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Feature with identifier &apos;{0}&apos; is not installed or it is not properly registered..
        /// </summary>
        internal static string FeatureManager_FeatureNotInstalled {
            get {
                return ResourceManager.GetString("FeatureManager_FeatureNotInstalled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Manager has not been initialized with a solution state yet..
        /// </summary>
        internal static string FeatureManager_MustInitializeSolutionState {
            get {
                return ResourceManager.GetString("FeatureManager_MustInitializeSolutionState", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The feature guidance workflow cannot be null..
        /// </summary>
        internal static string FeatureManager_NullGuidanceWorkflow {
            get {
                return ResourceManager.GetString("FeatureManager_NullGuidanceWorkflow", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to .Guidance.
        /// </summary>
        internal static string ModelingFeatureExtension_DefaultGuidanceSuffix {
            get {
                return ResourceManager.GetString("ModelingFeatureExtension_DefaultGuidanceSuffix", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not locate the guidance workflow activity diagram for the feature with identifier &apos;{0}&apos; and instance name &apos;{1}&apos;..
        /// </summary>
        internal static string ModelingFeatureExtension_NoActivityDiagram {
            get {
                return ResourceManager.GetString("ModelingFeatureExtension_NoActivityDiagram", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Feature &apos;{0}&apos; project template could not be located. Please reinstall the feature..
        /// </summary>
        internal static string ModelingFeatureExtension_NoFeatureProjectTemplate {
            get {
                return ResourceManager.GetString("ModelingFeatureExtension_NoFeatureProjectTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No modeling project could be located for feature state..
        /// </summary>
        internal static string ModelingFeatureExtension_NoModelingProject {
            get {
                return ResourceManager.GetString("ModelingFeatureExtension_NoModelingProject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A factory to retrieve extended feature information for a solution has not been set. Please ensure SolutionExtensions.FeatureSolutionFactory is set..
        /// </summary>
        internal static string ModelingSolutionExtensions_NullFeatureSolutionFactory {
            get {
                return ResourceManager.GetString("ModelingSolutionExtensions_NullFeatureSolutionFactory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Visual Studio SDK must be installed to use the Feature Builder.
        /// </summary>
        internal static string StandardFeatureTemplateExtension_ErrorVSSDKNotInstalled {
            get {
                return ResourceManager.GetString("StandardFeatureTemplateExtension_ErrorVSSDKNotInstalled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Visual Studio SDK must be installed to use the Feature Builder.
        ///
        ///This project template requires the SDK to expand successfully..
        /// </summary>
        internal static string StandardFeatureTemplateExtension_VSSDKNotInstalled {
            get {
                return ResourceManager.GetString("StandardFeatureTemplateExtension_VSSDKNotInstalled", resourceCulture);
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
        
        /// <summary>
        ///   Looks up a localized string similar to Template contains a feature template extension of type &apos;{0}&apos;, but its owning VSIX does not provide a valid Feature Extension. Please contact the template or VSIX author..
        /// </summary>
        internal static string VsTemplateExtension_NoOwningFeatureForExtension {
            get {
                return ResourceManager.GetString("VsTemplateExtension_NoOwningFeatureForExtension", resourceCulture);
            }
        }
    }
}
