using RAMQ.ClasseBase;
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
	public class ParamObtnRapportFichierSorti : ParamSorti
    {
        /// <summary>
        /// 
        /// </summary>
        public byte[] ContenuFichier { get; set; }

        /// <summary>
        /// Type "MIME", obtenu avec MimeMapping.GetMimeMapping(cheminFichier);
        /// </summary>
        public string TypeContenu { get; set; }

        /// <summary>
        /// Nom du fichier de sortie
        /// </summary>
        public string NomFichier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateDebutPeriode;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? DateFinPeriode;
    }
}