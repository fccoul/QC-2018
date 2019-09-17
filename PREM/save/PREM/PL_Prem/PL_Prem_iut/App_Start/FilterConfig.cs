using System.Web.Mvc;
using RAMQ.Web.MVC.Filtres;

namespace RAMQ.PRE.PL_Prem_iut
{
    /// <summary>
    /// 
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //Filtre d'autorisation RAMQ qui permet de s'assurer que l'attribut d'autorisation 
            //est présent sur chacun des controllers/actions.
            filters.Add(new FiltreAutorisation());
            filters.Add(new HandleErrorAttribute());
        }
    }
}