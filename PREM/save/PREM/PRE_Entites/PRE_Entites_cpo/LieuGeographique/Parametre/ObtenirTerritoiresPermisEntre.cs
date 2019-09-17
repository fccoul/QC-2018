using System;

namespace RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Parametre
{

    /// <summary> 
    /// Entité d'intrant pour l'obtention des territoires permis
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Décembre 2016
    /// </remarks>
    public class ObtenirTerritoiresPermisEntre
    {

        /// <summary>
        /// Date de début de pratique
        /// </summary>
        public DateTime DateDebutPratique { get; set; }

        /// <summary>
        /// Code de la région socio-sanitaire
        /// </summary>
        public string CodeRSS { get; set; }
    }
}