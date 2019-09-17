using System.Collections.Generic;
using RAMQ.ClasseBase;

namespace RAMQ.PRE.PL_PremMdl_cpo.Autorisation.Parametres
{

    /// <summary> 
    ///  Paramètre de sortie pour obtenir les autorisations d'un professionnel de la santé
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Novembre 2016
    /// </remarks>
    public class ObtenirLesAutorisationsProfessionnelSorti : ParamSorti
    {

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirLesAutorisationsProfessionnelSorti()
        {
            Autorisations = new List<Entites.Autorisation>();
        }

        #endregion

        #region Propriétés publiques

        /// <summary>
        /// Liste d'autorisations
        /// </summary>
        /// <returns></returns>
        public List<Entites.Autorisation> Autorisations { get; set; }

        #endregion

    }
}