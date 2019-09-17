namespace RAMQ.PRE.PRE_Entites_cpo.Recherche.Entite
{
    /// <summary>
    /// Entité pour les critères de recherche
    /// </summary>
    public class Critere
    {

        /// <summary>
        /// Terme
        /// </summary>
        public string Terme { get; set; }

        /// <summary>
        /// Limite par page
        /// </summary>
        public int LimiteParPage { get; set; }

        /// <summary>
        /// Page
        /// </summary>
        public int Page { get; set; }

    }
}