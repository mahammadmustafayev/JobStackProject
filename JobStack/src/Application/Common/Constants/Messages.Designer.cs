﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobStack.Application.Common.Constants {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("JobStack.Application.Common.Constants.Messages", typeof(Messages).Assembly);
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
        ///   Looks up a localized string similar to Added Successfully.
        /// </summary>
        internal static string Added {
            get {
                return ResourceManager.GetString("Added", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This file deleted successfully.
        /// </summary>
        internal static string DeletedMessage {
            get {
                return ResourceManager.GetString("DeletedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This cv file must be better than 500 kb.
        /// </summary>
        internal static string InvalidCvFile {
            get {
                return ResourceManager.GetString("InvalidCvFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This image type must be image.
        /// </summary>
        internal static string InvalidImagePhoto {
            get {
                return ResourceManager.GetString("InvalidImagePhoto", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This image must be better than 200 kb.
        /// </summary>
        internal static string InvalidPhoto {
            get {
                return ResourceManager.GetString("InvalidPhoto", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This category is not found!.
        /// </summary>
        internal static string NullMessage {
            get {
                return ResourceManager.GetString("NullMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;div style=&quot;border: 2px solid black;border-radius: 25px; &quot;&gt;
        ///        &lt;img style=&quot;padding-left: 600px; width: 200px;height: 45px; padding-top: 15px;&quot; src=&quot;https://shreethemes.in/jobstack/layouts/assets/images/logo-dark.png&quot; alt=&quot;&quot;&gt;
        ///        &lt;div style=&quot;padding-left: 50px;&quot;&gt;
        ///            &lt;h3 style=&quot;font-size: 25px;&quot;&gt;Deyerli Mehemmed Mustafayev&lt;/h3&gt;
        ///            &lt;p style=&quot;font-size: 20px;&quot;&gt;&lt;b style=&quot;font-size: 20px;&quot;&gt;Lenovo&lt;/b&gt; sirketinin  &lt;b style=&quot;font-size: 20px;&quot;&gt;Back-end developer&lt;/b&gt; vakansiyasına muraci [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SendEmailMessages {
            get {
                return ResourceManager.GetString("SendEmailMessages", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Updated Successfully.
        /// </summary>
        internal static string Updated {
            get {
                return ResourceManager.GetString("Updated", resourceCulture);
            }
        }
    }
}
