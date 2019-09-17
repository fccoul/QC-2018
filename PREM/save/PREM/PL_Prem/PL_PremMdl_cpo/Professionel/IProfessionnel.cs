using RAMQ.PRE.PL_PremMdl_cpo.svcCnsulProfiPremqProf;
using RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.EngagementPratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.PeriodePratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Pratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Entite;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Recherche.Entite;
using System.Collections.Generic;

namespace RAMQ.PRE.PL_PremMdl_cpo.Professionnel
{
    /// <summary> 
    ///  Interface permettant d'obtenir les informations des professionnels
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Septembre 2016
    /// </remarks>
    public interface IProfessionnel
    {
        /// <summary>
        /// Obtenir les informations sur la relation dispensateur individu
        /// </summary>
        /// <param name="intrant">Les critères de recherche</param>
        /// <returns>Une liste avec les informations des professionnels</returns>
        /// <remarks></remarks>
        ObtenirDispensateurIndividuSorti ObtenirInformationProfessionnel(ObtenirDispensateurIndividuEntre intrant);

        /// <summary>
        /// Obtenir la liste des professionnels de classe x
        /// </summary>
        /// <param name="classe">Les classes de professionnels à retourner</param>
        /// <param name="filtreSpecialPourCreationAvis">Indicateur pour l'utilisation du filtre spécial</param>
        /// <param name="forcerMiseAJour">Permet de forcer la mise à jour de la cache</param>
        /// <returns>Une liste des professionnels</returns>
        /// <remarks></remarks>
        Professionnels ObtenirProfessionnelParClasse(IEnumerable<int> classe, bool filtreSpecialPourCreationAvis = false, bool forcerMiseAJour = false);

        /// <summary>
        /// Obtient une liste de numéro de pratique filtré par le terme entré et la limite de pagination obtenu
        /// </summary>
        /// <param name="classe">Les classes de professionnels à filtrer</param>
        /// <param name="filtre">Les critères pour le filtre</param>
        /// <param name="filtreSpecialPourCreationAvis">Indicateur pour l'utilisation du filtre spécial</param>
        /// <returns>La liste filtrer des numéros de pratique</returns>
        /// <remarks></remarks>
        Resultat ObtenirNumerosPratiqueFiltre(IEnumerable<int> classe, Critere filtre, bool filtreSpecialPourCreationAvis = false);

        /// <summary>
        /// Permet d'obtenir les périodes de pratique des professionnels
        /// </summary>
        /// <param name="intrant">Paramètre d'entrée</param>
        /// <returns>Périodes de pratique</returns>
        /// <remarks></remarks>
        ObtenirPeriodePratiqueProfessionnelSorti ObtenirPeriodePratiqueProfessionnel(ObtenirPeriodePratiqueProfessionnelEntre intrant);

        /// <summary>
        /// Permet d'obtenir les information sur l'admissibilité du professionnel à facturer
        /// </summary>
        /// <param name="intrant">Information du professionnel</param>
        /// <returns>Les information sur l'admissibilité du professionnel à facturer</returns>
        /// <remarks></remarks>
        VerifierAdmissibiliteProfessionnelFacturerSorti VerifierAdmissibiliteProfessionnel(VerifierAdmissibiliteProfessionnelFacturerEntre intrant);

        /// <summary>
        /// Permet d'obtenir les dérogations d'un professionnel de la santé
        /// </summary>
        /// <param name="intrant">Paramètre d'entrée</param>
        /// <returns>Liste dérogations d'un professionnel de la santé</returns>
        /// <remarks></remarks>
        ObtenirDerogationsProfessionnelSanteSorti ObtenirDerogationProfessionnelSante(ObtenirDerogationsProfessionnelSanteEntre intrant);

        /// <summary>
        /// Permet de modifier une dérogation d'un professionnel de la santé
        /// </summary>
        /// <param name="intrant">Paramètre d'entrée</param>
        /// <returns>Nouveau numéro séquentiel de la dérogation</returns>
        /// <remarks></remarks>
        ModifierDerogationSorti ModifierDerogation(ModifierDerogationEntre intrant);

        /// <summary>
        /// Permet d'obtenir les engagements de pratique d'un professionnel
        /// </summary>
        /// <param name="intrant">Paramètres d'entré</param>
        /// <returns>Engagements de pratiques d'un professionnel</returns>
        ObtenirEngagementPratiqueSorti ObtenirEngagementPratiques(ObtenirEngagementPratiqueEntre intrant);

        /// <summary>
        /// Valider le professionnel
        /// </summary>
        /// <param name="intrant">Information du professionnel</param>
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