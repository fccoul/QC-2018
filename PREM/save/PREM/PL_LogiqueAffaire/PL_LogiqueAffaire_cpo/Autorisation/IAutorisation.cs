using RAMQ.PRE.PL_LogiqueAffaire_cpo.Parametres;
using RAMQ.PRE.PRE_Entites_cpo.Autorisation.Parametre;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.Autorisation
{
    /// <summary>
    ///  Interface pour la gestion des autorisations
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public interface IAutorisation
    {

        /// <summary>
        /// Fonction permettant d'obtenir une liste d'autorisation.
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Retourne les informations de l'obtention d'autorisation</returns>
        ObtenirLesAutorisationsProfessionnelSorti ObtenirAutorisationPREMQ(ObtenirLesAutorisationsProfessionnelEntre intrant);


        /// <summary>
        /// Permet de modifier une Autorisation d'un professionnel de la santé.
        /// </summary>
        /// <param name="intrant">Information de l'autorisation.</param>
        /// <returns>Le nouveau numéro de séquence de la dérogation.</returns>
        /// <remarks></remarks>
        ModifierAutorisationSorti ModifierAutorisation(ModifierAutorisationEntre intrant);

    }
}