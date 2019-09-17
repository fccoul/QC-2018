using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RAMQ.PRE.PL_Prem_iut.Models.PLA2_DecisionAvisConformite
{
    /// <summary>
    /// Modèle de suspension
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public class PLA2_Suspension : SuspensionBase
    {

        /// <summary>
        /// Numéro séquentiel de la suspension
        /// </summary>
        public string NumeroSequentiel { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        [Display(Name = "Type de suspension")]
        [Required(ErrorMessage = "[41078@Type de suspension]")]
        public string Type { get; set; }


        /// <summary>
        /// Date de début
        /// </summary>
        [Display(Name = "Date de début")]
        [Required(ErrorMessage = "[41078@Date de début]")]
        public DateTime? DateDebut { get; set; }

        /// <summary>
        /// Date de fin
        /// </summary>
        [Display(Name = "Date de la fin")]
        [Required(ErrorMessage = "[41078@Date de fin]")]
        public DateTime? DateFin { get; set; }

        /// <summary>
        /// Indicateur de renseignement confirmer
        /// </summary>
        [Display(Name = "Je Confirme que les renseignements transmis reflètent la décision prise.")]
        [Required(ErrorMessage = "[147999]")]
        public bool EstRenseignementConfirmer { get; set; }

        /// <summary>
        /// Liste de type de suspensions
        /// </summary>
        public IEnumerable<SelectListItem> Types{ get; set; }
    }
}