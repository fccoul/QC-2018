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
	public class ParamObtnrRappAvisConfTermines : IParamObtnrRapp
    {
        /// <summary>
        /// Année de recherche
        /// </summary>
        public int Annee { get; set; }
        /// <summary>
        /// Raison rechercée
        /// </summary>
        public string Raison { get; set; }
        /// <summary>
        /// Région originale recherchée, uniquement pour le comité paritaire
        /// </summary>
        public string RegionOriginale { get; set; }
        /// <summary>
        /// Région de destination recherchée, uniquement pour le comité paritaire
        /// </summary>
        public string RegionDestination { get; set; }
    }
}