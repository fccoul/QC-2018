using RAMQ.Attribut;
using RAMQ.ClasseBase;
using System.Collections.Generic;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    /// Paramètre de sortie pour l'obtention des réductions à la rémunération
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
	public class ObtenirReductionsRemunerationSorti : ParamSorti
    {

        /// <summary>
        /// Constructeur
        /// </summary>
        public ObtenirReductionsRemunerationSorti()
        {
            ReductionsRemuneration = new List<Entite.ReductionRemuneration>();
        }

        /// <summary>
        /// Liste des avis de conformité
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pCurListeReducProf", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.RefCursor)]
        public List<Entite.ReductionRemuneration> ReductionsRemuneration { get; set; }
    }
}