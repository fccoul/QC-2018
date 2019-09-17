using System.Text;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits;
using Xunit;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.test.GenerationPDF.GenerationXmlGabarit.Gabarits
{
    /// <summary> 
    ///  Essais unitaire sur la classe "SerialiseurXml"
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class SerialiseurXmlTest
    {
        [Fact]
        public void Serialiser_UnObjetQuelconque_DevraitContenirEncodingUTF8DansEntete()
        {
            var serialiseur = new SerialiseurXml();

            var contenuSerialise = serialiseur.Serialiser(new object());

            var contenuSousFormeTexte = Encoding.UTF8.GetString(contenuSerialise);

            Assert.True(contenuSousFormeTexte.Contains("<?xml version=\"1.0\" encoding=\"utf-8\"?>"));
        }
    }
}