using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Entites;
using RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Entite;
using RAMQ.PRE.PRE_Entites_cpo.EngagementPratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Entite;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using System;
using System.Collections.Generic;
using Entite = RAMQ.PRE.PRE_Entites_cpo.EngagementPratique.Entite;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Professionnel.Interface
{
    /// <summary> 
    ///  Interface des engagements de pratiques
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Décembre 2016
    /// </remarks>
    public interface IEngagementPratique
    {

        /// <summary>
        /// Permet d'obtenir les engagements de pratique du professionnel
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Les engagement de pratique d'un professionnel</returns>
        ObtenirEngagementPratiqueSorti ObtenirLesEngagementsPratiquesProfessionnel(ObtenirEngagementPratiqueEntre intrant);

        /// <summary>
        /// Permet d'obtenir les période de pratique d'un professionnel
        /// </summary>
        /// <param name="numeroSequenceDispensateur">Numéro de séquence du dispensateur</param>
        /// <returns>Période de pratique</returns>
        DateTime? ObtenirPeriodePratiqueProfessionnel(long numeroSequenceDispensateur);

        /// <summary>
        /// Permet d'obtenir les dérogations
        /// </summary>
        /// <param name="numeroSequenceDispensateur">Numéro de séquence du dispensateur</param>
        /// <returns>Liste de dérogation</returns>
        List<Entite.EngagementPratique> ObtenirDerogations(long numeroSequenceDispensateur);

        /// <summary>
        /// Permet d'obtenir les avis de conformités
        /// </summary>
        /// <param name="numeroSequenceDispensateur">Numéro de séquence du dispensateur</param>
        /// <returns>Liste des avis de conformités</returns>
        List<Entite.EngagementPratique> ObtenirLesAvisConformite(long numeroSequenceDispensateur);

        /// <summary>
        /// Permet d'obtenir les autorisations
        /// </summary>
        /// <param name="numeroSequenceDispensateur">Numéro de séquence du dispensateur</param>
        /// <returns>Liste des autorisations</returns>
        List<Entite.EngagementPratique> ObtenirAutorisations(long numeroSequenceDispensateur);


        /// <summary>
        /// Permet l'obtention des périodes d'engagement et absences du professionnel de la santé
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns>Liste des engagements et absences d'avis></returns>
        ObtenirVuePeriodeEngagementSorti ObtenirPeriodeEngagementsAbsenceProfessionnel(ObtenirVuePeriodeEngagementEntre intrant);

        /// <summary>
        /// Obtenir les informations sur la relation dispensateur individu
        /// </summary>
        /// <param name="intrant">Les critères de recherche</param>
        /// <returns>Une liste avec les informations des professionnels</returns>
        /// <remarks></remarks>
        ObtenirDispensateurIndividuSorti ObtenirInformationProfessionnel(ObtenirDispensateurIndividuEntre intrant);

        /// <summary>
        /// Permet d'obtenir la date de debut de l'historique d'engagement du medecin omnipraticien en cas d'absence
        /// </summary>
        /// <param name="numseqDispensateur"></param>
        /// <returns></returns>
        DateTime ObtenirDateDebutHistoriqueEngagementAbs(long numseqDispensateur);

        /// <summary>
        /// Permet d'obtenir les periodes de non participation du medecin omnipraticien
        /// </summary>
        /// <param name="numeroDispensateur"></param>
        /// <param name="numeroClasseDispensateur"></param>
        /// <param name="datePrevue"></param>
        /// <returns></returns>
        List<AdmissibiliteFacturer> ObtenirlesPeriodesNonParticipation(long numeroDispensateur, int numeroClasseDispensateur, DateTime datePrevue);


        /// <summary>
        /// permet de formatter la liste des engagements fusionnés avec les periodes absence et Non participation
        /// </summary>
        /// <param name="intrant"></param>
        /// <param name="engagementPratiqueFusionnes"></param>
        /// <returns></returns>
        List<Entite.EngagementPratique> ObtenirEngagementPratiquesFormate(ObtenirEngagementPratiqueEntre intrant, List<Entite.EngagementPratique> engagementPratiqueFusionnes);


        /// <summary>
        /// ajout ou suppression de periodes d'absence d'avis dans l'historique
        /// </summary>
        /// <param name="periodesAbs"></param>
        /// <param name="periodesNPAR"></param>
        /// <returns></returns>
        ChevauchementPeriode ConstruireChevauchementPeriodeAbsEtNonParticipation(List<Entite.EngagementPratique> periodesAbs, List<AdmissibiliteFacturer> periodesNPAR);

        /// <summary>
        /// permet d'obtenir la date de debut dans l'historique d'un avis en particulier
        /// </summary>
        /// <param name="intrantVue"></param>
        /// <param name="statutavis"></param>
        /// <returns></returns>
        bool ObtenirDateDebuthistoriqueDansAvis(ObtenirVuePeriodeEngagementSorti intrantVue, StatutAvisConformite statutavis);

    }
         
}