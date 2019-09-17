using RAMQ.ClasseBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre
{
    /// <summary> 
    ///  Paramètres de sortie  pour l'obtention de la liste des statuts engagement pratique RSS 
    /// </summary>
    /// <remarks>
    ///  Auteur : Franck COULIBALY <br/>
    ///  Date   : Juillet 2018
    /// </remarks>
	public class ObtenirStatutsEngagementPratiqueRSSSorti: ParametreSorti
    {
        /// <summary>
        /// constructeur
        /// </summary>
        public ObtenirStatutsEngagementPratiqueRSSSorti()
        {
            ListeStatutEngagementPratiqueRSS = new List<StatutEngagementPratiqueRSS>();
        }
        /// <summary>
        /// Liste des statuts
        /// </summary>
        public IEnumerable<StatutEngagementPratiqueRSS> ListeStatutEngagementPratiqueRSS { get; set; }
    }
}