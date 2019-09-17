using System;
namespace RAMQ.PRE.PRE_Entites_cpo.Pratique.Entite
{
    /// <summary> 
    ///  Respect d’engagement du médecin omnipraticien
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Juillet 2017
    /// </remarks>
	public class RespectEngagementProfs
    {
        /// <summary>
        ///  Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        public long NoSequentielDisp { get; set; }

        /// <summary>
        /// Date de début
        /// </summary>
        public DateTime? DdEngagement { get; set; }

        /// <summary>
        /// Date de fin
        /// </summary>
        public DateTime? DfEngagement { get; set; }

        /// <summary>
        /// Identifiant du pourcentage
        /// </summary>
        /// <remarks></remarks>
        public string IdentifiantPourcentage { get; set; }

        /// <summary>
        /// Nombre de jours
        /// </summary>
        public decimal NombreJours { get; set; }

        /// <summary>
        /// Nombre de jours total
        /// </summary>
        public decimal JoursTotal { get; set; }

        /// <summary>
        /// Pourcentage
        /// </summary>
        /// <remarks></remarks>
        public decimal Pourcentage { get; set; }

        /// <summary>
        /// Indicateur de respect d'engagement
        /// </summary>
        /// <remarks></remarks>
        public string IndicateurRespectEngag { get; set; }

    }
}