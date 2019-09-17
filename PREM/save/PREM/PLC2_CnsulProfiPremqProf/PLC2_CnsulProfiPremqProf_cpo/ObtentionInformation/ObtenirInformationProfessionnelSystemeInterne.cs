using RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Autorisation.Parametre;
using AccesDonne = RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal;
using System;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.ObtentionInformation
{
    /// <summary> 
    ///  Classe d'obtention des informations des professionnels
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Octobre 2016
    /// </remarks>
    public class ObtenirInformationProfessionnelSystemeInterne : IObtenirInformationProfessionnelSystemeInterne
    {

        #region Attributs privées


        private readonly AccesDonne.IPlanRegnMdcal _clientPlanRegionnalMedical;
        #endregion


        #region Constructeur

        /// <summary>
        /// Constructeur par défaut
        /// </summary>

        public ObtenirInformationProfessionnelSystemeInterne(AccesDonne.IPlanRegnMdcal planRegionnalMedical)
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
        /// Permet d'obtenir les autorisations d'un professionnel de la santé
        /// </summary>
        /// <param name="intrant">Paramètres d'entré</param>
        /// <returns>Une liste d'autorisations d'un professionnel de la santé</returns>
        public ObtenirLesAutorisationsProfessionnelSorti ObtenirAutorisationProfessionnelSante(ObtenirLesAutorisationsProfessionnelEntre intrant)
        {

            AccesDonne.Parametre.ObtenirAutorisationsEntre intrantPlanRegionMedical = new AccesDonne.Parametre.ObtenirAutorisationsEntre();
            AccesDonne.Parametre.ObtenirAutorisationsSorti extrantPlanRegionMedical = null;
            ObtenirLesAutorisationsProfessionnelSorti extrant = new ObtenirLesAutorisationsProfessionnelSorti();

            Utilitaire.Mappeur.Mapper(intrant, ref intrantPlanRegionMedical);

            extrantPlanRegionMedical = _clientPlanRegionnalMedical.ObtenirAutorisationsProfessionnelSante(intrantPlanRegionMedical);

            Utilitaire.Mappeur.Mapper(extrantPlanRegionMedical, ref extrant);

            return extrant;

        }



        #endregion

    }
}