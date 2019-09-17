using System;

namespace RAMQ.PRE.PL_Prem_iut.Utilitaires
{
    /// <summary>
    /// Interface du builder pour la création du nom du fichier PDF de confirmation
    /// </summary>
    /// <remarks>
    /// Auteur : Alexis Garon-Michaud
    /// Date   : Avril 2017
    /// </remarks>
    public interface INomFichierGabaritPDFConfirmationBuilder
    {
        /// <summary>
        /// Construire le nom du fichier pour la confirmation PDF
        /// </summary>
        /// <param name="numeroPratiqueDispensateur">Texte contenant le numéro de pratique du dispensateur</param>
        /// <param name="dateHeureCourante">Date heure courante</param>
        /// <returns>Le nom du fichier PDF de confirmation</returns>
        string Construire(string numeroPratiqueDispensateur, DateTime dateHeureCourante);
    }
}