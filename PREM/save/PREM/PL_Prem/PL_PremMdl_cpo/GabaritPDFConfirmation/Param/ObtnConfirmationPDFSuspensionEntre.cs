using static RAMQ.PRE.PRE_Entites_cpo.Enumerations;

namespace RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation.Param
{
    /// <summary>
    /// Paramètre d'entrée pour l'obtention du gabarit PDF de confirmation
    /// pour une suspension
    /// </summary>
    /// <remarks>
    /// Auteur : Alexis Garon-Michaud
    /// Date   : Avril 2017
    /// </remarks>
    public class ObtnConfirmationPDFSuspensionEntre
    {
       /// <summary>
       /// Type d'action
       /// </summary>
        public TypeTraitementSuspension TypeAction { get; set; }

        /// <summary>
        /// Message de confirmation
        /// </summary>
        public string MessageConfirmation { get; set; }

        /// <summary>
        /// Identification du médecin
        /// </summary>
        public string IdentificationMedecin { get; set; }

        /// <summary>
        /// Avis de conformité
        /// </summary>
        public string AvisConformite { get; set; }

        /// <summary>
        /// Type de suspension
        /// </summary>
        public string TypeSuspension { get; set; }

        /// <summary>
        /// Date de début
        /// </summary>
        public string DateDebut { get; set; }

        /// <summary>
        /// Date de fin
        /// </summary>
        public string DateFin { get; set; }

        /// <summary>
        /// Date de début de la période modifiée
        /// </summary>
        public string DateDebutPerModif { get; set; }

        /// <summary>
        /// Date de fin de la période modifiée
        /// </summary>
        public string DateFinPerModif { get; set; }
    }
}