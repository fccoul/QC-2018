using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RAMQ.Web.MVC.Attributs;
using RAMQ.Web.MVC.Controleurs;
using RAMQ.PRE.PL_Prem_iut.Attributs;
using RAMQ.PRE.PL_Prem_iut.Models.PLA5_SaisirAutorActivMdcal;

namespace RAMQ.PRE.PL_Prem_iut.Controllers
{
    /// <summary>
    /// Contrôleur des autorisations de PREMQ.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [RedirectionPageAccueil]
    public class AutorisationController : ControleurBase, IController
    {
        /// <summary>
        /// Action permettant d'ajouter une autorisation.
        /// </summary>
        /// <returns></returns>
        [HttpPost()]
        [ActionName(Constantes.NomAction.PLA5.AjouterAutorisation)]
        [Autor(Operation = "PRE_SaisAvisConfDRMG;PRE_SaisDecisComtParit;PRE_CnsulSuppo")]
        public ActionResult AjouterAutorisation()
        {
            return View();
        }
    }
}