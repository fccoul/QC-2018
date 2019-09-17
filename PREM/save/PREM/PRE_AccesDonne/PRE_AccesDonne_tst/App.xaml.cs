using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Autofac;
using GalaSoft.MvvmLight.Messaging;

namespace RAMQ.PRE.PRE_AccesDonne_tst
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {

        private const string TitreErrImpr = "Erreur imprévue";
        private static IContainer _container;
        private static IMessenger _messenger;

        /// <summary>
        /// Constructeur principal.
        /// </summary>
        public App()
        {
            DispatcherUnhandledException += App_DispatcherUnhandledException;
        }

        /// <summary>
        /// Conteneur autofac.
        /// </summary>
        public static IContainer Container
        {
            get
            {
                if (_container == null)
                {
                    _container = Configuration.Container.Resoudre();
                }
                return _container;
            }
        }

        /// <summary>
        /// Permet la communication entre les différentes vues.
        /// </summary>
        public static IMessenger Messenger
        {
            get
            {
                if (_messenger == null)
                {
                    _messenger = Container.Resolve<IMessenger>();
                }
                return _messenger;
            }
        }

        private void App_DispatcherUnhandledException(object sender,
                                                      DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString(), TitreErrImpr, MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }
    }
}