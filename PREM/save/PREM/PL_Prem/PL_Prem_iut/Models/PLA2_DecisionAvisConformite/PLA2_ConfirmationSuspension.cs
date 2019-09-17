using System;
using System.ComponentModel.DataAnnotations;

namespace RAMQ.PRE.PL_Prem_iut.Models.PLA2_DecisionAvisConformite
{
    /// <summary>
    /// Modèle de la confirmation de la suspension
    /// </summary>
    public class PLA2_ConfirmationSuspension : SuspensionBase
    {
        /// <summary>
        /// Date de transmission
        /// </summary>
        /// <remarks>
        /// Auteur: Jean-Benoit Drouin-Cloutier
        /// </remarks>
        [Display(Name = "Date de transmission")]
        public DateTime DateTransmission { get; set; }


        /// <summary>
        /// Type de suspension
        /// </summary>
        [Display(Name = "TypeSuspension")]
        public string TypeSuspension { get; set; }

        /// <summary>
        /// Date de début
        /// </summary>
        [Display(Name = "Date de début")]
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Date de début formatée pour l'affichage
        /// </summary>
        [Display(Name = "Date de début")]
        public string DateDebutAffichage { get { return DateDebut.ToLongDateString(); } }

        /// <summary>
        /// Date de fin
        /// </summary>
        [Display(Name = "Date de fin")]
        public DateTime DateFin { get; set; }

        /// <summary>
        /// Date de début formatée pour l'affichage
        /// </summary>
        [Display(Name = "Date de fin")]
        public string DateFinAffichage { get { return DateFin.ToLongDateString(); } }

        /// <summary>
        /// Nouvelle date de fin
        /// </summary>
        [Display(Name = "Nouvelle date de fin")]
        public DateTime? NouvelleDateFin { get; set; }

        /// <summary>
        /// Nouvelle date de fin formatée pour l'affichage
        /// </summary>
        [Display(Name = "Nouvelle date de fin")]
        public string NouvelleDateFinAffichage { get { return NouvelleDateFin.HasValue ? NouvelleDateFin.Value.ToLongDateString() : null; } }

        /// <summary>
        /// Message de confirmation
        /// </summary>
        public string MessageConfirmation { get; set; }
    }
}