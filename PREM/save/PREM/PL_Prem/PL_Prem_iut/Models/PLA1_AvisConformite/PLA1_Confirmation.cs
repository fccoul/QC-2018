using System;
using System.ComponentModel.DataAnnotations;
using RAMQ.PRE.PRE_Entites_cpo;

namespace RAMQ.PRE.PL_Prem_iut.Models.PLA1_AvisConformite
{
    /// <summary>
    /// Modèle pour la confirmation d'un avis
    /// </summary>
    public class PLA1_Confirmation
    {
        /// <summary>
        /// Date de création
        /// </summary>
        [Display(Name = "Date de création de l'avis")]
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// Territoire
        /// </summary>
        [Display(Name = "Territoire")]
        public string Territoire { get; set; }

        /// <summary>
        /// Numéro de pratique
        /// </summary>
        [Display(Name = "NoPratique")]
        public string NumeroPratique { get; set; }

        /// <summary>
        /// Date prévue
        /// </summary>
        [Display(Name = "Date prévue du début de pratique")]
        public DateTime DatePrevue { get; set; }

        /// <summary>
        /// Date summary formatée pour l'affichage
        /// </summary>
        [Display(Name = "Date de début")]
        public string DatePrevueAffichage { get { return DatePrevue.ToString("d MMMM yyyy"); } }

        /// <summary>
        /// Type d'action
        /// </summary>
        public Enumerations.TypeTraitementAvisConformite TypeAction { get; set; }

        /// <summary>
        /// Message de confirmation
        /// </summary>
        public string MessageConfirmation { get; set; }
    }
}
