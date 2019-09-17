using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PRE_Entites_cpo.Rapport.Parametre
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class ParamObtnrRappDerogPratiExclu : IParamObtnrRapp
    {
        /// <summary>
        /// Annee Prem à rechercher
        /// </summary>
        public int Annee { get; set; }

        /// <summary>
        /// TypePratique recherché
        /// </summary>
        public string TypePratique { get; set; }
    }
}