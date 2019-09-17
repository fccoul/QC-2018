using System;
using System.Web.Mvc;

namespace RAMQ.PRE.PL_Prem_iut
{
    /// <summary>
    /// Classe d'extension 
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public static class Extension
    {
        /// <summary>
        /// Permet d'obtenir un résultat typé
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="tempData">Object tempData</param>
        /// <param name="cle">Clé</param>
        /// <returns>Object typé</returns>
        public static T Obtenir<T>(this TempDataDictionary tempData, string cle)
        {
            return Nullable.GetUnderlyingType(typeof(T)) != null 
                ? tempData[cle] != null 
                    ? (T)tempData[cle] 
                    : default(T) 
                : tempData[cle] != null 
                    ? (T)Convert.ChangeType(tempData[cle], typeof(T)) 
                    : default(T);
        }

    }

}