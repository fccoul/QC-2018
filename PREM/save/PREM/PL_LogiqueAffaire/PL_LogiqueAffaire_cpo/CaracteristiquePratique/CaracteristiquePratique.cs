using System;
using RAMQ.PRE.PRE_Entites_cpo.CaracteristiquePratique.Parametre;
using AccesDonne = RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.CaracteristiquePratique
{
    /// <summary>
    /// CaracteristiquePratique
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class CaracteristiquePratique : ICaracteristiquePratique
    {
        #region Attributs privées

        private readonly AccesDonne.IPlanRegnMdcal _clientPlanRegionnalMedical;

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur par défaut
        /// </summary>

        public CaracteristiquePratique(AccesDonne.IPlanRegnMdcal planRegionnalMedical)
        {

            if (planRegionnalMedical == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(planRegionnalMedical)} ne peut être null.");
            }

            _clientPlanRegionnalMedical = planRegionnalMedical;

        }

        #endregion

        #region Méthodes publiques

        /// <summary>
        /// Permet d'obtenir les caractéristiques pratique RSS
        /// </summary>
        /// <param name="intrant">Paramètres d'entrées</param>
        /// <returns>Liste des caractéristiques pratique</returns>
        /// <remarks></remarks>
        public ObtenirCaracteristiquePratiqueRssSorti ObtenirCaracteristiquesPratique(ObtenirCaracteristiquePratiqueRssEntre intrant)
        {
            AccesDonne.Parametre.ObtenirCaracteristiquePratiqueRssEntre intrantPlanRegionMedical = new AccesDonne.Parametre.ObtenirCaracteristiquePratiqueRssEntre();
            AccesDonne.Parametre.ObtenirCaracteristiquePratiqueRssSorti extrantPlanRegionMedical = null;

            ObtenirCaracteristiquePratiqueRssSorti extrant = new ObtenirCaracteristiquePratiqueRssSorti();

            Utilitaire.Mappeur.Mapper(intrant, ref intrantPlanRegionMedical);

            extrantPlanRegionMedical = _clientPlanRegionnalMedical.ObtenirCaracteristiquePratiqueRss(intrantPlanRegionMedical);

            Utilitaire.Mappeur.Mapper(extrantPlanRegionMedical, ref extrant);

            return extrant;
        }

        #endregion
    }
}