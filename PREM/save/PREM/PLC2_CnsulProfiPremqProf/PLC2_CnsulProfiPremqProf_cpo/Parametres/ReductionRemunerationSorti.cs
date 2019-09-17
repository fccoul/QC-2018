using RAMQ.ClasseBase;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Entites;
using System.Collections.Generic;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Parametres
{
    /// <summary>
    /// Classe de paramètre de sortie pour la réduction à la rémunération
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
	public class ReductionRemunerationSorti : ParamSorti
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public ReductionRemunerationSorti()
        {
            ReductionRemunerations = new List<ReductionRemuneration>();
        }



        /// <summary>
        /// Liste de réduction à la rémunération
        /// </summary>
        public List<ReductionRemuneration> ReductionRemunerations { get; set; }
    }
}
