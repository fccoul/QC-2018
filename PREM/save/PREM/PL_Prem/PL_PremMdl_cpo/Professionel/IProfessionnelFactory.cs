namespace RAMQ.PRE.PL_PremMdl_cpo.Professionnel
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProfessionnelFactory
    {
        /// <summary>
        ///  Instancie le référentiel de type IProfessionnel en fonction de la configuration de 
        ///  l'application.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///  Si la valeur de configuration ProfessionnelSimulation est à « OUI » le référentiel créé
        ///  est une simulation qui n'accède pas aux données réelles.
        /// </remarks>
        IProfessionnel Instancier();
    }
}