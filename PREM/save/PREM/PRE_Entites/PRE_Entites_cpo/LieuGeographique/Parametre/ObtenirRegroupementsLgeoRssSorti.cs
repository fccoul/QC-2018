using System.Collections.Generic;
using RAMQ.ClasseBase;

namespace RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Parametre
{

    /// <summary> 
    /// Paramètres de sorties de la méthode ObtenirListeRegrLgeoRattaRss
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : 2016-09-09
    /// </remarks>
    public class ObtenirRegroupementsLgeoRssSorti : ParamSorti
    {

        /// <summary>
        /// Constructeur
        /// </summary>
        public ObtenirRegroupementsLgeoRssSorti()
        {
            Regroupements = new List<Entite.Regroupement>();
            LieuxGeographiques = new List<Entite.LieuGeographique>();
        }

        #region Propriétés publiques

        /// <summary>
        /// Liste des regroupements obtenus 
        /// </summary>
        /// <remarks></remarks>
        public List<Entite.Regroupement> Regroupements { get; set; }

        /// <summary>
        /// Liste des lieux géographiques rattachés aux regroupements retournés:
        /// </summary>
        /// <remarks></remarks>
        public List<Entite.LieuGeographique> LieuxGeographiques { get; set; }

        #endregion

    }

}