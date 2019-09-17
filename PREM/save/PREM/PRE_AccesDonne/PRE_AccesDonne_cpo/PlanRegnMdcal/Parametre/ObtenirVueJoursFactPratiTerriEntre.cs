using System;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class ObtenirVueJoursFactPratiTerriEntre
    {

        /// <summary>
        /// Numéros de séquence de dispensateurs
        /// </summary>
        public List<long> NumeroSeqDispensateur { get; set; } = new List<long>();

        /// <summary>
        /// Date de debut de recherche pour la date de service
        /// </summary>
        public DateTime? DateServiceDateDebutPerRechr { get; set; }

        /// <summary>
        /// Date de fin de recherche pour la date de service
        /// </summary>
        public DateTime? DateServiceDateFinPerRechr { get; set; }

        /// <summary>
        /// Codes RSS
        /// </summary>
        public string CodeRSS { get; set; }

        /// <summary>
        /// Types de lieux géographiques
        /// </summary>
        public string TypeLieuGeo { get; set; } 

        /// <summary>
        /// Codes de lieux géographiques
        /// </summary>
        public string CodeLieuGeo { get; set; } 

        /// <summary>
        /// Numéros de séquences de regroupement administratif de lieux géographiques
        /// </summary>
        public long NumeroSeqRegrAdminLieuGeo { get; set; } 
        /// <summary>
        /// Jours
        /// </summary>
        public double Jours { get; set; } = 0;

        /// <summary>
        /// Types de service de répartition de pratique
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