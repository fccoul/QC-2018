using System;

namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.AjusterEngagement.Entite
{
    /// <summary>
    ///  Individu
    /// </summary>
    public class Individu
    {
        /// <summary>
        ///  Numéro interne identifiant de façon unique un individu.
        /// </summary>
        public long NoSeq { get; set; }

        /// <summary>
        ///  Code identifiant dans quelle langue l'INDIVIDU désire recevoir toutes 
        ///  CORRESPONDANCES et communications.
        /// </summary>
        public string Langue { get; set; }

        /// <summary>
        ///  Code identifiant le titre à donner à l'INDIVIDU lors des CORRESPONDANCES et 
        ///  communications avec celle-ci.
        /// </summary>
        public string TitreCivilite { get; set; }

        /// <summary>
        ///  Code identifiant le sexe de l'INDIVIDU.
        /// </summary>
        public string Sexe { get; set; }

        /// <summary>
        ///  État ou statut civil de l'individu pour des besoins reliés à l'assurance.
        /// </summary>
        public string StatutCivil { get; set; }

        /// <summary>
        ///  Date à laquelle l'INDIVIDU est décédé.
        /// </summary>
        public DateTime? DateDeces { get; set; }

        /// <summary>
        ///  Identification de l'utilisateur qui a créé l'occurrence.
        /// </summary>
        public string IdUtilCreat { get; set; }

        /// <summary>
        ///  Date à laquelle l'occurrence est créée.
        /// </summary>
        public DateTime? Dc { get; set; }

        /// <summary>
        ///  Identification de l'utilisateur qui a fait la dernière modification sur 
        ///  l'occurrence.
        /// </summary>
        public string IdUtilMaj { get; set; }

        /// <summary>
        ///  Date de la dernière modification de l'occurrence.
        /// </summary>
        public DateTime? Dm { get; set;  }
    }

    #region BizTalk
    public class IndividuBizTalk
    {
        /// <summary>
        ///  Numéro interne identifiant de façon unique un individu.
        /// </summary>
        public string NoSeq { get; set; }

        /// <summary>
        ///  Code identifiant dans quelle langue l'INDIVIDU désire recevoir toutes 
        ///  CORRESPONDANCES et communications.
        /// </summary>
        public string Langue { get; set; }

        /// <summary>
        ///  Code identifiant le titre à donner à l'INDIVIDU lors des CORRESPONDANCES et 
        ///  communications avec celle-ci.
        /// </summary>
        public string TitreCivilite { get; set; }

        /// <summary>
        ///  Code identifiant le sexe de l'INDIVIDU.
        /// </summary>
        public string Sexe { get; set; }

        /// <summary>
        ///  État ou statut civil de l'individu pour des besoins reliés à l'assurance.
        /// </summary>
        public string StatutCivil { get; set; }

        /// <summary>
        ///  Date à laquelle l'INDIVIDU est décédé.
        /// </summary>
        public string DateDeces { get; set; }

        /// <summary>
        ///  Identification de l'utilisateur qui a créé l'occurrence.
        /// </summary>
        public string IdUtilCreat { get; set; }

        /// <summary>
        ///  Date à laquelle l'occurrence est créée.
        /// </summary>
        public string Dc { get; set; }

        /// <summary>
        ///  Identification de l'utilisateur qui a fait la dernière modification sur 
        ///  l'occurrence.
        /// </summary>
        public string IdUtilMaj { get; set; }

        /// <summary>
        ///  Date de la dernière modification de l'occurrence.
        /// </summary>
        public string Dm { get; set; }
    }
    #endregion
}