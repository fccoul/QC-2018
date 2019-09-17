using System;

namespace RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre
{
    /// <summary> 
    /// Paramètre d'entrée pour la modification d'une période d'un avis de conformité
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau<br/>
    ///  Date   : Novembre 2016
    /// </remarks>
    public class ModifierPeriodeAvisEntre
    {

        /// <summary>
        /// Numéro séquentiel de l'engagement
        /// </summary>
        /// <remarks></remarks>
        public long NumeroSequentielEngagement { get; set; }

        /// <summary>
        /// Date de début actuelle de l'avis de conformité
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateDebutActuelle { get; set; }

        /// <summary>
        /// Date de fin actuelle de l'avis de conformité
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateFinActuelle { get; set; }

        /// <summary>
        /// Nouvelle date de début de l'avis de conformité
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateDebutNouvelle { get; set; }

        /// <summary>
        /// Nouvelle date de fin de l'avis de conformité
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateFinNouvelle { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui a modifié l'occurence
        /// </summary>
        /// <remarks></remarks>
        public string IdentifiantMAJ { get; set; }

        /// <summary>
        /// Code de raison du statut de la dérogation
        /// </summary>
        /// <remarks></remarks>
        public string CodeRaisonStatut { get; set; }

    }
}