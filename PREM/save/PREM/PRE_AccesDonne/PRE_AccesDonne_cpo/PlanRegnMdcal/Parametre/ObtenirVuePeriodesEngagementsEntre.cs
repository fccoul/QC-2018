using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    ///  Classe de paramètres d'entrée pour l'obtention de la vue des périodes d'engagement des professionels de la santé.
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois<br/>
    ///  Date   : Juillet 2017
    /// </remarks>
	public class ObtenirVuePeriodesEngagementsEntre
    {

        /// <summary>
        /// Liste des numéros de séquences de dispensateurs
        /// </summary>
        public List<long> NumerosSequenceDispensateur { get; set; } = new List<long>();

        /// <summary>
        /// Type d'engagement
        /// </summary>
        public string Type { get; set; } 

    }
}