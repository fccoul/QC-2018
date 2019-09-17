using RAMQ.PRE.PL_PremMdl_cpo.Autorisation.Parametres;

namespace RAMQ.PRE.PL_PremMdl_cpo.Autorisation
{
    /// <summary>
    /// Interface pour le référentiel d'autorisation.
    /// </summary>
    public interface IAutorisation
    {
        /// <summary>
        /// Permet d'annuler une autorisation.
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Les informations sur l'état de l'opération</returns>
        /// <remarks></remarks>
        AnnulerAutorisationPREMQSorti AnnulerAutorisationPREMQ(AnnulerAutorisationPREMQEntre intrant);

        /// <summary>
        /// Permet de créer une autorisation.
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Les informations sur l'état de l'opération</returns>
        /// <remarks></remarks>
        CreerAutorisationPREMQSorti CreerAutorisationPREMQ(CreerAutorisationPREMQEntre intrant);

        /// <summary>
        /// Permet d'obtenir une liste d'autorisation.
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Les informations sur l'état de l'opération</returns>
        /// <remarks></remarks>
        ObtenirLesAutorisationsProfessionnelSorti ObtenirListeAutorisationPREMQ(ObtenirLesAutorisationsProfessionnelEntre intrant);

        /// <summary>
        /// Permet de prolonger une autorisation.
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Les informations sur l'état de l'opération</returns>
        /// <remarks></remarks>
        ProlongerAutorisationPREMQSorti ProlongerAutorisationPREMQ(ProlongerAutorisationPREMQEntre intrant);
    }
}