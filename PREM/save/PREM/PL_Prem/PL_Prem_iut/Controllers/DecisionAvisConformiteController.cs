using RAMQ.Message;
using RAMQ.PRE.PL_Prem_iut.Attributs;
using RAMQ.PRE.PL_Prem_iut.Models.PLA2_DecisionAvisConformite;
using RAMQ.PRE.PL_Prem_iut.Utilitaires;
using RAMQ.PRE.PL_PremMdl_cpo.AvisConformite;
using RAMQ.PRE.PL_PremMdl_cpo.DecisionAvisConformite;
using RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation;
using RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation.Param;
using RAMQ.PRE.PL_PremMdl_cpo.LieuGeographique;
using RAMQ.PRE.PL_PremMdl_cpo.Professionnel;
using RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.DecisionAvisConformite.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre;
using RAMQ.Web.MVC.Attributs;
using RAMQ.Web.MVC.Controleurs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using static RAMQ.PRE.PRE_Entites_cpo.Enumerations;
using OutilCommun = RAMQ.PRE.PRE_OutilComun_cpo;

namespace RAMQ.PRE.PL_Prem_iut.Controllers
{
    /// <summary>
    /// Contrôleur des décision des avis de conformités
    /// </summary>
    [RedirectionPageAccueil]
    public class DecisionAvisConformiteController : ControleurBase, IController
    {
        #region Attribut privé
        private readonly OutilCommun.IDomaineValeur _domaineValeur;
        private readonly IAvisConformiteFactory _avisConformiteFactory;
        private readonly ILieuGeographiqueFactory _lieuGeographiqueFactory;
        private readonly IDecisionAvisConformiteFactory _decisionAvisConformiteFactory;
        private readonly IProfessionnelFactory _professionnelFactory;
        private readonly OutilCommun.IMessageTraitement _messageTraitement;
        private readonly IGabaritPDFConfirmation _gabaritPDFConfirmation;
        private readonly INomFichierGabaritPDFConfirmationBuilder _nomFichierGabaritPDFConfirmationBuilder;
        #endregion

        #region Constantes
        private const string CleNumeroPratique = "NumeroPratique";
        private const string CleNumeroSequentielStatut = "NumeroSequentielStatut";
        private const string CleNumeroSequentielAvis = "NumeroSequentielAvis";
        private const string CleIdentiteMedecin = "IdentiteMedecin";
        private const string CleTypeSuspension = "TypeSuspension";
        private const string CleModeAffichage = "ModeAffichage";
        private const string CleDescriptionAvisConformite = "DescriptionAvisConformite";
        private const string CleDateDebut = "DateDebut";
        private const string CleDateFin = "DateFin";
        private const string CleModeleSuspension = "ModeleSuspension";
        private const string CleNouvelleDateFin = "NouvelleDateFin";
        private const string CleDescriptionTypeDerogation = "DescriptionTypeDerogation";
        private const string CleMessageConfirmation = "MessageConfirmation";
        private const string CleEstModeAnnulation = "EstModeAnnulation";
        private const string CleMessageFermetureEngagement = "MessageFermetureEngagement";
        

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="domaineValeur"></param>
        /// <param name="avisConformiteFactory"></param>
        /// <param name="lieuGeographiqueFactory"></param>
        /// <param name="decisionAvisConformiteFactory"></param>
        /// <param name="professionnelFactory"></param>
        /// <param name="messageTraitement"></param>
        /// <param name="gabaritPDFConfirmation">Gabarit PDF de confirmation</param>
        /// <param name="nomFichierGabaritPDFConfirmationBuilder">Builder pour le nom du fichier PDF de confirmation</param>
        public DecisionAvisConformiteController(OutilCommun.IDomaineValeur domaineValeur,
                                                IAvisConformiteFactory avisConformiteFactory,
                                                ILieuGeographiqueFactory lieuGeographiqueFactory,
                                                IDecisionAvisConformiteFactory decisionAvisConformiteFactory,
                                                IProfessionnelFactory professionnelFactory,
                                                OutilCommun.IMessageTraitement messageTraitement,
                                                IGabaritPDFConfirmation gabaritPDFConfirmation,
                                                INomFichierGabaritPDFConfirmationBuilder nomFichierGabaritPDFConfirmationBuilder)
        {
            _domaineValeur = domaineValeur;
            _avisConformiteFactory = avisConformiteFactory;
            _lieuGeographiqueFactory = lieuGeographiqueFactory;
            _decisionAvisConformiteFactory = decisionAvisConformiteFactory;
            _professionnelFactory = professionnelFactory;
            _messageTraitement = messageTraitement;
            _gabaritPDFConfirmation = gabaritPDFConfirmation;
            _nomFichierGabaritPDFConfirmationBuilder = nomFichierGabaritPDFConfirmationBuilder;
        }


        #endregion

