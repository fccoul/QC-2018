using System;

namespace RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre
{

    /// <summary> 
    ///  Paramètre d'entrée pour obtenir les informations sur la relation dispensateur individu
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Octobre 2016
    /// </remarks>
    public class ObtenirDispensateurIndividuEntre
    {

        /// <summary>
        /// Classe du dispensateur
        /// </summary>
        public int? NumeroClasseDispensateur { get; set; }

        /// <summary>
        /// Numéro du dispensateur
        /// </summary>
        public int? NumeroDispensateur { get; set; }

        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        public long? NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Numéro séquentiel d'individu
        /// </summary>
        public long? NumeroSequentielIndividu { get; set; }

        /// <summary>
        /// Date de service
        /// </summary>
        public DateTime? DateService { get; set; }

    }
}