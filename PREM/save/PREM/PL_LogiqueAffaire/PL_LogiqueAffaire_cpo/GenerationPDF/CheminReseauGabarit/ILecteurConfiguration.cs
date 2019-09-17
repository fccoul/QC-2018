namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.CheminReseauGabarit
{
    /// <summary> 
    ///  Interface permettant de lire des configurations
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public interface ILecteurConfiguration
    {
        /// <summary>
        /// Lire une configuration dans la section AppSettings
        /// </summary>
        /// <param name="nomCleConfiguration"></param>
        /// <returns>Retourne la valeur de la clé de configuration passée en paramètre.</returns>
        string LireConfiguration(string nomCleConfiguration);
    }
}