namespace RAMQ.PRE.PL_Prem_iut.Entite
{
    /// <summary>
    /// Critère de recherche pour la liste des journées facturé par RSS
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public class CritereRechercheJourneeFacturerRSS
    {

        /// <summary>
        /// Code RSS
        /// </summary>
        public string RSS { get; set; }

        /// <summary>
        /// Type de jour
        /// </summary>
        public string TypeJour { get; set; }

        /// <summary>
        /// Année
        /// </summary>
        public int? Annee { get; set; }

        /// <summary>
        /// Mois
        /// </summary>
        public int? Mois { get; set; }

    }
}