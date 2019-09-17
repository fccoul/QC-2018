using System;
using System.Configuration;
using NSubstitute;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.CheminReseauGabarit;
using Xunit;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.test.GenerationPDF.CheminReseauGabarit
{
    /// <summary> 
    ///  Essais unitaire sur la classe "CheminGabarit"
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class CheminGabaritTest
    {
        [Fact]
        public void LorsInstanciation_ILecteurConfigurationEstAbsent_DevraitRetournerArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => 
            {
                var cheminGabarit = new CheminGabarit(null);
            });
        }

        [Fact]
        public void Obtenir_TypeGabaritNestPasPriseEnCharge_DevraitRetournerNotSupportedException()
        {
            Assert.Throws<NotSupportedException>(() => 
            {
                var lecteurConfiguration = Substitute.For<ILecteurConfiguration>();
                var cheminGabarit = new CheminGabarit(lecteurConfiguration);
                var cheminReseauGabarit = cheminGabarit.Obtenir(TypeGabarit.Autre);
            });
        }

        [Theory]
        [InlineData(TypeGabarit.ConfirmationAvisConformite, "GabaritXslConfirmationAvisConformite")]
        [InlineData(TypeGabarit.ConfirmationSuspension, "GabaritXslConfirmationSuspension")]
        [InlineData(TypeGabarit.ConfirmationModificationSuspension, "GabaritXslConfirmationModificationSuspension")]
        [InlineData(TypeGabarit.ConfirmationDerogation, "GabaritXslConfirmationDerogation")]
        public void Obtenir_SelonTypeGabarit_DevraitPasserLaBonneCleAuLecteur(TypeGabarit typeGabarit, string nomCle)
        {
            //Arrange
            string valeurCleBidon = "Bidon";

            var lecteurConfiguration = Substitute.For<ILecteurConfiguration>();
            lecteurConfiguration.LireConfiguration(Arg.Any<string>()).Returns(valeurCleBidon);

            var cheminGabarit = new CheminGabarit(lecteurConfiguration);

            //Act
            var cheminReseauGabarit = cheminGabarit.Obtenir(typeGabarit);

            //Assert
            lecteurConfiguration.Received().LireConfiguration(nomCle);
        }

        [Fact]
        public void Obtenir_LecteurRetourneUneChaineVide_DevraitRetournerConfigurationErrorsException()
        {
            Assert.Throws<ConfigurationErrorsException>(() => 
            {
                var lecteurConfiguration = Substitute.For<ILecteurConfiguration>();
                lecteurConfiguration.LireConfiguration(Arg.Any<string>()).Returns(string.Empty);

                var cheminGabarit = new CheminGabarit(lecteurConfiguration);

                var cheminReseauGabarit = cheminGabarit.Obtenir(TypeGabarit.ConfirmationAvisConformite);
            });
        }

        [Fact]
        public void Obtenir_LecteurRetourneUneValeur_DevraitRetournerLaMemeValeurQueLeLecteur()
        {
            var cheminReseauGabaritAttendu = "valeurCleBidon";
            var lecteurConfiguration = Substitute.For<ILecteurConfiguration>();

            lecteurConfiguration.LireConfiguration(Arg.Any<string>()).Returns(cheminReseauGabaritAttendu);

            var cheminGabarit = new CheminGabarit(lecteurConfiguration);

            var cheminReseauGabarit = cheminGabarit.Obtenir(TypeGabarit.ConfirmationAvisConformite);

            Assert.Equal(cheminReseauGabaritAttendu, cheminReseauGabarit);
        }
    }
}