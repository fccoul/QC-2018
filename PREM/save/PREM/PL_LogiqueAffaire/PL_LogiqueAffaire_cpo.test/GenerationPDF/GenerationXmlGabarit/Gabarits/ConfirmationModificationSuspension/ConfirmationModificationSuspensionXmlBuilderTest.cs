using System;
using System.Collections.Generic;
using NSubstitute;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.ConfirmationModificationSuspension;
using Xunit;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.test.GenerationPDF.GenerationXmlGabarit.Gabarits.ConfirmationModificationSuspension
{
    /// <summary> 
    ///  Essais unitaire sur la classe "ConfirmationModificationSuspensionXmlBuilder"
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class ConfirmationModificationSuspensionXmlBuilderTest : XmlBuilderTestBase
    {
        [Fact]
        public void LorsInstanciation_PasserUnSerialiseurNull_DevraitRetournerArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var builder = new ConfirmationModificationSuspensionXmlBuilder(null);
            });
        }

        [Fact]
        public void Construire_PriorietesEstNulle_DevraitLancerUnArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var serialiseurXml = Substitute.For<ISerialiseurXml>();
                var builder = new ConfirmationModificationSuspensionXmlBuilder(serialiseurXml);
                var sortie = builder.Construire(null);
            });
        }

        [Fact]
        public void Construire_PriorietesContientMoinsPrioriteQueRequis_DevraitLancerUnArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var serialiseurXml = Substitute.For<ISerialiseurXml>();
                var builder = new ConfirmationModificationSuspensionXmlBuilder(serialiseurXml);
                IList<string> priorites = CreerPriorites(ConfirmationModificationSuspensionXmlBuilder.NombrePrioriteRequis - 1);
                var sortie = builder.Construire(priorites);
            });
        }

        [Fact]
        public void Construire_PriorietesContientPlusPrioriteQueRequis_DevraitLancerUnArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var serialiseurXml = Substitute.For<ISerialiseurXml>();
                var builder = new ConfirmationModificationSuspensionXmlBuilder(serialiseurXml);
                IList<string> priorites = CreerPriorites(ConfirmationModificationSuspensionXmlBuilder.NombrePrioriteRequis + 1);
                var sortie = builder.Construire(priorites);
            });
        }

        [Fact]
        public void Construire_Priorites_DevraitMapperCorrectementLesPrioritesDansLeTexteDesColonnes()
        {
            var serialiseurXml = Substitute.For<ISerialiseurXml>();

            var builder = new ConfirmationModificationSuspensionXmlBuilder(serialiseurXml);
            IList<string> priorites = CreerPriorites(ConfirmationModificationSuspensionXmlBuilder.NombrePrioriteRequis);
            var sortie = builder.Construire(priorites);

            Assert.True(builder.Gabarit.Page.Priorite1.Ligne1.Colonne1.Texte.Contains(priorites[0]));
            Assert.True(builder.Gabarit.Page.Priorite2.Ligne1.Colonne1.Texte.Contains(priorites[1]));
            Assert.True(builder.Gabarit.Page.Priorite3.Ligne1.Colonne1.Texte.Contains(priorites[2]));
            Assert.True(builder.Gabarit.Page.Priorite4.Ligne1.Colonne1.Texte.Contains(priorites[3]));
            Assert.True(builder.Gabarit.Page.Priorite5.Ligne1.Colonne1.Texte.Contains(priorites[4]));
            Assert.True(builder.Gabarit.Page.Priorite6.Ligne1.Colonne1.Texte.Contains(priorites[5]));
            Assert.True(builder.Gabarit.Page.Priorite7.Ligne1.Colonne1.Texte.Contains(priorites[6]));
            Assert.True(builder.Gabarit.Page.Priorite8.Ligne1.Colonne1.Texte.Contains(priorites[7]));
            Assert.True(builder.Gabarit.Page.Priorite9.Ligne1.Colonne1.Texte.Contains(priorites[8]));
        }
    }
}