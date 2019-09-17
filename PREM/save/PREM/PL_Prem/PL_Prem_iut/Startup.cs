using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RAMQ.PRE.PL_Prem_iut.Startup))]
namespace RAMQ.PRE.PL_Prem_iut
{
    public partial class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureNonce(app);
            ConfigureAutofac(app);
        }
    }
}