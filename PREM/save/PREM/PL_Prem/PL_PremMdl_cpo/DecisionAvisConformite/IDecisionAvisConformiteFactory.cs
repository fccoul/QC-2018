namespace RAMQ.PRE.PL_PremMdl_cpo.DecisionAvisConformite
{
    /// <summary>
    ///  Interface de « Factory » permettant de d'obtenir les informations des décision d'avis de conformité.
    /// </summary>
    /// <remarks>
    ///  Auteur : Sébastien Bourdages <br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    public interface IDecisionAvisConformiteFactory
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
        IDecisionAvisConformite Instancier();
    }
}