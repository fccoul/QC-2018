using RAMQ.Attribut;
using System;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Juillet 2017
    /// </remarks>
	public class JoursFactParRSS
    {

        /// <summary>
        /// 
        /// </summary>
        [ValeurEntite(ElementName = "NO_SEQ_DISP")]
        public long NumeroSeqDispensateur { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ValeurEntite(ElementName = "DAT_SERV")]
        public DateTime? DateService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ValeurEntite(ElementName = "COD_RSS")]
        public string CodeRss { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ValeurEntite(ElementName = "JR")]
        public double Jours { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ValeurEntite(ElementName = "TYP_SERV_REPTN_PRATI")]
        public string TypeMontant { get; set; }

    }
}