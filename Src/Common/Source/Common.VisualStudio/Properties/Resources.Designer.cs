﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NuPattern.VisualStudio.Properties {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NuPattern.VisualStudio.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Failed to create a new empty solution, an error occurred creating and saving the new solution to &apos;{0}&apos;. Verify that you have permissions to create new subfolders in the parent directory..
        /// </summary>
        internal static string DteExtensions_CreateNewSolution_FailedCreate {
            get {
                return ResourceManager.GetString("DteExtensions_CreateNewSolution_FailedCreate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to create a new empty solution, the default save location for new solutions could not be found..
        /// </summary>
        internal static string DteExtensions_CreateNewSolution_FailedDirSearch {
            get {
                return ResourceManager.GetString("DteExtensions_CreateNewSolution_FailedDirSearch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Could not find or create target path &apos;{0}&apos;..
        /// </summary>
        internal static string SolutionExtensions_CouldNotFindOrCreate {
            get {
                return ResourceManager.GetString("SolutionExtensions_CouldNotFindOrCreate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Solution item with name &apos;{0}&apos; already exists, rename failed..
        /// </summary>
        internal static string SolutionExtensions_ErrorRenamedItemExists {
            get {
                return ResourceManager.GetString("SolutionExtensions_ErrorRenamedItemExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown  solution item type for rename.
        /// </summary>
        internal static string SolutionExtensions_ErrorRenameUnknownType {
            get {
                return ResourceManager.GetString("SolutionExtensions_ErrorRenameUnknownType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The folder path &apos;{0}&apos; already exists..
        /// </summary>
        internal static string SolutionExtensions_FolderPathAlreadyExists {
            get {
                return ResourceManager.GetString("SolutionExtensions_FolderPathAlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The path to create can only be relative to a solution, solution folder, project or folder. Invalid relative node kind &apos;{0}&apos; found at &apos;{1}&apos; for path expression &apos;{2}&apos;..
        /// </summary>
        internal static string SolutionExtensions_InvalidFolderPath {
            get {
                return ResourceManager.GetString("SolutionExtensions_InvalidFolderPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Solution element &apos;{0}&apos; must be contained in a project in the solution..
        /// </summary>
        internal static string SolutionExtensions_ItemNotInProject {
            get {
                return ResourceManager.GetString("SolutionExtensions_ItemNotInProject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Service &apos;{0}&apos; is required..
        /// </summary>
        internal static string SolutionExtensions_MissingService {
            get {
                return ResourceManager.GetString("SolutionExtensions_MissingService", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The solution element &apos;{0}&apos; must be contained in a project containing a VSIX manifest file marked with the &apos;{1}&apos; MSBuild metadata..
        /// </summary>
        internal static string SolutionExtensions_NotToolkitProject {
            get {
                return ResourceManager.GetString("SolutionExtensions_NotToolkitProject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An associated solution item (file, folder or project) with the name &apos;{0}&apos; already exists in the solution. 
        ///The solution item has instead been renamed to: &apos;{1}&apos;..
        /// </summary>
        internal static string SolutionExtensions_PromptItemAlreadyExists_Message {
            get {
                return ResourceManager.GetString("SolutionExtensions_PromptItemAlreadyExists_Message", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Solution Item Already Exists.
        /// </summary>
        internal static string SolutionExtensions_PromptItemAlreadyExists_Title {
            get {
                return ResourceManager.GetString("SolutionExtensions_PromptItemAlreadyExists_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Project type is not supported. It must be a Visual Studio project..
        /// </summary>
        internal static string SolutionExtensions_UnsupportedProject {
            get {
                return ResourceManager.GetString("SolutionExtensions_UnsupportedProject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please see the Output Window (&apos;NuPattern Toolkit Extensions&apos; pane) for more information...
        /// </summary>
        internal static string TraceSourceExtensions_SeeDiagnosticsWindow {
            get {
                return ResourceManager.GetString("TraceSourceExtensions_SeeDiagnosticsWindow", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Vsix manifest file &apos;{0}&apos; does not contain required Identifier element..
        /// </summary>
        internal static string Vsix_InvalidManifest {
            get {
                return ResourceManager.GetString("Vsix_InvalidManifest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Vsix file &apos;{0}&apos; does not contain the required manifest named &quot;extension.vsixmanifest&quot;..
        /// </summary>
        internal static string Vsix_ManifestMissing {
            get {
                return ResourceManager.GetString("Vsix_ManifestMissing", resourceCulture);
            }
        }
    }
}
