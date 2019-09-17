using System;

namespace RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre
{
    /// <summary> 
    /// Paramètre d'entrée pour la création d'un avis de conformité
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : 2016-09-21
    /// </remarks>
    public class CreerAvisConformiteEntre
    {

        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        public long NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Code de région socio-sanitaire
        /// </summary>
        /// <remarks></remarks>
        public string CodeRegion { get; set; }

        /// <summary>
        /// Date de début de l'engagement
        /// </summary>
        /// <remarks></remarks>
        public DateTime DateDebutEngagement { get; set; }

        /// <summary>
        /// Date de fin de l'engagement
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateFinEngagement { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui a créé l'occurence
        /// </summary>
        /// <remarks></remarks>
        public string IdentifiantCreation { get; set; }

        /// <summary>
        /// CType de lieu géographique
        /// </summary>
        /// <remarks></remarks>
        public string TypeLieuGeographique { get; set; }

        /// <summary>
        /// Code du lieu géographique
        /// </summary>
        /// <remarks></remarks>
        public string CodeLieuGeographique { get; set; }

        /// <summary>
        /// Numéro séquentiel de regroupement administratif des lieux géographiques
        /// </summary>
        /// <remarks></remarks>
        public long? NumeroSequentielRegroupement { get; set; }

        /// <summary>
        /// Statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        public string StatutEngagement { get; set; }

        /// <summary>
        /// Indicateur de statut de l'engagement en attente
        /// </summary>
        /// <remarks></remarks>
        public string IndicateurStatutEngagementAttente { get; set; }

        /// <summary>
        /// Code de raison du statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        public string CodeRaisonStatutEngagement { get; set; }

    }
}