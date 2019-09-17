using System.Web.Mvc;
using RAMQ.Web.MVC.Attributs;
using RAMQ.PRE.PL_Prem_iut.Models.PLC1_ConsulterRappPrem;
using RAMQ.Web.MVC.Controleurs;
using RAMQ.PRE.PL_PremMdl_cpo.LieuGeographique;
using System.Linq;
using System;
using System.Collections.Generic;
using RAMQ.PRE.PL_Prem_iut.Entite;
using RAMQ.PRE.PL_PremMdl_cpo.Rapport;
using OutilCommun = RAMQ.PRE.PRE_OutilComun_cpo;
using RAMQ.PRE.PRE_Entites_cpo.Rapport.Entite;
using RAMQ.PRE.PL_Prem_iut.Utilitaires;

namespace RAMQ.PRE.PL_Prem_iut.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    [Autor(Operation = "PRE_CnsulRapport;PRE_CnsulSuppo")]
    public class RapportController : ControleurBase, IController
    {
        private readonly IRapportFactory _rapportFactory;
        private readonly Securite.ISecurite _securite;
        private readonly ILieuGeographiqueFactory _lieuGeographiqueFactory;
        private readonly OutilCommun.IDomaineValeur _domaineValeur;

        const string NomComiteParitaire = "Comité paritaire";
        const string NomCookieProfil = "TypeProfil";

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="rapportFactory"></param>
        /// <param name="lieuGeographiqueFactory"></param>
        /// <param name="securite"></param>
        /// <param name="domaineValeur"></param>
        public RapportController(IRapportFactory rapportFactory, ILieuGeographiqueFactory lieuGeographiqueFactory, Securite.ISecurite securite, OutilCommun.IDomaineValeur domaineValeur)
        {
            _rapportFactory = rapportFactory;
            _securite = securite;
            _lieuGeographiqueFactory = lieuGeographiqueFactory;
            _domaineValeur = domaineValeur;
        }

        #region Dérogation Pratique Exclusive

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ActionName(Constantes.NomAction.PLC1.RapportDerogPratiExclu)]

        public ActionResult ConsulterRapportDerogPratiExclu(PLC1_DerogPratiExclu modelRapport)
        {
            modelRapport.ListAnnees = ObtenirSelectListDepuisAnnee(Constantes.NomAction.PLC1.AnneeDebutRapportsPREM).OrderBy(x => x.Value).ToList();
            modelRapport.ListTypesPratique = ObtenirSelectListPratiques();

            if (modelRapport.Annee == 0) { 
                modelRapport.Annee = DateTime.Now.Year;
            }

            var paramEntreObtnLignesRapp = new PRE_Entites_cpo.Rapport.Parametre.ParamObtnrRappDerogPratiExclu();

            paramEntreObtnLignesRapp.Annee = modelRapport.Annee;
            paramEntreObtnLignesRapp.TypePratique = modelRapport.TypePratique;

            var paramSortiObtnLignesRapp = _rapportFactory.Instancier().ObtenirRapportDerogPratiExcluWeb(paramEntreObtnLignesRapp);

            if (!paramSortiObtnLignesRapp.InfoMsgTrait.Any())
            {
                modelRapport.LignesRapport = new List<LigneRapportDerogPratiExclu>(paramSortiObtnLignesRapp.LignesRapport);
                modelRapport.NombreDispensateursRetournes = modelRapport.LignesRapport.Select(x => x.NumeroPratique).Distinct().Count();
                modelRapport.DateDebutRapport = paramSortiObtnLignesRapp.DateDebutPeriode;
                modelRapport.DateFinRapport = paramSortiObtnLignesRapp.DateFinPeriode;
                //On remplace le type de la pratique affiché par le nom courant
                modelRapport.LignesRapport.ForEach(x => x.TypePratique = modelRapport.ListTypesPratique.FirstOrDefault(y => y.Value == x.TypePratique).Text);
            }
            else
            {
                foreach (var msg in paramSortiObtnLignesRapp.InfoMsgTrait)
                {
                    if (msg.CodSever != "Q")
                    {
                        ModelState.AddModelError(string.Empty, msg.TxtMsgFran);
                    }
                }
            }



            return View(modelRapport);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        [ActionName(Constantes.NomAction.PLC1.RapportDerogPratiExclu)]
        public ActionResult FiltrerRapportDerogPratiExclu(PLC1_DerogPratiExclu modelRapport)
        {
            return RedirectToAction(Constantes.NomAction.PLC1.RapportDerogPratiExclu, modelRapport);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ActionName(Constantes.NomAction.PLC1.RapportDerogPratiExclu + Constantes.NomAction.PLC1.RapportPdf)]
        public ActionResult ConsulterRapportDerogPratiExcluPdf(PLC1_DerogPratiExclu modelRapport)
        {
            return ObtenirRapportDerogPratiExcluFichier(modelRapport, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport.PDF);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ActionName(Constantes.NomAction.PLC1.RapportDerogPratiExclu + Constantes.NomAction.PLC1.RapportXml)]
        public ActionResult ConsulterRapportDerogPratiExcluXml(PLC1_DerogPratiExclu modelRapport)
        {
            return ObtenirRapportDerogPratiExcluFichier(modelRapport, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport.XML);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelRapport"></param>
        /// <param name="typeFichier"></param>
        /// <returns></returns>
        public ActionResult ObtenirRapportDerogPratiExcluFichier(PLC1_DerogPratiExclu modelRapport, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport typeFichier)
        {
            var paramEntreObtnLignesRapp = new PRE_Entites_cpo.Rapport.Parametre.ParamObtnrRappDerogPratiExclu()
            {
                Annee = Convert.ToInt32(modelRapport.Annee),
                TypePratique = modelRapport.TypePratique
            };

            var paramSortiObtnLignesRapp = _rapportFactory.Instancier().ObtenirRapportDerogPratiExcluFichier(paramEntreObtnLignesRapp, typeFichier);

            return File(paramSortiObtnLignesRapp.ContenuFichier, paramSortiObtnLignesRapp.TypeContenu, paramSortiObtnLignesRapp.NomFichier);
        }

        #endregion

        #region Non-respect de l'avis de conformité

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ActionName(Constantes.NomAction.PLC1.RapportNonRespectAvisConf)]
        public ActionResult ConsulterRapportNonRespectAvisConf(PLC1_NonRespAvisConf modelRapport)
        {
            modelRapport.EstDRMG = DeterminerSiUtilEstDRMG();

            var paramEntreObtnLignesRapp = new PRE_Entites_cpo.Rapport.Parametre.ParamObtnrRappNonRespAvisConf();

            modelRapport.ListAnnees = ObtenirSelectListDepuisAnnee(Constantes.NomAction.PLC1.AnneeDebutRapportsPREM).OrderBy(x => x.Value).ToList();
            modelRapport.ListRegions = ObtenirListeRegions().OrderBy(x => x.Value).ToList();

            if (modelRapport.Annee == 0) {
                modelRapport.Annee = DateTime.Now.Year;
            }
            if (modelRapport.EstDRMG == true)
            {
                var codeRssUtilConnecte = ObtenirCodeRSS();
                if (!string.IsNullOrEmpty(codeRssUtilConnecte))
                {
                    modelRapport.Region = codeRssUtilConnecte;
                }
            }
            if (modelRapport.Region == null) {
                modelRapport.ListSousTerritoires = new List<SelectListItem>()
                {
                    new SelectListItem()
                    {
                        Text = "Tous",
                        Value = ""
                    }
                };

                modelRapport.SousTerritoire = null;
            }
            else
            {
                modelRapport.ListSousTerritoires = ObtenirListeTerritoires(modelRapport.Region, modelRapport.Annee);
                
                if(!modelRapport.ListSousTerritoires.Any(x => x.Value == modelRapport.SousTerritoire))
                {
                    modelRapport.SousTerritoire = null;
                }
            }

            

            paramEntreObtnLignesRapp.Annee = modelRapport.Annee;
            paramEntreObtnLignesRapp.Region = modelRapport.Region;
            paramEntreObtnLignesRapp.SousTerritoire = modelRapport.SousTerritoire;

            var paramSortiObtnLignesRapp = _rapportFactory.
                                                Instancier()
                                                .ObtenirRapportNonRespAvisConfWeb(paramEntreObtnLignesRapp);

            if (!paramSortiObtnLignesRapp.InfoMsgTrait.Any())
            {
                modelRapport.LignesRapport = new List<LigneRapportNonRespAvisConf>(paramSortiObtnLignesRapp.LignesRapport);
                modelRapport.NombreDispensateursRetournes = modelRapport.LignesRapport.Select(x => x.NumeroPratique).Distinct().Count();
                modelRapport.DateDebutRapport = paramSortiObtnLignesRapp.DateDebutPeriode;
                modelRapport.DateFinRapport = paramSortiObtnLignesRapp.DateFinPeriode;
            }
            else
            {
                foreach (var msg in paramSortiObtnLignesRapp.InfoMsgTrait)
                {
                    if (msg.CodSever != "Q")
                    {
                        ModelState.AddModelError(string.Empty, msg.TxtMsgFran);
                    }
                }
            }

            return View(modelRapport);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        [ActionName(Constantes.NomAction.PLC1.RapportNonRespectAvisConf)]
        public ActionResult FiltrerRapportNonRespAvisConf(PLC1_NonRespAvisConf modelRapport)
        {
            return RedirectToAction(Constantes.NomAction.PLC1.RapportNonRespectAvisConf, modelRapport);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ActionName(Constantes.NomAction.PLC1.RapportNonRespectAvisConf + Constantes.NomAction.PLC1.RapportPdf)]
        public ActionResult ConsulterRapportNonRespAvisConfPdf(PLC1_NonRespAvisConf modelRapport)
        {
            return ObtenirRapportNonRespAvisConfFichier(modelRapport, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport.PDF);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ActionName(Constantes.NomAction.PLC1.RapportNonRespectAvisConf + Constantes.NomAction.PLC1.RapportXml)]
        public ActionResult ConsulterRapportNonRespAvisConfXml(PLC1_NonRespAvisConf modelRapport)
        {
            return ObtenirRapportNonRespAvisConfFichier(modelRapport, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport.XML);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelRapport"></param>
        /// <param name="typeFichier"></param>
        /// <returns></returns>
        public ActionResult ObtenirRapportNonRespAvisConfFichier(PLC1_NonRespAvisConf modelRapport, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport typeFichier)
        {
            var paramEntreObtnLignesRapp = new PRE_Entites_cpo.Rapport.Parametre.ParamObtnrRappNonRespAvisConf()
            {
                Annee = modelRapport.Annee,
                Region = modelRapport.Region,
                SousTerritoire = modelRapport.SousTerritoire
            };

            var paramSortiObtnLignesRapp = _rapportFactory.Instancier().ObtenirRapportNonRespAvisConfFichier(paramEntreObtnLignesRapp, typeFichier);

            return File(paramSortiObtnLignesRapp.ContenuFichier, paramSortiObtnLignesRapp.TypeContenu, paramSortiObtnLignesRapp.NomFichier);
        }

        #endregion

        #region Exercice non autorisé en RPPR (NonRespectPrcRPPR)

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ActionName(Constantes.NomAction.PLC1.RapportExerNonAutoRPPR)]
        public ActionResult ConsulterRapportExerNonAutoRPPR(PLC1_ExerNonAutoRPPR modelRapport)
        {
            modelRapport.EstDRMG = DeterminerSiUtilEstDRMG();

            var paramEntreObtnLignesRapp = new PRE_Entites_cpo.Rapport.Parametre.ParamObtnrRappExerNonAutoRPPR();


            modelRapport.ListAnnees = ObtenirSelectListDepuisAnnee(Constantes.NomAction.PLC1.AnneeDebutRapportsPREM).OrderBy(x => x.Value).ToList();
            modelRapport.ListRegions = ObtenirListeRegions().OrderBy(x => x.Value).ToList();

            if (modelRapport.Annee == 0){
                var dateAujourdhui = DateTime.Now;
                modelRapport.Annee = dateAujourdhui.Month < 3 ? dateAujourdhui.Year-1 : dateAujourdhui.Year;
            }
            if (modelRapport.EstDRMG == true){
                var codeRssUtilConnecte = ObtenirCodeRSS();
                if (!string.IsNullOrEmpty(codeRssUtilConnecte))
                {
                    modelRapport.Region = codeRssUtilConnecte;
                }
            }

            paramEntreObtnLignesRapp.Annee = modelRapport.Annee;
            paramEntreObtnLignesRapp.Region = modelRapport.Region;

            var paramSortiObtnLignesRapp = _rapportFactory
                                                .Instancier()
                                                .ObtenirRapportExerNonAutoRPPRWeb(paramEntreObtnLignesRapp);

            if (!paramSortiObtnLignesRapp.InfoMsgTrait.Any())
            {
                modelRapport.LignesRapport = new List<LigneRapportExerNonAutoRPPR>(paramSortiObtnLignesRapp.LignesRapport);
                modelRapport.DateDebutRapport = paramSortiObtnLignesRapp.DateDebutPeriode;
                modelRapport.DateFinRapport = paramSortiObtnLignesRapp.DateFinPeriode;
            }
            else
            {
                foreach (var msg in paramSortiObtnLignesRapp.InfoMsgTrait)
                {
                    if (msg.CodSever != "Q")
                    {
                        ModelState.AddModelError(string.Empty, msg.TxtMsgFran);
                    }
                }
            }

            return View(modelRapport);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        [ActionName(Constantes.NomAction.PLC1.RapportExerNonAutoRPPR)]
        public ActionResult FiltrerRapportNonRespPourcMaxReconRPPR(PLC1_ExerNonAutoRPPR modelRapport)
        {
            return RedirectToAction(Constantes.NomAction.PLC1.RapportExerNonAutoRPPR, modelRapport);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ActionName(Constantes.NomAction.PLC1.RapportExerNonAutoRPPR + Constantes.NomAction.PLC1.RapportPdf)]
        public ActionResult ConsulterRapportNonRespPourcMaxReconRPPRPdf(PLC1_ExerNonAutoRPPR modelRapport)
        {
            return ObtenirRapportExerNonAutoRPPRFichier(modelRapport, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport.PDF);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ActionName(Constantes.NomAction.PLC1.RapportExerNonAutoRPPR + Constantes.NomAction.PLC1.RapportXml)]
        public ActionResult ConsulterRapportNonRespPourcMaxReconRPPRXml(PLC1_ExerNonAutoRPPR modelRapport)
        {
            return ObtenirRapportExerNonAutoRPPRFichier(modelRapport, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport.XML);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelRapport"></param>
        /// <param name="typeFichier"></param>
        /// <returns></returns>
        public ActionResult ObtenirRapportExerNonAutoRPPRFichier(PLC1_ExerNonAutoRPPR modelRapport, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport typeFichier)
        {
            var paramEntreObtnLignesRapp = new PRE_Entites_cpo.Rapport.Parametre.ParamObtnrRappExerNonAutoRPPR()
            {
                Annee = modelRapport.Annee,
                Region = modelRapport.Region
            };

            var paramSortiObtnLignesRapp = _rapportFactory.Instancier().ObtenirRapportExerNonAutoRPPRFichier(paramEntreObtnLignesRapp, typeFichier);

            return File(paramSortiObtnLignesRapp.ContenuFichier, paramSortiObtnLignesRapp.TypeContenu, paramSortiObtnLignesRapp.NomFichier);
        }

        #endregion

        #region Répartition inter-regionale de la pratique

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ActionName(Constantes.NomAction.PLC1.RapportRepartInterRegionPrati)]
        public ActionResult ConsulterRapportRepartInterRegionPrati(PLC1_RepartInterRegionPrati modelRapport)
        {
            modelRapport.EstDRMG = DeterminerSiUtilEstDRMG();

            var paramEntreObtnLignesRapp = new PRE_Entites_cpo.Rapport.Parametre.ParamObtnrRappRepartInterRegionPrati();

            modelRapport.ListAnnees = ObtenirSelectListDepuisAnnee(Constantes.NomAction.PLC1.AnneeDebutRapportsPREM).OrderBy(x => x.Value).ToList();
            modelRapport.ListRegions = ObtenirListeRegions().OrderBy(x => x.Value).ToList();

            if (modelRapport.Annee == 0){
                modelRapport.Annee = DateTime.Now.Year;
            }
            if (modelRapport.EstDRMG == true){
                var codeRssUtilConnecte = ObtenirCodeRSS();
                if (!string.IsNullOrEmpty(codeRssUtilConnecte))
                {
                    modelRapport.Region = codeRssUtilConnecte;
                }
            }
            if (modelRapport.Region == null){
                modelRapport.ListSousTerritoires = new List<SelectListItem>()
                {
                    new SelectListItem()
                    {
                        Text = "Tous",
                        Value = ""
                    }
                };
                modelRapport.SousTerritoire = null;
            }
            else
            {
                modelRapport.ListSousTerritoires = ObtenirListeTerritoires(modelRapport.Region, modelRapport.Annee);

                if (!modelRapport.ListSousTerritoires.Any(x => x.Value == modelRapport.SousTerritoire))
                {
                    modelRapport.SousTerritoire = null;
                }
            }



            paramEntreObtnLignesRapp.Annee = modelRapport.Annee;
            paramEntreObtnLignesRapp.Region = modelRapport.Region;
            paramEntreObtnLignesRapp.SousTerritoire = modelRapport.SousTerritoire;

            var paramSortiObtnLignesRapp = _rapportFactory.
                                                Instancier()
                                                .ObtenirRapportRepartInterRegionPratiWeb(paramEntreObtnLignesRapp);

            if (!paramSortiObtnLignesRapp.InfoMsgTrait.Any())
            {
                modelRapport.LignesRapport = new List<LigneRapportRepartInterRegionPrati>(paramSortiObtnLignesRapp.LignesRapport);
                modelRapport.NombreDispensateursRetournes = modelRapport.LignesRapport.Select(x => x.NumeroPratique).Distinct().Count();
                modelRapport.DateDebutRapport = paramSortiObtnLignesRapp.DateDebutPeriode;
                modelRapport.DateFinRapport = paramSortiObtnLignesRapp.DateFinPeriode;
            }
            else
            {
                foreach (var msg in paramSortiObtnLignesRapp.InfoMsgTrait)
                {
                    if (msg.CodSever != "Q")
                    {
                        ModelState.AddModelError(string.Empty, msg.TxtMsgFran);
                    }
                }
            }

            return View(modelRapport);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        [ActionName(Constantes.NomAction.PLC1.RapportRepartInterRegionPrati)]
        public ActionResult FiltrerRapportRepartInterRegionPrati(PLC1_RepartInterRegionPrati modelRapport)
        {
            return RedirectToAction(Constantes.NomAction.PLC1.RapportRepartInterRegionPrati, modelRapport);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ActionName(Constantes.NomAction.PLC1.RapportRepartInterRegionPrati + Constantes.NomAction.PLC1.RapportPdf)]
        public ActionResult ConsulterRapportRepartInterRegionPratiPdf(PLC1_RepartInterRegionPrati modelRapport)
        {
            return ObtenirRapportRepartInterRegionPratiFichier(modelRapport, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport.PDF);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ActionName(Constantes.NomAction.PLC1.RapportRepartInterRegionPrati + Constantes.NomAction.PLC1.RapportXml)]
        public ActionResult ConsulterRapportRepartInterRegionPratiXml(PLC1_RepartInterRegionPrati modelRapport)
        {
            return ObtenirRapportRepartInterRegionPratiFichier(modelRapport, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport.XML);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelRapport"></param>
        /// <param name="typeFichier"></param>
        /// <returns></returns>
        public ActionResult ObtenirRapportRepartInterRegionPratiFichier(PLC1_RepartInterRegionPrati modelRapport, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport typeFichier)
        {
            var paramEntreObtnLignesRapp = new PRE_Entites_cpo.Rapport.Parametre.ParamObtnrRappRepartInterRegionPrati()
            {
                Annee = modelRapport.Annee,
                Region = modelRapport.Region
            };

            var paramSortiObtnLignesRapp = _rapportFactory.Instancier().ObtenirRapportRepartInterRegionPratiFichier(paramEntreObtnLignesRapp, typeFichier);

            return File(paramSortiObtnLignesRapp.ContenuFichier, paramSortiObtnLignesRapp.TypeContenu, paramSortiObtnLignesRapp.NomFichier);
        }

        #endregion





        #region Absence Avis Conformité

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet()]
        //[ActionName(Constantes.NomAction.PLC1.RapportAbsenceAvis)]
        //public ActionResult ConsulterRapportAbsenceAvis(PLC1_AbsncAvisConf modelRapport)
        //{
        //    if (modelRapport == null)
        //    {
        //        modelRapport = new PLC1_AbsncAvisConf();
        //    }

        //    var codeRss = ObtenirCodeRSS();

        //    modelRapport.ListAnnees = ObtenirSelectListDixDernieresAnnees();
        //    modelRapport.ListTrimestres = ObtenirSelectListTrimestres();
        //    modelRapport.ListSousTerritoires = ObtenirListeTerritoires(codeRss);
        //    modelRapport.ListRegions = ObtenirListeRegions(codeRss);

        //    if (modelRapport.Annee == null)
        //    {
        //        modelRapport.Annee = DateTime.Now.Year.ToString();
        //    }
        //    if (modelRapport.Trimestre == null)
        //    {
        //        modelRapport.Trimestre = "T1";
        //    }
        //    if (modelRapport.SousTerritoire == null)
        //    {
        //        modelRapport.SousTerritoire = "Tous";
        //    }
        //    if (modelRapport.Region == null)
        //    {
        //        modelRapport.Region = "Toutes";
        //    }

        //    int numTrimestre = ((DateTime.Now.Month / 3) + 1);
        //    modelRapport.Trimestre = $"T{numTrimestre.ToString()}";
        //    modelRapport.DateDebutTrimestre = ObtenirDateDebutTrimestre(numTrimestre, modelRapport.Annee);
        //    modelRapport.DateFinTrimestre = ObtenirDateFinTrimestre(numTrimestre, modelRapport.Annee);

        //    var paramEntreObtnLignesRapp = new PRE_Entites_cpo.Rapport.Parametre.ParamObtnrRappAbsncAvisConf();

        //    paramEntreObtnLignesRapp.Annee = int.Parse(modelRapport.Annee);
        //    paramEntreObtnLignesRapp.Region = modelRapport.Region;
        //    paramEntreObtnLignesRapp.SousTerritoire = modelRapport.SousTerritoire;
        //    paramEntreObtnLignesRapp.Trimestre = int.Parse(modelRapport.Trimestre);

        //    var paramSortiObtnLignesRapp = _rapportFactory.Instancier().ObtenirRapportAbsncAvisConfWeb(paramEntreObtnLignesRapp);

        //    if (!paramSortiObtnLignesRapp.InfoMsgTrait.Any())
        //    {
        //        modelRapport.LignesRapport = new List<PRE_Entites_cpo.Rapport.Entite.LigneRapportAbsncAvisConf>(paramSortiObtnLignesRapp.LignesRapport);
        //    }
        //    else
        //    {
        //        foreach (var msg in paramSortiObtnLignesRapp.InfoMsgTrait)
        //        {
        //            if (msg.CodSever != "Q")
        //            {
        //                ModelState.AddModelError(string.Empty, msg.TxtMsgFran);
        //            }
        //        }
        //    }

        //    return View(modelRapport);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost()]
        //[ActionName(Constantes.NomAction.PLC1.RapportAbsenceAvis)]
        //public ActionResult FiltrerRapportAbsenceAvis(PLC1_AbsncAvisConf modelRapport)
        //{
        //    return RedirectToAction(Constantes.NomAction.PLC1.RapportAbsenceAvis, modelRapport);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet()]
        //[ActionName(Constantes.NomAction.PLC1.RapportAbsenceAvis + Constantes.NomAction.PLC1.RapportPdf)]
        //public ActionResult ConsulterRapportAbsenceAvisPdf(PLC1_AbsncAvisConf modelRapport)
        //{
        //    return ObtenirRapportAbsenceAvisFichier(modelRapport, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport.PDF);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet()]
        //[ActionName(Constantes.NomAction.PLC1.RapportAbsenceAvis + Constantes.NomAction.PLC1.RapportXml)]
        //public ActionResult ConsulterRapportAbsenceAvisXml(PLC1_AbsncAvisConf modelRapport)
        //{
        //    return ObtenirRapportAbsenceAvisFichier(modelRapport, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport.XML);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="modelRapport"></param>
        ///// <param name="typeFichier"></param>
        ///// <returns></returns>
        //public ActionResult ObtenirRapportAbsenceAvisFichier(PLC1_AbsncAvisConf modelRapport, PRE_Entites_cpo.Enumerations.TypeFichierSortieRapport typeFichier)
        //{
        //    var paramEntreObtnLignesRapp = new PRE_Entites_cpo.Rapport.Parametre.ParamObtnrRappAbsncAvisConf()
        //    {
        //        Annee = int.Parse(modelRapport.Annee),
        //        Region = modelRapport.Region,
        //        SousTerritoire = modelRapport.SousTerritoire,
        //        Trimestre = int.Parse(modelRapport.Trimestre)
        //    };

        //    var paramSortiObtnLignesRapp = _rapportFactory.Instancier().ObtenirRapportAbsncAvisConfFichier(paramEntreObtnLignesRapp, typeFichier);

        //    return File(paramSortiObtnLignesRapp.ContenuFichier, paramSortiObtnLignesRapp.TypeContenu);
        //}

        #endregion


        

        



        #region Helpers

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

        private bool DeterminerSiUtilEstDRMG()
        {
            var estDRMG = false;
            try
            {
                var codeRssDrmg = _securite.ObtenirCodeRSSUtilisateurCookie();
                if (Utilitaire.ObtenirCookie(NomCookieProfil) == NomComiteParitaire || codeRssDrmg.InfoMsgTrait.Any())
                {
                    estDRMG = false;
                }
                else
                {
                    //On a vérifié que le cookie est bien setté, on peut donc forcer les utilisateurs du support à être considérés comme des DRMG
                    if (Utilitaire.EstDansGroupe(Utilitaires.Configuration.GroupeSupport) || Utilitaire.EstDansGroupe(Utilitaires.Configuration.GroupeDRMG))
                    {
                        estDRMG = true;
                    }
                }
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }

            return estDRMG;
        }

        private List<SelectListItem> ObtenirSelectListDepuisAnnee(int annee)
        {
            var listeRetournee = new List<SelectListItem>();
            var listeAnnees = Utilitaires.Utilitaire.ObtenirListeAnneesDepuisAnnee(annee);

            for (int i = 0; i < listeAnnees.Count; i++)
            {
                listeRetournee.Add(new SelectListItem()
                {
                    Text = listeAnnees[i].ToString(),
                    Value = listeAnnees[i].ToString()
                });
            }

            return listeRetournee;
        }

        private List<SelectListItem> ObtenirSelectListPratiques()
        {
            var listeRetournee = new List<SelectListItem>();

            var listeTypes = _domaineValeur.ObtenirNomTypeDerogationDomaineValeur();

            listeRetournee.Add(new SelectListItem()
            {
                Text = "Tous",
                Value = ""
            });

            foreach (var typeDerogation in listeTypes)
            {
                listeRetournee.Add(new SelectListItem()
                {
                    Text = typeDerogation.ValAbr,
                    Value = typeDerogation.ValBasse
                });
            }

            return listeRetournee;
        }

        private List<SelectListItem> ObtenirSelectListTrimestres()
        {
            var listeRetournee = new List<SelectListItem>();

            for (int i = 1; i < 4; i++)
            {
                listeRetournee.Add(new SelectListItem()
                {
                    Text = $"Trimestre {i}",
                    Value = $"T{i}"
                });
            }

            return listeRetournee;
        }

        private DateTime ObtenirDateDebutTrimestre(int numTrimestre, string annee)
        {
            DateTime dateRetour = DateTime.MaxValue;
            DateTime dtNow = System.DateTime.Now;
            if (numTrimestre == 1)
            {
                dateRetour = DateTime.Parse("1/1/" + annee);
            }
            else if (numTrimestre == 2)
            {
                dateRetour = DateTime.Parse("4/1/" + annee);
            }
            else if (numTrimestre == 3)
            {
                dateRetour = DateTime.Parse("7/1/" + annee);
            }
            else if (numTrimestre == 4)
            {
                dateRetour = DateTime.Parse("10/1/" + annee);
            }
            return dateRetour;
        }

        private DateTime ObtenirDateFinTrimestre(int numTrimestre, string annee)
        {
            DateTime dateRetour = DateTime.MaxValue;
            DateTime dtNow = System.DateTime.Now;
            if (numTrimestre == 1)
            {
                dateRetour = DateTime.Parse("3/31/" + annee);
            }
            else if (numTrimestre == 2)
            {
                dateRetour = DateTime.Parse("6/30/" + annee);
            }
            else if (numTrimestre == 3)
            {
                dateRetour = DateTime.Parse("9/30/" + annee);
            }
            else if (numTrimestre == 4)
            {
                dateRetour = DateTime.Parse("12/31/" + annee);
            }
            return dateRetour;
        }

        private List<SelectListItem> ObtenirListeRegions()
        {
            var listeRegions = _domaineValeur.ObtenirNomRssDomaineValeur();

            var selectListRegions = new List<SelectListItem>();

            selectListRegions.Add(new SelectListItem()
            {
                Text = "Toutes",
                Value = ""
            });

            foreach (var region in listeRegions.OrderBy(x => x.ValBasse))
            {
                selectListRegions.Add(new SelectListItem()
                {
                    Text = region.ValBasse + " - " + region.ValDes,
                    Value = region.ValBasse
                });
            }

            return selectListRegions;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codeRSS"></param>
        /// <param name="anneePrem"></param>
        /// <returns></returns>
        [HttpGet()]
        [ActionName(Constantes.NomAction.PLC1.RapportObtenirTerritoires)]
        public JsonResult ObtenirTerritoires(string codeRSS, int anneePrem)
        {
            return Json(ObtenirListeTerritoires(codeRSS, anneePrem), JsonRequestBehavior.AllowGet);
        }

        private List<SelectListItem> ObtenirListeTerritoires(string codeRSS, int anneePrem)
        {
            var listeRetournee = new List<SelectListItem>();

            listeRetournee.Add(
                    new SelectListItem()
                    {
                        Text = "Tous",
                        Value = ""
                    }
                 );

            if (codeRSS != null)
            {
                var listeNomsTerritoires = _lieuGeographiqueFactory
                        .Instancier()
                        .ObtenirRegroupementsLieuxGeographiquesRSS(
                            new PRE_Entites_cpo.LieuGeographique.Parametre.ObtenirRegroupementsLgeoRssEntre()
                            {
                                TypeRegroupement = "PREM",
                                NumeroDocumentOfficiel = "1177",
                                CodeRssRegionSocioSanitaire = codeRSS,
                                IndObtentionLgeo = false,
                                IndObtenirUniquementRegroupement = false,
                                DateRecherche = new DateTime(anneePrem, 3, 1)
                            });

                foreach (var territoire in listeNomsTerritoires.LieuxGeographiques.OrderBy(x => x.NomLieuGeographique))
                {
                    listeRetournee.Add(
                        new SelectListItem()
                        {
                            Text = territoire.NomLieuGeographique,
                            Value = territoire.CodeLieuGeographique
                        }
                     );
                }

                foreach (var territoire in listeNomsTerritoires.Regroupements.Where(x => x.TypeLieuGeographique != "RSS").OrderBy(x => x.Nom))
                {
                    listeRetournee.Add(
                        new SelectListItem()
                        {
                            Text = territoire.Nom,
                            Value = territoire.CodeRegroupement
                        }
                     );
                }
            }

            

            return listeRetournee;
        }


        #endregion


    }
}

