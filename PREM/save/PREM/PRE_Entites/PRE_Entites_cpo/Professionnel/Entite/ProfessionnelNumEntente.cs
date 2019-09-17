using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PRE_Entites_cpo.Professionnel.Entite
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class ProfessionnelNumEntente
    {
        /// <summary>
        /// Classe du dispensateur
        /// </summary>
        public int ClasseDispensateur { get; set; }

        /// <summary>
        /// Numéro du dispensateur
        /// </summary>
        public int NumeroDispensateur { get; set; }

        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        public int NumeroSeqDispensateur { get; set; }

        /// <summary>
        /// Numéro séquentiel individu
        /// </summary>
        public int NumeroSeqIndividu { get; set; }

        /// <summary>
        /// Date début spécialisation
        /// </summary>
        public DateTime DateDebutSpecialisation { get; set; }

        /// <summary>
        /// Date début période admissibilité
        /// </summary>
        public DateTime? DateDebutPeriodeAdmissibilite { get; set; }

        /// <summary>
        /// Date de fin période admissibilité
        /// </summary>
        public DateTime? DateFinPeriodeAdmissibilite { get; set; }

        /// <summary>
        /// Statut admissibilité
        /// </summary>
        public string StatutAdmissibilite { get; set; }

        /// <summary>
        /// Code de raison de la non admissibilité
        /// </summary>
        public string CodeRaisonNonAdmissibilite { get; set; }
    }
}