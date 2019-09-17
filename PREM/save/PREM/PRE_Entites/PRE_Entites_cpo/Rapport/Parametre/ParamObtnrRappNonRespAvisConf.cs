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
	public class ParamObtnrRappNonRespAvisConf : IParamObtnrRapp
    {
        /// <summary>
        /// Année de recherche
        /// </summary>
        public int Annee { get; set; }
        /// <summary>
        /// Région pour la recherche
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// Sous-territoire pour la recherche
        /// </summary>
        public string SousTerritoire { get; set; }
    }
}