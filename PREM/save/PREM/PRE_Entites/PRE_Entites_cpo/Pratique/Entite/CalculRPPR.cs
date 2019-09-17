using System;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_Entites_cpo.Pratique.Entite
{
    /// <summary> 
    ///  CalculRPPR
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Juillet 2018
    /// </remarks>
	public class CalculRPPR
    {
        /// <summary>
        /// Constructeur pour la classe CalculRPPR
        /// </summary>
        public CalculRPPR() {
            JourneesDepassementRPPR = new List<JoursFactDroitsAcquisDepassement>();
            JourneesNonAutRPPR = new List<JoursFactDroitsAcquis>();
            HistoriqueEngagement = new List<EngagementProf>();
            EngagementPresent = new List<EngagementProf>();
        }

        /// <summary>
        /// Liste de pratique en dépassement pour les RPPR
        /// </summary>
        /// <remarks></remarks>
        public List<JoursFactDroitsAcquisDepassement> JourneesDepassementRPPR { get; set; }


        /// <summary>
        /// Liste de pratique non autorisée pour les RPPR
        /// </summary>
        /// <remarks></remarks>
        public List<JoursFactDroitsAcquis> JourneesNonAutRPPR { get; set; }


        /// <summary>
        /// Liste des engagements précédents en RPPR (droits acquis)
        /// </summary>
        /// <remarks></remarks>
        public List<EngagementProf> HistoriqueEngagement { get; set; }

        /// <summary>
        ///  Numéro de séquence de l'engagement actuel du professionel
        /// </summary>
        /// <remarks></remarks>
        public List<EngagementProf> EngagementPresent { get; set; }

        
    }
}