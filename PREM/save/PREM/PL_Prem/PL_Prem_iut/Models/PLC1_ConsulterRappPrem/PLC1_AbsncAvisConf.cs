using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RAMQ.PRE.PL_Prem_iut.Models.PLC1_ConsulterRappPrem
{
    /// <summary>
    /// 
    /// </summary>
    public class PLC1_AbsncAvisConf
    {
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Année")]
        public string Annee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<SelectListItem> ListAnnees { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Trimestre")]
        public string Trimestre { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<SelectListItem> ListTrimestres { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Région")]
        public string Region { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<SelectListItem> ListRegions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Sous-territoire")]
        public string SousTerritoire { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public List<SelectListItem> ListSousTerritoires { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateDebutTrimestre { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateFinTrimestre { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<PRE_Entites_cpo.Rapport.Entite.LigneRapportAbsncAvisConf> LignesRapport { get; set; }
    }
}
