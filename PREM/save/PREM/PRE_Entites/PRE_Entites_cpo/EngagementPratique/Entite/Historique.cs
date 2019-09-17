namespace RAMQ.PRE.PRE_Entites_cpo.EngagementPratique.Entite
{

    /// <summary> 
    ///  Historique d'un engagement de pratique
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Novembre 2016
    /// </remarks>
    public class Historique
    {

        #region Propriétés publiques

        /// <summary>
        /// Période
        /// </summary>
        /// <returns></returns>
        public Periode Periode { get; set; }

        /// <summary>
        /// Statut
        /// </summary>
        /// <returns></returns>
        public string Statut { get; set; }

        /// <summary>
        /// Raison du statut
        /// </summary>
        /// <returns></returns>
        public string RaisonStatut { get; set; }

        /// <summary>
        /// Nombre de jour d'engagement
        /// </summary>
        /// <returns></returns>
        public decimal? NombreJourEngagement { get; set; }

        /// <summary>
        /// Total des jours facturés
        /// </summary>
        /// <returns></returns>
        public decimal? TotalJourFacturer { get; set; }

        /// <summary>
        /// Pourcentage effectué
        /// </summary>
        /// <returns></returns>
        public decimal? PourcentageEffectuer { get; set; }

        /// <summary>
        /// Permet de savoir si le pourcentage effectué ne respecte pas l'entente
        /// </summary>
        public bool EstNonRespectEntente { get; set; }

        #endregion
        
    }

}