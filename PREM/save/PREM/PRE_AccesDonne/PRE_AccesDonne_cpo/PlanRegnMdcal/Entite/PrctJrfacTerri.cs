using RAMQ.Attribut;
using System;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite
{

    /// <summary> 
    ///  Ligne du rapport Obtenir Liste pourcentage jrfac dérogation
    /// </summary>
    /// <remarks>
    ///  Auteur : Mathys Leleu <br/>
    ///  Date   : Octobre 2017
    /// </remarks>
    public class PrctJrfacTerri
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
        /// Type de répartition (INTRA, INTER)
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "typ_reptn")]
        public string TypeRepartition { get; set; }
        
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
        /// Jours facturés dans l'avis
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "NBR_JR_FACT")]
        public double JoursFacturesTerri { get; set; }

        /// <summary>
        /// Jours facturés dans l'avis
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "NBR_TOT_JR_FACT")]
        public double JoursFacturesTerriTotal { get; set; }

        /// <summary>
        /// Pourcentage de jours facturés dans la dérogation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "PRC_FACT_EFFEC")]
        public double PourcentageEffectue { get; set; }
    }
}