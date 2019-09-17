using RAMQ.ClasseBase;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class ObtenirVuePeriodesAdmissibiliteSorti : ParametreSorti
    {
        /// <summary>
        /// constructeur
        /// </summary>
        public ObtenirVuePeriodesAdmissibiliteSorti()
        {
            AdmissibilitePeriodes = new List<AdmissibilitePeriode>();
        }

        /// <summary>
        /// Liste des periodes d'admissibilité
        /// </summary>
        public List<AdmissibilitePeriode> AdmissibilitePeriodes { get; set; }
    }
}