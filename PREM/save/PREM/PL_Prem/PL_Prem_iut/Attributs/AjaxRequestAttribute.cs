using System.Web.Mvc;

namespace RAMQ.PRE.PL_Prem_iut.Attributs
{
    /// <summary> 
    ///  Permet de limiter l'accès a une action seulement si elle est appelé depuis une requête Ajax
    /// </summary>
    /// <remarks>
    ///  Auteur : Kévin Follier <br/>
    ///  Date   : 2015-09-16
    /// </remarks>
    public class AjaxRequestAttribute : ActionMethodSelectorAttribute
    {

        #region Méthodes publiques

        /// <summary>
        /// Permet de savoir si l'action concernée est valide pour la requête courante
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="methodInfo"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
        {
            return controllerContext.HttpContext.Request.IsAjaxRequest();
        }

        #endregion

    }
}