using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal;
using RAMQ.PRE.PRE_Entites_cpo.DemandeReevaluation.Parametre;
using System;
using ParametrePlanRegnMdcal = RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.DemandeReevaluation
{
    /// <summary> 
    ///  Classe des demandes de réévaluation
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Mars 2018
    /// </remarks>
    public class DemandeReevaluation : IDemandeReevaluation
    {
        #region Attribut privé

        private readonly IPlanRegnMdcal _clientPlanRegnMdcal;

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public DemandeReevaluation(IPlanRegnMdcal planRegnMdcal)
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
        /// Permet d'obtenir une liste des demandes de réévaluation
        /// </summary>
        /// <Parametre name="intrant">Paramètre d'entré</Parametre>
        /// <returns>Une liste des avis de conformité avec leurs statuts</returns>
        /// <remarks></remarks>
        public ObtenirDemandeReevaluationSorti ObtenirDemandeReevaluation(ObtenirDemandeReevaluationEntre intrant)
        {
            ObtenirDemandeReevaluationSorti extrant = new ObtenirDemandeReevaluationSorti();

            ParametrePlanRegnMdcal.ObtenirListeDemReevaEntre intrantPlanRegnMdcal = Utilitaire.Mappeur.Mapper(intrant);
            ParametrePlanRegnMdcal.ObtenirListeDemReevaSorti extrantPlanRegnMdcal = _clientPlanRegnMdcal.ObtenirListeDemReeva(intrantPlanRegnMdcal);
            extrant = Utilitaire.Mappeur.Mapper(extrantPlanRegnMdcal);
            PRE_OutilComun_cpo.MessageTraitement.ValiderMessageTraitement(extrant);

            return extrant;
        }

        /// <summary>
        /// Permet de modifier une demande de réévaluation
        /// </summary>
        /// <Parametre name="intrant">Paramètre d'entré</Parametre>
        /// <returns></returns>
        /// <remarks></remarks>
        public ModifierDemandeReevaluationSorti ModifierDemandeReevaluation(ModifierDemandeReevaluationEntre intrant)
        {
            ModifierDemandeReevaluationSorti extrant = new ModifierDemandeReevaluationSorti();

            ParametrePlanRegnMdcal.ModifierDemReevaPREMEntre intrantPlanRegnMdcal = Utilitaire.Mappeur.Mapper(intrant);
            ParametrePlanRegnMdcal.ModifierDemReevaPREMSorti extrantPlanRegnMdcal = _clientPlanRegnMdcal.ModifierDemReevaPREM(intrantPlanRegnMdcal);
            extrant = Utilitaire.Mappeur.Mapper(extrantPlanRegnMdcal);
            PRE_OutilComun_cpo.MessageTraitement.ValiderMessageTraitement(extrant);

            return extrant;
        }


        /// <summary>
        /// Permet d'annuler une demande de réévaluation
        /// </summary>
        /// <Parametre name="intrant">Paramètre d'entré</Parametre>
        /// <returns></returns>
        public AnnulerDemandeReevaluationSorti AnnulerDemandeReevaluation(AnnulerDemandeReevaluationEntre intrant)
        {
            AnnulerDemandeReevaluationSorti extrant = new AnnulerDemandeReevaluationSorti();

            ParametrePlanRegnMdcal.AnnulerDemandeReevaPREMQEntre intrantPlanRegnMdcal = Utilitaire.Mappeur.Mapper(intrant);
            ParametrePlanRegnMdcal.AnnulerDemandeReevaPREMQSorti extrantPlanRegnMdcal = _clientPlanRegnMdcal.AnnulerDemReevaPREMQ(intrantPlanRegnMdcal);
            extrant = Utilitaire.Mappeur.Mapper(extrantPlanRegnMdcal);
            PRE_OutilComun_cpo.MessageTraitement.ValiderMessageTraitement(extrant);

            return extrant;
        }

        /// <summary>
        /// Permet de créer une demande de réévaluation
        /// </summary>
        /// <Parametre name="intrant">Paramètre d'entré</Parametre>
        /// <returns></returns>
        public CreerDemandeReevaluationSorti CreerDemandeReevaluation(CreerDemandeReevaluationEntre intrant)
        {
            CreerDemandeReevaluationSorti extrant = new CreerDemandeReevaluationSorti();

            ParametrePlanRegnMdcal.CreerDemReevaPREMEntre intrantPlanRegnMdcal = Utilitaire.Mappeur.Mapper(intrant);
            ParametrePlanRegnMdcal.CreerDemReevaPREMSorti extrantPlanRegnMdcal = _clientPlanRegnMdcal.CreerDemReevaPREM(intrantPlanRegnMdcal);
            extrant = Utilitaire.Mappeur.Mapper(extrantPlanRegnMdcal);
            PRE_OutilComun_cpo.MessageTraitement.ValiderMessageTraitement(extrant);

            return extrant;
        }

        #endregion
    }
}