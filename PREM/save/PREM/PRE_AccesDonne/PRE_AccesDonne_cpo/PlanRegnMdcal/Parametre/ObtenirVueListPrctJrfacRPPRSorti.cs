using RAMQ.ClasseBase;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    ///  Classe de paramètres de sortie pour l'obtention de la vue des pourcentages de jours facturés en RPPR
    /// </summary>
    /// <remarks>
    ///  Auteur : Mathys Leleu<br/>
    ///  Date   : Octobre 2017
    /// </remarks>
	public class ObtenirVueListPrctJrfacRPPRSorti : ParamSorti
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirVueListPrctJrfacRPPRSorti()
        {
            LignesRapport = new List<PrctJrfacRPPR>();
        }

        /// <summary>
        /// Liste 
        /// </summary>
        public IEnumerable<PrctJrfacRPPR> LignesRapport { get; set; }
    }
}