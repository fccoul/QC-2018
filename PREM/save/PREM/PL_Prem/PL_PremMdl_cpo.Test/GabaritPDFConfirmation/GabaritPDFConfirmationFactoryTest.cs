using RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation;
using Xunit;

namespace RAMQ.PRE.PL_PremMdl_cpo.Test.GabaritPDFConfirmation
{
    /// <summary> 
    ///  Essais unitaire sur la classe "GabaritPDFConfirmationFactory"
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Avril 2017
    /// </remarks>
    public class GabaritPDFConfirmationFactoryTest
    {
        [Fact]
        public void Instancier_EnvironnementProduction_DevraitEtreTypeGabaritPDFConfirmationRepository()
        {
            var factory = new GabaritPDFConfirmationFactory();

            factory.EnvironnementCourant = Environnement.Production;

            var gabaritPDFConfirmation = factory.Instancier();

            Assert.IsType<GabaritPDFConfirmationRepository>(gabaritPDFConfirmation);
        }

        [Fact]
        public void Instancier_ConfigurationPourSimulationAvecEnvironnementDeProduction_DevraitEtreDeTypeGabaritPDFConfirmationRepository()
        {
            var factory = new GabaritPDFConfirmationFactory();

            factory.EnvironnementCourant = Environnement.Production;
            factory.EstSimulation = true;

            var gabaritPDFConfirmation = factory.Instancier();

            Assert.IsType<GabaritPDFConfirmationRepository>(gabaritPDFConfirmation);
        }

        [Theory, ClassData(typeof(EnvironnementsDeveloppement))]
        public void Instancier_ConfigurationPourSimulationAvecEnvironnementDeDeveloppement_DevraitEtreDeTypeGabaritPDFConfirmationSimulation(string environnement)
        {
            var factory = new GabaritPDFConfirmationFactory();

            factory.EnvironnementCourant = environnement;
            factory.EstSimulation = true;

            var gabaritPDFConfirmation = factory.Instancier();

            Assert.IsType<GabaritPDFConfirmationSimulation>(gabaritPDFConfirmation);
        }

        [Theory, ClassData(typeof(EnvironnementsDeveloppement))]
        public void Instancier_ConfigurationSansSimulationAvecEnvironnementDeDeveloppement_DevraitEtreDeTypeGabaritPDFConfirmationRepository(string environnement)
        {
            var factory = new GabaritPDFConfirmationFactory();

            factory.EnvironnementCourant = environnement;
            factory.EstSimulation = false;

            var gabaritPDFConfirmation = factory.Instancier();

            Assert.IsType<GabaritPDFConfirmationRepository>(gabaritPDFConfirmation);
        }
    }
}