using RAMQ.PRE.PRE_Entites_cpo.Autorisation.Parametre;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Professionnel.Interface
{
    /// <summary> 
    ///  Interface des autorisations
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Décembre 2016
    /// </remarks>
    public interface IAutorisation
    {

        /// <summary>
        /// Permet d'obtenir les autorisations d'un professionnel de la santé
        /// </summary>
        /// <param name="intrant">Paramètres d'entré</param>
        /// <returns>Une liste d'autorisations d'un professionnel de la santé</returns>
        ObtenirLesAutorisationsProfessionnelSorti ObtenirAutorisationsProfessionnelSante(ObtenirLesAutorisationsProfessionnelEntre intrant);
    }
}