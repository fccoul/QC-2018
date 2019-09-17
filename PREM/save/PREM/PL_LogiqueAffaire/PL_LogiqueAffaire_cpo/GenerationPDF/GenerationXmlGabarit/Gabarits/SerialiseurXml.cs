using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits
{
    /// <summary> 
    ///  Classe permettant de sérialiser un objet sous format XML
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class SerialiseurXml : ISerialiseurXml
    {
        /// <summary>
        /// Sérialise un objet
        /// </summary>
        /// <typeparam name="T">Type de l'objet</typeparam>
        /// <param name="instance">Instance de l'objet</param>
        /// <returns>Retourne un array de byte</returns>
        public byte[] Serialiser<T>(T instance)
        {
            var encodage = Encoding.UTF8;
            var serialiseur = new XmlSerializer(typeof(T));
            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memoryStream, encodage))
                {
                    serialiseur.Serialize(streamWriter, instance);
                    return memoryStream.ToArray();
                };
            };
        }
    }
}