        #region Opérations GET

        /// <summary>
        /// Traitement lors de l'ouverture de la page de transmission des dérogations
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ActionName(Constantes.NomAction.PLA2.TransmettreDerogation)]
        [Autor(Operation = "PRE_SaisDecisComtParit;PRE_CnsulSuppo")]
        public ActionResult TransmettreDerogation()
        {
            ViderToutTempDataSuspension();
            return View(new PLA2_Derogation());
        }

        /// <summary>
        /// Traitement lors de l'ouverture de la page de l'annulation des dérogations
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ActionName(Constantes.NomAction.PLA2.AnnulerDerogation)]
        [Autor(Operation = "PRE_SaisDecisComtParit;PRE_CnsulSuppo")]
        public ActionResult AnnulerDerogationGet()
        {
            ViderToutTempDataSuspension();
            return View(new PLA2_Derogation());
        }

        /// <summary>
        /// Traitement lors de l'ouverture de la page de confirmation des dérogations
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ActionName(Constantes.NomAction.PLA2.ConfirmationDerogation)]
        [Autor(Operation = "PRE_SaisDecisComtParit;PRE_CnsulSuppo")]
        public ActionResult ConfirmationDerogation()
        {
            try
            { 
                ActionResult resultat = null;

                PLA2_ConfirmationDerogation modele = new PLA2_ConfirmationDerogation
                {
                    NomCompletNumeroPratique = TempData.Obtenir<string>(CleIdentiteMedecin),
                    DescriptionTypeDerogation = TempData.Obtenir<string>(CleDescriptionTypeDerogation),
                    DateDebut = TempData.Obtenir<DateTime>(CleDateDebut),
                    MessageConfirmation = TempData.Obtenir<string>(CleMessageConfirmation),
                    EstModeAnnulation = TempData.Obtenir<bool>(CleEstModeAnnulation),
                    MessageFermetureEngagement = TempData.Obtenir<string>(CleMessageFermetureEngagement)
                };


                resultat = ModelState.IsValid && !string.IsNullOrEmpty(modele.NomCompletNumeroPratique)
                           ? (ActionResult)View(modele)
                           : RedirectToAction(Constantes.NomAction.PLA2.TransmettreDerogation,
                                              Constantes.NomControlleur.DecisionAvisConformite);

                return resultat;
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        /// <summary>
        /// Traitement lors de l'ouverture de la page de gestion des suspensions
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ActionName(Constantes.NomAction.PLA2.GererSuspension)]
        [Autor(Operation = "PRE_SaisDecisComtParit;PRE_CnsulSuppo")]
        public ActionResult GererSuspensionGet()
        {
            try
            { 
                var modele = TempData[CleModeleSuspension];

                ViderToutTempDataSuspension();

                return modele != null ? View(modele) : View(new PLA2_Suspension());
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        /// <summary>
        /// Traitement lors de l'ouverture de la page de l'ajout, la modification et l'annulation des suspensions
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ActionName(Constantes.NomAction.PLA2.AjouterModifierAnnulerSuspension)]
        [Autor(Operation = "PRE_SaisDecisComtParit;PRE_CnsulSuppo")]
        public ActionResult AjouterModifierAnnulerSuspensionGet()
        {

            try
            {

                var modele = new PLA2_Suspension() { IdentiteMedecin = TempData.Obtenir<string>(CleIdentiteMedecin),
                                                     ModeAffichage = TempData.Obtenir<TypeTraitementSuspension>(CleModeAffichage)};
                TempData.Keep(CleIdentiteMedecin);
                TempData.Keep(CleModeAffichage);
       
                //Obtenir l'avis sélectionner à la page précédente
                var extrant = _avisConformiteFactory.Instancier().ObtenirLesAvisConformite(
                    new ObtenirLesAvisConformiteEntre { NumeroSequentielEngagement = long.Parse(TempData.Obtenir<string>(CleNumeroSequentielAvis)) });

                TempData.Keep(CleNumeroSequentielAvis);

                    modele.Types = new List<SelectListItem>(
                        from domaineValeur in _domaineValeur.ObtenirDescriptionCodeRaisonStatutEngagement().OrderBy(x=>x.ValBasse)
                        where domaineValeur.ValBasse == OutilCommun.Constantes.CodeRaisonStatutEngagement.SuspensionExerceAutreTerritoire ||
                              domaineValeur.ValBasse == OutilCommun.Constantes.CodeRaisonStatutEngagement.SuspensionFinExercice ||
                              domaineValeur.ValBasse == OutilCommun.Constantes.CodeRaisonStatutEngagement.ProlongationSuspension
                        select new SelectListItem()
                        {
                            Text = domaineValeur.ValDes,
                            Value = domaineValeur.ValBasse
                        });

                if (TempData[CleNumeroSequentielStatut] != null)
                {
                    var suspension = extrant.ListeAvisConformite.First().ListeStatutAvisConformite.First(
                                   x => x.NumeroSequentielStatutEngagement.Value == long.Parse(TempData.Obtenir<string>(CleNumeroSequentielStatut)));


                    TempData.Keep(CleNumeroSequentielStatut);


                    modele.Type = ObtenirDescriptionCodeRaisonStatutEngagement(suspension.CodeRaisonStatutEngagement);
                    modele.DateDebut = suspension.DateDebutStatutEngagement;
                    modele.DateFin = suspension.DateFinStatutEngagement;


                    TempData[CleTypeSuspension] = modele.Type;
                    TempData[CleDateDebut] = suspension.DateDebutStatutEngagement;
                    TempData[CleDateFin] = suspension.DateFinStatutEngagement;
                }
          
                return View(modele);
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        /// <summary>
        /// Traitement lors de l'ouverture de la page de confirmation des suspensions
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ActionName(nameof(PLA2_ConfirmationSuspension))]
        [Autor(Operation = "PRE_SaisDecisComtParit;PRE_CnsulSuppo")]
        public ActionResult ConfirmationSuspensionGet()
        {

            try
            {
                PLA2_ConfirmationSuspension modele = new PLA2_ConfirmationSuspension
                {
                    IdentiteMedecin = TempData.Obtenir<string>(CleIdentiteMedecin),
                    AvisConformite = TempData.Obtenir<string>(CleNumeroSequentielAvis),
                    DateTransmission = DateTime.Now,
                    ModeAffichage = TempData.Obtenir<TypeTraitementSuspension>(CleModeAffichage),
                    NumeroPratique = TempData.Obtenir<string>(CleNumeroPratique),
                    TypeSuspension = TempData.Obtenir<string>(CleTypeSuspension),
                    DescriptionAvisConformite = TempData.Obtenir<string>(CleDescriptionAvisConformite)
                };

                if (modele.ModeAffichage != TypeTraitementSuspension.Modifier)
                {
                    modele.DateDebut = TempData.Obtenir<DateTime>(CleDateDebut);
                    modele.DateFin = TempData.Obtenir<DateTime>(CleDateFin);
                }
                else
                {
                    modele.DateDebut = TempData.Obtenir<DateTime>(CleDateDebut);
                    modele.DateFin = TempData.Obtenir<DateTime>(CleDateFin);
                    modele.NouvelleDateFin = TempData.Obtenir<DateTime>(CleNouvelleDateFin);
                }

                int codeTypeSuspension = 0;
                if (int.TryParse(modele.TypeSuspension, out codeTypeSuspension))
                {
                    modele.TypeSuspension = ObtenirDescriptionCodeRaisonStatutEngagement(modele.TypeSuspension);
                }

                string action = string.Empty;
                switch (modele.ModeAffichage)
                {
                    case TypeTraitementSuspension.Ajouter:
                        action = "transmise";
                        break;
                    case TypeTraitementSuspension.Modifier:
                        action = "modifiée";
                        break;
                    case TypeTraitementSuspension.Annuler:
                        action = "annulée";
                        break;
                    default:
                        break;
                }

                modele.MessageConfirmation = _messageTraitement.ResoudreMessageTraitement(OutilCommun.Constantes.CodeRetour.I_148016_SuspAvisConfSucces,
                                                                                          new string[] { action, DateTime.Now.ToString("d MMMM yyyy HH:mm:ss") });

                TempData.Keep(CleIdentiteMedecin);
                TempData.Keep(CleNumeroSequentielAvis);
                TempData.Keep(CleModeAffichage);
                TempData.Keep(CleDateDebut);
                TempData.Keep(CleDateFin);
                TempData.Keep(CleNumeroSequentielStatut);
                TempData.Keep(CleTypeSuspension);
                TempData.Keep(CleDescriptionAvisConformite);
                TempData.Keep(CleNouvelleDateFin);

                return View(modele);

            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }

        }

        #endregion

        #region Opérations POST

        /// <summary>
        /// Traitement lors de l'envoie de la page de l'annulation des dérogations
        /// </summary>
        /// <param name="modele">Modèle de données</param>
        /// <returns></returns>
        [HttpPost()]
        [ActionName(Constantes.NomAction.PLA2.AnnulerDerogation)]
        [Autor(Operation = "PRE_SaisDecisComtParit")]
        public ActionResult AnnulerDerogationPost(PLA2_Derogation modele)
        {
            ActionResult resultatAction = null;

            try
            {
                var extrant = _decisionAvisConformiteFactory.Instancier().TraiterAnnulationDerogation(
                    new TraiterAnnulationDerogationEntre()
                    {
                        NumeroSequentielDerogation = modele.NumeroSequentiel.Value,
                        DateDebutDerogation = modele.DateDebut.Value,
                        NumeroSequentielDispensateur = modele.NumeroSequentielDispensateur
                    });

                if (extrant.InfoMsgTrait.Count > 0)
                {
                    foreach (var message in extrant.InfoMsgTrait)
                    {
                        ModelState.AddModelError(string.Empty, message.TxtMsgFran);
                    }
                    return View(modele);
                }
                else
                {

                    TempData[CleIdentiteMedecin] = modele.IdentiteMedecin;
                    TempData[CleDescriptionTypeDerogation] = ObtenirDescriptionTypeDerogation(modele.Type);
                    TempData[CleDateDebut] = modele.DateDebut.Value;
                    TempData[CleMessageConfirmation] = _messageTraitement.ResoudreMessageTraitement(OutilCommun.Constantes.CodeRetour.I_148008_DerogTranmAnnuSucces,
                                                                                           new string[] { "annulée", DateTime.Now.ToString("d MMMM yyyy HH:mm:ss") });
                    TempData[CleEstModeAnnulation] = true;



                    resultatAction = RedirectToAction(Constantes.NomAction.PLA2.ConfirmationDerogation,
                                                      Constantes.NomControlleur.DecisionAvisConformite);
                }
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }

            return resultatAction;
        }

        /// <summary>
        /// Traitement lors de l'envoie de la page de la transmission des dérogations
        /// </summary>
        /// <param name="modele">Modèle de données</param>
        /// <returns></returns>
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        [ActionName(Constantes.NomAction.PLA2.TransmettreDerogation)]
        [Autor(Operation = "PRE_SaisDecisComtParit")]
        public ActionResult TransmettreDerogation(PLA2_Derogation modele)
        {
            ActionResult resultatAction = null;

            try
            {
                if (ModelState.IsValid)
                {
                    TraiterDerogationAvisConformiteEntre intrantTraiterderogAvisConf = new TraiterDerogationAvisConformiteEntre
                    {
                        NumeroPratique = modele.NumeroSequentielDispensateur,
                        TypeDerogation = modele.Type,
                        DateDebut = modele.DateDebut.Value,
                        Continuer = modele.Continuer,
                        QuestionPose = modele.QuestionPose
                    };
                    var extrantDerogation = _decisionAvisConformiteFactory.Instancier().TraiterDerogationAvisConformite(intrantTraiterderogAvisConf);

                    if (extrantDerogation.InfoMsgTrait.Count > 0)
                    {
                        foreach (var message in extrantDerogation.InfoMsgTrait.Where(x => x.CodSever == "E"))
                        {
                            ModelState.AddModelError(string.Empty, message.TxtMsgFran);
                        }

                        if (string.IsNullOrWhiteSpace(extrantDerogation.QuestionPose))
                        {
                            modele.Valider = false;
                            modele.Continuer = false;
                            modele.QuestionPose = null;
                        }
                        else
                        {
                            modele.Valider = true;
                            modele.Message = extrantDerogation.InfoMsgTrait.FirstOrDefault().TxtMsgFran;
                            modele.QuestionPose = extrantDerogation.QuestionPose;
                        }

                        return View(modele);
                    }

                    TempData[CleIdentiteMedecin] = extrantDerogation.NomCompletNumeroPratique;
                    TempData[CleDescriptionTypeDerogation] = extrantDerogation.DescriptionTypeDerogation;
                    TempData[CleDateDebut] = extrantDerogation.DateDebut;
                    TempData[CleMessageConfirmation] = _messageTraitement.ResoudreMessageTraitement(OutilCommun.Constantes.CodeRetour.I_148008_DerogTranmAnnuSucces,
                                                                                                    new string[] { "transmise", extrantDerogation.DateHeureCreationOccurence.ToString("d MMMM yyyy HH:mm:ss") });
                    TempData[CleEstModeAnnulation] = false;
                    TempData[CleMessageFermetureEngagement] = extrantDerogation.MessageFermetureEngagement;


                    resultatAction = RedirectToAction(Constantes.NomAction.PLA2.ConfirmationDerogation,
                                                      Constantes.NomControlleur.DecisionAvisConformite);
                }
                else
                {
                    resultatAction = View(modele);
                }
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }

            return resultatAction;
        }

        /// <summary>
        /// Traitement lors de l'envoie de la page de la gestion des suspensions
        /// </summary>
        /// <param name="modele">Modèle de données</param>
        /// <returns></returns>
        [HttpPost()]
        [ActionName(Constantes.NomAction.PLA2.GererSuspension)]
        [Autor(Operation = "PRE_SaisDecisComtParit;PRE_CnsulSuppo")]
        public ActionResult GererSuspensionPost(PLA2_Suspension modele)
        {
            try
            { 
                ActionResult resultat = null;

                resultat = RedirectToAction(Constantes.NomAction.PLA2.AjouterModifierAnnulerSuspension,
                                            Constantes.NomControlleur.DecisionAvisConformite);

                TempData[CleModeleSuspension] = modele;
                TempData[CleIdentiteMedecin] = modele.IdentiteMedecin;
                TempData[CleNumeroPratique] = modele.NumeroPratique;
                TempData[CleNumeroSequentielStatut] = modele.NumeroSequentiel;
                TempData[CleNumeroSequentielAvis] = modele.AvisConformite;
                TempData[CleTypeSuspension] = modele.Type;
                TempData[CleModeAffichage] = modele.ModeAffichage;
                TempData[CleDescriptionAvisConformite] = modele.DescriptionAvisConformite;

                return resultat;
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        /// <summary>
        /// Traitement lors de l'envoie de la page de la transmission des suspensions
        /// </summary>
        /// <param name="modele">Modèle de données</param>
        /// <returns></returns>
        [HttpPost()]
        [ActionName(Constantes.NomAction.PLA2.AjouterModifierAnnulerSuspension)]
        [Autor(Operation = "PRE_SaisDecisComtParit")]
        public ActionResult TransmettreSuspension(PLA2_Suspension modele)
        {
            ActionResult resultatAction = null;
            string numeroSequentielStatut = string.Empty;
            var messages = new List<MsgTrait>();

            try
            {
                modele.IdentiteMedecin = TempData.Obtenir<string>(CleIdentiteMedecin);

                var nouveauModele = new PLA2_ConfirmationSuspension
                {
                    IdentiteMedecin = TempData.Obtenir<string>(CleIdentiteMedecin),
                    AvisConformite = TempData.Obtenir<string>(CleNumeroSequentielAvis),
                    DateTransmission = DateTime.Now,
                    ModeAffichage = TempData.Obtenir<TypeTraitementSuspension>(CleModeAffichage),
                    NumeroPratique = TempData.Obtenir<string>(CleNumeroPratique),
                    TypeSuspension = !string.IsNullOrEmpty(modele.Type) ? modele.Type : !string.IsNullOrEmpty(TempData.Obtenir<string>(CleTypeSuspension)) ? TempData.Obtenir<string>(CleTypeSuspension) : modele.Type,
                    DescriptionAvisConformite = TempData.Obtenir<string>(CleDescriptionAvisConformite)
                };

                TempData[CleTypeSuspension] = nouveauModele.TypeSuspension;

                if (nouveauModele.ModeAffichage != TypeTraitementSuspension.Modifier)
                {
                    nouveauModele.DateDebut = modele.DateDebut.HasValue ? modele.DateDebut.Value : TempData.Obtenir<DateTime>(CleDateDebut);
                    nouveauModele.DateFin = modele.DateFin.HasValue ? modele.DateFin.Value : TempData.Obtenir<DateTime>(CleDateFin);
                    TempData[CleDateDebut] = nouveauModele.DateDebut;
                    TempData[CleDateFin] = nouveauModele.DateFin;

                }
                else
                {
                    nouveauModele.DateDebut = TempData.Obtenir<DateTime>(CleDateDebut);
                    nouveauModele.DateFin = TempData.Obtenir<DateTime>(CleDateFin);
                    nouveauModele.NouvelleDateFin = modele.DateFin;
                    TempData[CleNouvelleDateFin] = modele.DateFin;
                }

                numeroSequentielStatut = TempData.Obtenir<string>(CleNumeroSequentielStatut);


                messages = GererTransmissionDonneesSuspension(nouveauModele, numeroSequentielStatut);

                if (messages.Count > 0)
                {
                    foreach (var message in messages)
                    {
                        ModelState.AddModelError(string.Empty, message.TxtMsgFran);
                    }


                    if (modele.Types == null)
                    {
                        modele.Types = new List<SelectListItem>(
                            from domaineValeur in _domaineValeur.ObtenirDescriptionCodeRaisonStatutEngagement().OrderBy(x => x.ValBasse)
                            where domaineValeur.ValBasse == OutilCommun.Constantes.CodeRaisonStatutEngagement.SuspensionExerceAutreTerritoire ||
                                  domaineValeur.ValBasse == OutilCommun.Constantes.CodeRaisonStatutEngagement.SuspensionFinExercice ||
                                  domaineValeur.ValBasse == OutilCommun.Constantes.CodeRaisonStatutEngagement.ProlongationSuspension
                            select new SelectListItem()
                            {
                                Text = domaineValeur.ValDes,
                                Value = domaineValeur.ValBasse
                            });

                        if (modele.Type != null)
                        {
                            modele.Types.First(x => x.Value == modele.Type).Selected = true;
                        }
                        else
                        {
                            modele.Types.First(x => x.Text == nouveauModele.TypeSuspension).Selected = true;
                        }

                        modele.Type = nouveauModele.TypeSuspension;
                        modele.DateDebut = nouveauModele.DateDebut;

                    }

                    TempData.Keep(CleIdentiteMedecin);
                    TempData.Keep(CleNumeroSequentielAvis);
                    TempData.Keep(CleModeAffichage);
                    TempData.Keep(CleDateDebut);
                    TempData.Keep(CleDateFin);
                    TempData.Keep(CleNumeroSequentielStatut);
                    TempData.Keep(CleTypeSuspension);
                    TempData.Keep(CleDescriptionAvisConformite);

                    return View(modele);
                }
                else
                {
                    int typeSuspension = 0;
                    if (int.TryParse(modele.Type, out typeSuspension))
                    {
                        nouveauModele.TypeSuspension = ObtenirDescriptionCodeRaisonStatutEngagement(modele.Type);
                    }
                    resultatAction = RedirectToAction(Constantes.NomAction.PLA2.ConfirmationSuspension, 
                                                      Constantes.NomControlleur.DecisionAvisConformite);
                }

                TempData.Keep(CleIdentiteMedecin);
                TempData.Keep(CleNumeroSequentielAvis);
                TempData.Keep(CleModeAffichage);
                TempData.Keep(CleDateDebut);
                TempData.Keep(CleDateFin);
                TempData.Keep(CleNumeroSequentielStatut);
                TempData.Keep(CleTypeSuspension);
                TempData.Keep(CleDescriptionAvisConformite);
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }

            TempData.Remove(CleNumeroSequentielAvis);

            return resultatAction;

        }

        /// <summary>
        /// Obtenir le fichier PDF de confirmation suite à une action sur une
        /// suspension
        /// </summary>
        /// <param name="modele">Modèle</param>
        /// <returns>Retourne le fichier PDF de confirmation</returns>
        [HttpPost()]
        [ActionName(nameof(PLA2_ConfirmationSuspension))]
        [Autor(Operation = "PRE_SaisDecisComtParit;PRE_CnsulSuppo")]
        public ActionResult ConfirmationSuspensionPost(PLA2_ConfirmationSuspension modele)
        {
            try
            {
                var paramEntre = new ObtnConfirmationPDFSuspensionEntre()
                {
                    MessageConfirmation = modele.MessageConfirmation,
                    IdentificationMedecin = modele.IdentiteMedecin,
                    AvisConformite = modele.DescriptionAvisConformite,
                    TypeSuspension = modele.TypeSuspension,
                    DateDebut = modele.DateDebutAffichage,
                    DateFin = modele.DateFinAffichage,
                    DateDebutPerModif = modele.DateDebutAffichage,
                    DateFinPerModif = modele.NouvelleDateFinAffichage,
                    TypeAction = modele.ModeAffichage
                };

                var paramSorti = _gabaritPDFConfirmation.ObtenirConfirmationPDFSuspension(paramEntre);

                var nomFichier = _nomFichierGabaritPDFConfirmationBuilder.Construire(modele.IdentiteMedecin, HeureSysteme.Now());

                return File(paramSorti.GabaritPDF, "application/pdf", nomFichier);
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        /// <summary>
        /// Obtenir le fichier PDF de confirmation suite à une action sur une
        /// dérogation
        /// </summary>
        /// <param name="modele">Modèle</param>
        /// <returns>Retourne le fichier PDF de confirmation</returns>
        [HttpPost()]
        [ActionName(Constantes.NomAction.PLA2.ConfirmationDerogation)]
        [Autor(Operation = "PRE_SaisDecisComtParit;PRE_CnsulSuppo")]
        public ActionResult ConfirmationDerogationPost(PLA2_ConfirmationDerogation modele)
        {
            try
            {
                var paramEntre = new ObtnConfirmationPDFDerogationEntre()
                {
                    MessageConfirmation = modele.MessageConfirmation,
                    IdentificationMedecin = modele.NomCompletNumeroPratique,
                    TypeDerogation = modele.DescriptionTypeDerogation,
                    DateDebut = modele.DateDebutAffichage,
                    MessageInformatifComplementaire = modele.MessageFermetureEngagement,
                    EstUneAnnulation = modele.EstModeAnnulation
                };

                var paramSorti = _gabaritPDFConfirmation.ObtenirConfirmationPDFDerogation(paramEntre);

                var nomFichier = _nomFichierGabaritPDFConfirmationBuilder.Construire(modele.NomCompletNumeroPratique, HeureSysteme.Now());

                return File(paramSorti.GabaritPDF, "application/pdf", nomFichier);
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        #endregion

        #region Opérations AJAX

        /// <summary>
        /// Permet d'obtenir la dérogation d'un professionnel
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        [AjaxRequest()]
        [Autor(Operation = "PRE_SaisDecisComtParit;PRE_CnsulSuppo")]
        public JsonResult ObtenirDerogation(long numeroSequentielDispensateur)
        {
            try
            { 
                var extrant = _professionnelFactory.Instancier().ObtenirDerogationProfessionnelSante(
                    new ObtenirDerogationsProfessionnelSanteEntre() { NumeroSequentielDispensateur = numeroSequentielDispensateur });

                if ((extrant.Derogations.Count == 0) ||
                    (!extrant.Derogations.Any(x => x.Statut == OutilCommun.Constantes.StatutDerogation.StatutAutoriser && !x.DateHeureInactivationOccurence.HasValue)))
                {
                    extrant.Derogations.Clear();
                    if (extrant.InfoMsgTrait.Count == 0)
                    {
                        extrant.InfoMsgTrait = new List<MsgTrait>();
                        extrant.InfoMsgTrait.Add(_messageTraitement.NouveauMessageTraitement(OutilCommun.Constantes.CodeRetour.E_148038_DerogProfSantInxst));
                    }

                }
                else
                {
                    extrant.Derogations = new List<PRE_Entites_cpo.Derogation.Entite.Derogation>(
                        from derogation in extrant.Derogations
                        where derogation.Statut == OutilCommun.Constantes.StatutDerogation.StatutAutoriser &&
                              !derogation.DateHeureInactivationOccurence.HasValue
                        orderby derogation.DateDebut descending
                        select derogation);

                    if (extrant.Derogations.Count == 0)
                    {
                        extrant.InfoMsgTrait = new List<MsgTrait>();
                        extrant.InfoMsgTrait.Add(_messageTraitement.NouveauMessageTraitement(OutilCommun.Constantes.CodeRetour.E_148038_DerogProfSantInxst));
                    }
                }

                return Json(extrant);
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        /// <summary>
        /// Action permettant de voir s'il y a déjà un avis actif pour le professionnel sélectionné
        /// </summary>
        /// <param name="numeroProfessionnel"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [HttpPost()]
        [AjaxRequest()]
        [Autor(Operation = "PRE_SaisDecisComtParit;PRE_CnsulSuppo")]
        public ActionResult ValidationEngagementActif(long numeroProfessionnel)
        {
            try
            { 
                return Json(_avisConformiteFactory.Instancier().ValidationAvisDerogationEnCours(
                    new ValiderAvisDerogationEnCoursEntre { NumeroPratique = numeroProfessionnel }));
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        /// <summary>
        /// Permet d'obtenir le texte des messages d'erreurs
        /// </summary>
        /// <param name="idMessage">Identifiant du message recherché</param>
        /// <returns>Texte du message trouvé</returns>
        [HttpPost()]
        [AjaxRequest()]
        [Autor(Operation = "PRE_SaisDecisComtParit;PRE_CnsulSuppo")]
        public JsonResult ObtenirTextMessageErreur(string idMessage)
        {
            try
            { 
                return Json(_messageTraitement.ResoudreMessageTraitement(idMessage));
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
}

        /// <summary>
        /// Permet d'obtenir la description du code de raison de statut
        /// </summary>
        /// <param name="codeRaisonStatutEngagement">Code de raison du statut</param>
        /// <returns>Description du code de raison de statut</returns>
        [HttpPost()]
        [AjaxRequest()]
        [Autor(Operation = "PRE_SaisDecisComtParit;PRE_CnsulSuppo")]
        public JsonResult ObtenirDescriptionCodeRaisonStatutEngagementJSon(string codeRaisonStatutEngagement)
        {
            try
            {
                return Json(ObtenirDescriptionCodeRaisonStatutEngagement(codeRaisonStatutEngagement));
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        /// <summary>
        /// Permet d'obtenir la description du type de dérogation
        /// </summary>
        /// <param name="typeDerogation">Type de dérogation</param>
        /// <returns>Description du type de dérogation</returns>
        [HttpPost()]
        [AjaxRequest()]
        [Autor(Operation = "PRE_SaisDecisComtParit;PRE_CnsulSuppo")]
        public JsonResult ObtenirDescriptionTypeDerogationJson(string typeDerogation)
        {
            try
            {
                return Json(ObtenirDescriptionTypeDerogation(typeDerogation));
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        /// <summary>
        /// Permet d'obtenir les avis de conformités sans statut annuler ou révoqué
        /// </summary>
        /// <param name="numeroSequenceDispensateur">Numéro de pratique du professionnel</param>
        /// <returns>Les avis de conformité du professionnel</returns>
        [HttpPost()]
        [AjaxRequest()]
        [Autor(Operation = "PRE_SaisDecisComtParit;PRE_CnsulSuppo")]
        public ActionResult ObtenirAvisConformiteSansAnnulerRevoquer(long numeroSequenceDispensateur)
        {
            try
            {
                var extrant = _avisConformiteFactory.Instancier().ObtenirLesAvisConformite(
                new ObtenirLesAvisConformiteEntre
                {
                    NumeroSequentielDispensateur = numeroSequenceDispensateur,
                    IndicateurAttenteTransmission = "N"
                });

                extrant.ListeAvisConformite = new List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>(
                        from avis in extrant.ListeAvisConformite
                        where !avis.ListeStatutAvisConformite.Any(x => x.StatutEngagement == OutilCommun.Constantes.StatutAvisConformite.StatutAnnuler ||
                                                                        x.StatutEngagement == OutilCommun.Constantes.StatutAvisConformite.StatutRevoquer)
                        select avis);


                extrant.ListeAvisConformite.OrderByDescending(x => x.DateDebutEngagement);

                foreach (var avis in extrant.ListeAvisConformite)
                {
                    avis.ListeStatutAvisConformite = avis.ListeStatutAvisConformite.OrderByDescending(x => x.DateDebutStatutEngagement).ToList();
                }


                if (extrant.ListeAvisConformite.Count == 0)
                {
                    if (extrant.InfoMsgTrait.Count == 0)
                    {
                        extrant.InfoMsgTrait = new List<MsgTrait>();
                        extrant.InfoMsgTrait.Add(_messageTraitement.NouveauMessageTraitement(OutilCommun.Constantes.CodeRetour.E_148018_AvisConfProfSantInxst));
                    }
                }

                return Json(extrant);
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        #endregion

        #region Méthodes privées

        private string ObtenirDescriptionCodeRaisonStatutEngagement(string codeRaisonStatutEngagement)
        {
            var descriptionCodeRaison = _domaineValeur.ObtenirDescriptionCodeRaisonStatutEngagement();

            if (codeRaisonStatutEngagement != null && codeRaisonStatutEngagement.Length == 1)
            {
                codeRaisonStatutEngagement = codeRaisonStatutEngagement.PadLeft(2, char.Parse("0"));
            }

            return codeRaisonStatutEngagement != null ? descriptionCodeRaison.FirstOrDefault(x => x.ValBasse == codeRaisonStatutEngagement).ValDes : string.Empty;

        }

        private List<MsgTrait> GererTransmissionDonneesSuspension(PLA2_ConfirmationSuspension modele, string numeroSequentielSuspension)
        {

            TraiterSuspensionAvisConformiteSorti extrant = null;
            long numeroSequentielAvis = long.Parse(modele.AvisConformite);

            var extrantAvis = _avisConformiteFactory.Instancier().ObtenirLesAvisConformite(new ObtenirLesAvisConformiteEntre() { NumeroSequentielEngagement = numeroSequentielAvis });

            //var avis = new PRE_Entites_cpo.AvisConformite.Entite.AvisConformite() { NumeroSequentielEngagement = long.Parse(modele.AvisConformite) };
            var avis = extrantAvis.ListeAvisConformite.FirstOrDefault(x => x.NumeroSequentielEngagement == numeroSequentielAvis);
            var suspension = new PRE_Entites_cpo.AvisConformite.Entite.StatutAvisConformite()
            {
                NumeroSequentielEngagement = long.Parse(modele.AvisConformite),
                NumeroSequentielStatutEngagement = string.IsNullOrEmpty(numeroSequentielSuspension) ? (long?)null : long.Parse(numeroSequentielSuspension),
                CodeRaisonStatutEngagement = modele.TypeSuspension,
                DateDebutStatutEngagement = modele.DateDebut,
                DateFinStatutEngagement = modele.DateFin
            };


           
            if (modele.ModeAffichage == TypeTraitementSuspension.Modifier)
            {
                suspension.DateFinStatutEngagement = modele.NouvelleDateFin;
            }

            extrant = _decisionAvisConformiteFactory.Instancier().TraiterSuspensionAvisConformite(new TraiterSuspensionAvisConformiteEntre()
            {
                Avis = avis,
                NouvelleSuspension = suspension,
                TypeAction = modele.ModeAffichage
            });

            return extrant.InfoMsgTrait.ToList();
        }

        private string ObtenirDescriptionTypeDerogation(string typeDerogation)
        {
            var descriptionCodeRaison = _domaineValeur.ObtenirNomTypeDerogationDomaineValeur();

            return typeDerogation != null ? descriptionCodeRaison.FirstOrDefault(x => x.ValBasse == typeDerogation).ValDes : string.Empty;
        }


        private void ViderToutTempDataSuspension()
        {

            TempData.Remove(CleIdentiteMedecin);
            TempData.Remove(CleNumeroSequentielAvis);
            TempData.Remove(CleModeAffichage);
            TempData.Remove(CleDateDebut);
            TempData.Remove(CleDateFin);
            TempData.Remove(CleNumeroSequentielStatut);
            TempData.Remove(CleTypeSuspension);
            TempData.Remove(CleDescriptionAvisConformite);
            TempData.Remove(CleNumeroPratique);
            TempData.Remove(CleModeleSuspension);
        }
        #endregion

    }
}