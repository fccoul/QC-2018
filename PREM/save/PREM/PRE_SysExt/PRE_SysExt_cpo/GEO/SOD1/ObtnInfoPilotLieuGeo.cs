using RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Parametre;
using RAMQ.PRE.PRE_OutilComun_cpo;

namespace RAMQ.PRE.PRE_SysExt_cpo.GEO.SOD1
{

    /// <summary> 
    ///  Encapsulation des appels à SOD1
    /// </summary>
    public class ObtnInfoPilotLieuGeo : IObtnInfoPilotLieuGeo
    {


        /// <summary>
        /// Permet d'obtenir les regroupements et lieux géographique RSS
        /// </summary>
        /// <param name="intrant">Entité contenant les paramètre de recherche</param>
        /// <returns>Liste des informations des territoire</returns>
        /// <remarks></remarks>
        public ObtenirRegroupementsLgeoRssSorti ObtenirRegroupementsLieuxGeographiquesRSS(ObtenirRegroupementsLgeoRssEntre intrant)
        {
            svcObtnInfoPilotLieuGeo.ObtnListeRegrLgeoRattaRssSorti extrantSOD1 = null;
            svcObtnInfoPilotLieuGeo.ObtnListeRegrLgeoRattaRssEntre intrantSOD1 = null;
            ObtenirRegroupementsLgeoRssSorti extrant = null;

            intrantSOD1 = Utilitaire.Mappeur.Mapper(intrant);

            extrantSOD1 = UtilitaireService.AppelerService<svcObtnInfoPilotLieuGeo.IServObtnInfoPilotLieuGeo,
                                                           svcObtnInfoPilotLieuGeo.ServObtnInfoPilotLieuGeoClient,
                                                           svcObtnInfoPilotLieuGeo.ObtnListeRegrLgeoRattaRssSorti>
                                                           (x => x.ObtenirListeRegrLgeoRattaRss(intrantSOD1));

            extrant = Utilitaire.Mappeur.Mapper(extrantSOD1);

            return extrant;

        }
    }
}
