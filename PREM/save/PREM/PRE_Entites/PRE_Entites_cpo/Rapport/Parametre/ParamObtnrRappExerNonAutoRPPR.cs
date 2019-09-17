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
	public class ParamObtnrRappExerNonAutoRPPR : IParamObtnrRapp
    {
        /// <summary>
        /// Année de recherche
        /// </summary>
        public int Annee { get; set; }
        /// <summary>
        /// Région où rechercher
        /// </summary>
        public string Region { get; set; }
    }
}