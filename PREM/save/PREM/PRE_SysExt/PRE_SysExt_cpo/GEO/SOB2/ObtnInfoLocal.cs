using RAMQ.PRE.PRE_OutilComun_cpo;
using RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Parametre;

namespace RAMQ.PRE.PRE_SysExt_cpo.GEO.SOB2
{

    /// <summary> 
    ///  Encapsulation des appels à SOB2
    /// </summary>
    public class ObtnInfoLocal : IObtnInfoLocal
    {
        /// <summary>
        /// Permet d'obtenir les informations des territoire CLSC
        /// </summary>
        /// <param name="intrant">Entité contenant les paramètre de recherche</param>
        /// <returns>Liste de nom des territoire</returns>
        /// <remarks></remarks>
        public ObtenirInformationTerritoireCLSCSortie ObtenirLesNomsTerritoireCLSC(ObtenirInformationTerritoireCLSCEntre intrant)
        {
            svcObtnInfoLocal.SortieObtnInfoTerriCLSC extrantSOB2 = null;
            svcObtnInfoLocal.EntreObtnInfoTerriCLSC intrantSOB2 = null;
            ObtenirInformationTerritoireCLSCSortie extrant = null;

            intrantSOB2 = Utilitaire.Mappeur.Mapper(intrant);

            extrantSOB2 = UtilitaireService.AppelerService<svcObtnInfoLocal.IServObtnInfoLocal,
                                                           svcObtnInfoLocal.ServObtnInfoLocalClient,
                                                           svcObtnInfoLocal.SortieObtnInfoTerriCLSC>
                                                           (x => x.ObtenirInfoTerriCLSC(intrantSOB2));

            extrant = Utilitaire.Mappeur.Mapper(extrantSOB2);

            return extrant;
        }

        /// <summary>
        /// Permet d'obtenir les informations des territoire RLS
        /// </summary>
        /// <param name="intrant">Entité contenant les paramètre de recherche</param>
        /// <returns>Liste de nom des territoire</returns>
        /// <remarks></remarks>
        public ObtenirInformationTerritoireRLSSorti ObtenirLesNomsTerritoireRLS(ObtenirInformationTerritoireRLSEntre intrant)
        {
            svcObtnInfoLocal.SortieObtnInfoTerriRLS extrantSOB2 = null;
            svcObtnInfoLocal.EntreObtnInfoTerriRLS intrantSOB2 = null;
            ObtenirInformationTerritoireRLSSorti extrant = null;

            intrantSOB2 = Utilitaire.Mappeur.Mapper(intrant);

            extrantSOB2 = UtilitaireService.AppelerService<svcObtnInfoLocal.IServObtnInfoLocal,
                                                           svcObtnInfoLocal.ServObtnInfoLocalClient,
                                                           svcObtnInfoLocal.SortieObtnInfoTerriRLS>
                                                           (x => x.ObtenirInfoTerriRLS(intrantSOB2));

            extrant = Utilitaire.Mappeur.Mapper(extrantSOB2);

            return extrant;
        }
    }
}

