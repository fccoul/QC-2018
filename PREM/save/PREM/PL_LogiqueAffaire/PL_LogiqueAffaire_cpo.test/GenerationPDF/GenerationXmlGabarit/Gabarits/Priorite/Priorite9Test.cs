using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.Priorite;
using Xunit;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.test.GenerationPDF.GenerationXmlGabarit.Gabarits.Priorite
{
    /// <summary> 
    ///  Essais unitaire sur la classe "Priorite9"
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class Priorite9Test
    {
        [Fact]
        public void Priorite9_PossedeUnNumero_LeNumeroDevraitEtreNeuf()
        {
            var priorite = new Priorite9();

            var numeroAttendu = 9;

            Assert.Equal(numeroAttendu, priorite.Numero);
        }
    }
}