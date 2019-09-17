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
	public class ObtenirVueListPrctJrfacDerogSorti : ParamSorti
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirVueListPrctJrfacDerogSorti()
        {
            LignesRapport = new List<PrctJrfacDerog>();
        }

        /// <summary>
        /// Liste de jours facturés par avis
        /// </summary>
        public IEnumerable<PrctJrfacDerog> LignesRapport { get; set; }
    }
}