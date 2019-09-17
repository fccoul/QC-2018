namespace RAMQ.PRE.PRE_Entites_cpo.Pratique.Entite
{
    /// <summary> 
    ///  JoursFactTerritoire
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Juillet 2017
    /// </remarks>
	public class JoursFactTerritoire : JoursFactures
    {
        /// <summary>
        /// Regroupement administratif d'un lieu géographique
        /// </summary>
        /// <remarks></remarks>
        public long? NumeroSeqRegrAdmnLGEO { get; set; }

        /// <summary>
        /// Type du lieu géographique
        /// </summary>
        /// <remarks></remarks>
        public string TypeLieuGeographique { get; set; }

        /// <summary>
        /// Code du lieu géographique
        /// </summary>
        /// <remarks></remarks>
        public string CodeLieuGeographique { get; set; }

        /// <summary>
        /// Code RSS
        /// </summary>
        /// <remarks></remarks>
        public string CodeRSS { get; set; }

        /// <summary>
        /// Pourcentage
        /// </summary>
        /// <remarks></remarks>
        public decimal Pourcentage { get; set; }

        /// <summary>
        /// Annee
        /// </summary>
        /// <remarks></remarks>
        public int? Annee { get; set; }

        /// <summary>
        /// Mois
        /// </summary>
        /// <remarks></remarks>
        public int? Mois { get; set; }
    }
}