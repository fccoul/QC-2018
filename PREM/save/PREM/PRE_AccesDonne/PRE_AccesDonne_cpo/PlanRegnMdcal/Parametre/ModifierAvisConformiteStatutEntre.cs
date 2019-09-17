using System;
using System.Data;
using RAMQ.Attribut;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{

    /// <summary> 
    ///  Classe de paramètres d'entrées pour le service du noyau « Modifier un avis de conformité selon son statut ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau<br/>
    ///  Date   : Septembre 2016
    /// </remarks>
    public class ModifierAvisConformiteStatutEntre
    {

        /// <summary>
        /// Numéro séquentiel de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqEngagement", Direction = ParameterDirection.Input)]
        public long NumeroSequentielEngagement { get; set; }

        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqDisp", Direction = ParameterDirection.Input)]
        public long? NumeroSequentielDispensateur{ get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui a modifié l'occurence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrIdentifiantMAJ", Direction = ParameterDirection.Input)]
        public string IdentifiantMAJ { get; set; }

        /// <summary>
        /// Type de lieu géographique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrTypeLieuGeographique", Direction = ParameterDirection.Input)]
        public string TypeLieuGeographique { get; set; }

        /// <summary>
        /// Code de lieu géographique
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
        /// Indicateur d'inactivation d'occurrence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrIndInactivationOcc", Direction = ParameterDirection.Input)]
        public string IndicateurInactivationOccurence { get; set; }
    }
}