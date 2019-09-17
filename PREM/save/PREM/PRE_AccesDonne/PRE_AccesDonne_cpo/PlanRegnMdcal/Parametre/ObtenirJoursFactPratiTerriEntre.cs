using System;
using System.Data;
using RAMQ.Attribut;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary> 
    ///  Classe de paramètres d'entré pour le service du noyau « Obtenir les jours facturés de la pratique PREM par territoire ».
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
        [ValeurEntite(ElementName = "pTblNoSeqDisp", Direction = ParameterDirection.Input)]
        public IEnumerable<long> NumerosSequentielsProfs { get; set; }

        /// <summary>
        /// Date de début (Optionnelle)
        /// </summary>
        /// <remarks>Optionnel</remarks>
        [ValeurEntite(ElementName = "pDatDateDebut", Direction = ParameterDirection.Input)]
        public DateTime? DateDebut { get; set; }

        /// <summary>
        /// Date de fin (Optionnelle)
        /// </summary>
        /// <remarks>Optionnel</remarks>
        [ValeurEntite(ElementName = "pDatDateFin", Direction = ParameterDirection.Input)]
        public DateTime? DateFin { get; set; }

        /// <summary>
        /// Regroupement LGEO (Optionnel)
        /// </summary>
        /// <remarks>Optionnel</remarks>
        [ValeurEntite(ElementName = "pNumRegrLieuGeographique", Direction = ParameterDirection.Input)]
        public string NumeroRegrLieuGeographique { get; set; }

        /// <summary>
        /// Type LGEO (Optionnel)
        /// </summary>
        /// <remarks>Optionnel</remarks>
        [ValeurEntite(ElementName = "pVchrTypeLieuGeographique", Direction = ParameterDirection.Input)]
        public string TypeLieuGeographique { get; set; }

        /// <summary>
        /// Code LGEO (Optionnel)
        /// </summary>
        /// <remarks>Optionnel</remarks>
        [ValeurEntite(ElementName = "pVchrCodeLieuGeographique", Direction = ParameterDirection.Input)]
        public string CodeLieuGeographique { get; set; }

        /// <summary>
        /// Montant par journée
        /// </summary>
        /// <remarks>Optionnel</remarks>
        [ValeurEntite(ElementName = "pNumMontantJournee", Direction = ParameterDirection.Input)]
        public int MontantparJournee { get; set; }
    }
}