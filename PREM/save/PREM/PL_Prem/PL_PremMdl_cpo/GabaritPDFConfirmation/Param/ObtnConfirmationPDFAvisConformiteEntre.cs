using RAMQ.PRE.PRE_Entites_cpo;

namespace RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation.Param
{
    /// <summary>
    /// Paramètre d'entrée pour l'obtention du gabarit PDF de confirmation
    /// pour un avis de conformité
    /// </summary>
    /// <remarks>
    /// Auteur : Alexis Garon-Michaud
    /// Date   : Avril 2017
    /// </remarks>
    public class ObtnConfirmationPDFAvisConformiteEntre
    {
        /// <summary>
        /// Type d'action sur l'avis de conformité
        /// </summary>
        public Enumerations.TypeTraitementAvisConformite TypeAction { get; set; }

        /// <summary>
        /// Message de confirmation
        /// </summary>
        public string MessageConfirmation { get; set; }

        /// <summary>
        /// Identification du médecin
        /// </summary>
        public string IdentificationMedecin { get; set; }

        /// <summary>
        /// Territoire
        /// </summary>
        public string Territoire { get; set; }

        /// <summary>
        /// Date de début prévue de l'avis
        /// </summary>
        public string DateDebutPrevueAvis { get; set; }
    }
}