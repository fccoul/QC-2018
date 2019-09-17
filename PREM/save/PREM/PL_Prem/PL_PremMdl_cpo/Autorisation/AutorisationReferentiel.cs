using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAMQ.PRE.PRE_OutilComun_cpo;

using ParamTravail = RAMQ.PRE.PL_PremMdl_cpo.Autorisation.Parametres;
using ParamService = RAMQ.PRE.PL_PremMdl_cpo.svcSaisAutorActivMdcal;
using RAMQ.PRE.PL_PremMdl_cpo.Autorisation.Mappeur;

namespace RAMQ.PRE.PL_PremMdl_cpo.Autorisation
{
    /// <summary>
    /// Référentiel qui permet d'obtenir les informations des autorisations.
    /// </summary>
    public class AutorisationReferentiel : IAutorisation
    {
        private readonly IAutorisationMappeur _mappeur;

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        public AutorisationReferentiel(IAutorisationMappeur autorisationMappeur)
        {
            _mappeur = autorisationMappeur;
        }

        /// <summary>
        /// Permet de créer une autorisation.
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Les informations sur l'état de l'opération</returns>
        /// <remarks></remarks>
        public ParamTravail.CreerAutorisationPREMQSorti CreerAutorisationPREMQ(ParamTravail.CreerAutorisationPREMQEntre intrant)
        {
            ParamService.CreerAutorisationPREMQEntre intrantService = _mappeur.Mapper(intrant);

            ParamService.CreerAutorisationPREMQSorti extrantService = UtilitaireService.AppelerService <svcSaisAutorActivMdcal.IServSaisAutorActivMdcal,
                                                    svcSaisAutorActivMdcal.ServSaisAutorActivMdcalClient,
                                                    ParamService.CreerAutorisationPREMQSorti>
                                                    (x => x.CreerAutorisationPREMQ(intrantService));

            return _mappeur.Mapper(extrantService);
        }

        /// <summary>
        /// Permet d'annuler une autorisation.
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Les informations sur l'état de l'opération</returns>
        /// <remarks></remarks>
        public ParamTravail.AnnulerAutorisationPREMQSorti AnnulerAutorisationPREMQ(ParamTravail.AnnulerAutorisationPREMQEntre intrant)
        {
            ParamService.AnnulerAutorisationPREMQEntre intrantService = _mappeur.Mapper(intrant);

            ParamService.AnnulerAutorisationPREMQSorti extrantService = UtilitaireService.AppelerService<svcSaisAutorActivMdcal.IServSaisAutorActivMdcal,
                                                    svcSaisAutorActivMdcal.ServSaisAutorActivMdcalClient,
                                                    ParamService.AnnulerAutorisationPREMQSorti>
                                                    (x => x.AnnulerAutorisationPREMQ(intrantService));

            return _mappeur.Mapper(extrantService);
        }

        /// <summary>
        /// Permet de prolonger une autorisation.
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Les informations sur l'état de l'opération</returns>
        /// <remarks></remarks>
        public ParamTravail.ProlongerAutorisationPREMQSorti ProlongerAutorisationPREMQ(ParamTravail.ProlongerAutorisationPREMQEntre intrant)
        {
            ParamService.ProlongerAutorisationPREMQEntre intrantService = _mappeur.Mapper(intrant);

            ParamService.ProlongerAutorisationPREMQSorti extrantService = UtilitaireService.AppelerService<svcSaisAutorActivMdcal.IServSaisAutorActivMdcal,
                                                    svcSaisAutorActivMdcal.ServSaisAutorActivMdcalClient,
                                                    ParamService.ProlongerAutorisationPREMQSorti>
                                                    (x => x.ProlongerAutorisationPREMQ(intrantService));

            return _mappeur.Mapper(extrantService);
        }

        /// <summary>
        /// Permet d'obtenir une liste d'autorisation.
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Les informations sur l'état de l'opération</returns>
        /// <remarks></remarks>
        public ParamTravail.ObtenirLesAutorisationsProfessionnelSorti ObtenirListeAutorisationPREMQ(ParamTravail.ObtenirLesAutorisationsProfessionnelEntre intrant)
        {
            ParamService.ObtenirLesAutorisationsProfessionnelEntre intrantService = _mappeur.Mapper(intrant);

            ParamService.ObtenirLesAutorisationsProfessionnelSorti extrantService = UtilitaireService.AppelerService<svcSaisAutorActivMdcal.IServSaisAutorActivMdcal,
                                                    svcSaisAutorActivMdcal.ServSaisAutorActivMdcalClient,
                                                    ParamService.ObtenirLesAutorisationsProfessionnelSorti>
                                                    (x => x.ObtenirListeAutorisation(intrantService));

            return _mappeur.Mapper(extrantService);
        }
    }
}
