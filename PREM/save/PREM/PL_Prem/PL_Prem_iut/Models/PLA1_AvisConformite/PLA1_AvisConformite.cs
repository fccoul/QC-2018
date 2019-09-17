using System.ComponentModel.DataAnnotations;
using RAMQ.PRE.PRE_Entites_cpo;

namespace RAMQ.PRE.PL_Prem_iut.Models.PLA1_AvisConformite
{
    /// <summary>
    /// Modèle de base pour les avis de conformité
    /// </summary>
    public class PLA1_AvisConformite : PLA1_AvisBase
    {
        /// <summary>
        /// Territoire
        /// </summary>
        [Display(Name = "Territoire")]
        [Required(ErrorMessage = "[41078@Territoire]")]
        public string Territoire { get; set; }

        /// <summary>
        /// Confirmation
        /// </summary>
        [Display(Name = "Confirmation")]
        public bool? Confirmation { get; set; }

        /// <summary>
        /// Type d'action
        /// </summary>
        public Enumerations.TypeTraitementAvisConformite? TypeAction { get; set; }

        /// <summary>
        /// Valider
        /// </summary>
        public bool? Valider { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Id d'une liste déroulante de territoire
        /// </summary>
        public string IdTerritoireDDL { get; set; }

        /// <summary>
        /// Texte d'une liste déroulante de territoire
        /// </summary>
        public string TextTerritoireDDL { get; set; }

        /// <summary>
        /// Permet de savoir si l'information vient d'une redirection
        /// </summary>
        public bool? InfoRedirection { get; set; }

        /// <summary>
        /// Guid pour la gestion des tabs multiple
        /// </summary>
        public string Guid { get; set; }

    }

}
