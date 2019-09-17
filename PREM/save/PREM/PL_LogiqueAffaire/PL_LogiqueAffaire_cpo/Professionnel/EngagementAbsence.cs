using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.Professionnel
{
    /// <summary> 
    ///  Classe pour la recherche ddes engagements et peridoe absence.
    /// </summary>
    /// <remarks>
    ///  Auteur : Franck COULIBALY <br/>
    ///  Date   : Juin 2018
    /// </remarks>
    public class EngagementAbsence : IEngagementAbence
    {
        #region Attributs privées
        private readonly IPlanRegnMdcal _clientPlanRegionnalMedical;
        #endregion

        #region constructeur
        /// <summary>
        /// constructeur par defaut
        /// </summary>
        /// <param name="clientPlanRegionnalMedical"></param>
        public EngagementAbsence(IPlanRegnMdcal clientPlanRegionnalMedical)
        {
            if (clientPlanRegionnalMedical == null)
            {
                throw new System.ArgumentNullException($"Le paramètre {nameof(clientPlanRegionnalMedical)} est obligatoire");
            }

            _clientPlanRegionnalMedical = clientPlanRegionnalMedical;
        }
        #endregion

        #region Méthodes publiques
        /// <summary>
        /// Permet l'obtention des périodes d'engagement et absences du professionnel de la santé
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns>Liste des engagements et absences d'avis></returns>
        public ObtenirVuePeriodeEngagementSorti ObtenirPeriodeEngagementsAbsenceProfessionnel(ObtenirVuePeriodeEngagementEntre intrant)
        {
            ObtenirVuePeriodeEngagementSorti extrant = new ObtenirVuePeriodeEngagementSorti();
            ObtenirVuePeriodesEngagementsEntre intrantPlanRegionMedical = Utilitaire.Mappeur.Mapper(intrant);
            ObtenirVuePeriodesEngagementsSorti extrantPlanRegionMedical = _clientPlanRegionnalMedical.ObtenirVuePeriodesEngagements(intrantPlanRegionMedical);
            extrant = Utilitaire.Mappeur.Mapper(extrantPlanRegionMedical);

            return extrant;
        }
        #endregion
    }
}