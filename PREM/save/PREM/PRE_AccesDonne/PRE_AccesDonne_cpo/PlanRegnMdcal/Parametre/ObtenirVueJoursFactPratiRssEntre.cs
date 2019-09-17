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
	public class ObtenirVueJoursFactPratiRssEntre
    {
        /// <summary>
        /// Numero de sequence dispensateur
        /// </summary>
        public List<long> NumeroSeqDispensateur { get; set; } = new List<long>();

        /// <summary>
        /// Date de debut de recherche
        /// </summary>
        public DateTime? DateServiceDateDebutPerRechr { get; set; }

        /// <summary>
        /// Date de fin de recherche
        /// </summary>
        public DateTime? DateServiceDateFinPerRechr { get; set; }

        /// <summary>
        /// Codes RSS
        /// </summary>
        public string CodeRSS { get; set; } 

        /// <summary>
        /// Jours
        /// </summary>
        public double Jours { get; set; } = 0;

        /// <summary>
        /// Type de Service de Repartition de Pratique
        /// </summary>
        public string TypeServiceRepartitionPratique { get; set; }

        /// <summary>
        /// Nombre d'éléments par page
        /// </summary>
        public long NombreElementsParPage { get; set; } = 0;

        /// <summary>
        /// Numéro de page
        /// </summary>
        public long NumeroPage { get; set; } = 0;
    }
}