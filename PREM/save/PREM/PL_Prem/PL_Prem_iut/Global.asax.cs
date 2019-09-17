using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using RAMQ.Web.MVC.Site;
using RAMQ.Web.MVC.Filtres;
using System.Collections.Generic;
using System.Linq;
using OutilCommun = RAMQ.PRE.PRE_OutilComun_cpo;
using RAMQ.Message;
using Autofac;
using RAMQ.PRE.PL_PremMdl_cpo.Autorisation.Mappeur;

namespace RAMQ.PRE.PL_Prem_iut
{
    /// <summary>
    /// 
    /// </summary>
    public class MvcApplication : SiteDemarrage
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Application_Start()
        {
            base.Application_Start();

            AreaRegistration.RegisterAllAreas();

            //Filtre d'autorisation RAMQ qui permet de s'assurer que l'attribut d'autorisation 
            //est présent sur chacun des controllers/actions
            GlobalFilters.Filters.Add(new FiltreAutorisation());

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            builder.RegisterType<AutorisationMappeur>().As<IAutorisationMappeur>();

            var container = builder.Build();
        }

        private void Session_Start(object sender,
                                   EventArgs e)
        {
            this.NomApplication = "";
        }

        /// <summary>
        ///  Permet de résoudre des messages d'erreurs dont les numéros sont passés 
        /// </summary>
        /// <param name="strNoMsg"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public override string ObtenirMsg(string strNoMsg)
        {
            string strMsg = string.Empty;
            RAMQ.Message.ResolutionMessage objResolMsg = new RAMQ.Message.ResolutionMessage();
            IEnumerable<string> colctParamMsg = default(IEnumerable<string>);

            colctParamMsg = strNoMsg.Split('@').AsEnumerable();
            strMsg = objResolMsg.ResoudreMessage(OutilCommun.Constantes.CodeApplication, colctParamMsg.First(), colctParamMsg.Skip(1));

            return strMsg;
        }
    }
}
