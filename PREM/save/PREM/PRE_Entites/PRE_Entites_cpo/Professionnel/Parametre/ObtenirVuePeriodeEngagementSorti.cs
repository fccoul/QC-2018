using RAMQ.ClasseBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Entite;

namespace RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class ObtenirVuePeriodeEngagementSorti : ParametreSorti
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirVuePeriodeEngagementSorti()
        {
            EngagementsPeriode = new List<EngagementPeriode>();
        }

        /// <summary>
        /// Liste de jours facturés par avis
        /// </summary>
        public List<EngagementPeriode> EngagementsPeriode { get; set; }
    }
}