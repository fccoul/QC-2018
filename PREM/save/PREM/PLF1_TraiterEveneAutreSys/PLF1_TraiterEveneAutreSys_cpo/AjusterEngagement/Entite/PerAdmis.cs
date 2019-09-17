using System;

namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.AjusterEngagement.Entite
{
    /// <summary>
    ///  Période d'admisibilité
    /// </summary>
    public class PerAdmis
    {
        /// <summary>
        ///  Statut de la période d'admisibilité
        /// </summary>
        public string Statut { get; set; }

        /// <summary>
        ///  Date de début de la période
        /// </summary>
        public DateTime Dd { get; set; }

        /// <summary>
        ///  Date de fin de la période
        /// </summary>
        public DateTime? Df { get; set; }

        /// <summary>
        ///  Code de raison de non admisibilité
        /// </summary>
        public string CodRaisNonAdmis { get; set; }
    }

    #region BizTalk
    /// <summary>
    ///  Période d'admisibilité
    /// </summary>
    public class PerAdmisBizTalk
    {
        /// <summary>
        ///  Statut de la période d'admisibilité
        /// </summary>
        public string Statut { get; set; }

        /// <summary>
        ///  Date de début de la période
        /// </summary>
        public string Dd { get; set; }

        /// <summary>
        ///  Date de fin de la période
        /// </summary>
        public string Df { get; set; }

        /// <summary>
        ///  Code de raison de non admisibilité
        /// </summary>
        public string CodRaisNonAdmis { get; set; }
    }

    #endregion
}