using System;

namespace RAMQ.PRE.PL_Prem_iut.Utilitaires
{
    /// <summary>
    /// Builder pour la création du nom du fichier PDF de confirmation
    /// </summary>
    /// <remarks>
    /// Auteur : Alexis Garon-Michaud
    /// Date   : Avril 2017
    /// </remarks>
    public class NomFichierGabaritPDFConfirmationBuilder : INomFichierGabaritPDFConfirmationBuilder
    {
        /// <summary>
        /// Longueur nécessaire pour un numéro de dispensateur
        /// </summary>
        public const int LongueurNumeroDispensateur = 6;

        /// <summary>
        /// Construire le nom du fichier pour la confirmation PDF
        /// </summary>
        /// <param name="numeroPratiqueDispensateur">Texte contenant le numéro de pratique du dispensateur</param>
        /// <param name="dateHeureCourante">Date heure courante</param>
        /// <returns>Le nom du fichier PDF de confirmation</returns>
        public string Construire(string numeroPratiqueDispensateur, DateTime dateHeureCourante)
        {
            var numeroPratique = string.IsNullOrEmpty(numeroPratiqueDispensateur) ||
                                 numeroPratiqueDispensateur.Length < LongueurNumeroDispensateur ?
                                 string.Empty : numeroPratiqueDispensateur.Substring(0, LongueurNumeroDispensateur);

            return $"Confr_{numeroPratique}_{dateHeureCourante.ToString()}.pdf";
        }
    }
}