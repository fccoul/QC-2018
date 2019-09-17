using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.Priorite;
using Xunit;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.test.GenerationPDF.GenerationXmlGabarit.Gabarits.Priorite
{
    /// <summary> 
    ///  Essais unitaire sur la classe "Ligne1"
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class Ligne1Test
    {
        [Fact]
        public void Ligne1_PossedeUnNumero_LeNumeroDevraitEtreUn()
        {
            var ligne = new Ligne1();

            var numeroAttendu = 1;

            Assert.Equal(numeroAttendu, ligne.Numero);
        }
    }
}