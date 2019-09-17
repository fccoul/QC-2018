using System.Collections.Generic;
using RAMQ.ClasseBase;
using RAMQ.PRE.PRE_Entites_cpo.Pratique.Entite;

namespace RAMQ.PRE.PRE_Entites_cpo.Pratique.Parametre
{
    /// <summary> 
    ///  Paramètres de sortie pour le service du noyau « Obtenir les jours facturés de la pratique PREM par région ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart<br/>
    ///  Date   : Février 2017
    /// </remarks>
	public class ObtenirJoursFactPratiRegionSorti : ParamSorti
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirJoursFactPratiRegionSorti()
        {
            ListeJourFactProfsRSS = new List<PratiqueRegion>();
        }

        /// <summary>
        /// Liste de journées facturées des professionnels de la santé par RSS
        /// </summary>
        /// <remarks></remarks>
        public List<PratiqueRegion> ListeJourFactProfsRSS { get; set; }
    }
}