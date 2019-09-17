using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.Priorite;
using Xunit;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.test.GenerationPDF.GenerationXmlGabarit.Gabarits.Priorite
{
    /// <summary> 
    ///  Essais unitaire sur la classe "Priorite6"
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class Priorite6Test
    {
        [Fact]
        public void Priorite6_PossedeUnNumero_LeNumeroDevraitEtreSix()
        {
            var priorite = new Priorite6();

            var numeroAttendu = 6;

            Assert.Equal(numeroAttendu, priorite.Numero);
        }
    }
}