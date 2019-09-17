using System;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Entite
{
    /// <summary> 
    /// Entite des avis de conformité
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : 2016-09-21
    /// </remarks>
    public class AvisConformite
    {

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public AvisConformite()
        {
            ListeStatutAvisConformite = new List<StatutAvisConformite>();
        }

        #endregion

        #region Propriétés publiques

        /// <summary>
        /// Numéro séquentiel de l'engagement de pratique
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
        /// Date de début de l'engagement
        /// </summary>
        /// <remarks></remarks>
        public DateTime DateDebutEngagement { get; set; }

        /// <summary>
        /// Date et heure de l'occurence
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateHeureOccurence { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui a créé l'occurence
        /// </summary>
        /// <remarks></remarks>
        public string IdentifiantCreation { get; set; }

        /// <summary>
        /// Date de fin de l'engagement
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateFinEngagement { get; set; }

        /// <summary>
        /// Date et heure de la modification de l'occurence
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateHeureOccurenceMAJ { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui a modifié l'occurence
        /// </summary>
        /// <remarks></remarks>
        public string IdentifiantMAJ { get; set; }

        /// <summary>
        /// Date et heure de l'inactivité de l'occurence
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateHeureOccurenceInactive { get; set; }

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
        /// Numéro séquentiel de regroupement administratif des lieux géographiques
        /// </summary>
        /// <remarks></remarks>
        public long? NumeroSequentielRegroupement { get; set; }

        /// <summary>
        /// Liste des statuts des avis de conformité
        /// </summary>
        /// <remarks></remarks>
        public List<StatutAvisConformite> ListeStatutAvisConformite { get; set; }

        #endregion

    }
}