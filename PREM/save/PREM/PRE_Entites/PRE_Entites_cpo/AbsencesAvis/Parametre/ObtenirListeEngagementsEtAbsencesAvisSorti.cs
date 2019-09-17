using RAMQ.ClasseBase;
using RAMQ.PRE.PRE_Entites_cpo.AbsencesAvis.Entite;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_Entites_cpo.AbsencesAvis.Parametre
{
    /// <summary>
    /// Paramètres de sortie pour Obtenir les engagements et absences d'avis d'un professionnel
    /// </summary>
    /// <remarks>
    /// Auteur : FLorent Pollart
    /// </remarks>
	public class ObtenirListeEngagementsEtAbsencesAvisSorti : ParamSorti 
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirListeEngagementsEtAbsencesAvisSorti()
        {
            ListeEngagementsEtAbsencesAvis = new List<AbsenceAvis>();
        }

        /// <summary>
        /// Liste des engagements et/ou absences d'avis
        /// </summary>
        /// <remarks></remarks>
        public List<AbsenceAvis> ListeEngagementsEtAbsencesAvis { get; set; }
    }
}