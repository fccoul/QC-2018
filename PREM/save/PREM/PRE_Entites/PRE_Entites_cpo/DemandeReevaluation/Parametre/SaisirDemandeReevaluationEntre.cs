using System;

namespace RAMQ.PRE.PRE_Entites_cpo.DemandeReevaluation.Parametre
{
    /// <summary> 
    /// Paramètre d'entrée pour saisir des demandes de réévaluation
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Mars 2018
    /// </remarks>
    public class SaisirDemandeReevaluationEntre
    {

        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        public long? NumeroSequentielDispensateur { get; set; }


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

        /// <summary>
        /// Source de l'appelant
        /// </summary>
        /// <remarks></remarks>
        public int? CodeSource { get; set; }

        /// <summary>
        /// Catégorie de réévaluation
        /// </summary>
        /// <remarks></remarks>
        public int? CodeCategorieReeva { get; set; }

    }
}