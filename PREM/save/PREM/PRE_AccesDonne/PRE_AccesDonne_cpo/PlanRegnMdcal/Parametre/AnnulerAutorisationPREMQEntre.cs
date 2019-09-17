using RAMQ.Attribut;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    /// Paramètre d'entré du service du noyau AnnulerAutorPREMQ
    /// </summary>
    public class AnnulerAutorisationPREMQEntre
    {
        /// <summary>
        /// Numéro séquentiel de l'autorisation à annuler.
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqAutorPREMQ", Direction = ParameterDirection.Input)]
        public long NumeroSequentielAutorisation { get; set; }

        /// <summary>
        /// Identifiant utilisateur annulant l'autorisation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrIdUtilAnnu", Direction = ParameterDirection.Input)]
        public string IdentifiantUtilisateur { get; set; }
    }
}
