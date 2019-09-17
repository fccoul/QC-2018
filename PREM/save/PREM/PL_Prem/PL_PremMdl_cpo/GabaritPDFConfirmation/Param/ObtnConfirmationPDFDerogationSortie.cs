using RAMQ.ClasseBase;

namespace RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation.Param
{
    /// <summary>
    /// Paramètre de sortie pour l'obtention du gabarit PDF de confirmation
    /// pour une dérogation
    /// </summary>
    /// <remarks>
    /// Auteur : Alexis Garon-Michaud
    /// Date   : Avril 2017
    /// </remarks>
    public class ObtnConfirmationPDFDerogationSortie : ParamSorti
    {
        /// <summary>
        /// Gabarit PDF
        /// </summary>
        public byte[] GabaritPDF { get; set; }
    }
}