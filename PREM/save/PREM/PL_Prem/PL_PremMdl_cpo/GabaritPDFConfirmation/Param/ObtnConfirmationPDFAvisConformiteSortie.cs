using RAMQ.ClasseBase;

namespace RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation.Param
{
    /// <summary>
    /// Paramètre de sortie pour l'obtention du gabarit PDF de confirmation
    /// pour un avis de conformité
    /// </summary>
    /// <remarks>
    /// Auteur : Alexis Garon-Michaud
    /// Date   : Avril 2017
    /// </remarks>
    public class ObtnConfirmationPDFAvisConformiteSortie : ParamSorti
    {
        /// <summary>
        /// Gabarit PDF
        /// </summary>
        public byte[] GabaritPDF { get; set; }
    }
}