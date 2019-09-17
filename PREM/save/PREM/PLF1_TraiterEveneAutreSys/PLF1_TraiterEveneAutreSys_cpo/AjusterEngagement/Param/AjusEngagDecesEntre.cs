using RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.AjusterEngagement.Entite;

namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.AjusterEngagement.Param
{
    /// <summary>
    ///  Paramètres d'entrée de la méthode AjusterEngageDeces
    /// </summary>
    public class AjusEngagDecesEntre
    {
        /// <summary>
        ///  Informations originale de l'individu
        /// </summary>
        public Individu InfoOrignIndiv { get; set; }

        /// <summary>
        ///  Informations modifiées de l'individu
        /// </summary>
        public Individu InfoModifIndiv { get; set; }
    }

    #region BizTalk
    public class AjusEngagDecesEntreBizTalk
    {
        /// <summary>
        ///  Informations originale de l'individu
        /// </summary>
        public IndividuBizTalk InfoOrignIndiv { get; set; }

        /// <summary>
        ///  Informations modifiées de l'individu
        /// </summary>
        public IndividuBizTalk InfoModifIndiv { get; set; }
    }
    #endregion
}