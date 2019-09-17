using System;

namespace RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre
{
    /// <summary> 
    /// Paramètre d'entrée pour l'obtention des avis de conformité
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : 2016-09-21
    /// </remarks>
    public class ObtenirLesAvisConformiteEntre
    {

        /// <summary>
        /// Numéro séquentiel de l'engagement
        /// </summary>
        /// <remarks></remarks>
        public long? NumeroSequentielEngagement { get; set; }

        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        public long? NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Code de région socio-sanitaire
        /// </summary>
        /// <remarks></remarks>
        public string CodeRegion { get; set; }

        /// <summary>
        /// Indicateur d'attente de transmission
        /// </summary>
        /// <remarks></remarks>
        public string IndicateurAttenteTransmission { get; set; }

        /// <summary>
        /// Date de recherche
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateRecherche { get; set; }

        /// <summary>
        /// Date de début
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateDebut { get; set; }

        /// <summary>
        /// Date de fin
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateFin { get; set; }

        /// <summary>
        /// Indicateur d'avis inactivé
        /// </summary>
        /// <remarks></remarks>
        public string IndicateurAvisInactive { get; set; }

        /// <summary>
        /// Tri
        /// </summary>
        /// <remarks></remarks>
        public string Tri { get; set; }

    }
}