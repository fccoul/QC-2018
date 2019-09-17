using RAMQ.Attribut;
using System;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite
{

    /// <summary> 
    ///  Présence d'engagement
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Aout 2017
    /// </remarks>
    public class Engagement
    {
        /// <summary>
        /// Numéro séquentiel de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "no_seq_engag_prati")]
        public long NumeroSequentielEngagement { get; set; }

        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "no_seq_disp")]
        public long NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Code RSS
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "cod_rss")]
        public string CodeRSS { get; set; }

        /// <summary>
        /// Code de lieu géographique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "cod_lgeo")]
        public string CodeLgeo { get; set; }

        /// <summary>
        /// Type de lieu géographique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "typ_lgeo")]
        public string TypeLgeo { get; set; }

        /// <summary>
        /// Numéro de séquence de regroupement administratif de lieu géographique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "no_seq_regr_admn_lgeo")]
        public long? NumeroSequenceRegroupementAdministratifLGEO { get; set; }

        /// <summary>
        /// Statut d'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "sta_engag_terri")]
        public string Statut { get; set; }

        /// <summary>
        /// Date de début d'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "dd_engag_prati")]
        public DateTime? DateDebutEngagement { get; set; }

        /// <summary>
        /// Date de fin d'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "df_engag_prati")]
        public DateTime? DateFinEngagement { get; set; }

        /// <summary>
        /// Date de début de statut
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "dd_sta_engag_terri")]
        public DateTime? DateDebutStatut { get; set; }

        /// <summary>
        /// Date de fin de statut
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "df_sta_engag_terri")]
        public DateTime? DateFinStatut { get; set; }

    }
}