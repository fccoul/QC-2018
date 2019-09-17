namespace RAMQ.PRE.PL_PremMdl_cpo.LieuGeographique
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILieuGeographiqueFactory
    {
        /// <summary>
        ///  Instancie le référentiel de type ILieuGeographique en fonction de la configuration de 
        ///  l'application.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///  Si la valeur de configuration LieuGeographiqueSimulation est à « OUI » le référentiel créé
        ///  est une simulation qui n'accède pas aux données réelles.
        /// </remarks>
        ILieuGeographique Instancier();
    }
}