using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class ObtenirVuePeriodeEngagementEntre
    {
        /// <summary>
        /// Liste des numéros de séquences de dispensateurs
        /// </summary>
        public List<long> NumerosSequenceDispensateur { get; set; } = new List<long>();

        /// <summary>
        /// Type d'engagement
        /// </summary>
        public string Type { get; set; }
    }
}