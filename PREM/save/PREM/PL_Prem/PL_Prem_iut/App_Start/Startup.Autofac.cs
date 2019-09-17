using Autofac;
using Autofac.Integration.Mvc;
using Owin;
using RAMQ.DomainesValeur;
using RAMQ.Message;
using RAMQ.PRE.PL_Prem_iut.Attributs;
using RAMQ.PRE.PL_Prem_iut.Controllers;
using RAMQ.PRE.PL_Prem_iut.ControllersHelpers;
using RAMQ.PRE.PL_Prem_iut.Utilitaires;
using RAMQ.PRE.PL_PremMdl_cpo.Autorisation.Mappeur;
using RAMQ.PRE.PL_PremMdl_cpo.AvisConformite;
using RAMQ.PRE.PL_PremMdl_cpo.DecisionAvisConformite;
using RAMQ.PRE.PL_PremMdl_cpo.DemandeReevaluation;
using RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation;
using RAMQ.PRE.PL_PremMdl_cpo.LieuGeographique;
using RAMQ.PRE.PL_PremMdl_cpo.Professionnel;
using RAMQ.PRE.PL_PremMdl_cpo.Rapport;
using RAMQ.PRE.PRE_OutilComun_cpo;
using System.Web.Mvc;

namespace RAMQ.PRE.PL_Prem_iut
{
    public partial class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public void ConfigureAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            //Enregistrement des contrôleurs MVC.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //ou
            //builder.RegisterType<HomeController>().InstancePerRequest();

            // Optionnel: Enregistrement des "model binders" qui requiert l'injection de dépendance.
            //builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            //builder.RegisterModelBinderProvider();

            // Optionnel: Enregistrement des classes Web du Framework .NET tel que HttpContextBase.
            //builder.RegisterModule<AutofacWebTypesModule>();

            // Optionnel: Active l'injection dans les vues.
            //builder.RegisterSource(new ViewRegistrationSource());

            // Optionnel: Active l'injection dans les filtres.
            //builder.RegisterFilterProvider();

            builder.RegisterType<AvisConformiteFactory>().As<IAvisConformiteFactory>();
            builder.RegisterType<LieuGeographiqueFactory>().As<ILieuGeographiqueFactory>();
            builder.RegisterType<ProfessionnelFactory>().As<IProfessionnelFactory>();
            builder.RegisterType<DemandeReevaluationFactory>().As<IDemandeReevaluationFactory>();

            builder.RegisterType<ResolutionMessage>().As<IResolutionMessage>();
            builder.RegisterType<DomaineValeur>().As<IDomaineValeur>();
            builder.RegisterType<AccesDomVal>().As<IAccesDomVal>();
            builder.RegisterType<Securite.Securite>().As<Securite.ISecurite>();
            builder.RegisterType<PRE_OutilComun_cpo.Securite>().As<ISecurite>();
            builder.RegisterType<DecisionAvisConformiteFactory>().As<IDecisionAvisConformiteFactory>();
            builder.RegisterType<MessageTraitement>().As<IMessageTraitement>();
            builder.RegisterType<NomFichierGabaritPDFConfirmationBuilder>().As<INomFichierGabaritPDFConfirmationBuilder>();

            builder.Register(c => new GabaritPDFConfirmationFactory().Instancier()).As<IGabaritPDFConfirmation>();

            builder.Register(c => new NombreAvisNonTransmisAttribute(c.Resolve<IAvisConformiteFactory>(),
                                                                     c.Resolve<Securite.ISecurite>()))
                .AsActionFilterFor<AvisConformiteController>().InstancePerRequest();


            builder.Register(c => new RedirectionPageAccueilPLC2(c.Resolve<Securite.ISecurite>()))
               .AsActionFilterFor<ProfilProfessionnelController>().InstancePerRequest();

            builder.RegisterType<RapportFactory>().As<IRapportFactory>();

            builder.RegisterType<AutorisationMappeur>().As<IAutorisationMappeur>();
            builder.RegisterType<ProfessionnelHelpers>().As<IProfessionnelHelpers>();
            builder.RegisterType<LieuGeographiqueHelpers>().As<ILieuGeographiqueHelpers>();

            builder.RegisterFilterProvider();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }
    }
}
