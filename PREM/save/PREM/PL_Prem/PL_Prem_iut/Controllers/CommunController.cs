using RAMQ.Message;
using RAMQ.PRE.PL_Prem_iut.Attributs;
using RAMQ.PRE.PL_Prem_iut.ControllersHelpers;
using RAMQ.PRE.PL_Prem_iut.Entite;
using RAMQ.PRE.PL_PremMdl_cpo.AvisConformite;
using RAMQ.PRE.PL_PremMdl_cpo.LieuGeographique;
using RAMQ.PRE.PL_PremMdl_cpo.Professionnel;
using RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Recherche.Entite;
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
    /// 
    /// </summary>
    [Autor(Operation = "PRE_SaisAvisConfDRMG;PRE_CnsulProfiProf;PRE_SaisDecisComtParit;PRE_CnsulSuppo;PRE_CreerDemReeva")]
    public class CommunController : ControleurBase, IController
    {
        #region Attributs privées

        private readonly IProfessionnelFactory _professionnelFactory;
        private readonly ILieuGeographiqueFactory _lieuGeographiqueFactory;
        private readonly Securite.ISecurite _securite;
        private readonly IAvisConformiteFactory _avisConformiteFactory;
        private readonly OutilCommun.IMessageTraitement _messageTraitement;
        private readonly IProfessionnelHelpers _utilitaireProfessionnel;
        private readonly ILieuGeographiqueHelpers _utilitaireLieuGeographique;

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="professionnelFactory"></param>
        /// <param name="lieuGeographiqueFactory"></param>
        /// <param name="securite"></param>
        /// <param name="avisConformite"></param>
        /// <param name="messageTraitement"></param>
        /// <param name="utilitaireProfessionnel">Injection de l'utilitaire des professionnels.</param>
        /// <param name="utilitaireLieuGeographique">Injection de l'utilitaire des lieux géographique.</param>
        public CommunController(IProfessionnelFactory professionnelFactory,
                                ILieuGeographiqueFactory lieuGeographiqueFactory,
                                Securite.ISecurite securite,
                                IAvisConformiteFactory avisConformite,
                                OutilCommun.IMessageTraitement messageTraitement,
                                IProfessionnelHelpers utilitaireProfessionnel,
                                ILieuGeographiqueHelpers utilitaireLieuGeographique)
        {
            _professionnelFactory = professionnelFactory;
            _lieuGeographiqueFactory = lieuGeographiqueFactory;
            _securite = securite;
            _avisConformiteFactory = avisConformite;
            _messageTraitement = messageTraitement;
            _utilitaireProfessionnel = utilitaireProfessionnel;
            _utilitaireLieuGeographique = utilitaireLieuGeographique;
        }

        #endregion

        #region Recherche professionnels

        /// <summary>
        /// Fonction utiliser avec AJAX pour retourner la liste des professionnels filtrer avec les caractères saisis
        /// </summary>
        /// <param name="intrant">Paramètres d'entré pour la recherche</param>
        /// <returns>Les résultat de la recherche</returns>
        [HttpPost()]
        [AjaxRequest()]
        public ActionResult ObtenirNumerosPratiqueJson(RechercheNumeroPratique intrant)
        {
            try
            {
                var filtre = new Critere
                {
                    LimiteParPage = intrant.LimiteParPage,
                    Page = intrant.Page,
                    Terme = intrant.Terme
                };

                var resultat = _professionnelFactory.Instancier()
                    .ObtenirNumerosPratiqueFiltre(intrant.ClassesProfessionnelUtilise,
                                                  filtre,
                                                  intrant.FiltreSpecialPourCreationAvis);

                if (resultat.InfoMsgTrait.Count > 0)
                {
                    throw new Exception(resultat.InfoMsgTrait.First().TxtMsgFran);
                }

                return Json(resultat);
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        /// <summary>
        /// Fonction utiliser avec AJAX pour retourner les informations d'un professionnel
        /// </summary>
        /// <param name="intrant">Paramètres d'entré pour la recherche</param>
        /// <returns>Les résultat de la recherche</returns>
        [HttpPost()]
        [AjaxRequest()]
        public ActionResult ObtenirProfessionnelRecherche(RechercheProfessionnel intrant)
        {
            try
            {
                return Json(_utilitaireProfessionnel.ObtenirProfessionnelRecherche(intrant));
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        /// <summary>
        /// Fonction utiliser avec AJAX pour savoir si le professionnel possède une classe 1
        /// </summary>
        /// <param name="intrant">Paramètres d'entré pour la recherche</param>
        /// <returns>Retourne vrai ou faux</returns>
        [HttpPost()]
        [AjaxRequest()]
        public bool ProfessionnelPossedeClasseUn(ProfessionnelPossedeClasse intrant)
        {
            try
            {
                var informationProfessionnel = _professionnelFactory.Instancier().ObtenirInformationProfessionnel(
                        new ObtenirDispensateurIndividuEntre
                        {
                            NumeroSequentielIndividu = intrant.NumeroIndividu
                        });                               

                return informationProfessionnel.NumerosClasseDispensateur.Any(x => x == intrant.Classe);
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        #endregion

        #region Lieux géographiques

        /// <summary>
        /// Fonction utiliser avec AJAX pour retourner le nom du territoire en paramètre
        /// </summary>
        /// <param name="information">information du territoire</param>
        /// <returns></returns>
        /// <remarks></remarks>
        [HttpPost()]
        [AjaxRequest()]
        public string ObtenirNomTerritoire(InformationTerritoire information)
        {
            try
            {
                return _lieuGeographiqueFactory.Instancier().ObtenirNomTerritoire(
                   new ObtenirNomTerritoireEntre
                   {
                       Code = information.Code,
                       DateDebutPratique = information.DateDebutPratique,
                       NumeroSequentiel = information.NumeroSequentiel,
                       Type = information.Type,
                       CodeRSS = _securite.ObtenirCodeRSSUtilisateurCourant().CodeRSS
                   }).NomTerritoire;
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        /// <summary>
        /// Fonction utiliser avec AJAX pour retourner le nom du territoire en paramètre
        /// </summary>
        /// <param name="information">information du territoire</param>
        /// <returns></returns>
        /// <remarks></remarks>
        [HttpPost()]
        [AjaxRequest()]
        public string ObtenirNomTerritoireSelonAvisConformite(InformationTerritoire information)
        {
            try
            {
                return _lieuGeographiqueFactory.Instancier().ObtenirNomTerritoire(
                    new ObtenirNomTerritoireEntre
                    {
                        Code = information.Code,
                        DateDebutPratique = information.DateDebutPratique,
                        NumeroSequentiel = information.NumeroSequentiel,
                        Type = information.Type
                    }).NomTerritoire;
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        /// <summary>
        /// Fonction pour obtenir le nom de la région socio-sanitaire lié au DRMG connecté
        /// </summary>
        /// <returns>Nom de la région socio-sanitaire</returns>
        public string ObtenirNomTerritoireRSSUtilisateurCourant()
        {
            try
            {
                return _utilitaireLieuGeographique.ObtenirNomTerritoireRSSUtilisateurCourant();
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        #endregion

        #region Avis de conformité

        /// <summary>
        /// Permet d'obtenir les avis de conformités
        /// </summary>
        /// <param name="numeroProfessionnel">Numéro de pratique du professionnel</param>
        /// <returns>Les avis de conformité du professionnel</returns>
        [HttpPost()]
        [AjaxRequest()]
        public ActionResult ObtenirAvisConformite(long numeroProfessionnel)
        {
            try
            {
                var extrant = _avisConformiteFactory.Instancier().ObtenirLesAvisConformite(
                    new ObtenirLesAvisConformiteEntre { NumeroSequentielDispensateur = numeroProfessionnel });

                if (extrant.ListeAvisConformite.Count == 0)
                {
                    if (extrant.InfoMsgTrait.Count == 0)
                    {
                        extrant.InfoMsgTrait = new List<MsgTrait>();
                        extrant.InfoMsgTrait.Add(new MsgTrait(OutilCommun.Constantes.CodeApplication,
                            OutilCommun.Constantes.CodeRetour.E_148018_AvisConfProfSantInxst));
                    }

                }
                else
                {
                    extrant.ListeAvisConformite.OrderByDescending(x => x.DateDebutEngagement);
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

        #region Erreurs

        /// <summary>
        /// Permet de faire un throw d'une erreur. Principalement lors d'une exception dans un appel AJAX.
        /// </summary>
        /// <param name="message">Message de l'erreur</param>
        /// <returns></returns>
        public ActionResult ErreurTechnique(string message)
        {
            throw new Exception(message);
        }

        /// <summary>
        /// Permet de retourner un message de traitement en Razor dans le front-end
        /// </summary>
        /// <param name="numeroMessage">Numéro du message de traitement</param>
        /// <param name="parametres">Paramètres pour le message</param>
        /// <returns>Le message de traitement</returns>
        [HttpPost()]
        [AjaxRequest()]
        public string RetourneMessageTraitement(string numeroMessage, string[] parametres = null)
        {
            try
            {
                return _messageTraitement.ResoudreMessageTraitement(numeroMessage, parametres);
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw;
            }
        }

        #endregion

        #region Formatage
        /// <summary>
        /// Permet de formater une date passé en paramètre en un date de format "1 janvier 2017"
        /// </summary>
        /// <param name="date">Date à formater</param>
        /// <returns>Date formater</returns>
        [HttpPost()]
        [AjaxRequest()]
        public string FormaterDateLong(DateTime? date)
        {

            return date.HasValue ? date.Value.ToLongDateString() : string.Empty;

        }
        #endregion

        #region Cache

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ActionName("MAJCache")]
        public ActionResult MAJCacheGet()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        [ActionName("MAJCache")]
        public ActionResult MAJCachePost()
        {
            var extrant = _professionnelFactory.Instancier().ObtenirProfessionnelParClasse(new List<int> { 1, 5 }, false, true);

            if (extrant.InfoMsgTrait.Any())
            {

            }

            return View();
        }

        #endregion

    }
}