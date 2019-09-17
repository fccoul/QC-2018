using RAMQ.Attribut;
using System;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class JoursFactParAvis
    {
        /// <summary>
        /// No sequence du dispensateur
        /// </summary>
        [ValeurEntite(ElementName = "NO_SEQ_DISP")]
        public long NoSeqDispensateur { get; set; }

        /// <summary>
        /// Date de service
        /// </summary>
        [ValeurEntite(ElementName = "DAT_SERV")]
        public DateTime? DateService { get; set; }

        /// <summary>
        /// Code rss
        /// </summary>
        [ValeurEntite(ElementName = "COD_RSS")]
        public string CodeRss { get; set; }

        /// <summary>
        /// Type de lieu geographique
        /// </summary>
        [ValeurEntite(ElementName = "TYP_LGEO")]
        public string CodeTypeLieuGeo { get; set; }

        /// <summary>
        /// Code de lieu geographique
        /// </summary>
        [ValeurEntite(ElementName = "COD_LGEO")]
        public string CodeLieuGeo { get; set; }

        /// <summary>
        /// NUmero de sequence de regroupement administratif de lieu geographique
        /// </summary>
        [ValeurEntite(ElementName = "NO_SEQ_REGR_ADMN_LGEO")]
        public long? NumeroSeqRegroupementAdminLieuGeo { get; set; }

        /// <summary>
        /// Date de début d'engagement
        /// </summary>
        [ValeurEntite(ElementName = "DD_ENGAG_PRATI")]
        public DateTime? DateDebutEngagPrati { get; set; }

        /// <summary>
        /// Date de fin d'engagement
        /// </summary>
        [ValeurEntite(ElementName = "DF_ENGAG_PRATI")]
        public DateTime? DateFinEngagPrati { get; set; }

        /// <summary>
        /// Date de début de statut d'engagement
        /// </summary>
        [ValeurEntite(ElementName = "DD_STA_ENGAG_TERRI")]
        public DateTime? DateDebutStatut { get; set; }

        /// <summary>
        /// Date de fin de statut d'engagement
        /// </summary>
        [ValeurEntite(ElementName = "DF_STA_ENGAG_TERRI")]
        public DateTime? DateFinStatut { get; set; }

        /// <summary>
        /// Statut d'engagement
        /// </summary>
        [ValeurEntite(ElementName = "STA_ENGAG_TERRI")]
        public string StatutEngagPrati { get; set; }

        /// <summary>
        /// Nombre de jours
        /// </summary>
        [ValeurEntite(ElementName = "JR")]
        public decimal Jours { get; set; }

        /// <summary>
        /// Type de service de répartition de pratique
        /// </summary>
        [ValeurEntite(ElementName = "TYP_SERV_REPTN_PRATI")]
        public string TypeServiceRepartitionPratique { get; set; }

    }
}