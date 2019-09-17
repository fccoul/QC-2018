using ParametreTravail = RAMQ.PRE.PL_PremMdl_cpo.Autorisation.Parametres;
using ParametreService = RAMQ.PRE.PL_PremMdl_cpo.svcSaisAutorActivMdcal;

namespace RAMQ.PRE.PL_PremMdl_cpo.Autorisation.Mappeur
{
    /// <summary>
    /// Classe permettant de mapper les entités de travail de l'IUT avec ceux des services.
    /// </summary>
    public class AutorisationMappeur : IAutorisationMappeur
    {
        /// <summary>
        /// Permet de mapper les paramètre de CreerAutorisationPREMQSorti.
        /// </summary>
        /// <param name="intrant">Paramètre du service</param>
        /// <returns>Paramètre de travail</returns>
        public ParametreTravail.CreerAutorisationPREMQSorti Mapper(ParametreService.CreerAutorisationPREMQSorti intrant)
        {
            var config = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<ParametreService.CreerAutorisationPREMQSorti, ParametreTravail.CreerAutorisationPREMQSorti>());
            var mapper = config.CreateMapper();

            ParametreTravail.CreerAutorisationPREMQSorti extrant = mapper.Map<ParametreTravail.CreerAutorisationPREMQSorti>(intrant);

            return extrant;
        }

        /// <summary>
        /// Permet de mapper les paramètre de CreerAutorisationPREMQEntre.
        /// </summary>
        /// <param name="intrant">Paramètre de travail</param>
        /// <returns>Paramètre de service</returns>
        public ParametreService.CreerAutorisationPREMQEntre Mapper(ParametreTravail.CreerAutorisationPREMQEntre intrant)
        {
            var config = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<ParametreService.CreerAutorisationPREMQEntre, ParametreTravail.CreerAutorisationPREMQEntre>());
            var mapper = config.CreateMapper();

            ParametreService.CreerAutorisationPREMQEntre extrant = mapper.Map<ParametreService.CreerAutorisationPREMQEntre>(intrant);

            return extrant;
        }

        /// <summary>
        /// Permet de mapper les paramètre de AnnulerAutorisationPREMQSorti.
        /// </summary>
        /// <param name="intrant">Paramètre du service</param>
        /// <returns>Paramètre de travail</returns>
        public ParametreTravail.AnnulerAutorisationPREMQSorti Mapper(ParametreService.AnnulerAutorisationPREMQSorti intrant)
        {
            var config = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<ParametreService.AnnulerAutorisationPREMQSorti, ParametreTravail.AnnulerAutorisationPREMQSorti>());
            var mapper = config.CreateMapper();

            ParametreTravail.AnnulerAutorisationPREMQSorti extrant = mapper.Map<ParametreTravail.AnnulerAutorisationPREMQSorti>(intrant);

            return extrant;
        }

        /// <summary>
        /// Permet de mapper les paramètre de AnnulerAutorisationPREMQEntre.
        /// </summary>
        /// <param name="intrant">Paramètre de travail</param>
        /// <returns>Paramètre de service</returns>
        public ParametreService.AnnulerAutorisationPREMQEntre Mapper(ParametreTravail.AnnulerAutorisationPREMQEntre intrant)
        {
            var config = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<ParametreService.AnnulerAutorisationPREMQEntre, ParametreTravail.AnnulerAutorisationPREMQEntre>());
            var mapper = config.CreateMapper();

            ParametreService.AnnulerAutorisationPREMQEntre extrant = mapper.Map<ParametreService.AnnulerAutorisationPREMQEntre>(intrant);

            return extrant;
        }

        /// <summary>
        /// Permet de mapper les paramètre de ProlongerAutorisationPREMQSorti.
        /// </summary>
        /// <param name="intrant">Paramètre du service</param>
        /// <returns>Paramètre de travail</returns>
        public ParametreTravail.ProlongerAutorisationPREMQSorti Mapper(ParametreService.ProlongerAutorisationPREMQSorti intrant)
        {
            var config = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<ParametreService.ProlongerAutorisationPREMQSorti, ParametreTravail.ProlongerAutorisationPREMQSorti>());
            var mapper = config.CreateMapper();

            ParametreTravail.ProlongerAutorisationPREMQSorti extrant = mapper.Map<ParametreTravail.ProlongerAutorisationPREMQSorti>(intrant);

            return extrant;
        }

        /// <summary>
        /// Permet de mapper les paramètre de ProlongerAutorisationPREMQEntre.
        /// </summary>
        /// <param name="intrant">Paramètre de travail</param>
        /// <returns>Paramètre de service</returns>
        public ParametreService.ProlongerAutorisationPREMQEntre Mapper(ParametreTravail.ProlongerAutorisationPREMQEntre intrant)
        {
            var config = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<ParametreService.ProlongerAutorisationPREMQEntre, ParametreTravail.ProlongerAutorisationPREMQEntre>());
            var mapper = config.CreateMapper();

            ParametreService.ProlongerAutorisationPREMQEntre extrant = mapper.Map<ParametreService.ProlongerAutorisationPREMQEntre>(intrant);

            return extrant;
        }


        /// <summary>
        /// Permet de mapper les paramètre de ObtenirLesAutorisationsProfessionnelSorti.
        /// </summary>
        /// <param name="intrant">Paramètre du service</param>
        /// <returns>Paramètre de travail</returns>
        public ParametreTravail.ObtenirLesAutorisationsProfessionnelSorti Mapper(ParametreService.ObtenirLesAutorisationsProfessionnelSorti intrant)
        {
            var config = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<ParametreService.ObtenirLesAutorisationsProfessionnelSorti, ParametreTravail.ObtenirLesAutorisationsProfessionnelSorti>());
            var mapper = config.CreateMapper();

            ParametreTravail.ObtenirLesAutorisationsProfessionnelSorti extrant = mapper.Map<ParametreTravail.ObtenirLesAutorisationsProfessionnelSorti>(intrant);

            return extrant;
        }

        /// <summary>
        /// Permet de mapper les paramètre de ObtenirAutorisationPREMQEntre.
        /// </summary>
        /// <param name="intrant">Paramètre de travail</param>
        /// <returns>Paramètre de service</returns>
        public ParametreService.ObtenirLesAutorisationsProfessionnelEntre Mapper(ParametreTravail.ObtenirLesAutorisationsProfessionnelEntre intrant)
        {
            var config = new AutoMapper.MapperConfiguration(cfg => cfg.CreateMap<ParametreService.ObtenirLesAutorisationsProfessionnelEntre, ParametreTravail.ObtenirLesAutorisationsProfessionnelEntre>());
            var mapper = config.CreateMapper();

            ParametreService.ObtenirLesAutorisationsProfessionnelEntre extrant = mapper.Map<ParametreService.ObtenirLesAutorisationsProfessionnelEntre>(intrant);

            return extrant;
        }

    }
}
