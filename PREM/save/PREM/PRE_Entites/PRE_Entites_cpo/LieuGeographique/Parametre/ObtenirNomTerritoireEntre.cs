using System;

namespace RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Parametre
{

    /// <summary> 
    /// Entité d'intrant pour l'obtention du nom d'un territoire
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Décembre 2016
    /// </remarks>
    public class ObtenirNomTerritoireEntre
    {
        /// <summary>
        /// Date de début de pratique
        /// </summary>
        public DateTime? DateDebutPratique { get; set; }

        /// <summary>
        /// Numéro séquentiel
        /// </summary>
        public long? NumeroSequentiel { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Code du territoire
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Code de la région socio-sanitaire
        /// </summary>
        public string CodeRSS { get; set; }
    }
}