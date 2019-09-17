using RAMQ.PRE.PRE_Entites_cpo.CaracteristiquePratique.Parametre;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.CaracteristiquePratique
{
    /// <summary>
    /// Interface CaracteristiquePratique
    /// </summary>
    /// <remarks>
    /// </remarks>
    public interface ICaracteristiquePratique
    {
        /// <summary>
        /// Permet d'obtenir les caractéristiques pratique RSS
        /// </summary>
        /// <param name="intrant">Paramètres d'entrées</param>
        /// <returns>Liste des caractéristiques pratique</returns>
        /// <remarks></remarks>
        ObtenirCaracteristiquePratiqueRssSorti ObtenirCaracteristiquesPratique(ObtenirCaracteristiquePratiqueRssEntre intrant);
    }
}