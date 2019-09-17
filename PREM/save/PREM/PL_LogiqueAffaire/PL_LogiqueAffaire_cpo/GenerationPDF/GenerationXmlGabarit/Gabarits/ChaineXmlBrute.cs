using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits
{
    /// <summary> 
    ///  Classe permettant de sérialiser un contenu de texte de façon brute.
    ///  Autrement dit,  le sérialiseur ne va pas réinterpréter le contenu en 
    ///  remplaçant les caractères spéciaux.
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class ChaineXmlBrute : IXmlSerializable
    {
        /// <summary>
        /// Texte
        /// </summary>
        public string Texte { get; set; }

        /// <summary>
        /// Obtenir schéma
        /// </summary>
        /// <returns></returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Lecteur XML
        /// </summary>
        /// <param name="reader">Lecteur XML</param>
        public void ReadXml(XmlReader reader)
        {
            Texte = reader.ReadInnerXml();
        }

        /// <summary>
        /// Éditeur XML
        /// </summary>
        /// <param name="writer">Éditeur XML </param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteRaw(Texte);
        }
    }
}