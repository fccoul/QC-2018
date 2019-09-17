using System;
using System.Collections.Generic;
using NSubstitute;
using Ploeh.AutoFixture;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.CheminReseauGabarit;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationGabaritXSL;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationPDF;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.test.Base;
using Xunit;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.test.GenerationPDF
{
    /// <summary> 
    ///  Essais unitaire sur la classe "GenerationPDF"
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class GenerateurPDFTest : TestBase
    {
        [Fact]
        public void LorsInstanciation_IXmlBuilderFactoryEstAbsent_DevraitRetournerArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var cheminGabarit = Substitute.For<ICheminGabarit>();
                var generateurGabaritXSL = Substitute.For<IGenerateurGabaritXSL>();

                var generateurPDF = new GenerateurPDF(null, cheminGabarit, generateurGabaritXSL);
            });
        }

        [Fact]
        public void LorsInstanciation_ICheminGabaritEstAbsent_DevraitRetournerArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var xmlBuilderFactory = Substitute.For<IXmlBuilderFactory>();
                var generateurGabaritXSL = Substitute.For<IGenerateurGabaritXSL>();

                var generateurPDF = new GenerateurPDF(xmlBuilderFactory, null, generateurGabaritXSL);
            });
        }

        [Fact]
        public void LorsInstanciation_IGenerateurGabaritXSLEstAbsent_DevraitRetournerArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var xmlBuilderFactory = Substitute.For<IXmlBuilderFactory>();
                var cheminGabarit = Substitute.For<ICheminGabarit>();

                var generateurPDF = new GenerateurPDF(xmlBuilderFactory, cheminGabarit, null);
            });
        }

        [Fact]
        public void Generer_UnTypeDeGabaritEnEntree_LeXmlBuilderFactoryDevraitUtiliserLeMemeTypeDeGabarit()
        {
            var xmlBuilderFactory = Substitute.For<IXmlBuilderFactory>();
            var cheminGabarit = Substitute.For<ICheminGabarit>();
            var generateurGabaritXSL = Substitute.For<IGenerateurGabaritXSL>();
            var generateurPDF = new GenerateurPDF(xmlBuilderFactory, cheminGabarit, generateurGabaritXSL);
            var priorites = Fixture.Create<IList<string>>();
            var typeGabarit = TypeGabarit.Autre;

            generateurPDF.Generer(typeGabarit, priorites);

            xmlBuilderFactory.Received().FabriquerBuilder(typeGabarit);
        }

        [Fact]
        public void Generer_DesPrioritesEnEntree_LeXmlBuildeDevraitUtiliserLesBonnesPriorites()
        {
            //Arrange
            var xmlBuilderFactory = Substitute.For<IXmlBuilderFactory>();
            var cheminGabarit = Substitute.For<ICheminGabarit>();
            var generateurGabaritXSL = Substitute.For<IGenerateurGabaritXSL>();
            var xmlBuilder = Substitute.For<IXmlBuilder>();
            var generateurPDF = new GenerateurPDF(xmlBuilderFactory, cheminGabarit, generateurGabaritXSL);

            xmlBuilder.Construire(Arg.Any<IList<string>>());
            generateurPDF.XmlBuilder = xmlBuilder;

            var priorites = Fixture.Create<IList<string>>();
            var typeGabarit = TypeGabarit.Autre;

            //Act
            generateurPDF.Generer(typeGabarit, priorites);

            //Assert
            xmlBuilder.Received().Construire(priorites);
        }

        [Fact]
        public void Generer_UnTypeDeGabaritEnEntree_LeCheminGabaritDevraitUtiliserLeMemeTypeDeGabarit()
        {
            var xmlBuilderFactory = Substitute.For<IXmlBuilderFactory>();
            var cheminGabarit = Substitute.For<ICheminGabarit>();
            var generateurGabaritXSL = Substitute.For<IGenerateurGabaritXSL>();
            var generateurPDF = new GenerateurPDF(xmlBuilderFactory, cheminGabarit, generateurGabaritXSL);
            var priorites = Fixture.Create<IList<string>>();
            var typeGabarit = TypeGabarit.Autre;

            generateurPDF.Generer(typeGabarit, priorites);

            cheminGabarit.Received().Obtenir(typeGabarit);
        }

        [Fact]
        public void Generer_LeCheminGabaritRetourneUnCheminSurLeReseau_LeGenerateurGabaritXSLDevraitUtiliserLeCheminTrouve()
        {
            //Arrange
            var xmlBuilderFactory = Substitute.For<IXmlBuilderFactory>();
            var cheminGabarit = Substitute.For<ICheminGabarit>();
            var generateurGabaritXSL = Substitute.For<IGenerateurGabaritXSL>();
            var cheminReseauGabarit = Fixture.Create<string>();

            cheminGabarit.Obtenir(Arg.Any<TypeGabarit>()).Returns(cheminReseauGabarit);

            var generateurPDF = new GenerateurPDF(xmlBuilderFactory, cheminGabarit, generateurGabaritXSL);
            var priorites = Fixture.Create<IList<string>>();
            var typeGabarit = TypeGabarit.Autre;

            //Act
            generateurPDF.Generer(typeGabarit, priorites);

            //Assert
            generateurGabaritXSL.Received().GenererGabaritXSL(cheminReseauGabarit, Arg.Any<byte[]>());
        }

        [Fact]
        public void Generer_LeXmlBuilderRetourneUnXML_LeGenerateurGabaritXSLDevraitUtiliserLeXML()
        {
            //Arrange
            var xmlBuilderFactory = Substitute.For<IXmlBuilderFactory>();
            var cheminGabarit = Substitute.For<ICheminGabarit>();
            var generateurGabaritXSL = Substitute.For<IGenerateurGabaritXSL>();
            var xmlBuilder = Substitute.For<IXmlBuilder>();
            var generateurPDF = new GenerateurPDF(xmlBuilderFactory, cheminGabarit, generateurGabaritXSL);
            var xml = Fixture.Create<byte[]>();

            xmlBuilder.Construire(Arg.Any<IList<string>>()).Returns(xml);
            generateurPDF.XmlBuilder = xmlBuilder;

            var priorites = Fixture.Create<IList<string>>();
            var typeGabarit = TypeGabarit.Autre;

            //Act
            generateurPDF.Generer(typeGabarit, priorites);

            //Assert
            generateurGabaritXSL.Received().GenererGabaritXSL(Arg.Any<string>(), xml);
        }

        [Fact]
        public void Generer_LeGenerateurDeGabaritXSLRetournePDF_LePDFRetourneDevraitEtreLeMeme()
        {
            //Arrange
            var xmlBuilderFactory = Substitute.For<IXmlBuilderFactory>();
            var cheminGabarit = Substitute.For<ICheminGabarit>();
            var generateurGabaritXSL = Substitute.For<IGenerateurGabaritXSL>();
            var fichierPDFRenderX = Fixture.Create<byte[]>();

            generateurGabaritXSL.GenererGabaritXSL(Arg.Any<string>(), Arg.Any<byte[]>()).Returns(fichierPDFRenderX);
            var generateurPDF = new GenerateurPDF(xmlBuilderFactory, cheminGabarit, generateurGabaritXSL);

            var priorites = Fixture.Create<IList<string>>();
            var typeGabarit = TypeGabarit.Autre;

            //Act
            var fichierPDF =  generateurPDF.Generer(typeGabarit, priorites);

            //Assert
            Assert.Equal(fichierPDFRenderX, fichierPDF);
        }
    }
}