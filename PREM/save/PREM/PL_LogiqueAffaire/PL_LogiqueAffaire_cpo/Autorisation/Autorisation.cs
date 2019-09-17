using RAMQ.PRE.PL_LogiqueAffaire_cpo.Parametres;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Utilitaire;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal;
using RAMQ.PRE.PRE_Entites_cpo.Autorisation.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre;
using System;
using AccesDonneParametre = RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.Autorisation
{
    /// <summary>
    /// Classe regroupant les différentes actions possibles à faire sur une autorisation PREMQ.
    /// </summary>
    /// <remarks>
    /// </remarks>
    public class Autorisation : IAutorisation
    {

        #region Attribut privé

        private readonly IPlanRegnMdcal _planRegnMdcal;

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        public Autorisation(IPlanRegnMdcal planRegnMdcal)
        {
            if (planRegnMdcal == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(planRegnMdcal)} ne peut être null.");
            }

            _planRegnMdcal = planRegnMdcal;
        }

        #endregion

        #region Public
       
        /// <summary>
        /// Fonction permettant d'obtenir une liste d'autorisation.
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Retourne les informations de l'obtention d'autorisation</returns>
        public ObtenirLesAutorisationsProfessionnelSorti ObtenirAutorisationPREMQ(ObtenirLesAutorisationsProfessionnelEntre intrant)
        {
            AccesDonneParametre.ObtenirAutorisationsEntre intrantProlongationAutorPREMQ = new AccesDonneParametre.ObtenirAutorisationsEntre();
            AccesDonneParametre.ObtenirAutorisationsSorti extrantProlongationAutorPREMQ = new AccesDonneParametre.ObtenirAutorisationsSorti();

            ObtenirLesAutorisationsProfessionnelSorti extrantProlongationAutorisationPREMQ = new ObtenirLesAutorisationsProfessionnelSorti();

            try
            {
                intrantProlongationAutorPREMQ = Mappeur.Mapper(intrant);
                extrantProlongationAutorPREMQ = _planRegnMdcal.ObtenirAutorisationsPREMQ(intrantProlongationAutorPREMQ);
                extrantProlongationAutorisationPREMQ = Mappeur.Mapper(extrantProlongationAutorPREMQ);
            }
            catch (Exception)
            {

                throw;
            }

            return extrantProlongationAutorisationPREMQ;
        }


        /// <summary>
        /// Permet de modifier une Autorisation d'un professionnel de la santé.
        /// </summary>
        /// <param name="intrant">Information de l'autorisation.</param>
        /// <returns>Le nouveau numéro de séquence de la dérogation.</returns>
        /// <remarks></remarks>
        public ModifierAutorisationSorti ModifierAutorisation(ModifierAutorisationEntre intrant)
        {
           
            AccesDonneParametre.ModifierAutorisationEntre intrantPlanRegionMedical = new AccesDonneParametre.ModifierAutorisationEntre();
            AccesDonneParametre.ModifierAutorisationSorti extrantPlanRegionMedical = null;
            ModifierAutorisationSorti extrant = new ModifierAutorisationSorti();


            Utilitaire.Mappeur.Mapper(intrant, ref intrantPlanRegionMedical);

            extrantPlanRegionMedical = _planRegnMdcal.ModifierAutorisation(intrantPlanRegionMedical);

            Utilitaire.Mappeur.Mapper(extrantPlanRegionMedical, ref extrant);

            PRE_OutilComun_cpo.MessageTraitement.ValiderMessageTraitement(extrant);

            return extrant;
        }

        #endregion
    }
}