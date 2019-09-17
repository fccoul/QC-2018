using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.Priorite;
using Xunit;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.test.GenerationPDF.GenerationXmlGabarit.Gabarits.Priorite
{
    /// <summary> 
    ///  Essais unitaire sur la classe "Priorite5"
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class Priorite5Test
    {
        [Fact]
        public void Priorite5_PossedeUnNumero_LeNumeroDevraitEtreCinq()
        {
            var priorite = new Priorite5();

            var numeroAttendu = 5;

            Assert.Equal(numeroAttendu, priorite.Numero);
        }
    }
}