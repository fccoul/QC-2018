using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal;
using RAMQ.PRE.PRE_Entites_cpo.AbsencesAvis.Parametre;
using System;
using ParametrePlanRegnMdcal = RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.AbsenceAvis
{
    /// <summary>
    /// Absence Avis
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class AbsenceAvis
    {
        #region Attribut privé

        private readonly IPlanRegnMdcal _clientPlanRegnMdcal;

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public AbsenceAvis(IPlanRegnMdcal planRegnMdcal)
        {
            if (planRegnMdcal == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(planRegnMdcal)} ne peut être null.");
            }

            _clientPlanRegnMdcal = planRegnMdcal;
        }

        #endregion

        #region Méthodes publiques

        /// <summary>
        /// Permet d'obtenir une liste des engagements et/ou absences d'avis d'un professionnel
        /// </summary>
        /// <Parametre name="intrant">Paramètre d'entré</Parametre>
        /// <returns>Une liste des engagements et/ou absences d'avis d'un professionnel</returns>
        /// <remarks></remarks>
        public ObtenirListeEngagementsEtAbsencesAvisSorti ObtenirListeEngagementsEtAbsencesAvis(ObtenirListeEngagementsEtAbsencesAvisEntre intrant)
        {
            ParametrePlanRegnMdcal.ObtenirListeEngagementsEtAbsencesAvisEntre intrantPlanRegnMdcal = new ParametrePlanRegnMdcal.ObtenirListeEngagementsEtAbsencesAvisEntre();
            ParametrePlanRegnMdcal.ObtenirListeEngagementsEtAbsencesAvisSorti extrantPlanRegnMdcal = new ParametrePlanRegnMdcal.ObtenirListeEngagementsEtAbsencesAvisSorti();
            ObtenirListeEngagementsEtAbsencesAvisSorti extrant = new ObtenirListeEngagementsEtAbsencesAvisSorti();

            try
            {
                Utilitaire.Mappeur.Mapper(intrant, ref intrantPlanRegnMdcal);

                extrantPlanRegnMdcal = _clientPlanRegnMdcal.ObtenirListeEngagementsEtAbsencesAvis(intrantPlanRegnMdcal);

                Utilitaire.Mappeur.Mapper(extrantPlanRegnMdcal, ref extrant);

            }
            catch (Exception)
            {
                throw;
            }

            return extrant;
        }

        #endregion
    }
}