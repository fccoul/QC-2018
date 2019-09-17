using System;
using System.Web;
using Autofac;
using Autofac.Integration.Wcf;
using System.Web.Services.Description;
using RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal;
using RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3;
using OutilCommun = RAMQ.PRE.PRE_OutilComun_cpo;
using System.Collections.Generic;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.AvisConformite;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Derogation;
using RAMQ.AccesDonnees.BDOracle;
using RAMQ.PRE.PRE_FournAccesDonne_cpo;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Autorisation;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Professionnel;
using RAMQ.Message;

namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_svc
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ServTraitEveneAutreSys>().AsSelf();
            builder.RegisterType<TraitEveneAutreSys>().As<ITraitEveneAutreSys>();

            builder.RegisterType<AjusterAvisConformite>().As<IAjusterAvisConformite>();

            builder.RegisterType<PlanRegnMdcal>().As<IPlanRegnMdcal>();
            builder.RegisterType<PRE_FournAccesDonne_cpo.AccesDonne>().As<PRE_FournAccesDonne_cpo.IAccesDonne>();
            builder.RegisterType<InfoDispCnsul>().As<IInfoDispCnsul>();

            builder.Register(c => new Func<IAccesDonnesOra>(() =>
                    SingletonAccesDonnesOra.Instance().ConnexionOracle
                    )).As<Func<IAccesDonnesOra>>().SingleInstance();


            builder.RegisterType<TraiterAdmissProf>().As<ITraiterAdmissProf>();
            builder.RegisterType<TraitementDonneesAdmissProf>().As<ITraitementDonneesAdmissProf>();
            builder.RegisterType<AvisConformite>().As<IAvisConformite>();
            builder.RegisterType<Derogation>().As<IDerogation>();

            builder.RegisterType<Autorisation>().As<IAutorisation>();
            builder.RegisterType<RechercherProfessionnel>().As<IRechercherProfessionnel>();

            builder.RegisterType<AjusterEngagAvisConfNonParticipation>().As<IAjusterEngagAvisConfNonParticipation>();
            builder.RegisterType<ResolutionMessage>().As<IResolutionMessage>();

            AutofacHostFactory.Container = builder.Build(); ;
        }
    }
}