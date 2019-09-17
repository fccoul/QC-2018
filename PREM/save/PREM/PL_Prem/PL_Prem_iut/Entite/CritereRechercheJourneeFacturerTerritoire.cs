namespace RAMQ.PRE.PL_Prem_iut.Entite
{
    /// <summary>
    /// Critère de recherche pour la liste des journées facturé par territoire
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public class CritereRechercheJourneeFacturerTerritoire
    {

        /// <summary>
        /// Numéro de séquence du regroupement du lieu géographique
        /// </summary>
        public long? NumeroSequenceRegroupementLieuGeo { get; set; }

        /// <summary>
        /// Type de lieu géographique
        /// </summary>
        public string TypeLieuGeo { get; set; }

        /// <summary>
        /// Code du lieu géographique
        /// </summary>
        public string CodeLieuGeo { get; set; }

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