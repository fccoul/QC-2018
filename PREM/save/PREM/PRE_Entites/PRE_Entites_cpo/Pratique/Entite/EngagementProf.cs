using System;

namespace RAMQ.PRE.PRE_Entites_cpo.Pratique.Entite
{
    /// <summary> 
    ///  Engagement
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Juillet 2018
    /// </remarks>
	public class EngagementProf
    {
        /// <summary>
        ///  Numéro de séquence du dispensateur
        /// </summary>
        /// <remarks></remarks>
        public long NoSeqDisp { get; set; }

        /// <summary>
        ///  Numéro de séquence d'engagement
        /// </summary>
        /// <remarks></remarks>
        public long NoSeqEngagement { get; set; }

        /// <summary>
        /// Date de début
        /// </summary>
        public DateTime? DateDebut { get; set; }

        /// <summary>
        /// Date de fin
        /// </summary>
        public DateTime? DateFin { get; set; }

        /// <summary>
        /// Code RSS
        /// </summary>
        public string CodeRSS { get; set; }
        
        /// <summary>
        /// Nom du territoire géographique
        /// </summary>
        /// <remarks></remarks>
        public string NomTerritoire { get; set; }

    }
}