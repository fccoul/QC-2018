using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.Priorite;
using Xunit;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.test.GenerationPDF.GenerationXmlGabarit.Gabarits.Priorite
{
    /// <summary> 
    ///  Essais unitaire sur la classe "Colonne1"
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class Colonne1Test
    {
        [Fact]
        public void Colonne1_PossedeUnNumero_LeNumeroDevraitEtreUn()
        {
            var colonne = new Colonne1();

            var numeroAttendu = 1;

            Assert.Equal(numeroAttendu, colonne.Numero);
        }

        [Fact]
        public void Colonne1_UnTexteEstDefini_DevraitContenirLeTexte()
        {
            var texteAttendu = "Ceci est un texte bidon";

            var colonne = new Colonne1() { Texte = texteAttendu };

            Assert.True(colonne.Texte.Contains(texteAttendu));
        }

        [Fact]
        public void Colonne1_LorsObtentionTexte_DevraitCommencerParUneBaliseParagraphe()
        {
            var colonne = new Colonne1();

            Assert.True(colonne.Texte.StartsWith("<p>"));
        }

        [Fact]
        public void Colonne1_LorsObtentionTexte_DevraitTerminerParUneBaliseDeFinParagraphe()
        {
            var colonne = new Colonne1();

            Assert.True(colonne.Texte.EndsWith("</p>"));
        }
    }
}