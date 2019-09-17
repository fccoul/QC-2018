using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.Priorite;
using Xunit;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.test.GenerationPDF.GenerationXmlGabarit.Gabarits.Priorite
{
    /// <summary> 
    ///  Essais unitaire sur la classe "Priorite3"
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class Priorite3Test
    {
        [Fact]
        public void Priorite3_PossedeUnNumero_LeNumeroDevraitEtreTrois()
        {
            var priorite = new Priorite3();

            var numeroAttendu = 3;

            Assert.Equal(numeroAttendu, priorite.Numero);
        }
    }
}