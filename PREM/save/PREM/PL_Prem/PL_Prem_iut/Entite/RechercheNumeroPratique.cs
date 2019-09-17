namespace RAMQ.PRE.PL_Prem_iut.Entite
{
    /// <summary>
    /// Entité pour les paramètres de recherches en entré
    /// </summary>
    public class RechercheNumeroPratique
    {
        /// <summary>
        /// Le terme recherché
        /// </summary>
        public string Terme { get; set; }

        /// <summary>
        /// Limite de résultat par page
        /// </summary>
        public int LimiteParPage { get; set; }

        /// <summary>
        /// Classes de professionnel utilisées
        /// </summary>
        public int[] ClassesProfessionnelUtilise { get; set; }

        /// <summary>
        /// Page à retourner
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Utilisation du filtre pour la création d'avis
        /// </summary>
        public bool FiltreSpecialPourCreationAvis { get; set; }
    }
}