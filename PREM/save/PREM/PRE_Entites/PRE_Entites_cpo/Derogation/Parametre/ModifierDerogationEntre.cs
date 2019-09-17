using System;

namespace RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre
{

    /// <summary> 
    ///  Paramètres d'entré pour la modification d'une dérogation d'un professionnel de la santé
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Novembre 2016
    /// </remarks>
    public class ModifierDerogationEntre
    {

        /// <summary>
        /// Numéro séquantiel de la dérogation
        /// </summary>
        /// <remarks></remarks>
        public long NumeroSequentiel { get; set; }

        /// <summary>
        /// Numéro séquantiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        public long? NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Type de dérogation
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public string Type { get; set; }

        /// <summary>
        /// Date de renouvellemenent de la dérogation
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public DateTime? DateRenouvellement { get; set; }

        /// <summary>
        /// Date de début de la dérogation
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public DateTime? DateDebut { get; set; }

        /// <summary>
        /// Date de fin de la dérogation
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public DateTime? DateFin { get; set; }

        /// <summary>
        /// Statut de la dérogation
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public string Statut { get; set; }

        /// <summary>
        /// Code de raison du statut
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public string CodeRaisonStatut { get; set; }

        /// <summary>
        /// Identifiant de la MAJ
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public string IdentifiantMAJ { get; set; }
    }

}