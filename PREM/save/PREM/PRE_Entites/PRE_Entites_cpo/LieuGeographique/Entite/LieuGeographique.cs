using System;

namespace RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Entite
{

    /// <summary> 
    /// Informations du lieu géographique
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Octobre 2016
    /// </remarks>
    public class LieuGeographique
    {

        #region Propriétés publiques

        /// <summary>
        /// Nunéro séquence regroupement administratif du lieu géographique
        /// </summary>
        public long NumeroSequence { get; set; }

        /// <summary>
        /// Numéro séquence du regroupement
        /// </summary>
        public long NumeroSequenceRegroupement { get; set; }

        /// <summary>
        /// Type du lieu géographique
        /// </summary>
        public string TypeLieuGeographique { get; set; }

        /// <summary>
        /// Code de lieu géographique
        /// </summary>
        public string CodeLieuGeographique { get; set; }

        /// <summary>
        /// Date de début du regroupement
        /// </summary>
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Date de fin du regroupement
        /// </summary>
        public DateTime? DateFin { get; set; }

        /// <summary>
        /// Nom du regroupement
        /// </summary>
        public string NomLieuGeographique { get; set; }

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