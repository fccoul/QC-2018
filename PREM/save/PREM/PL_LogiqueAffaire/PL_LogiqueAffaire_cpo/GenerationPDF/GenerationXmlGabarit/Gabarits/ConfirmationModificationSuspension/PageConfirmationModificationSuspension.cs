using System;
using System.Xml.Serialization;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.Priorite;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits.ConfirmationModificationSuspension
{
    /// <summary> 
    ///  Classe qui représente la section "Pages" dans le fichier
    ///  XML pour la confirmation de la modification d'une suspension
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    [Serializable, XmlRoot("Pages")]
    public class PageConfirmationModificationSuspension
    {
        /// <summary>
        /// Priorité 1
        /// </summary>
        public Priorite1 Priorite1 { get; set; } = new Priorite1();

        /// <summary>
        /// Priorité 2
        /// </summary>
        public Priorite2 Priorite2 { get; set; } = new Priorite2();

        /// <summary>
        /// Priorité 3
        /// </summary>
        public Priorite3 Priorite3 { get; set; } = new Priorite3();

        /// <summary>
        /// Priorité 4
        /// </summary>
        public Priorite4 Priorite4 { get; set; } = new Priorite4();

        /// <summary>
        /// Priorité 5
        /// </summary>
        public Priorite5 Priorite5 { get; set; } = new Priorite5();

        /// <summary>
        /// Priorité 6
        /// </summary>
        public Priorite6 Priorite6 { get; set; } = new Priorite6();

        /// <summary>
        /// Priorité 7
        /// </summary>
        public Priorite7 Priorite7 { get; set; } = new Priorite7();

        /// <summary>
        /// Priorité 8
        /// </summary>
        public Priorite8 Priorite8 { get; set; } = new Priorite8();

        /// <summary>
        /// Priorité 9
        /// </summary>
        public Priorite9 Priorite9 { get; set; } = new Priorite9();
    }
}