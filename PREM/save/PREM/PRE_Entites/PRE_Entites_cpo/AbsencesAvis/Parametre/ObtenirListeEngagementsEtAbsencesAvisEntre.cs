using System;

namespace RAMQ.PRE.PRE_Entites_cpo.AbsencesAvis.Parametre
{
    /// <summary>
    /// Paramètres de sortie pour Obtenir les engagements et absences d'avis d'un professionnel
    /// </summary>
    /// <remarks>
    /// Auteur : FLorent Pollart
    /// </remarks>
	public class ObtenirListeEngagementsEtAbsencesAvisEntre
    {
        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        public long? NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Date de début
        /// </summary>
        /// <remarks></remarks>
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Date de fin
        /// </summary>
        /// <remarks></remarks>
        public DateTime DateFin { get; set; }

        /// <summary>
        /// Type liste à retourner
        /// </summary>
        /// <remarks></remarks>
        public int? TypeListe { get; set; }
    }
}