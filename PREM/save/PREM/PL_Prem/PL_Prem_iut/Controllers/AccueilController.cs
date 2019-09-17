using RAMQ.Web.MVC.Attributs;
using RAMQ.Web.MVC.Controleurs;
using System.Web.Mvc;

namespace RAMQ.PRE.PL_Prem_iut.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Autor(Operation = "PRE_SaisAvisConfDRMG;PRE_CnsulProfiProf;PRE_SaisDecisComtParit;PRE_CnsulSuppo;PRE_CreerDemReeva")]
    public class AccueilController : ControleurBase, IController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult PLA9_Accueil()
        {
            return View();
        }
    }
}