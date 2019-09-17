using RAMQ.Message;
using RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.AjusterEngagement.Param;
using RAMQ.PRE.PRE_Entites_cpo.Autorisation.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.DemandeReevaluation.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Derogation.Entite;
using RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntiteCPO = RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre;
using EntiteCPOAvis = RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Entite;

namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo
{
    /// <summary>
    /// Interface des avis de conformité du medecin omnipraticien - periode de non participation 
    /// </summary>
    public interface IAjusterEngagAvisConfNonParticipation
    {

        #region Appel BizTalk
        /// <summary>
        /// Permet de traiter/Ajuster un engagement du medecin omnipraticiem à une date de non participation inscrite
        /// </summary>
        /// <param name="param"></param>
        /// <param name="operationEvt"></param>
        /// <returns></returns>
        AjusEngagAjouNonPartnSorti TraiterEngagementInscriptionDateNonParticipation(AjusEngagAjouNonPartnEntre param, OperationEvt operationEvt);

        /// <summary>
        /// Permet de traiter un engagement du medecin omnipraticien pour lequel une periode de non participation est annulée
        /// </summary>
        /// <param name="param"></param>
        /// <param name="operationEvt"></param>
        /// <returns></returns>
        AjusEngagAnnuNonPartnSorti TraiterEngagementAnnuDateNonParticipation(AjusEngagAnnuNonPartnEntre param, OperationEvt operationEvt);

        /// <summary>
        /// Permet de traiter un engagement du medecin omnipraticien pour lequel une periode de non participation est modifiée
        /// </summary>
        /// <param name="param"></param>
        /// <param name="operationEvt"></param>
        /// <returns></returns>
        AjusEngagModifNonPartnSorti TraiterEngagementModifDateNonParticipation(AjusEngagModifNonPartnEntre param, OperationEvt operationEvt);

        /// <summary>
        /// Permet de traiter un engagement du medecin omnipraticien pour lequel une date de debut de spécialité ou date de decès a été inscrite
        /// </summary>
        /// <param name="param"></param>
        /// <param name="operationEvt"></param>
        /// <returns></returns>
        AjusEngagDdSpecInscrSorti TraiterEngagementPremiereSpecialiteDeces(AjusEngagDdSpecInscrEntre param, OperationEvt operationEvt);

        /// <summary>
        /// Permet de traiter un engagement du medecin omnipraticien pour lequel une date de decès été inscrite
        /// </summary>
        /// <param name="param"></param>
        /// <param name="operationEvt"></param>
        /// <returns></returns>
        AjusEngagDecesSorti TraiterEngagementDeces(AjusEngagDecesEntre param, OperationEvt operationEvt);
        #endregion

        #region methodes publiques

        #region Engagements medecin Particien

        #region avis conformites
        /// <summary>
        /// Permet d'obtenir les avis de conformités du professionnel
        /// </summary>
        /// <param name="objParamEntree"></param>
        /// <returns></returns>
        ObtenirLesAvisConformiteSorti ObtenirLesEngagementsPratiquesProfessionnel(ObtenirLesAvisConformiteEntre objParamEntree);


        /// <summary>
        /// Permet de Modifier la période d'un avis de conformité à la date de non participation
        /// </summary>
        /// <param name="objParamEntree"></param>
        /// <returns></returns>
        ModifierPeriodeAvisSorti ModifierPeriodeLesAvisConformites(ModifierPeriodeAvisEntre objParamEntree);


        /// <summary>
        /// Permet de Modifier la raison de fermeture du statut de l'engagement
        /// </summary>
        /// <param name="objParamEntree"></param>
        /// <returns></returns>
        ModifierRaisFermStatutEngagSorti ModifierRaisonFermetureStatEngag(ModifierRaisFermStatutEngagEntre objParamEntree);

        /// <summary>
        /// Permet de traiter/Ajuster un engagement du medecin omnipraticiem à une date de non participation inscrite
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Obsolete("TraiterEngagementDateNonParticipation")]
        AjusEngagAjouNonPartnSorti TraiterEngagDateNonParticipation(AjusEngagAjouNonPartnEntre param, OperationEvt operationEvt);

        /// <summary>
        /// Permet de saisir une demande de réévaluation pour un professionnel de la santé
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns>Les dates réelles de la demande<</returns>
        SaisirDemandeReevaluationSorti SaisirDemandeReevaluation(SaisirDemandeReevaluationEntre intrant);

        /// <summary>
        /// permet d'otenir les avis de conformites  du medecin omnipraticien anterieures ou posterieurs à la date de debut de non participation
        /// </summary>
        /// <param name="numseqDispensateur"></param>
        /// <param name="datDebNonPartn"></param>
        /// <param name="post">si vraie ,les avis de conformites posterieurs sont retournés sinon les anterieures</param>
        /// <returns></returns>
        List<EntiteCPOAvis.AvisConformite> ObtenirLesAvisConfPostProfessionnel(long numseqDispensateur, DateTime datDebNonPartn, bool post);

        /// <summary>
        /// Ferme l'avis de conformité actif à la periode de non-participation -1 jour
        /// </summary>
        /// <param name="lstObjParamEntree"></param>
        /// <param name="datDebNonPartn"></param>
        /// <param name="codRaisonStatutEntre"></param>
        /// <returns></returns>
        IList<IMsgTrait> FermerAvisConfProfessionel(List<EntiteCPOAvis.AvisConformite> lstObjParamEntree, DateTime datDebNonPartn, string codRaisonStatutEntre);


        /// <summary>
        /// Annulation des avis de conformités postérieurs à la date dde debut de non participation
        /// </summary>
        /// <param name="numeroSequentielDispensateur"></param>
        /// <param name="datDebNonPartn"></param> 
        /// <param name="codeRaisonStatutAvisConf"></param> 
        IList<IMsgTrait> AnnulerAvisConf(long numeroSequentielDispensateur, DateTime datDebNonPartn, string codeRaisonStatutAvisConf);

        /// <summary>
        /// permet d'obtenir les avis conformites Fermées ou annulées  du medecin omnipraticien 
        /// </summary>
        /// <param name="numseqDispensateur"></param>
        /// <param name="datDebNonPartn"></param>
        /// <param name="ferme"></param>
        /// <returns>si ferme est vraie, les avis conformites fermés à la date de non participation ayant le code 21 avec Statut=TER,sinon 
        ///            retourne les avis conformites annulés
        List<EntiteCPOAvis.AvisConformite> ObtenirLesAvisConfFermeesAnnulees(long numseqDispensateur, DateTime datDebNonPartn, bool ferme);

        /// <summary>
        /// permet d'inactiver l'avis de conformité terminé
        /// </summary>
        /// <param name="avis"></param>
        /// <returns></returns>
        ModifierAvisConformiteStatutSorti InactiverAvisConformiteTermine(EntiteCPOAvis.AvisConformite avis);


        /// <summary>
        /// permet de reactiver -creer un avis de confimité suite à une annulation 
        /// </summary>
        /// <param name="avisInactif"></param>
        /// <param name="dateNonParticipation"></param>
        /// <param name="avisferme"></param>
        /// <param name="codRaisonStatut"></param>
        /// <returns></returns>
        CreerAvisConformiteSorti ReactiverAvisConformite(EntiteCPOAvis.AvisConformite avisInactif, DateTime dateNonParticipation, bool avisferme, string codRaisonStatut);

        /// <summary>
        /// permet d'inactiver et creer à nouveau les differents status de l'avis de conformité
        /// </summary>
        /// <param name="avis"></param>
        /// <param name="nouvAvisConf"></param>
        /// <param name="numSeqStatEngag"></param>
        /// <param name="ferme"></param>
        /// si ferme est vraie, les avis conformites fermés sont traités sinon les avis annulés
        IList<IMsgTrait> InactivationCreationStatuts(EntiteCPOAvis.AvisConformite avis, ObtenirLesAvisConformiteSorti nouvAvisConf, long numSeqStatEngag, bool ferme);


        /// <summary>
        /// Permet de Reactiver les differents status de l'avis de conformités avant fermeture pour raison de non participation
        /// </summary>
        /// <param name="avisConformites"></param>
        /// <param name="numeroSequentielDispensateur"></param>
        /// <param name="dateNonParticipation"></param>
        /// <param name="ferme"></param>
        /// <param name="codRaisonStatutEntre"></param>
        /// si ferme est vraie, les avis conformites fermés sont traités sinon les avis annulés
        IList<IMsgTrait> ReactivationAvisConfFermeAnnule(List<EntiteCPOAvis.AvisConformite> avisConformites, long numeroSequentielDispensateur, DateTime dateNonParticipation, bool ferme, CodRaisonStatutEntre codRaisonStatutEntre);

        /// <summary>
        /// permet d'obtenir le nombre les differents stauts distinct de l'avis de conformité
        /// </summary>
        /// <param name="avis"></param>
        /// <returns></returns>
        int ObtenirNombreStatutsAvisConformite(EntiteCPOAvis.AvisConformite avis);

        /// <summary>
        /// permet de recuperer la date du prochain engagement annule de la sequence 
        /// </summary>
        /// <param name="numeroSequentielDispensateur"></param>
        /// <param name="avis"></param>
        /// <param name="statutEngagement"></param>
        /// <param name="dateNonParticipation"></param>
        /// <returns></returns>
        DateTime? ObtenirDateProchainEngagementAnnuledelaSequence(long numeroSequentielDispensateur, EntiteCPOAvis.AvisConformite avis, string statutEngagement,DateTime dateNonParticipation);

        #endregion


        /// <summary>
        /// Permet de faire l'obtention de la liste des statuts engagement pratique RSS 
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste des statuts engagement pratique RSS</returns>
        ObtenirStatutsEngagementPratiqueRSSSorti ObtenirStatutsEngagementPratiqueRSS(ObtenirStatutsEngagementPratiqueRSSEntre intrant);


        /// <summary>
        /// le numero de sequence du statur de l'engagement
        /// </summary>
        /// <param name="numeroSequentielEngagement"></param>
        /// <param name="dateNonParticipation"></param>
        /// <param name="statutEngagement"></param>
        /// <returns></returns>
        long ObtenirNumSeqStatutEngagementPratique(long numeroSequentielEngagement, DateTime dateNonParticipation, string statutEngagement);

        #region Derogation
        /// <summary>
        /// permet d'otenir les derogations actives du medecin omnipraticien anterieures ou posterieurs à la date de debut de non participation
        /// </summary>
        /// <param name="numseqDispensateur"></param>
        /// <param name="datDebNonPartn"></param>
        /// <param name="post">si vraie ,les derogations posterieurs sont retournées sinon les anterieures</param>
        /// <returns></returns>
        List<Derogation> ObtenirLesDerogationsActivPostProfessionnel(long numseqDispensateur, DateTime datDebNonPartn, bool post);

        /// <summary>
        /// Ferme la derogation à la periode de non-participation -1 jour
        /// </summary>
        /// <param name="objParamEntree"></param>
        /// <param name="datDebNonPartn"></param>
        /// <returns></returns>
        ModifierDerogationSorti FermerDerogationProfessionel(ModifierDerogationEntre objParamEntree, DateTime datDebNonPartn);

        /// <summary>
        /// Annule la derogation posterieure à la date de non de participation du medecin omnipraticien
        /// </summary>
        /// <param name="objParamEntree"></param>
        /// <returns></returns>
        ModifierDerogationSorti AnnulationDerogationPosterieurDateNonPartipation(ModifierDerogationEntre objParamEntree);


        /// <summary>
        /// Traitement de derogation(s) d'un medecin omnipraticien qui devient non-participant
        /// </summary>
        /// <param name="numeroSequentielDispensateur"></param>
        /// <param name="datDebNonPartn"></param>
        /// <param name="codRaisonStatut"></param>    
        /// <param name="estModifie"></param>   
        //TraiterEngagementSorti TraiterDerogationDateNonParticipation(long numeroSequentielDispensateur, DateTime datDebNonPartn, string codRaisonStatut);
        TraiterEngagementSorti TraiterDerogationDateNonParticipation(long numeroSequentielDispensateur, DateTime datDebNonPartn, string codRaisonStatut,bool estModifie);

        /// <summary>
        /// permet d'obtenir les derogations Fermées ou annulées  du medecin omnipraticien 
        /// </summary>
        /// <param name="numseqDispensateur"></param>
        /// <param name="datDebNonPartn"></param>
        /// <param name="ferme"></param>
        /// <param name="codRaisonStatutEntre"></param>
        /// <returns>
        /// Non-Participation :si ferme est vraie, les derogations fermées à la date de non participation ayant le code 7 avec Statut=TER,sinon 
        ///            retourne les derogations annulées code= 7 et statut=ANN
        /// 1ère Specialite :code derogation fermée /annulée : 02
        List<Derogation> ObtenirLesDerogationsProfessionnelFermeesAnnulees(long numseqDispensateur, DateTime datDebNonPartn, bool ferme, string codRaisonStatutEntre);

        /// <summary>
        /// Reactive la derogation suite à une annulation de periode de non admissibilité
        /// </summary>
        /// <param name="objParamEntree"></param>       
        /// <returns></returns>
        ModifierDerogationSorti ReactivationDerogationProfessionel(ModifierDerogationEntre objParamEntree);


        /// <summary>
        /// permet d'otenir les derogations actives(TER ou ANN) du medecin omnipraticien anterieures ou posterieurs à la date de debut de non participation avant modification
        /// </summary>
        /// <param name="numseqDispensateur"></param>
        /// <param name="datDebNonPartn"></param>
        /// <param name="post">si vraie ,les derogations posterieurs sont retournées sinon les anterieures</param>
        /// <returns></returns>
        List<PRE_Entites_cpo.Derogation.Entite.Derogation> ObtenirLesDerogModifActivPostProfessionnel(long numseqDispensateur, DateTime datDebNonPartn, bool post);

        #endregion

        #region Autorisation      
        /// <summary>
        /// permet d'obtenir les Autorisations  du medecin omnipraticien anterieures ou posterieurs à la date de debut de non participation
        /// </summary>
        /// <param name="numseqDispensateur"></param>
        /// <param name="datDebNonPartn"></param>
        /// <param name="post">si vraie ,les autorisations posterieurs sont retournées sinon les anterieures</param>
        /// <returns></returns>
        List<PL_LogiqueAffaire_cpo.Entites.Autorisation> ObtenirLesAutorisationsActivPostProfessionnel(long numseqDispensateur, DateTime datDebNonPartn, bool post);

        List<PL_LogiqueAffaire_cpo.Entites.Autorisation> ObtenirLesAutorisationsModifActivPostProfessionnel(long numseqDispensateur, DateTime datDebNonPartn, bool post);
        /// <summary>
        /// Ferme l'autorisation à la periode de non-participation -1 jour
        /// </summary>
        /// <param name="objParamEntree"></param>
        /// <param name="datDebNonPartn"></param>
        /// <returns></returns>
        ModifierAutorisationSorti FermerAutorisationProfessionel(ModifierAutorisationEntre objParamEntree, DateTime datDebNonPartn);

        /// <summary>
        /// Annule l'autorisation posterieure à la date de non de participation du medecin omnipraticien
        /// </summary>
        /// <param name="objParamEntree"></param>
        /// <returns></returns>
        ModifierAutorisationSorti AnnulationAutorisationPosterieurDateNonPartipation(ModifierAutorisationEntre objParamEntree);


        /// <summary>
        /// Traitement de(s) autorisation(s) d'un medecin omnipraticien qui devient non-participant
        /// </summary>
        /// <param name="numeroSequentielDispensateur"></param>
        /// <param name="datDebNonPartn"></param>
        /// <param name="codeRaisonStatutAutorisation"></param>        
       // TraiterEngagementSorti TraiterAutorisationDateNonParticipation(long numeroSequentielDispensateur, DateTime datDebNonPartn, CodeRaisonStatutAutorisation codeRaisonStatutAutorisation);
        TraiterEngagementSorti TraiterAutorisationDateNonParticipation(long numeroSequentielDispensateur, DateTime datDebNonPartn, CodeRaisonStatutAutorisation codeRaisonStatutAutorisation,bool estModifie);

        /// <summary>
        /// permet d'obtenir les Autorisations Fermées ou annulées du medecin omnipraticien 
        /// </summary>
        /// <param name="numseqDispensateur"></param>
        /// <param name="datDebNonPartn"></param>
        /// <param name="ferme"></param>
        /// <param name="codRaisonStatutEntre"></param>
        /// <returns>
        /// Date Non participation : si ferme est vraie, les autorisations fermées à la date de non participation ayant le code 3 avec Statut=TER,sinon 
        ///            retourne les autorisations annulées code= 7 et statut=ANN
        /// Date 1ère Spec : autorisation dermée : 05 , autorisation annulée : 08           
        /// </returns>
        List<PL_LogiqueAffaire_cpo.Entites.Autorisation> ObtenirLesAutorisationsProfessionnelFermeesAnnulees(long numseqDispensateur, DateTime datDebNonPartn, bool ferme, string codRaisonStatutEntre);

        /// <summary>
        /// Reactive l'autorisation suite à une Fermeture /annulation de periode de non admissibilité
        /// </summary>
        /// <param name="objParamEntree"></param>       
        /// <returns></returns>
        ModifierAutorisationSorti ReactivationAutorisationProfessionel(ModifierAutorisationEntre objParamEntree);

        #endregion

        #endregion

        #endregion

        #region methode Communes
        /// <summary>
        /// Permet de reactiver toute derogation fermée ou annulée pour raison de non particpation
        /// </summary>
        /// <param name="numeroSequentielDispensateur"></param>
        /// <param name="lstDerogFermees"></param>
        /// <param name="lstDerogAnnulees"></param>
        /// <param name="dateNonParticipation"></param>
        /// <returns></returns>    
        TraiterEngagementSorti ReactiverDerogation(long numeroSequentielDispensateur, List<PRE_Entites_cpo.Derogation.Entite.Derogation> lstDerogFermees,
                                           List<PRE_Entites_cpo.Derogation.Entite.Derogation> lstDerogAnnulees, DateTime dateNonParticipation);

        /// <summary>
        /// Permet de reactiver toute Autorisation fermée ou annulée pour raison de non particpation
        /// </summary>
        /// <param name="numeroSequentielDispensateur"></param>
        /// <param name="lstAutorisationFermees"></param>
        /// <param name="lstAutorisationAnnulees"></param>
        /// <returns></returns>     
        TraiterEngagementSorti ReactiverAutorisation(long numeroSequentielDispensateur, List<PL_LogiqueAffaire_cpo.Entites.Autorisation> lstAutorisationFermees,
                                                List<PL_LogiqueAffaire_cpo.Entites.Autorisation> lstAutorisationAnnulees);

        /// <summary>
        /// Permet de reactiver toute avis de conformite fermée ou annulée pour raison de non particpation
        /// </summary>
        /// <param name="numeroSequentielDispensateur"></param>
        /// <param name="dateNonParticipation"></param>
        /// <param name="avisConfFermees"></param>
        /// <param name="avisConfAnnulees"></param>
        /// <param name="codRaisonStatutEntre"></param>
        /// <returns></returns> 
        TraiterEngagementSorti ReactiverAvis(long numeroSequentielDispensateur, DateTime dateNonParticipation, List<EntiteCPOAvis.AvisConformite> avisConfFermees,
                                        List<EntiteCPOAvis.AvisConformite> avisConfAnnulees, CodRaisonStatutEntre codRaisonStatutEntre);

        /// <summary>
        /// Permet de veifier si il ya eu des modifications au dossier du medecin , si oui envoie un courriel
        /// </summary>
        /// <returns></returns>
        bool VerificationMAJDossier(ObtenirDispensateurIndividuEntre param, DateTime dDNonPartn, EnvoyCourlEntre objParamEntreCourl, OperationEvt operationEvt);

        /// <summary>
        /// permet de verifier si il n,ya pas eu de modification au dossier du medecin omnipraticien et si il n'ya pas eu de nouveau engagement apres la date de non partcipation
        /// si oui un courriel est envoyé
        /// </summary>
        /// <param name="noSeqIntervenant"></param>
        /// <param name="dateNParticipation"></param>
        /// <param name="operationEvt"></param>
        /// <returns></returns>
        bool VerifierMAJDossierEngagement(long noSeqIntervenant, DateTime dateNParticipation, OperationEvt operationEvt);

        /// <summary>
        /// envoi de courriel
        /// </summary>
        /// <param name="objParamEntre"></param>
        /// <param name="raisonCourriel"></param>
        /// <param name="contenuMsg"></param>
        bool EnvoyerCourlConfr(EnvoyCourlEntre objParamEntre, EnumRaisonCourriel raisonCourriel, ContenuCourlEntre contenuMsg);

        /// <summary>
        /// Permet de verifier il s'agit d'une modification ou retrait de date de spécialité
        /// </summary>
        /// <param name="param"></param>
        /// <returns>True si il s'agit d'une modification ou retrait de date de spécialité sinon retourne False pour l'ajout de la 1ère date de spécialité</returns>
        bool? VerificationMiseAJourDatePremSpec(AjusEngagDdSpecInscrEntre param);
        #endregion

    }
}
