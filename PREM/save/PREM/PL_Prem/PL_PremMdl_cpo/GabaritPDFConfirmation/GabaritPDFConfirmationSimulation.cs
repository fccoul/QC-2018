using System.IO;
using RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation.Param;

namespace RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation
{
    /// <summary>
    /// Classe offrant les fonctionnalités pour récupérer les gabarits de confirmation
    /// en mode simulation
    /// </summary>
    /// <remarks>
    /// Auteur : Alexis Garon-Michaud
    /// Date   : Avril 2017
    /// </remarks>
    public class GabaritPDFConfirmationSimulation : IGabaritPDFConfirmation
    {
        /// <summary>
        /// Permet de récupérer une confirmation PDF selon l'action faite sur un 
        /// avis de conformité
        /// </summary>
        /// <param name="paramEntre">Paramètre d'entrée</param>
        /// <returns>Retourne une confirmation PDF</returns>
        public ObtnConfirmationPDFAvisConformiteSortie ObtenirConfirmationPDFAvisConformite(ObtnConfirmationPDFAvisConformiteEntre paramEntre)
        {
            return new ObtnConfirmationPDFAvisConformiteSortie() { GabaritPDF = ObtenirFichierPDFSimulation() };
        }

        /// <summary>
        /// Permet de récupérer une confirmation PDF selon l'action faite sur
        /// une dérogation
        /// </summary>
        /// <param name="paramEntre">Paramètre d'entrée</param>
        /// <returns>Retourne une confirmation PDF</returns>
        public ObtnConfirmationPDFDerogationSortie ObtenirConfirmationPDFDerogation(ObtnConfirmationPDFDerogationEntre paramEntre)
        {
            return new ObtnConfirmationPDFDerogationSortie() { GabaritPDF = ObtenirFichierPDFSimulation() };
        }

        /// <summary>
        /// Permet de récupérer une confirmation PDF selon l'action faite
        /// sur une suspension
        /// </summary>
        /// <param name="paramEntre">Paramètre d'entrée</param>
        /// <returns>Retourne une confirmation PDF</returns>
        public ObtnConfirmationPDFSuspensionSortie ObtenirConfirmationPDFSuspension(ObtnConfirmationPDFSuspensionEntre paramEntre)
        {
            return new ObtnConfirmationPDFSuspensionSortie() { GabaritPDF = ObtenirFichierPDFSimulation() };
        }

        private byte[] ObtenirFichierPDFSimulation()
        {
            using (FileStream fileStream = new FileStream(@"\\depoappliunit\DonneAppli\Unit\PRE\PRE_LIV00\PL\PDFSimulation.pdf",
                                                          FileMode.Open,
                                                          FileAccess.Read))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    fileStream.CopyTo(memoryStream);
                    return memoryStream.ToArray();
                }
            } 
        }
    }
}