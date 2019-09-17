using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PRE_Entites_cpo.Professionnel.Entite
{
    /// <summary>
    /// Numero et classe d'un dispensateur
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class NumeroEtClasseDisp
    {
        /// <summary>
        /// Classe du Dispensateur
        /// </summary>
        public short? ClasseDispensateur { get; set; }

        /// <summary>
        /// Numéro du Dispensateur
        /// </summary>
        public int? NumeroDispensateur { get; set; }
    }
}