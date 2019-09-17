using System;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_Entites_cpo.Pratique.Parametre
{
    /// <summary> 
    ///  Paramètres d'entré pour CalculerNbrJrsPratiProfs
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois<br/>
    ///  Date   : Juillet 2017
    /// </remarks>
	public class CalculerNbrJrFactProfsEntre
    {
        /// <summary>
        /// Liste de numéros séquentiels des professionnels de la santé 
        /// </summary>
        /// <remarks></remarks>
        public IEnumerable<long> NumerosSequentielsProfs { get; set; }

        /// <summary>
        /// Date de début (Optionnelle)
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public DateTime? DateDebut { get; set; }

        /// <summary>
        /// Date de fin (Optionnelle)
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public DateTime? DateFin { get; set; }

        /// <summary>
        /// Obtention de la liste par territoire (Optionnelle)
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public bool ObtenirListeIntra { get; set; } = false;

        /// <summary>
        /// Obtention de la liste par RSS (Optionnelle)
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public bool ObtenirListeInter { get; set; } = false;

        /// <summary>
        /// Obtention de la liste des respects d'engagement (Optionnelle)
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public bool ObtenirListeRespectEngag { get; set; } = false;

        /// <summary>
        /// Obtention de la liste par RPPR (Optionnelle)
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public bool ObtenirListeRPPR { get; set; } = false;
    }
}