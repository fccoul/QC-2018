using RAMQ.Attribut;
using RAMQ.ClasseBase;
using System;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    /// Paramètre de sorti du service PLB1 ObtenirInfosExecutionMass
    /// </summary>
    public class ObtenirInfosExecutionMassiveSorti : ParamSorti
    {
        /// <summary>
        /// Date de début de la période
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDateDebutPeriode", Direction = ParameterDirection.Output)]
        public DateTime DateDebutPeriode { get; set; }

        /// <summary>
        /// Date de fin de la période
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDateFinPeriode", Direction = ParameterDirection.Output)]
        public DateTime DateFinPeriode { get; set; }
    }
}