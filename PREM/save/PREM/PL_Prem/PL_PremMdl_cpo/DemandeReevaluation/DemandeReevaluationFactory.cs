namespace RAMQ.PRE.PL_PremMdl_cpo.DemandeReevaluation
{
    /// <summary> 
    ///  « Factory » permettant de créer les référentiels de type IDemandeReevaluation.
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Septembre 2016
    /// </remarks>
    public class DemandeReevaluationFactory : IDemandeReevaluationFactory
    {
        #region Méthodes publiques

        /// <summary>
        ///  Instancie le référentiel de type IAvisConformite en fonction de la configuration de 
        ///  l'application.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///  Si la valeur de configuration DemandeReevaluationSimulation est à « OUI » le référentiel créé
        ///  est une simulation qui n'accède pas aux données réelles.
        /// </remarks>
        public IDemandeReevaluation Instancier()
        {
            IDemandeReevaluation retour = (Utilitaires.ObtenirEnvir() != Environnement.Production && Config.SimulationDemandeReevaluation)
                                   ? (IDemandeReevaluation)new DemandeReevaluationSimulation() : new DemandeReevaluationReferentiel();

            return retour;
        }

        #endregion

    }
}