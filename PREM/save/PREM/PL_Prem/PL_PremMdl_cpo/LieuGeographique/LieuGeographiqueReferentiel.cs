using RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Parametre;
using RAMQ.PRE.PRE_OutilComun_cpo;

namespace RAMQ.PRE.PL_PremMdl_cpo.LieuGeographique
{
    /// <summary> 
    ///  Référentiel qui permet d'obtenir les regroupements de lieux géographiques
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Septembre 2016
    /// <br/>
    ///  Historique des modifications<br/>
    ///  ------------------------------------------------------------------------------<br/>
    ///  Auteur : [Auteur]<br/>
    ///  Date   : [aaaa-mm-jj]<br/>
    ///  Description:<br/>
    /// <br/>
    /// </remarks>
    public class LieuGeographiqueReferentiel : ILieuGeographique
    {

        /// <summary>
        /// Obtenir la liste des regroupements et des lieux géographiques     
        /// rattachés à un RSS ou à un regroupement administratif.
        /// </summary>
        /// <returns>Retourne la liste des regroupements</returns>
        /// <remarks></remarks>
        public ObtenirRegroupementsLgeoRssSorti ObtenirRegroupementsLieuxGeographiquesRSS(ObtenirRegroupementsLgeoRssEntre intrant)
        {

            return UtilitaireService.AppelerService<svcLieuxGeographiques.IServLieuxGeographiques, 
                                                    svcLieuxGeographiques.ServLieuxGeographiquesClient, 
                                                    ObtenirRegroupementsLgeoRssSorti>
                                                    (x => x.ObtenirRegroupementsLieuxGeographiquesRSS(intrant));
        }

        /// <summary>
        /// Permet d'obtenir les information d'un territoire CLCS
        /// </summary>
        /// <param name="intrant">Entité contenant les valeur de recherche du territoire CLSC</param>
        /// <returns>Territoire CLSC</returns>
        /// <remarks></remarks>
        public ObtenirInformationTerritoireCLSCSortie ObtenirInformationTerritoireCLSC(ObtenirInformationTerritoireCLSCEntre intrant)
        {

            return UtilitaireService.AppelerService<svcLieuxGeographiques.IServLieuxGeographiques, 
                                                    svcLieuxGeographiques.ServLieuxGeographiquesClient, 
                                                    ObtenirInformationTerritoireCLSCSortie>
                                                    (x => x.ObtenirLesNomsTerritoireCLSC(intrant));

        }

        /// <summary>
        /// Permet d'obtenir les informations des territoire RLS
        /// </summary>
        /// <param name="intrant">Entité contenant les paramètre de recherche</param>
        /// <returns>Liste de nom des territoire</returns>
        /// <remarks></remarks>
        public ObtenirInformationTerritoireRLSSorti ObtenirLesNomsTerritoireRLS(ObtenirInformationTerritoireRLSEntre intrant)
        {

            return UtilitaireService.AppelerService<svcLieuxGeographiques.IServLieuxGeographiques, 
                                                    svcLieuxGeographiques.ServLieuxGeographiquesClient, 
                                                    ObtenirInformationTerritoireRLSSorti>
                                                    (x => x.ObtenirLesNomsTerritoireRLS(intrant));
        }

        /// <summary>
        /// Fonction pour retourner le nom du territoire en paramètre
        /// </summary>
        /// <param name="intrant">information du territoire</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public ObtenirNomTerritoireSorti ObtenirNomTerritoire(ObtenirNomTerritoireEntre intrant)
        {

            return UtilitaireService.AppelerService<svcLieuxGeographiques.IServLieuxGeographiques, 
                                                    svcLieuxGeographiques.ServLieuxGeographiquesClient, 
                                                    ObtenirNomTerritoireSorti>
                                                    (x => x.ObtenirNomTerritoire(intrant));
        }


        /// <summary>
        /// Fonction pour retourner la liste des territoires permis
        /// </summary>
        /// <param name="intrant">date de début de pratique</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public ObtenirTerritoiresPermisSorti ObtenirTerritoiresPermis(ObtenirTerritoiresPermisEntre intrant)
        {

            return UtilitaireService.AppelerService<svcLieuxGeographiques.IServLieuxGeographiques, 
                                                    svcLieuxGeographiques.ServLieuxGeographiquesClient, 
                                                    ObtenirTerritoiresPermisSorti>
                                                    (x => x.ObtenirTerritoiresPermis(intrant));
        }
    }
}