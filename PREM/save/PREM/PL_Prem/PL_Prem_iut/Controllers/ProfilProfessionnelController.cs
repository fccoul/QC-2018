using RAMQ.PRE.PL_Prem_iut.Attributs;
using RAMQ.PRE.PL_Prem_iut.Entite;
using RAMQ.PRE.PL_Prem_iut.Models.PLC2_ProfilProfessionnel;
using RAMQ.PRE.PL_Prem_iut.Securite;
using RAMQ.PRE.PL_Prem_iut.Utilitaires;
using RAMQ.PRE.PL_PremMdl_cpo.LieuGeographique;
using RAMQ.PRE.PL_PremMdl_cpo.Professionnel;
using RAMQ.PRE.PL_PremMdl_cpo.svcCnsulProfiPremqProf;
using RAMQ.PRE.PRE_Entites_cpo.EngagementPratique.Entite;
using RAMQ.PRE.PRE_Entites_cpo.EngagementPratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Pratique.Entite;
using RAMQ.PRE.PRE_Entites_cpo.Pratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using RAMQ.Web.MVC.Attributs;
using RAMQ.Web.MVC.Controleurs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OutilCommun = RAMQ.PRE.PRE_OutilComun_cpo;

namespace RAMQ.PRE.PL_Prem_iut.Controllers
{
    /// <summary>
    /// Contrôleur pour la consultation du profil d'un professionnel
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public class ProfilProfessionnelController : ControleurBase, IController
    {

        #region Constantes

#pragma warning disable RAMQ0105 // Règle RAMQ 7.13 : Favorisez l'utilisation du mot clé nameof
        private const string NomVueEngagementPratique = "PLC2_HistoriqueEngagement";
        private const string NomVueRepartionInterregionnale = "PLC2_RepartitionPratique";
        private const string NomVueProfilPratiqueExclusive = "PLC2_PratiqueExclusive";
        private const string NomVueDroitsAcquis = "PLC2_RegionPratiquePartielleRestreinte";
        private const string NomVueReductionRemuneration = "PLC2_ReductionRemuneration";
#pragma warning restore RAMQ0105 // Règle RAMQ 7.13 : Favorisez l'utilisation du mot clé nameof

        private const string CleNumeroPratique = "NumeroPratique";
        private const string CleNumeroSequenceProfessionnel = "NumeroSequenceProfessionnel";
        private const string CleEngagementPratiques = "EngagementPratiques";
        private const string CleJourneesFacturerRss = "JourneesFacturerRss";
        private const string CleJourneesFacturerTerritoire = "JourneesFacturerTerritoire";

        #endregion

        #region Attributs

        private readonly IProfessionnelFactory _professionnelFactory;
        private readonly OutilCommun.IDomaineValeur _domaineValeur;

        private PLC2_HistoriqueEngagement _modelePartage;

        private static readonly Random _random = new Random();
        private static readonly object _syncLock = new object();
        private readonly ISecurite _securite;
        private readonly ILieuGeographiqueFactory _lieuGeographique;
        private readonly OutilCommun.IMessageTraitement _messageTraitement;

        private static readonly DateTime _debutPREM = new DateTime(2004, 3, 1);


        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="professionnelFactory">Interface IProfessionnelFactory</param>
        /// <param name="domaineValeur">Interface IDomaineValeur</param>
        /// <param name="securite">Interface ISecurite</param>
        /// <param name="lieuGeographique">Interface ILieuGeographiqueFactory</param>
        /// <param name="messageTraitement">Interface IMessageTraitement</param>
        public ProfilProfessionnelController(IProfessionnelFactory professionnelFactory,
                                             OutilCommun.IDomaineValeur domaineValeur,
                                             ISecurite securite,
                                             ILieuGeographiqueFactory lieuGeographique,
                                             OutilCommun.IMessageTraitement messageTraitement)
        {
            _professionnelFactory = professionnelFactory;
            _domaineValeur = domaineValeur;
            _securite = securite;
            _lieuGeographique = lieuGeographique;
            _messageTraitement = messageTraitement;
        }


        #endregion

        #region Propriétés       

        /// <summary>
        /// Modèle partagé dans le processus
        /// </summary>
        /// <returns></returns>
        private PLC2_HistoriqueEngagement ModelePartage
        {
            get
            {
                if (_modelePartage == null)
                {
                    _modelePartage = new PLC2_HistoriqueEngagement();
                }
                return _modelePartage;
            }
            set { _modelePartage = value; }
        }

        /// <summary>
        /// Permet de créer un nombre aléatoire
        /// </summary>
        /// <returns></returns>
        public static int CreerNombreAleatoire()
        {
            lock (_syncLock)
            {
                return _random.Next(int.MaxValue);
            }
        }
        #endregion

        #region Opérations GET

        /// <summary>
        /// Avis
        /// </summary>
        /// <returns>Vue</returns>
        [HttpGet()]
        [ActionName(nameof(PLC2_Avis))]
        [Autor(Operation = "PRE_CnsulProfiProf;PRE_CnsulSuppo")]
        public ActionResult PLC2_Avis()
        {
            return View(new PLC2_HistoriqueEngagement());
        }

        /// <summary>
        /// Engagement de pratique
        /// </summary>
        /// <param name="modele">Modèle de donnée</param>
        /// <returns>Vue</returns>
        [HttpGet()]
        [ActionName(NomVueEngagementPratique)]
        [Autor(Operation = "PRE_CnsulProfiProf;PRE_CnsulSuppo")]
        public ActionResult PLC2_HistoriqueEngagement(PLC2_HistoriqueEngagement modele)
        {

            try
            {
                ActionResult objResult = null;

                ModelePartage = modele;

                if (!string.IsNullOrWhiteSpace(ModelePartage.NumeroPratique))
                {

                    TempData[CleNumeroPratique] = ModelePartage.NumeroPratique;

                    var informationProfessionnel = ObtenirInformationProfessionnel(ModelePartage.NumeroPratique);

                    var dateObtentionPermis = informationProfessionnel.DatesObtentionPermis.First().Value;

                    TempData[CleNumeroSequenceProfessionnel] = informationProfessionnel.NumerosSequentielDispensateur.First().Value;


                    if (informationProfessionnel.NumerosSequentielDispensateur.Any() && informationProfessionnel.NumerosSequentielDispensateur.First().HasValue)
                    {
                        var extrantObtentionEngagement = _professionnelFactory.Instancier().ObtenirEngagementPratiques(
                            new ObtenirEngagementPratiqueEntre { NumeroSequenceDispensateur = informationProfessionnel.NumerosSequentielDispensateur.First().Value });

                        TempData["DictRaisStatusAvisConf"] = modele.ObtenirRaisStatusAvisConf(_domaineValeur);
                        TempData["DictRaisStatusDerogation"] = modele.ObtenirRaisStatusDerogation(_domaineValeur);
                        TempData["DictRaisStatusAutorisation"] = modele.ObtenirRaisStatusAUTOR_PREMQ(_domaineValeur);

                        var nomsDerogationDomaineValeur = _domaineValeur.ObtenirNomTypeDerogationDomaineValeur();


                        // Convertir le type de dérogation
                        foreach (var derogation in extrantObtentionEngagement.EngagementPratiques.Where(x => x.Description == OutilCommun.Constantes.DescriptionTypeEngagement.TypeDerogation))
                        {
                            if (!string.IsNullOrEmpty(derogation.Type))
                            {
                                derogation.Type = nomsDerogationDomaineValeur.First(x => x.ValBasse == derogation.Type).ValAbr;
                            }
                        }

                        if (extrantObtentionEngagement.EngagementPratiques.Any())
                        {
                            modele.EngagementPratiques.AddRange(extrantObtentionEngagement.EngagementPratiques);
                            TempData[CleEngagementPratiques] = extrantObtentionEngagement.EngagementPratiques;
                        }
                        else
                        {
                            modele.EngagementPratiques.Add(new EngagementPratique
                            {
                                NumeroSequence = CreerNombreAleatoire(),
                                CodeRegion = string.Empty,
                                Description = OutilCommun.Constantes.DescriptionTypeEngagement.TypeAbsenceAvis,
                                Historiques = new List<Historique>(),
                                Periode = new Periode
                                {
                                    DateDebut = dateObtentionPermis < _debutPREM ? _debutPREM : dateObtentionPermis,
                                    DateFin = null

                                },
                                Territoire = new PRE_Entites_cpo.EngagementPratique.Entite.InformationTerritoire()
                            });

                            TempData[CleEngagementPratiques] = modele.EngagementPratiques;
                        }

                        if (ValiderDroitDRMG())
                        {
                            var code = ObtenirCodeRSSUtilisateurCourant();

                            if (modele.EngagementPratiques.Any(x => x.Description == OutilCommun.Constantes.DescriptionTypeEngagement.TypeAvisConformite &&
                                                                    x.CodeRegion == code.CodeRSS))
                            {
                                modele.MedecinResponsabiliteDRMG = true;
                            }
                            else
                            {
                                modele.MedecinResponsabiliteDRMG = false;
                                modele.MessageErreur = _messageTraitement.ResoudreMessageTraitement(OutilCommun.Constantes.CodeRetour.E_148722_MedecinPasSousReponsabiliteUtilisateurConnecter);
                            }


                        }
                    }

                }
                else
                {
                    ModelePartage.EstTableauHistoriqueVisible = false;
                }


                modele = ModelePartage;
                objResult = PartialView(modele);


                return objResult;
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }



        }

        /// <summary>
        /// Répartition interrégionale
        /// </summary>
        /// <param name="modele">Modèle de donnée</param>
        /// <returns>Vue</returns>
        [HttpGet()]
        [ActionName(NomVueRepartionInterregionnale)]
        [Autor(Operation = "PRE_CnsulProfiProf;PRE_CnsulSuppo")]
        public ActionResult PLC2_RepartitionPratique(PLC2_RepartitionPratique modele)
        {

            try
            {
                if (TempData[CleEngagementPratiques] != null)
                {

                    var engagementPratiques = ((IEnumerable)TempData[CleEngagementPratiques]).Cast<EngagementPratique>().ToList();                                 
                        //-PRE 040
                        var engagementPratiquesSansNP = engagementPratiques.Where(x => x.Description != "Non-Participation").ToList();
                        if (engagementPratiquesSansNP != null && engagementPratiquesSansNP.Any())
                        {
                        TempData[CleEngagementPratiques] = null;
                        TempData[CleEngagementPratiques] = engagementPratiquesSansNP;
                        }
                    

                    var annees = default(List<int>);


                    if (ValiderDroitDRMG())
                    {
                        var code = ObtenirCodeRSSUtilisateurCourant();
                        annees = ObtenirAnnees(engagementPratiques.Where(x => x.Description == OutilCommun.Constantes.DescriptionTypeEngagement.TypeAvisConformite &&
                                                                         x.CodeRegion == code.CodeRSS).ToList());
                    }
                    else
                    {
                        annees = ObtenirAnnees(engagementPratiques);
                    }


                    modele.AnneesRepartition = new List<SelectListItem>(from annee in annees.Select(x => x).Distinct()
                                                                        select new SelectListItem()
                                                                        {
                                                                            Text = annee.ToString(),
                                                                            Value = annee.ToString()
                                                                        });


                    modele.AnneesRepartition = modele.AnneesRepartition.OrderByDescending(x => x.Value).ToList();

                    if (modele.AnneesRepartition.Any())
                    {
                        modele.AnneesRepartition.First().Selected = true;
                        modele.AnneeRepartition = modele.AnneesRepartition.First().Value;
                    }

                }



                TempData.Keep(CleEngagementPratiques);

            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
            return PartialView(modele);
        }

        /// <summary>
        /// Profil de pratique exclusive
        /// </summary>
        /// <param name="modele">Modèle de donnée</param>
        /// <returns>Vue</returns>
        [HttpGet()]
        [ActionName(NomVueProfilPratiqueExclusive)]
        [Autor(Operation = "PRE_CnsulProfiProf;PRE_CnsulSuppo")]
        public ActionResult PLC2_PratiqueExclusive(PLC2_PratiqueExclusive modele)
        {
            try
            {
                if (TempData[CleEngagementPratiques] != null)
                {

                    var engagementPratiques = ((IEnumerable)TempData[CleEngagementPratiques]).Cast<EngagementPratique>().ToList();
                    var annees = ObtenirAnnees(engagementPratiques);

                    modele.AnneesPratique = new List<SelectListItem>(from annee in annees.Select(x => x).Distinct()
                                                                     select new SelectListItem()
                                                                     {
                                                                         Text = annee.ToString(),
                                                                         Value = annee.ToString()
                                                                     });
                    modele.AnneesPratique = modele.AnneesPratique.OrderByDescending(x => x.Value).ToList();

                    if (modele.AnneesPratique.Any())
                    {
                        modele.AnneesPratique.First().Selected = true;
                        modele.AnneePratique = modele.AnneesPratique.First().Value;
                    }
                }



                TempData.Keep(CleEngagementPratiques);
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }

            return PartialView(modele);
        }

        /// <summary>
        /// Région à pratique partielle restreinte
        /// </summary>
        /// <param name="modele">Modèle de donnée</param>
        /// <returns>Vue</returns>
        [HttpGet()]
        [ActionName(NomVueDroitsAcquis)]
        [Autor(Operation = "PRE_CnsulProfiProf;PRE_CnsulSuppo")]
        public ActionResult PLC2_RegionPratiquePartielleRestreinte(PLC2_RegionPratiquePartielleRestreinte modele)
        {

            try
            {
                if (Utilitaire.ConvertirStringEnBoolean(Utilitaires.Configuration.AfficherOngletRPPR))
                {
                    var extrantCalculerNbrJrFactProfs = _professionnelFactory.Instancier().CalculerNombreJourneeFacturation(
                       new CalculerNbrJrFactProfsEntre
                       {
                           NumerosSequentielsProfs = new List<long>() { (long)TempData[CleNumeroSequenceProfessionnel] },
                           ObtenirListeRPPR = true
                       });

                    //Si PLB3 retourne le message 44038 ou le message 42198, alors afficher un message
                    if (extrantCalculerNbrJrFactProfs.Messages.Any(message => message.NumeroMessage == OutilCommun.Constantes.CodeRetour.I_44038_AucunDroitExercerRegionPratique
                                                                                    || message.NumeroMessage == OutilCommun.Constantes.CodeRetour.I_42198_MedecinPasSujetAuxRestrictionsRegionPratique))
                    {
                        var message = extrantCalculerNbrJrFactProfs.Messages.First(x => x.NumeroMessage == OutilCommun.Constantes.CodeRetour.I_44038_AucunDroitExercerRegionPratique ||
                                                                                   x.NumeroMessage == OutilCommun.Constantes.CodeRetour.I_42198_MedecinPasSujetAuxRestrictionsRegionPratique);

                        var parametresMessage = new List<string>();

                        if (!string.IsNullOrEmpty(message.ParamMsg1))
                        {
                            parametresMessage.Add(message.ParamMsg1);
                            if (!string.IsNullOrEmpty(message.ParamMsg2))
                            {
                                parametresMessage.Add(message.ParamMsg2);
                            }
                        }

                        modele.Message = _messageTraitement.ResoudreMessageTraitement(message.NumeroMessage, parametresMessage.ToArray());
                    }

                    var calculRPPR = extrantCalculerNbrJrFactProfs.JourneesRPPR;

                    //Engagement présent sur un territoire RPPR
                    if (calculRPPR.EngagementPresent.Any())
                    {
                        modele.DroitsExercices.Add(new DroitExercice()
                        {
                            Region = calculRPPR.EngagementPresent.First().CodeRSS,
                            Territoire = calculRPPR.EngagementPresent.First().NomTerritoire,
                            DateDebutPeriode = calculRPPR.EngagementPresent.First().DateDebut < _debutPREM ? _debutPREM : calculRPPR.EngagementPresent.First().DateDebut,
                        });
                    }

                    //Historique du droit d’exercice en région à pratique partielle restreinte
                    modele.HistoriqueDroitExercice.AddRange(calculRPPR.HistoriqueEngagement
                                                  .OrderByDescending(o => o.DateDebut).Select(o =>
                       new DroitExercice()
                       {
                           Region = o.CodeRSS,
                           Territoire = o.NomTerritoire,
                           DateDebutPeriode = o.DateDebut < _debutPREM ? _debutPREM : o.DateDebut,
                           DateFinPeriode = o.DateFin
                       }
                    ));

                    //Périodes d’exercices en région à pratique partielle restreinte sans y être autorisé par un avis de conformité
                    modele.PeriodesExercices.AddRange(calculRPPR.JourneesNonAutRPPR
                                            .Where(o=> o.TypeJours == OutilCommun.Constantes.TypeMontant.Total)
                                            .OrderByDescending(o => o.DebutPeriode).Select(o =>
                        new PeriodeExercice
                        {
                            Periode = DefinirPeriodeDroitExercice(o.DebutPeriode, o.FinPeriode),
                            EngagementActif = o.NomTerritoireAvis,
                            Region = o.CodeRSSAvis,
                            NombreJourPratique = o.NombreJours,
                            PourcentageEffectuer = o.Pourcentage
                        }
                    ));


                    //Dépassement du maximum de 45% autorisé par un droit d’exercice en région à pratique partielle restreinte
                    modele.DepassementPeriodesExercices.AddRange(calculRPPR.JourneesDepassementRPPR
                                                       .Where(o => o.IndicateurRespectRPPR == OutilCommun.Constantes.IndicateurNon)
                                                       .OrderByDescending(o => o.DebutPeriode).Select(o =>
                        new PeriodeExercice
                        {
                            Periode = DefinirPeriodeDroitExercice(o.DebutPeriode, o.FinPeriode),
                            EngagementActif = o.NomTerritoireAvis,
                            Region = o.NomTerritoirefacturation,
                            NombreJourPratique = o.NombreJours,
                            PourcentageEffectuer = o.Pourcentage
                        }
                    ));

                    var extrantObtenirPourcentageMaximum = _professionnelFactory.Instancier().ObtenirPourcentageMaximum();

                    if (!extrantObtenirPourcentageMaximum.InfoMsgTrait.Any())
                    {
                        modele.PourcentageMaximum = extrantObtenirPourcentageMaximum.PourcentageMaximum.ToString();
                    }
                    else
                    {
                        modele.PourcentageMaximum = "0";
                    }


                    TempData.Keep(CleNumeroSequenceProfessionnel);
                }

            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
            return PartialView(modele);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modele">Modèle de donnée</param>
        /// <returns>Vue</returns>
        [HttpGet()]
        [ActionName(NomVueReductionRemuneration)]
        [Autor(Operation = "PRE_CnsulProfiProf;PRE_CnsulSuppo")]
        public ActionResult PLC2_ReductionRemuneration(PLC2_HistoriqueEngagement modele)
        {

            TempData.Remove(CleNumeroPratique);
            return PartialView(modele);
        }
        #endregion

        #region Opérations POST

        /// <summary>
        /// Avis
        /// </summary>
        /// <param name="modele">Modèle de donnée</param>
        /// <returns>Vue</returns>
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        [ActionName(nameof(PLC2_Avis))]
        [Autor(Operation = "PRE_CnsulProfiProf;PRE_CnsulSuppo")]
        public ActionResult PLC2_Avis(PLC2_HistoriqueEngagement modele)
        {
            return View(modele);
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
        [Autor(Operation = "PRE_CnsulProfiProf;PRE_CnsulSuppo")]
        public JsonResult ObtenirInformationMedecin(string numeroProfessionnel)
        {

            try
            {

                var extrant = ObtenirInformationProfessionnel(numeroProfessionnel);
                var informationProfessionnel = default(RechercheProfessionnelInformation);


                if (!extrant.InfoMsgTrait.Any())
                {
                    var extrantValidation = _professionnelFactory.Instancier().ValiderProfessionnel(
                    new ValiderProfessionnelEntre()
                    {
                        DateDeces = extrant.DatesDecesIndividu.First(),
                        DatePremiereSpecialite = extrant.DatesPremiereSpecialite.First(),
                        NumeroDispensateur = extrant.NumerosDispensateur.First(),
                        NumeroClasseDispensateur = extrant.NumerosClasseDispensateur.First()
                    });

                    informationProfessionnel = new RechercheProfessionnelInformation()
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
                }
                else
                {
                    informationProfessionnel = new RechercheProfessionnelInformation();
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
        /// Permet d'obtenir les engagements selon l'année.
        /// </summary>
        /// <param name="annee">Année</param>
        /// <returns>Engagement</returns>
        [HttpPost]
        [AjaxRequest()]
        [Autor(Operation = "PRE_CnsulProfiProf;PRE_CnsulSuppo")]
        public JsonResult ObtenirEngagementSelonAnnee(string annee)
        {
            var engagementsRetour = new List<SelectListItem>();
            var absencesAvisAjouter = new List<EngagementPratique>();
            try
            {


                if (TempData[CleEngagementPratiques] != null)
                {
                    var engagementPratiques = ((IEnumerable)TempData[CleEngagementPratiques]).Cast<EngagementPratique>().ToList();

                    if (ValiderDroitDRMG())
                    {
                        engagementPratiques = engagementPratiques.Where(x => x.Description == OutilCommun.Constantes.DescriptionTypeEngagement.TypeAvisConformite).ToList();
                    }

                    if (!string.IsNullOrWhiteSpace(annee))
                    {
                        var anneeSelectionner = int.Parse(annee);
                        var dateDebutControle = new DateTime(anneeSelectionner, 3, 1);

                        //Permet d'obtenir la date du 28 ou 29 février
                        var dateFinControle = new DateTime(anneeSelectionner + 1, 3, 1).AddDays(-1);

                        foreach (var engagement in engagementPratiques.Where(x => x.Description != OutilCommun.Constantes.DescriptionTypeEngagement.TypeAvisRevoque))
                        {

                            var dateFin = ObtenirDateFinPREM(engagement.Periode.DateDebut.Value, engagement.Periode.DateFin);

                            if (engagement.Periode.DateDebut.Value.Year == anneeSelectionner &&
                                (dateFin.Year == (anneeSelectionner + 1) || dateFin <= dateFinControle))
                            {
                                engagementsRetour.Add(new SelectListItem()
                                {
                                    Value = engagement.NumeroSequence.Value.ToString(),
                                    Text = DefinirNomEngagement(engagement)
                                });
                            }
                            else if (engagement.Periode.DateFin.HasValue &&
                                     (engagement.Periode.DateFin.Value - engagement.Periode.DateDebut).Value.TotalDays > 365 &&
                                      ValiderAnneeSituerDansPeriode(anneeSelectionner, engagement.Periode.DateDebut.Value.Year, engagement.Periode.DateFin.Value.Year) &&
                                      ValiderDateSituerDansPeriode(engagement.Periode.DateFin.Value, new DateTime(anneeSelectionner, 3, 1), dateFinControle))
                            {
                                engagementsRetour.Add(new SelectListItem()
                                {
                                    Value = engagement.NumeroSequence.Value.ToString(),
                                    Text = DefinirNomEngagement(engagement)
                                });
                            }
                            else if (engagement.Periode.DateFin.HasValue &&
                                    (engagement.Periode.DateFin.Value - engagement.Periode.DateDebut).Value.TotalDays > 365 &&
                                     ValiderAnneeSituerDansPeriode(anneeSelectionner, engagement.Periode.DateDebut.Value.Year, engagement.Periode.DateFin.Value.Year))
                            {
                                engagementsRetour.Add(new SelectListItem()
                                {
                                    Value = engagement.NumeroSequence.Value.ToString(),
                                    Text = DefinirNomEngagement(engagement)
                                });
                            }
                            else if (engagement.Periode.DateFin.HasValue &&
                                    ValiderAnneeSituerDansPeriode(anneeSelectionner, engagement.Periode.DateDebut.Value.Year, engagement.Periode.DateFin.Value.Year) &&
                                    ValiderDateSituerDansPeriode(engagement.Periode.DateFin.Value, dateDebutControle, dateFinControle))
                            {
                                engagementsRetour.Add(new SelectListItem()
                                {
                                    Value = engagement.NumeroSequence.Value.ToString(),
                                    Text = DefinirNomEngagement(engagement)
                                });
                            }
                            else if (!engagement.Periode.DateFin.HasValue &&
                                     engagement.Periode.DateDebut <= dateFinControle)
                            {
                                engagementsRetour.Add(new SelectListItem()
                                {
                                    Value = engagement.NumeroSequence.Value.ToString(),
                                    Text = DefinirNomEngagement(engagement)
                                });
                            }

                        }


                        engagementsRetour = engagementsRetour.Distinct(new SelectListItemComparer()).ToList();

                        engagementPratiques.AddRange(absencesAvisAjouter);

                        TempData[CleEngagementPratiques] = engagementPratiques;

                    }
                    else
                    {
                        engagementsRetour = new List<SelectListItem>();
                    }

                }

                TempData.Keep(CleEngagementPratiques);
                return Json(engagementsRetour);

            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        /// <summary>
        /// Permet d'obtenir les répartitions de la pratique
        /// </summary>
        /// <param name="periode">Période</param>
        /// <param name="codeRSS">Code RSS</param>
        /// <returns>Liste de répartition de pratique</returns>
        [HttpPost]
        [AjaxRequest()]
        [Autor(Operation = "PRE_CnsulProfiProf;PRE_CnsulSuppo")]
        public JsonResult ObtenirRepartitionPratique(Periode periode,
                                                     string codeRSS)
        {

            try
            {

                var extrant = _professionnelFactory.Instancier().CalculerNombreJourneeFacturation(
                    new CalculerNbrJrFactProfsEntre()
                    {
                        NumerosSequentielsProfs = new List<long>() { (long)TempData[CleNumeroSequenceProfessionnel] },
                        DateDebut = periode.DateDebut.Value,
                        DateFin = periode.DateFin,
                        ObtenirListeInter = true,
                        ObtenirListeIntra = true,
                        ObtenirListeRespectEngag = false,
                        ObtenirListeRPPR = false
                    });


                extrant.JourneesFactRSS = extrant.JourneesFactRSS.Where(x => x.TypeJours == OutilCommun.Constantes.TypeMontant.HQ ||
                                                                             x.TypeJours == OutilCommun.Constantes.TypeMontant.PremDpnagLoc ||
                                                                             x.TypeJours == OutilCommun.Constantes.TypeMontant.Localite ||
                                                                             x.TypeJours == OutilCommun.Constantes.TypeMontant.Total ||
                                                                             x.TypeJours == OutilCommun.Constantes.TypeMontant.TotalDerog ||
                                                                             x.TypeJours == OutilCommun.Constantes.TypeMontant.HQDerog ||
                                                                             x.TypeJours == OutilCommun.Constantes.TypeMontant.LocaliteDerog).OrderByDescending(
                    x => x.RSS == codeRSS).ThenBy(x => string.IsNullOrWhiteSpace(x.RSS)).ThenBy(x => x.RSS).ThenBy(x => x.TypeJours).ThenBy(x => x.Mois.HasValue == false).ThenBy(x => x.Mois).ToList();

                extrant.JourneesFactTerritoire = extrant.JourneesFactTerritoire.Where(x => x.TypeJours == OutilCommun.Constantes.TypeMontant.HQ ||
                                                                                         x.TypeJours == OutilCommun.Constantes.TypeMontant.PremDpnagLoc ||
                                                                                         x.TypeJours == OutilCommun.Constantes.TypeMontant.Localite ||
                                                                                         x.TypeJours == OutilCommun.Constantes.TypeMontant.Total ||
                                                                                         x.TypeJours == OutilCommun.Constantes.TypeMontant.TotalDerog ||
                                                                                         x.TypeJours == OutilCommun.Constantes.TypeMontant.HQDerog ||
                                                                                         x.TypeJours == OutilCommun.Constantes.TypeMontant.LocaliteDerog).OrderByDescending(
                  x => x.CodeRSS == codeRSS).ThenBy(x => string.IsNullOrWhiteSpace(x.CodeRSS)).ThenBy(x => x.CodeRSS).ThenBy(x => x.NumeroSeqRegrAdmnLGEO).ThenBy(x => x.TypeLieuGeographique).ThenBy(x => x.TypeJours).ThenBy(x => x.Mois.HasValue == false).ThenBy(x => x.Mois).ToList();


                TempData[CleJourneesFacturerRss] = extrant.JourneesFactRSS;
                TempData[CleJourneesFacturerTerritoire] = extrant.JourneesFactTerritoire;


                TempData.Keep(CleNumeroSequenceProfessionnel);
                return Json(extrant);
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        /// <summary>
        /// Permet d'obtenir la pratique exclusive
        /// </summary>
        /// <param name="periode">Période</param>
        /// <param name="anneeSelectionner">Année</param>
        /// <returns>Liste de pratique exclusive</returns>
        [HttpPost]
        [AjaxRequest()]
        [Autor(Operation = "PRE_CnsulProfiProf;PRE_CnsulSuppo")]
        public JsonResult ObtenirPratiqueExclusive(Periode periode,
                                                   int anneeSelectionner)
        {
            try
            {
                DateTime dateDebut;

                if (periode.DateDebut.Value.Year != anneeSelectionner)
                {
                    periode.DateDebut = new DateTime(anneeSelectionner, 3, 1);
                }

                var dateFin = ObtenirDateFinPREM(periode.DateDebut.Value, periode.DateFin);


                if (!ValiderAnneeSituerDansPeriode(anneeSelectionner, periode.DateDebut.Value.Year, dateFin.Year))
                {
                    dateDebut = new DateTime(anneeSelectionner, 3, 1);
                    dateFin = dateDebut.AddYears(1).AddDays(-1);
                }
                else
                {
                    dateDebut = periode.DateDebut.Value;
                }

                var extrant = _professionnelFactory.Instancier().CalculerNombreJourneeFacturation(
                    new CalculerNbrJrFactProfsEntre()
                    {
                        NumerosSequentielsProfs = new List<long>() { (long)TempData[CleNumeroSequenceProfessionnel] },
                        DateDebut = dateDebut,
                        DateFin = dateFin,
                        ObtenirListeInter = true,
                        ObtenirListeIntra = false,
                        ObtenirListeRespectEngag = false,
                        ObtenirListeRPPR = false
                    });


                extrant.JourneesFactRSS = extrant.JourneesFactRSS.Where(x => x.TypeJours == OutilCommun.Constantes.TypeMontant.IVN ||
                                                                                           x.TypeJours == OutilCommun.Constantes.TypeMontant.TotalPratiqueExclusive ||
                                                                                           x.TypeJours == OutilCommun.Constantes.TypeMontant.Dpnag).OrderBy(
                  x => string.IsNullOrWhiteSpace(x.RSS)).ThenBy(x => x.RSS).ThenBy(x => x.TypeJours).ThenBy(x => x.Mois.HasValue == false).ThenBy(x => x.Mois).ToList();


                TempData[CleJourneesFacturerRss] = extrant.JourneesFactRSS;

                TempData.Keep(CleNumeroSequenceProfessionnel);
                return Json(extrant.JourneesFactRSS);

            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        /// <summary>
        /// Permet d'obtenir la valeur précise dans la liste des journées facturé par RSS
        /// </summary>
        /// <param name="critereRecherche">Critères de recherche</param>
        /// <returns>Valeur trouvé</returns>
        [HttpPost]
        [AjaxRequest()]
        [Autor(Operation = "PRE_CnsulProfiProf;PRE_CnsulSuppo")]
        public JsonResult ObtenirValeurListeJourneesFacturerRSS(CritereRechercheJourneeFacturerRSS critereRecherche)
        {

            try
            {

                var valeur = string.Empty;

                var journeesFacturerRSS = ((IEnumerable)TempData[CleJourneesFacturerRss]).Cast<JoursFactRSS>().ToList();

                var journeeFacturer = journeesFacturerRSS.FirstOrDefault(x => x.TypeJours == critereRecherche.TypeJour &&
                                                                              x.Annee == critereRecherche.Annee &&
                                                                              x.Mois == critereRecherche.Mois &&
                                                                              x.RSS == critereRecherche.RSS);

                if (journeeFacturer == null)
                {
                    journeeFacturer = new JoursFactRSS();
                }

                journeeFacturer.Pourcentage = Math.Round(journeeFacturer.Pourcentage, 2, MidpointRounding.AwayFromZero);

                TempData.Keep(CleJourneesFacturerRss);

                return Json(journeeFacturer);

            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        /// <summary>
        /// Permet d'obtenir la valeur précise dans la liste des journées facturé par territoire
        /// </summary>
        /// <param name="critereRecherche">Critères de recherche</param>
        /// <returns>Valeur trouvé</returns>
        [HttpPost]
        [AjaxRequest()]
        [Autor(Operation = "PRE_CnsulProfiProf;PRE_CnsulSuppo")]
        public JsonResult ObtenirValeurListeJourneesFacturerTerritoire(CritereRechercheJourneeFacturerTerritoire critereRecherche)
        {
            try
            {
                var valeur = string.Empty;

                var journeesFacturerTerritoire = ((IEnumerable)TempData[CleJourneesFacturerTerritoire]).Cast<JoursFactTerritoire>().ToList();

                var journeeFacturer = journeesFacturerTerritoire.FirstOrDefault(x => x.TypeJours == critereRecherche.TypeJour &&
                                                                                x.Annee == critereRecherche.Annee &&
                                                                                x.Mois == critereRecherche.Mois &&
                                                                                x.CodeLieuGeographique == critereRecherche.CodeLieuGeo &&
                                                                                x.TypeLieuGeographique == critereRecherche.TypeLieuGeo &&
                                                                                x.NumeroSeqRegrAdmnLGEO == critereRecherche.NumeroSequenceRegroupementLieuGeo);
                if (journeeFacturer == null)
                {
                    journeeFacturer = new JoursFactTerritoire();
                }

                journeeFacturer.Pourcentage = Math.Round(journeeFacturer.Pourcentage, 2, MidpointRounding.AwayFromZero);

                TempData.Keep(CleJourneesFacturerTerritoire);

                return Json(journeeFacturer);

            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        /// <summary>
        /// Permet d'obtenir l'information d'un engagement
        /// </summary>
        /// <param name="numeroSequenceEngagement">Numéro de séquence de l'engagement</param>
        /// <returns>Engagement</returns>
        [HttpPost]
        [AjaxRequest()]
        [Autor(Operation = "PRE_CnsulProfiProf;PRE_CnsulSuppo")]
        public JsonResult ObtenirInformationEngagement(long? numeroSequenceEngagement)
        {
            try
            {

                var valeur = string.Empty;


                var engagementsPratiques = ((IEnumerable)TempData[CleEngagementPratiques]).Cast<EngagementPratique>().ToList();

                var engagementPratique = engagementsPratiques.First(x => x.NumeroSequence == numeroSequenceEngagement);

                TempData.Keep(CleEngagementPratiques);

                return Json(engagementPratique);
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }

        }

        /// <summary>
        /// Permet d'obtenir le nom du RSS selon le code RSS passé en paramètre
        /// </summary>
        /// <param name="codeRSS">Code RSS</param>
        /// <returns>Nom du RSS</returns>
        [HttpPost]
        [AjaxRequest()]
        [Autor(Operation = "PRE_CnsulProfiProf;PRE_CnsulSuppo")]
        public string ObtenirNomRSS(string codeRSS)
        {

            try
            {
                var domaineValeur = _domaineValeur.ObtenirNomRssDomaineValeur();

                return domaineValeur.First(x => x.ValBasse == codeRSS).ValDes;

            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }

        }

        /// <summary>
        /// Permet de valider si l'utilisateur est un DRMG
        /// </summary>
        /// <returns>Boolean</returns>
        [HttpPost]
        [AjaxRequest()]
        [Autor(Operation = "PRE_CnsulProfiProf;PRE_CnsulSuppo")]
        public bool ValiderDroitDRMG()
        {
            string nomCookieProfil = "TypeProfil";
            string typeProfil = Utilitaire.ObtenirCookie(nomCookieProfil);
            bool estGroupeDRMG = false;
            bool estGroupeSupport = Utilitaire.EstDansGroupe(Utilitaires.Configuration.GroupeSupport);


            var code = ObtenirCodeRSSUtilisateurCourant();

            estGroupeDRMG = (Utilitaire.EstDansGroupe(Utilitaires.Configuration.GroupeConsultationProfilPrem) && !code.InfoMsgTrait.Any() && !string.IsNullOrEmpty(code.CodeRSS));

            return (estGroupeSupport && typeProfil == "DRMG") || (estGroupeDRMG && !estGroupeSupport);
        }

        #endregion

        #region Opération Privée

        private string ObtenirEngagementActif(DateTime? dateDebutEngagement)
        {

            string engagementActif = "";
            var engagementPratiques = ((IEnumerable)TempData[CleEngagementPratiques]).Cast<EngagementPratique>().ToList();
            var nomsDerogationDomaineValeur = _domaineValeur.ObtenirNomTypeDerogationDomaineValeur();

            foreach (var derogation in engagementPratiques.Where(x => DateTime.Equals(x.Periode.DateDebut, dateDebutEngagement)))
            {
                if (derogation.Description == OutilCommun.Constantes.DescriptionTypeEngagement.TypeDerogation)
                {
                    if (!string.IsNullOrEmpty(derogation.Type))
                    {
                        //Engagement actif = Dérogation - Type
                        engagementActif = string.Format("{0} - {1}", derogation.Description, derogation.Type);
                    }
                }

                if (derogation.Description == OutilCommun.Constantes.DescriptionTypeEngagement.TypeAvisConformite)
                {
                    //Engagement actif = Dérogation - Territoire
                    engagementActif = (!string.IsNullOrEmpty(derogation.Territoire.Nom)) ? string.Format("{0} - {1}", OutilCommun.Constantes.DescriptionTypeEngagement.TypeAvisConformite, derogation.Territoire.Nom)
                                                                                          : OutilCommun.Constantes.DescriptionTypeEngagement.TypeAvisConformite;
                }
            }

            if (!engagementPratiques.Any())
            {
                //Engagemet actif = Absence d’avis
                engagementActif = OutilCommun.Constantes.DescriptionTypeEngagement.TypeAbsenceAvis;
            }
            TempData.Keep(CleEngagementPratiques);
            return engagementActif;
        }

        private List<int> ObtenirAnnees(List<EngagementPratique> engagementPratiques)
        {
            var annees = new List<int>();
            var dateDebut = default(DateTime?);
            var dateFin = default(DateTime?);
            var dateDuJour = DateTime.Now;
            var anneeDateDebut = default(int);

            foreach (var engagement in engagementPratiques.Where(x => x.Description != OutilCommun.Constantes.DescriptionTypeEngagement.TypeAvisRevoque))
            {
                dateDebut = engagement.Periode.DateDebut;
                dateFin = engagement.Periode.DateFin;

                if (dateFin.HasValue)
                {

                    for (int annee = dateDebut.Value.Year; annee <= dateFin.Value.Year; annee++)
                    {
                        // À partir du 1er avril, l’année actuelle doit être dans la liste, sinon elle n’y figure pas
                        if ((annee == dateDuJour.Year && dateDuJour >= new DateTime(annee, 4, 1)) || (annee != dateDuJour.Year))
                        {
                            annees.Add(annee);
                        }
                    }
                }
                else
                {
                    for (int annee = dateDebut.Value.Year; annee <= dateDuJour.Year; annee++)
                    {
                        // À partir du 1er avril, l’année actuelle doit être dans la liste, sinon elle n’y figure pas
                        if ((annee == dateDuJour.Year && dateDuJour >= new DateTime(annee, 4, 1)) || (annee != dateDuJour.Year))
                        {
                            annees.Add(annee);
                        }
                    }
                }

                anneeDateDebut = dateDebut.Value.AddYears(-1).Year;
                // Si le mois de la date de début est Janvier ou Février, considérer l'engagement commençant dans
                // l'année PREM précédente et que l'année est plus grand ou égale à 2004
                if ((dateDebut.Value.Month == 1 || dateDebut.Value.Month == 2) && anneeDateDebut >= 2004)
                {
                    annees.Add(anneeDateDebut);
                }
            }

            return annees;

        }

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

        private string DefinirPeriodeDroitExercice(DateTime? dateDebut,
                                                   DateTime? dateFin)
        {
            return dateFin.HasValue && dateFin.Value.Date < HeureSysteme.Now().Date ? string.Format("{0} au {1}", dateDebut.Value.ToLongDateString(), dateFin.Value.ToLongDateString()) : string.Format("{0} au - - - -", dateDebut.Value.ToLongDateString());

        }

        private string DefinirNomEngagement(EngagementPratique engagement)
        {
            if (engagement.Description == OutilCommun.Constantes.DescriptionTypeEngagement.TypeDerogation)
            {
                /*
                *prise en compte de la demande 26 : Lors de la sélection du type d'engagement, le libellé "IVN" doit être remplacé par "Dérogation - Instance à vocation nationale"
                *et le libellé "Dépannage" doit être remplacé par "Dérogation - Dépannage"
                */
                return engagement.Type == "IVN" ? "Dérogation - Instance à vocation nationale" : "Dérogation - Dépannage";

            }
            else if (engagement.Description == OutilCommun.Constantes.DescriptionTypeEngagement.TypeAbsenceAvis)
            {
                return "Absence d’avis de conformité";
            }
            else
            {
                return string.IsNullOrEmpty(engagement.Territoire.Nom) ? engagement.Description : string.Format("{0} - {1}", engagement.Description, engagement.Territoire.Nom);
            }
        }

        private DateTime ObtenirDateFinPREM(DateTime dateDebut,
                                            DateTime? dateFin)
        {
            var dateDebutAnnee = dateDebut.Year;
            var dateFinControle = new DateTime(dateDebutAnnee + 1, 3, 1).AddDays(-1);

            if (dateFin.HasValue)
            {
                if (dateFin.Value > dateFinControle)
                {
                    return dateFinControle;
                }
                return dateFin.Value;
            }
            else
            {
                return dateFinControle;
            }
        }

        private bool ValiderAnneeSituerDansPeriode(int annee,
                                                   int anneeDebut,
                                                   int anneeFin)
        {

            if (annee <= anneeFin &&
                   anneeDebut <= annee)
            {
                return true;
            }

            return false;
        }

        private bool ValiderDateSituerDansPeriode(DateTime date,
                                                  DateTime dateDebut,
                                                  DateTime dateFin)
        {

            if (date <= dateFin &&
                   dateDebut <= date)
            {
                return true;
            }

            return false;
        }


        #endregion

        #region Opération publique

        /// <summary>
        /// Permet d'obtenir le code RSS de l'utilisateur courant
        /// </summary>
        /// <returns>Code RSS</returns>
        /// <remarks>La méthode est public pour est utiliser dans la view</remarks>
        [Autor(Operation = "PRE_CnsulProfiProf;PRE_CnsulSuppo")]
        public CodeRSSUtilisateur ObtenirCodeRSSUtilisateurCourant()
        {
            return _securite.ObtenirCodeRSSUtilisateurCourant();
        }

        #endregion


    }
}