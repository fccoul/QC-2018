using RAMQ.ClasseBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.AjusterEngagement.Param
{
    /// <summary>
    /// Parametre de sortie de la methode TraiterDerogationDateNonParticipation
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class TraiterEngagementSorti : ParametreSorti
    {
        /// <summary>
        /// constructeur
        /// </summary>
        public TraiterEngagementSorti()
        {
            EstTraite = false;
        }
        /// <summary>
        /// permet de verifier si le traitement a eu lieu ou pas
        /// </summary>
        public bool EstTraite { get; set; }
    }
}