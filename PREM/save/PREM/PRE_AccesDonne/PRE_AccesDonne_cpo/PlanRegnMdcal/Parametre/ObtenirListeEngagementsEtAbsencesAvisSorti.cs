using RAMQ.Attribut;
using RAMQ.ClasseBase;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite;
using System.Collections.Generic;
using System.Data;


namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    /// Classe de paramètres de sorties pour le service du noyau « ObtenirListeEngagEtAbsAvis »
    /// </summary>
    /// <remarks>
    /// Auteur: Florent Pollart
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
        [ValeurEntite(ElementName = "pCurListeEngagEtAbsAvis", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.RefCursor)]
        public List<AbsenceAvis> ListeEngagementsEtAbsencesAvis { get; set; }
    }
}