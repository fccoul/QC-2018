using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using RAMQ.Message;
using RAMQ.PRE.PL_Prem_iut.Attributs;
using RAMQ.PRE.PL_Prem_iut.Entite;
using RAMQ.PRE.PL_Prem_iut.Models.PLA1_AvisConformite;
using RAMQ.PRE.PL_Prem_iut.Utilitaires;
using RAMQ.PRE.PL_PremMdl_cpo.AvisConformite;
using RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation;
using RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation.Param;
using RAMQ.PRE.PL_PremMdl_cpo.LieuGeographique;
using RAMQ.PRE.PL_PremMdl_cpo.Professionnel;
using RAMQ.PRE.PRE_Entites_cpo;
using RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Entite;
using RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using RAMQ.Web.MVC.Attributs;
using RAMQ.Web.MVC.Controleurs;
using OutilCommun = RAMQ.PRE.PRE_OutilComun_cpo;

namespace RAMQ.PRE.PL_Prem_iut.Controllers
{
    /// <summary>
    /// 
    /// </summary>    
    [RedirectionPageAccueil]
    public class AvisConformiteController : ControleurBase, IController
    {
        #region Attributs privées

        private const string CleNumeroAvisRedirection = "NumeroAvisRedirection";
        private const string CleNumeroAvis = "NumeroAvis";
        private const string CleNumeroStatut = "NumeroStatut";
        private const string CleNumeroPratique = "NumeroPratique";
        private const string CleTerritoire = "TerritoireID";
        private const string CleDatePrevue = "DatePrevue";
        private const string CleRedirection = "Redirection";
        private const string MessageConfirmation = "L'avis a été {0} le {1}.";

        private readonly IAvisConformiteFactory _avisConformiteFactory;
        private readonly ILieuGeographiqueFactory _lieuGeographiqueFactory;
        private readonly IProfessionnelFactory _professionnelFactory;
        private readonly Securite.ISecurite _securite;
        private readonly OutilCommun.IMessageTraitement _messageTraitement;
        private readonly IGabaritPDFConfirmation _gabaritPDFConfirmation;
        private readonly INomFichierGabaritPDFConfirmationBuilder _nomFichierGabaritPDFConfirmationBuilder;

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="avisConformiteFactory"></param>
        /// <param name="lieuGeographiqueFactory"></param>
        /// <param name="professionnelFactory"></param>
        /// <param name="securite"></param>
        /// <param name="messageTraitement"></param>
        /// <param name="gabaritPDFConfirmation">Gabarit de PDF de confirmation</param>
        /// <param name="nomFichierGabaritPDFConfirmationBuilder">Builder pour le nom du fichier PDF de confirmation</param>
        public AvisConformiteController(IAvisConformiteFactory avisConformiteFactory,
                                        ILieuGeographiqueFactory lieuGeographiqueFactory,
                                        IProfessionnelFactory professionnelFactory,
                                        Securite.ISecurite securite,
                                        OutilCommun.IMessageTraitement messageTraitement,
                                        IGabaritPDFConfirmation gabaritPDFConfirmation,
                                        INomFichierGabaritPDFConfirmationBuilder nomFichierGabaritPDFConfirmationBuilder)
        {
            _avisConformiteFactory = avisConformiteFactory;
            _lieuGeographiqueFactory = lieuGeographiqueFactory;
            _professionnelFactory = professionnelFactory;
            _securite = securite;
            _messageTraitement = messageTraitement;
            _gabaritPDFConfirmation = gabaritPDFConfirmation;
            _nomFichierGabaritPDFConfirmationBuilder = nomFichierGabaritPDFConfirmationBuilder;
        }

        #endregion

        #region PLA1_Transmettre

