using RAMQ.PRE.PL_Prem_iut.Utilitaires;
using System.Linq;
using System.Web.Mvc;

namespace RAMQ.PRE.PL_Prem_iut.Attributs
{
    /// <summary>
    /// Classe permettant la redirection à la page d'accueil à partir de PLC2 selon les droits
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
	public class RedirectionPageAccueilPLC2 : ActionFilterAttribute
    {

        #region Attributs privées

        private readonly Securite.ISecurite _securite;

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="securite"></param>
        public RedirectionPageAccueilPLC2(Securite.ISecurite securite)
        {
            _securite = securite;
        }

        #endregion


        #region Méthodes publiques

        /// <summary>
        ///  Permet d'exécuté du code lors de chaque action
        /// </summary>
        /// <param name="filterContext"></param>
        /// <remarks></remarks>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            

            bool estGroupeSupport = Utilitaire.EstDansGroupe(Utilitaires.Configuration.GroupeSupport);
            bool estGroupConsultationProfil = Utilitaire.EstDansGroupe(Utilitaires.Configuration.GroupeConsultationProfilPrem);
            bool estDRMG = false;

            if (estGroupeSupport)
            {
                string typeProfil = Utilitaire.ObtenirCookie("TypeProfil");

                switch (typeProfil)
                {
                    case "DRMG":
                        estDRMG = true;
                        break;
                    default:
                        estDRMG = false;
                        estGroupConsultationProfil = true;
                        break;
                }
            }
            else
            {
               var code = _securite.ObtenirCodeRSSUtilisateurCourant();

                estDRMG = (estGroupConsultationProfil && !code.InfoMsgTrait.Any() && !string.IsNullOrEmpty(code.CodeRSS));
            }

            if (!estDRMG && !estGroupConsultationProfil)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(
                        new { action = "PLA9_Accueil", controller = "Accueil" }));
            }

            base.OnActionExecuting(filterContext);
        }

        #endregion
    }

}