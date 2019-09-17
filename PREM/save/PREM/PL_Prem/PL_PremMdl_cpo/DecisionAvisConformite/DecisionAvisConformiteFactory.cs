namespace RAMQ.PRE.PL_PremMdl_cpo.DecisionAvisConformite
{
    /// <summary> 
    ///  « Factory » permettant de créer les référentiels de type IDecisionAvisConformite.
    /// </summary>
    /// <remarks>
    ///  Auteur : Sébastien Bourdages <br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    public class DecisionAvisConformiteFactory : IDecisionAvisConformiteFactory
    {
        #region Méthodes publiques

        /// <summary>
        ///  Instancie le référentiel de type IDecisionAvisConf en fonction de la configuration de 
        ///  l'application.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///  Si la valeur de configuration DecisionAvisConfSimulation est à « OUI » le référentiel créé
        ///  est une simulation qui n'accède pas aux données réelles.
        /// </remarks>
        public IDecisionAvisConformite Instancier()
        {
            IDecisionAvisConformite retour = (Utilitaires.ObtenirEnvir() != Environnement.Production && Config.SimulationDecisionAvisConformite)
                                             ? (IDecisionAvisConformite)new DecisionAvisConformiteSimulation() : new DecisionAvisConformiteReferentiel();

            return retour;
        }

        #endregion
    }
}