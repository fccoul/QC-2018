using System;
using System.Xml.Serialization;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.ConfirmationModificationSuspension
{
    /// <summary> 
    ///  Classe représentant le gabarit XSL pour la confirmation
    ///  dune modification d'une suspension
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    [Serializable, XmlRoot("Rapport")]
    public class GabaritConfirmationModificationSuspension
    {
        /// <summary>
        /// Page
        /// </summary>
        [XmlElement("Pages")]
        public PageConfirmationModificationSuspension Page { get; set; } = new PageConfirmationModificationSuspension();
    }
}