using RAMQ.ClasseBase;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    ///  Classe de paramètres de sortie pour l'obtention de la vue des engagements des professionels de la santé.
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois<br/>
    ///  Date   : Juillet 2017
    /// </remarks>
	public class ObtenirVueListeEngagementsSorti : ParamSorti
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirVueListeEngagementsSorti()
        {
            Engagements = new List<Engagement>();
        }

        /// <summary>
        /// Liste de jours facturés par avis
        /// </summary>
        public IEnumerable<Engagement> Engagements { get; set; }
    }
}