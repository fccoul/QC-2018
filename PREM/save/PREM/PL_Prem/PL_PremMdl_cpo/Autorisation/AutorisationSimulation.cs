using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ParamTravail = RAMQ.PRE.PL_PremMdl_cpo.Autorisation.Parametres;
using ParamService = RAMQ.PRE.PL_PremMdl_cpo.svcSaisAutorActivMdcal;

namespace RAMQ.PRE.PL_PremMdl_cpo.Autorisation
{
    /// <summary>
    ///  Référentiel bidon qui permet d'obtenir les informations des autorisations
    ///  codés en dur.
    /// </summary>
    public class AutorisationSimulation : IAutorisation
    {
        /// <summary>
        /// Permet de créer une autorisation.
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Les informations sur l'état de l'opération</returns>
        /// <remarks></remarks>
        public ParamTravail.CreerAutorisationPREMQSorti CreerAutorisationPREMQ(ParamTravail.CreerAutorisationPREMQEntre intrant)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permet d'annuler une autorisation.
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Les informations sur l'état de l'opération</returns>
        /// <remarks></remarks>
        public ParamTravail.AnnulerAutorisationPREMQSorti AnnulerAutorisationPREMQ(ParamTravail.AnnulerAutorisationPREMQEntre intrant)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permet de prolonger une autorisation.
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Les informations sur l'état de l'opération</returns>
        /// <remarks></remarks>
        public ParamTravail.ProlongerAutorisationPREMQSorti ProlongerAutorisationPREMQ(ParamTravail.ProlongerAutorisationPREMQEntre intrant)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permet d'obtenir une liste d'autorisation.
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Les informations sur l'état de l'opération</returns>
        /// <remarks></remarks>
        public ParamTravail.ObtenirLesAutorisationsProfessionnelSorti ObtenirListeAutorisationPREMQ(ParamTravail.ObtenirLesAutorisationsProfessionnelEntre intrant)
        {
            throw new NotImplementedException();
        }
    }
}
