using System;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    ///  Classe de paramètres d'entrée pour l'obtention de la vue des engagements des professionels de la santé.
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois<br/>
    ///  Date   : Juillet 2017
    /// </remarks>
	public class ObtenirVueListeEngagementsEntre
    {

        /// <summary>
        /// Liste des numéros de séquences de dispensateurs
        /// </summary>(:NumerosSequenceDispensateur 
        public List<long> NumerosSequenceDispensateur { get; set; } = new List<long>();

        /// <summary>
        /// Date de début de service recherchée
        /// </summary>
        public string CodesRSS { get; set; } 

        /// <summary>
        /// Date de fin de service recherchée
        /// </summary>
        public DateTime? DateDebutEngagementRechr { get; set; }

        /// <summary>
        /// Date de fin de service recherchée
        /// </summary>
        public DateTime? DateFinEngagementRechr { get; set; }
        
        /// <summary>
        /// Statut d'engagement
        /// </summary>
        public string StatutEngagement { get; set; }



    }
}