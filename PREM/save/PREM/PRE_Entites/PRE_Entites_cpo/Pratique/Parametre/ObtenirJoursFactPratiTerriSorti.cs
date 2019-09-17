using RAMQ.ClasseBase;
using RAMQ.PRE.PRE_Entites_cpo.Pratique.Entite;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_Entites_cpo.Pratique.Parametre
{
    /// <summary> 
    ///  Paramètres de sortie pour le service du noyau « Obtenir les jours facturés de la pratique PREM par territoire ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart<br/>
    ///  Date   : Février 2017
    /// </remarks>
	public class ObtenirJoursFactPratiTerriSorti : ParamSorti
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirJoursFactPratiTerriSorti()
        {
            ListeJourFactProfsTerri = new List<PratiqueTerritoire>();
        }

        /// <summary>
        /// Liste de journées facturées des professionnels de la santé par territoire
        /// </summary>
        /// <remarks></remarks>
        public List<PratiqueTerritoire> ListeJourFactProfsTerri { get; set; }
    }
}