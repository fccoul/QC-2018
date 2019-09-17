using RAMQ.PRE.PL_LogiqueAffaire_cpo.Admissibilite;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Derogation;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Parametres;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Professionnel.Interface;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Validations;
using RAMQ.PRE.PRE_Entites_cpo.EngagementPratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.PeriodePratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Pratique.Parametre;
using System;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo
{
    /// <summary> 
    ///  Consultation du profil PREM des professionnels
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : 2016-09-16
    /// </remarks>
    public class CnsulProfiPremqProf : ICnsulProfiPremqProf
    {

        #region Attributs

        private readonly IEngagementPratique _engagementPratique;
        private readonly IPeriodePratique _periodePratique;
        private readonly IDerogation _derogation;
        private readonly IAdmissibilite _admissibilite;
        private readonly IValidations _validations;
        private readonly IJourneeFacturation _journeeFacturation;
        private readonly IReductionRemuneration _reductionRemuneration;

        #endregion

        #region Constructeur


        /// <summary>
        /// Constructeur pour l'obtention des engagement de pratique
        /// </summary>
        /// <param name="engagementPratique"></param>
        /// <param name="periodePratique"></param>
        /// <param name="derogation"></param>
        /// <param name="admissibilite"></param>
        /// <param name="validations"></param>
        /// <param name="journeeFacturation"></param>
        /// <param name="reductionRemuneration"></param>
        public CnsulProfiPremqProf(IEngagementPratique engagementPratique, 
                                   IPeriodePratique periodePratique, 
                                   IDerogation derogation,
                                   IAdmissibilite admissibilite,
                                   IValidations validations,
                                   IJourneeFacturation journeeFacturation,
                                   IReductionRemuneration reductionRemuneration)
        {

            if (engagementPratique == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(engagementPratique)} ne peut être null.");
            }

            if (periodePratique == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(periodePratique)} ne peut être null.");
            }

            if (derogation == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(derogation)} ne peut être null.");
            }

            if (admissibilite == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(admissibilite)} ne peut être null.");
            }

            if (journeeFacturation == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(journeeFacturation)} ne peut être null.");
            }

            if (reductionRemuneration == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(reductionRemuneration)} ne peut être null.");
            }
            _engagementPratique = engagementPratique;
            _periodePratique = periodePratique;
            _derogation = derogation;
            _admissibilite = admissibilite;
            _validations = validations;
            _journeeFacturation = journeeFacturation;
            _reductionRemuneration = reductionRemuneration;

        }

        #endregion

        #region Méthodes Publiques

        /// <summary>
        /// Permet d'obtenir les engagements de pratique du professionnel
        /// </summary>
        /// <param name="intrant">Paramètres d'entrées</param>
        /// <returns>Les engagement de pratique d'un professionnel</returns>
        public ObtenirEngagementPratiqueSorti ObtenirLesEngagementsPratiquesProfessionnel(ObtenirEngagementPratiqueEntre intrant)
        {
            return _engagementPratique.ObtenirLesEngagementsPratiquesProfessionnel(intrant);
        }

        /// <summary>
        /// Permet d'obtenir la période de pratique d'un professionnel
        /// </summary>
        /// <param name="intrant">Paramètres d'entrées</param>
        /// <returns>Les informations de la période de pratique d'un professionnel</returns>
        /// <remarks></remarks>
        public ObtenirPeriodePratiqueProfessionnelSorti ObtenirPeriodePratiqueProfessionnel(ObtenirPeriodePratiqueProfessionnelEntre intrant)
        {
            return _periodePratique.ObtenirPeriodePratiqueProfessionnel(intrant);
        }

        /// <summary>
        /// Permet de valider les informations d'un professionnel de la santé
        /// </summary>
        /// <param name="intrant">Paramètres d'entré</param>
        /// <returns>Liste de messages</returns>
        public ValiderProfessionnelSorti ValiderProfessionnel(ValiderProfessionnelEntre intrant)
        {
            return _validations.ValiderProfessionnel(intrant);
        }

        /// <summary>
        /// Permet de calculer le nombre de journée de facturation
        /// </summary>
        /// <param name="intrant">Paramètres d'entré</param>
        /// <returns>Journées facturés</returns>
        public CalculerNbrJrFactProfsSorti CalculerNombreJourneeFacturation(CalculerNbrJrFactProfsEntre intrant)
        {
            return _journeeFacturation.CalculerNombreJourneeFacturation(intrant);
        }

        /// <summary>
        /// Permet d'obtenir la réduction à la rémunération
        /// </summary>
        /// <param name="intrant">Paramètres d'entré</param>
        /// <returns>Réduction à la rémunération</returns>
        public ReductionRemunerationSorti ObtenirReductionRemuneration(ReductionRemunerationEntre intrant)
        {
            return _reductionRemuneration.ObtenirReductionRemuneration(intrant);
        }

        /// <summary>
        /// Permet d'obtenir le pourcentage maximum
        /// </summary>
        /// <returns>Pourcentage maximum</returns>
        public ObtenirPourcentageMaximumSorti ObtenirPourcentageMaximum()
        {
            return _journeeFacturation.ObtenirPourcentageMaximum();
        }



        #endregion

    }
}
