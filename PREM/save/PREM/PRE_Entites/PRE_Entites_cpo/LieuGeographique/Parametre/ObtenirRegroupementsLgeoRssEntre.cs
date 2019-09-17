using System;

namespace RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Parametre
{

    /// <summary> 
    /// Paramètres d'entrés de la méthode ObtenirListeRegrLgeoRattaRss
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Octobre 2016
    /// </remarks>
    public class ObtenirRegroupementsLgeoRssEntre
    {

        /// <summary>
        /// Type de regrouppement
        /// </summary>
        /// <remarks></remarks>
        public string TypeRegroupement { get; set; }

        /// <summary>
        /// Numéro document officiel 
        /// </summary>
        /// <remarks></remarks>
        public string NumeroDocumentOfficiel { get; set; }

        /// <summary>
        /// Date de recherche
        /// </summary>
        /// <remarks>Optionnelle</remarks>
        public DateTime? DateRecherche { get; set; }

        /// <summary>
        /// Date de début de recherche
        /// </summary>
        /// <remarks>Optionnelle</remarks>
        public DateTime? DateDebutRecherche { get; set; }

        /// <summary>
        /// Date de fin de recherche
        /// </summary>
        /// <remarks>Optionnelle</remarks>
        public DateTime? DateFinRecherche { get; set; }

        /// <summary>
        /// Code RSS de la région socio-sanitaire  
        /// </summary>
        /// <remarks></remarks>
        public string CodeRssRegionSocioSanitaire { get; set; }

        /// <summary>
        /// Numéro de séquence de regroupement administratif du lieu géographique
        /// </summary>
        /// <remarks></remarks>
        public long? NumeroSequenceRegrAdminLieuGeo { get; set; }

        /// <summary>
        /// Indicateur d’obtention des regroupements parents au regroupement immédiat
        /// </summary>
        /// <remarks></remarks>
        public bool IndObtentionLgeo { get; set; }

        /// <summary>
        /// Indicateur pour obtenir uniquement le regroupement visé par la recherche.  
        /// </summary>
        /// <remarks>Les regroupements inférieurs et les lieux géographiques ne seront pas retournés</remarks>
        public bool IndObtenirUniquementRegroupement { get; set; }
    }

}