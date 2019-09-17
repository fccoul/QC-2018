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
    /// Paramètre d'entré du service du noyau CreerAutorPREMQ
    /// </summary>
    public class CreerAutorisationPREMQEntre
    {
        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNumeroSeqDisp", Direction = ParameterDirection.Input)]
        public long NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Type d'autorisation PREMQ
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrTypAutor", Direction = ParameterDirection.Input)]
        public string TypeAutorisationPREMQ { get; set; }

        /// <summary>
        /// Date de début d'autorisation PREMQ
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDDAutorPREMQ", Direction = ParameterDirection.Input)]
        public DateTime DateDebutAutorisation { get; set; }

        /// <summary>
        /// Date de fin d'autorisation PREMQ
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDFAutorPREMQ", Direction = ParameterDirection.Input)]
        public DateTime DateFinAutorisation { get; set; }

        /// <summary>
        /// Identifiant utilisateur créateur
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrIdUtil", Direction = ParameterDirection.Input)]
        public string IdentifiantUtilisateur { get; set; }

    }
}
