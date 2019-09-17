using System;
using System.ComponentModel.DataAnnotations;

namespace RAMQ.PRE.PL_Prem_iut.Models.PLA2_DecisionAvisConformite
{
    /// <summary>
    /// Modèle de la confirmation de la dérogation
    /// </summary>
    public class PLA2_ConfirmationDerogation
    {
        #region Propriété

        /// <summary>
        /// Message de confirmation de transmission ou d'annulation de haut de page.
        /// </summary>
        public string MessageConfirmation { get; set; }

        /// <summary>
        /// Nom complet avec numéro de pratique.
        /// </summary>
        [Display(Name = "Identification du médecin")]
        public string NomCompletNumeroPratique { get; set; }

        /// <summary>
        /// Description type de dérogation
        /// </summary>
        [Display(Name = "Type de dérogation")]
        public string DescriptionTypeDerogation { get; set; }

        /// <summary>
        /// Date de début
        /// </summary>
        [Display(Name = "Date de début")]
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Date de début formatée pour l'affichage
        /// </summary>
        [Display(Name = "Date de début")]
        public string DateDebutAffichage { get { return DateDebut.ToString("D"); } }

        /// <summary>
        /// Message d'engagement fermé s'il y a lieu (soit Dérogation ou Avis de conformité).
        /// </summary>
        public string MessageFermetureEngagement { get; set; }

        /// <summary>
        /// Permet de déterminer si c'est un mode annulation (True) ou pas (False).
        /// </summary>
        public bool EstModeAnnulation { get; set; }

        #endregion
    }
}