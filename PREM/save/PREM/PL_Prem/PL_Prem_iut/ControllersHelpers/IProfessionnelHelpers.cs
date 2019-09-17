using RAMQ.PRE.PL_Prem_iut.Entite;

namespace RAMQ.PRE.PL_Prem_iut.ControllersHelpers
{
    /// <summary>
    /// Interface de la classe ProfesionnelHelpers.
    /// </summary>
    public interface IProfessionnelHelpers
    {
        /// <summary>
        /// Fonction permettant de rechercher les information d'un professionnel.
        /// </summary>
        /// <param name="intrant">Paramètres d'appel de la fonction </param>
        /// <returns>Zone de retour.</returns>
        RechercheProfessionnelInformation ObtenirProfessionnelRecherche(RechercheProfessionnel intrant);
    }
}