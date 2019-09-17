using System;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_Entites_cpo.Pratique.Parametre
{
    /// <summary> 
    ///  Paramètres d'entré pour le service du noyau « Obtenir les jours facturés de la pratique PREM par territoire ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart<br/>
    ///  Date   : Février 2017
    /// </remarks>
	public class ObtenirJoursFactPratiTerriEntre
    {
        /// <summary>
        /// Liste de numéros séquentiels des professionnels de la santé 
        /// </summary>
        /// <remarks></remarks>
        public IEnumerable<long> NumerosSequentielsProfs { get; set; }

        /// <summary>
        /// Date de début (Optionnelle)
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public DateTime? DateDebut { get; set; }

        /// <summary>
        /// Date de fin (Optionnelle)
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public DateTime? DateFin { get; set; }

        /// <summary>
        /// Regroupement LGEO (Optionnel)
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public string NumeroRegrLieuGeographique { get; set; }

        /// <summary>
        /// Type LGEO (Optionnel)
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public string TypeLieuGeographique { get; set; }

        /// <summary>
        /// Code LGEO (Optionnel)
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public string CodeLieuGeographique { get; set; }

        /// <summary>
        /// Montant par journée
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public int MontantparJournee { get; set; }
    }
}