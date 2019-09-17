using System;
using System.Xml.Serialization;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.ConfirmationSuspension
{
    /// <summary> 
    ///  Classe représentant le gabarit XSL pour une confirmation 
    ///  d'une suspension
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    [Serializable, XmlRoot("Rapport")]
    public class GabaritConfirmationSuspension
    {
        /// <summary>
        /// Page
        /// </summary>
        [XmlElement("Pages")]
        public PageConfirmationSuspension Page { get; set; } = new PageConfirmationSuspension();
    }
}