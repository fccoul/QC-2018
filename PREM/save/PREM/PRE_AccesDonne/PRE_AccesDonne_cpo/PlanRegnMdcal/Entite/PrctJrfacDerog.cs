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
    public class PrctJrfacDerog
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
        /// Type de pratique (IVN, DPN)
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "typ_prati")]
        public string TypePratique { get; set; }

        /// <summary>
        /// Date de début d'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "DD_DEROG")]
        public DateTime? DateDebutDerogation { get; set; }

        /// <summary>
        /// Date de fin d'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "DF_DEROG")]
        public DateTime? DateFinDerogation { get; set; }

        /// <summary>
        /// Jours facturés dans l'avis
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "NBR_JR_FACT_DEROG")]
        public double JoursFacturesDerog { get; set; }

        /// <summary>
        /// Jours facturés dans l'avis
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "NBR_TOT_JR_FACT_DEROG")]
        public double JoursFacturesDerogTotal { get; set; }

        /// <summary>
        /// Pourcentage de jours facturés dans la dérogation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "PRC_FACT_EFFEC")]
        public double PourcentageEffectue { get; set; }
    }
}