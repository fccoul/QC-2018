using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PRE_Entites_cpo.Professionnel.Entite
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class EngagementPeriode
    {
        /// <summary>
        /// Type de l'engagement
        /// </summary>
        /// <remarks></remarks>           
        public string Type { get; set; }

        /// <summary>
        /// Numéro de séquence du dispensateur
        /// </summary>
        /// <remarks></remarks>            
        public long NumeroSequenceDisp { get; set; }

        /// <summary>
        /// Date de fin de l'engagement
        /// </summary>
        /// <remarks></remarks>           
        public DateTime? DateDebutEngagement { get; set; }

        /// <summary>
        /// Date de début de l'engagement
        /// </summary>
        /// <remarks></remarks>            
        public DateTime? DateFinEngagement { get; set; }

    }
}