using System;

namespace RAMQ.PRE.PRE_Entites_cpo.Pratique.Entite
{
    /// <summary> 
    ///  Pratique Territoire
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : Février 2017
    /// </remarks>
	public class PratiqueTerritoire
    {
        /// <summary>
        ///  Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        public long NoSequentielDisp { get; set; }

        /// <summary>
        /// Nombre de jours PREM/DPNAG
        /// </summary>
        /// <remarks></remarks>
        public decimal NbJoursPremDpnag { get; set; }

        /// <summary>
        /// Nombre de jours PREM
        /// </summary>
        /// <remarks></remarks>
        public decimal NbJoursPrem { get; set; }

        /// <summary>
        /// Nombre de jours DPNAG
        /// </summary>
        /// <remarks></remarks>
        public decimal NbJoursDpnag { get; set; }

        /// <summary>
        /// Nombre de jours IVN
        /// </summary>
        /// <remarks></remarks>
        public decimal NbJoursIvn { get; set; }

        /// <summary>
        /// Le code de région socio-sanitaire
        /// </summary>
        /// <remarks></remarks>
        public string CodeRSS { get; set; }

        /// <summary>
        /// Numéro séquentiel de regroupement administratif d'un lieu géographique
        /// </summary>
        /// <remarks></remarks>
        public long? NumeroSeqRegrAdmnLGEO { get; set; }

        /// <summary>
        /// Type du lieu géographique
        /// </summary>
        /// <remarks></remarks>
        public string TypeLieuGeographique { get; set; }

        /// <summary>
        /// Code du lieu géographique
        /// </summary>
        /// <remarks></remarks>
        public string CodeLieuGeographique { get; set; }

        /// <summary>
        /// Date de service
        /// </summary>
        /// <remarks></remarks>
        public DateTime DateService { get; set; }
    }
}