        /// <summary>
        /// Action GET pour la vue PLA1_Transmettre
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        [HttpGet()]
        [ActionName(Constantes.NomAction.PLA1.Transmettre)]
        [Autor(Operation = "PRE_SaisAvisConfDRMG;PRE_CnsulSuppo")]
        public ActionResult TransmettreGet()
        {
            try
            {
                var modelAvisConformite = new PLA1_AvisConformite();

                string guid = Guid.NewGuid().ToString();

                modelAvisConformite.Guid = guid;

                //Si provient de la sélection d'un avis en attente
                if (TempData[CleRedirection] != null && TempData.Obtenir<bool>(CleRedirection))
                {
                    var sortantObtentionAvis = _avisConformiteFactory.Instancier()
                        .ObtenirLesAvisConformite(new ObtenirLesAvisConformiteEntre
                        {
                            NumeroSequentielEngagement = TempData.Obtenir<long>(CleNumeroAvisRedirection)
                        });

                    if (sortantObtentionAvis.InfoMsgTrait.Any())
                    {
                        ModelState.AddModelError(string.Empty, sortantObtentionAvis.InfoMsgTrait.First().TxtMsgFran);
                        return View(modelAvisConformite);
                    }

                    var avis = sortantObtentionAvis.ListeAvisConformite.First();
                    var statut = avis.ListeStatutAvisConformite.First();

                    var professionnel = _professionnelFactory.Instancier()
                        .ObtenirInformationProfessionnel(new ObtenirDispensateurIndividuEntre
                        {
                            NumeroSequentielDispensateur = avis.NumeroSequentielDispensateur
                        });

                    modelAvisConformite.IdDDL = avis.NumeroSequentielDispensateur.ToString();
                    modelAvisConformite.TextDDL = professionnel.NomsIndividu.FirstOrDefault() + ", " + professionnel.PrenomsIndividu.FirstOrDefault();
                    modelAvisConformite.NumeroPratique = (professionnel.NumerosClasseDispensateur.First().Value * 100000 +
                                                          professionnel.NumerosDispensateur.First().Value).ToString();
                    modelAvisConformite.DatePrevue = avis.DateDebutEngagement;
                    modelAvisConformite.TextTerritoireDDL = _lieuGeographiqueFactory.Instancier()
                        .ObtenirNomTerritoire(new ObtenirNomTerritoireEntre
                        {
                            Code = avis.CodeLieuGeographique,
                            DateDebutPratique = avis.DateDebutEngagement,
                            NumeroSequentiel = avis.NumeroSequentielRegroupement,
                            Type = avis.TypeLieuGeographique,
                            CodeRSS = ObtenirCodeRSS()
                        }).NomTerritoire;

                    //TODO: peut-être faire l'appel jusqu'à la fonction dans reglesAffaires
                    modelAvisConformite.IdTerritoireDDL =
                        string.IsNullOrWhiteSpace(avis.CodeLieuGeographique) &&
                        string.IsNullOrWhiteSpace(avis.TypeLieuGeographique)
                         ? avis.NumeroSequentielRegroupement.Value.ToString()
                         : avis.TypeLieuGeographique + avis.CodeLieuGeographique;

                    modelAvisConformite.InfoRedirection = true;

                    //On garde temporairement en mémoire le numéro d'avis, mais aussi les autres informations 
                    //nécessaire puisque lors d'une modification, il faut le numéro d'avis et il ne faut pas qu'il 
                    //ait été modifié par une source externe. Pour les autres champs, c'est pour savoir s'ils ont été modifié
                    TempData[CleNumeroAvis + guid] = avis.NumeroSequentielEngagement;
                    TempData[CleNumeroStatut + guid] = statut.NumeroSequentielStatutEngagement;
                    TempData[CleNumeroPratique + guid] = modelAvisConformite.IdDDL;
                    TempData[CleDatePrevue + guid] = avis.DateDebutEngagement;
                    TempData[CleTerritoire + guid] = modelAvisConformite.IdTerritoireDDL;
                }
                else
                {
                    TempData.Remove(CleNumeroAvis + guid);
                    TempData.Remove(CleNumeroStatut + guid);
                    TempData.Remove(CleNumeroPratique + guid);
                    TempData.Remove(CleDatePrevue + guid);
                    TempData.Remove(CleTerritoire + guid);
                }

                return View(modelAvisConformite);
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        /// <summary>
        /// Action POST pour la vue PLA1_Transmettre
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        [ActionName(Constantes.NomAction.PLA1.Transmettre)]
        [Autor(Operation = "PRE_SaisAvisConfDRMG")]
        public ActionResult TransmettrePost(PLA1_AvisConformite model)
        {
            try
            {
                ActionResult resultat = null;
                string messageTraitement = null;

                if (ModelState.IsValid)
                {
                    if (model.Confirmation.Value &&
                        model.TypeAction == Enumerations.TypeTraitementAvisConformite.Enregistrer)
                    {
                        messageTraitement = _messageTraitement.ResoudreMessageTraitement(OutilCommun.Constantes.CodeRetour.E_43640_CaseCocheEnregistrer);
                        ModelState.AddModelError(string.Empty, messageTraitement);
                        return View(model);
                    }

                    if (!model.Confirmation.Value &&
                        model.TypeAction == Enumerations.TypeTraitementAvisConformite.Transmettre)
                    {
                        messageTraitement = _messageTraitement.ResoudreMessageTraitement(OutilCommun.Constantes.CodeRetour.E_43638_CaseCocheTransmettre);
                        ModelState.AddModelError(string.Empty, messageTraitement);
                        return View(model);
                    }

                    string guid = model.Guid;

                    if (model.TypeAction == Enumerations.TypeTraitementAvisConformite.Enregistrer &&
                        TempData[CleDatePrevue + guid] != null && TempData.Obtenir<DateTime>(CleDatePrevue + guid) == model.DatePrevue &&
                        TempData[CleTerritoire + guid] != null && TempData.Obtenir<string>(CleTerritoire + guid) == model.Territoire &&
                        TempData[CleNumeroPratique + guid] != null && TempData.Obtenir<string>(CleNumeroPratique + guid) == model.IdDDL)
                    {
                        messageTraitement = _messageTraitement.ResoudreMessageTraitement(OutilCommun.Constantes.CodeRetour.E_43959_AucuneModification);
                        ModelState.AddModelError(string.Empty, messageTraitement);

                        TempData.Keep(CleNumeroPratique + guid);
                        TempData.Keep(CleDatePrevue + guid);
                        TempData.Keep(CleTerritoire + guid);

                        return View(model);
                    };

                    var sortantTraiterAvis = _avisConformiteFactory.Instancier()
                        .TraiterAvisConformite(ParametreTraiterAvisTransmettre(model, guid));

                    if (sortantTraiterAvis.InfoMsgTrait.Any())
                    {
                        foreach (MsgTrait msg in sortantTraiterAvis.InfoMsgTrait)
                        {
                            if (msg.CodSever != "Q")
                            {
                                ModelState.AddModelError(string.Empty, msg.TxtMsgFran);
                            }
                        }

                        //On persiste les données puisque la vue va se ré-afficher et on ne veut pas que les
                        //données disparaissent puisque si la personne décide de continuer, les validations 
                        //vont se refaire et les conditions ne fonctionneront plus correctement si les 
                        //données ne sont plus en mémoire
                        TempData.Keep(CleNumeroAvis + guid);
                        TempData.Keep(CleNumeroStatut + guid);
                        TempData.Keep(CleNumeroPratique + guid);
                        TempData.Keep(CleDatePrevue + guid);
                        TempData.Keep(CleTerritoire + guid);

                        //Si une question est posé à l'utilisateur, il faut l'afficher à l'interface
                        if (!string.IsNullOrWhiteSpace(sortantTraiterAvis.QuestionPose))
                        {
                            model.Valider = true;
                            model.Message = sortantTraiterAvis.InfoMsgTrait.FirstOrDefault().TxtMsgFran;
                            model.QuestionPose = sortantTraiterAvis.QuestionPose;
                        }
                        else
                        {
                            model.Valider = false;
                            model.Continuer = false;
                            model.QuestionPose = null;
                        }

                        return View(model);
                    }

                    var confirmation = new PLA1_Confirmation
                    {
                        DateCreation = sortantTraiterAvis.DateCreation.Value,
                        DatePrevue = model.DatePrevue.Value,
                        NumeroPratique = sortantTraiterAvis.NomCompletNumeroPratique,
                        TypeAction = model.TypeAction.Value,
                        Territoire = sortantTraiterAvis.NomTerritoire
                    };

                    resultat = RedirectToAction(Constantes.NomAction.PLA1.Confirmation,
                                                Constantes.NomControlleur.AvisConformite,
                                                confirmation);
                }
                else
                {
                    resultat = View(model);
                }

                return resultat;
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        private TraiterAvisConformiteEntre ParametreTraiterAvisTransmettre(PLA1_AvisConformite model, string guid)
        {
            return new TraiterAvisConformiteEntre
            {
                DatePrevue = model.DatePrevue.Value,
                CodeRSS = ObtenirCodeRSS(),
                Continuer = (model.Continuer.HasValue) ? model.Continuer.Value : false,
                NumeroPratique = long.Parse(model.IdDDL),
                Territoire = model.Territoire,
                TypeAction = model.TypeAction.Value,
                QuestionPose = model.QuestionPose,
                NumeroSequentielAvis = TempData.Obtenir<long?>(CleNumeroAvis + guid),
                NumeroSequentielStatut = TempData.Obtenir<long?>(CleNumeroStatut + guid),
                DateModifier = (TempData[CleDatePrevue + guid] != null && TempData.Obtenir<DateTime>(CleDatePrevue + guid) != model.DatePrevue) ? true : false,
                TerritoireModifier = (TempData[CleTerritoire + guid] != null && TempData.Obtenir<string>(CleTerritoire + guid) != model.Territoire) ? true : false
            };
        }

        #endregion

        #region PLA1_Confirmation

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet()]
        [ActionName(Constantes.NomAction.PLA1.Confirmation)]
        [Autor(Operation = "PRE_SaisAvisConfDRMG;PRE_CnsulSuppo")]
        public ActionResult ConfirmationGet(PLA1_Confirmation model)
        {    
            try
            {
                const string TitreTransmettre = "Confirmation de transmission - Avis de conformité";
                const string TitreModifier = "Confirmation de modification - Avis de conformité";
                ActionResult resultat = null;
                string avisEtat = null;

                ViewData["TitrePage"] = "Confirmation";

                switch (model.TypeAction)
                {
                    case Enumerations.TypeTraitementAvisConformite.Transmettre:
                        avisEtat = "transmis";
                        ViewData["TitrePage"] = TitreTransmettre;
                        break;
                    case Enumerations.TypeTraitementAvisConformite.Enregistrer:
                        avisEtat = "enregistré";
                        ViewData["TitrePage"] = TitreTransmettre;
                        break;
                    case Enumerations.TypeTraitementAvisConformite.Modifier:
                        avisEtat = "modifié";
                        ViewData["TitrePage"] = TitreModifier;
                        break;
                    case Enumerations.TypeTraitementAvisConformite.Supprimer:
                        avisEtat = "supprimé";
                        ViewData["TitrePage"] = TitreTransmettre;
                        break;
                    case Enumerations.TypeTraitementAvisConformite.Annuler:
                        avisEtat = "annulé";
                        ViewData["TitrePage"] = TitreModifier;
                        break;
                    case Enumerations.TypeTraitementAvisConformite.Inactiver:
                        avisEtat = "annulé";
                        ViewData["TitrePage"] = TitreModifier;
                        break;
                    case Enumerations.TypeTraitementAvisConformite.Reporter:
                        avisEtat = "reporté";
                        ViewData["TitrePage"] = TitreModifier;
                        break;
                    case Enumerations.TypeTraitementAvisConformite.Revoquer:
                        avisEtat = "révoqué";
                        ViewData["TitrePage"] = TitreModifier;
                        break;
                }

                model.MessageConfirmation = string.Format(MessageConfirmation, avisEtat, model.DateCreation.ToString("d MMMM yyyy HH:mm:ss"));

                resultat = ModelState.IsValid & model.NumeroPratique != null
                           ? (ActionResult)View(model)
                           : RedirectToAction(Constantes.NomAction.PLA1.Transmettre,
                                              Constantes.NomControlleur.AvisConformite);

                return resultat;
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        /// <summary>
        /// Obtenir le fichier PDF de confirmation suite à une action sur un
        /// avis de conformité
        /// </summary>
        /// <param name="model">Modèle</param>
        /// <returns>Retourne le fichier PDF de confirmation</returns>
        [HttpPost()]
        [ActionName(Constantes.NomAction.PLA1.Confirmation)]
        [Autor(Operation = "PRE_SaisAvisConfDRMG;PRE_CnsulSuppo")]
        public ActionResult ConfirmationPost(PLA1_Confirmation model)
        {
            try
            {
                var paramEntre = new ObtnConfirmationPDFAvisConformiteEntre()
                {
                    MessageConfirmation = model.MessageConfirmation,
                    IdentificationMedecin = model.NumeroPratique,
                    Territoire = model.Territoire,
                    DateDebutPrevueAvis = model.DatePrevueAffichage,
                    TypeAction = model.TypeAction
                };

                var paramSorti = _gabaritPDFConfirmation.ObtenirConfirmationPDFAvisConformite(paramEntre);

                var nomFichier = _nomFichierGabaritPDFConfirmationBuilder.Construire(model.NumeroPratique, HeureSysteme.Now());

                return File(paramSorti.GabaritPDF, "application/pdf", nomFichier);
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        #endregion

        #region PLA1_Modifier

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ActionName(Constantes.NomAction.PLA1.Modifier)]
        [Autor(Operation = "PRE_SaisAvisConfDRMG;PRE_CnsulSuppo")]
        public ActionResult ModifierGet()
        {
            try
            {
                return View(new PLA1_Modification() { Guid = Guid.NewGuid().ToString() });
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost()]
        [ActionName(Constantes.NomAction.PLA1.Modifier)]
        [Autor(Operation = "PRE_SaisAvisConfDRMG")]
        public ActionResult ModifierPost(PLA1_Modification model)
        {
            try
            {
                ActionResult resultat;
                string messageTraitement = null;

                if (ModelState.IsValid)
                {
                    if (!model.Confirmation.Value)
                    {
                        messageTraitement = _messageTraitement.ResoudreMessageTraitement(OutilCommun.Constantes.CodeRetour.E_43638_CaseCocheTransmettre);
                        ModelState.AddModelError(string.Empty, messageTraitement);
                        return View(model);
                    }

                    string guid = model.Guid;

                    var sortantTraiterAvis = _avisConformiteFactory.Instancier()
                        .TraiterAvisConformite(ParametreTraiterModifier(model, guid));

                    if (sortantTraiterAvis.InfoMsgTrait.Any())
                    {
                        foreach (var msg in sortantTraiterAvis.InfoMsgTrait)
                        {
                            if (msg.CodSever != "Q")
                            {
                                ModelState.AddModelError(string.Empty, msg.TxtMsgFran);
                            }
                        }

                        //On persiste les données puisque la vue va se ré-afficher et on ne veut pas que les
                        //données disparaissent puisque si la personne décide de continuer, les validations 
                        //vont se refaire et les conditions ne fonctionneront plus correctement si les 
                        //données ne sont plus en mémoire
                        TempData.Keep(CleNumeroAvis + guid);

                        //Si une question est posé à l'utilisateur, il faut l'afficher à l'interface
                        if (!string.IsNullOrWhiteSpace(sortantTraiterAvis.QuestionPose))
                        {
                            model.Valider = true;
                            model.Message = sortantTraiterAvis.InfoMsgTrait.FirstOrDefault().TxtMsgFran;
                            model.QuestionPose = sortantTraiterAvis.QuestionPose;
                        }
                        else
                        {
                            model.Valider = false;
                            model.Continuer = false;
                            model.QuestionPose = null;
                        }

                        return View(model);
                    }

                    var confirmation = new PLA1_Confirmation()
                    {
                        DateCreation = sortantTraiterAvis.DateCreation.Value,
                        DatePrevue = (model.DatePrevue.HasValue) ? model.DatePrevue.Value : model.DateDebut.Value,
                        NumeroPratique = sortantTraiterAvis.NomCompletNumeroPratique,
                        Territoire = model.Territoire,
                        TypeAction = model.Decision
                    };

                    resultat = RedirectToAction(Constantes.NomAction.PLA1.Confirmation,
                                                Constantes.NomControlleur.AvisConformite,
                                                confirmation);
                }
                else
                {
                    resultat = View(model);
                }

                return resultat;
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        private TraiterAvisConformiteEntre ParametreTraiterModifier(PLA1_Modification model, string guid)
        {
            return new TraiterAvisConformiteEntre
            {
                DatePrevue = (model.DatePrevue.HasValue) ? model.DatePrevue.Value : DateTime.MinValue,
                CodeRSS = ObtenirCodeRSS(),
                DateDebut = (model.DateDebut.HasValue) ? model.DateDebut.Value : DateTime.MinValue,
                Continuer = (model.Continuer.HasValue) ? true : false,
                NumeroPratique = long.Parse(model.IdDDL),
                NumeroSequentielAvis = TempData.Obtenir<long?>(CleNumeroAvis + guid),
                Territoire = model.IdTerritoireDDL,
                TypeAction = model.Decision,
                QuestionPose = model.QuestionPose
            };
        }

        #endregion

        #region PLA1_Attente

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        [ActionName(Constantes.NomAction.PLA1.Attente)]
        [Autor(Operation = "PRE_SaisAvisConfDRMG;PRE_CnsulSuppo")]
        public ActionResult AttentePost(PLA1_Attente model)
        {
            try
            {
                ActionResult resultat = null;

                //Pour permettre de passer les données nécessaires à la prochaine vue sans les mettre dans l'URL
                TempData[CleNumeroAvisRedirection] = long.Parse(model.NumeroAvis);
                TempData[CleRedirection] = true;

                resultat = RedirectToAction(Constantes.NomAction.PLA1.Transmettre,
                                            Constantes.NomControlleur.AvisConformite,
                                            new PLA1_AvisConformite());

                return resultat;
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ActionName(Constantes.NomAction.PLA1.Attente)]
        [Autor(Operation = "PRE_SaisAvisConfDRMG;PRE_CnsulSuppo")]
        public ActionResult AttenteGet()
        {
            try
            {
                string messageTraitement = string.Empty;

                var sortantObtentionAvis = _avisConformiteFactory.Instancier()
                    .ObtenirLesAvisConformite(new ObtenirLesAvisConformiteEntre
                    {
                        IndicateurAttenteTransmission = OutilCommun.Constantes.IndicateurOui,
                        CodeRegion = ObtenirCodeRSS()
                    });

                List<string> territoires = new List<string>();
                List<string> numerosNomsPratique = new List<string>();
                List<DateTime> datesPrevu = new List<DateTime>();
                List<long?> numerosAvis = new List<long?>();

                foreach (AvisConformite avis in sortantObtentionAvis.ListeAvisConformite)
                {
                    var sortantProfessionnel = _professionnelFactory.Instancier()
                        .ObtenirInformationProfessionnel(new ObtenirDispensateurIndividuEntre
                        {
                            NumeroSequentielDispensateur = avis.NumeroSequentielDispensateur
                        });

                    numerosNomsPratique.Add(Utilitaires.Utilitaire.GenereNomAffichage(sortantProfessionnel));
                    datesPrevu.Add(avis.DateDebutEngagement);

                    territoires.Add(_lieuGeographiqueFactory.Instancier()
                        .ObtenirNomTerritoire(new ObtenirNomTerritoireEntre
                        {
                            Code = avis.CodeLieuGeographique,
                            DateDebutPratique = avis.DateDebutEngagement,
                            NumeroSequentiel = avis.NumeroSequentielRegroupement,
                            Type = avis.TypeLieuGeographique,
                            CodeRSS = ObtenirCodeRSS()
                        }).NomTerritoire);

                    numerosAvis.Add(avis.NumeroSequentielEngagement);
                }

                if (sortantObtentionAvis.ListeAvisConformite.Count == 0)
                {
                    messageTraitement = _messageTraitement.ResoudreMessageTraitement(OutilCommun.Constantes.CodeRetour.I_43818_AucunAvisNonTransmis);
                }
                if (sortantObtentionAvis.InfoMsgTrait.Any())
                {
                    messageTraitement = sortantObtentionAvis.InfoMsgTrait.First().TxtMsgFran;
                }

                return View(new PLA1_Attente
                {
                    Territoires = territoires,
                    NumerosNomsPratique = numerosNomsPratique,
                    DatesPrevues = datesPrevu,
                    NumerosAvis = numerosAvis,
                    MessageAvertissement = messageTraitement
                });
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        #endregion

        #region Ajax

        /// <summary>
        /// Action permettant de voir s'il y a déjà un avis actif pour le professionnel sélectionné
        /// </summary>
        /// <param name="intrant"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [HttpPost()]
        [AjaxRequest()]
        [Autor(Operation = "PRE_SaisAvisConfDRMG;PRE_CnsulSuppo")]
        public ActionResult ValidationAvisDerogationEnCours(ValiderAvisDerogationEnCoursEntre intrant, string guid)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(intrant.CodeRSS))
                {
                    intrant.CodeRSS = _securite.ObtenirCodeRSSUtilisateurCourant().CodeRSS;
                }

                var extrant = _avisConformiteFactory.Instancier()
                    .ValidationAvisDerogationEnCours(intrant);

                //On garde temporairement en mémoire le numéro d'avis, mais aussi les autres informations 
                //nécessaire puisque lors d'une modification, il faut le numéro d'avis et il ne faut pas qu'il 
                //ait été modifié par une source externe. Pour les autres champs, c'est pour savoir s'ils ont été modifié
                if (extrant.AvisEnregistrer)
                {
                    TempData[CleNumeroAvis + guid] = extrant.NumeroSequentielEngagement;
                    TempData[CleNumeroStatut + guid] = extrant.NumeroSequentielStatut;
                    TempData[CleNumeroPratique + guid] = intrant.NumeroPratique;
                    TempData[CleDatePrevue + guid] = extrant.DateDebutPratique;
                    TempData[CleTerritoire + guid] = extrant.TerritoireId;
                }
                else
                {
                    TempData.Remove(CleNumeroAvis + guid);
                    TempData.Remove(CleNumeroStatut + guid);
                    TempData.Remove(CleNumeroPratique + guid);
                    TempData.Remove(CleDatePrevue + guid);
                    TempData.Remove(CleTerritoire + guid);
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
        /// Fonction utiliser avec AJAX pour retourner les informations d'un avis de conformité à modifier
        /// </summary>
        /// <param name="numeroProfessionnel">numéro du professionnel à rechercher</param>
        /// <param name="guid">guid permettant d'identifier la page utilisé pour les onglets</param>
        /// <returns></returns>
        /// <remarks></remarks>
        [HttpPost()]
        [AjaxRequest()]
        [Autor(Operation = "PRE_SaisAvisConfDRMG;PRE_CnsulSuppo")]
        public ActionResult ObtenirAvisAModifier(long numeroProfessionnel, string guid)
        {
            try
            {
                var sortantAvis = _avisConformiteFactory.Instancier()
                       .ObtenirLesAvisConformite(new ObtenirLesAvisConformiteEntre
                       {
                           NumeroSequentielDispensateur = numeroProfessionnel,
                           IndicateurAttenteTransmission = OutilCommun.Constantes.IndicateurNon
                       });

                if (sortantAvis.InfoMsgTrait.Any())
                {
                    throw new Exception(sortantAvis.InfoMsgTrait.First().TxtMsgFran);
                }

                if (sortantAvis.ListeAvisConformite.Any())
                {
                    var avis = new List<AvisConformite>(
                        from avisConformite in sortantAvis.ListeAvisConformite.OrderByDescending(x => x.DateDebutEngagement)
                        where avisConformite.CodeRegion == ObtenirCodeRSS() &&
                              (avisConformite.ListeStatutAvisConformite.OrderByDescending(x => x.DateDebutStatutEngagement)
                                .Select(y => y.StatutEngagement).FirstOrDefault() == OutilCommun.Constantes.StatutAvisConformite.StatutAutoriser ||
                                avisConformite.ListeStatutAvisConformite.OrderByDescending(x => x.DateDebutStatutEngagement)
                                .Select(y => y.StatutEngagement).FirstOrDefault() == OutilCommun.Constantes.StatutAvisConformite.StatutSuspendu ||
                                avisConformite.ListeStatutAvisConformite.OrderByDescending(x => x.DateDebutStatutEngagement)
                                .Select(y => y.StatutEngagement).FirstOrDefault() == OutilCommun.Constantes.StatutAvisConformite.StatutTerminer)
                        select avisConformite).FirstOrDefault();

                    if (avis != null)
                    {
                        string messageAvertissement = string.Empty;

                        var statut = avis.ListeStatutAvisConformite.OrderByDescending(x => x.DateDebutStatutEngagement).FirstOrDefault();

                        if (statut.StatutEngagement == OutilCommun.Constantes.StatutAvisConformite.StatutTerminer)
                        {
                            messageAvertissement = RetourneBonMessageAvertissement(sortantAvis, numeroProfessionnel);
                        }

                        var statutActif = avis.ListeStatutAvisConformite.Where(x => x.DateDebutStatutEngagement <= DateTime.Today && x.DateFinStatutEngagement >= DateTime.Today).FirstOrDefault();

                        string statutCourrant = string.Empty;
                        if (statutActif != null)
                        {
                            statutCourrant = statutActif.StatutEngagement;
                        }

                        var informationAvisAModifier = new AvisAModifier()
                        {
                            NumeroSequentielRegroupement = avis.NumeroSequentielRegroupement,
                            CodeLieuGeographique = avis.CodeLieuGeographique,
                            TypeLieuGeographique = avis.TypeLieuGeographique,
                            DateDebutEngagement = avis.DateDebutEngagement,
                            MessageAvertissement = messageAvertissement,
                            Statut = statutCourrant
                        };

                        TempData[CleNumeroAvis + guid] = avis.NumeroSequentielEngagement;

                        return Json(informationAvisAModifier);
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        private string RetourneBonMessageAvertissement(ObtenirLesAvisConformiteSorti sortantAvis, long numeroProfessionnel)
        {
            string messageAvertissement;

            var dernierAvis = new List<AvisConformite>(
                 from avisConformite in sortantAvis.ListeAvisConformite.OrderByDescending(x => x.DateDebutEngagement)
                 where (avisConformite.ListeStatutAvisConformite.OrderByDescending(x => x.DateDebutStatutEngagement)
                         .Select(y => y.StatutEngagement).FirstOrDefault() == OutilCommun.Constantes.StatutAvisConformite.StatutAutoriser ||
                         avisConformite.ListeStatutAvisConformite.OrderByDescending(x => x.DateDebutStatutEngagement)
                         .Select(y => y.StatutEngagement).FirstOrDefault() == OutilCommun.Constantes.StatutAvisConformite.StatutSuspendu)
                 select avisConformite).FirstOrDefault();

            StatutAvisConformite dernierStatut = null;

            if (dernierAvis != null)
            {
                dernierStatut = dernierAvis.ListeStatutAvisConformite.OrderByDescending(x => x.DateDebutStatutEngagement).FirstOrDefault();
            }

            var derogations = _professionnelFactory.Instancier()
                .ObtenirDerogationProfessionnelSante(new ObtenirDerogationsProfessionnelSanteEntre
                {
                    NumeroSequentielDispensateur = numeroProfessionnel
                });

            var derniereDerogation = derogations.Derogations.OrderByDescending(x => x.DateDebut).FirstOrDefault();

            DateTime dateDerogation = (derniereDerogation != null) ? derniereDerogation.DateDebut : DateTime.MinValue;
            DateTime dateStatut = (dernierStatut != null) ? dernierStatut.DateDebutStatutEngagement : DateTime.MinValue;

            messageAvertissement = (dateStatut > dateDerogation)
                ? messageAvertissement = _messageTraitement.ResoudreMessageTraitement(
                    OutilCommun.Constantes.CodeRetour.E_43639_ValidationAvisFuture,
                    new string[] { dernierAvis.DateDebutEngagement.ToString("D"),
                                                   _lieuGeographiqueFactory.Instancier()
                                                       .ObtenirNomTerritoire(new ObtenirNomTerritoireEntre
                                                       {
                                                           Code = dernierAvis.CodeLieuGeographique,
                                                           DateDebutPratique = dernierAvis.DateDebutEngagement,
                                                           NumeroSequentiel = (dernierAvis.NumeroSequentielRegroupement.HasValue) ? dernierAvis.NumeroSequentielRegroupement.Value : default(long?),
                                                           Type = dernierAvis.TypeLieuGeographique
                                                       }).NomTerritoire,
                                                   _lieuGeographiqueFactory.Instancier()
                                                       .ObtenirNomTerritoire(new ObtenirNomTerritoireEntre
                                                       {
                                                           Code = dernierAvis.CodeRegion,
                                                           Type = "RSS"
                                                       }).NomTerritoire})
                : messageAvertissement = _messageTraitement.ResoudreMessageTraitement(
                    OutilCommun.Constantes.CodeRetour.E_148882_DerogationExistante,
                    new string[] { derniereDerogation.DateDebut.ToString("D") });
            return messageAvertissement;
        }

        /// <summary>
        /// Fonction utiliser avec AJAX pour retourner la liste des territoires permis
        /// </summary>
        /// <param name="dateDebutPratique">date de début de pratique</param>
        /// <returns></returns>
        [HttpPost()]
        [AjaxRequest()]
        [Autor(Operation = "PRE_SaisAvisConfDRMG;PRE_CnsulSuppo")]
        public ActionResult ObtenirTerritoiresPermis(DateTime dateDebutPratique)
        {
            try
            {
                var sortantTerritoiresPermis = _lieuGeographiqueFactory
                       .Instancier().ObtenirTerritoiresPermis(
                           new ObtenirTerritoiresPermisEntre
                           {
                               DateDebutPratique = dateDebutPratique,
                               CodeRSS = ObtenirCodeRSS()
                           });

                return Json(sortantTerritoiresPermis.TerritoiresPermis);
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        #endregion

        #region Obtention du code RSS              

        /// <summary>
        /// Obtient le code RSS
        /// </summary>
        /// <returns></returns>
        private string ObtenirCodeRSS()
        {
            try
            {
                return _securite.ObtenirCodeRSSUtilisateurCourant().CodeRSS;
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        #endregion        

    }
}