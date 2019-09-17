using System.Collections.Generic;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit
{
    /// <summary> 
    ///  Interface pour les builder XML
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public interface IXmlBuilder
    {
        /// <summary>
        /// Construire 
        /// </summary>
        /// <param name="priorites">Liste des priorités à insérer dans le gabarit</param>
        /// <returns>Retourne une structure XML en format d'array de byte selon le type de Gabarit</returns>
        byte[] Construire(IList<string> priorites);
    }
}

