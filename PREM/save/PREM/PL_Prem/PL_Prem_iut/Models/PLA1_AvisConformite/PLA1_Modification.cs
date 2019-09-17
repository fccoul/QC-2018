using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using RAMQ.PRE.PRE_Entites_cpo;

namespace RAMQ.PRE.PL_Prem_iut.Models.PLA1_AvisConformite
{
    /// <summary>
    /// Modèle pour la modification d'un avis
    /// </summary>
    public class PLA1_Modification
    {
        /// <summary>
        /// Territoire
        /// </summary>
        [Display(Name = "Territoire")]
        [Required(ErrorMessage = "[41078@Territoire]")]
        public string Territoire { get; set; }

        /// <summary>
        /// Date de début
        /// </summary>
        [Display(Name = "Date de début de l'avis")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DateDebut { get; set; }

        /// <summary>
        /// Décision
        /// </summary>
        [Display(Name = "Décision")]
        [Required(ErrorMessage = "[41078@Décision]")]
        public Enumerations.TypeTraitementAvisConformite Decision { get; set; }

        /// <summary>
        /// Liste de décision
        /// </summary>
        public List<SelectListItem> Decisions
        {
            get
            {
                List<SelectListItem> decisionsDDL = new List<SelectListItem>();
                decisionsDDL.Add(new SelectListItem
                {
                    Value = Enumerations.TypeTraitementAvisConformite.Inactiver.ToString("D"),
                    Text = "Annuler (erreur de saisie)"
                });
                decisionsDDL.Add(new SelectListItem
                {
                    Value = Enumerations.TypeTraitementAvisConformite.Annuler.ToString("D"),
                    Text = "Annuler (désistement)"
                });
                decisionsDDL.Add(new SelectListItem
                {
                    Value = Enumerations.TypeTraitementAvisConformite.Revoquer.ToString("D"),
                    Text = "Révoquer (article 5.04)"
                });
                decisionsDDL.Add(new SelectListItem
                {
                    Value = Enumerations.TypeTraitementAvisConformite.Reporter.ToString("D"),
                    Text = "Reporter (article 5.05)"
                });

                return decisionsDDL;
            }

            set { }
        }

        /// <summary>
        /// Confirmation
        /// </summary>
        public bool? Confirmation { get; set; }

        /// <summary>
        /// Numéro de pratique
        /// </summary>
        [Display(Name = "Numéro de pratique")]
        [Required(ErrorMessage = "[41078@Numéro de pratique]")]
        [RegularExpression(@"^1\d{5}$", ErrorMessage = "[149061]")]
        public string NumeroPratique { get; set; }

        /// <summary>
        /// Date prévue
        /// </summary>
        [Display(Name = "Date prévue du début de pratique")]
        public DateTime? DatePrevue { get; set; }

        /// <summary>
        /// Valider
        /// </summary>
        public bool? Valider { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Continuer après une question
        /// </summary>
        public bool? Continuer { get; set; }

        /// <summary>
        /// Question posé
        /// </summary>
        public string QuestionPose { get; set; }

        /// <summary>
        /// Id d'une liste déroulante de territoire
        /// </summary>
        public string IdTerritoireDDL { get; set; }

        /// <summary>
        /// Id d'une liste déroulante
        /// </summary>
        public string IdDDL { get; set; }

        /// <summary>
        /// Texte d'une liste déroulante
        /// </summary>
        public string TextDDL { get; set; }

        /// <summary>
        /// Guid pour la gestion des tabs multiple
        /// </summary>
        public string Guid { get; set; }
    }
}
