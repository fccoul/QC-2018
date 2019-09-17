namespace RAMQ.PRE.PL_PremMdl_cpo.AvisConformite
{
    /// <summary> 
    ///  « Factory » permettant de créer les référentiels de type IAvisConformite.
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Septembre 2016
    /// </remarks>
    public class AvisConformiteFactory : IAvisConformiteFactory
    {
        #region Méthodes publiques

        /// <summary>
        ///  Instancie le référentiel de type IAvisConformite en fonction de la configuration de 
        ///  l'application.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///  Si la valeur de configuration AvisConformiteSimulation est à « OUI » le référentiel créé
        ///  est une simulation qui n'accède pas aux données réelles.
        /// </remarks>
        public IAvisConformite Instancier()
        {
            IAvisConformite retour = (Utilitaires.ObtenirEnvir() != Environnement.Production && Config.SimulationAvisConformite)
                                   ? (IAvisConformite)new AvisConformiteSimulation() : new AvisConformiteReferentiel();

            return retour;
        }

        #endregion

    }
}