using System;
using NSubstitute;
using Ploeh.AutoFixture;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationGabaritXSL;
using RAMQ.Rapports.RenderX;
using Xunit;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.test.GenerationPDF.GenerationGabaritXSL
{
    /// <summary> 
    ///  Essais unitaire sur la classe "GenerateurGabaritXSL"
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class GenerateurGabaritXSLTest : Base.TestBase
    {
        const string CheminFichierXSL = "chemin vers le fichier XSL";

        [Fact]
        public void LorsInstanciation_LaDependanceDeRenderXEstAbsente_DevraitRetournerArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => 
            {
                var generateurGabarit = new GenerateurGabaritXSL(null);
            });
        }

        [Fact]
        public void GenererGabaritXSL_LeCheminDuGabaritEstVide_DevraitRetournerArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => 
            {
                var renderX = Substitute.For<IRenderX>();
                var generateurGabarit = new GenerateurGabaritXSL(renderX);
                generateurGabarit.GenererGabaritXSL(null, new byte[] { });
            });
        }

        [Fact]
        public void GenererGabaritXSL_LeContenuDuXmlEstNul_DevraitRetournerArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => 
            {
                var renderX = Substitute.For<IRenderX>();
                var generateurGabarit = new GenerateurGabaritXSL(renderX);
                generateurGabarit.GenererGabaritXSL(CheminFichierXSL, null);
            });
        }

        [Fact]
        public void GenererGabaritXSL_RenderXRetourneUnGabarit_LeGabaritEnSortieDevraitEtreIdentique()
        {
            var renderX = Substitute.For<IRenderX>();
            var fichierPdfGenererParRenderX = Fixture.Create<byte[]>();

            renderX.FusionnerDocXSLFO(Arg.Any<string>(), Arg.Any<byte[]>()).Returns(fichierPdfGenererParRenderX);

            var generateurGabarit = new GenerateurGabaritXSL(renderX);

            var fichierPdf = generateurGabarit.GenererGabaritXSL(CheminFichierXSL, new byte[] { });

            Assert.Equal(fichierPdfGenererParRenderX, fichierPdf);
        }
    }
}