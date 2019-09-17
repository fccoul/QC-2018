using System;
using RAMQ.Attribut;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite
{
    /// <summary>
    /// AbsenceAvis
    /// </summary>
    /// <remarks>
    /// Auteur : Florent Pollart
    /// </remarks>
	public class AbsenceAvis
    {
        /// <summary>
        /// Numéro de séquence du dispensateur
        /// </summary>
        /// <returns></returns>
        [ValeurEntite(ElementName = "numNoSeqDisp")]
        public long NumeroSequenceDispensateur { get; set; }

        /// <summary>
        /// Numéro séquentiel de l'avis
        /// </summary>
        [ValeurEntite(ElementName = "numNoSeqEngagPrati")]
        public long? NumeroSequentielAvis { get; set; }

        /// <summary>
        /// Numéro séquentiel de la dérogation
        /// </summary>
        [ValeurEntite(ElementName = "numNoSeqDerog")]
        public long? NumeroSequentielDerogation { get; set; }

        /// <summary>
        /// Numéro séquentiel de l'autorisation
        /// </summary>
        [ValeurEntite(ElementName = "numNoSeqAutor")]
        public long? NumeroSequentielAutorisation { get; set; }

        /// <summary>
        /// Date de début
        /// </summary>
        [ValeurEntite(ElementName = "datDd")]
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Date de début
        /// </summary>
        [ValeurEntite(ElementName = "datDf")]
        public DateTime DateFin { get; set; }

        /// <summary>
        /// Statut de l'avis ou de la dérogation
        /// </summary>
        [ValeurEntite(ElementName = "vchrSta")]
        public string Statut { get; set; }

        /// <summary>
        /// Code de lieu de l'avis
        /// </summary>
        [ValeurEntite(ElementName = "vchrCodLgeo")]
        public string CodeLieuGeographique { get; set; }

        /// <summary>
        /// Type de lieu de l'avis
        /// </summary>
        [ValeurEntite(ElementName = "vchrTypLgeo")]
        public string TypeLieuGeographique { get; set; }

        /// <summary>
        /// Code de regroupement de l’avis
        /// </summary>
        [ValeurEntite(ElementName = "numNoSeqRegrAdmnLgeo")]
        public long? NumeroSeqRegrAdmnLgeo { get; set; }

        /// <summary>
        /// Code de région de l’avis 
        /// </summary>
        [ValeurEntite(ElementName = "vchrCodRss")]
        public string CodeRss { get; set; }

        /// <summary>
        /// Type de dérogation 
        /// </summary>
        [ValeurEntite(ElementName = "vchrTypDerog")]
        public string TypeDerogation { get; set; }
    }
}