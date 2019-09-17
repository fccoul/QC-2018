using RAMQ.Message;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre;
using RAMQ.PRE.PRE_FournAccesDonne_cpo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal
{
    /// <summary> 
    /// Classe regroupant les appels pour la facette Plans régionaux d'effectifs médicaux.
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : 2016-09-21
    /// </remarks>
    public class PlanRegnMdcal : IPlanRegnMdcal
    {
        #region Attribut privé

        const string NomCodeRetourDifferent = "pVchrCodeRetour";
        private readonly IAccesDonne _clientAccessDonne;

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public PlanRegnMdcal(IAccesDonne accesDonne)
        {
            if (accesDonne == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(accesDonne)} ne peut être null.");
            }

            _clientAccessDonne = accesDonne;
        }

        #endregion

        #region Méthodes publiques


        /// <summary>
        /// Obtenir une liste de demandes de réévaluation PREM 
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Un objet contenant la date et heure de l’occurrence et des messages d'erreurs</returns>
        public ObtenirListeDemReevaSorti ObtenirListeDemReeva(ObtenirListeDemReevaEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<ObtenirListeDemReevaEntre,
                                                        ObtenirListeDemReevaSorti>
                   (intrant, "PRE_PREMQ_PlanRegnMdcalCnsul.ObtenirListeDemReeva", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Modifier une demande de réévaluation PREM 
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Un objet contenant la date et heure de l’occurrence et des messages d'erreurs</returns>
        public ModifierDemReevaPREMSorti ModifierDemReevaPREM(ModifierDemReevaPREMEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<ModifierDemReevaPREMEntre,
                                                        ModifierDemReevaPREMSorti>
                   (intrant, "PRE_PREMQ_PlanRegnMdcalMAJ.ModifierDemReevaPREM", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Créer une demande de réévaluation PREM  
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Un objet contenant la date et heure de l’occurrence et des messages d'erreurs</returns>
        public CreerDemReevaPREMSorti CreerDemReevaPREM(CreerDemReevaPREMEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<CreerDemReevaPREMEntre,
                                                        CreerDemReevaPREMSorti>
                   (intrant, "PRE_PREMQ_PlanRegnMdcalMAJ.CreerDemReevaPREM", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Annuler une demande de réévaluation PREM  
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Un objet contenant la date et heure de l’occurrence et des messages d'erreurs</returns>
        public AnnulerDemandeReevaPREMQSorti AnnulerDemReevaPREMQ(AnnulerDemandeReevaPREMQEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<AnnulerDemandeReevaPREMQEntre,
                                                        AnnulerDemandeReevaPREMQSorti>
                   (intrant, "PRE_PREMQ_PlanRegnMdcalMAJ.AnnulerDemReevaPREM", NomCodeRetourDifferent);
        }


        /// <summary>
        /// Permet la création des avis de conformités
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Un objet contenant le numéro séquentiel de l'engagement créé</returns>
        public CreerAvisConformiteSorti CreerAvisConformite(CreerAvisConformiteEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<CreerAvisConformiteEntre,
                                                        CreerAvisConformiteSorti>
                   (intrant, "PRE_PREMQ_PlanRegnMdcalMaj.CreerAvisConf", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Permet la modification des avis de conformités et de ses statuts
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Un objet contenant la date et heure de l'occurrence et des messages d'erreurs</returns>
        public ModifierAvisConformiteStatutSorti ModifierAvisConformiteStatut(ModifierAvisConformiteStatutEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<ModifierAvisConformiteStatutEntre, 
                                                        ModifierAvisConformiteStatutSorti>
                   (intrant, "PRE_PREMQ_PlanRegnMdcalMaj.ModifierAvisConfSta", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Permet l'obtention des avis de conformités et de leur statuts
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste des avis de conformité et de leurs statuts</returns>
        public ObtenirLesAvisConformiteSorti ObtenirLesAvisConformite(ObtenirLesAvisConformiteEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<ObtenirLesAvisConformiteEntre, 
                                                        ObtenirLesAvisConformiteSorti>
                   (intrant, "PRE_PREMQ_PlanRegnMdcalCnsul.ObtenirListeAvisConf", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Permet de Modifier un avis de conformité  
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        public ModifierAvisConformiteSorti ModifierAvisConformite(ModifierAvisConformiteEntre intrant)
        {
            return _clientAccessDonne.ExecuterProc<ModifierAvisConformiteEntre,
                                                        ModifierAvisConformiteSorti>
                   (intrant, "PRE_PREMQ_PlanRegnMdcalMaj.ModifierAvisConf", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Permet de modifier un statut lié à un avis de conformité d'un professionnel
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Un objet contenant la date et heure de l'occurrence et des messages d'erreurs</returns>
        public ModifierStatutEngagementSorti ModifierStatutEngagement(ModifierStatutEngagementEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<ModifierStatutEngagementEntre,
                                                        ModifierStatutEngagementSorti>
                   (intrant, "PRE_PREMQ_PlanRegnMdcalMaj.ModifierStaEngag", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Permet de créer un statut pour un avis de conformité
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Un objet contenant la date et heure de l'occurrence, des messages d'erreurs et le numéro séquentiel du statut créé</returns>
        public CreerStatutAvisConformiteSorti CreerStatutAvisConformite(CreerStatutAvisConformiteEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<CreerStatutAvisConformiteEntre,
                                                        CreerStatutAvisConformiteSorti>
                   (intrant, "PRE_PREMQ_PlanRegnMdcalMaj.CreerStaEngag", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Permet de modifier la période d'un avis de conformité
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Un objet contenant la date et heure de l’occurrence et des messages d'erreurs</returns>
        public ModifierPeriodeAvisSorti ModifierPeriodeAvis(ModifierPeriodeAvisEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<ModifierPeriodeAvisEntre,
                                                        ModifierPeriodeAvisSorti>
                   (intrant, "PRE_PREMQ_PlanRegnMdcalMAJ.ModifierPeriodeAvis", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Permet de modifier une dérogation d'un professionnel de la santé
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Le nouveau numéro séquentiel de la dérogation</returns>
        public ModifierDerogationSorti ModifierDerogation(ModifierDerogationEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<ModifierDerogationEntre, 
                                                        ModifierDerogationSorti>
                   (intrant, "PRE_PREMQ_PlanRegnMdcalMAJ.ModifierDerogation", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Permet de faire l'obtention des dérogations d'un professionnel de la santé
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste des dérogations d'un professionnel de la santé</returns>
        public ObtenirDerogationsProfessionnelSanteSorti ObtenirDerogationsProfessionnelSante(ObtenirDerogationsProfessionnelSanteEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<ObtenirDerogationsProfessionnelSanteEntre, 
                                                        ObtenirDerogationsProfessionnelSanteSorti>
                   (intrant, "PRE_PREMQ_PlanRegnMdcalCnsul.ObtenirListeDerog", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Permet de créer une dérogation d'un professionnel de la santé.
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée.</param>
        /// <returns>Liste des dérogations d'un professionnel de la santé.</returns>
        public CreerDerogationSorti CreerDerogation(CreerDerogationEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<CreerDerogationEntre,
                                                        CreerDerogationSorti>
                   (intrant, "PRE_PREMQ_PlanRegnMdcalMaj.CreerDerogation", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Permet de faire l'obtention des autorisations PREMQ
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste des autorisations PREMQ</returns>
        public ObtenirAutorisationsSorti ObtenirAutorisationsPREMQ(ObtenirAutorisationsEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<ObtenirAutorisationsEntre, 
                                                        ObtenirAutorisationsSorti>
                   (intrant, "PRE_PREMQ_PlanRegnMdcalCnsul.ObtenirListeAutorPREMQ", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Permet de faire l'obtention de la liste des statuts engagement pratique RSS 
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste des statuts engagement pratique RSS</returns>
        public ObtenirStatutsEngagementPratiqueRSSSorti ObtenirStatutsEngagementPratiqueRSS(ObtenirStatutsEngagementPratiqueRSSEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<ObtenirStatutsEngagementPratiqueRSSEntre,
                                                        ObtenirStatutsEngagementPratiqueRSSSorti>
                   (intrant, "PRE_PREMQ_PlanRegnMdcalCnsul.ObtenirListStatEngagPratiRSS", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Permet de faire l'obtention des jours facturés de la pratique PREM par région
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste de journées facturées des professionnels de la santé par RSS</returns>
        public ObtenirJoursFactPratiRegionSorti ObtenirJoursFactPratiRegion(ObtenirJoursFactPratiRegionEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<ObtenirJoursFactPratiRegionEntre,
                                                        ObtenirJoursFactPratiRegionSorti>
                   (intrant, "PRE_PREMQ_PlanRegnMdcalCnsul.ObtenirJoursFactPratiRegion", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Permet de faire l'obtention des jours facturés de la pratique PREM par territoire
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste de journées facturées des professionnels de la santé par RSS</returns>
        public ObtenirJoursFactPratiTerriSorti ObtenirJoursFactPratiTerri(ObtenirJoursFactPratiTerriEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<ObtenirJoursFactPratiTerriEntre,
                                                        ObtenirJoursFactPratiTerriSorti>
                   (intrant, "PRE_PREMQ_PlanRegnMdcalCnsul.ObtenirJoursFactPratiTerri", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Permet de faire l'obtention paramètres de production
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste de paramètres de production</returns>
        public ObtenirParametresProductionSorti ObtenirParametresProduction(ObtenirParametresProductionEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<ObtenirParametresProductionEntre,
                                                        ObtenirParametresProductionSorti>
                   (intrant, "PRE_PILOT_PlanRegnMdcalCnsul.ObtenirListeParamProd", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Permet de faire l'obtention des commandes de correspondances
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste des commandes de correspondances</returns>
        public ObtenirListeCmndCorreSorti ObtenirListeCmndCorre(ObtenirListeCmndCorreEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<ObtenirListeCmndCorreEntre,
                                                        ObtenirListeCmndCorreSorti>
                   (intrant, "PRE_PREMQ_PlanRegnMdcalCnsul.ObtenirListeCmndCorre", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Permet de faire l'obtention des exemptions d’une réduction 
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste des exemptions</returns>
        public ObtenirListeExemptionsSorti ObtenirListeExemptions(ObtenirListeExemptionsEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<ObtenirListeExemptionsEntre,
                                                        ObtenirListeExemptionsSorti>
                   (intrant, "PRE_PREMQ_PlanRegnMdcalCnsul.ObtenirListeExemptions", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Permet de modifier une commande de correspondances 
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns></returns>
        public IEnumerable<MsgTrait> ModifierCmndCorre(ModifierCommandeCorrespondancesEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<ModifierCommandeCorrespondancesEntre>
                   (intrant, "PRE_PREMQ_PlanRegnMdcalMAJ.ModifierCmndCorre", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Permet de créer une autorisation PREMQ 
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns></returns>
        public CreerAutorisationPREMQSorti CreerAutorisationPREMQ(CreerAutorisationPREMQEntre intrant)
        {
           return  _clientAccessDonne.ExecuterProcedure<CreerAutorisationPREMQEntre,
                                                        CreerAutorisationPREMQSorti>
                   (intrant, "PRE_PREMQ_PlanRegnMdcalMAJ.CreerAutorPREMQ", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Permet d'annuler une autorisation PREMQ 
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns></returns>
        public AnnulerAutorisationPREMQSorti AnnulerAutorisationPREMQ(AnnulerAutorisationPREMQEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<AnnulerAutorisationPREMQEntre,
                                                        AnnulerAutorisationPREMQSorti>
                    (intrant, "PRE_PREMQ_PlanRegnMdcalMAJ.AnnulerAutorPREMQ", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Permet de prolonger une autorisation PREMQ 
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns></returns>
        public ProlongerAutorisationPREMQSorti ProlongerAutorisationPREMQ(ProlongerAutorisationPREMQEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<ProlongerAutorisationPREMQEntre,
                                                        ProlongerAutorisationPREMQSorti>
                    (intrant, "PRE_PREMQ_PlanRegnMdcalMAJ.ProlongerAutorPREMQ", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Permet d'obtenir les engagements et/ou absences d'avis d'un professionnel
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste des engagements et/ou absences d'avis d'un professionnel</returns>
        public ObtenirListeEngagementsEtAbsencesAvisSorti ObtenirListeEngagementsEtAbsencesAvis(ObtenirListeEngagementsEtAbsencesAvisEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<ObtenirListeEngagementsEtAbsencesAvisEntre,
                                                        ObtenirListeEngagementsEtAbsencesAvisSorti>
                   (intrant, "PRE_PREMQ_PlanRegnMdcalCnsul.ObtenirListeEngagEtAbsAvis", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Permet de faire l'obtention des réductions à la rémunération
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste des réduction à la  rémunération d'un professionnel de la santé</returns>
        public ObtenirReductionsRemunerationSorti ObtenirReductionsRemuneration(ObtenirReductionsRemunerationEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<ObtenirReductionsRemunerationEntre,
                                                        ObtenirReductionsRemunerationSorti>
                    (intrant, "PRE_PREMQ_PlanRegnMdcalMAJ.ObtenirListeReducProf", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Permet de faire l'obtention des caractéristiques de pratique RSS
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste des caractéristiques de pratique</returns>
        public ObtenirCaracteristiquePratiqueRssSorti ObtenirCaracteristiquePratiqueRss(ObtenirCaracteristiquePratiqueRssEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<ObtenirCaracteristiquePratiqueRssEntre,
                                                        ObtenirCaracteristiquePratiqueRssSorti>
                    (intrant, "PRE_Pilot_PlanRegnMdcalCnsul.ObtenirCarPratiRss", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Permet de faire l'obtention des jours facturés de la pratique PREM par avis
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste de journées facturées des professionnels de la santé par avis</returns>
        public ObtenirVueJoursFactPratiAvisSorti ObtenirVueJoursFactPratiAvis(ObtenirVueJoursFactPratiAvisEntre intrant)
        {
            var sortant = new ObtenirVueJoursFactPratiAvisSorti();
            var requete = string.Format(Constantes.RequeteVueReptnPratiAvis,
                                        intrant.NumeroSeqDispensateur.Any() ? intrant.NumeroSeqDispensateur.First().ToString() : "NULL",
                                        intrant.NumeroSeqDispensateur.Any() ? string.Join(",", intrant.NumeroSeqDispensateur) : "NULL");
            sortant.ListeJoursFactParAvis = _clientAccessDonne.ExecuterRequeteSQL<JoursFactParAvis>(requete, new List<string>()
            {
                intrant.DateServiceDebutPerRechr.ToString(),
                intrant.DateServiceDebutPerRechr.ToString(),
                intrant.DateServiceFinPerRechr.ToString(),
                intrant.DateServiceFinPerRechr.ToString(),
                intrant.DateDebutEngagDebutPerRechr.ToString(),
                intrant.DateDebutEngagDebutPerRechr.ToString(),
                intrant.DateDebutEngagFinPerRechr.ToString(),
                intrant.DateDebutEngagFinPerRechr.ToString(),
                intrant.DateFinEngagDebutPerRechr.ToString(),
                intrant.DateFinEngagDebutPerRechr.ToString(),
                intrant.DateFinEngagFinPerRechr.ToString(),
                intrant.DateFinEngagFinPerRechr.ToString(),
                intrant.CodeRSS,
                intrant.CodeRSS,
                intrant.TypeLieuGeo,
                intrant.TypeLieuGeo,
                intrant.CodeLieuGeo,
                intrant.CodeLieuGeo,
                intrant.NumeroSeqRegrAdminLieuGeo,
                intrant.NumeroSeqRegrAdminLieuGeo,
                intrant.StatutEngagTerri,
                intrant.StatutEngagTerri,
                intrant.Jours.ToString(),
                intrant.Jours.ToString(),
                intrant.TypeServiceRepartitionPratique,
                intrant.TypeServiceRepartitionPratique,
                intrant.NombreElementsParPage.ToString(),
                intrant.NumeroPage.ToString(),
                intrant.NombreElementsParPage.ToString(),
                intrant.NumeroPage.ToString()
            });
            return sortant;
        }

        /// <summary>
        /// Permet de faire l'obtention des jours facturés de la pratique PREM par RSS
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste de journées facturées des professionnels de la santé par RSS</returns>
        public ObtenirVueJoursFactPratiRssSorti ObtenirVueJoursFactPratiRSS(ObtenirVueJoursFactPratiRssEntre intrant)
        {
            var sortant = new ObtenirVueJoursFactPratiRssSorti();
            var requete = string.Format(Constantes.RequeteVueReptnPratiRSS,
                                        intrant.NumeroSeqDispensateur.Any() ? intrant.NumeroSeqDispensateur.First().ToString() : "NULL",
                                        intrant.NumeroSeqDispensateur.Any() ? string.Join(",", intrant.NumeroSeqDispensateur) : "NULL");
            sortant.ListeJoursFactParRss = _clientAccessDonne.ExecuterRequeteSQL<JoursFactParRSS>(requete, new List<string>()
            {
                intrant.DateServiceDateDebutPerRechr.ToString(),
                intrant.DateServiceDateDebutPerRechr.ToString(),
                intrant.DateServiceDateFinPerRechr.ToString(),
                intrant.DateServiceDateFinPerRechr.ToString(),
                intrant.CodeRSS,
                intrant.CodeRSS,
                intrant.Jours.ToString(),
                intrant.Jours.ToString(),
                intrant.TypeServiceRepartitionPratique,
                intrant.TypeServiceRepartitionPratique,
                intrant.NombreElementsParPage.ToString(),
                intrant.NumeroPage.ToString(),
                intrant.NombreElementsParPage.ToString(),
                intrant.NumeroPage.ToString()
            });
            return sortant;
        }

        /// <summary>
        /// Permet de faire l'obtention des jours facturés de la pratique PREM par Territoires
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste de journées facturées des professionnels de la santé par Territoires</returns>
        public ObtenirVueJoursFactPratiTerriSorti ObtenirVueJoursFactPratiTerri(ObtenirVueJoursFactPratiTerriEntre intrant)
        {
            var sortant = new ObtenirVueJoursFactPratiTerriSorti();
            var requete = string.Format(Constantes.RequeteVueReptnPratiTerri,
                                        intrant.NumeroSeqDispensateur.Any() ? intrant.NumeroSeqDispensateur.First().ToString() : "NULL",
                                        intrant.NumeroSeqDispensateur.Any() ? string.Join(",", intrant.NumeroSeqDispensateur) : "NULL");
            sortant.ListeJoursFactParTerri = _clientAccessDonne.ExecuterRequeteSQL<JoursFactParTerri> (requete, new List<string>()
            {
                intrant.DateServiceDateDebutPerRechr.ToString(),
                intrant.DateServiceDateDebutPerRechr.ToString(),
                intrant.DateServiceDateFinPerRechr.ToString(),
                intrant.DateServiceDateFinPerRechr.ToString(),
                intrant.CodeRSS,
                intrant.CodeRSS,
                intrant.TypeLieuGeo,
                intrant.TypeLieuGeo,
                intrant.CodeLieuGeo,
                intrant.CodeLieuGeo,
                intrant.NumeroSeqRegrAdminLieuGeo.ToString(),
                intrant.NumeroSeqRegrAdminLieuGeo.ToString(),
                intrant.Jours.ToString(),
                intrant.Jours.ToString(),
                intrant.TypeServiceRepartitionPratique,
                intrant.TypeServiceRepartitionPratique,
                intrant.NombreElementsParPage.ToString(),
                intrant.NumeroPage.ToString(),
                intrant.NombreElementsParPage.ToString(),
                intrant.NumeroPage.ToString()
            });

            return sortant;
        }

        /// <summary>
        /// Permet de faire l'obtention des jours facturés de la pratique PREM par RPPR
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste de journées facturées des professionnels de la santé par RPPR</returns>
        public ObtenirVueJoursFactPratiRPPRSorti ObtenirVueJoursFactPratiRPPR(ObtenirVueJoursFactPratiRPPREntre intrant)
        {
            var sortant = new ObtenirVueJoursFactPratiRPPRSorti();
            var requete = string.Format(Constantes.RequeteVueReptnPratiRPPR,
                                        intrant.NumeroSeqDispensateur.Any() ? intrant.NumeroSeqDispensateur.First().ToString() : "NULL",
                                        intrant.NumeroSeqDispensateur.Any() ? string.Join(",", intrant.NumeroSeqDispensateur) : "NULL");
            sortant.ListeJoursFactParRPPR = _clientAccessDonne.ExecuterRequeteSQL<JoursFactParRPPR>(requete, new List<string>()
            {
               
                intrant.DateServiceDateDebutPerRechr.ToString(),
                intrant.DateServiceDateDebutPerRechr.ToString(),

                intrant.DateServiceDateFinPerRechr.ToString(),
                intrant.DateServiceDateFinPerRechr.ToString(),

                intrant.CodeRSS,
                intrant.CodeRSS,
                
                intrant.Jours.ToString(),
                intrant.Jours.ToString(),
                intrant.TypeServiceRepartitionPratique,
                intrant.TypeServiceRepartitionPratique,
                intrant.NombreElementsParPage.ToString(),
                intrant.NumeroPage.ToString(),
                intrant.NombreElementsParPage.ToString(),
                intrant.NumeroPage.ToString()
            });
            return sortant;
        }

        /// <summary>
        /// Permet d'obtenir les informations d'exécution en mode massif.
        /// </summary>
        /// <returns>Date de début et de fin de période.</returns>
        public ObtenirInfosExecutionMassiveSorti ObtenirInfosExecutionMassive()
        {
            return _clientAccessDonne.ExecuterProcedure<ObtenirInfosExecutionMassiveSorti>
                    ("PLB1_CalcReptnPratiProf.ObtenirInfosExecutionMass", NomCodeRetourDifferent);

        }

        /// <summary>
        /// Permet d'obtenir les informations d'exécution en mode mensuel.
        /// </summary>
        /// <returns>Date de début et de fin de période.</returns>
        public ObtenirInfosExecutionMensuelSorti ObtenirInfosExecutionMensuel()
        {
            return _clientAccessDonne.ExecuterProcedure<ObtenirInfosExecutionMensuelSorti>
                    ("PLB1_CalcReptnPratiProf.ObtenirInfosExecutionMens", NomCodeRetourDifferent);

        }

        /// <summary>
        /// Permet d'obtenir les informations d'exécution en mode journalier.
        /// </summary>
        /// <returns>Date de début et de fin de période.</returns>
        public ObtenirInfosExecutionJournalierSorti ObtenirInfosExecutionJournalier()
        {
            return _clientAccessDonne.ExecuterProcedure<ObtenirInfosExecutionJournalierSorti>
                    ("PLB1_CalcReptnPratiProf.ObtenirInfosExecutionJourn", NomCodeRetourDifferent);

        }

        /// <summary>
        /// Permet de purger la table de pratique professionnel.
        /// </summary>
        /// <returns>Rien</returns>
        public PurgerTablePratiqueProfessionnelSorti PurgerTablePratiqueProfessionnel()
        {
            return _clientAccessDonne.ExecuterProcedure<PurgerTablePratiqueProfessionnelSorti>
                    ("PLB1_CalcReptnPratiProf.PurgerTablePratiProfJRTerri", NomCodeRetourDifferent);

        }

        /// <summary>
        /// Permet d'exécuter la répartition en mode journalier.
        /// </summary>
        /// <returns>Rien</returns>
        public TraiterRepartitionJournalierSorti TraiterRepartitionJournalier()
        {
            return _clientAccessDonne.ExecuterProcedure<TraiterRepartitionJournalierSorti>
                    ("PLB1_CalcReptnPratiProf.TraitementReptnJournalier", NomCodeRetourDifferent, true);

        }

        /// <summary>
        /// Permet de faire l'obtention des caractéristiques de pratique RSS
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste des caractéristiques de pratique</returns>
        public TraiterRepartitionMensuelMassifSorti TraiterRepartitionMensuelMassif(TraiterRepartitionMensuelMassifEntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<TraiterRepartitionMensuelMassifEntre,
                                                        TraiterRepartitionMensuelMassifSorti>
                    (intrant, "PLB1_CalcReptnPratiProf.TraitementReptnMensuelMassif", NomCodeRetourDifferent, true);
        }

        /// <summary>
        /// Permet l'obtention des territoires RPPR
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste des territoires RPPR</returns>
        public ObtenirTerriRPPRSorti ObtenirTerriRPPR(ObtenirTerriRPPREntre intrant)
        {
            return _clientAccessDonne.ExecuterProcedure<ObtenirTerriRPPREntre,
                                                        ObtenirTerriRPPRSorti>
                    (intrant, "PRE_Pilot_PlanRegnMdcalCnsul.ObtenirTerriRPPR", NomCodeRetourDifferent);
        }

        /// <summary>
        /// Permet l'obtention des engagements des professionnels de la santé
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        public ObtenirVueListeEngagementsSorti ObtenirVueListeEngagements(ObtenirVueListeEngagementsEntre intrant) {
            var sortant = new ObtenirVueListeEngagementsSorti();
            var requete = string.Format(Constantes.RequeteObtenirVueListeEngagements,
                                        intrant.NumerosSequenceDispensateur.Any() ? intrant.NumerosSequenceDispensateur.First().ToString() : "NULL",
                                        intrant.NumerosSequenceDispensateur.Any() ? string.Join(",", intrant.NumerosSequenceDispensateur) : "NULL");
            sortant.Engagements = _clientAccessDonne.ExecuterRequeteSQL<Engagement>(requete, new List<string>()
            {
                intrant.CodesRSS,
                intrant.CodesRSS,
                intrant.DateDebutEngagementRechr.ToString(),
                intrant.DateDebutEngagementRechr.ToString(),
                intrant.DateFinEngagementRechr.ToString(),
                intrant.DateFinEngagementRechr.ToString(),
                intrant.StatutEngagement,
                intrant.StatutEngagement
            });

            return sortant;
        }

        /// <summary>
        /// Permet l'obtention des périodes d'engagement des professionnels de la santé
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        public ObtenirVuePeriodesEngagementsSorti ObtenirVuePeriodesEngagements(ObtenirVuePeriodesEngagementsEntre intrant)
        {
            var sortant = new ObtenirVuePeriodesEngagementsSorti();
            var requete = string.Format(Constantes.RequeteObtenirVuePeriodesEngagements, 
                                        intrant.NumerosSequenceDispensateur.Any() ? intrant.NumerosSequenceDispensateur.First().ToString() : "NULL",
                                        intrant.NumerosSequenceDispensateur.Any() ? string.Join(",", intrant.NumerosSequenceDispensateur) : "NULL");

            sortant.EngagementsPeriode = _clientAccessDonne.ExecuterRequeteSQL<EngagementPeriode>(requete, new List<string>()
            {
                intrant.Type,
                intrant.Type
            }).ToList();

            return sortant;
        }


        /// <summary>
        /// Permet l'obtention de la vue Obtenir la liste du pourcentage de jours facturés des médecins omnipraticiens par avis 
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        public ObtenirVueListPrctJrfacAvisSorti ObtenirVueListPrctJrfacAvis(ObtenirVueListPrctJrfacAvisEntre intrant)
        {
            var sortant = new ObtenirVueListPrctJrfacAvisSorti();
            sortant.LignesRapport = _clientAccessDonne.ExecuterRequeteSQL<PrctJrfacAvis>(Constantes.RequeteObtenirVueListePrctJrfacAvis, new List<string>()
            {
                intrant.Annee.ToString(),
                intrant.Annee.ToString(),
                intrant.CodeRSS,
                intrant.CodeRSS,
                intrant.SousTerritoire,
                intrant.SousTerritoire,
                intrant.SousTerritoire,
                intrant.PourcentageMaximum.ToString(),
                intrant.PourcentageMaximum.ToString()
            }).ToList();

            return sortant;
        }

        /// <summary>
        /// Permet l'obtention de la vue Obtenir la liste du pourcentage de jours facturés des médecins omnipraticiens par dérogations 
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        public ObtenirVueListPrctJrfacDerogSorti ObtenirVueListPrctJrfacDerog(ObtenirVueListPrctJrfacDerogEntre intrant)
        {
            var sortant = new ObtenirVueListPrctJrfacDerogSorti();
            sortant.LignesRapport = _clientAccessDonne.ExecuterRequeteSQL<PrctJrfacDerog>(Constantes.RequeteObtenirVueListePrctJrfacDerog, new List<string>()
            {
                intrant.Annee.ToString(),
                intrant.Annee.ToString(),
                intrant.TypePratique,
                intrant.TypePratique,
                intrant.PourcentageMaximum.ToString(),
                intrant.PourcentageMaximum.ToString()
            }).ToList();

            return sortant;
        }

        /// <summary>
        /// Permet l'obtention de la vue Obtenir la liste du pourcentage de jours facturés des médecins omnipraticiens par répartition inter/intra régionale
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        public ObtenirVueListPrctJrfacTerriSorti ObtenirVueListPrctJrfacTerri(ObtenirVueListPrctJrfacTerriEntre intrant)
        {
            var sortant = new ObtenirVueListPrctJrfacTerriSorti();
            sortant.LignesRapport = _clientAccessDonne.ExecuterRequeteSQL<PrctJrfacTerri>(Constantes.RequeteObtenirVueListePrctJrfacTerri, new List<string>()
            {
                intrant.Annee.ToString(),
                intrant.Annee.ToString(),
                intrant.Region,
                intrant.Region,
                intrant.SousTerritoire,
                intrant.SousTerritoire,
                intrant.SousTerritoire,
                intrant.TypeRepartition,
                intrant.TypeRepartition
            }).ToList();

            return sortant;
        }

        /// <summary>
        /// Permet l'obtention de la vue Obtenir la liste du pourcentage de jours facturés des médecins omnipraticiens en RPPR 
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        public ObtenirVueListPrctJrfacRPPRSorti ObtenirVueListPrctJrfacRPPR(ObtenirVueListPrctJrfacRPPREntre intrant)
        {
            var sortant = new ObtenirVueListPrctJrfacRPPRSorti();
            sortant.LignesRapport = _clientAccessDonne.ExecuterRequeteSQL<PrctJrfacRPPR>(Constantes.RequeteObtenirVueListePrctJrfacRPPR, new List<string>()
            {
                intrant.Annee.ToString(),
                intrant.Annee.ToString(),
                intrant.Region,
                intrant.Region,
                intrant.PourcentageMinimum.ToString(),
                intrant.PourcentageMinimum.ToString(),
                intrant.NbreJoursTotalMinimum.ToString(),
                intrant.NbreJoursTotalMinimum.ToString(),
                intrant.DisNoSeq.HasValue ? intrant.DisNoSeq.Value.ToString() : "NULL",
                intrant.DisNoSeq.HasValue ? intrant.DisNoSeq.Value.ToString() : "NULL"
            }).ToList();

            return sortant;
        }

        /// <summary>
        /// Permet de modifier la raison de fermeture du statut de l'engagement
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        public ModifierRaisFermStatutEngagSorti ModifierRaisFermStatutEngag(ModifierRaisFermStatutEngagEntre intrant)
        {
            return _clientAccessDonne.ExecuterProc<ModifierRaisFermStatutEngagEntre,
                                                        ModifierRaisFermStatutEngagSorti>
                   (intrant, "PRE_PREMQ_PlanRegnMdcalMAJ.ModifierRaisFermStatEngag", NomCodeRetourDifferent);
        }


        /// <summary>
        /// Permet de modifier une Autorisation d'un professionnel de la santé
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Le nouveau numéro séquentiel de l'autorisation</returns>
        public ModifierAutorisationSorti ModifierAutorisation(ModifierAutorisationEntre intrant)
        {
            return _clientAccessDonne.ExecuterProc<ModifierAutorisationEntre,
                                                       ModifierAutorisationSorti>
                  (intrant, "PRE_PREMQ_PlanRegnMdcalMAJ.ModifierAutorisation", NomCodeRetourDifferent);
        }
        #endregion
    }
}