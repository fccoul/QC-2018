using RAMQ.ClasseBase;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_Entites_cpo.DemandeReevaluation.Parametre
{

    /// <summary> 
    /// Paramètre de sortie pour l'obtention des demandes de réévaluation
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Mars 2018
    /// </remarks>
    public class ObtenirDemandeReevaluationSorti : ParamSorti
    {

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirDemandeReevaluationSorti()
        {
            ListeDemandeReevaluation = new List<Entite.DemandeReevaluation>();
        }

        /// <summary>
        /// Liste des avis de conformité
        /// </summary>
        /// <remarks></remarks>
        public List<Entite.DemandeReevaluation> ListeDemandeReevaluation { get; set; }

    }

}