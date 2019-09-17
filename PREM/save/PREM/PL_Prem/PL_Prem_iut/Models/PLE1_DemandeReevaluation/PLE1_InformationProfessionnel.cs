using System.ComponentModel.DataAnnotations;

namespace RAMQ.PRE.PL_Prem_iut.Models.PLE1_DemandeReevaluation
{
    /// <summary>
    /// Modèle d'information du professionnel
    /// </summary>
    /// <remarks>
    /// Auteur: Maxime Comtois
    /// </remarks>
    public class PLE1_InformationProfessionnel
    {

        /// <summary>
        /// Numéro de pratique
        /// </summary>
        [Display(Name = "Numéro de pratique")]
        [Required(ErrorMessage = "Le champs est obligatoire.")]
        [RegularExpression(@"^1\d{5}$", ErrorMessage = "[149061]")]
        public string NumeroPratique { get; set; }

    }
}