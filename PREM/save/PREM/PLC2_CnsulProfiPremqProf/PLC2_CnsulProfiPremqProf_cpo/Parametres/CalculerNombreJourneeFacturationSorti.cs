using RAMQ.ClasseBase;
using RAMQ.PRE.PRE_Entites_cpo.Pratique.Entite;
using System.Collections.Generic;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Parametres
{
    /// <summary>
    /// Paramètre d'entré pour faire le calcule du nombre de journée de facturation
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
	public class CalculerNombreJourneeFacturationSorti : ParamSorti
    {

        /// <summary>
        /// Liste de journées facturées des professionnels de la santé pour un avis
        /// </summary>
        public List<JoursFactAvis> JourneesFacturerAvis { get; set; }

        /// <summary>
        /// Liste de journées facturées des professionnels pour les droits acquis
        /// </summary>
        public List<JoursFactDroitsAcquis> JourneesFacturerDroitsAcquis { get; set; }

        /// <summary>
        /// Liste de journées facturées des professionnels de la santé par RSS
        /// </summary>
        public List<JoursFactRSS> JourneesFacturerRSS { get; set; }

        /// <summary>
        /// Liste de journées facturées des professionnels de la santé par territoire
        /// </summary>
        public List<JoursFactTerritoire> JourneesFacturerTerritoire { get; set; }

        /// <summary>
        /// Liste de pourcentages des professionnels de la santé
        /// </summary>
        public List<PourcentageProf> PourcentagesProfessionnnels { get; set; }

        /// <summary>
        /// Liste de sommaires des professionnels de la santé
        /// </summary>
        public List<SommaireProf> SommairesProfessionnels { get; set; }
    }
}