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
	public class ParamObtnrRappAvisConfActifsParTerritoire : IParamObtnrRapp
    {
        /// <summary>
        /// Région utilisée pour la recherche
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// Sous-territoire utilisé pour la recherche
        /// </summary>
        public string SousTerritoire { get; set; }
        /// <summary>
        /// Statut recherché
        /// </summary>
        public string StatutAvis { get; set; }
        /// <summary>
        /// Date utilisée pour la recherche
        /// </summary>
        public DateTime? DateRecherche { get; set; }
        /// <summary>
        /// Exclut ou non les médecins retraités
        /// </summary>
        public bool IndicateurRetraiteExclus { get; set; }
        /// <summary>
        /// Exclut ou non les médecins désengagés
        /// </summary>
        public bool IndicateurDesengagesExclus { get; set; }
        /// <summary>
        /// Exclut ou non le médecins hors RAMQ
        /// </summary>
        public bool IndicateurHorsRAMQExclus { get; set; }
    }
}