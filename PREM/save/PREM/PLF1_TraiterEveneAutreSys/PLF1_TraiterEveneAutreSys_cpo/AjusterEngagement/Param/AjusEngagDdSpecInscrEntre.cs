using RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.AjusterEngagement.Entite;

namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.AjusterEngagement.Param
{
    /// <summary>
    ///  Paramètres d'entrée de la méthode AjusterEngagDdSpecInscr.
    /// </summary>
    public class AjusEngagDdSpecInscrEntre
    {
        /// <summary>
        ///  Informations original du dispensateur
        /// </summary>
        public Dispensateur InfoDispOrign { get; set; }

        /// <summary>
        ///  Informations modifiées du dispensateur
        /// </summary>
        public Dispensateur InfoDispModif { get; set; }
    }

    #region BizTalk
    public class AjusEngagDdSpecInscrEntreBizTalk
    {
        /// <summary>
        ///  Informations original du dispensateur
        /// </summary>
        public DispensateurBizTalk InfoDispOrign { get; set; }

        /// <summary>
        ///  Informations modifiées du dispensateur
        /// </summary>
        public DispensateurBizTalk InfoDispModif { get; set; }
    }
    #endregion
}