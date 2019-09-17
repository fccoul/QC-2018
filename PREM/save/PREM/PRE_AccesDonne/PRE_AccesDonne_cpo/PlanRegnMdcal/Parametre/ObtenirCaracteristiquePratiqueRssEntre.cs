using System;
using System.Data;
using RAMQ.Attribut;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{

    /// <summary> 
    ///  Classe de paramètres d'entré pour le service du noyau « Obtenir caractéristique pratique RSS ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart<br/>
    ///  Date   : Juin 2017
    /// </remarks>
    public class ObtenirCaracteristiquePratiqueRssEntre
    {

        /// <summary>
        /// Code RSS
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrCodeRss", Direction = ParameterDirection.Input)]
        public string CodeRss { get; set; }

        /// <summary>
        /// Caractéristique de pratique
        /// </summary>
        /// <remarks>Optionnel</remarks>
        [ValeurEntite(ElementName = "pVchrCarPrati", Direction = ParameterDirection.Input)]
        public string CaracteristiquePratique { get; set; }

        /// <summary>
        /// Date de début
        /// </summary>
        /// <remarks>Optionnel</remarks>
        [ValeurEntite(ElementName = "pDatDateDebut", Direction = ParameterDirection.Input)]
        public DateTime? DateDeDebut { get; set; }

        /// <summary>
        /// Date de fin
        /// </summary>
        /// <remarks>Optionnel</remarks>
        [ValeurEntite(ElementName = "pDatDateFin", Direction = ParameterDirection.Input)]
        public DateTime? DateDeFin { get; set; }
    }

}