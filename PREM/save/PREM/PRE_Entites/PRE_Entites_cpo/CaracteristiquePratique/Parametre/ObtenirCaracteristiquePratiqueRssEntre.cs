using System;

namespace RAMQ.PRE.PRE_Entites_cpo.CaracteristiquePratique.Parametre
{

    /// <summary> 
    ///  Classe de paramètres d'entré pour l'obtention des caractéristiques pratique RSS
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart<br/>
    /// </remarks>
    public class ObtenirCaracteristiquePratiqueRssEntre
    {

        /// <summary>
        /// Code RSS
        /// </summary>
        /// <remarks></remarks>
        public string CodeRss { get; set; }

        /// <summary>
        /// Caractéristique de pratique
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public string CaracteristiquePratique { get; set; }

        /// <summary>
        /// Date de début
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public DateTime? DateDeDebut { get; set; }

        /// <summary>
        /// Date de fin
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public DateTime? DateDeFin { get; set; }
    }

}