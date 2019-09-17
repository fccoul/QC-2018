using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace RAMQ.PRE.PL_Prem_iut.Attributs
{
    /// <summary> 
    ///  Attribut permettant de faire fonctionner la validation AntiForgeryToken en contexte AJAX avec IE 8/9
    /// </summary>
    /// <remarks>
    ///  Auteur : Kévin Follier <br/>
    ///  Date   : 2015-09-24
    /// </remarks>
    public class AjaxValidateAntiForgeryTokenAttribute : FilterAttribute, IAuthorizationFilter
    {

        #region Méthodes publiques

        /// <summary>
        /// implémentation de IAuthorizationFilter.OnAuthorization
        /// </summary>
        /// <param name="filterContext"></param>
        /// <remarks></remarks>
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if ((filterContext.HttpContext.Request.IsAjaxRequest()))
            {
                this.ValidateRequestHeader(filterContext.HttpContext.Request);
            }
            else
            {
                AntiForgery.Validate();
            }
        }

        #endregion

        #region Méthodes privées

        /// <summary>
        /// Permet de valider les tokens via le header de la requete Http (Fix pour faire fonctionner ValidateAntiForgeryToken sur IE9 car ne supporte pas FormData)
        /// </summary>
        /// <param name="request"></param>
        /// <remarks></remarks>
        private void ValidateRequestHeader(HttpRequestBase request)
        {
            string cookieToken = string.Empty;
            string formToken = string.Empty;
            string tokenValue = request.Headers["VerificationToken"];

            if (!string.IsNullOrEmpty(tokenValue))
            {
                string[] tokens = tokenValue.Split(',');

                if (tokens.Length == 2)
                {
                    cookieToken = tokens[0].Trim();
                    formToken = tokens[1].Trim();
                }
            }

            AntiForgery.Validate(cookieToken, formToken);

        }

        #endregion

    }
}