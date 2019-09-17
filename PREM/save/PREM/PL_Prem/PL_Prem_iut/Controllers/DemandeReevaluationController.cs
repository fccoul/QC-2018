using RAMQ.PRE.PL_Prem_iut.Attributs;
using RAMQ.PRE.PL_Prem_iut.Entite;
using RAMQ.PRE.PL_Prem_iut.Models.PLE1_DemandeReevaluation;
using RAMQ.PRE.PL_Prem_iut.Securite;
using RAMQ.PRE.PL_Prem_iut.Utilitaires;
using RAMQ.PRE.PL_PremMdl_cpo.DemandeReevaluation;
using RAMQ.PRE.PL_PremMdl_cpo.LieuGeographique;
using RAMQ.PRE.PL_PremMdl_cpo.Professionnel;
using RAMQ.PRE.PL_PremMdl_cpo.svcCnsulProfiPremqProf;
using RAMQ.PRE.PRE_Entites_cpo.DemandeReevaluation.Entite;
using RAMQ.PRE.PRE_Entites_cpo.DemandeReevaluation.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.EngagementPratique.Entite;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using RAMQ.Web.MVC.Attributs;
using RAMQ.Web.MVC.Controleurs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OutilCommun = RAMQ.PRE.PRE_OutilComun_cpo;


namespace RAMQ.PRE.PL_Prem_iut.Controllers
{
    /// <summary>
    /// Contrôleur pour la réévaluation du profil d'un professionnel
    /// </summary>
    /// <remarks>Maxime Comtois
    /// </remarks>
    public class DemandeReevaluationController : ControleurBase, IController
    {



        #region Attributs
        private readonly IProfessionnelFactory _professionnelFactory;
        private readonly IDemandeReevaluationFactory _demandeReevaluationFactory;
        private readonly OutilCommun.IDomaineValeur _domaineValeur;

        private PLE1_Reevaluation _modelePartage;

        private readonly ISecurite _securite;
        private readonly OutilCommun.IMessageTraitement _messageTraitement;

        private const string CleNumeroPratique = "NumeroPratique";
        private const string CleNumeroSequenceProfessionnel = "NumeroSequenceProfessionnel";

        #endregion



        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="professionnelFactory">Interface IProfessionnelFactory</param>
        /// <param name="demandeReevaluationFactory">Interface IDemandeReevaluationFactory</param>
        /// <param name="domaineValeur">Interface IDomaineValeur</param>
        /// <param name="securite">Interface ISecurite</param>
        /// <param name="messageTraitement">Interface IMessageTraitement</param>
        public DemandeReevaluationController(IProfessionnelFactory professionnelFactory,
                                             IDemandeReevaluationFactory demandeReevaluationFactory,
                                             OutilCommun.IDomaineValeur domaineValeur,
                                             ISecurite securite,
                                             OutilCommun.IMessageTraitement messageTraitement)
        {
            _professionnelFactory = professionnelFactory;
            _demandeReevaluationFactory = demandeReevaluationFactory;
            _domaineValeur = domaineValeur;
            _securite = securite;
            _messageTraitement = messageTraitement;
        }


        #endregion

        #region Propriétés       

        /// <summary>
        /// Modèle partagé dans le processus
        /// </summary>
        /// <returns></returns>
        private PLE1_Reevaluation ModelePartage
        {
            get
            {
                if (_modelePartage == null)
                {
                    _modelePartage = new PLE1_Reevaluation();
                }
                return _modelePartage;
            }
            set { _modelePartage = value; }
        }


        #endregion

        #region Opérations GET

