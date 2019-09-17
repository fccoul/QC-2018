namespace RAMQ.PRE.PRE_Entites_cpo.DemandeReevaluation.Parametre
{
    /// <summary> 
    /// Paramètre d'entrée pour l'annulation des demandes de réévaluation
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Mars 2018
    /// </remarks>
    public class AnnulerDemandeReevaluationEntre
    {

        /// <summary>
        /// Numéro séquentiel de l'engagement de pratique
        /// </summary>
        /// <remarks></remarks>
        public long NumeroSequentielDemande { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui annule la demande
        /// </summary>
        /// <remarks></remarks>
        public string IdentifiantInact{ get; set; }

    }
}