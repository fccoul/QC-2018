using System;
using RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre;
using AccesDonne = RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.Derogation
{
    /// <summary> 
    ///  Classe des dérogations
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    public class Derogation : IDerogation
    {
        #region Attributs privées

        private readonly AccesDonne.IPlanRegnMdcal _clientPlanRegionnalMedical;

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur par défaut
        /// </summary>

        public Derogation(AccesDonne.IPlanRegnMdcal planRegionnalMedical)
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
        /// Permet d'obtenir les dérogations d'un professionnel de la santé
        /// </summary>
        /// <param name="intrant">Paramètres d'entrées</param>
        /// <returns>Liste des dérogations d'un professionnel de la santé</returns>
        /// <remarks></remarks>
        public ObtenirDerogationsProfessionnelSanteSorti ObtenirDerogationProfessionnel(ObtenirDerogationsProfessionnelSanteEntre intrant)
        {
            AccesDonne.Parametre.ObtenirDerogationsProfessionnelSanteEntre intrantPlanRegionMedical = new AccesDonne.Parametre.ObtenirDerogationsProfessionnelSanteEntre();
            AccesDonne.Parametre.ObtenirDerogationsProfessionnelSanteSorti extrantPlanRegionMedical = null;
            ObtenirDerogationsProfessionnelSanteSorti extrant = new ObtenirDerogationsProfessionnelSanteSorti();


            Utilitaire.Mappeur.Mapper(intrant, ref intrantPlanRegionMedical);

            extrantPlanRegionMedical = _clientPlanRegionnalMedical.ObtenirDerogationsProfessionnelSante(intrantPlanRegionMedical);

            Utilitaire.Mappeur.Mapper(extrantPlanRegionMedical, ref extrant);

            return extrant;
        }

        /// <summary>
        /// Permet de modifier une dérogation d'un professionnel de la santé
        /// </summary>
        /// <param name="intrant">Information de la dérogation</param>
        /// <returns>Le nouveau numéro de séquence de la dérogation</returns>
        /// <remarks></remarks>
        public ModifierDerogationSorti ModifierDerogation(ModifierDerogationEntre intrant)
        {
            AccesDonne.Parametre.ModifierDerogationEntre intrantPlanRegionMedical = new AccesDonne.Parametre.ModifierDerogationEntre();
            AccesDonne.Parametre.ModifierDerogationSorti extrantPlanRegionMedical = null;
            ModifierDerogationSorti extrant = new ModifierDerogationSorti();


            Utilitaire.Mappeur.Mapper(intrant, ref intrantPlanRegionMedical);

            extrantPlanRegionMedical = _clientPlanRegionnalMedical.ModifierDerogation(intrantPlanRegionMedical);

            Utilitaire.Mappeur.Mapper(extrantPlanRegionMedical, ref extrant);

            PRE_OutilComun_cpo.MessageTraitement.ValiderMessageTraitement(extrant);

            return extrant;
        }

        /// <summary>
        /// Permet de créer une dérogation d'un professionnel de la santé.
        /// </summary>
        /// <param name="intrant">Paramètres d'entrées.</param>
        /// <returns>Liste des dérogations d'un professionnel de la santé.</returns>
        /// <remarks></remarks>
        public CreerDerogationSorti CreerDerogation(CreerDerogationEntre intrant)
        {
            AccesDonne.Parametre.CreerDerogationEntre intrantPlanRegionMedical = Utilitaire.Mappeur.Mapper(intrant);

            AccesDonne.Parametre.CreerDerogationSorti extrantPlanRegionMedical = _clientPlanRegionnalMedical.CreerDerogation(intrantPlanRegionMedical);

            CreerDerogationSorti extrant = Utilitaire.Mappeur.Mapper(extrantPlanRegionMedical);

            PRE_OutilComun_cpo.MessageTraitement.ValiderMessageTraitement(extrant);

            return extrant;
        }

        #endregion
    }
}