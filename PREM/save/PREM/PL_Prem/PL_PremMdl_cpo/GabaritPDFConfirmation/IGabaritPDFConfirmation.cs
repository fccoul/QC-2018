using RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation.Param;

namespace RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation
{
    /// <summary>
    /// Interface offrant les fonctionnalités pour récupérer les PDF de confirmation
    /// </summary>
    /// <remarks>
    /// Auteur : Alexis Garon-Michaud
    /// Date   : Avril 2017
    /// </remarks>
    public interface IGabaritPDFConfirmation
    {
        /// <summary>
        /// Permet de récupérer une confirmation PDF selon l'action faite sur un 
        /// avis de conformité
        /// </summary>
        /// <param name="paramEntre">Paramètre d'entrée</param>
        /// <returns>Retourne une confirmation PDF</returns>
        ObtnConfirmationPDFAvisConformiteSortie ObtenirConfirmationPDFAvisConformite(ObtnConfirmationPDFAvisConformiteEntre paramEntre);

        /// <summary>
        /// Permet de récupérer une confirmation PDF selon l'action faite sur
        /// une dérogation
        /// </summary>
        /// <param name="paramEntre">Paramètre d'entrée</param>
        /// <returns>Retourne une confirmation PDF</returns>
        ObtnConfirmationPDFDerogationSortie ObtenirConfirmationPDFDerogation(ObtnConfirmationPDFDerogationEntre paramEntre);

        /// <summary>
        /// Permet de récupérer une confirmation PDF selon l'action faite
        /// sur une suspension
        /// </summary>
        /// <param name="paramEntre">Paramètre d'entrée</param>
        /// <returns>Retourne une confirmation PDF</returns>
        ObtnConfirmationPDFSuspensionSortie ObtenirConfirmationPDFSuspension(ObtnConfirmationPDFSuspensionEntre paramEntre);
    }
}