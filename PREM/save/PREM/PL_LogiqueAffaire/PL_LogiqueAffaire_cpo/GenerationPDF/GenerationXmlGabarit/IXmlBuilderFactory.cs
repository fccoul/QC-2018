namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationXmlGabarit
{
    /// <summary> 
    ///  Interface permettant de fabriquer le bon XmlBuilder selon le
    ///  type de gabarit
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public interface IXmlBuilderFactory
    {
        /// <summary>
        /// Fabriquer le builder spécifique pour construire le XML
        /// </summary>
        /// <param name="typeGabarit">Type de gabarit</param>
        /// <returns>Retourne le bon builder tout dépendamment du type de gabarit</returns>
        IXmlBuilder FabriquerBuilder(TypeGabarit typeGabarit);
    }
}