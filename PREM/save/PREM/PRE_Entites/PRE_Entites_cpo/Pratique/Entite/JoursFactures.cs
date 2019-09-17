namespace RAMQ.PRE.PRE_Entites_cpo.Pratique.Entite
{
    /// <summary> 
    ///  JoursFactures
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : Février 2017
    /// </remarks>
	public class JoursFactures
    {
        /// <summary>
        ///  Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        public long NoSequentielDisp { get; set; }

        /// <summary>
        /// Nombre de jours
        /// </summary>
        /// <remarks></remarks>
        public decimal NombreJours { get; set; }

        /// <summary>
        /// Type de jours
        /// </summary>
        /// <remarks></remarks>
        public string TypeJours { get; set; }
    }
}