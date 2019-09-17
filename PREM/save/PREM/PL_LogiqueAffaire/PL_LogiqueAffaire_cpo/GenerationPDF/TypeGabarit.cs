namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF
{
    /// <summary> 
    ///  Énumération des type de gabarit
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public enum TypeGabarit
    {
        /// <summary>
        /// Gabarit par défaut
        /// </summary>
        Autre,

        /// <summary>
        /// Gabarit de confirmation pour un avis de conformité
        /// </summary>
        ConfirmationAvisConformite,

        /// <summary>
        /// Gabarit de confirmation pour une suspension
        /// </summary>
        ConfirmationSuspension,

        /// <summary>
        /// Gabarit de confirmation pour la modification d'une suspension
        /// </summary>
        ConfirmationModificationSuspension,

        /// <summary>
        /// Gabarit de confirmation pour une dérogation
        /// </summary>
        ConfirmationDerogation
    }
}