        /// <summary>
        /// Réévaluation
        /// </summary>
        /// <returns>Vue</returns>
        [HttpGet()]
        [ActionName(nameof(PLE1_Reevaluation))]
        [Autor(Operation = "PRE_CreerDemReeva;PRE_CnsulSuppo")]
        public ActionResult PLE1_Reevaluation()
        {
            ActionResult vue = null;
            try
            {
                if (Utilitaire.EstDansZoneIntranet() || RAMQ.Utilitaires.ObtenirEnvir() == Environnement.Unitaire)
                {
                    vue = View(new PLE1_Reevaluation());
                }
                return vue;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        #endregion


        #region Opérations AJAX

        /// <summary>
        /// Permet d'obtenir les information du médecin
        /// </summary>
        /// <param name="numeroProfessionnel">Numéro du professionnel</param>
        /// <returns>Information d'un professionnel</returns>
        [HttpPost]
        [AjaxRequest()]
        [Autor(Operation = "PRE_CreerDemReeva;PRE_CnsulSuppo")]
        public JsonResult ObtenirInformationMedecin(string numeroProfessionnel)
        {

            try
            {
                var extrant = ObtenirInformationProfessionnel(numeroProfessionnel);
                var informationProfessionnel = default(RechercheProfessionnelReevaluation);
                TempData[CleNumeroSequenceProfessionnel] = extrant.NumerosSequentielDispensateur.FirstOrDefault();

                if (!extrant.InfoMsgTrait.Any())
                {
                    var premierMars2004 = new DateTime(2004, 3, 1);

                    var dateDeces = (extrant.DatesDecesIndividu.First().HasValue && extrant.DatesDecesIndividu.First() < premierMars2004) ?
                                    extrant.DatesDecesIndividu.First() : null;
                    var dateSpec = (extrant.DatesPremiereSpecialite.First().HasValue && extrant.DatesPremiereSpecialite.First() < premierMars2004) ?
                                    extrant.DatesPremiereSpecialite.First() : null;
                    
                    var extrantValidation = _demandeReevaluationFactory.Instancier().ValiderProfessionnel(
                        new PL_PremMdl_cpo.svcCreerDemReeva.ValiderProfessionnelEntre()
                        {
                            DateDeces = dateDeces,
                            DatePremiereSpecialite = dateSpec,
                            NumeroDispensateur = extrant.NumerosDispensateur.First(),
                            NumeroClasseDispensateur = extrant.NumerosClasseDispensateur.First()
                        });

                    informationProfessionnel = new RechercheProfessionnelReevaluation()
                    {
                        DateDeces = extrant.DatesDecesIndividu.FirstOrDefault(),
                        DateSpecialite = extrant.DatesPremiereSpecialite.FirstOrDefault(),
                        DateObtentionPermis = extrant.DatesObtentionPermis.FirstOrDefault(),
                        NumeroSequentielDispensateur = extrant.NumerosSequentielDispensateur.FirstOrDefault(),
                        NumeroSequentielIndividu = extrant.NumerosSequentielIndividu.FirstOrDefault()
                    };

                    if (extrant.NomsIndividu.Any() && extrant.PrenomsIndividu.Any())
                    {
                        informationProfessionnel.NomAffichage = extrant.NomsIndividu.First() + ", " + extrant.PrenomsIndividu.First();
                    }
                    else
                    {
                        informationProfessionnel.NomAffichage = string.Empty;
                    }


                    informationProfessionnel.MessageErreurs.AddRange(extrantValidation.InfoMsgTrait.Select(x => x.TxtMsgFran));
                    informationProfessionnel.DemandesReevaluation = ObtenirDemandeReevaluation();
                }
                else
                {
                    informationProfessionnel = new RechercheProfessionnelReevaluation();
                    informationProfessionnel.MessageErreurs.AddRange(extrant.InfoMsgTrait.Select(x => x.TxtMsgFran));
                }


                return Json(informationProfessionnel);
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        /// <summary>
        /// Permet d'obtenir des demandes de réévaluation
        /// </summary>
        /// <Parametre name="intrant">Paramètre d'entré</Parametre>
        /// <returns></returns>
        /// <remarks></remarks>
        [HttpPost]
        [AjaxRequest()]
        [Autor(Operation = "PRE_CreerDemReeva;PRE_CnsulSuppo")]
        public List<DemandeReevaluation> ObtenirDemandeReevaluation()
        {
            try
            {
                var client = _demandeReevaluationFactory.Instancier();
                var retour = (client.ObtenirDemandeReevaluation(
                    new ObtenirDemandeReevaluationEntre()
                    {
                        IndicateurActive = OutilCommun.Constantes.IndicateurOui,
                        NumeroSequentielDispensateur = (long)TempData[CleNumeroSequenceProfessionnel]
                    }

                )).ListeDemandeReevaluation;
                TempData.Keep();
                return retour;
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        /// <summary>
        /// Permet d'annuler une demandes de réévaluation
        /// </summary>
        [HttpPost]
        [AjaxRequest()]
        [Autor(Operation = "PRE_CreerDemReeva")]
        public void AnnulerDemandeReevaluation(string noSeqDemande)
        {
            try
            {
                var client = _demandeReevaluationFactory.Instancier();
                var retour = (client.AnnulerDemandeReevaluation(
                    new AnnulerDemandeReevaluationEntre()
                    {
                        IdentifiantInact = OutilCommun.Composante.ObtenirIdUtil(),
                        NumeroSequentielDemande = long.Parse(noSeqDemande)
                    }));
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }


        /// <summary>
        /// Permet de créer une demande de réévaluation
        /// </summary>
        /// <returns>Liste de demandes de réévaluation</returns>
        [HttpPost]
        [AjaxRequest()]
        [Autor(Operation = "PRE_CreerDemReeva")]
        public JsonResult CreerDemandeReevaluation(string categorie, Periode periode)
        {
            //if (!Utilitaire.EstDansGroupe(Utilitaires.Configuration.GroupeSupport))
            //{
            try
            {
                var client = _demandeReevaluationFactory.Instancier();
                var retour = (client.SaisirDemandeReevaluation(
                    new SaisirDemandeReevaluationEntre()
                    {
                        IdentifiantOcc = OutilCommun.Composante.ObtenirIdUtil(),
                        NumeroSequentielDispensateur = (long)TempData[CleNumeroSequenceProfessionnel],
                        CodeCategorieReeva = int.Parse(categorie),
                        CodeSource = OutilCommun.Constantes.SourceReeva.Agent,
                        DateDebutReeva = periode.DateDebut.Value.ToUniversalTime(),
                        DateFinReeva = periode.DateFin.Value.ToUniversalTime()
                    }));
                TempData.Keep();
                return Json(retour);
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
            //}
        }


        

        #endregion

        #region Opération Privée 


        private ObtenirDispensateurIndividuSorti ObtenirInformationProfessionnel(string numeroPratique)
        {
            int? classeDispensateur = !string.IsNullOrEmpty(numeroPratique) ? int.Parse(numeroPratique.Substring(0, 1)) : default(int?);
            int? numeroDispensateur = !string.IsNullOrEmpty(numeroPratique) ? int.Parse(numeroPratique.Substring(1, 5)) : default(int?);

            var informationProfessionnel = new ProfessionnelFactory().Instancier().ObtenirInformationProfessionnel(
                new ObtenirDispensateurIndividuEntre
                {
                    NumeroDispensateur = numeroDispensateur,
                    NumeroClasseDispensateur = classeDispensateur
                });

            return informationProfessionnel;
        }



        #endregion

        #region Opération publique

        /// <summary>
        /// Permet d'obtenir le code RSS de l'utilisateur courant
        /// </summary>
        /// <returns>Code RSS</returns>
        /// <remarks>La méthode est public pour est utiliser dans la view</remarks>
        [Autor(Operation = "PRE_CnsulProfiProf;PRE_CreerDemReeva;PRE_CnsulSuppo")]
        public CodeRSSUtilisateur ObtenirCodeRSSUtilisateurCourant()
        {
            return _securite.ObtenirCodeRSSUtilisateurCourant();
        }

        #endregion


    }
}