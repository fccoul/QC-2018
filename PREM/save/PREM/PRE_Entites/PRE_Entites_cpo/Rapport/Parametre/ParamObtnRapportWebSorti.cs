using RAMQ.ClasseBase;
using RAMQ.PRE.PRE_Entites_cpo.Rapport.Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PRE_Entites_cpo.Rapport.Parametre
{
    /// <summary>
    /// Paramètre de sortie, utilisé pour renvoyer un rapport en tant que fichier (PDF, XML).
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class ParamObtnRapportWebSorti<T> : ParamSorti where T : ILigneRapport
    {
        /// <summary>
        /// Lignes du rapport généré
        /// </summary>
        public IList<T> LignesRapport;

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateDebutPeriode;

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateFinPeriode;
    }
}