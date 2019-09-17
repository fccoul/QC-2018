namespace RAMQ.PRE.PL_PremMdl_cpo.DroitAcquis
{
    /// <summary> 
    ///  « Factory » permettant de créer les référentiels de type IDroitAcquis.
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : 2016-10-11
    /// </remarks>
    public class DroitAcquisFactory : IDroitAcquisFactory
    {

        #region Méthodes publiques

        /// <summary>
        ///  Instancie le référentiel de type IDroitAcquis en fonction de la configuration de 
        ///  l'application.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///  Si la valeur de configuration DroitAcquisSimulation est à « OUI » le référentiel créé
        ///  est une simulation qui n'accède pas aux données réelles.
        /// </remarks>
        public IDroitAcquis Instancier()
        {

            IDroitAcquis retour = (Utilitaires.ObtenirEnvir() != Environnement.Production && Config.SimulationDroitAcquis)
                                ? (IDroitAcquis)new DroitAcquisSimulation() : new DroitAcquisReferentiel();

            return retour;
        }

        #endregion

    }
}