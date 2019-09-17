using System;

namespace RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre
{
    /// <summary> 
    ///  Paramètres d'entrée pour la modification d'un statut de l'engagement.
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
        public long NumeroSequentielStatutEngagement { get; set; }

        /// <summary>
        /// Numéro séquentiel de l'engagement
        /// </summary>
        /// <remarks></remarks>
        public long NumeroSequentielEngagement { get; set; }

        /// <summary>
        /// Indicateur de statut de l'engagement en attente
        /// </summary>
        /// <remarks></remarks>
        public string IndicateurStatutEngagementEnAttente { get; set; }

        /// <summary>
        /// Date de fin du statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateFinStatutEngagement { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui a modifié l'occurence
        /// </summary>
        /// <remarks></remarks>
        public string IdentifiantMAJ { get; set; }

        /// <summary>
        /// Indicateur d'inactivation du statut
        /// </summary>
        /// <remarks></remarks>
        public string IndicateurInactivationStatut { get; set; }

    }
}