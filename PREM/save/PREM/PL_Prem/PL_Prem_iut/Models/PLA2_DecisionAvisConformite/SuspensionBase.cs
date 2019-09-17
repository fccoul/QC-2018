using System.ComponentModel.DataAnnotations;
using static RAMQ.PRE.PRE_Entites_cpo.Enumerations;

namespace RAMQ.PRE.PL_Prem_iut.Models.PLA2_DecisionAvisConformite
{
    /// <summary>
    /// Modèle de base pour les suspensions
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public abstract class SuspensionBase
    {
        /// <summary>
        /// Mode d'affichage
        /// </summary>
        public TypeTraitementSuspension ModeAffichage { get; set; }

        /// <summary>
        /// Numéro de pratique
        /// </summary>
        [Display(Name = "Identification du médecin")]
        [Required(ErrorMessage = "[41078@Numéro de pratique]")]
        [RegularExpression(@"^1\d{5}$", ErrorMessage = "[149061]")]
        public string NumeroPratique { get; set; }

        /// <summary>
        /// Identité du médecin
        /// </summary>
        [Display(Name = "IdentiteMedecin")]
        [Required(ErrorMessage = "Le champs est obligatoire.")]
        public string IdentiteMedecin { get; set; }

        /// <summary>
        /// Avis de conformité
        /// </summary>
        [Display(Name = "AvisConformite")]
        public string AvisConformite { get; set; }

        /// <summary>
        /// Description de l'avis de conformité
        /// </summary>
        [Display(Name = "DescriptionAvisConformite")]
        public string DescriptionAvisConformite { get; set; }

    }

}
