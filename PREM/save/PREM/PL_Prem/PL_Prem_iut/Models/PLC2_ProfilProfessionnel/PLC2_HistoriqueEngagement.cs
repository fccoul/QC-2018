using RAMQ.PRE.PRE_Entites_cpo.EngagementPratique.Entite;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using OutilCommun = RAMQ.PRE.PRE_OutilComun_cpo;
using RAMQ.DomainesValeur;
using System;
using RAMQ.PRE.PL_PremMdl_cpo.Professionnel;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.PeriodePratique.Parametre;
using RAMQ.PRE.PL_Prem_iut.Entite;

namespace RAMQ.PRE.PL_Prem_iut.Models.PLC2_ProfilProfessionnel
{
    /// <summary>
    /// Modèle de données pour la consultation du profil d'un professionnel
    /// </summary>
    public class PLC2_HistoriqueEngagement : PLC2_InformationProfessionnel, IPLC2_HistoriqueEngagement
    {

        #region Attributs

        private static IEnumerable<string> _entetesTableAvis;

        private bool _estTableauHistoriqueVisible;

        private List<EngagementPratique> _engagementPratiques;


        private readonly IProfessionnel _professionel;
        #endregion

        #region Constructeur
        /// <summary>
        /// 
        /// </summary>
        public PLC2_HistoriqueEngagement()
        { }
        /// <summary>
        /// constructeur avac paraamètre
        /// </summary>
        /// <param name="professionel"></param>
        public PLC2_HistoriqueEngagement(IProfessionnel professionel)
        {
            if (professionel == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(professionel)} ne peut etre null .");
            }

            _professionel = professionel;
        }
        #endregion

        #region Propriétés


        /// <summary>
        /// Identité du médecin
        /// </summary>
        [Display(Name = "IdentiteMedecin")]
        [Required(ErrorMessage = "Le champs est obligatoire.")]
        public string IdentiteMedecin { get; set; }

        /// <summary>
        /// Pratique année exclusive
        /// </summary>
        [Display(Name = "PratiqueExclusiveAnnee")]
        public string PratiqueExclusiveAnnee { get; set; }

        /// <summary>
        /// Liste d'engagement de pratiques
        /// </summary>
        /// <returns></returns>
        public List<EngagementPratique> EngagementPratiques
        {
            get
            {
                if (_engagementPratiques == null)
                {
                    _engagementPratiques = new List<EngagementPratique>();
                }
                return _engagementPratiques;
            }
            set { _engagementPratiques = value; }
        }

        /// <summary>
        /// Liste des pratique exclusive par années
        /// </summary>
        public List<SelectListItem> PratiqueExclusiveAnnees
        {
            get { return new List<SelectListItem> { new SelectListItem { Value = "1", Text = "2015", Selected = true }, new SelectListItem { Value = "2", Text = "2016" } }; }

            set { }
        }


        /// <summary>
        /// Liste des noms d'entête pour la/les table(s) des historiques des avis
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public static List<string> EnteteTableHistoriqueAvis
        {
            get
            {
                if (_entetesTableAvis == null)
                {
                    _entetesTableAvis = new List<string>(Constantes.NomColonneTableauEngagementPratique.Split(';'));
                }
                return _entetesTableAvis.ToList();
            }
        }

        /// <summary>
        /// Permet de savoir si le tableau des historique est visible ou non
        /// </summary>
        public bool EstTableauHistoriqueVisible
        {
            get { return _estTableauHistoriqueVisible; }
            set { _estTableauHistoriqueVisible = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool EstMedecinOmnipraticien { get; set; }

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
        /// Liste des raisons des statuts d'avis de conformité d'un médecin omnipraticien
        /// </summary>
        /// <returns>Dictionnaire de domaine de valeurs ayant pour clé la valeur basse </returns>
        public Dictionary<string, DomainesValeur.IValeur> ObtenirRaisStatusAvisConf(OutilCommun.IDomaineValeur domaineValeur)
        {
            Dictionary<string, DomainesValeur.IValeur> dictRaisStatusAvisConf = new Dictionary<string, DomainesValeur.IValeur>();
            dictRaisStatusAvisConf = domaineValeur.ObtenirDescriptionCodeRaisonStatutEngagement().ToDictionary(d => d.ValBasse);
            return dictRaisStatusAvisConf;

        }

        /// <summary>
        /// Liste des raisons des statuts d'avis de'autorisation d'un médecin omnipraticien
        /// </summary>
        /// <param name="domaineValeur"></param>
        /// <returns>Dictionnaire de domaine de valeurs ayant pour clé la valeur basse</returns>
        public Dictionary<string, IValeur> ObtenirRaisStatusAUTOR_PREMQ(OutilCommun.IDomaineValeur domaineValeur)
        {
            Dictionary<string, DomainesValeur.IValeur> dictRaisStatusAutorisation = new Dictionary<string, DomainesValeur.IValeur>();
            dictRaisStatusAutorisation = domaineValeur.ObtenirDescriptionCodeRaisonStatutAutorisation().ToDictionary(d => d.ValBasse);
            return dictRaisStatusAutorisation;
        }

        /// <summary>
        /// Liste des raisons des statuts d'avis de derogation d'un médecin omnipraticien
        /// </summary>
        /// <param name="domaineValeur"></param>
        /// <returns>Dictionnaire de domaine de valeurs ayant pour clé la valeur basse</returns>
        public Dictionary<string, IValeur> ObtenirRaisStatusDerogation(OutilCommun.IDomaineValeur domaineValeur)
        {
            Dictionary<string, DomainesValeur.IValeur> dictRaisStatusDerogation = new Dictionary<string, DomainesValeur.IValeur>();
            dictRaisStatusDerogation = domaineValeur.ObtenirDescriptionCodeRaisonStatutDerogation().ToDictionary(d => d.ValBasse);
            return dictRaisStatusDerogation;
        }

        #region methode Privée

        #endregion
    }

}
