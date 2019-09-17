using RAMQ.Attribut;
using System;
using System.Collections.Generic;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary> 
    ///  Classe de paramètres d'entrées pour le service du noyau « Obtenir les exemptions d’une réduction ».
    /// </summary>
    /// <remarks>
    /// Auteur : Florent Pollart
    /// </remarks>
	public class ObtenirListeExemptionsEntre
    {
        /// <summary>
        /// Liste numéros séquentiel de réduction
        /// </summary>
        [ValeurEntite(ElementName = "pTblReductions", Direction = ParameterDirection.Input)]
        public List<string> NumerosSeqReduction { get; set; }
    }
}