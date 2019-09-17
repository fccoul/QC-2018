namespace RAMQ.PRE.PL_Prem_iut.ControllersHelpers
{
    /// <summary>
    /// Interface de la classe LieuGeographiqueHelpers
    /// </summary>
    public interface ILieuGeographiqueHelpers
    {
        /// <summary>
        /// Fonction permettant d'obtenir le territoire RSS de l'utilisateur courant.
        /// </summary>
        /// <returns>Territoire RSS</returns>
        string ObtenirNomTerritoireRSSUtilisateurCourant();
    }
}