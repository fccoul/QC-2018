using RAMQ.PRE.PL_PremMdl_cpo.AvisConformite;
using RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre;
using OutilCommun = RAMQ.PRE.PRE_OutilComun_cpo;
using System.Web.Mvc;
using System.Linq;

namespace RAMQ.PRE.PL_Prem_iut.Attributs
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class NombreAvisNonTransmisAttribute : ActionFilterAttribute
    {
        #region Attributs privées

        private readonly IAvisConformiteFactory _avisConformiteFactory;
        private readonly Securite.ISecurite _securite;

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="avisConformiteFactory"></param>
        /// <param name="securite"></param>
        public NombreAvisNonTransmisAttribute(IAvisConformiteFactory avisConformiteFactory,
                                              Securite.ISecurite securite)
        {
            _avisConformiteFactory = avisConformiteFactory;
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
            var code = _securite.ObtenirCodeRSSUtilisateurCourant();

            if (code.InfoMsgTrait.Any())
            {
                //filterContext.Result = new RedirectToRouteResult(
                //    new System.Web.Routing.RouteValueDictionary(
                //        new { action = "Erreur", controller = "Commun", Message = code.InfoMsgTrait.First().TxtMsgFran }));

                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(
                        new { action = "PLA9_Accueil", controller = "Accueil"}));
            }
            else
            {
                //On va chercher le nombre d'avis en attente
                ObtenirLesAvisConformiteSorti extrantObtentionAvis = _avisConformiteFactory.Instancier()
                    .ObtenirLesAvisConformite(
                        new ObtenirLesAvisConformiteEntre
                        {
                            IndicateurAttenteTransmission = OutilCommun.Constantes.IndicateurOui,
                            CodeRegion = code.CodeRSS
                        });

                filterContext.Controller.ViewData.Add(Constantes.CleNombreAvisAttente, extrantObtentionAvis.ListeAvisConformite.Count);
            }

            base.OnActionExecuting(filterContext);
        }

        #endregion

    }
}