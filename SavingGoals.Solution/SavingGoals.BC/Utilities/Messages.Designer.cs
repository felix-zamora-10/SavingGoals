﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SavingGoals.BC.Utilities {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SavingGoals.BC.Utilities.Messages", typeof(Messages).Assembly);
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
        ///   Looks up a localized string similar to Debe ingresar un monto objetivo válido, debe ser mayor o igual a 1..
        /// </summary>
        internal static string SavingCalculation_EstimatedAmountError {
            get {
                return ResourceManager.GetString("SavingCalculation_EstimatedAmountError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El id no es válido, ingrese un id mayor o igual a 1..
        /// </summary>
        internal static string SavingCalculation_IdError {
            get {
                return ResourceManager.GetString("SavingCalculation_IdError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Los movimientos mensuales no pueden ser nulos..
        /// </summary>
        internal static string SavingCalculation_MonthlyMovementsNull {
            get {
                return ResourceManager.GetString("SavingCalculation_MonthlyMovementsNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El ahorro no puede ser nulo..
        /// </summary>
        internal static string SavingCalculation_SavingGoalNull {
            get {
                return ResourceManager.GetString("SavingCalculation_SavingGoalNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Debe ingresar un monto de ahorro mensual válido, debe ser mayor o igual a 1..
        /// </summary>
        internal static string SavingCalculation_SavingPerMonthError {
            get {
                return ResourceManager.GetString("SavingCalculation_SavingPerMonthError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El monto de ahorro deseado es menor o igual al monto ahorrado..
        /// </summary>
        internal static string SavingCalculation_TargetAmountError {
            get {
                return ResourceManager.GetString("SavingCalculation_TargetAmountError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El monto del ahorro no es válido, debe ser mayor o igual a 1..
        /// </summary>
        internal static string SavingGoal_AmountSavedError {
            get {
                return ResourceManager.GetString("SavingGoal_AmountSavedError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to La descripción no puede estar vacía..
        /// </summary>
        internal static string SavingGoal_DescriptionError {
            get {
                return ResourceManager.GetString("SavingGoal_DescriptionError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El id no es válido, ingrese un id mayor o igual a 1..
        /// </summary>
        internal static string SavingGoal_IdError {
            get {
                return ResourceManager.GetString("SavingGoal_IdError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No se puede agregar dos ahorros iniciales..
        /// </summary>
        internal static string SavingGoal_MonthlyMovements {
            get {
                return ResourceManager.GetString("SavingGoal_MonthlyMovements", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No hay ahorros por guardar..
        /// </summary>
        internal static string SavingGoal_MonthlyMovementsNull {
            get {
                return ResourceManager.GetString("SavingGoal_MonthlyMovementsNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El objeto no puede estar vacío, debe enviar un objeto válido..
        /// </summary>
        internal static string SavingGoal_NullObject {
            get {
                return ResourceManager.GetString("SavingGoal_NullObject", resourceCulture);
            }
        }
    }
}
