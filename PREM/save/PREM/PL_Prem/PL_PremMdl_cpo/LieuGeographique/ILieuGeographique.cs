using RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Parametre;

namespace RAMQ.PRE.PL_PremMdl_cpo.LieuGeographique
{
    /// <summary> 
    ///  Interface permettant d'obtenir les regroupements de lieux géographiques
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Septembre 2016
    /// </remarks>
    public interface ILieuGeographique
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        ObtenirRegroupementsLgeoRssSorti ObtenirRegroupementsLieuxGeographiquesRSS(ObtenirRegroupementsLgeoRssEntre intrant);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        ObtenirInformationTerritoireCLSCSortie ObtenirInformationTerritoireCLSC(ObtenirInformationTerritoireCLSCEntre intrant);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        ObtenirInformationTerritoireRLSSorti ObtenirLesNomsTerritoireRLS(ObtenirInformationTerritoireRLSEntre intrant);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        ObtenirNomTerritoireSorti ObtenirNomTerritoire(ObtenirNomTerritoireEntre intrant);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        ObtenirTerritoiresPermisSorti ObtenirTerritoiresPermis(ObtenirTerritoiresPermisEntre intrant);
    }
}