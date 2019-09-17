namespace RAMQ.PRE.PRE_Entites_cpo.Pratique.Entite
{
    /// <summary> 
    ///  PourcentageProf
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Juillet 2017
    /// </remarks>
	public class Message
    {
        /// <summary>
        ///  Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        public long NoSequentielDisp { get; set; }

        /// <summary>
        ///  Numéro de message
        /// </summary>
        /// <remarks></remarks>
        public string NumeroMessage { get; set; }

        /// <summary>
        /// Paramètre de message 1
        /// </summary>
        public string ParamMsg1 { get; set; }

        /// <summary>
        /// Paramètre de message 2
        /// </summary>
        public string ParamMsg2 { get; set; }

    }
}