using RAMQ.Attribut;
using System;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite
{

    /// <summary> 
    ///  Ligne du rapport Obtenir Liste pourcentage jrfac avis
    /// </summary>
    /// <remarks>
    ///  Auteur : Mathys Leleu <br/>
    ///  Date   : Octobre 2017
    /// </remarks>
    public class PrctJrfacAvis
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
        [ValeurEntite(ElementName = "no_prati")]
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
        /// Type de lieu géographique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "typ_terri")]
        public string TypeTerritoire { get; set; }


        /// <summary>
        /// Code de lieu géographique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "cod_terri")]
        public string CodeTerritoire { get; set; }

        /// <summary>
        /// Type de lieu géographique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "nom_terri")]
        public string NomTerritoire { get; set; }

        /// <summary>
        /// Numéro de séquence de regroupement administratif de lieu géographique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "no_seq_regr_admn_lgeo")]
        public long? NumeroSequenceRegroupementAdministratifLGEO { get; set; }

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
        /// Jours facturés dans l'avis
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "nbr_jr_fact_avis")]
        public double JoursFacturesAvis { get; set; }

        /// <summary>
        /// Jours facturés hors de l'avis
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "nbr_jr_fact_hors_avis")]
        public double JoursFacturesHorsAvis { get; set; }

        /// <summary>
        /// Jours facturés dans l'avis
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "nbr_tot_jr_fact")]
        public double JoursFacturesTotal { get; set; }

        /// <summary>
        /// Pourcentage de jours facturés dans l'avis
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "PRC_FACT_EFFEC")]
        public double PourcentageEffectue { get; set; }
    }
}