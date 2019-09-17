using RAMQ.Attribut;
using System;
using System.Data;


namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary> 
    ///  Classe de paramètres d'entrée pour le service du noyau « Modifier un statut de l'engagement   ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart<br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    public class ModifierStatutEngagementEntre
    {

        /// <summary>
        /// Numéro séquentiel du statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqStatutEngagement", Direction = ParameterDirection.Input)]
        public long NumeroSequentielStatutEngagement { get; set; }

        /// <summary>
        /// Numéro séquentiel de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqEngagement", Direction = ParameterDirection.Input)]
        public long NumeroSequentielEngagement { get; set; }

        /// <summary>
        /// Indicateur de statut de l'engagement en attente
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrIndStatutEngagAttente", Direction = ParameterDirection.Input)]
        public string IndicateurStatutEngagementEnAttente { get; set; }

        /// <summary>
        /// Date de fin du statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDateFinStatutEngagement", Direction = ParameterDirection.Input)]
        public DateTime? DateFinStatutEngagement { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui a modifié l'occurence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrIdentifiantMAJ", Direction = ParameterDirection.Input)]
        public string IdentifiantMAJ { get; set; }

        /// <summary>
        /// Indicateur d'inactivation du statut
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrIndInactivationStatut", Direction = ParameterDirection.Input)]
        public string IndicateurInactivationStatut { get; set; }

    }
}