using RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.AjusterEngagement.Entite;
using System;

namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.AjusterEngagement.Param
{
    /// <summary>
    ///  Paramètres d'entrée de la méthode AjusterEngagAjouNonPartn
    /// </summary>
    public class AjusEngagAjouNonPartnEntre
    {
        /// <summary>
        ///  Nouvelle période d'admisibilité
        /// </summary>
        public PerAdmis NouvPerAdmis { get; set; }

        /// <summary>
        ///  Numéro séquentiel de la période d'admisibilité.
        /// </summary>
        public long NoSeqPerAdmis { get; set; }

        /// <summary>
        ///  Type d'intervenant
        /// </summary>
        public string TypeIntervenant { get; set; }

        /// <summary>
        ///  Numéro séquentiel de l'intervenant
        /// </summary>
        public long NoSeqIntervenant { get; set; }

        /// <summary>
        ///  Date de modification
        /// </summary>
        public DateTime DmAdmis { get; set; }
    }

    #region Biztalk
    /// <summary>
    ///  Paramètres d'entrée de la méthode AjusterEngagAjouNonPartn
    /// </summary>
    public class AjusEngagAjouNonPartnEntreBizTalk
    {
        /// <summary>
        ///  Nouvelle période d'admisibilité
        /// </summary>
        public PerAdmisBizTalk NouvPerAdmis { get; set; }

        /// <summary>
        ///  Numéro séquentiel de la période d'admisibilité.
        /// </summary>
        public string NoSeqPerAdmis { get; set; }

        /// <summary>
        ///  Type d'intervenant
        /// </summary>
        public string TypeIntervenant { get; set; }

        /// <summary>
        ///  Numéro séquentiel de l'intervenant
        /// </summary>
        public string NoSeqIntervenant { get; set; }

        /// <summary>
        ///  Date de modification
        /// </summary>
        public string DmAdmis { get; set; }
    }
    #endregion
}