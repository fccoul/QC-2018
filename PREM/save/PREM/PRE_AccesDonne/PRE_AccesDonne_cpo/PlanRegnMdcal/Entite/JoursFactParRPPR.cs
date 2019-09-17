using RAMQ.Attribut;
using System;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite
{
    /// <summary>
    /// JoursFactParRPPR
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Juillet 2017
    /// </remarks>
	public class JoursFactParRPPR
    {
        /// <summary>
        /// Numero de sequence de dispensateur
        /// </summary>
        [ValeurEntite(ElementName = "NO_SEQ_DISP")]
        public long NoSeqDispensateur { get; set; }

        /// <summary>
        /// Date de service
        /// </summary>
        [ValeurEntite(ElementName = "DAT_SERV")]
        public DateTime? DateServ { get; set; }

        /// <summary>
        /// CodeRSS
        /// </summary>
        [ValeurEntite(ElementName = "COD_RSS")]
        public string CodeRSS { get; set; }

        /// <summary>
        /// Type de lieu
        /// </summary>
        [ValeurEntite(ElementName = "TYP_LGEO")]
        public string TypLGEO { get; set; }

        /// <summary>
        /// Code de lieu
        /// </summary>
        [ValeurEntite(ElementName = "COD_LGEO")]
        public string CodeLGEO { get; set; }

        /// <summary>
        /// Numéro de séquence de regroupement administratif
        /// </summary>
        [ValeurEntite(ElementName = "NO_SEQ_REGR_ADMN_LGEO")]
        public long? NoSeqRegrAdmnLgeo { get; set; }

        /// <summary>
        /// Jours
        /// </summary>
        [ValeurEntite(ElementName = "JR")]
        public double Jours { get; set; }

        /// <summary>
        /// Type de service en repartition de pratique
        /// </summary>
        [ValeurEntite(ElementName = "TYP_SERV_REPTN_PRATI")]
        public string TypeMontant { get; set; }

    }
}