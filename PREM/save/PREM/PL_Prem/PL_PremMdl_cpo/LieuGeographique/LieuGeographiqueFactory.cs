namespace RAMQ.PRE.PL_PremMdl_cpo.LieuGeographique
{
    /// <summary> 
    ///  « Factory » permettant de créer les référentiels de type IProfessionnel.
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Septembre 2016
    /// </remarks>
    public class LieuGeographiqueFactory : ILieuGeographiqueFactory
    {

        #region Méthodes publiques

        /// <summary>
        ///  Instancie le référentiel de type ILieuGeographique en fonction de la configuration de 
        ///  l'application.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///  Si la valeur de configuration LieuGeographiqueSimulation est à « OUI » le référentiel créé
        ///  est une simulation qui n'accède pas aux données réelles.
        /// </remarks>
        public ILieuGeographique Instancier()
        {
            ILieuGeographique retour = (Utilitaires.ObtenirEnvir() != Environnement.Production && Config.SimulationLieuGeographique)
                                         ? (ILieuGeographique)new LieuGeographiqueSimulation() : new LieuGeographiqueReferentiel();

            return retour;
        }

        #endregion

    }
}