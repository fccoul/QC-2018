namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit.Gabarits
{
    /// <summary> 
    ///  Interface permettant de sérialiser un objet sous format XML
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public interface ISerialiseurXml
    {
        /// <summary>
        /// Sérialise un objet
        /// </summary>
        /// <typeparam name="T">Type de l'objet</typeparam>
        /// <param name="instance">Instance de l'objet</param>
        /// <returns>Retourne un array de byte</returns>
        byte[] Serialiser<T>(T instance);
    }
}