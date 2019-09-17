namespace RAMQ.PRE.PRE_Entites_cpo.Pratique.Entite
{
    /// <summary> 
    ///  Sommaire d'un professionnel de la santé pour un avis
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Juillet 2017
    /// </remarks>
	public class SommaireProf : JoursFactures
    {

        /// <summary>
        /// Type de total
        /// </summary>
        /// <remarks></remarks>
        public string TypeTotal { get; set; }
    }
}