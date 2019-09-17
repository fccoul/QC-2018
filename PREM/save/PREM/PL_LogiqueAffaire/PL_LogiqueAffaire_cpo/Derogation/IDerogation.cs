using RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.Derogation
{
    /// <summary> 
    ///  Interface des dérogations
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    public interface IDerogation
    {

        /// <summary>
        /// Permet de modifier une dérogation d'un professionnel de la santé.
        /// </summary>
        /// <param name="intrant">Information de la dérogation.</param>
        /// <returns>Le nouveau numéro de séquence de la dérogation.</returns>
        /// <remarks></remarks>
        ModifierDerogationSorti ModifierDerogation(ModifierDerogationEntre intrant);

        /// <summary>
        /// Permet d'obtenir les dérogations d'un professionnel de la santé.
        /// </summary>
        /// <param name="intrant">Paramètres d'entrées.</param>
        /// <returns>Liste des dérogations d'un professionnel de la santé.</returns>
        /// <remarks></remarks>
        ObtenirDerogationsProfessionnelSanteSorti ObtenirDerogationProfessionnel(ObtenirDerogationsProfessionnelSanteEntre intrant);

        /// <summary>
        /// Permet de créer une dérogation d'un professionnel de la santé.
        /// </summary>
        /// <param name="intrant">Paramètres d'entrées.</param>
        /// <returns>Liste des dérogations d'un professionnel de la santé.</returns>
        /// <remarks></remarks>
        CreerDerogationSorti CreerDerogation(CreerDerogationEntre intrant);
    }
}
