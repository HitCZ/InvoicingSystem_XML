﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InvoicingSystem_XML.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("InvoicingSystem_XML.Properties.Strings", typeof(Strings).Assembly);
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
        ///   Looks up a localized string similar to Město není vyplněno..
        /// </summary>
        internal static string ERR_CITY_EMPTY {
            get {
                return ResourceManager.GetString("ERR_CITY_EMPTY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Číslo domu není vyplněno..
        /// </summary>
        internal static string ERR_CONTRACTOR_BUILDING_EMPTY {
            get {
                return ResourceManager.GetString("ERR_CONTRACTOR_BUILDING_EMPTY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Číslo domu není ve správném tvaru..
        /// </summary>
        internal static string ERR_CONTRACTOR_BUILDING_INVALID {
            get {
                return ResourceManager.GetString("ERR_CONTRACTOR_BUILDING_INVALID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Jméno dodavatele není vyplněno..
        /// </summary>
        internal static string ERR_CONTRACTOR_NAME_INVALID {
            get {
                return ResourceManager.GetString("ERR_CONTRACTOR_NAME_INVALID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Země není vyplněna..
        /// </summary>
        internal static string ERR_COUNTRY_EMPTY {
            get {
                return ResourceManager.GetString("ERR_COUNTRY_EMPTY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ulice není vyplněna..
        /// </summary>
        internal static string ERR_STREET_EMPTY {
            get {
                return ResourceManager.GetString("ERR_STREET_EMPTY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Poštovní směrovací číslo není vyplněno..
        /// </summary>
        internal static string ERR_ZIPCODE_EMPTY {
            get {
                return ResourceManager.GetString("ERR_ZIPCODE_EMPTY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Poštovní směrovací číslo neobsahuje žádné číslo..
        /// </summary>
        internal static string ERR_ZIPCODE_INVALID {
            get {
                return ResourceManager.GetString("ERR_ZIPCODE_INVALID", resourceCulture);
            }
        }
    }
}
