using System;

namespace RAMQ.PRE.PRE_Entites_cpo.DemandeReevaluation.Entite
{
    /// <summary> 
    /// Entite des demandes de réévaluation
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Mars 2018
    /// </remarks>
    public class DemandeReevaluation
    {

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public DemandeReevaluation()
        {
        }

        #endregion

        #region Propriétés publiques

        /// <summary>
        /// Numéro séquentiel de l'engagement de pratique
        /// </summary>
        /// <remarks></remarks>
        public long? NumeroSequentielDemande { get; set; }

        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        public long? NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Catégorie de la demande de réévaluation
        /// </summary>
        /// <remarks></remarks>
        public long? CategorieDemande { get; set; }

        /// <summary>
        /// Code source de la demande de réévaluation
        /// </summary>
        /// <remarks></remarks>
        public long? CodeSourceDemande { get; set; }

        /// <summary>
        /// Date de début de réévaluation
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateDebutReeva { get; set; }

        /// <summary>
        /// Date de fin de réévaluation
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateFinReeva { get; set; }

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
        /// Date et heure de l'inactivation de l'occurence
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateHeureInact { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui a inactivé l'occurence
        /// </summary>
        /// <remarks></remarks>
        public string IdentifiantInact { get; set; }

        #endregion

    }
}