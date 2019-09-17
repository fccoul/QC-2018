
using RAMQ.ServiceModel.Erreur;
using System.ServiceModel;
using RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Parametre;

namespace RAMQ.PRE.PRE_SysExt_cpo.GEO.SOD1
{

    /// <summary> 
    ///  Interface d'encapsulation des appels à SOD1
    /// </summary>
    public interface IObtnInfoPilotLieuGeo
    {

        /// <summary>
        /// Permet d'obtenir les regroupements et lieux géographique RSS
        /// </summary>
        /// <param name="intrant">Entité contenant les paramètre de recherche</param>
        /// <returns>Liste des informations des territoire</returns>
        ObtenirRegroupementsLgeoRssSorti ObtenirRegroupementsLieuxGeographiquesRSS(ObtenirRegroupementsLgeoRssEntre intrant);
    }

}

