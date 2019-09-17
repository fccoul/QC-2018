using System.Collections.Generic;
using RAMQ.ClasseBase;

namespace RAMQ.PRE.PRE_Entites_cpo.EngagementPratique.Parametre
{

    /// <summary> 
    ///  Paramètre de sortir de l'obtention des engagements de pratique
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : 2016-09-16
    /// </remarks>
    public class ObtenirEngagementPratiqueSorti : ParamSorti
    {

        #region Constructeurs

        /// <summary>
        /// Constructeur
        /// </summary>
        public ObtenirEngagementPratiqueSorti()
        {
            EngagementPratiques = new List<Entite.EngagementPratique>();
        }
        #endregion

        #region Propriétés publiques

        /// <summary>
        /// Liste d'engagement de pratiques
        /// </summary>
        public List<Entite.EngagementPratique> EngagementPratiques { get; set; }

        #endregion

    }

}