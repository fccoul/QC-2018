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
	public class ParamObtnrRappAbsncAvisConf : IParamObtnrRapp
    {
        /// <summary>
        /// Année utilisée pour la recherche
        /// </summary>
        public int Annee { get; set; }
        /// <summary>
        /// Trimestre utilisé pour la recherche
        /// </summary>
        public int Trimestre { get; set; }
        /// <summary>
        /// Région utilisée pour la recherche
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// Sous-territoire utilisé pour la recherche
        /// </summary>
        public string SousTerritoire { get; set; }
    }
}