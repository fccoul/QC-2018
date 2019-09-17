namespace RAMQ.PRE.PL_PremMdl_cpo.DemandeReevaluation
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDemandeReevaluationFactory
    {
        /// <summary>
        ///  Instancie le référentiel de type IDemandeReevaluation en fonction de la configuration de 
        ///  l'application.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///  Si la valeur de configuration DemandeReevaluationSimulation est à « OUI » le référentiel créé
        ///  est une simulation qui n'accède pas aux données réelles.
        /// </remarks>
        IDemandeReevaluation Instancier();
    }
}