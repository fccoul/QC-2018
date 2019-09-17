using RAMQ.ClasseBase;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    ///  Classe de paramètres de sortie pour l'obtention de la vue des pourcentages de jours facturés en dérogation
    /// </summary>
    /// <remarks>
    ///  Auteur : Mathys Leleu<br/>
    ///  Date   : Octobre 2017
    /// </remarks>
	public class ObtenirVueListPrctJrfacTerriSorti : ParamSorti
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirVueListPrctJrfacTerriSorti()
        {
            LignesRapport = new List<PrctJrfacTerri>();
        }

        /// <summary>
        /// Liste de jours facturés par avis
        /// </summary>
        public IEnumerable<PrctJrfacTerri> LignesRapport { get; set; }
    }
}