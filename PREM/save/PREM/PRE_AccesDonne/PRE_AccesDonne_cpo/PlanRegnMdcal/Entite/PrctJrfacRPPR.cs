using RAMQ.Attribut;
using System;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite
{

    /// <summary> 
    ///  Ligne du rapport Obtenir Liste pourcentage jrfac RPPR
    /// </summary>
    /// <remarks>
    ///  Auteur : Mathys Leleu <br/>
    ///  Date   : Décembre 2017
    /// </remarks>
    public class PrctJrfacRPPR
    {

        /// <summary>
        /// Année PREM
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "an_per_premq")]
        public int Periode { get; set; }

        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "dis_no_seq")]
        public long NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Numéro de pratique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "No_PRATI")]
        public string NumeroPratique { get; set; }

        /// <summary>
        /// Numéro de pratique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "nom_md")]
        public string NomMedecin { get; set; }

        /// <summary>
        /// Code RSS
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "cod_rss")]
        public string CodeRSS { get; set; }

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
        /// Jours facturés en RPPR
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "NBR_JR_FACT")]
        public double JoursFacturesRPPR { get; set; }

        /// <summary>
        /// Jours facturés dans l'avis
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "NBR_TOT_JR_FACT")]
        public double JoursFacturesTotal { get; set; }

        /// <summary>
        /// Pourcentage de jours facturés en RPPR
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "PRC_FACT_EFFEC")]
        public double PourcentageEffectue { get; set; }
    }
}