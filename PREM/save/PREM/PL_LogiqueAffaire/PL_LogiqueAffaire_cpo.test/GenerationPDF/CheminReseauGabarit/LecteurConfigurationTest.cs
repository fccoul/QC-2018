using System;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.CheminReseauGabarit;
using Xunit;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.test.GenerationPDF.CheminReseauGabarit
{
    /// <summary> 
    ///  Essais unitaire sur la classe "LecteurConfiguration"
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class LecteurConfigurationTest
    {
        [Fact]
        public void LireConfiguration_UnNomCleVide_DevraitRetournerUnArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var lecteurConfiguration = new LecteurConfiguration();
                lecteurConfiguration.LireConfiguration(string.Empty);
            });
        }

        [Fact]
        public void LireConfiguration_UnNomCleNul_DevraitRetournerUnArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var lecteurConfiguration = new LecteurConfiguration();
                lecteurConfiguration.LireConfiguration(null);
            });
        }

        [Fact]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategory("ExcluBuild")]
        public void LireConfiguration_UneCleExistanteDansAppConfig_DevraitRetournerLeContenuDeLaCle()
        {
            var lecteurConfiguration = new LecteurConfiguration();
            var valeurCle = lecteurConfiguration.LireConfiguration("CleExistante");

            var valeurCleAttendu = "ContenuCle";

            Assert.Equal(valeurCleAttendu, valeurCle);
        }

        [Fact]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategory("ExcluBuild")]
        public void LireConfiguration_UneCleInexistanteDansAppConfig_DevraitRetournerUneChaineVide()
        {
            var lecteurConfiguration = new LecteurConfiguration();

            var valeurCle = lecteurConfiguration.LireConfiguration("CleInexistante");

            Assert.Equal(string.Empty, valeurCle);
        }
    }
}