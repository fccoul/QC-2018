using RAMQ.DomainesValeur;
using RAMQ.PRE.PRE_OutilComun_cpo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RAMQ.PRE.PL_Prem_iut.Models.PLA2_DecisionAvisConformite
{
    /// <summary>
    /// Modèle de dérogation
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public class PLA2_Derogation
    {
        /// <summary>
        /// Numéro de pratique
        /// </summary>
        [Display(Name = "Numéro de pratique")]
        [Required(ErrorMessage = "[41078@Numéro de pratique]")]
        [RegularExpression(@"^1\d{5}$", ErrorMessage = "[149061]")]
        public string NumeroPratique { get; set; }

        /// <summary>
        /// Numéro de séquence du dispensateur
        /// </summary>
        public long NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Type de dérogation
        /// </summary>
        [Display(Name = "Type de dérogation")]
        [Required(ErrorMessage = "[41078@Type de dérogation]")]
        public string Type { get; set; }

        /// <summary>
        /// Date de début
        /// </summary>
        [Display(Name = "Date de début")]
        [Required(ErrorMessage = "[41078@Date de début]")]
        public DateTime? DateDebut { get; set; }

        /// <summary>
        /// Indicateur de renseignement confirmer
        /// </summary>
        [Display(Name = "Confirmation")]
        [Required(ErrorMessage = "[147998]")]
        public bool EstRenseignementConfirmer { get; set; }

        /// <summary>
        /// Types de dérogation
        /// </summary>
        public List<SelectListItem> Types
        {
            get
            {
                var accesDomVal = new AccesDomVal();
                var domaineValeur = new DomaineValeur(accesDomVal);
                DomVal nomTypeDerogation = domaineValeur.ObtenirNomTypeDerogationDomaineValeur();
                
                List<SelectListItem> objListDerogation = new List<SelectListItem>();
                foreach (IValeur item in nomTypeDerogation)
                {
                    objListDerogation.Add(new SelectListItem
                    {
                        Value = item.ValBasse,
                        Text = item.ValDes
                    });
                }

                return objListDerogation;
            }
        }

        /// <summary>
        /// Id de la liste déroulante (Type de dérogation)
        /// </summary>
        public string IdTypeDDL { get; set; }

        /// <summary>
        /// Texte de la liste déroulante (Type de dérogation)
        /// </summary>
        public string TextTypeDDL { get; set; }

        /// <summary>
        /// Question posé.
        /// </summary>
        public string QuestionPose { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Valider
        /// </summary>
        public bool Valider { get; set; }

        /// <summary>
        /// Continuer après une question.
        /// </summary>
        public bool Continuer { get; set; }

        /// <summary>
        /// Numéro de séquence de la dérogation
        /// </summary>
        public long? NumeroSequentiel { get; set; }

        /// <summary>
        /// Identité du médecin
        /// </summary>
        public string IdentiteMedecin { get; set; }

        /// <summary>
        /// Message d'information
        /// </summary>
        public string MessageInformation { get; set; }
    }
}