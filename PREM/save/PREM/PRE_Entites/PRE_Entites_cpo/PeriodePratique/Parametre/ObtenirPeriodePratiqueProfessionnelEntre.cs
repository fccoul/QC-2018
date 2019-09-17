namespace RAMQ.PRE.PRE_Entites_cpo.PeriodePratique.Parametre
{

    /// <summary> 
    ///  Paramètres d'entrées pour l'obtention des périodes de pratique d'un professionnel
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : 2016-09-16
    /// </remarks>
    public class ObtenirPeriodePratiqueProfessionnelEntre
    {

        /// <summary>
        /// Numéro de séquence du dispensateur
        /// </summary>
        public long NumeroSequenceDispensateur { get; set; }

        /// <summary>
        /// Numéro du type  de pratique
        /// </summary>
        public int NumeroTypePratique { get; set; }

    }

}