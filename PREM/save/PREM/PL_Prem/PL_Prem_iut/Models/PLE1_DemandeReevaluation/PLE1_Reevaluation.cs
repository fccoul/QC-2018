using RAMQ.PRE.PRE_Entites_cpo.DemandeReevaluation.Entite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RAMQ.PRE.PL_Prem_iut.Models.PLE1_DemandeReevaluation
{
    /// <summary>
    /// Modèle de données pour la consultation du profil d'un professionnel
    /// </summary>
    public class PLE1_Reevaluation : PLE1_InformationProfessionnel
    {

        #region Attributs
        
        private List<DemandeReevaluation> _demandesReeva;

        #endregion



        #region Propriétés


        /// <summary>
        /// Identité du médecin
        /// </summary>
        [Display(Name = "IdentiteMedecin")]
        [Required(ErrorMessage = "Le champ est obligatoire.")]
        public string IdentiteMedecin { get; set; }

        /// <summary>
        /// Date de début
        /// </summary>
        [Display(Name = "Date de début")]
        [Required(ErrorMessage = "[41078@Date de début]")]
        public DateTime? DateDebut { get; set; }   

        /// <summary>
        /// Date de début
        /// </summary>
        [Display(Name = "Date de fin")]
        [Required(ErrorMessage = "[41078@Date de fin]")]
        public DateTime? DateFin { get; set; }

        /// <summary>
        /// Type de demande
        /// </summary>
        [Display(Name = "Type de réévaluation")]
        [Required(ErrorMessage = "[41078@Type de réévaluation]")]
        public string TypeDemande { get; set; }

        /// <summary>
        /// Liste des pratiques
        /// </summary>
        public List<SelectListItem> TypesDemandes { get; set; } = new List<SelectListItem>() {
            new SelectListItem() { Value ="1" , Text = "Complète", Selected = true },
            new SelectListItem() { Value ="2" , Text = "Partielle" }
        };

        /// <summary>
        /// Message de confirmation de transmission ou d'annulation de haut de page.
        /// </summary>
        public string MessageConfirmation { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public bool MedecinResponsabiliteDRMG { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MessageErreur { get; set; }
        #endregion


        /// <summary>
        /// Liste de demandes de réévaluation
        /// </summary>
        /// <returns></returns>
        public List<DemandeReevaluation> DemandesReevaluation
        {
            get
            {
                if (_demandesReeva == null)
                {
                    _demandesReeva = new List<DemandeReevaluation>();
                }
                return _demandesReeva;
            }
            set { _demandesReeva = value; }
        }

    }

    
}
