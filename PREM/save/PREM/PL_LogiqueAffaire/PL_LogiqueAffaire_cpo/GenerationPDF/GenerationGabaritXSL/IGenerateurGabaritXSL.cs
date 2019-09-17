namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationGabaritXSL
{

    /// <summary> 
    ///  Interface pour la génération des gabarits XSL
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public interface IGenerateurGabaritXSL
    {
        /// <summary>
        /// Générer un gabarit XSL
        /// </summary>
        /// <param name="cheminGabaritXSL">chemin du gabarit XSL</param>
        /// <param name="fichierXml">Contenu du fichier XML</param>
        /// <returns>Retourne un gabarit XSL</returns>
        byte[] GenererGabaritXSL(string cheminGabaritXSL, byte[] fichierXml);
    }
}