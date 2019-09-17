using System;

namespace RAMQ.PRE.PRE_Entites_cpo.DemandeReevaluation.Parametre
{
    /// <summary> 
    /// Paramètre d'entrée pour la création des demandes de réévaluation
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Mars 2018
    /// </remarks>
    public class CreerDemandeReevaluationEntre
    {

        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        public long? NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Catégorie de la demande
        /// </summary>
        /// <remarks></remarks>
        public long? CategorieDemande { get; set; }

        /// <summary>
        /// Code source de la demande
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
        /// Identifiant de l'utilisateur qui crée la demande
        /// </summary>
        /// <remarks></remarks>
        public string IdentifiantOcc { get; set; }

    }
}