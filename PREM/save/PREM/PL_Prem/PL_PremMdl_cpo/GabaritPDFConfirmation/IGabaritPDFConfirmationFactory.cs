namespace RAMQ.PRE.PL_PremMdl_cpo.GabaritPDFConfirmation
{
    /// <summary>
    /// Interface de la fabrique qui permet d'instancier le bon objet tout dépendant 
    /// du contexte d'utilisation pour les gabarits PDF de confirmation
    /// </summary>
    /// <remarks>
    /// Auteur : Alexis Garon-Michaud
    /// Date   : Avril 2017
    /// </remarks>
    public interface IGabaritPDFConfirmationFactory
    {
        /// <summary>
        ///  Instancie le référentiel de type référentiel de type IGabaritPDFConfirmation en fonction de la configuration de 
        ///  l'application.
        /// </summary>
        /// <returns>Le référentiel selon les configurations</returns>
        IGabaritPDFConfirmation Instancier();
    }
}