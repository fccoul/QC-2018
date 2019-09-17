using System.ServiceModel;
using RAMQ.ServiceModel.Erreur;
using RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Parametre;

namespace RAMQ.PRE.PRE_SysExt_cpo.GEO.SOB2
{

    /// <summary> 
    ///  Interface d'encapsulation des appels à SOB2
    /// </summary>
    public interface IObtnInfoLocal
    {

        /// <summary>
        /// Permet d'obtenir les informations des territoire CLSC
        /// </summary>
        /// <param name="intrant">Entité contenant les paramètre de recherche</param>
        /// <returns>Liste de nom des territoire</returns>
        ObtenirInformationTerritoireCLSCSortie ObtenirLesNomsTerritoireCLSC(ObtenirInformationTerritoireCLSCEntre intrant);

        /// <summary>
        /// Permet d'obtenir les informations des territoire RLS
        /// </summary>
        /// <param name="intrant">Entité contenant les paramètre de recherche</param>
        /// <returns>Liste de nom des territoire</returns>
        ObtenirInformationTerritoireRLSSorti ObtenirLesNomsTerritoireRLS(ObtenirInformationTerritoireRLSEntre intrant);

    }

}

