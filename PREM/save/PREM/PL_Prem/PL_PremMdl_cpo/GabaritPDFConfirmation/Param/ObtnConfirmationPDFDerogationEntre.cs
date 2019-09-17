namespace RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation.Param
{
    /// <summary>
    /// Paramètre d'entrée pour l'obtention du gabarit PDF de confirmation
    /// pour une dérogation
    /// </summary>
    /// <remarks>
    /// Auteur : Alexis Garon-Michaud
    /// Date   : Avril 2017
    /// </remarks>
    public class ObtnConfirmationPDFDerogationEntre
    {

        /// <summary>
        /// Permet de savoir si l'action est une annulation, si c'est faux c'est une transmission
        /// </summary>
        public bool EstUneAnnulation { get; set; }

        /// <summary>
        /// Message de confirmation
        /// </summary>
        public string MessageConfirmation { get; set; }

        /// <summary>
        /// Identification du médecin
        /// </summary>
        public string IdentificationMedecin { get; set; }

        /// <summary>
        /// Type de dérogation
        /// </summary>
        public string TypeDerogation { get; set; }

        /// <summary>
        /// Date de début
        /// </summary>
        public string DateDebut { get; set; }

        /// <summary>
        /// Message informatif complémentaire
        /// </summary>
        public string MessageInformatifComplementaire { get; set; }
    }
}