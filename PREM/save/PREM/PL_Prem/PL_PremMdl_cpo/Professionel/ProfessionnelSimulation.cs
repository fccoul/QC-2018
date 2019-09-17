#region Importation
using RAMQ.PRE.PL_PremMdl_cpo.svcCnsulProfiPremqProf;
using RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.EngagementPratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.PeriodePratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Pratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Entite;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Recherche.Entite;
using System;
using System.Collections.Generic;
#endregion


namespace RAMQ.PRE.PL_PremMdl_cpo.Professionnel
{
    /// <summary> 
    ///  Référentiel bidon qui permet d'obtenir les informations des professionnels fictifs 
    ///  codés en dur.
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
    public class ProfessionnelSimulation : IProfessionnel
    {

        /// <summary>
        /// Obtenir les informations sur la relation dispensateur individu
        /// </summary>
        /// <param name="intrant">Les critères de recherche</param>
        /// <returns>Une liste avec les informations des professionnels</returns>
        /// <remarks></remarks>
        public ObtenirDispensateurIndividuSorti ObtenirInformationProfessionnel(ObtenirDispensateurIndividuEntre intrant)
        {

            //TODO : Faire la simulation

            throw new NotImplementedException();
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

            //TODO : Faire la simulation

            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtient une liste de numéro de pratique filtré par le terme entré et la limite de pagination obtenu
        /// </summary>
        /// <param name="classe">Les classes de professionnels à filtrer</param>
        /// <param name="filtre">Les critères pour le filtre</param>
        /// <param name="filtreSpecialPourCreationAvis">Indicateur pour l'utilisation du filtre spécial</param>
        /// <returns>La liste filtrer des numéros de pratique</returns>
        /// <remarks></remarks>
        public Resultat ObtenirNumerosPratiqueFiltre(IEnumerable<int> classe, Critere filtre, bool filtreSpecialPourCreationAvis)
        {

            //TODO : Faire la simulation

            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtenir les période de pratique d'un professionnel
        /// </summary>
        /// <param name="intrant">Information pour la recherche des périodes de pratique lié au professionnel</param>
        /// <returns>Période de pratique d'un professionnel</returns>
        /// <remarks></remarks>
        public ObtenirPeriodePratiqueProfessionnelSorti ObtenirPeriodePratiqueProfessionnel(ObtenirPeriodePratiqueProfessionnelEntre intrant)
        {
            //TODO : Faire la simulation

            throw new NotImplementedException();
        }

        /// <summary>
        /// Permet d'obtenir les information sur l'admissibilité du professionnel à facturer
        /// </summary>
        /// <param name="intrant">Information du professionnel</param>
        /// <returns>Les information sur l'admissibilité du professionnel à facturer</returns>
        /// <remarks></remarks>
        public VerifierAdmissibiliteProfessionnelFacturerSorti VerifierAdmissibiliteProfessionnel(VerifierAdmissibiliteProfessionnelFacturerEntre intrant)
        {
            //TODO : Faire la simulation

            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtenir les dérogations d'un professionnel de la santé
        /// </summary>
        /// <param name="intrant">Information pour la recherche des dérogations</param>
        /// <returns>Les dérogations d'un professionnel de la santé</returns>
        /// <remarks></remarks>
        public ObtenirDerogationsProfessionnelSanteSorti ObtenirDerogationProfessionnelSante(ObtenirDerogationsProfessionnelSanteEntre intrant)
        {
            //TODO : Faire la simulation

            throw new NotImplementedException();
        }


        /// <summary>
        /// Permet de modifier une dérogation d'un professionnel de la santé
        /// </summary>
        /// <param name="intrant">Paramètre d'entrée</param>
        /// <returns>Nouveau numéro séquentiel de la dérogation</returns>
        /// <remarks></remarks>
        public ModifierDerogationSorti ModifierDerogation(ModifierDerogationEntre intrant)
        {
            //TODO : Faire la simulation

            throw new NotImplementedException();
        }

        /// <summary>
        /// Permet d'obtenir les engagements de pratique d'un professionnel
        /// </summary>
        /// <param name="intrant">Paramètres d'entré</param>
        /// <returns>Engagements de pratiques d'un professionnel</returns>
        public ObtenirEngagementPratiqueSorti ObtenirEngagementPratiques(ObtenirEngagementPratiqueEntre intrant)
        {
            //TODO : Faire la simulation

            throw new NotImplementedException();
        }

        /// <summary>
        /// Valider le professionnel
        /// </summary>
        /// <param name="intrant">Information du professionnel</param>
        /// <returns>Liste de messages</returns>
        public ValiderProfessionnelSorti ValiderProfessionnel(ValiderProfessionnelEntre intrant)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permet de calculer le nombre de journée de facturation
        /// </summary>
        /// <param name="intrant">Paramètres d'entré</param>
        /// <returns>Journées facturés</returns>
        public CalculerNbrJrFactProfsSorti CalculerNombreJourneeFacturation(CalculerNbrJrFactProfsEntre intrant)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permet d'obtenir la réduction à la rémunération
        /// </summary>
        /// <param name="intrant">Paramètres d'entré</param>
        /// <returns>Réduction à la rémunération</returns>
        public ReductionRemunerationSorti ObtenirReductionRemuneration(ReductionRemunerationEntre intrant)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Permet d'obtenir le pourcentage maximum
        /// </summary>
        /// <returns>Pourcentage maximum</returns>
        public ObtenirPourcentageMaximumSorti ObtenirPourcentageMaximum()
        {
            throw new NotImplementedException();
        }

        
    }
}