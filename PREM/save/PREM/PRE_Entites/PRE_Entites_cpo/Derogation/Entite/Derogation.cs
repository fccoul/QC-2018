using System;

namespace RAMQ.PRE.PRE_Entites_cpo.Derogation.Entite
{

    /// <summary> 
    ///  Dérogation
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Octobre 2016
    /// </remarks>
    public class Derogation
    {

        /// <summary>
        /// Numéro séquentiel de la dérogation
        /// </summary>
        /// <remarks></remarks>
        public long NumeroSequentiel { get; set; }

        /// <summary>
        ///  Type de dérogation
        /// </summary>
        /// <remarks></remarks>
        public string Type { get; set; }

        /// <summary>
        /// Date de début de la dérogation
        /// </summary>
        /// <remarks></remarks>
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Date de renouvellement de la dérogation
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateRenouvellement { get; set; }

        /// <summary>
        /// Statut de la dérogation
        /// </summary>
        /// <remarks></remarks>
        public string Statut { get; set; }

        /// <summary>
        /// Code de raison du statut de la dérogation
        /// </summary>
        /// <remarks></remarks>
        public string CodeRaisonStatut { get; set; }

        /// <summary>
        /// Date de fin de la dérogation
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateFin { get; set; }

        /// <summary>
        /// Date et heure de création de l’occurrence
        /// </summary>
        /// <remarks></remarks>
        public DateTime DateHeureCreationOccurence { get; set; }

        /// <summary>
        /// Identifiant de l’utilisateur qui a créé l’occurrence
        /// </summary>
        /// <remarks></remarks>
        public string IdentifiantCreationOccurence { get; set; }

        /// <summary>
        /// Date et heure d’inactivation de l’occurrence
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateHeureInactivationOccurence { get; set; }

        /// <summary>
        /// Identifiant de l’utilisateur qui a inactivé l’occurrence
        /// </summary>
        /// <remarks></remarks>
        public string IdentifiantInactivationOccurence { get; set; }

    }

}