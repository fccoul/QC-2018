using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace RAMQ.PRE.PL_Prem_iut.CustomValidationAttribute
{
    /// <summary>
    /// Classe personnalisé de type DataAnnotation permettant de valider qu'un champ boolean est présent et à la valeur true.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class RequiredTrueAttribute : ValidationAttribute
    {
        /// <summary>
        /// Fonction permettant de valider la valeur du champ.
        /// On vérifie que le champ est présent et qu'il a la valeur true. 
        /// </summary>
        /// <param name="value">Valeur du champ à valider.</param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            bool isAccepted = (bool)value;
            return (isAccepted == true);
        }

        /// <summary>
        /// Fonction permettant de retourner un message d'erreur formaté.
        /// </summary>
        /// <param name="name">Nom du champ</param>
        /// <returns>Message d'erreur formaté</returns>
        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture,
              ErrorMessageString, name);
        }
    }
}