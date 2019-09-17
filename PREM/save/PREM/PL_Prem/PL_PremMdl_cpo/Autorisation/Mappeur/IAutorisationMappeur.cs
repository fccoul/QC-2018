using ParametreTravail = RAMQ.PRE.PL_PremMdl_cpo.Autorisation.Parametres;
using ParametreService = RAMQ.PRE.PL_PremMdl_cpo.svcSaisAutorActivMdcal;

namespace RAMQ.PRE.PL_PremMdl_cpo.Autorisation.Mappeur
{
    /// <summary>
    /// Interface pour les mappeurs des autorisations.
    /// </summary>
    public interface IAutorisationMappeur
    {
        /// <summary>
        /// Permet de mapper les paramètre de CreerAutorisationPREMQEntre.
        /// </summary>
        /// <param name="intrant">Paramètre de travail</param>
        /// <returns>Paramètre de service</returns>
        ParametreService.CreerAutorisationPREMQEntre Mapper(ParametreTravail.CreerAutorisationPREMQEntre intrant);

        /// <summary>
        /// Permet de mapper les paramètre de ObtenirAutorisationPREMQEntre.
        /// </summary>
        /// <param name="intrant">Paramètre de travail</param>
        /// <returns>Paramètre de service</returns>
        ParametreService.ObtenirLesAutorisationsProfessionnelEntre Mapper(ParametreTravail.ObtenirLesAutorisationsProfessionnelEntre intrant);

        /// <summary>
        /// Permet de mapper les paramètre de ProlongerAutorisationPREMQEntre.
        /// </summary>
        /// <param name="intrant">Paramètre de travail</param>
        /// <returns>Paramètre de service</returns>
        ParametreService.ProlongerAutorisationPREMQEntre Mapper(ParametreTravail.ProlongerAutorisationPREMQEntre intrant);

        /// <summary>
        /// Permet de mapper les paramètre de ProlongerAutorisationPREMQSorti.
        /// </summary>
        /// <param name="intrant">Paramètre du service</param>
        /// <returns>Paramètre de travail</returns>
        ParametreTravail.ProlongerAutorisationPREMQSorti Mapper(ParametreService.ProlongerAutorisationPREMQSorti intrant);

        /// <summary>
        /// Permet de mapper les paramètre de ObtenirLesAutorisationsProfessionnelSorti.
        /// </summary>
        /// <param name="intrant">Paramètre du service</param>
        /// <returns>Paramètre de travail</returns>
        ParametreTravail.ObtenirLesAutorisationsProfessionnelSorti Mapper(ParametreService.ObtenirLesAutorisationsProfessionnelSorti intrant);

        /// <summary>
        /// Permet de mapper les paramètre de CreerAutorisationPREMQSorti.
        /// </summary>
        /// <param name="intrant">Paramètre du service</param>
        /// <returns>Paramètre de travail</returns>
        ParametreTravail.CreerAutorisationPREMQSorti Mapper(ParametreService.CreerAutorisationPREMQSorti intrant);

        /// <summary>
        /// Permet de mapper les paramètre de AnnulerAutorisationPREMQSorti.
        /// </summary>
        /// <param name="intrant">Paramètre du service</param>
        /// <returns>Paramètre de travail</returns>
        ParametreTravail.AnnulerAutorisationPREMQSorti Mapper(ParametreService.AnnulerAutorisationPREMQSorti intrant);

        /// <summary>
        /// Permet de mapper les paramètre de AnnulerAutorisationPREMQEntre.
        /// </summary>
        /// <param name="intrant">Paramètre de travail</param>
        /// <returns>Paramètre de service</returns>
        ParametreService.AnnulerAutorisationPREMQEntre Mapper(ParametreTravail.AnnulerAutorisationPREMQEntre intrant);
    }
}