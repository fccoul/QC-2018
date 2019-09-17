using System;
using RAMQ.Attribut;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite
{
    /// <summary> 
    ///  Pratique
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : Février 2017
    /// </remarks>
	public class PratiqueTerritoire
    {

        /// <summary>
        ///  Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "NO_SEQ_DISP")]
        public long NoSequentielDisp { get; set; }

        /// <summary>
        /// Nombre de jours PREM/DPNAG
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "NbJoursPremDpnag")]
        public decimal NbJoursPremDpnag { get; set; }

        /// <summary>
        /// Nombre de jours PREM
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "NbJoursPrem")]
        public decimal NbJoursPrem { get; set; }

        /// <summary>
        /// Nombre de jours DPNAG
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "NbJoursDpnag")]
        public decimal NbJoursDpnag { get; set; }

        /// <summary>
        /// Nombre de jours IVN
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "NbJoursIvn")]
        public decimal NbJoursIvn { get; set; }

        /// <summary>
        /// Le code de région socio-sanitaire
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "COD_RSS")]
        public string CodeRSS { get; set; }

        /// <summary>
        /// Numéro séquentiel de regroupement administratif d'un lieu géographique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "NO_SEQ_REGR_ADMN_LGEO")]
        public long? NumeroSeqRegrAdmnLGEO { get; set; }

        /// <summary>
        /// Type du lieu géographique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "TYP_LGEO")]
        public string TypeLieuGeographique { get; set; }

        /// <summary>
        /// Code du lieu géographique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "COD_LGEO")]
        public string CodeLieuGeographique { get; set; }

        /// <summary>
        /// Date de service
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "DAT_SERV")]
        public DateTime DateService { get; set; }
    }
}