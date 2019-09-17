using RAMQ.PRE.PRE_Entites_cpo.Rapport.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Rapport.Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAMQ.PRE.PRE_OutilComun_cpo;

namespace RAMQ.PRE.PL_PremMdl_cpo.Rapport
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class RapportReferentiel : IRapport
    {
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="intrant"></param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public ParamObtnRapportWebSorti<LigneRapportAbsncAvisConf> ObtenirRapportAbsncAvisConfWeb(ParamObtnrRappAbsncAvisConf intrant)
        //{
        //    return UtilitaireService.AppelerService<svcCnsulRapp.IServCnsulRappPremq,
        //                                            svcCnsulRapp.ServCnsulRappPremqClient,
        //                                            ParamObtnRapportWebSorti<LigneRapportAbsncAvisConf>>
        //                                            (x => x.ObtenirRapportAbsncAvisConfWeb(intrant));
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="intrant"></param>
        ///// <param name="enumTypeFichier"></param>
        ///// <returns></returns>
        //public ParamObtnRapportFichierSorti ObtenirRapportAbsncAvisConfFichier(ParamObtnrRappAbsncAvisConf intrant, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport enumTypeFichier)
        //{
        //    return UtilitaireService.AppelerService<svcCnsulRapp.IServCnsulRappPremq,
        //                                            svcCnsulRapp.ServCnsulRappPremqClient,
        //                                            ParamObtnRapportFichierSorti>
        //                                            (x => x.ObtenirRapportAbsncAvisConfFichier(intrant, enumTypeFichier));
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="intrant"></param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public ParamObtnRapportWebSorti<LigneRapportAvisConfActifsParTerritoire> ObtenirRapportAvisConfActifsParTerritoireWeb(ParamObtnrRappAvisConfActifsParTerritoire intrant)
        //{
        //    return UtilitaireService.AppelerService<svcCnsulRapp.IServCnsulRappPremq,
        //                                            svcCnsulRapp.ServCnsulRappPremqClient,
        //                                            ParamObtnRapportWebSorti<LigneRapportAvisConfActifsParTerritoire>>
        //                                            (x => x.ObtenirRapportAvisConfActifsParTerritoireWeb(intrant));
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="intrant"></param>
        ///// <param name="enumTypeFichier"></param>
        ///// <returns></returns>
        //public ParamObtnRapportFichierSorti ObtenirRapportAvisConfActifsParTerritoireFichier(ParamObtnrRappAvisConfActifsParTerritoire intrant, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport enumTypeFichier)
        //{
        //    return UtilitaireService.AppelerService<svcCnsulRapp.IServCnsulRappPremq,
        //                                            svcCnsulRapp.ServCnsulRappPremqClient,
        //                                            ParamObtnRapportFichierSorti>
        //                                            (x => x.ObtenirRapportAvisConfActifsParTerritoireFichier(intrant, enumTypeFichier));
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="intrant"></param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //public ParamObtnRapportWebSorti<LigneRapportAvisConfTermines> ObtenirRapportAvisConfTerminesWeb(ParamObtnrRappAvisConfTermines intrant)
        //{
        //    return UtilitaireService.AppelerService<svcCnsulRapp.IServCnsulRappPremq,
        //                                            svcCnsulRapp.ServCnsulRappPremqClient,
        //                                            ParamObtnRapportWebSorti<LigneRapportAvisConfTermines>>
        //                                            (x => x.ObtenirRapportAvisConfTerminesWeb(intrant));
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="intrant"></param>
        ///// <param name="enumTypeFichier"></param>
        ///// <returns></returns>
        //public ParamObtnRapportFichierSorti ObtenirRapportAvisConfTerminesFichier(ParamObtnrRappAvisConfTermines intrant, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport enumTypeFichier)
        //{
        //    return UtilitaireService.AppelerService<svcCnsulRapp.IServCnsulRappPremq,
        //                                            svcCnsulRapp.ServCnsulRappPremqClient,
        //                                            ParamObtnRapportFichierSorti>
        //                                            (x => x.ObtenirRapportAvisConfTerminesFichier(intrant, enumTypeFichier));
        //}

        /// <summary>
        ///
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public ParamObtnRapportWebSorti<LigneRapportDerogPratiExclu> ObtenirRapportDerogPratiExcluWeb(ParamObtnrRappDerogPratiExclu intrant)
        {
            return UtilitaireService.AppelerService<svcCnsulRapp.IServCnsulRappPremq,
                                                    svcCnsulRapp.ServCnsulRappPremqClient,
                                                    ParamObtnRapportWebSorti<LigneRapportDerogPratiExclu>>
                                                    (x => x.ObtenirRapportDerogPratiExcluWeb(intrant));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <param name="enumTypeFichier"></param>
        /// <returns></returns>
        public ParamObtnRapportFichierSorti ObtenirRapportDerogPratiExcluFichier(ParamObtnrRappDerogPratiExclu intrant, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport enumTypeFichier)
        {
            return UtilitaireService.AppelerService<svcCnsulRapp.IServCnsulRappPremq,
                                                    svcCnsulRapp.ServCnsulRappPremqClient,
                                                    ParamObtnRapportFichierSorti>
                                                    (x => x.ObtenirRapportDerogPratiExcluFichier(intrant, enumTypeFichier));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public ParamObtnRapportWebSorti<LigneRapportNonRespAvisConf> ObtenirRapportNonRespAvisConfWeb(ParamObtnrRappNonRespAvisConf intrant)
        {
            return UtilitaireService.AppelerService<svcCnsulRapp.IServCnsulRappPremq,
                                                    svcCnsulRapp.ServCnsulRappPremqClient,
                                                    ParamObtnRapportWebSorti<LigneRapportNonRespAvisConf>>
                                                    (x => x.ObtenirRapportNonRespAvisConfWeb(intrant));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <param name="enumTypeFichier"></param>
        /// <returns></returns>
        public ParamObtnRapportFichierSorti ObtenirRapportNonRespAvisConfFichier(ParamObtnrRappNonRespAvisConf intrant, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport enumTypeFichier)
        {
            return UtilitaireService.AppelerService<svcCnsulRapp.IServCnsulRappPremq,
                                                    svcCnsulRapp.ServCnsulRappPremqClient,
                                                    ParamObtnRapportFichierSorti>
                                                    (x => x.ObtenirRapportNonRespAvisConfFichier(intrant, enumTypeFichier));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public ParamObtnRapportWebSorti<LigneRapportExerNonAutoRPPR> ObtenirRapportExerNonAutoRPPRWeb(ParamObtnrRappExerNonAutoRPPR intrant)
        {
            return UtilitaireService.AppelerService<svcCnsulRapp.IServCnsulRappPremq,
                                                    svcCnsulRapp.ServCnsulRappPremqClient,
                                                    ParamObtnRapportWebSorti<LigneRapportExerNonAutoRPPR>>
                                                    (x => x.ObtenirRapportExerNonAutoRPPRWeb(intrant));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <param name="enumTypeFichier"></param>
        /// <returns></returns>
        public ParamObtnRapportFichierSorti ObtenirRapportExerNonAutoRPPRFichier(ParamObtnrRappExerNonAutoRPPR intrant, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport enumTypeFichier)
        {
            return UtilitaireService.AppelerService<svcCnsulRapp.IServCnsulRappPremq,
                                                    svcCnsulRapp.ServCnsulRappPremqClient,
                                                    ParamObtnRapportFichierSorti>
                                                    (x => x.ObtenirRapportExerNonAutoRPPRFichier(intrant, enumTypeFichier));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        //public ParamObtnRapportWebSorti<LigneRapportNouvMedSansAvisConf> ObtenirRapportNouvMedSansAvisConfWeb(ParamObtnrRappNouvMedSansAvisConf intrant)
        //{
        //    return UtilitaireService.AppelerService<svcCnsulRapp.IServCnsulRappPremq,
        //                                            svcCnsulRapp.ServCnsulRappPremqClient,
        //                                            ParamObtnRapportWebSorti<LigneRapportNouvMedSansAvisConf>>
        //                                            (x => x.ObtenirRapportNouvMedSansAvisConfWeb(intrant));
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="intrant"></param>
        ///// <param name="enumTypeFichier"></param>
        ///// <returns></returns>
        //public ParamObtnRapportFichierSorti ObtenirRapportNouvMedSansAvisConfFichier(ParamObtnrRappNouvMedSansAvisConf intrant, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport enumTypeFichier)
        //{
        //    return UtilitaireService.AppelerService<svcCnsulRapp.IServCnsulRappPremq,
        //                                            svcCnsulRapp.ServCnsulRappPremqClient,
        //                                            ParamObtnRapportFichierSorti>
        //                                            (x => x.ObtenirRapportNouvMedSansAvisConfFichier(intrant, enumTypeFichier));
        //}

        /// <summary>
        ///
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public ParamObtnRapportWebSorti<LigneRapportRepartInterRegionPrati> ObtenirRapportRepartInterRegionPratiWeb(ParamObtnrRappRepartInterRegionPrati intrant)
        {
            return UtilitaireService.AppelerService<svcCnsulRapp.IServCnsulRappPremq,
                                                    svcCnsulRapp.ServCnsulRappPremqClient,
                                                    ParamObtnRapportWebSorti<LigneRapportRepartInterRegionPrati>>
                                                    (x => x.ObtenirRapportRepartInterRegionPratiWeb(intrant));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <param name="enumTypeFichier"></param>
        /// <returns></returns>
        public ParamObtnRapportFichierSorti ObtenirRapportRepartInterRegionPratiFichier(ParamObtnrRappRepartInterRegionPrati intrant, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport enumTypeFichier)
        {
            return UtilitaireService.AppelerService<svcCnsulRapp.IServCnsulRappPremq,
                                                    svcCnsulRapp.ServCnsulRappPremqClient,
                                                    ParamObtnRapportFichierSorti>
                                                    (x => x.ObtenirRapportRepartInterRegionPratiFichier(intrant, enumTypeFichier));
        }
    }
}