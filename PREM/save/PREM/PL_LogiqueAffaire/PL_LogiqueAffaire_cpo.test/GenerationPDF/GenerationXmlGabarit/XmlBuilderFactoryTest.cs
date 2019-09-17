using System;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.ConfirmationAvisConformite;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.ConfirmationDerogation;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.ConfirmationModificationSuspension;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.ConfirmationSuspension;
using Xunit;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.test.GenerationPDF.GenerationXmlGabarit
{
    /// <summary> 
    ///  Essais unitaire sur la classe "XmlBuilderFactory"
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class XmlBuilderFactoryTest
    {
        [Theory]
        [InlineData(TypeGabarit.ConfirmationAvisConformite, typeof(ConfirmationAvisConformiteXmlBuilder))]
        [InlineData(TypeGabarit.ConfirmationSuspension, typeof(ConfirmationSuspensionXmlBuilder))]
        [InlineData(TypeGabarit.ConfirmationModificationSuspension, typeof(ConfirmationModificationSuspensionXmlBuilder))]
        [InlineData(TypeGabarit.ConfirmationDerogation, typeof(ConfirmationDerogationXmlBuilder))]
        public void FabriquerBuilder_SelonTypeGabarit_DevraitRetournerLeBonBuilder(TypeGabarit typeGabarit, Type typeAttendu)
        {
            var fabrique = new XmlBuilderFactory();

            IXmlBuilder builder = fabrique.FabriquerBuilder(typeGabarit);

            Assert.IsType(typeAttendu, builder);
        }

        [Fact]
        public void FabriquerBuilder_TypeGabaritNonSupporte_DevraitLancerUnNotSupportedException()
        {
            Exception ex = Assert.Throws<NotSupportedException>(() =>
            {
                var fabrique = new XmlBuilderFactory();

                IXmlBuilder builder = fabrique.FabriquerBuilder(TypeGabarit.Autre);
            });

            Assert.Contains($"La valeur de la variable typeGabarit : {TypeGabarit.Autre} n'est pas supportée.", ex.Message);
        }
    }
}