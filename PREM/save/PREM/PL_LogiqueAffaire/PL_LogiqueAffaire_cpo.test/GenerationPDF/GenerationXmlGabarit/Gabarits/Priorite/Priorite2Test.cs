using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.Priorite;
using Xunit;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.test.GenerationPDF.GenerationXmlGabarit.Gabarits.Priorite
{
    /// <summary> 
    ///  Essais unitaire sur la classe "Priorite2"
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class Priorite2Test
    {
        [Fact]
        public void Priorite2_PossedeUnNumero_LeNumeroDevraitEtreDeux()
        {
            var priorite = new Priorite2();

            var numeroAttendu = 2;

            Assert.Equal(numeroAttendu, priorite.Numero);
        }
    }
}