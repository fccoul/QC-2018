using Autofac;
using GalaSoft.MvvmLight.Messaging;
using RAMQ.AccesDonnees.BDOracle;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal;
using RAMQ.PRE.PRE_AccesDonne_tst.ViewModels;
using RAMQ.PRE.PRE_FournAccesDonne_cpo;
using System;
using System.IO;

namespace RAMQ.PRE.PRE_AccesDonne_tst.Configuration
{
    /// <summary>
    /// Conteneur autofac.
    /// </summary>
    internal static class Container
    {
        /// <summary>
        /// Configuration d'autofac.
        /// </summary>
        /// <returns></returns>
        internal static IContainer Resoudre()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Messenger>().As<IMessenger>();
            builder.RegisterType<MainWindowViewModel>().AsSelf();

            builder.RegisterType<PlanRegnMdcal>().As<IPlanRegnMdcal>();
            builder.RegisterType<AccesDonne>().As<IAccesDonne>();
            
            builder.Register(c => new Func<IAccesDonnesOra>(() =>
                    SingletonAccesDonnesOra.Instance().ConnexionOracle
                    )).As<Func<IAccesDonnesOra>>().SingleInstance();
                    

            /*if (File.Exists(@"D:\AuthnDonne\PRE\PRE_ORA.udl"))
            {
                builder.Register(c => new Func<IAccesDonnesOra>(() =>
                        SingletonAccesDonnesOra.Instance(@"D:\AuthnDonne\PRE\PRE_ORA.udl").ConnexionOracle
                        )).As<Func<IAccesDonnesOra>>().SingleInstance();
            }*/
            return builder.Build();
        }
    }
}