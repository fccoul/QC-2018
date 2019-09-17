using RAMQ.ClasseBase;

namespace RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation.Param
{
    /// <summary>
    /// Paramètre de sortie pour l'obtention du gabarit PDF de confirmation
    /// pour une suspension
    /// </summary>
    /// <remarks>
    /// Auteur : Alexis Garon-Michaud
    /// Date   : Avril 2017
    /// </remarks>
    public class ObtnConfirmationPDFSuspensionSortie : ParamSorti
    {
        /// <summary>
        /// Gabarit PDF
        /// </summary>
        public byte[] GabaritPDF { get; set; }
    }
}