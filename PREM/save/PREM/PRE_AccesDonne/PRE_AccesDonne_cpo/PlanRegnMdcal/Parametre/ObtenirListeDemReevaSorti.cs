using RAMQ.Attribut;
using RAMQ.ClasseBase;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite;
using System.Collections.Generic;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    ///  Classe de paramètres de sortie pour l'obtention des demandes de réévaluation
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois<br/>
    ///  Date   : Mars 2018
    /// </remarks>
	public class ObtenirListeDemReevaSorti : ParamSorti
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirListeDemReevaSorti()
        {
            DemandesReeva = new List<DemandeReeva>();
        }

        /// <summary>
        /// Liste de demandes de réévaluation
        /// </summary>
        [ValeurEntite(ElementName = "pCurListeDemReeva", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.RefCursor)]
        public IEnumerable<DemandeReeva> DemandesReeva { get; set; }
    }
}