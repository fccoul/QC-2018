using RAMQ.ClasseBase;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class ObtenirVueJoursFactPratiAvisSorti : ParamSorti
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirVueJoursFactPratiAvisSorti()
        {
            ListeJoursFactParAvis = new List<JoursFactParAvis>();
        }

        /// <summary>
        /// Liste de jours facturés par avis
        /// </summary>
        public IEnumerable<JoursFactParAvis> ListeJoursFactParAvis { get; set; }
    }
}