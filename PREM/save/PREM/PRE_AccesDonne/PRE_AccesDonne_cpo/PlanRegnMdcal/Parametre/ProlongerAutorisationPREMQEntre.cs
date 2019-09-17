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
    /// Paramètre d'entré du service du noyau ProlongerAutorPREMQ
    /// </summary>
    public class ProlongerAutorisationPREMQEntre
    {
        /// <summary>
        /// Numéro séquentiel de l'autorisation à annuler.
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqAutorPREMQ", Direction = ParameterDirection.Input)]
        public long NumeroSequentielAutorisation { get; set; }

        /// <summary>
        /// Date de fin d'autorisation PREMQ
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDFAutorPREMQ", Direction = ParameterDirection.Input)]
        public DateTime DateFinAutorisation { get; set; }

        /// <summary>
        /// Identifiant utilisateur prolongeant l'autorisation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrIdUtil", Direction = ParameterDirection.Input)]
        public string IdentifiantUtilisateur { get; set; }
    }
}
