using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.Priorite;
using Xunit;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.test.GenerationPDF.GenerationXmlGabarit.Gabarits.Priorite
{
    /// <summary> 
    ///  Essais unitaire sur la classe "Priorite8"
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class Priorite8Test
    {
        [Fact]
        public void Priorite8_PossedeUnNumero_LeNumeroDevraitEtreHuit()
        {
            var priorite = new Priorite8();

            var numeroAttendu = 8;

            Assert.Equal(numeroAttendu, priorite.Numero);
        }
    }
}