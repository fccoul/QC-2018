using System;

namespace RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Entite
{

    /// <summary> 
    /// Informations du regroupement
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Octobre 2016
    /// </remarks>
    public class Regroupement
    {

        #region Propriétés publiques

        /// <summary>
        /// Nunéro séquence regroupement administratif du lieu géographique
        /// </summary>
        public long NumeroSequenceRegroupement { get; set; }

        /// <summary>
        /// Numéro séquance document officiel
        /// </summary>
        public long NumeroSequenceDocumentOfficiel { get; set; }

        /// <summary>
        /// Type de regroupement administratif du lieu géographique
        /// </summary>
        public string TypeRegroupement { get; set; }

        /// <summary>
        /// Code de regroupement administratif du lieu géographique
        /// </summary>
        public string CodeRegroupement { get; set; }

        /// <summary>
        /// Date de début du regroupement
        /// </summary>
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Nom du regroupement
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Numéro du niveau de regroupement administratif du lieu géographique
        /// </summary>
        public int NumeroNiveau { get; set; }

        /// <summary>
        /// Type de lieu géographique
        /// </summary>
        public string TypeLieuGeographique { get; set; }

        /// <summary>
        /// Code de lieu géographique
        /// </summary>
        public string CodeLieuGeographique { get; set; }

        /// <summary>
        /// Numéro de séquence regroupement administratif du lieu géographique responsable
        /// </summary>
        public int? NumeroSequenceResponsable { get; set; }

        /// <summary>
        /// Date de fin du regroupement
        /// </summary>
        public DateTime? DateFin { get; set; }

        /// <summary>
        /// Date et heure de création de l'occurence
        /// </summary>
        public DateTime DateHeureCreationOccurence { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur de la création de l'occurence
        /// </summary>
        public string IdentifiantUtilisateurCreation { get; set; }

        /// <summary>
        /// Date et heure de l'inactivation de l'occurence
        /// </summary>
        public DateTime? DateHeureInactivationOccurence { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur de l'inactivation de l'occurence
        /// </summary>
        public string IdUtilInact { get; set; }

        #endregion

    }
}