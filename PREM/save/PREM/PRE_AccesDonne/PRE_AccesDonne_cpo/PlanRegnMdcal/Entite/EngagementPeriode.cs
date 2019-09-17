using System;
using RAMQ.Attribut;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite
{
    /// <summary> 
    ///  Période d'engagement
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Aout 2017
    /// </remarks>
	public class EngagementPeriode
    {
        /// <summary>
        /// Type de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "TYPE")]
        public string Type { get; set; }

        /// <summary>
        /// Numéro de séquence du dispensateur
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "NO_SEQ_DISP")]
        public long NumeroSequenceDisp { get; set; }

        /// <summary>
        /// Date de fin de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "DD_ENGAG_PRATI")]
        public DateTime? DateDebutEngagement { get; set; }

        /// <summary>
        /// Date de début de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "DF_ENGAG_PRATI")]
        public DateTime? DateFinEngagement { get; set; }

        /// <summary>
        /// Date de début de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "NO_SEQ_ENGAG_PRATI")]
        public long? NoSeqEngaPrati { get; set; }

        /// <summary>
        /// Date de début de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "NO_SEQ_DEROG_PRATI_PROF")]
        public long? NoSeqDerogPrati { get; set; }

    }
}