using RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation;
using RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation.Param;
using Xunit;

namespace RAMQ.PRE.PL_PremMdl_cpo.Test.GabaritPDFConfirmation
{
    /// <summary> 
    ///  Essais unitaire sur la classe "GabaritPDFConfirmationSimulation"
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Avril 2017
    /// </remarks>
    public class GabaritPDFConfirmationSimulationTest
    {
        [Fact]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategory("ExcluBuild")]
        public void ObtenirConfirmationPDFAvisConformite_TousLesScenarios_DevraitRetournerFichierPDFSimulation()
        {
            var gabaritPDFConfirmationSimulation = new GabaritPDFConfirmationSimulation();

            var sortie = gabaritPDFConfirmationSimulation.ObtenirConfirmationPDFAvisConformite(new ObtnConfirmationPDFAvisConformiteEntre());

            Assert.True(sortie.GabaritPDF.Length > 0);
        }

        [Fact]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategory("ExcluBuild")]
        public void ObtenirConfirmationPDFDerogation_TousLesScenarios_DevraitRetournerFichierPDFSimulation()
        {
            var gabaritPDFConfirmationSimulation = new GabaritPDFConfirmationSimulation();

            var sortie = gabaritPDFConfirmationSimulation.ObtenirConfirmationPDFDerogation(new ObtnConfirmationPDFDerogationEntre());

            Assert.True(sortie.GabaritPDF.Length > 0);
        }

        [Fact]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategory("ExcluBuild")]
        public void ObtenirConfirmationPDFSuspension_TousLesScenarios_DevraitRetournerFichierPDFSimulation()
        {
            var gabaritPDFConfirmationSimulation = new GabaritPDFConfirmationSimulation();

            var sortie = gabaritPDFConfirmationSimulation.ObtenirConfirmationPDFSuspension(new ObtnConfirmationPDFSuspensionEntre());

            Assert.True(sortie.GabaritPDF.Length > 0);
        }
    }
}