using System;

namespace RAMQ.PRE.PRE_Entites_cpo.DemandeReevaluation.Parametre
{
    /// <summary> 
    /// Paramètre d'entrée pour l'obtention des demandes de réévaluation
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Mars 2018
    /// </remarks>
    public class ObtenirDemandeReevaluationEntre
    {

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
        public DateTime? DateDebutRech { get; set; }

        /// <summary>
        /// Date de fin de réévaluation
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateFinRech { get; set; }

        /// <summary>
        /// Indicateur d'avis inactivé
        /// </summary>
        /// <remarks></remarks>
        public string IndicateurActive { get; set; }

    }
}