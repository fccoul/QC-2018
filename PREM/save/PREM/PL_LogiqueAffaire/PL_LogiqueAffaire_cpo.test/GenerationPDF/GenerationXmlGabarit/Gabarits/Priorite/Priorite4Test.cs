using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.Priorite;
using Xunit;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.test.GenerationPDF.GenerationXmlGabarit.Gabarits.Priorite
{
    /// <summary> 
    ///  Essais unitaire sur la classe "Priorite4"
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class Priorite4Test
    {
        [Fact]
        public void Priorite4_PossedeUnNumero_LeNumeroDevraitEtreQuatre()
        {
            var priorite = new Priorite4();

            var numeroAttendu = 4;

            Assert.Equal(numeroAttendu, priorite.Numero);
        }
    }
}