using System;

namespace RAMQ.PRE.PRE_Entites_cpo.DemandeReevaluation.Parametre
{
    /// <summary> 
    /// Paramètre d'entrée pour la modification des demandes de réévaluation
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Mars 2018
    /// </remarks>
    public class ModifierDemandeReevaluationEntre
    {

        /// <summary>
        /// Numéro séquentiel de l'engagement de pratique
        /// </summary>
        /// <remarks></remarks>
        public long NumeroSequentielDemande { get; set; }

        /// <summary>
        /// Date de début de réévaluation
        /// </summary>
        /// <remarks></remarks>
        public DateTime DateDebutReeva { get; set; }

        /// <summary>
        /// Date de fin de réévaluation
        /// </summary>
        /// <remarks></remarks>
        public DateTime DateFinReeva { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui met à jour la demande
        /// </summary>
        /// <remarks></remarks>
        public string IdentifiantMAJ { get; set; }

    }
}