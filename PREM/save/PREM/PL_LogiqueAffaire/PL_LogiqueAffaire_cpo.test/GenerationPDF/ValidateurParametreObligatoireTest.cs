using System;
using Ploeh.AutoFixture;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.test.Base;
using Xunit;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.test.GenerationPDF
{
    /// <summary> 
    ///  Essais unitaire sur la classe "ValidateurParametreObligatoire"
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class ValidateurParametreObligatoireTest : TestBase
    {
        [Fact]
        public void ValiderParametreNull_UnObjectQuelconqueNull_DevraitRetournerArgumentNullException()
        {
            var nomParametre = Fixture.Create<string>();

            Assert.Throws<ArgumentNullException>(() => 
            {
                ValidateurParametreObligatoire.ValiderParametreNull(null, nomParametre);
            });
        }

        [Fact]
        public void ValiderParametreNull_UnObjectQuelconqueNull_DevraitContenirNomParametreDansMessageErreur()
        {
            var nomParametre = Fixture.Create<string>();

            var erreur = Assert.Throws<ArgumentNullException>(() =>
            {
                ValidateurParametreObligatoire.ValiderParametreNull(null, nomParametre);
            });

            Assert.True(erreur.Message.Contains(nomParametre));
        }

        [Fact]
        public void ValiderParametreNull_UnObjectQuelconqueNonNull_NeDevraitPasRetournerUnArgumentNullException()
        {
            try
            {
                var nomParametre = Fixture.Create<string>();

                ValidateurParametreObligatoire.ValiderParametreNull(new object(), nomParametre);
            }
            catch (Exception)
            {
                Assert.True(false, "Ne devrait pas retourner une exception lorsque l'objet n'est pas null.");
            }
        }
    }
}