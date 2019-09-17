using RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.AjusterEngagement.Entite;
using System;

namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.AjusterEngagement.Param
{
    /// <summary>
    ///  Paramètres d'entrée de la méthode AjusterEngagModifNonPartn
    /// </summary>
    public class AjusEngagModifNonPartnEntre
    {
        /// <summary>
        ///  Période d'admisibilité original
        /// </summary>
        public PerAdmis PerAdmisOrign { get; set; }

        /// <summary>
        ///  Période d'admisibilité modifiée
        /// </summary>
        public PerAdmis PerAdmisModif { get; set; }

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

    #region BizTalk
    public class AjusEngagModifNonPartnEntreBiztalk
    {
        /// <summary>
        ///  Période d'admisibilité original
        /// </summary>
        public PerAdmisBizTalk PerAdmisOrign { get; set; }

        /// <summary>
        ///  Période d'admisibilité modifiée
        /// </summary>
        public PerAdmisBizTalk PerAdmisModif { get; set; }

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