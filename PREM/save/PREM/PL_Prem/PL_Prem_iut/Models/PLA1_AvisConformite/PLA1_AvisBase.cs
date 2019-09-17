using System;
using System.ComponentModel.DataAnnotations;

namespace RAMQ.PRE.PL_Prem_iut.Models.PLA1_AvisConformite
{
    /// <summary>
    /// Modèle de base pour les avis
    /// </summary>
    public class PLA1_AvisBase
    {
        /// <summary>
        /// Numéro de pratique
        /// </summary>
        [Display(Name = "Numéro de pratique")]
        [Required(ErrorMessage = "[41078@Numéro de pratique]")]
        [RegularExpression(@"^(1|5)\d{5}$", ErrorMessage = "[149242]")]
        public string NumeroPratique { get; set; }

        /// <summary>
        /// Date prévue
        /// </summary>
        [Display(Name = "Date prévue du début de pratique")]
        [Required(ErrorMessage = "[41078@Date prévue]")]
        public DateTime? DatePrevue { get; set; }

        /// <summary>
        /// Continuer après une question
        /// </summary>
        public bool? Continuer { get; set; }

        /// <summary>
        /// Question posé
        /// </summary>
        public string QuestionPose { get; set; }

        /// <summary>
        /// Id d'une liste déroulante
        /// </summary>
        public string IdDDL { get; set; }

        /// <summary>
        /// Texte d'une liste déroulante
        /// </summary>
        public string TextDDL { get; set; }

    }

}
