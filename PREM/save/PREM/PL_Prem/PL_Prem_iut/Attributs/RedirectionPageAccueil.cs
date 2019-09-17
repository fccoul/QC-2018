using RAMQ.PRE.PL_Prem_iut.Utilitaires;
using System.Web.Mvc;

namespace RAMQ.PRE.PL_Prem_iut.Attributs
{
    /// <summary>
    /// 
    /// </summary>
	public class RedirectionPageAccueil : ActionFilterAttribute
    {

        private IUtilitaire _utilitaire;

        /// <summary>
        /// Propriété utilisé pour les tests unitaires.
        /// Permet d'injecter une interface IUtilitaire sans ajouter un constructeur, ce qui amènerait un refactoring important.
        /// </summary>
        public IUtilitaire UtilitaireInjecte
        {
            get {return _utilitaire ?? new Utilitaire();}
            set { _utilitaire = value; }
        }

        /// <summary>
        ///  Permet d'exécuté du code lors de chaque action
        /// </summary>
        /// <param name="filterContext"></param>
        /// <remarks></remarks>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controlleur = filterContext.Controller.ControllerContext.RouteData.GetRequiredString("controller");

            bool redirige = false;

            switch (controlleur)
            {
                case Constantes.NomControlleur.AvisConformite:
                    redirige = RedirigePLA1();
                    break;
                case Constantes.NomControlleur.DecisionAvisConformite:
                    redirige = RedirigePLA2();
                    break;

                case Constantes.NomControlleur.Autorisation:
                    redirige = RedirigePLA5();
                    break;
            }
            
            if (redirige)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(
                        new { action = Constantes.NomAction.PLA9.Accueil, controller = Constantes.NomControlleur.Accueil }));
            }            

            base.OnActionExecuting(filterContext);
        }

        private bool RedirigePLA1()
        {
            bool estGroupeSupport = Utilitaire.EstDansGroupe(Utilitaires.Configuration.GroupeSupport);
            bool estGroupeDRMG = Utilitaire.EstDansGroupe(Utilitaires.Configuration.GroupeDRMG);
            
            if (estGroupeSupport)
            {
                string typeProfil = Utilitaire.ObtenirCookie("TypeProfil");

                switch (typeProfil)
                {
                    case "DRMG":
                        estGroupeDRMG = true;
                        break;
                    default:
                        estGroupeDRMG = false;
                        break;
                }
            }

            return !estGroupeDRMG;
        }

        private bool RedirigePLA2()
        {
            bool estGroupeSupport = Utilitaire.EstDansGroupe(Utilitaires.Configuration.GroupeSupport);
            bool estGroupeComiteParitaire = Utilitaire.EstDansGroupe(Utilitaires.Configuration.GroupeComiteParitaire);

            if (estGroupeSupport)
            {
                string typeProfil = Utilitaire.ObtenirCookie("TypeProfil");

                switch (typeProfil)
                {
                    case "Comité paritaire":
                        estGroupeComiteParitaire = true;
                        break;
                    case "":
                        estGroupeComiteParitaire = true;
                        break;
                    default:
                        estGroupeComiteParitaire = false;
                        break;
                }
            }

            return !estGroupeComiteParitaire;
        }

        /// <summary>
        /// Fonction permettant de déterminer si on doit rediriger l'utilisateur sur la page d'accueil, s'il n'a 
        /// pas les droits nécessairent pour accéder les pages en lien à PLA5 (Autorisation PREMQ).
        /// </summary>
        /// <returns>True si on doit rediriger, false sinon.</returns>
        private bool RedirigePLA5()
        {
            //*** L'ordre des groupes est important, car on y va par priotiré d'accès.

            //Vérification de la présence de l'utilsateur dans le groupe DRMG.
            bool estDansGroupe = UtilitaireInjecte.EstDansGroupe(Utilitaires.Configuration.GroupeDRMG);
            if (estDansGroupe)
            {
                return !estDansGroupe;
            }

            //Vérification de la présence de l'utilsateur dans le groupe Comité paritaire.
            estDansGroupe = UtilitaireInjecte.EstDansGroupe(Utilitaires.Configuration.GroupeComiteParitaire);
            if (estDansGroupe)
            {
                return !estDansGroupe;
            }

            //Vérification de la présence de l'utilsateur dans le groupe de support.
            estDansGroupe = EstDansGroupeSupport(UtilitaireInjecte.EstDansGroupe(Utilitaires.Configuration.GroupeSupport));

            return !estDansGroupe;
        }
        /// <summary>
        /// Fonction permettant de déterminer si l'usager en cours est dans le groupe de support et 
        /// à le bon type de profil.
        /// </summary>
        /// <param name="estDansGroupeSupport"></param>
        /// <returns>True si est dans le groupe de support, false sinon.</returns>
        private bool EstDansGroupeSupport(bool estDansGroupeSupport)
        {
            if (estDansGroupeSupport)
            {
                string typeProfil = UtilitaireInjecte.ObtenirCookie("TypeProfil");

                switch (typeProfil)
                {
                    case Constantes.TypeProfil.ComiteParitaire:
                        return true;
                    case Constantes.TypeProfil.DRMG:
                        return true;
                    case "":
                        return true;
                    default:
                        return false;
                }
            }

            return estDansGroupeSupport;

        }
    }
}