using RAMQ.ClasseBase;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_Entites_cpo.Pratique.Parametre
{
    /// <summary> 
    ///  Paramètres de sortie pour CalculerNbrJrsPratiProfs
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois<br/>
    ///  Date   : Juillet 2018
    /// </remarks>
	public class CalculerNbrJrFactProfsSorti : ParamSorti
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public CalculerNbrJrFactProfsSorti()
        {
            Messages = new List<Entite.Message>();
            JourneesFactRSS = new List<Entite.JoursFactRSS>();
            JourneesFactTerritoire = new List<Entite.JoursFactTerritoire>();
            JourneesFactAvis = new List<Entite.JoursFactAvis>();
            JourneesRPPR = new Entite.CalculRPPR();
            SommairesProfs = new List<Entite.SommaireProf>();
            RespectsEngagementProfs = new List<Entite.RespectEngagementProfs>();
        }
        /// <summary>
        /// Liste de messages
        /// </summary>
        /// <remarks></remarks>
        public List<Entite.Message> Messages { get; set; }

        /// <summary>
        /// Liste de journées facturées des professionnels de la santé par RSS
        /// </summary>
        /// <remarks></remarks>
        public List<Entite.JoursFactRSS> JourneesFactRSS { get; set; }

        /// <summary>
        /// Liste de journées facturées des professionnels de la santé par territoire
        /// </summary>
        /// <remarks></remarks>
        public List<Entite.JoursFactTerritoire> JourneesFactTerritoire { get; set; }

        /// <summary>
        /// Liste de journées facturées des professionnels de la santé pour un avis
        /// </summary>
        /// <remarks></remarks>
        public List<Entite.JoursFactAvis> JourneesFactAvis { get; set; }

        /// <summary>
        /// Calcul des RPPR
        /// </summary>
        /// <remarks></remarks>
        public Entite.CalculRPPR JourneesRPPR { get; set; }

        /// <summary>
        /// Liste de sommaires des professionnels de la santé
        /// </summary>
        /// <remarks></remarks>
        public List<Entite.SommaireProf> SommairesProfs { get; set; }

        /// <summary>
        /// Liste de respects d'engagement des professionnels de la santé
        /// </summary>
        /// <remarks></remarks>
        public List<Entite.RespectEngagementProfs> RespectsEngagementProfs { get; set; }
    }
}