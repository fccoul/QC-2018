using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Parametres;
using RAMQ.PRE.PRE_Entites_cpo.EngagementPratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.PeriodePratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Pratique.Parametre;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo
{
    /// <summary> 
    ///  Interface de consultation du profil PREM des professionnels
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : 2016-09-16
    /// </remarks>
    public interface ICnsulProfiPremqProf
    {

        /// <summary>
        /// Permet d'obtenir les engagements de pratique du professionnel
        /// </summary>
        /// <param name="intrant">Paramètres d'entrées</param>
        /// <returns>Les engagement de pratique d'un professionnel</returns>
        ObtenirEngagementPratiqueSorti ObtenirLesEngagementsPratiquesProfessionnel(ObtenirEngagementPratiqueEntre intrant);

        /// <summary>
        /// Permet d'obtenir la période de pratique d'un professionnel
        /// </summary>
        /// <param name="intrant">Paramètres d'entrées</param>
        /// <returns>Les informations de la période de pratique d'un professionnel</returns>
        /// <remarks></remarks>
        ObtenirPeriodePratiqueProfessionnelSorti ObtenirPeriodePratiqueProfessionnel(ObtenirPeriodePratiqueProfessionnelEntre intrant);


        /// <summary>
        /// Permet de valider les informations d'un professionnel de la santé
        /// </summary>
        /// <param name="intrant">Paramètres d'entré</param>
        /// <returns>Liste de messages</returns>
        ValiderProfessionnelSorti ValiderProfessionnel(ValiderProfessionnelEntre intrant);

        /// <summary>
        /// Permet de calculer le nombre de journée de facturation
        /// </summary>
        /// <param name="intrant">Paramètres d'entré</param>
        /// <returns>Journées facturés</returns>
        CalculerNbrJrFactProfsSorti CalculerNombreJourneeFacturation(CalculerNbrJrFactProfsEntre intrant);

        /// <summary>
        /// Permet d'obtenir la réduction à la rémunération
        /// </summary>
        /// <param name="intrant">Paramètres d'entré</param>
        /// <returns>Réduction à la rémunération</returns>
        ReductionRemunerationSorti ObtenirReductionRemuneration(ReductionRemunerationEntre intrant);


        /// <summary>
        /// Permet d'obtenir le pourcentage maximum
        /// </summary>
        /// <returns>Pourcentage maximum</returns>
        ObtenirPourcentageMaximumSorti ObtenirPourcentageMaximum();
    }
}