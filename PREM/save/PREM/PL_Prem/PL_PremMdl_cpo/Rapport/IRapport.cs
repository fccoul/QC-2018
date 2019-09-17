using RAMQ.PRE.PRE_Entites_cpo.Rapport.Entite;
using RAMQ.PRE.PRE_Entites_cpo.Rapport.Parametre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PL_PremMdl_cpo.Rapport
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
    public interface IRapport
    {
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="intrant"></param>
        ///// <returns></returns>
        //ParamObtnRapportWebSorti<LigneRapportAbsncAvisConf> ObtenirRapportAbsncAvisConfWeb(ParamObtnrRappAbsncAvisConf intrant);

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="intrant"></param>
        ///// <param name="enumTypeFichier"></param>
        ///// <returns></returns>
        //ParamObtnRapportFichierSorti ObtenirRapportAbsncAvisConfFichier(ParamObtnrRappAbsncAvisConf intrant, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport enumTypeFichier);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="intrant"></param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //ParamObtnRapportWebSorti<LigneRapportAvisConfActifsParTerritoire> ObtenirRapportAvisConfActifsParTerritoireWeb(ParamObtnrRappAvisConfActifsParTerritoire intrant);

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="intrant"></param>
        ///// <param name="enumTypeFichier"></param>
        ///// <returns></returns>
        //ParamObtnRapportFichierSorti ObtenirRapportAvisConfActifsParTerritoireFichier(ParamObtnrRappAvisConfActifsParTerritoire intrant, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport enumTypeFichier);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="intrant"></param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //ParamObtnRapportWebSorti<LigneRapportAvisConfTermines> ObtenirRapportAvisConfTerminesWeb(ParamObtnrRappAvisConfTermines intrant);

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="intrant"></param>
        ///// <param name="enumTypeFichier"></param>
        ///// <returns></returns>
        //ParamObtnRapportFichierSorti ObtenirRapportAvisConfTerminesFichier(ParamObtnrRappAvisConfTermines intrant, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport enumTypeFichier);

        /// <summary>
        ///
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        ParamObtnRapportWebSorti<LigneRapportDerogPratiExclu> ObtenirRapportDerogPratiExcluWeb(ParamObtnrRappDerogPratiExclu intrant);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <param name="enumTypeFichier"></param>
        /// <returns></returns>
        ParamObtnRapportFichierSorti ObtenirRapportDerogPratiExcluFichier(ParamObtnrRappDerogPratiExclu intrant, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport enumTypeFichier);

        /// <summary>
        ///
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        ParamObtnRapportWebSorti<LigneRapportNonRespAvisConf> ObtenirRapportNonRespAvisConfWeb(ParamObtnrRappNonRespAvisConf intrant);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <param name="enumTypeFichier"></param>
        /// <returns></returns>
        ParamObtnRapportFichierSorti ObtenirRapportNonRespAvisConfFichier(ParamObtnrRappNonRespAvisConf intrant, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport enumTypeFichier);

        /// <summary>
        ///
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        ParamObtnRapportWebSorti<LigneRapportExerNonAutoRPPR> ObtenirRapportExerNonAutoRPPRWeb(ParamObtnrRappExerNonAutoRPPR intrant);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <param name="enumTypeFichier"></param>
        /// <returns></returns>
        ParamObtnRapportFichierSorti ObtenirRapportExerNonAutoRPPRFichier(ParamObtnrRappExerNonAutoRPPR intrant, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport enumTypeFichier);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="intrant"></param>
        ///// <returns></returns>
        ///// <remarks></remarks>
        //ParamObtnRapportWebSorti<LigneRapportNouvMedSansAvisConf> ObtenirRapportNouvMedSansAvisConfWeb(ParamObtnrRappNouvMedSansAvisConf intrant);

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="intrant"></param>
        ///// <param name="enumTypeFichier"></param>
        ///// <returns></returns>
        //ParamObtnRapportFichierSorti ObtenirRapportNouvMedSansAvisConfFichier(ParamObtnrRappNouvMedSansAvisConf intrant, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport enumTypeFichier);

        /// <summary>
        ///
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        ParamObtnRapportWebSorti<LigneRapportRepartInterRegionPrati> ObtenirRapportRepartInterRegionPratiWeb(ParamObtnrRappRepartInterRegionPrati intrant);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <param name="enumTypeFichier"></param>
        /// <returns></returns>
        ParamObtnRapportFichierSorti ObtenirRapportRepartInterRegionPratiFichier(ParamObtnrRappRepartInterRegionPrati intrant, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport enumTypeFichier);
    }
}