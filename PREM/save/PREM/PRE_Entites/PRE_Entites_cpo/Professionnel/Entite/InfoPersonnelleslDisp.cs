using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PRE_Entites_cpo.Professionnel.Entite
{
    /// <summary>
    /// Information personnelle d'un dispensateur
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class InfoPersonnelleslDisp
    {
        /// <summary>
        /// Code de profession
        /// </summary>
        public string CodeDeProfession { get; set; }

        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        public long? NumeroSeqDisp { get; set; }

        /// <summary>
        /// Prénom du dispensateur  
        /// </summary>
        public string PrenomDisp { get; set; }

        /// <summary>
        /// Nom du dispensateur  
        /// </summary>
        public string NomDisp { get; set; }

        /// <summary>
        /// Date de décès 
        /// </summary>
        public DateTime? DateDeces { get; set; }

        /// <summary>
        /// Date de début de spécialité
        /// </summary>
        public DateTime? DateDebutSpec { get; set; }

        /// <summary>
        /// Dates d'obtention de permis
        /// </summary>
        public DateTime? DateObtentionPermis { get; set; }

        /// <summary>
        /// Classe du dispensateur
        /// </summary>
        public short? ClasseDispensateur { get; set; }

        /// <summary>
        /// Numéro du Dispensateur
        /// </summary>
        public int? NumeroDispensateur { get; set; }
    }
}