using System;
using RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal;
using ParametrePlanRegnMdcal = RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.AvisConformite
{
    /// <summary> 
    ///  Classe des avis de conformité
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    public class AvisConformite : IAvisConformite
    {
        #region Attribut privé

        private readonly IPlanRegnMdcal _clientPlanRegnMdcal;

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public AvisConformite(IPlanRegnMdcal planRegnMdcal)
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
        /// Permet d'obtenir une liste des avis de conformité et de leurs statuts
        /// </summary>
        /// <Parametre name="intrant">Paramètre d'entré</Parametre>
        /// <returns>Une liste des avis de conformité avec leurs statuts</returns>
        /// <remarks></remarks>
        public ObtenirLesAvisConformiteSorti ObtenirLesAvisConformite(ObtenirLesAvisConformiteEntre intrant)
        {
            ParametrePlanRegnMdcal.ObtenirLesAvisConformiteEntre intrantPlanRegnMdcal = new ParametrePlanRegnMdcal.ObtenirLesAvisConformiteEntre();
            ParametrePlanRegnMdcal.ObtenirLesAvisConformiteSorti extrantPlanRegnMdcal = new ParametrePlanRegnMdcal.ObtenirLesAvisConformiteSorti();
            ObtenirLesAvisConformiteSorti extrant = new ObtenirLesAvisConformiteSorti();

            try
            {
                Utilitaire.Mappeur.Mapper(intrant, ref intrantPlanRegnMdcal);

                extrantPlanRegnMdcal = _clientPlanRegnMdcal.ObtenirLesAvisConformite(intrantPlanRegnMdcal);

                Utilitaire.Mappeur.Mapper(extrantPlanRegnMdcal, ref extrant);

            }
            catch (Exception)
            {
                throw;
            }

            return extrant;
        }

        /// <summary>
        /// Permet de modifier la période d'un avis de conformité et son statut
        /// </summary>
        /// <Parametre name="intrant">Paramètre d'entré</Parametre>
        /// <returns>Retourne les informations de modification de l'avis de conformité</returns>
        /// <remarks></remarks>
        public ModifierPeriodeAvisSorti ModifierPeriodeAvis(ModifierPeriodeAvisEntre intrant)
        {
            ModifierPeriodeAvisSorti extrant = new ModifierPeriodeAvisSorti();

            try
            {
                ParametrePlanRegnMdcal.ModifierPeriodeAvisEntre intrantPlanRegnMdcal = Utilitaire.Mappeur.Mapper(intrant);

                ParametrePlanRegnMdcal.ModifierPeriodeAvisSorti extrantPlanRegnMdcal = _clientPlanRegnMdcal.ModifierPeriodeAvis(intrantPlanRegnMdcal);

                extrant = Utilitaire.Mappeur.Mapper(extrantPlanRegnMdcal);

            }
            catch (Exception)
            {
                throw;
            }

            return extrant;
        }


        /// <summary>
        /// Permet de créer un statut de l'engagement
        /// </summary>
        /// <Parametre name="intrant">Paramètre d'entré</Parametre>
        /// <returns>Retourne les informations de la création du statut de l'engagement</returns>
        public CreerStatutAvisConformiteSorti CreerStatutAvisConformite(CreerStatutAvisConformiteEntre intrant)
        {
            ParametrePlanRegnMdcal.CreerStatutAvisConformiteEntre intrantPlanRegnMdcal = new ParametrePlanRegnMdcal.CreerStatutAvisConformiteEntre();
            ParametrePlanRegnMdcal.CreerStatutAvisConformiteSorti extrantPlanRegnMdcal = new ParametrePlanRegnMdcal.CreerStatutAvisConformiteSorti();
            CreerStatutAvisConformiteSorti extrant = new CreerStatutAvisConformiteSorti();

            try
            {
                Utilitaire.Mappeur.Mapper(intrant, ref intrantPlanRegnMdcal);

                extrantPlanRegnMdcal = _clientPlanRegnMdcal.CreerStatutAvisConformite(intrantPlanRegnMdcal);

                Utilitaire.Mappeur.Mapper(extrantPlanRegnMdcal, ref extrant);

            }
            catch (Exception)
            {
                throw;
            }

            return extrant;
        }

        /// <summary>
        /// Permet de modifier le statut d'un avis de conformité
        /// </summary>
        /// <Parametre name="intrant">Paramètre d'entré</Parametre>
        /// <returns>Retourne les informations de modification du statut de l'avis de conformité</returns>
        public ModifierStatutEngagementSorti ModifierStatutAvisConformite(ModifierStatutEngagementEntre intrant)
        {
            ParametrePlanRegnMdcal.ModifierStatutEngagementEntre intrantPlanRegnMdcal = new ParametrePlanRegnMdcal.ModifierStatutEngagementEntre();
            ParametrePlanRegnMdcal.ModifierStatutEngagementSorti extrantPlanRegnMdcal = new ParametrePlanRegnMdcal.ModifierStatutEngagementSorti();
            ModifierStatutEngagementSorti extrant = new ModifierStatutEngagementSorti();


            try
            {
                Utilitaire.Mappeur.Mapper(intrant, ref intrantPlanRegnMdcal);

                extrantPlanRegnMdcal = _clientPlanRegnMdcal.ModifierStatutEngagement(intrantPlanRegnMdcal);

                Utilitaire.Mappeur.Mapper(extrantPlanRegnMdcal, ref extrant);

            }
            catch (Exception)
            {
                throw;
            }

            return extrant;
        }




        /// <summary>
        /// Permet de modifier la raison de fermeture du statut de l'engagement
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        public ModifierRaisFermStatutEngagSorti ModifierRaisFermStatutEngag(ModifierRaisFermStatutEngagEntre intrant)
        {
            ModifierRaisFermStatutEngagSorti extrant = new ModifierRaisFermStatutEngagSorti();

            try
            {
                ParametrePlanRegnMdcal.ModifierRaisFermStatutEngagEntre intrantPlanRegnMdcal = Utilitaire.Mappeur.Mapper(intrant);

                ParametrePlanRegnMdcal.ModifierRaisFermStatutEngagSorti extrantPlanRegnMdcal = _clientPlanRegnMdcal.ModifierRaisFermStatutEngag(intrantPlanRegnMdcal);

                extrant = Utilitaire.Mappeur.Mapper(extrantPlanRegnMdcal);

            }
            catch (Exception)
            {
                throw;
            }

            return extrant;
        }


        /// <summary>
        /// Permet de modifier un avis de conformite
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        public ModifierAvisConfSorti ModifierAvisConformite(ModifierAvisConfEntre intrant)
        {
            ModifierAvisConfSorti extrant = new ModifierAvisConfSorti();

            try
            {
                ParametrePlanRegnMdcal.ModifierAvisConformiteEntre intrantPlanRegnMdcal = Utilitaire.Mappeur.Mapper(intrant);

                ParametrePlanRegnMdcal.ModifierAvisConformiteSorti extrantPlanRegnMdcal = _clientPlanRegnMdcal.ModifierAvisConformite(intrantPlanRegnMdcal);

                extrant = Utilitaire.Mappeur.Mapper(extrantPlanRegnMdcal);

            }
            catch (Exception)
            {
                throw;
            }

            return extrant;
        }


        /// <summary>
        ///  Permet la modification des avis de conformités et de ses statuts
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        public ModifierAvisConformiteStatutSorti ModifierAvisConformiteStatut(ModifierAvisConformiteStatutEntre intrant)
        {
            ModifierAvisConformiteStatutSorti extrant = new ModifierAvisConformiteStatutSorti();

            try
            {
                ParametrePlanRegnMdcal.ModifierAvisConformiteStatutEntre intrantPlanRegnMdcal = Utilitaire.Mappeur.Mapper(intrant);

                ParametrePlanRegnMdcal.ModifierAvisConformiteStatutSorti extrantPlanRegnMdcal = _clientPlanRegnMdcal.ModifierAvisConformiteStatut(intrantPlanRegnMdcal);

                extrant = Utilitaire.Mappeur.Mapper(extrantPlanRegnMdcal);

            }
            catch (Exception)
            {
                throw;
            }

            return extrant;
        }


        /// <summary>
        ///  Permet la création des avis de conformités
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        public CreerAvisConformiteSorti CreerAvisConformite(CreerAvisConformiteEntre intrant)
        {
            CreerAvisConformiteSorti extrant = new CreerAvisConformiteSorti();

            try
            {
                ParametrePlanRegnMdcal.CreerAvisConformiteEntre intrantPlanRegnMdcal = Utilitaire.Mappeur.Mapper(intrant);

                ParametrePlanRegnMdcal.CreerAvisConformiteSorti extrantPlanRegnMdcal = _clientPlanRegnMdcal.CreerAvisConformite(intrantPlanRegnMdcal);

                extrant = Utilitaire.Mappeur.Mapper(extrantPlanRegnMdcal);

            }
            catch (Exception)
            {
                throw;
            }

            return extrant;
        }

        /// <summary>
        /// Permet de faire l'obtention de la liste des statuts engagement pratique RSS 
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste des statuts engagement pratique RSS</returns>
        public ObtenirStatutsEngagementPratiqueRSSSorti ObtenirStatutsEngagementPratiqueRSS(ObtenirStatutsEngagementPratiqueRSSEntre intrant)
        {
            ObtenirStatutsEngagementPratiqueRSSSorti extrant = new ObtenirStatutsEngagementPratiqueRSSSorti();

            ParametrePlanRegnMdcal.ObtenirStatutsEngagementPratiqueRSSEntre intrantPlanRegnMdcal = Utilitaire.Mappeur.Mapper(intrant);

            ParametrePlanRegnMdcal.ObtenirStatutsEngagementPratiqueRSSSorti extrantPlanRegnMdcal = _clientPlanRegnMdcal.ObtenirStatutsEngagementPratiqueRSS(intrantPlanRegnMdcal);

            extrant = Utilitaire.Mappeur.Mapper(extrantPlanRegnMdcal);

            return extrant;
        }
        #endregion
    }
}