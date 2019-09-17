using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RAMQ.PRE.PL_Prem_iut.Models.PLC1_ConsulterRappPrem
{
    /// <summary>
    /// 
    /// </summary>
    public class PLC1_DerogPratiExclu
    {

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Année")]
        public int Annee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<SelectListItem> ListAnnees { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Type de pratique")]
        public string TypePratique { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<SelectListItem> ListTypesPratique { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? DateDebutRapport { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? DateFinRapport { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? NombreDispensateursRetournes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<PRE_Entites_cpo.Rapport.Entite.LigneRapportDerogPratiExclu> LignesRapport { get; set; }
    }
}
