using System;

namespace RAMQ.PRE.PRE_Entites_cpo.Pratique.Entite
{
    /// <summary> 
    ///  JoursFactAvis
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Juillet 2017
    /// </remarks>
	public class JoursFactAvis : JoursFactures
    {

        /// <summary>
        /// Date de fin de l'engagment
        /// </summary>
        /// <remarks></remarks>
        public DateTime DateDebutEngag { get; set; }

        /// <summary>
        /// Date de début de l'engagment
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateFinEngag { get; set; }

        /// <summary>
        /// Statut
        /// </summary>
        /// <remarks></remarks>
        public string Statut { get; set; }

        /// <summary>
        /// Nombre de jours admissibles
        /// </summary>
        /// <remarks></remarks>
        public decimal JoursAdmissibles { get; set; }

        /// <summary>
        /// Pourcentage
        /// </summary>
        /// <remarks></remarks>
        public decimal Pourcentage { get; set; }

        /// <summary>
        /// Date de début du statut
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateDebutStatut { get; set; }

        /// <summary>
        /// Date de fin du statut
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateFinStatut { get; set; }
    }
}