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
	public class ObtenirVueJoursFactPratiAvisEntre
    {
        /// <summary>
        /// Numéros de séquences de dispensateur
        /// </summary>
        public List<long> NumeroSeqDispensateur { get; set; } = new List<long>();

        /// <summary>
        /// Date de début de recherche pour la période
        /// </summary>
        public DateTime? DateServiceDebutPerRechr { get; set; }

        /// <summary>
        /// Date de fin de recherche pour la période
        /// </summary>
        public DateTime? DateServiceFinPerRechr { get; set; }

        /// <summary>
        /// Date de début de recherche pour le début de l'engagement
        /// </summary>
        public DateTime? DateDebutEngagDebutPerRechr { get; set; }

        /// <summary>
        /// Date de fin de recherche pour le début de l'engagement
        /// </summary>
        public DateTime? DateDebutEngagFinPerRechr { get; set; }

        /// <summary>
        /// Date de début de recherche pour la fin de l'engagement
        /// </summary>
        public DateTime? DateFinEngagDebutPerRechr { get; set; }

        /// <summary>
        /// Date de fin de recherche pour la fin de l'engagement
        /// </summary>
        public DateTime? DateFinEngagFinPerRechr { get; set; }

        /// <summary>
        /// Codes RSS
        /// </summary>
        public string CodeRSS { get; set; }

        /// <summary>
        /// Types de lieu géographique
        /// </summary>
        public string TypeLieuGeo { get; set; } 

        /// <summary>
        /// Codes de lieu géographique
        /// </summary>
        public string CodeLieuGeo { get; set; } 
        /// <summary>
        /// Numéros de séquences de regroupement administratif de lieu géographique
        /// </summary>
        public string NumeroSeqRegrAdminLieuGeo { get; set; }

        /// <summary>
        /// Status d'engagement 
        /// </summary>
        public string StatutEngagTerri { get; set; }

        /// <summary>
        /// Jours
        /// </summary>
        public double Jours { get; set; } = 0;

        /// <summary>
        /// Type de service de répartition de pratique
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