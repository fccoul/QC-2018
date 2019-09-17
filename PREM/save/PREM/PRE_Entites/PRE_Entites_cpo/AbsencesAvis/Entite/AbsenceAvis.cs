using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PRE_Entites_cpo.AbsencesAvis.Entite
{
    /// <summary>
    /// Entite absence avis
    /// </summary>
    /// <remarks>
    /// Auteur : Florent Pollart
    /// </remarks>
	public class AbsenceAvis
    {
        /// <summary>
        /// Numéro de séquence du dispensateur
        /// </summary>
        /// <returns></returns>
        public long NumeroSequenceDispensateur { get; set; }

        /// <summary>
        /// Numéro séquentiel de l'avis
        /// </summary>
        public long? NumeroSequentielAvis { get; set; }

        /// <summary>
        /// Numéro séquentiel de la dérogation
        /// </summary>
        public long? NumeroSequentielDerogation { get; set; }

        /// <summary>
        /// Numéro séquentiel de l'autorisation
        /// </summary>
        public long? NumeroSequentielAutorisation { get; set; }

        /// <summary>
        /// Date de début
        /// </summary>
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Date de début
        /// </summary>
        public DateTime DateFin { get; set; }

        /// <summary>
        /// Statut de l'avis ou de la dérogation
        /// </summary>
        public string Statut { get; set; }

        /// <summary>
        /// Code de lieu de l'avis
        /// </summary>
        public string CodeLieuGeographique { get; set; }

        /// <summary>
        /// Type de lieu de l'avis
        /// </summary>
        public string TypeLieuGeographique { get; set; }

        /// <summary>
        /// Code de regroupement de l’avis
        /// </summary>
        public long? NumeroSeqRegrAdmnLgeo { get; set; }

        /// <summary>
        /// Code de région de l’avis 
        /// </summary>
        public string CodeRss { get; set; }

        /// <summary>
        /// Type de dérogation 
        /// </summary>
        public string TypeDerogation { get; set; }
    }
}