namespace RAMQ.PRE.PL_PremMdl_cpo.DroitAcquis
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDroitAcquisFactory
    {
        /// <summary>
        ///  Instancie le référentiel de type IDroitAcquis en fonction de la configuration de 
        ///  l'application.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///  Si la valeur de configuration DroitAcquisSimulation est à « OUI » le référentiel créé
        ///  est une simulation qui n'accède pas aux données réelles.
        /// </remarks>
        IDroitAcquis Instancier();
    }
}