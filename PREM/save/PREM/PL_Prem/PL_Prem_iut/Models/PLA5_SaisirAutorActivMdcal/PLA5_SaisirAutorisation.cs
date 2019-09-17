using System;
using System.ComponentModel.DataAnnotations;


namespace RAMQ.PRE.PL_Prem_iut.Models.PLA5_SaisirAutorActivMdcal
{
    /// <summary>
    /// Modèle pour l'inscription d'autorisation.
    /// </summary>
    public class PLA5_SaisirAutorisation
    {
        /// <summary>
        /// Numéro de pratique
        /// </summary>
        [Display(Name = "Numéro de pratique")]
        [Required(ErrorMessage = "[41078@Identification du médecin]")]
        public string NumeroPratique { get; set; }

        /// <summary>
        /// Date de début de l'autorisation
        /// </summary>
        [Display(Name = "Date de début de l'autorisation")]
        public DateTime DateDebutAutorisation { get; set; }

        /// <summary>
        /// Date de fin de l'autorisation
        /// </summary>
        [Display(Name = "Date de fin de l'autorisation")]
        public DateTime? DateFinAutorisation { get; set; }

        /// <summary>
        /// Indicateur que les renseignements ont été confirmés.
        /// </summary>
        [Display(Name = "BLA BLA BLA")]
        public bool EstRenseignementConfirmer { get; set; }
    }
}