using Autofac;
using Autofac.Integration.Wcf;
using RAMQ.AccesDonnees.BDOracle;
using RAMQ.DomainesValeur;
using RAMQ.Message;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.CaracteristiquePratique;
using RAMQ.PRE.PL_RegleAffaiComne_cpo.PLC1_ETR_ObtnDroitAcqProf;
using RAMQ.PRE.PL_RegleAffaiComne_cpo.Territoire;
using RAMQ.PRE.PL_RegleAffaiComne_cpo.Territoire.Factory;
using RAMQ.PRE.PL_RegleAffaiComne_cpo.Validations;
using RAMQ.PRE.PLB3_CalculerNbrJrFactProfs_cpo;
using RAMQ.PRE.PLB3_CalculerNbrJrFactProfs_cpo.Calcul;
using RAMQ.PRE.PLB3_CalculerNbrJrFactProfs_cpo.Traitement;
using RAMQ.PRE.PLB3_CalculerNbrJrFactProfs_cpo.Traitement.Interface;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Professionnel;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Professionnel.Interface;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Validations;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal;
using RAMQ.PRE.PRE_FournAccesDonne_cpo;
using RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3;
using RAMQ.PRE.PRE_SysExt_cpo.GEO.SOB2;
using RAMQ.PRE.PRE_SysExt_cpo.GEO.SOD1;
using System;
using System.Web;
using LAAutorisation = RAMQ.PRE.PL_LogiqueAffaire_cpo.Autorisation;
using LAAvis = RAMQ.PRE.PL_LogiqueAffaire_cpo.AvisConformite;
using LADAdmis = RAMQ.PRE.PL_LogiqueAffaire_cpo.Admissibilite;
using LADerog = RAMQ.PRE.PL_LogiqueAffaire_cpo.Derogation;
using LAProf = RAMQ.PRE.PL_LogiqueAffaire_cpo.Professionnel;
using OutilCommun = RAMQ.PRE.PRE_OutilComun_cpo;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_svc
{
    /// <summary>
    /// Global
    /// </summary>
    public class Global : HttpApplication
    {
        /// <summary>
        /// Application start
        /// </summary>
        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();

            // LogiqueAffaire
            builder.RegisterType<LADAdmis.Admissibilite>().As<LADAdmis.IAdmissibilite>();
            builder.RegisterType<LAAvis.AvisConformite>().As<LAAvis.IAvisConformite>();
            builder.RegisterType<LADerog.Derogation>().As<LADerog.IDerogation>();
            builder.RegisterType<LAProf.RechercherProfessionnel>().As<LAProf.IRechercherProfessionnel>();

            builder.RegisterType<LAProf.EngagementAbsence>().As<LAProf.IEngagementAbence>();

           

            builder.RegisterType<ServCnsulProfiPremqProf>().AsSelf();
            builder.RegisterType<CnsulProfiPremqProf>().As<ICnsulProfiPremqProf>();
            builder.RegisterType<PlanRegnMdcal>().As<IPlanRegnMdcal>();
            builder.RegisterType<AccesDonne>().As<IAccesDonne>();
            builder.RegisterType<InfoDispCnsul>().As<IInfoDispCnsul>();
            builder.RegisterType<EngagementPratique>().As<IEngagementPratique>();
            builder.RegisterType<PeriodePratique>().As<IPeriodePratique>();
            builder.RegisterType<JourneeFacturation>().As<IJourneeFacturation>();
            builder.RegisterType<LAAutorisation.Autorisation>().As<LAAutorisation.IAutorisation>();
            builder.RegisterType<OutilCommun.DomaineValeur>().As<OutilCommun.IDomaineValeur>();
            builder.RegisterType<ObtnInfoPilotLieuGeo>().As<IObtnInfoPilotLieuGeo>();
            builder.RegisterType<Validations>().As<IValidations>();
            builder.RegisterType<ReglesValidations>().As<IReglesValidations>();
            builder.RegisterType<AccesDomVal>().As<IAccesDomVal>();
            builder.RegisterType<ResolutionMessage>().As<IResolutionMessage>();
            builder.RegisterType<ReductionRemuneration>().As<IReductionRemuneration>();
            builder.RegisterType<ObtnDroitAcqProf>().As<IObtnDroitAcqProf>();
            builder.RegisterType<CaracteristiquePratique>().As<ICaracteristiquePratique>();
            builder.RegisterType<OutilCommun.MessageTraitement>().As<OutilCommun.IMessageTraitement>();


            //PLB3
            builder.RegisterType<CalculerNbrJrFactProfs>().As<ICalculerNbrJrFactProfs>();
            builder.RegisterType<TraitementCalculerJournFactRSS>().As<ITraitementCalculerJournFactRSS>();
            builder.RegisterType<TraitementCalculerSommaires>().As<ITraitementCalculerSommaires>();
            builder.RegisterType<TraitementCalculerRespectEngagement>().As<ITraitementCalculerRespectEngagement>();
            builder.RegisterType<TraitementCalculerJournFactTerri>().As<ITraitementCalculerJournFactTerri>();
            builder.RegisterType<TraitementCalculerJournFactAvis>().As<ITraitementCalculerJournFactAvis>(); 
            builder.RegisterType<TraitementCalculerJournFactRPPR>().As<ITraitementCalculerJournFactRPPR>();
            builder.RegisterType<CalculJournFactRSS>().As<ICalculJournFactRSS>();
            builder.RegisterType<CalculJournFactTerri>().As<ICalculJournFactTerri>();
            builder.RegisterType<CalculJournFactAvis>().As<ICalculJournFactAvis>();
            builder.RegisterType<CalculRespectEngagement>().As<ICalculRespectEngagement>();
            builder.RegisterType<CalculSommaires>().As<ICalculSommaires>();
            
                
                



            // Instanciation du "Factory" des nom des territoires par rapport à son type.
            builder.RegisterType<ObtenirNomTerritoireFactory>().As<IObtenirNomTerritoireFactory>();
            builder.RegisterType<TerritoiresRegles>().As<ITerritoiresRegles>();
            builder.RegisterType<ObtnInfoLocal>().As<IObtnInfoLocal>();
            builder.Register<IObtenirNomTerritoire>((context, parametre) =>
            {
                var typeTerritoire = parametre.TypedAs<string>();
                switch (typeTerritoire)
                {
                    case "RSS":
                        return new ObtenirNomRSS(context.Resolve<OutilCommun.IDomaineValeur>());
                    case "TCLSC":
                        return new ObtenirNomCLSC(context.Resolve<IObtnInfoLocal>());
                    case "RLS":
                        return new ObtenirNomRLS(context.Resolve<IObtnInfoLocal>());
                    case null:
                        return new ObtenirNomRegroupement(context.Resolve<ITerritoiresRegles>());
                    default:
                        throw new ArgumentException("Type de territoire invalide");
                }
            })
          .As<IObtenirNomTerritoire>();

            //Paramètre de connexion oracle
            builder.Register(c => new Func<IAccesDonnesOra>(() =>
                    SingletonAccesDonnesOra.Instance().ConnexionOracle
                    )).As<Func<IAccesDonnesOra>>().SingleInstance();

            AutofacHostFactory.Container = builder.Build();
        }
    }
}