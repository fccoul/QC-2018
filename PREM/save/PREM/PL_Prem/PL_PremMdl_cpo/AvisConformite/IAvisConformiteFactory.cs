namespace RAMQ.PRE.PL_PremMdl_cpo.AvisConformite
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAvisConformiteFactory
    {
        /// <summary>
        ///  Instancie le référentiel de type IAvisConformite en fonction de la configuration de 
        ///  l'application.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///  Si la valeur de configuration AvisConformiteSimulation est à « OUI » le référentiel créé
        ///  est une simulation qui n'accède pas aux données réelles.
        /// </remarks>
        IAvisConformite Instancier();
    }
}