using RAMQ.Message;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal
{
    /// <summary> 
    /// Interface regroupant les appels pour la facette Plans régionaux d'effectifs médicaux.
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : 2016-09-21
    /// </remarks>
    public interface IPlanRegnMdcal
    {
        #region Demande Reevaluation

        /// <summary>
        /// Obtenir une liste de demandes de réévaluation PREM 
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Un objet contenant la date et heure de l’occurrence et des messages d'erreurs</returns>
        ObtenirListeDemReevaSorti ObtenirListeDemReeva(ObtenirListeDemReevaEntre intrant);

        /// <summary>
        /// Modifier une demande de réévaluation PREM 
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Un objet contenant la date et heure de l’occurrence et des messages d'erreurs</returns>
        ModifierDemReevaPREMSorti ModifierDemReevaPREM(ModifierDemReevaPREMEntre intrant);

        /// <summary>
        /// Créer une demande de réévaluation PREM  
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Un objet contenant la date et heure de l’occurrence et des messages d'erreurs</returns>
        CreerDemReevaPREMSorti CreerDemReevaPREM(CreerDemReevaPREMEntre intrant);

        /// <summary>
        /// Annuler une demande de réévaluation PREM  
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Un objet contenant la date et heure de l’occurrence et des messages d'erreurs</returns>
        AnnulerDemandeReevaPREMQSorti AnnulerDemReevaPREMQ(AnnulerDemandeReevaPREMQEntre intrant);

        #endregion

        #region Avis de conformité

        /// <summary>
        /// Permet la création des avis de conformités
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Un objet contenant le numéro séquentiel de l'engagement créé</returns>
        CreerAvisConformiteSorti CreerAvisConformite(CreerAvisConformiteEntre intrant);

        /// <summary>
        /// Permet de Modifier un avis de conformité  
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        ModifierAvisConformiteSorti ModifierAvisConformite(ModifierAvisConformiteEntre intrant);

        /// <summary>
        /// Permet la modification des avis de conformités et de ses statuts
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Un objet contenant la date et heure de l’occurrence et des messages d'erreurs</returns>
        ModifierAvisConformiteStatutSorti ModifierAvisConformiteStatut(ModifierAvisConformiteStatutEntre intrant);

        /// <summary>
        /// Permet l'obtention des avis de conformités et de leur statuts
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste des avis de conformité et de leurs statuts</returns>
        ObtenirLesAvisConformiteSorti ObtenirLesAvisConformite(ObtenirLesAvisConformiteEntre intrant);

        /// <summary>
        /// Permet de modifier un statut lié à un avis de conformité d'un professionnel
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Un objet contenant la date et heure de l'occurrence et des messages d'erreurs</returns>
        ModifierStatutEngagementSorti ModifierStatutEngagement(ModifierStatutEngagementEntre intrant);

        /// <summary>
        /// Permet de créer un statut pour un avis de conformité
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Un objet contenant la date et heure de l'occurrence, des messages d'erreurs et le numéro séquentiel du statut créé</returns>
        CreerStatutAvisConformiteSorti CreerStatutAvisConformite(CreerStatutAvisConformiteEntre intrant);

        /// <summary>
        /// Permet de modifier la période d'un avis de conformité
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Un objet contenant la date et heure de l'occurrence et des messages d'erreurs</returns>
        ModifierPeriodeAvisSorti ModifierPeriodeAvis(ModifierPeriodeAvisEntre intrant);

        /// <summary>
        /// Permet d'obtenir les engagements et/ou absences d'avis d'un professionnel
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste des engagements et/ou absences d'avis d'un professionnel</returns>
        ObtenirListeEngagementsEtAbsencesAvisSorti ObtenirListeEngagementsEtAbsencesAvis(ObtenirListeEngagementsEtAbsencesAvisEntre intrant);

        /// <summary>
        /// Permet de modifier la raison de fermeture du statut de l'engagement
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        ModifierRaisFermStatutEngagSorti ModifierRaisFermStatutEngag(ModifierRaisFermStatutEngagEntre intrant);


        #endregion

        #region Dérogation

        /// <summary>
        /// Permet de modifier une dérogation d'un professionnel de la santé
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Le nouveau numéro séquentiel de la dérogation</returns>
        ModifierDerogationSorti ModifierDerogation(ModifierDerogationEntre intrant);

        /// <summary>
        /// Permet de faire l'obtention des dérogations d'un professionnel de la santé
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste des dérogations d'un professionnel de la santé</returns>
        ObtenirDerogationsProfessionnelSanteSorti ObtenirDerogationsProfessionnelSante(ObtenirDerogationsProfessionnelSanteEntre intrant);

        /// <summary>
        /// Permet de créer une dérogation d'un professionnel de la santé.
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée.</param>
        /// <returns>Liste des dérogations d'un professionnel de la santé.</returns>
        CreerDerogationSorti CreerDerogation(CreerDerogationEntre intrant);

        #endregion

        #region Professionnel

        /// <summary>
        /// Permet de faire l'obtention de la liste des statuts engagement pratique RSS 
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste des statuts engagement pratique RSS</returns>
        ObtenirStatutsEngagementPratiqueRSSSorti ObtenirStatutsEngagementPratiqueRSS(ObtenirStatutsEngagementPratiqueRSSEntre intrant);


        #endregion

        #region Pratique

        /// <summary>
        /// Permet de faire l'obtention des jours facturés de la pratique PREM par région
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste de journées facturées des professionnels de la santé par RSS</returns>
        ObtenirJoursFactPratiRegionSorti ObtenirJoursFactPratiRegion(ObtenirJoursFactPratiRegionEntre intrant);

        /// <summary>
        /// Permet de faire l'obtention des jours facturés de la pratique PREM par territoire
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste de journées facturées des professionnels de la santé par RSS</returns>
        ObtenirJoursFactPratiTerriSorti ObtenirJoursFactPratiTerri(ObtenirJoursFactPratiTerriEntre intrant);

        /// <summary>
        /// Permet de faire l'obtention des jours facturés de la pratique PREM par avis
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste de journées facturées des professionnels de la santé par avis</returns>
        ObtenirVueJoursFactPratiAvisSorti ObtenirVueJoursFactPratiAvis(ObtenirVueJoursFactPratiAvisEntre intrant);

        /// <summary>
        /// Permet de faire l'obtention des jours facturés de la pratique PREM par RSS
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste de journées facturées des professionnels de la santé par RSS</returns>
        ObtenirVueJoursFactPratiRssSorti ObtenirVueJoursFactPratiRSS(ObtenirVueJoursFactPratiRssEntre intrant);

        /// <summary>
        /// Permet de faire l'obtention des jours facturés de la pratique PREM par Territoires
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste de journées facturées des professionnels de la santé par Territoires</returns>
        ObtenirVueJoursFactPratiTerriSorti ObtenirVueJoursFactPratiTerri(ObtenirVueJoursFactPratiTerriEntre intrant);

        /// <summary>
        /// Permet de faire l'obtention des jours facturés de la pratique PREM par Territoires
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste de journées facturées des professionnels de la santé par Territoires</returns>
        ObtenirVueJoursFactPratiRPPRSorti ObtenirVueJoursFactPratiRPPR(ObtenirVueJoursFactPratiRPPREntre intrant);

        /// <summary>
        /// Permet de faire l'obtention paramètres de production
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste de paramètres de production</returns>
        ObtenirParametresProductionSorti ObtenirParametresProduction(ObtenirParametresProductionEntre intrant);

        #endregion

        #region Correspondance

        /// <summary>
        /// Permet de faire l'obtention des commandes de correspondances
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste de paramètres de production</returns>
        ObtenirListeCmndCorreSorti ObtenirListeCmndCorre(ObtenirListeCmndCorreEntre intrant);

        /// <summary>
        /// Permet de faire l'obtention des exemptions d’une réduction 
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste de paramètres de production</returns>
        ObtenirListeExemptionsSorti ObtenirListeExemptions(ObtenirListeExemptionsEntre intrant);

        /// <summary>
        /// Permet de modifier une commande de correspondances 
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns></returns>
        IEnumerable<MsgTrait> ModifierCmndCorre(ModifierCommandeCorrespondancesEntre intrant);

        #endregion

        #region Autorisation
        /// <summary>
        /// Permet de faire l'obtention des autorisations PREMQ
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste des autorisations d'un professionnel de la santé</returns>
        ObtenirAutorisationsSorti ObtenirAutorisationsPREMQ(ObtenirAutorisationsEntre intrant);

        /// <summary>
        /// Permet de créer une autorisation PREMQ 
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns></returns>
        CreerAutorisationPREMQSorti CreerAutorisationPREMQ(CreerAutorisationPREMQEntre intrant);

        /// <summary>
        /// Permet d'annuler une autorisation PREMQ 
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns></returns>
        AnnulerAutorisationPREMQSorti AnnulerAutorisationPREMQ(AnnulerAutorisationPREMQEntre intrant);


        /// <summary>
        /// Permet de prolonger une autorisation PREMQ 
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns></returns>
        ProlongerAutorisationPREMQSorti ProlongerAutorisationPREMQ(ProlongerAutorisationPREMQEntre intrant);



        /// <summary>
        /// Permet de modifier une Autorisation d'un professionnel de la santé
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Le nouveau numéro séquentiel de l'autorisation</returns>
        ModifierAutorisationSorti ModifierAutorisation(ModifierAutorisationEntre intrant);
        #endregion

        #region Réduction rémunération

        /// <summary>
        /// Permet de faire l'obtention des réductions à la rémunération
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste des réduction à la  rémunération d'un professionnel de la santé</returns>
        ObtenirReductionsRemunerationSorti ObtenirReductionsRemuneration(ObtenirReductionsRemunerationEntre intrant);

        #endregion

        #region "Caractéristique pratique"

        /// <summary>
        /// Permet de faire l'obtention des caractéristiques de pratique RSS
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste des caractéristiques de pratique</returns>
        ObtenirCaracteristiquePratiqueRssSorti ObtenirCaracteristiquePratiqueRss(ObtenirCaracteristiquePratiqueRssEntre intrant);

        #endregion

        #region CalculRepartition
        /// <summary>
        /// Permet d'obtenir les informations d'exécution en mode massif.
        /// </summary>
        /// <returns>Date de début et de fin de période.</returns>
        ObtenirInfosExecutionMassiveSorti ObtenirInfosExecutionMassive();

        /// <summary>
        /// Permet d'obtenir les informations d'exécution en mode mensuel.
        /// </summary>
        /// <returns>Date de début et de fin de période.</returns>
        ObtenirInfosExecutionMensuelSorti ObtenirInfosExecutionMensuel();

        /// <summary>
        /// Permet d'obtenir les informations d'exécution en mode journalier.
        /// </summary>
        /// <returns>Date de début et de fin de période.</returns>
        ObtenirInfosExecutionJournalierSorti ObtenirInfosExecutionJournalier();

        /// <summary>
        /// Permet de purger la table de pratique professionnel.
        /// </summary>
        /// <returns>Rien</returns>
        PurgerTablePratiqueProfessionnelSorti PurgerTablePratiqueProfessionnel();

        /// <summary>
        /// Permet d'exécuter la répartition en mode journalier.
        /// </summary>
        /// <returns>Rien</returns>
        TraiterRepartitionJournalierSorti TraiterRepartitionJournalier();

        /// <summary>
        /// Permet de faire l'obtention des caractéristiques de pratique RSS
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste des caractéristiques de pratique</returns>
        TraiterRepartitionMensuelMassifSorti TraiterRepartitionMensuelMassif(TraiterRepartitionMensuelMassifEntre intrant);

        /// <summary>
        ///  Permet l'obtention des territoires RPPR
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste des réduction à la  rémunération d'un professionnel de la santé</returns>
        ObtenirTerriRPPRSorti ObtenirTerriRPPR(ObtenirTerriRPPREntre intrant);

        /// <summary>
        ///  Permet l'obtention des listes d'engagement
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns>Liste d'engagements de professionnels de la santé</returns>
        ObtenirVueListeEngagementsSorti ObtenirVueListeEngagements(ObtenirVueListeEngagementsEntre intrant);

        /// <summary>
        ///  Permet l'obtention de la vue des périodes d'engagement
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        ObtenirVuePeriodesEngagementsSorti ObtenirVuePeriodesEngagements(ObtenirVuePeriodesEngagementsEntre intrant);
        #endregion

        #region Vues PLC1
        /// <summary>
        /// Obtenir la vue de la liste PrctJrfacAvis
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        ObtenirVueListPrctJrfacAvisSorti ObtenirVueListPrctJrfacAvis(ObtenirVueListPrctJrfacAvisEntre intrant);
        /// <summary>
        /// Obtenir la vue de la liste PrctJrfacDerog
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        ObtenirVueListPrctJrfacDerogSorti ObtenirVueListPrctJrfacDerog(ObtenirVueListPrctJrfacDerogEntre intrant);

        /// <summary>
        /// Obtenir la vue de la liste PrctJrfacTerri
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        ObtenirVueListPrctJrfacTerriSorti ObtenirVueListPrctJrfacTerri(ObtenirVueListPrctJrfacTerriEntre intrant);

        /// <summary>
        /// Permet l'obtention de la vue Obtenir la liste du pourcentage de jours facturés des médecins omnipraticiens en RPPR 
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        ObtenirVueListPrctJrfacRPPRSorti ObtenirVueListPrctJrfacRPPR(ObtenirVueListPrctJrfacRPPREntre intrant);

        #endregion
    }
}