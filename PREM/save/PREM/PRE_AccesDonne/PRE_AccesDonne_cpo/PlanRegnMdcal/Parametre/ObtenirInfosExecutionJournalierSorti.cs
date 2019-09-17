using RAMQ.Attribut;
using RAMQ.ClasseBase;
using System;
using System.Collections.Generic;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    /// Paramètre de sorti du service PLB1 ObtenirInfosExecutionJourn
    /// </summary>
    public class ObtenirInfosExecutionJournalierSorti : ParamSorti
    {
        /// <summary>
        /// Liste des numéros de séquence de professionnel.
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblNoSeqProf", Direction = ParameterDirection.Output, TypeSorti = RAMQ.Enumeration.EnumTypeParamSorti.Tableau)]
        public List<long> NumerosSequenceProfessionnel { get; set; }

        /// <summary>
        /// Liste des classes de dispensateur.
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblClaDisp", Direction = ParameterDirection.Output, TypeSorti = RAMQ.Enumeration.EnumTypeParamSorti.Tableau)]
        public List<int> ClassesDispensateur { get; set; }

        /// <summary>
        /// Liste des numéros de dispensateur.
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblNoDisp", Direction = ParameterDirection.Output, TypeSorti = RAMQ.Enumeration.EnumTypeParamSorti.Tableau)]
        public List<int> NumerosDispensateur { get; set; }

        /// <summary>
        /// Liste des numéros de séquence de demande de réévaluation.
        /// </summary>
        [ValeurEntite(ElementName = "pTblNoSeqDemReeva", Direction = ParameterDirection.Output, TypeSorti = RAMQ.Enumeration.EnumTypeParamSorti.Tableau)]
        public List<int> NumerosSequenceDemandeReevaluation { get; set; }

        /// <summary>
        /// Liste des dates de début de période
        /// </summary>
        [ValeurEntite(ElementName = "pTblDDPeriode", Direction = ParameterDirection.Output, TypeSorti = RAMQ.Enumeration.EnumTypeParamSorti.Tableau)]
        public List<DateTime> DatesDebutPeriode { get; set; }

        /// <summary>
        /// Liste des dates de fin de période
        /// </summary>
        [ValeurEntite(ElementName = "pTblDFPeriode", Direction = ParameterDirection.Output, TypeSorti = RAMQ.Enumeration.EnumTypeParamSorti.Tableau)]
        public List<DateTime> DatesFinPeriode { get; set; }
    }
}