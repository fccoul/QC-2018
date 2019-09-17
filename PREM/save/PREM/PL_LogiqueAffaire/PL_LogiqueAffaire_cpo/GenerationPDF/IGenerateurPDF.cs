using System.Collections.Generic;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationPDF
{
    /// <summary> 
    ///  Interface pour la génération d'un fichier PDF
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public interface IGenerateurPDF
    {
        /// <summary>
        /// Générer fichier PDF
        /// </summary>
        /// <param name="typeGabarit">Type de gabarit</param>
        /// <param name="priorites">Liste des priorités</param>
        /// <returns>Retourne un fichier PDF soit faire d'array de byte</returns>
        byte[] Generer(TypeGabarit typeGabarit, IList<string> priorites);
    }
}