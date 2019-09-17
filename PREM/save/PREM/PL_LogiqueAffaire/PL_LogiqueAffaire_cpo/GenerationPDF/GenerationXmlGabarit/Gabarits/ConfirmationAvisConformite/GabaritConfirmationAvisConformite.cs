using System;
using System.Xml.Serialization;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.ConfirmationAvisConformite
{
    /// <summary> 
    ///  Classe représentant le gabarit XSL pour un avis de conformité
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    [Serializable, XmlRoot("Rapport")]
    public class GabaritConfirmationAvisConformite
    {
        /// <summary>
        /// Page
        /// </summary>
        [XmlElement("Pages")]
        public PageConfirmationAvisConformite Page { get; set; } = new PageConfirmationAvisConformite();
    }
}