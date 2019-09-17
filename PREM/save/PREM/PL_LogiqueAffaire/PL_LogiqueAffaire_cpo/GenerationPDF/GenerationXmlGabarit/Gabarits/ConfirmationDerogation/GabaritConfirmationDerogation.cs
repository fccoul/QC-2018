using System;
using System.Xml.Serialization;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.ConfirmationDerogation
{
    /// <summary> 
    ///  Classe représentant le gabarit XSL pour une confirmation 
    ///  d'une dérogation
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    [Serializable, XmlRoot("Rapport")]
    public class GabaritConfirmationDerogation
    {
        /// <summary>
        /// Page
        /// </summary>
        [XmlElement("Pages")]
        public PageConfirmationDerogation Page { get; set; } = new PageConfirmationDerogation();
    }
}