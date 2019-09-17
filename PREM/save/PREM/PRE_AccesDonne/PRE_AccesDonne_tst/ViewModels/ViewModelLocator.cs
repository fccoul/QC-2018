using Microsoft.Practices.ServiceLocation;
using Autofac.Extras.CommonServiceLocator;

namespace RAMQ.PRE.PRE_AccesDonne_tst.ViewModels
{
    /// <summary>
    /// Localisateur de modèle de vue.
    /// </summary>
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            var autofacServLoc = new AutofacServiceLocator(App.Container);
            ServiceLocator.SetLocatorProvider(() => autofacServLoc);
        }

        public MainWindowViewModel MainWindowViewModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
    }
}