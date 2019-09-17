using System.ComponentModel.DataAnnotations;

namespace RAMQ.PRE.PL_Prem_iut.Models.PLC2_ProfilProfessionnel
{
    /// <summary>
    /// Modèle d'information du professionnel
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public class PLC2_InformationProfessionnel
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