using System;

namespace RAMQ.PRE.PL_Prem_iut.Entite
{
    /// <summary>
    /// 
    /// </summary>
    public class InformationMedecin
    {
        /// <summary>
        /// 
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NumeroPratique { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? NombreAnneePratique { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? DateObtentionPermis { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int NombrePeriode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int NombreEntreeVigueur { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? DatePremiereFacturation { get; set; }

    }
}
