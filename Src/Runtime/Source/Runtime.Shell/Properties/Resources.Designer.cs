﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NuPattern.Runtime.Shell.Properties {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NuPattern.Runtime.Shell.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Can not create tool window..
        /// </summary>
        internal static string CanNotCreateWindow {
            get {
                return ResourceManager.GetString("CanNotCreateWindow", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Guidance Browser.
        /// </summary>
        internal static string GuidanceBrowserToolWindow_WindowTitle {
            get {
                return ResourceManager.GetString("GuidanceBrowserToolWindow_WindowTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Guidance Explorer.
        /// </summary>
        internal static string GuidanceExplorerToolWindow_WindowTitle {
            get {
                return ResourceManager.GetString("GuidanceExplorerToolWindow_WindowTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The following extension is currently installed and enabled: 
        ///    {0}.
        ///
        ///This extension is not compatible with the current version of the &apos;{1}&apos; extension. We recommend that you disable this extension for correct operation.
        ///
        ///To remedy this problem, open the &apos;Extension Manager&apos; window in Visual Studio (Tools menu), disable the listed extension above, and restart Visual Studio..
        /// </summary>
        internal static string RuntimeShellPackage_CheckFertInstalled_Enabled {
            get {
                return ResourceManager.GetString("RuntimeShellPackage_CheckFertInstalled_Enabled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The dependency &apos;{0}&apos; could not be found in the repository..
        /// </summary>
        internal static string RuntimeShellPackage_DependencyNotAvailable {
            get {
                return ResourceManager.GetString("RuntimeShellPackage_DependencyNotAvailable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A MEF exception happened loading &apos;{0}&apos;. The MEF logs will be opened now for diagnostics..
        /// </summary>
        internal static string RuntimeShellPackage_DumpMefLogs {
            get {
                return ResourceManager.GetString("RuntimeShellPackage_DumpMefLogs", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attempting to resolve partially named assembly &apos;{0}&apos;..
        /// </summary>
        internal static string RuntimeShellPackage_OnAssemblyResolved_ResolvingAssembly {
            get {
                return ResourceManager.GetString("RuntimeShellPackage_OnAssemblyResolved_ResolvingAssembly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Partially named assembly &apos;{0}&apos;, was not resolved to any Pattern Toolkit assembly loaded into the AppDomain..
        /// </summary>
        internal static string RuntimeShellPackage_OnAssemblyResolved_ResolvingAssemblyFailed {
            get {
                return ResourceManager.GetString("RuntimeShellPackage_OnAssemblyResolved_ResolvingAssemblyFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Partially named assembly &apos;{0}&apos;, was loaded into the current AppDomain..
        /// </summary>
        internal static string RuntimeShellPackage_OnAssemblyResolved_ResolvingAssemblyForLoadedAssembly {
            get {
                return ResourceManager.GetString("RuntimeShellPackage_OnAssemblyResolved_ResolvingAssemblyForLoadedAssembly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Partially named assembly &apos;{0}&apos;, is installed by an enabled Pattern Toolkit..
        /// </summary>
        internal static string RuntimeShellPackage_OnAssemblyResolved_ResolvingAssemblyForToolkitAssembly {
            get {
                return ResourceManager.GetString("RuntimeShellPackage_OnAssemblyResolved_ResolvingAssemblyForToolkitAssembly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Partially named assembly &apos;{0}&apos;, was resolved to Pattern Toolkit assembly &apos;{1}&apos;..
        /// </summary>
        internal static string RuntimeShellPackage_OnAssemblyResolved_ResolvingAssemblySucceeded {
            get {
                return ResourceManager.GetString("RuntimeShellPackage_OnAssemblyResolved_ResolvingAssemblySucceeded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unexpected error resolving partially named assembly, the error was: {0}.
        /// </summary>
        internal static string RuntimeShellPackage_OnAssemblyResolved_UnexpectedError {
            get {
                return ResourceManager.GetString("RuntimeShellPackage_OnAssemblyResolved_UnexpectedError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Shortcut cannot be executed, file content is invalid..
        /// </summary>
        internal static string ShortcutEditorFactory_ErrorShortcutFormat {
            get {
                return ResourceManager.GetString("ShortcutEditorFactory_ErrorShortcutFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Shortcut cannot be read or written to file. Check the permissions to the file and whether the file is locked..
        /// </summary>
        internal static string ShortcutEditorFactory_ErrorShortcutIO {
            get {
                return ResourceManager.GetString("ShortcutEditorFactory_ErrorShortcutIO", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Shortcut cannot be executed, its type is unknown, or the format of the shortcut is invalid..
        /// </summary>
        internal static string ShortcutEditorFactory_ErrorShortcutProviderNotExist {
            get {
                return ResourceManager.GetString("ShortcutEditorFactory_ErrorShortcutProviderNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Shortcut cannot be opened, an unexpected error has occured..
        /// </summary>
        internal static string ShortcutEditorFactory_ErrorUnknown {
            get {
                return ResourceManager.GetString("ShortcutEditorFactory_ErrorUnknown", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Solution Builder.
        /// </summary>
        internal static string SolutionBuilderToolWindow_WindowTitle {
            get {
                return ResourceManager.GetString("SolutionBuilderToolWindow_WindowTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pattern Toolkit References.
        /// </summary>
        internal static string ToolkitReferencesFolderName {
            get {
                return ResourceManager.GetString("ToolkitReferencesFolderName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Logging Level.
        /// </summary>
        internal static string TraceOptionsPageControl_LoggingLevelTitle {
            get {
                return ResourceManager.GetString("TraceOptionsPageControl_LoggingLevelTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Source Name is Invalid..
        /// </summary>
        internal static string TraceOptionsPageControl_SourceNameInvalid {
            get {
                return ResourceManager.GetString("TraceOptionsPageControl_SourceNameInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Source Name is Required..
        /// </summary>
        internal static string TraceOptionsPageControl_SourceNameRequired {
            get {
                return ResourceManager.GetString("TraceOptionsPageControl_SourceNameRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Source Name.
        /// </summary>
        internal static string TraceOptionsPageControl_SourceNameTitle {
            get {
                return ResourceManager.GetString("TraceOptionsPageControl_SourceNameTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to register task to perform on VS idle time..
        /// </summary>
        internal static string VsIdleTaskHost_ErrorRegistration {
            get {
                return ResourceManager.GetString("VsIdleTaskHost_ErrorRegistration", resourceCulture);
            }
        }
    }
}
