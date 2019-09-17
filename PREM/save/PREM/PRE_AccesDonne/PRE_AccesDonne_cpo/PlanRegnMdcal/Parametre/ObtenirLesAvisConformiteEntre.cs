using System;
using System.Data;
using RAMQ.Attribut;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{

    /// <summary> 
    ///  Classe de paramètres d'entrées pour le service du noyau « Obtenir la liste des avis de conformité ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau<br/>
    ///  Date   : Septembre 2016
    /// </remarks>
    public class ObtenirLesAvisConformiteEntre
    {

        /// <summary>
        /// Numéro séquentiel de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNumeroSequentielEngag", Direction = ParameterDirection.Input)]
        public long? NumeroSequentielEngagement { get; set; }

        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNumeroSequentielDisp", Direction = ParameterDirection.Input)]
        public long? NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Code de région socio-sanitaire
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrCodeRegionSocioSanitaire", Direction = ParameterDirection.Input)]
        public string CodeRegion { get; set; }

        /// <summary>
        /// Indicateur d'attente de transmission
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrIndAttenteTransmission", Direction = ParameterDirection.Input)]
        public string IndicateurAttenteTransmission { get; set; }

        /// <summary>
        /// Date de recherche
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDateRecherche", Direction = ParameterDirection.Input)]
        public DateTime? DateRecherche { get; set; }

        /// <summary>
        /// Date de début
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDateDebut", Direction = ParameterDirection.Input)]
        public DateTime? DateDebut { get; set; }

        /// <summary>
        /// Date de fin
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDateFin", Direction = ParameterDirection.Input)]
        public DateTime? DateFin { get; set; }

        /// <summary>
        /// Indicateur d'avis inactivé
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrIndicateurAvisInactive", Direction = ParameterDirection.Input)]
        public string IndicateurAvisInactive { get; set; }

        /// <summary>
        /// Tri
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrTri", Direction = ParameterDirection.Input)]
        public string Tri { get; set; }

    }
}