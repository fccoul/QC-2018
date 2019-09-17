using System;
using RAMQ.PRE.PL_Prem_iut.Utilitaires;
using Xunit;

namespace RAMQ.PRE.PL_Prem_iut.Test.Utilitaires
{
    /// <summary> 
    ///  Essais unitaire sur la classe "NomFichierGabaritPDFConfirmationBuilder"
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Avril 2017
    /// </remarks>
    public class NomFichierGabaritPDFConfirmationBuilderTest
    {
        [Fact]
        public void Construire_UnNumeroDeDispensateurAbsent_LeNomDuFichierNeDevraitPasContenirLeNumeroDuDispensateur()
        {
            var builder = new NomFichierGabaritPDFConfirmationBuilder();
            HeureSysteme.Now = () => new DateTime(2017, 4, 20, 17, 57, 30);

            var nomFichier = builder.Construire(null, HeureSysteme.Now());

            var nomFichierAttendu = "Confr__2017-04-20 17:57:30.pdf";

            Assert.Equal(nomFichierAttendu, nomFichier);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("12345")]
        public void Construire_UnNumeroDeDispensateurNonValide_LeNomDuFichierNeDevraitPasContenirLeNumeroDuDispensateur(string numeroDispensateur)
        {
            var builder = new NomFichierGabaritPDFConfirmationBuilder();
            HeureSysteme.Now = () => new DateTime(2017, 4, 20, 17, 57, 30);

            var nomFichier = builder.Construire(numeroDispensateur, HeureSysteme.Now());

            var nomFichierAttendu = "Confr__2017-04-20 17:57:30.pdf";

            Assert.Equal(nomFichierAttendu, nomFichier);
        }

        [Fact]
        public void Construire_UnNumeroDeDispensateurValide_LeNomDuFichierDevraitContenirNumero()
        {
            var builder = new NomFichierGabaritPDFConfirmationBuilder();
            HeureSysteme.Now = () => new DateTime(2017, 4, 20, 17, 57, 30);

            var numeroDispensateur =  "123456";

            var nomFichier = builder.Construire(numeroDispensateur, HeureSysteme.Now());

            Assert.True(nomFichier.Contains(numeroDispensateur));
        }
    }
}