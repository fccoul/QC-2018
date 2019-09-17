namespace RAMQ.PRE.PRE_Entites_cpo.EngagementPratique.Parametre
{

    /// <summary> 
    ///  Paramètre d'entré de l'obtention des engagements de pratique
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : 2016-09-16
    /// </remarks>
    public class ObtenirEngagementPratiqueEntre
    {

        #region Propriétés publiques

        /// <summary>
        /// Numéro de séquence du dispensateur
        /// </summary>
        /// <returns></returns>
        public long NumeroSequenceDispensateur { get; set; }

        /// <summary>
        /// Boolean pour savoir si l'utilisateur est DRMG ou non
        /// </summary>
        public bool EstDRMG { get; set; }

        #endregion

    }

}