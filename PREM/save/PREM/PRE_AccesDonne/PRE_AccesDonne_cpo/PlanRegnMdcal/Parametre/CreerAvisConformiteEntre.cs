using System;
using System.Data;
using RAMQ.Attribut;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{

    /// <summary> 
    ///  Classe de paramètres d'entrées pour le service du noyau « Créer un avis de conformité ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau<br/>
    ///  Date   : Septembre 2016
    /// </remarks>
    public class CreerAvisConformiteEntre
    {

        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNumeroSequentielDisp", Direction = ParameterDirection.Input)]
        public long NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Code de région socio-sanitaire
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrCodeRegion", Direction = ParameterDirection.Input)]
        public string CodeRegion { get; set; }

        /// <summary>
        /// Date de début de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDateDebutEngagement", Direction = ParameterDirection.Input)]
        public DateTime DateDebutEngagement { get; set; }

        /// <summary>
        /// Date de fin de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDateFinEngagement", Direction = ParameterDirection.Input)]
        public DateTime? DateFinEngagement { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui a créé l'occurence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrIdentifiantCreation", Direction = ParameterDirection.Input)]
        public string IdentifiantCreation { get; set; }

        /// <summary>
        /// CType de lieu géographique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrTypeLieuGeographique", Direction = ParameterDirection.Input)]
        public string TypeLieuGeographique { get; set; }

        /// <summary>
        /// Code du lieu géographique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrCodeLieuGeographique", Direction = ParameterDirection.Input)]
        public string CodeLieuGeographique { get; set; }

        /// <summary>
        /// Numéro séquentiel de regroupement administratif des lieux géographiques
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqRegrAdmnLgeo", Direction = ParameterDirection.Input)]
        public long? NumeroSequentielRegroupement { get; set; }

        /// <summary>
        /// Statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrStatutEngagement", Direction = ParameterDirection.Input)]
        public string StatutEngagement { get; set; }

        /// <summary>
        /// Indicateur de statut de l'engagement en attente
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrIndStatutEngagAttente", Direction = ParameterDirection.Input)]
        public string IndicateurStatutEngagementAttente { get; set; }

        /// <summary>
        /// Code de raison du statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrCodeRaisonStatutEngag", Direction = ParameterDirection.Input)]
        public string CodeRaisonStatutEngagement { get; set; }

    }
}