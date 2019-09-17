namespace RAMQ.PRE.PRE_Entites_cpo.Pratique.Entite
{
    /// <summary> 
    ///  JoursFactRSS
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Juillet 2017
    /// </remarks>
	public class JoursFactRSS : JoursFactures
    {

        /// <summary>
        /// Le code de région socio-sanitaire
        /// </summary>
        /// <remarks></remarks>
        public string RSS { get; set; }

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