using System.Collections.Generic;
using RAMQ.ClasseBase;

namespace RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Parametre
{

    /// <summary> 
    /// Entité d'extrant pour l'obtention de l'information sur les territoire CLSC
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Octobre 2016
    /// </remarks>
    public class ObtenirInformationTerritoireCLSCSortie : ParamSorti
    {

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        public ObtenirInformationTerritoireCLSCSortie()
        {
            NomTerritoires = new List<string>();
        }
        
        #endregion

        #region Propriétés publiques

        /// <summary>
        /// Liste des territoires
        /// </summary>
        public List<string> NomTerritoires { get; set; }

        #endregion

    }
    
}