using RAMQ.PRE.PL_Prem_iut.Attributs;
using RAMQ.Web.MVC.Attributs;
using System.Web.Mvc;

namespace RAMQ.PRE.PL_Prem_iut.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Autor(Operation = "PRE_SaisAvisConfDRMG;PRE_CnsulProfiProf;PRE_SaisDecisComtParit;PRE_CnsulSuppo;PRE_CreerDemReeva")]
    public class JavascriptController : Controller
    {
        /// <summary>
        /// Action permettant de retourner la vue de constantes comme un fichier .js
        /// </summary>
        /// <returns></returns>
        [FichierJavascriptExterne]
        public ActionResult Constantes()
        {
            return PartialView();
        }
    }
}