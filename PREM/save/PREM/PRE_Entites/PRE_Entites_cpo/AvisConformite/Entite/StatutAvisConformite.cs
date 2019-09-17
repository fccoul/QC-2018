using System;

namespace RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Entite
{

    /// <summary> 
    ///  Entité pour les statuts des avis de conformité
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Septembre 2016
    /// </remarks>
    public class StatutAvisConformite
    {

        /// <summary>
        /// Numéro séquentiel du statut de l'engagement de pratique
        /// </summary>
        /// <remarks></remarks>
        public long? NumeroSequentielStatutEngagement { get; set; }

        /// <summary>
        /// Numéro séquentiel de l'engagement de pratique
        /// </summary>
        /// <remarks></remarks>
        public long? NumeroSequentielEngagement { get; set; }

        /// <summary>
        /// Statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        public string StatutEngagement { get; set; }

        /// <summary>
        /// Indicateur du statut de l'engagement en attente
        /// </summary>
        /// <remarks></remarks>
        public string IndicateurStatutEngagementAttente { get; set; }

        /// <summary>
        /// Date et heure de l'occurence
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateHeureOccurence { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui a créé l'occurence
        /// </summary>
        /// <remarks></remarks>
        public string IdentifiantCreation { get; set; }

        /// <summary>
        /// Date de début du statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        public DateTime DateDebutStatutEngagement { get; set; }

        /// <summary>
        /// Code de raison du statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        public string CodeRaisonStatutEngagement { get; set; }

        /// <summary>
        /// Date de fin du statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateFinStatutEngagement { get; set; }

        /// <summary>
        /// Date et heure de la modification de l'occurence
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateHeureOccurenceMAJ { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui a modifié l'occurence
        /// </summary>
        /// <remarks></remarks>
        public string IdentifiantMAJ { get; set; }

        /// <summary>
        /// Date et heure de l'inactivité de l'occurence
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateHeureOccurenceInactive { get; set; }

    }
}