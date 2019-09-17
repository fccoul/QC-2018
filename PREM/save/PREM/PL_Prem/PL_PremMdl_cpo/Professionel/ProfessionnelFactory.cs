namespace RAMQ.PRE.PL_PremMdl_cpo.Professionnel
{
    /// <summary> 
    ///  « Factory » permettant de créer les référentiels de type IProfessionnel.
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Septembre 2016
    /// </remarks>
    public class ProfessionnelFactory : IProfessionnelFactory
    {

        #region Méthodes publiques

        /// <summary>
        ///  Instancie le référentiel de type IProfessionnel en fonction de la configuration de 
        ///  l'application.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///  Si la valeur de configuration ProfessionnelSimulation est à « OUI » le référentiel créé
        ///  est une simulation qui n'accède pas aux données réelles.
        /// </remarks>
        public IProfessionnel Instancier()
        {
             IProfessionnel retour = (Utilitaires.ObtenirEnvir() != Environnement.Production && Config.SimulationProfessionnel)
                                      ? (IProfessionnel)new ProfessionnelSimulation() : new ProfessionnelReferentiel();

            return retour;
        }

        #endregion

    }
}