using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.Professionnel
{
    /// <summary> 
    ///  Interface pour la recherche de professionnels.
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    public interface IRechercherProfessionnel
    {
        /// <summary>
        ///  Obtenir les informations sur la relation dispensateur individu.
        /// </summary>
        /// <param name="intrant">Les critètres de recherche.</param>
        /// <returns>Une liste avec les informations des professionnels.</returns>
        /// <remarks></remarks>
        ObtenirDispensateurIndividuSorti ObtenirInformationProfessionnel(ObtenirDispensateurIndividuEntre intrant);

        /// <summary>
        ///  Obtenir les informations personnelles d'un dispensateur
        /// </summary>
        /// <param name="intrant">Les critètres de recherche.</param>
        /// <returns>Une liste avec les informations des professionnels.</returns>
        /// <remarks></remarks>
        ObtenirInfoPerslDispSorti ObtenirInforPersonnellesDispensateur(ObtenirInfoPerslDispEntre intrant);

    }
}
