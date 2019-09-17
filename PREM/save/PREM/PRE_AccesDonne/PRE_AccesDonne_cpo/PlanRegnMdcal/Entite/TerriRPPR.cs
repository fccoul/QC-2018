using RAMQ.Attribut;
using System;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite
{
    /// <summary> 
    ///  Pratique
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Aout 2017
    /// </remarks>
	public class TerriRPPR
    {
        /// <summary>
        /// Code RSS
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "cod_rss")]
        public string CodRSS { get; set; }

        /// <summary>
        /// Code du lieu géographique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "cod_lgeo")]
        public string CodLGEO { get; set; }

        /// <summary>
        /// Type du lieu géographique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "typ_lgeo")]
        public string TypLGEO { get; set; }

        /// <summary>
        /// Type du lieu géographique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "no_seq_regr_admn_lgeo")]
        public long? NoSeqRegrAdmnLGEO { get; set; }

        /// <summary>
        /// Date début de la caractéristique de pratique dans un territoire PREM.
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "dd_terri_rppr")]
        public DateTime? DdTerriRPPR { get; set; }

        /// <summary>
        /// Date fin de la caractéristique de pratique dans un territoire PREM.
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "df_terri_rppr")]
        public DateTime? DfTerriRPPR { get; set; }

        /// <summary>
        /// Date et heure de création de l'occurrence.
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "dhc_occ")]
        public DateTime DhcOcc { get; set; }
    }
}