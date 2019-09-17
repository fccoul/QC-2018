#region Importations
using RAMQ.PRE.PL_PremMdl_cpo.svcCnsulProfiPremqProf;
using RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.EngagementPratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.PeriodePratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Pratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Entite;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Recherche.Entite;
using RAMQ.PRE.PRE_OutilComun_cpo;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace RAMQ.PRE.PL_PremMdl_cpo.Professionnel
{
    /// <summary> 
    ///  Référentiel qui permet d'obtenir les informations des professionnels.
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Septembre 2016
    /// <br/>
    ///  Historique des modifications<br/>
    ///  ------------------------------------------------------------------------------<br/>
    ///  Auteur : [Auteur]<br/>
    ///  Date   : [aaaa-mm-jj]<br/>
    ///  Description:<br/>
    /// <br/>
    /// </remarks>
    public class ProfessionnelReferentiel : IProfessionnel
    {
        /// <summary>
        /// Obtenir les informations sur la relation dispensateur individu
        /// </summary>
        /// <param name="intrant">Les critères de recherche</param>
        /// <returns>Une liste avec les informations des professionnels</returns>
        /// <remarks></remarks>
        public ObtenirDispensateurIndividuSorti ObtenirInformationProfessionnel(ObtenirDispensateurIndividuEntre intrant)
        {

            return UtilitaireService.AppelerService<svcRechrProf.IServRechrProf, 
                                                    svcRechrProf.ServRechrProfClient, 
                                                    ObtenirDispensateurIndividuSorti>
                                                    (x => x.ObtenirInformationProfessionnel(intrant));
        }

        /// <summary>
        /// Obtenir la liste des professionnels de classe x
        /// </summary>
        /// <param name="classe">Les classes de professionnels à retourner</param>
        /// <param name="filtreSpecialPourCreationAvis">Indicateur pour l'utilisation du filtre spécial</param>
        /// <param name="forcerMiseAJour">Permet de forcer la mise à jour de la cache</param>
        /// <returns>Une liste des professionnels</returns>
        /// <remarks></remarks>
        public Professionnels ObtenirProfessionnelParClasse(IEnumerable<int> classe, bool filtreSpecialPourCreationAvis = false, bool forcerMiseAJour = false)
        {

            return UtilitaireService.AppelerService<svcRechrProf.IServRechrProf, 
                                                    svcRechrProf.ServRechrProfClient, 
                                                    Professionnels>
                                                    (x => x.ObtenirProfessionnelsParClasse(classe.ToList(), filtreSpecialPourCreationAvis, forcerMiseAJour));
        }

        /// <summary>
        /// Obtient une liste de numéro de pratique filtré par le terme entré et la limite de pagination obtenu
        /// </summary>
        /// <param name="classe">Les classes de professionnels à filtrer</param>
        /// <param name="filtre">Les critères pour le filtre</param>
        /// <param name="filtreSpecialPourCreationAvis">Indicateur pour l'utilisation du filtre spécial</param>
        /// <returns>La liste filtrer des numéros de pratique</returns>
        /// <remarks></remarks>
        public Resultat ObtenirNumerosPratiqueFiltre(IEnumerable<int> classe, Critere filtre, bool filtreSpecialPourCreationAvis = false)
        {

            return UtilitaireService.AppelerService<svcRechrProf.IServRechrProf, 
                                                    svcRechrProf.ServRechrProfClient, 
                                                    Resultat>
                                                    (x => x.ObtenirNumerosPratiqueFiltre(classe.ToList(), filtre, filtreSpecialPourCreationAvis));
        }

        /// <summary>
        /// Permet d'obtenir les périodes de pratique des professionnels
        /// </summary>
        /// <param name="intrant">Paramètre d'entrée</param>
        /// <returns>Périodes de pratique</returns>
        /// <remarks></remarks>
        public ObtenirPeriodePratiqueProfessionnelSorti ObtenirPeriodePratiqueProfessionnel(ObtenirPeriodePratiqueProfessionnelEntre intrant)
        {

            return UtilitaireService.AppelerService<svcCnsulProfiPremqProf.IServCnsulProfiPremqProf, 
                                                    svcCnsulProfiPremqProf.ServCnsulProfiPremqProfClient, 
                                                    ObtenirPeriodePratiqueProfessionnelSorti>
                                                    (x => x.ObtenirPeriodePratiqueProfessionnel(intrant));


        }

        /// <summary>
        /// Permet d'obtenir les information sur l'admissibilité du professionnel à facturer
        /// </summary>
        /// <param name="intrant">Information du professionnel</param>
        /// <returns>Les information sur l'admissibilité du professionnel à facturer</returns>
        /// <remarks></remarks>
        public VerifierAdmissibiliteProfessionnelFacturerSorti VerifierAdmissibiliteProfessionnel(VerifierAdmissibiliteProfessionnelFacturerEntre intrant)
        {

            return UtilitaireService.AppelerService<svcCnsulProfiPremqProf.IServCnsulProfiPremqProf, 
                                                    svcCnsulProfiPremqProf.ServCnsulProfiPremqProfClient, 
                                                    VerifierAdmissibiliteProfessionnelFacturerSorti>
                                                    (x => x.VerifierAdmissibiliteProfessionnel(intrant));
        }

        /// <summary>
        /// Permet d'obtenir les dérogations d'un professionnel de la santé
        /// </summary>
        /// <param name="intrant">Paramètre d'entrée</param>
        /// <returns>Liste dérogations d'un professionnel de la santé</returns>
        /// <remarks></remarks>
        public ObtenirDerogationsProfessionnelSanteSorti ObtenirDerogationProfessionnelSante(ObtenirDerogationsProfessionnelSanteEntre intrant)
        {

            return UtilitaireService.AppelerService<svcCnsulProfiPremqProf.IServCnsulProfiPremqProf, 
                                                    svcCnsulProfiPremqProf.ServCnsulProfiPremqProfClient, 
                                                    ObtenirDerogationsProfessionnelSanteSorti>
                                                    (x => x.ObtenirDerogationsProfessionnelSante(intrant));

        }

        /// <summary>
        /// Permet de modifier une dérogation d'un professionnel de la santé
        /// </summary>
        /// <param name="intrant">Paramètre d'entrée</param>
        /// <returns>Nouveau numéro séquentiel de la dérogation</returns>
        /// <remarks></remarks>
        public ModifierDerogationSorti ModifierDerogation(ModifierDerogationEntre intrant)
        {

            return UtilitaireService.AppelerService<svcCnsulProfiPremqProf.IServCnsulProfiPremqProf, 
                                                    svcCnsulProfiPremqProf.ServCnsulProfiPremqProfClient,
                                                    ModifierDerogationSorti>
                                                    (x => x.ModifierDerogation(intrant));

        }

    
        /// <summary>
        /// Permet d'obtenir les engagements de pratique d'un professionnel
        /// </summary>
        /// <param name="intrant">Paramètres d'entré</param>
        /// <returns>Engagements de pratiques d'un professionnel</returns>
        public ObtenirEngagementPratiqueSorti ObtenirEngagementPratiques(ObtenirEngagementPratiqueEntre intrant)
        {

            return UtilitaireService.AppelerService<svcCnsulProfiPremqProf.IServCnsulProfiPremqProf, 
                                                    svcCnsulProfiPremqProf.ServCnsulProfiPremqProfClient, 
                                                    ObtenirEngagementPratiqueSorti>
                                                    (x => x.ObtenirLesEngagementsPratiquesProfessionnel(intrant));

        }


        /// <summary>
        /// Valider le professionnel
        /// </summary>
        /// <param name="intrant">Information du professionnel</param>
        /// <returns>Liste de messages</returns>
        public ValiderProfessionnelSorti ValiderProfessionnel(ValiderProfessionnelEntre intrant)
        {
            return UtilitaireService.AppelerService<svcCnsulProfiPremqProf.IServCnsulProfiPremqProf,
                                                    svcCnsulProfiPremqProf.ServCnsulProfiPremqProfClient,
                                                    ValiderProfessionnelSorti>
                                                    (x => x.ValiderProfessionnel(intrant));
        }

        /// <summary>
        /// Permet de calculer le nombre de journée de facturation
        /// </summary>
        /// <param name="intrant">Paramètres d'entré</param>
        /// <returns>Journées facturés</returns>
        public CalculerNbrJrFactProfsSorti CalculerNombreJourneeFacturation(CalculerNbrJrFactProfsEntre intrant)
        {
            return UtilitaireService.AppelerService<svcCnsulProfiPremqProf.IServCnsulProfiPremqProf,
                                                    svcCnsulProfiPremqProf.ServCnsulProfiPremqProfClient,
                                                    CalculerNbrJrFactProfsSorti>
                                                    (x => x.CalculerNombreJourneeFacturation(intrant));
        }

        /// <summary>
        /// Permet d'obtenir la réduction à la rémunération
        /// </summary>
        /// <param name="intrant">Paramètres d'entré</param>
        /// <returns>Réduction à la rémunération</returns>
        public ReductionRemunerationSorti ObtenirReductionRemuneration(ReductionRemunerationEntre intrant)
        {
            return UtilitaireService.AppelerService<svcCnsulProfiPremqProf.IServCnsulProfiPremqProf,
                                                     svcCnsulProfiPremqProf.ServCnsulProfiPremqProfClient,
                                                     ReductionRemunerationSorti>
                                                     (x => x.ObtenirReductionRemuneration(intrant));
        }

        /// <summary>
        /// Permet d'obtenir le pourcentage maximum
        /// </summary>
        /// <returns>Pourcentage maximum</returns>
        public ObtenirPourcentageMaximumSorti ObtenirPourcentageMaximum()
        {
            return UtilitaireService.AppelerService<svcCnsulProfiPremqProf.IServCnsulProfiPremqProf,
                                                     svcCnsulProfiPremqProf.ServCnsulProfiPremqProfClient,
                                                     ObtenirPourcentageMaximumSorti>
                                                     (x => x.ObtenirPourcentageMaximum());
        }

         
    }
}