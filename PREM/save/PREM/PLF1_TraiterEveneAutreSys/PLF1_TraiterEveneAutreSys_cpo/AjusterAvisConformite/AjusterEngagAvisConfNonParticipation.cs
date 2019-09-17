using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.AvisConformite;
using RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.AjusterEngagement.Param;
using RAMQ.PRE.PRE_Entites_cpo.DemandeReevaluation.Parametre;
using RAMQ.PRE.PRE_OutilComun_cpo;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Derogation;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Autorisation;
using RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre;
using LAAutorisatonParametres = RAMQ.PRE.PL_LogiqueAffaire_cpo.Parametres;
using RAMQ.PRE.PRE_Entites_cpo.Autorisation.Parametre;
using EntiteCPOAvis = RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Entite;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Professionnel;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using System.Dynamic;
using RAMQ.Message;
using RAMQ.Courriel;
using RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.AjusterEngagement.Constante;
using System.Collections;
using RAMQ.Enumeration;
using RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.AjusterEngagement.Entite;

namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class AjusterEngagAvisConfNonParticipation : IAjusterEngagAvisConfNonParticipation
    {

        #region Attributs privés

        private readonly IAvisConformite _avisConformite;
        private readonly IDerogation _derogation;
        private readonly IAutorisation _autorisation;
        private readonly IRechercherProfessionnel _professionnel;
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur par defaut
        /// </summary>
        /// <param name="avisconformite"></param>
        /// <param name="derogation"></param>
        /// <param name="autorisation"></param>
        /// <param name="professionnel"></param>
        public AjusterEngagAvisConfNonParticipation(IAvisConformite avisconformite, IDerogation derogation, IAutorisation autorisation, IRechercherProfessionnel professionnel)
        {
            if (avisconformite == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(avisconformite)} ne peut être null .");
            }
            if (derogation == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(derogation)} ne peut être null .");
            }
            if (autorisation == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(autorisation)} ne peut être null .");
            }
            if (professionnel == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(professionnel)} ne peut être null .");
            }

            _avisConformite = avisconformite;
            _derogation = derogation;
            _autorisation = autorisation;
            _professionnel = professionnel;
        }

        #endregion

        #region Appel BizTalk
        /// <summary>
        /// Permet de traiter/Ajuster un engagement du medecin omnipraticiem à une date de non participation inscrite
        /// </summary>
        /// <param name="param"></param>
        /// <param name="operationEvt"></param>
        /// <returns></returns>
        public AjusEngagAjouNonPartnSorti TraiterEngagementInscriptionDateNonParticipation(AjusEngagAjouNonPartnEntre param, OperationEvt operationEvt)
        {
            CodRaisonStatutEntre codRaisonStatutEntre = CreerParametreCodeRaisonStatutEntre(operationEvt);

            AjusEngagAjouNonPartnSorti extrant = new AjusEngagAjouNonPartnSorti();
            var messagesErreurs = new List<IMsgTrait>();
            if (param != null)
            {
                long numeroSequentielDispensateur = param.NoSeqIntervenant;
                DateTime dateNonParticipation = param.NouvPerAdmis.Dd;

                #region Avis conformite                
                var resultTraiterAvis = TraiterAvisConfDateNonParticipation(numeroSequentielDispensateur, dateNonParticipation, codRaisonStatutEntre.CodeRaisonStatutAvisConf);
                messagesErreurs.AddRange(resultTraiterAvis.InfoMsgTrait);

                #endregion

                #region Derogation

                var resultTraiterDerogation = TraiterDerogationDateNonParticipation(numeroSequentielDispensateur, dateNonParticipation, codRaisonStatutEntre.CodeRaisonStatutDerogation, false);
                messagesErreurs.AddRange(resultTraiterDerogation.InfoMsgTrait);

                #endregion

                #region Autorisation

                //var resultTraiterAutorisation = TraiterAutorisationDateNonParticipation(numeroSequentielDispensateur, dateNonParticipation, codRaisonStatutEntre.CodeRaisonStatutAutorisation);
                var resultTraiterAutorisation = TraiterAutorisationDateNonParticipation(numeroSequentielDispensateur, dateNonParticipation, codRaisonStatutEntre.CodeRaisonStatutAutorisation, false);
                messagesErreurs.AddRange(resultTraiterAutorisation.InfoMsgTrait);
                #endregion

                //CAll PLE1
                #region Appel PLE1 - Fin du Process             
                DateTime dateJour = DateTime.Today;
                if ((resultTraiterAvis.EstTraite || resultTraiterDerogation.EstTraite || resultTraiterAutorisation.EstTraite) && dateNonParticipation < dateJour)
                {
                    var datDeb = dateNonParticipation;
                    var datFin = dateJour;

                    messagesErreurs.AddRange(AppelPLE1(param.NoSeqIntervenant, datDeb, datFin));
                    #endregion

                    if (messagesErreurs.Count > 0)
                    {
                        extrant.InfoMsgTrait = messagesErreurs;

                    }
                }
            }

            return extrant;
        }

        /// <summary>
        /// Permete de Traiter un engament de medecin omnipraticien pour lequel une periode de non participation est annulée
        /// </summary>
        /// <param name="param"></param>
        /// <param name="operationEvt"></param>
        /// <returns></returns>
        public AjusEngagAnnuNonPartnSorti TraiterEngagementAnnuDateNonParticipation(AjusEngagAnnuNonPartnEntre param, OperationEvt operationEvt)
        {
            CodRaisonStatutEntre codRaisonStatutEntre = CreerParametreCodeRaisonStatutEntre(operationEvt);
            AjusEngagAnnuNonPartnSorti extrant = new AjusEngagAnnuNonPartnSorti();
            var messagesErreurs = new List<IMsgTrait>();

            if (param != null)
            {
                long numeroSequentielDispensateur = param.NoSeqIntervenant;

                DateTime dateNonParticipation = param.PerAdmisAnnu.Dd;

                //--si aucun changement , reactiver les engagements
                if (!VerifierMAJDossierEngagement(numeroSequentielDispensateur, dateNonParticipation, operationEvt))
                {

                    #region Reactivativation Avis Conformites
                    var messagesErreursAvis = new List<IMsgTrait>();
                    var avisConfFermees = ObtenirLesAvisConfFermeesAnnulees(numeroSequentielDispensateur, dateNonParticipation, true);
                    var avisAnnulee = ObtenirLesAvisConfFermeesAnnulees(numeroSequentielDispensateur, dateNonParticipation, false);

                    var resultTraiterAvis = ReactiverAvis(numeroSequentielDispensateur, dateNonParticipation, avisConfFermees, avisAnnulee, codRaisonStatutEntre);
                    messagesErreurs.AddRange(resultTraiterAvis.InfoMsgTrait);
                    #endregion

                    #region Reactivation des derogations Fermee et annulees

                    var messagesErreursDerogation = new List<IMsgTrait>();
                    List<PRE_Entites_cpo.Derogation.Entite.Derogation> derogationsFermees = ObtenirLesDerogationsProfessionnelFermeesAnnulees(numeroSequentielDispensateur, dateNonParticipation, true, codRaisonStatutEntre.CodeRaisonStatutDerogation);
                    List<PRE_Entites_cpo.Derogation.Entite.Derogation> derogationsAnnulees = ObtenirLesDerogationsProfessionnelFermeesAnnulees(numeroSequentielDispensateur, dateNonParticipation, false, codRaisonStatutEntre.CodeRaisonStatutDerogation);

                    var resultTraiterDerogation = ReactiverDerogation(numeroSequentielDispensateur, derogationsFermees, derogationsAnnulees, dateNonParticipation);
                    messagesErreurs.AddRange(resultTraiterDerogation.InfoMsgTrait);
                    #endregion

                    #region Reactivation des autorisations
                    var messagesErreursAutorisation = new List<IMsgTrait>();
                    List<PL_LogiqueAffaire_cpo.Entites.Autorisation> autorisationsFermees = ObtenirLesAutorisationsProfessionnelFermeesAnnulees(numeroSequentielDispensateur, dateNonParticipation, true, codRaisonStatutEntre.CodeRaisonStatutAutorisation.Fermeture);
                    List<PL_LogiqueAffaire_cpo.Entites.Autorisation> autorisationsAnnulees = ObtenirLesAutorisationsProfessionnelFermeesAnnulees(numeroSequentielDispensateur, dateNonParticipation, false, codRaisonStatutEntre.CodeRaisonStatutAutorisation.Annulation);


                    var resultTraiterAutorisation = ReactiverAutorisation(numeroSequentielDispensateur, autorisationsFermees, autorisationsAnnulees);
                    messagesErreurs.AddRange(resultTraiterAutorisation.InfoMsgTrait);

                    #endregion



                    //CAll PLE1
                    #region Appel PLE1 - Fin du Process             
                    DateTime dateJour = DateTime.Today;
                    if ((resultTraiterAvis.EstTraite || resultTraiterDerogation.EstTraite || resultTraiterAutorisation.EstTraite) && dateNonParticipation < dateJour)
                    {
                        var datDeb = dateNonParticipation;
                        var datFin = dateJour;
                        messagesErreurs.AddRange(AppelPLE1(param.NoSeqIntervenant, datDeb, datFin));
                    }
                    #endregion


                    if (messagesErreurs.Count > 0)
                    {
                        extrant.InfoMsgTrait = messagesErreurs;
                    }
                }
            }

            return extrant;

        }

        /// <summary>
        /// Permete de Traiter un engament de medecin omnipraticien pour lequel une periode de non participation est modifiée
        /// </summary>
        /// <param name="param"></param>
        /// <param name="operationEvt"></param>
        /// <returns></returns>
        public AjusEngagModifNonPartnSorti TraiterEngagementModifDateNonParticipation(AjusEngagModifNonPartnEntre param, OperationEvt operationEvt)
        {
            TraiterEngagementSorti resultTraiterAvis = new TraiterEngagementSorti();
            TraiterEngagementSorti resultTraiterDerogation = new TraiterEngagementSorti();
            TraiterEngagementSorti resultTraiterAutorisation = new TraiterEngagementSorti();
            CodRaisonStatutEntre codRaisonStatutEntre = CreerParametreCodeRaisonStatutEntre(operationEvt);

            long numeroSequentielDispensateur = param.NoSeqIntervenant;

            DateTime ancDateNonParticipation = param.PerAdmisOrign.Dd;
            DateTime nouvDateNonParticipation = param.PerAdmisModif.Dd;
            AjusEngagModifNonPartnSorti extrant = new AjusEngagModifNonPartnSorti();
            var messagesErreurs = new List<IMsgTrait>();

            if (param != null)
            {
                if (!VerifierMAJDossierEngagement(numeroSequentielDispensateur, ancDateNonParticipation, operationEvt))
                {
                    //--aucune MAJ au dossier
                    var messagesErreursDerogation = new List<IMsgTrait>();
                    var messagesErreursAutorisation = new List<IMsgTrait>();
                    var messagesErreursAvisConf = new List<IMsgTrait>();

                    if (nouvDateNonParticipation > ancDateNonParticipation)
                    {
                        //***************A6
                        #region Reactivation des avis conformites Fermes et annules à l'ancienne date de non participation
                        var avisConfFermees = ObtenirLesAvisConfFermeesAnnulees(numeroSequentielDispensateur, ancDateNonParticipation, true);
                        var avisAnnulee = ObtenirLesAvisConfFermeesAnnulees(numeroSequentielDispensateur, ancDateNonParticipation, false);

                        resultTraiterAvis = ReactiverAvis(numeroSequentielDispensateur, ancDateNonParticipation, avisConfFermees, avisAnnulee, codRaisonStatutEntre);
                        messagesErreursAvisConf.AddRange(resultTraiterAvis.InfoMsgTrait);
                        messagesErreurs.AddRange(messagesErreursAvisConf);
                        #endregion

                        #region Reactivation des derogations Fermee et annulees à l'ancienne date de non participation
                        var lstDerogFermees = ObtenirLesDerogationsProfessionnelFermeesAnnulees(numeroSequentielDispensateur, ancDateNonParticipation, true, codRaisonStatutEntre.CodeRaisonStatutDerogation);
                        var lstDerogAnnulees = ObtenirLesDerogationsProfessionnelFermeesAnnulees(numeroSequentielDispensateur, ancDateNonParticipation, false, codRaisonStatutEntre.CodeRaisonStatutDerogation);

                        resultTraiterDerogation = ReactiverDerogation(numeroSequentielDispensateur, lstDerogFermees, lstDerogAnnulees, ancDateNonParticipation);
                        messagesErreursDerogation.AddRange(resultTraiterDerogation.InfoMsgTrait);
                        messagesErreurs.AddRange(messagesErreursDerogation);
                        #endregion

                        #region  Reactivation des autorisations Fermee et annulees à l'ancienne date de non participation                       
                        var autorisationsFermees = ObtenirLesAutorisationsProfessionnelFermeesAnnulees(numeroSequentielDispensateur, ancDateNonParticipation, true, codRaisonStatutEntre.CodeRaisonStatutAutorisation.Fermeture);
                        var autorisationsAnnulees = ObtenirLesAutorisationsProfessionnelFermeesAnnulees(numeroSequentielDispensateur, ancDateNonParticipation, false, codRaisonStatutEntre.CodeRaisonStatutAutorisation.Annulation);

                        resultTraiterAutorisation = ReactiverAutorisation(numeroSequentielDispensateur, autorisationsFermees, autorisationsAnnulees);
                        messagesErreursAutorisation.AddRange(resultTraiterAutorisation.InfoMsgTrait);
                        messagesErreurs.AddRange(messagesErreursAutorisation);
                        #endregion

                    }

                    //**********A4 avec particularité
                    #region Fermeture et annulation des avis de conformites à la nouvelle date de non participation

                    resultTraiterAvis = TraiterAvisConfDateNonParticipation(numeroSequentielDispensateur, nouvDateNonParticipation, codRaisonStatutEntre.CodeRaisonStatutAvisConf);
                    messagesErreursAvisConf.AddRange(resultTraiterAvis.InfoMsgTrait);
                    messagesErreurs.AddRange(messagesErreursAvisConf);
                    #endregion


                    if (nouvDateNonParticipation < ancDateNonParticipation)
                    {
                        #region Fermeture et annulation des derogations à la nouvelle date de non participation                       
                        resultTraiterDerogation = TraiterDerogationDateNonParticipation(numeroSequentielDispensateur, nouvDateNonParticipation, codRaisonStatutEntre.CodeRaisonStatutDerogation, true);
                        messagesErreursDerogation.AddRange(resultTraiterDerogation.InfoMsgTrait);
                        messagesErreurs.AddRange(messagesErreursDerogation);
                        #endregion

                        #region Fermeture et annulation des autorisations à la nouvelle date de non participation                     
                        resultTraiterAutorisation = TraiterAutorisationDateNonParticipation(numeroSequentielDispensateur, nouvDateNonParticipation, codRaisonStatutEntre.CodeRaisonStatutAutorisation, true);
                        messagesErreursAutorisation.AddRange(resultTraiterAutorisation.InfoMsgTrait);
                        messagesErreurs.AddRange(messagesErreursAutorisation);
                        #endregion

                    }
                    else
                    {
                        #region Fermeture et annulation des derogations à la nouvelle date de non participation
                        resultTraiterDerogation = TraiterDerogationDateNonParticipation(numeroSequentielDispensateur, nouvDateNonParticipation, codRaisonStatutEntre.CodeRaisonStatutDerogation, false);
                        messagesErreursDerogation.AddRange(resultTraiterDerogation.InfoMsgTrait);
                        messagesErreurs.AddRange(messagesErreursDerogation);
                        #endregion

                        #region Fermeture et annulation des autorisations à la nouvelle date de non participation                     
                        resultTraiterAutorisation = TraiterAutorisationDateNonParticipation(numeroSequentielDispensateur, nouvDateNonParticipation, codRaisonStatutEntre.CodeRaisonStatutAutorisation, false);
                        messagesErreursAutorisation.AddRange(resultTraiterAutorisation.InfoMsgTrait);
                        messagesErreurs.AddRange(messagesErreursAutorisation);
                        #endregion
                    }


                    //CAll PLE1
                    #region Appel PLE1 - Fin du Process   
                    DateTime dateJour = DateTime.Today;
                    DateTime datePlusAncienne = ancDateNonParticipation < nouvDateNonParticipation ? ancDateNonParticipation : nouvDateNonParticipation;
                    if ((resultTraiterAvis.EstTraite || resultTraiterDerogation.EstTraite || resultTraiterAutorisation.EstTraite) && datePlusAncienne < dateJour)
                    {
                        var datDeb = datePlusAncienne;
                        var datFin = dateJour;
                        messagesErreurs.AddRange(AppelPLE1(param.NoSeqIntervenant, datDeb, datFin));
                    }
                    #endregion

                    if (messagesErreurs.Count > 0)
                    {
                        extrant.InfoMsgTrait = messagesErreurs;
                    }
                }
            }

            return extrant;

        }

        /// <summary>
        /// Permet de traiter un engagement du medecin omnipraticien pour lequel une date de debut de spécialité ou date de décès a été inscrite
        /// </summary>
        /// <param name="param"></param>
        /// <param name="operationEvt"></param>
        /// <returns></returns>
        public AjusEngagDdSpecInscrSorti TraiterEngagementPremiereSpecialiteDeces(AjusEngagDdSpecInscrEntre param, OperationEvt operationEvt)
        {
            AjusEngagDdSpecInscrSorti extrant = new AjusEngagDdSpecInscrSorti();
            dynamic resultat;
            var messagesErreurs = new List<IMsgTrait>();

            if (VerificationMiseAJourDatePremSpec(param).HasValue)
            {
                if (VerificationMiseAJourDatePremSpec(param).Value)
                {
                    AjusEngagAjouNonPartnEntre paramAjout = new AjusEngagAjouNonPartnEntre
                    {
                        NoSeqIntervenant = param.InfoDispOrign.NoSeq,
                        NouvPerAdmis = new PerAdmis
                        {

                            Dd = param.InfoDispModif.DdSpecialite.Value
                        }
                    };
                    resultat = TraiterEngagementInscriptionDateNonParticipation(paramAjout, operationEvt);
                    messagesErreurs.AddRange(resultat.InfoMsgTrait);
                }
                else //--MAJ date Specialite
                {
                    if (!param.InfoDispModif.DdSpecialite.HasValue) //-cas retrait
                    {
                        AjusEngagAnnuNonPartnEntre paramAnn = new AjusEngagAnnuNonPartnEntre
                        {
                            NoSeqIntervenant = param.InfoDispOrign.NoSeq,
                            PerAdmisAnnu = new PerAdmis
                            {
                                Dd = param.InfoDispOrign.DdSpecialite.Value
                            }
                        };
                        resultat = TraiterEngagementAnnuDateNonParticipation(paramAnn, operationEvt);
                        messagesErreurs.AddRange(resultat.InfoMsgTrait);
                    }
                    else
                    {
                        if (param.InfoDispOrign.DdSpecialite.Value != param.InfoDispModif.DdSpecialite.Value)//-si date identique ne rien faire
                        {
                            AjusEngagModifNonPartnEntre paramMAJ = new AjusEngagModifNonPartnEntre
                            {
                                NoSeqIntervenant = param.InfoDispOrign.NoSeq,
                                PerAdmisOrign = new PerAdmis { Dd = param.InfoDispOrign.DdSpecialite.Value },
                                PerAdmisModif = new PerAdmis { Dd = param.InfoDispModif.DdSpecialite.Value }
                            };
                            resultat = TraiterEngagementModifDateNonParticipation(paramMAJ, operationEvt);
                            messagesErreurs.AddRange(resultat.InfoMsgTrait);
                        }
                    }

                }
            }
            if (messagesErreurs.Count > 0)
            {
                extrant.InfoMsgTrait = messagesErreurs;
            }
            return extrant;
        }

        /// <summary>
        /// Permet de traiter un engagement du medecin omnipraticien pour lequel une date de decès été inscrite
        /// </summary>
        /// <param name="param"></param>
        /// <param name="operationEvt"></param>
        /// <returns></returns>
        public AjusEngagDecesSorti TraiterEngagementDeces(AjusEngagDecesEntre param, OperationEvt operationEvt)
        {
            AjusEngagDecesSorti extrant = new AjusEngagDecesSorti();
            dynamic resultat;
            var messagesErreurs = new List<IMsgTrait>();


            ObtenirDispensateurIndividuEntre intrant = new ObtenirDispensateurIndividuEntre() { NumeroSequentielIndividu = param.InfoOrignIndiv.NoSeq };
            ObtenirDispensateurIndividuSorti dispensateurIndividu = _professionnel.ObtenirInformationProfessionnel(intrant);
            if (dispensateurIndividu != null)
            {
                AjusEngagDdSpecInscrEntre paramDeces = new AjusEngagDdSpecInscrEntre
                {
                    InfoDispOrign = new Dispensateur
                    {
                        NoSeq = (long)dispensateurIndividu.NumerosSequentielDispensateur.FirstOrDefault(),
                        DdSpecialite = param.InfoOrignIndiv.DateDeces

                    },
                    InfoDispModif = new Dispensateur
                    {
                        NoSeq = (long)dispensateurIndividu.NumerosSequentielDispensateur.FirstOrDefault(),
                        DdSpecialite = param.InfoModifIndiv.DateDeces

                    }

                };
                resultat = TraiterEngagementPremiereSpecialiteDeces(paramDeces, operationEvt);
                messagesErreurs.AddRange(resultat.InfoMsgTrait);
                if (messagesErreurs.Count > 0)
                {
                    extrant.InfoMsgTrait = messagesErreurs;
                }
            }
            return extrant;
        }
        #endregion

        #region Engagements medecin Particien

        #region Avis de conformites
        /// <summary>
        /// Permet d'obtenir les avis de conformités du professionnel
        /// </summary>
        /// <param name="objParamEntree"></param>
        /// <returns></returns>
        public ObtenirLesAvisConformiteSorti ObtenirLesEngagementsPratiquesProfessionnel(ObtenirLesAvisConformiteEntre objParamEntree) => _avisConformite.ObtenirLesAvisConformite(objParamEntree);

        /// <summary>
        /// Permet de Modifier la période d'un avis de conformité à la date de non participation
        /// </summary>
        /// <param name="objParamEntree"></param>
        /// <returns></returns>
        public ModifierPeriodeAvisSorti ModifierPeriodeLesAvisConformites(ModifierPeriodeAvisEntre objParamEntree) => _avisConformite.ModifierPeriodeAvis(objParamEntree);

        /// <summary>
        /// Permet de Modifier la raison de fermeture du statut de l'engagement
        /// </summary>
        /// <param name="objParamEntree"></param>
        /// <returns></returns>
        public ModifierRaisFermStatutEngagSorti ModifierRaisonFermetureStatEngag(ModifierRaisFermStatutEngagEntre objParamEntree) => _avisConformite.ModifierRaisFermStatutEngag(objParamEntree);

        /// <summary>
        /// Permet de traiter/Ajuster un engagement du medecin omnipraticiem à une date de non participation inscrite
        /// </summary>
        /// <param name="param"></param>
        /// <param name="operationEvt"></param>
        /// <returns></returns>
        public AjusEngagAjouNonPartnSorti TraiterEngagDateNonParticipation(AjusEngagAjouNonPartnEntre param, OperationEvt operationEvt)
        {
            CodRaisonStatutEntre codRaisonStatutEntre = CreerParametreCodeRaisonStatutEntre(operationEvt);
            AjusEngagAjouNonPartnSorti extrant = new AjusEngagAjouNonPartnSorti();

            if (param != null)
            {

                #region Engagement(s) Actif(s) - Avis de conformité à la date de non participation

                ObtenirLesAvisConformiteEntre objParamEntree = new ObtenirLesAvisConformiteEntre()
                {
                    NumeroSequentielDispensateur = param.NoSeqIntervenant,
                    DateRecherche = param.NouvPerAdmis.Dd,
                    IndicateurAvisInactive = "N"
                };

                var lesEngagementsPratiques = ObtenirLesEngagementsPratiquesProfessionnel(objParamEntree);
                if (lesEngagementsPratiques != null && lesEngagementsPratiques.ListeAvisConformite.Count > 0)
                {
                    ModifierPeriodeAvisEntre periodeAvisEntre = new ModifierPeriodeAvisEntre();

                    if (lesEngagementsPratiques.ListeAvisConformite.Count == 1)
                    {
                        TraiterStatutAvis(true, lesEngagementsPratiques, periodeAvisEntre, objParamEntree, param);
                    }

                    else
                    {
                        TraiterStatutAvis(false, lesEngagementsPratiques, periodeAvisEntre, objParamEntree, param);

                    }



                }
                #endregion


                #region Engagement(s) Actif(s) - Derogation à la date de non participation
                #endregion

                #region Engagement(s) Actif(s) - Autorisation à la date de non participation
                #endregion
            }
            else
            {
                throw new ArgumentNullException(nameof(param), $"Le paramètre {nameof(param)} ne peut ëtre nul");
            }

            return extrant;
        }

        /// <summary>
        /// Permet de saisir une demande de réévaluation pour un professionnel de la santé
        /// </summary>
        /// <param name="intrant">Information de la demande</param>
        /// <returns>Les dates réelles de la demande</returns>
        /// <remarks></remarks>
        public SaisirDemandeReevaluationSorti SaisirDemandeReevaluation(SaisirDemandeReevaluationEntre intrant)
        {
            return UtilitaireService.AppelerService<svcCreerDemReeva.IServCreerDemReeva,
                                                    svcCreerDemReeva.ServCreerDemReevaClient,
                                                    SaisirDemandeReevaluationSorti>
                                                    (x => x.SaisirDemandeReevaluation(intrant));

        }

        /// <summary>
        /// permet d'obtenir les avis de conformites  du medecin omnipraticien anterieures ou posterieurs à la date de debut de non participation
        /// </summary>
        /// <param name="numseqDispensateur"></param>
        /// <param name="datDebNonPartn"></param>
        /// <param name="post">si vraie ,les avis de conformites posterieurs sont retournés sinon les anterieures</param>
        /// <returns></returns>
        public List<EntiteCPOAvis.AvisConformite> ObtenirLesAvisConfPostProfessionnel(long numseqDispensateur, DateTime datDebNonPartn, bool post)
        {
            List<EntiteCPOAvis.AvisConformite> lstAvisConf = new List<EntiteCPOAvis.AvisConformite>();

            ObtenirLesAvisConformiteEntre objParamEntree = new ObtenirLesAvisConformiteEntre()
            {
                NumeroSequentielDispensateur = numseqDispensateur,
                IndicateurAvisInactive = "N"
            };
            var result = _avisConformite.ObtenirLesAvisConformite(objParamEntree);
            List<EntiteCPOAvis.AvisConformite> lstResult = new List<EntiteCPOAvis.AvisConformite>();
            //------------------RG avis actif
            if (result != null && result.ListeAvisConformite.Any())
            {
                foreach (var item in result.ListeAvisConformite)
                {
                    var dernierStat = item.ListeStatutAvisConformite.Where(u => u.StatutEngagement == "AUT" || u.StatutEngagement == "SUS")
                                                                      .OrderByDescending(o => o.DateDebutStatutEngagement).Take(1).FirstOrDefault();
                    if (dernierStat != null && (dernierStat.DateFinStatutEngagement == null || dernierStat.DateFinStatutEngagement >= datDebNonPartn))
                    {
                        lstResult.Add(item);
                    }

                }

                if (lstResult.Any())
                {
                    lstAvisConf = !post ? result.ListeAvisConformite.Where(u => u.DateDebutEngagement <= datDebNonPartn).ToList() :
                                                                            result.ListeAvisConformite.Where(u => u.DateDebutEngagement > datDebNonPartn).ToList();

                }
            }

            return lstAvisConf;
        }

        /// <summary>
        /// Ferme l'avis de conformité actif à la periode de non-participation -1 jour
        /// </summary>
        /// <param name="lstObjParamEntree"></param>
        /// <param name="datDebNonPartn"></param>
        /// <param name="codeRaisonStatutAvisConf"></param>
        /// <returns></returns>        
        public IList<IMsgTrait> FermerAvisConfProfessionel(List<EntiteCPOAvis.AvisConformite> lstObjParamEntree, DateTime datDebNonPartn, string codeRaisonStatutAvisConf)
        {

            var messagesErreurs = new List<IMsgTrait>();
            List<EntiteCPOAvis.AvisConformite> lstret = new List<EntiteCPOAvis.AvisConformite>();
            foreach (var obj in lstObjParamEntree)
            {

                var lstActiv = obj.ListeStatutAvisConformite.Where(w => (w.StatutEngagement == "AUT" || w.StatutEngagement == "SUS")
                                                                     && (w.DateFinStatutEngagement == null || w.DateFinStatutEngagement > datDebNonPartn)
                                                           ).ToList();

                if (lstActiv.Count() > 0)
                {
                    messagesErreurs = lstActiv.Count() == 1 ? ModifierPeriodeAvisConf(true, obj, datDebNonPartn, codeRaisonStatutAvisConf).ToList() : ModifierPeriodeAvisConf(false, obj, datDebNonPartn, codeRaisonStatutAvisConf).ToList();

                }

            }

            return messagesErreurs.ToList();
        }

        /// <summary>
        /// Annulation des avis de conformités postérieurs à la date dde debut de non participation
        /// </summary>
        /// <param name="numeroSequentielDispensateur"></param>
        /// <param name="datDebNonPartn"></param> 
        /// <param name="codeRaisonStatutAvisConf"></param> 
        public IList<IMsgTrait> AnnulerAvisConf(long numeroSequentielDispensateur, DateTime datDebNonPartn, string codeRaisonStatutAvisConf)
        {
            var messagesErreurs = new List<IMsgTrait>();
            var lstAvisAnnul = ObtenirLesAvisConfPostProfessionnel(numeroSequentielDispensateur, datDebNonPartn, true);

            if (lstAvisAnnul.Count > 0)//-fin du traitement
            {
                #region Annuler engagement
                foreach (var engag in lstAvisAnnul)
                {
                    CreerStatutAvisConformiteEntre statutEntre = new CreerStatutAvisConformiteEntre()
                    {
                        NumeroSequentielEngagement = engag.NumeroSequentielEngagement.Value,
                        StatutEngagement = "ANN",
                        IdentifiantCreation = "PLF1",
                        //DateDebutStatutEngagement=,- non renseigné
                        CodeRaisonStatutEngagement = codeRaisonStatutAvisConf.Length > 1 ? codeRaisonStatutAvisConf : codeRaisonStatutAvisConf.PadLeft(2, '0')
                    };

                    var res = _avisConformite.CreerStatutAvisConformite(statutEntre);
                    messagesErreurs.AddRange(res.InfoMsgTrait);

                }
                #endregion
                return messagesErreurs;
            }
            return messagesErreurs;
        }

        /// <summary>
        /// Traitement de Avis de conformite(s) d'un medecin omnipraticien qui devient non-participant
        /// </summary>
        /// <param name="numeroSequentielDispensateur"></param>
        /// <param name="datDebNonPartn"></param>
        /// <param name="codeRaisonStatutAvisConf"></param>        
        public TraiterEngagementSorti TraiterAvisConfDateNonParticipation(long numeroSequentielDispensateur, DateTime datDebNonPartn, string codeRaisonStatutAvisConf)
        {
            TraiterEngagementSorti traiterEngagementSorti = new TraiterEngagementSorti();
            var messagesErreurs = new List<IMsgTrait>();
            try
            {
                var lstAvis = ObtenirLesAvisConfPostProfessionnel(numeroSequentielDispensateur, datDebNonPartn, false);
                if (lstAvis.Count > 0) //-avis actifs a la periode de non participation
                {
                    messagesErreurs.AddRange(FermerAvisConfProfessionel(lstAvis, datDebNonPartn, codeRaisonStatutAvisConf).ToList());
                }
                if (messagesErreurs.Count == 0)
                {
                    messagesErreurs.AddRange(AnnulerAvisConf(numeroSequentielDispensateur, datDebNonPartn, codeRaisonStatutAvisConf));
                }

                if (!messagesErreurs.Any())
                {
                    traiterEngagementSorti.EstTraite = true;
                }
                traiterEngagementSorti.InfoMsgTrait = messagesErreurs;
            }
            catch (Exception ex)
            {
                throw;
            }
            return traiterEngagementSorti;

        }

        /// <summary>
        /// permet d'obtenir les avis conformites Fermées ou annulées  du medecin omnipraticien 
        /// </summary>
        /// <param name="numseqDispensateur"></param>
        /// <param name="datDebNonPartn"></param>
        /// <param name="ferme"></param>
        /// <returns>si ferme est vraie, les avis conformites fermés à la date de non participation ayant le code 21 avec Statut=TER,sinon 
        ///            retourne les avis conformites annulés
        public List<EntiteCPOAvis.AvisConformite> ObtenirLesAvisConfFermeesAnnulees(long numseqDispensateur, DateTime datDebNonPartn, bool ferme)
        {

            List<EntiteCPOAvis.AvisConformite> lstAvisConf = null;

            ObtenirLesAvisConformiteEntre objParamEntree = new ObtenirLesAvisConformiteEntre()
            {
                NumeroSequentielDispensateur = numseqDispensateur,
                IndicateurAvisInactive = "O",
                Tri = "DF_ENGAG_PRATI DESC"

            };
            var result = _avisConformite.ObtenirLesAvisConformite(objParamEntree);

            if (result != null && result.ListeAvisConformite.Any())
            {

                lstAvisConf = !ferme ? result.ListeAvisConformite.Where(u => u.DateDebutEngagement > datDebNonPartn).OrderBy(o => o.DateDebutEngagement).ToList() :
                                                            result.ListeAvisConformite.Where(u => u.DateFinEngagement == datDebNonPartn.AddDays(-1)).ToList();
            }

            return lstAvisConf;


        }

        /// <summary>
        /// permet d'inactiver l'avis de conformité terminé ayant code 21
        /// </summary>
        /// <param name="avisTermine"></param>
        /// <returns></returns>
        public ModifierAvisConformiteStatutSorti InactiverAvisConformiteTermine(EntiteCPOAvis.AvisConformite avisTermine)
        {

            ModifierAvisConformiteStatutSorti extrant = new ModifierAvisConformiteStatutSorti();

            ModifierAvisConformiteStatutEntre paramIntrant = new ModifierAvisConformiteStatutEntre();
            paramIntrant.NumeroSequentielEngagement = avisTermine.NumeroSequentielEngagement.Value;
            paramIntrant.IdentifiantMAJ = "PLF1";
            paramIntrant.IndicateurInactivationOccurence = "O";

            extrant = _avisConformite.ModifierAvisConformiteStatut(paramIntrant);

            return extrant;
        }

        /// <summary>
        /// permet de reactiver -creer un avis de conformité fermé suite à une annulation de non participation
        /// </summary>
        /// <param name="avisInactif"></param>
        /// <param name="dateNonParticipation"></param>
        /// <param name="avisferme"></param>
        /// <param name="codRaisonStatut"></param>
        /// <returns></returns>
        public CreerAvisConformiteSorti ReactiverAvisConformite(EntiteCPOAvis.AvisConformite avisInactif, DateTime dateNonParticipation, bool avisferme, string codRaisonStatut)
        {

            if (avisferme)
            {

                var satutEngagInactif = avisInactif.ListeStatutAvisConformite.Where(u => u.DateDebutStatutEngagement == dateNonParticipation
                                                                                        && u.StatutEngagement == "TER" && u.CodeRaisonStatutEngagement == codRaisonStatut
                                                                                       ).FirstOrDefault();
                if (satutEngagInactif != null)
                {
                    CreerAvisConformiteEntre paramEntree = new CreerAvisConformiteEntre
                    {
                        NumeroSequentielDispensateur = avisInactif.NumeroSequentielDispensateur.Value,
                        CodeRegion = avisInactif.CodeRegion,
                        DateDebutEngagement = avisInactif.DateDebutEngagement,
                        IdentifiantCreation = "PLF1",
                        TypeLieuGeographique = avisInactif.TypeLieuGeographique,
                        CodeLieuGeographique = avisInactif.CodeLieuGeographique,
                        NumeroSequentielRegroupement = avisInactif.NumeroSequentielRegroupement,
                    };

                    DateTime dateDebStatutEngagInactif = avisInactif.ListeStatutAvisConformite.Where(w => w.DateHeureOccurenceInactive != null)
                                                                                                    .Min(m => m.DateDebutStatutEngagement);

                    var infosAvisInactif = avisInactif.ListeStatutAvisConformite.Where(w => w.DateDebutStatutEngagement == dateDebStatutEngagInactif
                                                                                         && w.DateHeureOccurenceInactive != null).LastOrDefault();


                    paramEntree.StatutEngagement = infosAvisInactif.StatutEngagement;
                    paramEntree.IndicateurStatutEngagementAttente = infosAvisInactif.IndicateurStatutEngagementAttente;
                    paramEntree.CodeRaisonStatutEngagement = infosAvisInactif.CodeRaisonStatutEngagement;


                    return _avisConformite.CreerAvisConformite(paramEntree);

                }
            }
            else
            {


                var satutEngagInactifAnn = avisInactif.ListeStatutAvisConformite.Where(u => u.DateDebutStatutEngagement > dateNonParticipation
                                                                                         && u.StatutEngagement == "ANN" && u.CodeRaisonStatutEngagement == codRaisonStatut
                                                                                         ).OrderBy(o => o.DateDebutStatutEngagement).Take(1).FirstOrDefault();
                if (satutEngagInactifAnn != null)
                {
                    var infosAvisInactifAnn = avisInactif.ListeStatutAvisConformite.Where(w => w.DateDebutStatutEngagement == satutEngagInactifAnn.DateDebutStatutEngagement
                                                                                        && w.DateHeureOccurenceInactive != null).LastOrDefault();

                    CreerAvisConformiteEntre paramEntree = new CreerAvisConformiteEntre
                    {
                        NumeroSequentielDispensateur = avisInactif.NumeroSequentielDispensateur.Value,
                        CodeRegion = avisInactif.CodeRegion,
                        DateDebutEngagement = avisInactif.DateDebutEngagement,
                        IdentifiantCreation = "PLF1",
                        TypeLieuGeographique = avisInactif.TypeLieuGeographique,
                        CodeLieuGeographique = avisInactif.CodeLieuGeographique,
                        NumeroSequentielRegroupement = avisInactif.NumeroSequentielRegroupement,
                        DateFinEngagement = avisInactif.DateFinEngagement,
                        StatutEngagement = infosAvisInactifAnn.StatutEngagement,
                        IndicateurStatutEngagementAttente = infosAvisInactifAnn.IndicateurStatutEngagementAttente,
                        CodeRaisonStatutEngagement = infosAvisInactifAnn.CodeRaisonStatutEngagement
                    };

                    return _avisConformite.CreerAvisConformite(paramEntree);
                }
            }
            return new CreerAvisConformiteSorti();
        }

        /// <summary>
        /// permet de modifier le statut de l'engagement
        /// </summary>
        /// <param name="nouvAvisConf"></param>
        /// <param name="numSeqStatEngag"></param>
        /// <returns></returns>
        IList<MsgTrait> ModifierStatutEngagement(ObtenirLesAvisConformiteSorti nouvAvisConf, long numSeqStatEngag, long numSeqEngag)
        {
            var messagesErreurs = new List<IMsgTrait>();


            ModifierStatutEngagementEntre modifierStatutEngagementEntre = new ModifierStatutEngagementEntre
            {
                NumeroSequentielEngagement = numSeqEngag,
                NumeroSequentielStatutEngagement = numSeqStatEngag,
                IdentifiantMAJ = "PLF1",
                IndicateurInactivationStatut = "O"
            };

            var modifierStatEngagSorti = _avisConformite.ModifierStatutAvisConformite(modifierStatutEngagementEntre);
            return modifierStatEngagSorti.InfoMsgTrait;
        }

        /// <summary>
        /// permet d'inactiver et creer à nouveau les differents status de l'avis de conformité
        /// </summary>
        /// <param name="avis"></param>
        /// <param name="nouvAvisConf"></param>
        /// <param name="numSeqStatEngag"></param>
        /// <param name="ferme"></param>
        /// si ferme est vraie, les avis conformites fermés sont traités sinon les avis annulés
        public IList<IMsgTrait> InactivationCreationStatuts(EntiteCPOAvis.AvisConformite avis, ObtenirLesAvisConformiteSorti nouvAvisConf, long numSeqStatEngag, bool ferme)
        {
            var messagesErreurs = new List<IMsgTrait>();
            long numSeqEngag = nouvAvisConf.ListeAvisConformite[0].NumeroSequentielEngagement.Value;


            if (ferme)
            {

                DateTime dateDebStatutEngagInactif = avis.ListeStatutAvisConformite.Where(w => w.DateHeureOccurenceInactive != null)
                                                                                                   .Min(m => m.DateDebutStatutEngagement);

                var lstAvisInactif = avis.ListeStatutAvisConformite.Where(w => w.DateDebutStatutEngagement == dateDebStatutEngagInactif);

                var infosAvisInactif = lstAvisInactif.FirstOrDefault().DateFinStatutEngagement.HasValue ? lstAvisInactif.FirstOrDefault() :
                   lstAvisInactif.Skip(1).FirstOrDefault();

                DateTime? valdatePrec = null;

                if (infosAvisInactif != null && infosAvisInactif.DateFinStatutEngagement.HasValue)
                {

                    var modifierStatEngagMsgTrait = ModifierStatutEngagement(nouvAvisConf, numSeqStatEngag, numSeqEngag);
                    messagesErreurs.AddRange(modifierStatEngagMsgTrait);

                    valdatePrec = infosAvisInactif.DateFinStatutEngagement.Value;

                    var ltsTraitement = avis.ListeStatutAvisConformite.Where(w => w.StatutEngagement == "SUS" || w.StatutEngagement == "AUT")
                                                     .OrderBy(w => w.DateDebutStatutEngagement).ToList();

                    #region 1er statut
                    //-creation du 1er statut identique  a celui qui est inactivé afin de lui attribuer une date de fin
                    var paramEntreStatut = new CreerStatutAvisConformiteEntre
                    {
                        NumeroSequentielEngagement = numSeqEngag,
                        StatutEngagement = ltsTraitement[0].StatutEngagement,
                        IdentifiantCreation = "PLF1",
                        DateDebutStatutEngagement = avis.DateDebutEngagement,
                        CodeRaisonStatutEngagement = ltsTraitement[0].CodeRaisonStatutEngagement,
                        DateFinStatutEngagement = valdatePrec.Value
                    };

                    var creerSortiPremStatut = _avisConformite.CreerStatutAvisConformite(paramEntreStatut);
                    messagesErreurs.AddRange(creerSortiPremStatut.InfoMsgTrait);

                    #endregion

                    #region statuts suivant
                    var dateDebMax = ltsTraitement.Max(m => m.DateDebutStatutEngagement);
                    foreach (var it in ltsTraitement) //iterer pour reconstruire tous les autres status
                    {
                        if (it.DateDebutStatutEngagement == valdatePrec.Value.AddDays(1))
                        {
                            //on iterer uniquement sur ceux dont la date de debut egale a la datefin du precedent +1jrs                     
                            var paramEntre = new CreerStatutAvisConformiteEntre
                            {
                                NumeroSequentielEngagement = numSeqEngag,
                                StatutEngagement = it.StatutEngagement,
                                IdentifiantCreation = "PLF1",
                                DateDebutStatutEngagement = it.DateDebutStatutEngagement,
                                CodeRaisonStatutEngagement = it.CodeRaisonStatutEngagement

                            };
                            if (it.DateFinStatutEngagement.HasValue)
                            {
                                paramEntre.DateFinStatutEngagement = it.DateFinStatutEngagement.Value;
                                valdatePrec = it.DateFinStatutEngagement.Value;
                            }

                            if (it.DateFinStatutEngagement.HasValue || (!it.DateFinStatutEngagement.HasValue && it.DateDebutStatutEngagement == dateDebMax))
                            {
                                var creerSortiavisConfSorti = _avisConformite.CreerStatutAvisConformite(paramEntre);
                                messagesErreurs.AddRange(creerSortiavisConfSorti.InfoMsgTrait);
                            }

                            if (!it.DateFinStatutEngagement.HasValue && it.DateDebutStatutEngagement == dateDebMax)
                            { break; }
                        }
                    }
                    #endregion

                }
            }
            else
            {
                //---cas Annulation 
                //-cas de plus status pour un avis
                var modifierStatEngagMsgTrait = ModifierStatutEngagement(nouvAvisConf, numSeqStatEngag, numSeqEngag);
                messagesErreurs.AddRange(modifierStatEngagMsgTrait);

                var datAnnu = avis.ListeStatutAvisConformite.Where(u => u.StatutEngagement == "ANN").FirstOrDefault().DateDebutStatutEngagement;
                var satutEngagAnnul = avis.ListeStatutAvisConformite.Where(u => u.DateDebutStatutEngagement >= datAnnu
                                                                            && u.DateFinStatutEngagement.HasValue
                                                                            && u.DateHeureOccurenceInactive.HasValue).OrderBy(u => u.DateDebutStatutEngagement);
                foreach (var it in satutEngagAnnul)
                {
                    var paramEntre = new CreerStatutAvisConformiteEntre
                    {
                        NumeroSequentielEngagement = numSeqEngag,
                        StatutEngagement = it.StatutEngagement,
                        IdentifiantCreation = "PLF1",
                        DateDebutStatutEngagement = it.DateDebutStatutEngagement,
                        CodeRaisonStatutEngagement = it.CodeRaisonStatutEngagement,
                        DateFinStatutEngagement = it.DateFinStatutEngagement

                    };

                    var creerSortiavisConfSorti = _avisConformite.CreerStatutAvisConformite(paramEntre);
                    messagesErreurs.AddRange(creerSortiavisConfSorti.InfoMsgTrait);
                }
            }
            return messagesErreurs.ToList();

        }

        /// <summary>
        /// Permet de faire l'obtention de la liste des statuts engagement pratique RSS 
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste des statuts engagement pratique RSS</returns>
        public ObtenirStatutsEngagementPratiqueRSSSorti ObtenirStatutsEngagementPratiqueRSS(ObtenirStatutsEngagementPratiqueRSSEntre intrant) => _avisConformite.ObtenirStatutsEngagementPratiqueRSS(intrant);

        #endregion

        #region Derogation
        /// <summary>
        /// permet d'otenir les derogations actives du medecin omnipraticien anterieures ou posterieurs à la adate de debu de non participation
        /// </summary>
        /// <param name="numseqDispensateur"></param>
        /// <param name="datDebNonPartn"></param>
        /// <param name="post">si vraie ,les derogations posterieurs sont retournées sinon les anterieures</param>
        /// <returns></returns>
        public List<PRE_Entites_cpo.Derogation.Entite.Derogation> ObtenirLesDerogationsActivPostProfessionnel(long numseqDispensateur, DateTime datDebNonPartn, bool post)
        {

            ObtenirDerogationsProfessionnelSanteEntre objParamEntree = new ObtenirDerogationsProfessionnelSanteEntre();
            List<PRE_Entites_cpo.Derogation.Entite.Derogation> lstDerogations = new List<PRE_Entites_cpo.Derogation.Entite.Derogation>();
            objParamEntree.NumeroSequentielDispensateur = numseqDispensateur;
            objParamEntree.IndicateurDerogationInactive = "N";
            var result = _derogation.ObtenirDerogationProfessionnel(objParamEntree);
            if (result != null && result.Derogations.Any())
            {

                lstDerogations = !post ? result.Derogations.Where(u => u.Statut != "ANN"
                                                                 && u.DateDebut < datDebNonPartn
                                                                 && (u.DateFin == null || u.DateFin.Value > datDebNonPartn)).ToList() :
                                                                 result.Derogations.Where(u => u.Statut == "AUT"
                                                                 && u.DateDebut >= datDebNonPartn).ToList();

                if (!post)
                {
                    var lstTer = result.Derogations.Where(u => u.Statut == "TER" && u.DateDebut < datDebNonPartn);
                    var resDerogTerminee = result.Derogations.Where(u => u.Statut == "AUT" && u.DateDebut < datDebNonPartn && u.DateFin == null
                                                                  && lstTer.Any(l => l.DateDebut == u.DateDebut)
                        );
                    var lstDerogInactiv = lstDerogations.Intersect(resDerogTerminee).ToList();

                    foreach (var derogInactiv in lstDerogInactiv)
                    {
                        lstDerogations.Remove(derogInactiv);
                    }
                }
            }

            return lstDerogations;

        }


        /// <summary>
        /// permet d'otenir les derogations actives(TER ou ANN) du medecin omnipraticien anterieures ou posterieurs à la date de debut de non participation avant modification
        /// </summary>
        /// <param name="numseqDispensateur"></param>
        /// <param name="datDebNonPartn"></param>
        /// <param name="post">si vraie ,les derogations posterieurs sont retournées sinon les anterieures</param>
        /// <returns></returns>
        public List<PRE_Entites_cpo.Derogation.Entite.Derogation> ObtenirLesDerogModifActivPostProfessionnel(long numseqDispensateur, DateTime datDebNonPartn, bool post)
        {
            ObtenirDerogationsProfessionnelSanteEntre objParamEntree = new ObtenirDerogationsProfessionnelSanteEntre();
            List<PRE_Entites_cpo.Derogation.Entite.Derogation> lstDerogations = new List<PRE_Entites_cpo.Derogation.Entite.Derogation>();
            objParamEntree.NumeroSequentielDispensateur = numseqDispensateur;
            objParamEntree.IndicateurDerogationInactive = "N";
            var result = _derogation.ObtenirDerogationProfessionnel(objParamEntree);
            if (result != null && result.Derogations.Any())
            {

                lstDerogations = !post ? result.Derogations.Where(u => u.Statut == "TER"
                                                                 && u.DateDebut < datDebNonPartn
                                                                 && u.DateFin > datDebNonPartn).ToList() :
                                                                 result.Derogations.Where(u => u.Statut == "ANN"
                                                                 && u.DateDebut >= datDebNonPartn).ToList();

            }

            return lstDerogations;
        }

        /// <summary>
        /// Ferme la derogation à la periode de non-participation -1 jour
        /// </summary>
        /// <param name="objParamEntree"></param>
        /// <param name="datDebNonPartn"></param>
        /// <returns></returns>
        public ModifierDerogationSorti FermerDerogationProfessionel(ModifierDerogationEntre objParamEntree, DateTime datDebNonPartn)
        {
            ModifierDerogationSorti periodeDerogationSorti = new ModifierDerogationSorti(); ;
            objParamEntree.IdentifiantMAJ = "PLF1";
            objParamEntree.Statut = "TER";
            if (objParamEntree.CodeRaisonStatut.Length == 1)
            {
                objParamEntree.CodeRaisonStatut = objParamEntree.CodeRaisonStatut.PadLeft(2, '0');
            }

            objParamEntree.DateFin = datDebNonPartn.AddDays(-1);
            periodeDerogationSorti = _derogation.ModifierDerogation(objParamEntree);

            return periodeDerogationSorti;

        }

        /// <summary>
        /// Annule la derogation posterieure à la date de non de participation dumedecin omnipraticien
        /// </summary>
        /// <param name="objParamEntree"></param>
        /// <returns></returns>
        public ModifierDerogationSorti AnnulationDerogationPosterieurDateNonPartipation(ModifierDerogationEntre objParamEntree)
        {
            ModifierDerogationSorti periodeDerogationSorti = new ModifierDerogationSorti();
            objParamEntree.IdentifiantMAJ = "PLF1";
            objParamEntree.Statut = "ANN";
            if (objParamEntree.CodeRaisonStatut.Length == 1)
            {
                objParamEntree.CodeRaisonStatut = objParamEntree.CodeRaisonStatut.PadLeft(2, '0');
            }
            periodeDerogationSorti = _derogation.ModifierDerogation(objParamEntree);
            return periodeDerogationSorti;
        }

        /// <summary>
        /// Traitement de derogation(s) d'un medecin omnipraticien qui devient non-participant
        /// </summary>
        /// <param name="numeroSequentielDispensateur"></param>
        /// <param name="datDebNonPartn"></param>      
        /// <param name="codRaisonStatut"></param>      
        public TraiterEngagementSorti TraiterDerogationDateNonParticipation(long numeroSequentielDispensateur, DateTime datDebNonPartn, string codRaisonStatut, bool estModif)
        {
            TraiterEngagementSorti traiterEngagementSorti = new TraiterEngagementSorti();
            var messagesErreurs = new List<IMsgTrait>();
            try
            {
                //-traitement des derogations actives
                var resultDerog = ObtenirLesDerogationsActivPostProfessionnel(numeroSequentielDispensateur, datDebNonPartn, false);

                if (resultDerog != null && resultDerog.Count > 0)
                {
                    //Fermer l'engagement actif
                    foreach (var item in resultDerog)
                    {
                        ModifierDerogationEntre objParamEntree = new ModifierDerogationEntre();
                        objParamEntree.DateDebut = item.DateDebut;
                        objParamEntree.NumeroSequentiel = item.NumeroSequentiel;
                        objParamEntree.CodeRaisonStatut = codRaisonStatut;
                        objParamEntree.DateFin = item.DateFin;
                        var resultFermeture = FermerDerogationProfessionel(objParamEntree, datDebNonPartn);

                        messagesErreurs.AddRange(resultFermeture.InfoMsgTrait);
                    }

                }
                //-traitement des derogations posterieurs
                var resultDerogpost = ObtenirLesDerogationsActivPostProfessionnel(numeroSequentielDispensateur, datDebNonPartn, true);
                if (resultDerogpost != null && resultDerogpost.Count > 0)
                {
                    //Annuler l'engagement
                    foreach (var item in resultDerogpost)
                    {
                        ModifierDerogationEntre objParamEntree = new ModifierDerogationEntre();
                        objParamEntree.NumeroSequentiel = item.NumeroSequentiel;
                        objParamEntree.CodeRaisonStatut = codRaisonStatut;
                        var resultAnnulation = AnnulationDerogationPosterieurDateNonPartipation(objParamEntree);

                        messagesErreurs.AddRange(resultAnnulation.InfoMsgTrait);
                    }
                }

                if (!messagesErreurs.Any())
                {
                    traiterEngagementSorti.EstTraite = true;
                }
                traiterEngagementSorti.InfoMsgTrait = messagesErreurs;
            }
            catch (Exception)
            {

                throw;
            }

            return traiterEngagementSorti;
        }


        /// <summary>
        /// permet d'obtenir les derogations Fermées ou annulées  du medecin omnipraticien 
        /// </summary>
        /// <param name="numseqDispensateur"></param>
        /// <param name="datDebNonPartn"></param>
        /// <param name="ferme"></param>
        /// <param name="codRaisonStatutEntre"></param>
        /// <returns>
        /// Non-Participation :si ferme est vraie, les derogations fermées à la date de non participation ayant avec Statut=TER,sinon 
        ///            retourne les derogations annulées  et statut=ANN pour raison de non participation   
        /// </returns>
        public List<PRE_Entites_cpo.Derogation.Entite.Derogation> ObtenirLesDerogationsProfessionnelFermeesAnnulees(long numseqDispensateur, DateTime datDebNonPartn, bool ferme, string codRaisonStatutEntre)
        {
            ObtenirDerogationsProfessionnelSanteEntre objParamEntree = new ObtenirDerogationsProfessionnelSanteEntre();
            List<PRE_Entites_cpo.Derogation.Entite.Derogation> lstDerogations = null;
            objParamEntree.NumeroSequentielDispensateur = numseqDispensateur;
            objParamEntree.IndicateurDerogationInactive = "O";
            var result = _derogation.ObtenirDerogationProfessionnel(objParamEntree);
            if (result != null && result.Derogations.Any())
            {
                string codeRais = codRaisonStatutEntre.Length > 1 ? codRaisonStatutEntre : codRaisonStatutEntre.PadLeft(2, '0');

                lstDerogations = !ferme ? result.Derogations.Where(u => u.Statut == "ANN" && u.CodeRaisonStatut == codeRais
                                                                      && u.DateDebut > datDebNonPartn).ToList() :
                                                                      result.Derogations.Where(u => u.Statut == "TER" && u.CodeRaisonStatut == codeRais
                                                                      && u.DateFin == datDebNonPartn.AddDays(-1)).ToList();


            }

            return lstDerogations;

        }

        /// <summary>
        /// Reactive la derogation suite à une annulation de periode de non admissibilité
        /// </summary>
        /// <param name="objParamEntree"></param>        
        /// <returns></returns>
        public ModifierDerogationSorti ReactivationDerogationProfessionel(ModifierDerogationEntre objParamEntree)
        {

            ModifierDerogationSorti periodeDerogationSorti = new ModifierDerogationSorti();

            objParamEntree.IdentifiantMAJ = "PLF1";

            if (objParamEntree.CodeRaisonStatut != null && objParamEntree.CodeRaisonStatut.Length == 1)
            {
                objParamEntree.CodeRaisonStatut = objParamEntree.CodeRaisonStatut.PadLeft(2, '0');
            }

            periodeDerogationSorti = _derogation.ModifierDerogation(objParamEntree);

            return periodeDerogationSorti;


        }

        /// <summary>
        /// retoune la liste des derogation fermées pour non participation
        /// </summary>
        /// <param name="numseqDispensateur"></param>
        /// <param name="ancDateNonParticipation"></param>
        /// <returns></returns>
        [Obsolete("Utilisez la methode ObtenirLesDerogationsProfessionnelFermeesAnnulees")]
        List<PRE_Entites_cpo.Derogation.Entite.Derogation> ObtenirDerogationFermePourNonParticipation(long numseqDispensateur, DateTime ancDateNonParticipation) =>
            ObtenirLesDerogationsInactives(numseqDispensateur).Where(u => u.CodeRaisonStatut == "07" && u.DateFin == ancDateNonParticipation.AddDays(-1)).ToList();
        #endregion

        #region Autorisation

        public List<PL_LogiqueAffaire_cpo.Entites.Autorisation> ObtenirLesAutorisationsActivPostProfessionnel(long numseqDispensateur, DateTime datDebNonPartn, bool post)
        {


            LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre objParamEntree = new LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre();
            List<PL_LogiqueAffaire_cpo.Entites.Autorisation> lstAutorisations = new List<PL_LogiqueAffaire_cpo.Entites.Autorisation>();
            objParamEntree.NumeroSequentielDispensateur = numseqDispensateur;

            var result = _autorisation.ObtenirAutorisationPREMQ(objParamEntree);
            if (result != null && result.Autorisations.Any())
            {
                lstAutorisations = !post ? result.Autorisations.Where(u => u.DateDebut < datDebNonPartn).ToList() : result.Autorisations.Where(u => u.DateDebut >= datDebNonPartn).ToList();
            }

            return lstAutorisations;



        }

        public List<PL_LogiqueAffaire_cpo.Entites.Autorisation> ObtenirLesAutorisationsModifActivPostProfessionnel(long numseqDispensateur, DateTime datDebNonPartn, bool post)
        {


            LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre objParamEntree = new LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre();
            List<PL_LogiqueAffaire_cpo.Entites.Autorisation> lstAutorisations = new List<PL_LogiqueAffaire_cpo.Entites.Autorisation>();
            objParamEntree.NumeroSequentielDispensateur = numseqDispensateur;

            var result = _autorisation.ObtenirAutorisationPREMQ(objParamEntree);
            if (result != null && result.Autorisations.Any())
            {
                lstAutorisations = !post ? result.Autorisations.Where(u => u.DateDebut < datDebNonPartn
                                                                         && u.DateFin > datDebNonPartn
                                                                         && u.CodeRaisonStatut == "07").ToList() :
                                                                         result.Autorisations.Where(u => u.DateDebut >= datDebNonPartn
                                                                                                    && u.CodeRaisonStatut == "07"
                                                                                                     ).ToList();
            }

            return lstAutorisations;



        }


        /// <summary>
        /// Ferme l'autorisation à la periode de non-participation -1 jour
        /// </summary>
        /// <param name="objParamEntree"></param>
        /// <param name="datDebNonPartn"></param>
        /// <returns></returns>
        public ModifierAutorisationSorti FermerAutorisationProfessionel(ModifierAutorisationEntre objParamEntree, DateTime datDebNonPartn)
        {
            ModifierAutorisationSorti periodeDerogationSorti = new ModifierAutorisationSorti();
            objParamEntree.IdentifiantMAJ = "PLF1";

            if (objParamEntree.CodeRaisonStatut.Length == 1)
            {
                objParamEntree.CodeRaisonStatut = objParamEntree.CodeRaisonStatut.PadLeft(2, '0');
            }

            objParamEntree.DateFin = datDebNonPartn.AddDays(-1);
            periodeDerogationSorti = _autorisation.ModifierAutorisation(objParamEntree);

            return periodeDerogationSorti;
        }


        /// <summary>
        /// Annule l'autorisation posterieure à la date de non de participation du medecin omnipraticien
        /// </summary>
        /// <param name="objParamEntree"></param>
        /// <returns></returns>
        public ModifierAutorisationSorti AnnulationAutorisationPosterieurDateNonPartipation(ModifierAutorisationEntre objParamEntree)
        {
            ModifierAutorisationSorti periodeAutorisationSorti = new ModifierAutorisationSorti();
            objParamEntree.IdentifiantMAJ = "PLF1";

            if (objParamEntree.CodeRaisonStatut.Length == 1)
            {
                objParamEntree.CodeRaisonStatut = objParamEntree.CodeRaisonStatut.PadLeft(2, '0');
            }
            return periodeAutorisationSorti = _autorisation.ModifierAutorisation(objParamEntree);

        }


        /// <summary>
        /// Traitement de(s) autorisation(s) d'un medecin omnipraticien qui devient non-participant
        /// </summary>
        /// <param name="numeroSequentielDispensateur"></param>
        /// <param name="datDebNonPartn"></param>
        /// <param name="codeRaisonStatutAutorisation"></param>
        public TraiterEngagementSorti TraiterAutorisationDateNonParticipation(long numeroSequentielDispensateur, DateTime datDebNonPartn, CodeRaisonStatutAutorisation codeRaisonStatutAutorisation, bool estModif)
        {
            TraiterEngagementSorti traiterEngagementSorti = new TraiterEngagementSorti();
            var messagesErreurs = new List<IMsgTrait>();

            try
            {

                //-traitement des autorisations 
                var resultAutor = estModif ? ObtenirLesAutorisationsModifActivPostProfessionnel(numeroSequentielDispensateur, datDebNonPartn, false)
                                      : ObtenirLesAutorisationsActivPostProfessionnel(numeroSequentielDispensateur, datDebNonPartn, false);
                if (resultAutor != null && resultAutor.Count > 0)
                {
                    //Fermer l'engagement actif
                    foreach (var item in resultAutor)
                    {
                        ModifierAutorisationEntre objParamEntree = new ModifierAutorisationEntre();
                        objParamEntree.DateDebut = item.DateDebut;
                        objParamEntree.NumeroSequentiel = item.NumeroSequence;
                        objParamEntree.CodeRaisonStatut = codeRaisonStatutAutorisation.Fermeture;//"03";
                        objParamEntree.DateFin = item.DateFin;
                        objParamEntree.CodeLgeo = item.CodeLieuGeographique;
                        objParamEntree.NumeroSeqRegrAdmnLgeo = item.NumeroSequenceRegroupementAdministratif;
                        objParamEntree.TypeAutor = item.Type;
                        objParamEntree.TypeLgeo = item.TypeLieuGeographique;


                        var resultFermeture = FermerAutorisationProfessionel(objParamEntree, datDebNonPartn);
                        messagesErreurs.AddRange(resultFermeture.InfoMsgTrait);
                    }

                }
                //-traitement des derogations posterieurs
                var resultAutorpost = ObtenirLesAutorisationsActivPostProfessionnel(numeroSequentielDispensateur, datDebNonPartn, true);
                if (resultAutorpost != null && resultAutorpost.Count > 0)
                {
                    //Annuler l'engagement
                    foreach (var item in resultAutorpost)
                    {
                        ModifierAutorisationEntre objParamEntree = new ModifierAutorisationEntre();
                        objParamEntree.NumeroSequentiel = item.NumeroSequence;
                        objParamEntree.CodeRaisonStatut = codeRaisonStatutAutorisation.Annulation;//"07";
                        var resultAnnulation = AnnulationAutorisationPosterieurDateNonPartipation(objParamEntree);
                        messagesErreurs.AddRange(resultAnnulation.InfoMsgTrait);
                    }
                }

                if (!messagesErreurs.Any())
                {
                    traiterEngagementSorti.EstTraite = true;
                }
                traiterEngagementSorti.InfoMsgTrait = messagesErreurs;

            }
            catch (Exception)
            {
                throw;
            }
            return traiterEngagementSorti;
        }


        /// <summary>
        /// permet d'obtenir les Autorisations Fermées ou annulées du medecin omnipraticien 
        /// </summary>
        /// <param name="numseqDispensateur"></param>
        /// <param name="datDebNonPartn"></param>
        /// <param name="ferme"></param>
        /// <param name="codRaisonStatutEntre"></param>
        /// <returns>
        /// Date Non participation : si ferme est vraie, les autorisations fermées à la date de non participation  avec Statut=TER,sinon 
        ///            retourne les autorisations annulées -  statut=ANN pour raison en paramètre        
        /// </returns>
        public List<PL_LogiqueAffaire_cpo.Entites.Autorisation> ObtenirLesAutorisationsProfessionnelFermeesAnnulees(long numseqDispensateur, DateTime datDebNonPartn, bool ferme, string codRaisonStatutEntre)
        {
            LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre objParamEntree = new LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre();
            List<PL_LogiqueAffaire_cpo.Entites.Autorisation> lstAutorisations = null;
            objParamEntree.NumeroSequentielDispensateur = numseqDispensateur;
            var result = _autorisation.ObtenirAutorisationPREMQ(objParamEntree);
            if (result != null && result.Autorisations.Any())
            {
                var codRaison = codRaisonStatutEntre.Length > 1 ? codRaisonStatutEntre : codRaisonStatutEntre.PadLeft(2, '0');
                lstAutorisations = !ferme ? result.Autorisations.Where(u => u.DateDebut > datDebNonPartn && u.CodeRaisonStatut == codRaison).ToList() : result.Autorisations.Where(u => u.DateFin == datDebNonPartn.AddDays(-1) && u.CodeRaisonStatut == codRaison).ToList();
            }

            return lstAutorisations;
        }

        /// <summary>
        /// Reactive l'autorisation suite à une Fermeture /annulation de periode de non admissibilité
        /// </summary>
        /// <param name="objParamEntree"></param>       
        /// <returns></returns>   
        public ModifierAutorisationSorti ReactivationAutorisationProfessionel(ModifierAutorisationEntre objParamEntree)
        {

            ModifierAutorisationSorti periodeAutorisationSorti = null;
            objParamEntree.IdentifiantMAJ = "PLF1";

            if (objParamEntree.CodeRaisonStatut.Length == 1)
            {
                objParamEntree.CodeRaisonStatut = objParamEntree.CodeRaisonStatut.PadLeft(2, '0');
            }

            periodeAutorisationSorti = _autorisation.ModifierAutorisation(objParamEntree);
            return periodeAutorisationSorti;

        }


        #endregion

        #endregion

        #region methodes privées

        /// <summary>
        /// creation des code de raison statut selon l'evenement
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        CodRaisonStatutEntre CreerParametreCodeRaisonStatutEntre(OperationEvt operation)
        {
            CodRaisonStatutEntre codRaisonStatutEntre = null;
            switch (operation)
            {
                case OperationEvt.OperationNonAdmissibilite:
                    codRaisonStatutEntre = new CodRaisonStatutEntre
                    {
                        CodeRaisonStatutAvisConf = Constante.CodeRaisonStatutAvisConf_DateNonPartn,
                        CodeRaisonStatutReactivationAvisConf = Constante.EvtModif_CodeRaiStaAvisDatNPartPosterieur,

                        CodeRaisonStatutDerogation = Constante.CodeRaisonStatutDerogation_DateNonPartn,
                        CodeRaisonStatutAutorisation = new CodeRaisonStatutAutorisation
                        {
                            Fermeture = Constante.CodeRaisonStatutAutorisationFerm_DateNonPartn,
                            Annulation = Constante.CodeRaisonStatutAutorisationAnn_DateNonPartn
                        }

                    };
                    break;
                case OperationEvt.OperationPremièreSpecialite:
                    codRaisonStatutEntre = new CodRaisonStatutEntre
                    {
                        CodeRaisonStatutAvisConf = Constante.CodeRaisonStatutAvisConf_DateSpec,
                        CodeRaisonStatutReactivationAvisConf = Constante.EvtSpec_CodeRaiStaAvisDatNPartPosterieur,

                        CodeRaisonStatutDerogation = Constante.CodeRaisonStatutDerogation_DateSpec,
                        CodeRaisonStatutAutorisation = new CodeRaisonStatutAutorisation
                        {
                            Fermeture = Constante.CodeRaisonStatutAutorisationFerm_DateSpec,
                            Annulation = Constante.CodeRaisonStatutAutorisationAnn_DateSpec
                        }
                    };
                    break;
                case OperationEvt.OperationDeces:
                    codRaisonStatutEntre = new CodRaisonStatutEntre
                    {
                        CodeRaisonStatutAvisConf = Constante.CodeRaisonStatutAvisConf_DateDec,
                        CodeRaisonStatutReactivationAvisConf = Constante.EvtDec_CodeRaiStaAvisDatNPartPosterieur,

                        CodeRaisonStatutDerogation = Constante.CodeRaisonStatutDerogation_DateDec,
                        CodeRaisonStatutAutorisation = new CodeRaisonStatutAutorisation
                        {
                            Fermeture = Constante.CodeRaisonStatutAutorisationFerm_DateDec,
                            Annulation = Constante.CodeRaisonStatutAutorisationAnn_DateDec
                        }
                    };
                    break;
            }
            return codRaisonStatutEntre;
        }

        /// <summary>
        /// appel du service PLE1 - Saisir une demande de réevaluation pour un professionnel de la santé
        /// </summary>
        /// <param name="numeroSequentielDispensateur"></param>
        /// <param name="dateDebutReeva"></param>
        /// <param name="dateFinReeva"></param>
        IList<IMsgTrait> AppelPLE1(long numeroSequentielDispensateur, DateTime? dateDebutReeva, DateTime dateFinReeva)
        {
            var messagesErreurs = new List<IMsgTrait>();
            //-Appel PLE1
            SaisirDemandeReevaluationEntre demandeReevaluationEntre = new SaisirDemandeReevaluationEntre()
            {

                NumeroSequentielDispensateur = numeroSequentielDispensateur,
                CodeCategorieReeva = 1,
                CodeSource = 2,
                DateDebutReeva = dateDebutReeva.Value,
                DateFinReeva = dateFinReeva,
                IdentifiantOcc = "PLF1"
            };

            
            var result = SaisirDemandeReevaluation(demandeReevaluationEntre);

            if (result.InfoMsgTrait.Any() && result.InfoMsgTrait[0].CodSever != "I")
            { messagesErreurs.AddRange(result.InfoMsgTrait); }

            return messagesErreurs;

        }

        /// <summary>
        /// Fermeture d'un avis de conformité
        /// </summary>
        /// <param name="periodeAvisEntre"></param>
        /// <param name="dateNonParticipation"></param>
        /// <param name="statutEngagement"></param>        
        /// <param name="codeRaisonStatutAvisConf"></param>        
        IList<IMsgTrait> FermetureAvisConformite(ModifierPeriodeAvisEntre periodeAvisEntre, DateTime dateNonParticipation, string statutEngagement, string codeRaisonStatutAvisConf)
        {
            var messagesErreurs = new List<IMsgTrait>();
            //-1 Modifier periode Avis conformite
            ModifierPeriodeAvisSorti periodeAvisSorti = ModifierPeriodeLesAvisConformites(periodeAvisEntre);
            messagesErreurs.AddRange(periodeAvisSorti.InfoMsgTrait);
            if (periodeAvisSorti.DateHeureOccurence.HasValue)
            {
                //-2 Modifier raison de fermeture du statut de l'engagement                     
                //-MAJ
                ModifierRaisFermStatutEngagEntre raisFermStatutEngagEntre = new ModifierRaisFermStatutEngagEntre()
                {
                    NumeroSequentielStatutEngagement = ObtenirNumSeqStatutEngagementPratique(periodeAvisEntre.NumeroSequentielEngagement, dateNonParticipation, statutEngagement),
                    CodeRaisonStatut = codeRaisonStatutAvisConf,
                    IdentifiantMAJ = "PLF1"

                };

                ModifierRaisFermStatutEngagSorti raisFermStatutEngagSorti = ModifierRaisonFermetureStatEngag(raisFermStatutEngagEntre);

                messagesErreurs.AddRange(raisFermStatutEngagSorti.InfoMsgTrait);

            }
            return messagesErreurs.ToList();

        }

        /// <summary>
        /// le numero de sequence du statur de l'engagement
        /// </summary>
        /// <param name="numeroSequentielEngagement"></param>
        /// <param name="dateNonParticipation"></param>
        /// <param name="statutEngagement"></param>
        /// <returns></returns>
        public long ObtenirNumSeqStatutEngagementPratique(long numeroSequentielEngagement, DateTime dateNonParticipation, string statutEngagement)
        {

            
            var statutEntre = statutEngagement == "TER" ? new ObtenirStatutsEngagementPratiqueRSSEntre()
            {
                NumeroSequentielEngagement = numeroSequentielEngagement,
                StatutEngagementTerritoire = statutEngagement,
                DateDebutStatutEngagementTerritoire = dateNonParticipation
            } :
                                                                          new ObtenirStatutsEngagementPratiqueRSSEntre
                                                                          {
                                                                              NumeroSequentielEngagement = numeroSequentielEngagement,
                                                                              StatutEngagementTerritoire = statutEngagement
                                                                          };
            
            
            var statuSorti = ObtenirStatutsEngagementPratiqueRSS(statutEntre);
            return statuSorti != null && statuSorti.ListeStatutEngagementPratiqueRSS.Any() ? statuSorti.ListeStatutEngagementPratiqueRSS.ToList()[0].NumeroSequentielStatutEngagement.Value : default(long);
        }

        /// <summary>
        /// Fermeture d'un avis de conformité - suivant une action 
        /// </summary>        
        /// <param name="numeroSequentielEngagement"></param>
        /// <param name="codeRaisonStatut"></param>
        /// <param name="statutEngagement"></param>     
        /// <param name="dateNonParticipation"></param>     
        void FermetureAvisConformite(long numeroSequentielEngagement, string codeRaisonStatut, string statutEngagement, DateTime dateNonParticipation)
        {
            ModifierRaisFermStatutEngagEntre raisFermStatutEngagEntre = new ModifierRaisFermStatutEngagEntre()
            {
                NumeroSequentielStatutEngagement = ObtenirNumSeqStatutEngagementPratique(numeroSequentielEngagement, dateNonParticipation, statutEngagement),
                CodeRaisonStatut = codeRaisonStatut,
                IdentifiantMAJ = "PLF1"

            };

            ModifierRaisFermStatutEngagSorti raisFermStatutEngagSorti = ModifierRaisonFermetureStatEngag(raisFermStatutEngagEntre);

        }

        /// <summary>
        /// Annulation des avis de conformités postérieurs à la date dde debut de non participation
        /// </summary>
        /// <param name="numeroSequentielDispensateur"></param>
        /// <param name="nouvPerAdmis_Dd"></param>
        /// <param name="numeroSequentielEngagement"></param>

        void AnnulationAvisConformite(long numeroSequentielDispensateur, DateTime nouvPerAdmis_Dd, long numeroSequentielEngagement)
        {
            ObtenirLesAvisConformiteEntre paramEntree = new ObtenirLesAvisConformiteEntre()
            {
                NumeroSequentielDispensateur = numeroSequentielDispensateur,
                IndicateurAvisInactive = "N"
            };
            var lesEngagementsPratiquesPosterieur = ObtenirLesEngagementsPratiquesProfessionnel(paramEntree)
                                                   .ListeAvisConformite.Where(w => w.DateDebutEngagement > nouvPerAdmis_Dd)
                                                    .ToList();

            //--Ya t-il des engagements postérieurs à la date de non participation
            if (lesEngagementsPratiquesPosterieur.Count > 0)
            {
                #region Annuler engagement
                foreach (var engag in lesEngagementsPratiquesPosterieur)
                {
                    CreerStatutAvisConformiteEntre statutEntre = new CreerStatutAvisConformiteEntre()
                    {
                        NumeroSequentielEngagement = numeroSequentielEngagement,
                        StatutEngagement = "ANN",
                        IdentifiantCreation = "PLF1",
                        //DateDebutStatutEngagement=,- non renseigné
                        CodeRaisonStatutEngagement = "21"
                    };

                    _avisConformite.CreerStatutAvisConformite(statutEntre);
                }
                #endregion
            }

        }

        /// <summary>
        /// traite les differents statuts des avis de conformités
        /// </summary>
        /// <param name="aUnSeulStatut">Vraie si l'avis de conformité n'a qu'un seul statut</param>
        /// <param name="lesEngagementsPratiques"></param>
        /// <param name="periodeAvisEntre"></param>
        /// <param name="objParamEntree"></param>
        /// <param name="param"></param>
        void TraiterStatutAvis(bool aUnSeulStatut, ObtenirLesAvisConformiteSorti lesEngagementsPratiques, ModifierPeriodeAvisEntre periodeAvisEntre, ObtenirLesAvisConformiteEntre objParamEntree, AjusEngagAjouNonPartnEntre param)
        {
            int i = 0;
            if (aUnSeulStatut)
            {
                #region un seul statut avis de conformite
                var item = lesEngagementsPratiques.ListeAvisConformite[i];
                var status = item.ListeStatutAvisConformite.Where(w => w.StatutEngagement == "AUT" || w.StatutEngagement == "SUS");


                periodeAvisEntre.NumeroSequentielEngagement = item.NumeroSequentielEngagement.Value;
                periodeAvisEntre.DateDebutActuelle = item.DateDebutEngagement;
                periodeAvisEntre.DateFinActuelle = item.DateFinEngagement;
                periodeAvisEntre.DateDebutNouvelle = item.DateDebutEngagement;
                periodeAvisEntre.IdentifiantMAJ = "PLF1";
                periodeAvisEntre.DateFinNouvelle = objParamEntree.DateRecherche.Value.AddDays(-1);


                #region Fermeture de l'avis                    

                FermetureAvisConformite(periodeAvisEntre, param.NouvPerAdmis.Dd, "TER", "21");

                #endregion

                #region recherche engagements postérieurs à la date de non participation  

                AnnulationAvisConformite(param.NoSeqIntervenant, param.NouvPerAdmis.Dd, item.NumeroSequentielEngagement.Value);

                #endregion

                #region Refaire le calcul de la repartition de la pratique
                //-Appel PLE1   - Fin du Process                               
                var datDeb = periodeAvisEntre.DateFinNouvelle.Value.AddDays(-15);
                var datFin = periodeAvisEntre.DateFinNouvelle.Value;
                AppelPLE1(param.NoSeqIntervenant, datDeb, datFin);
                #endregion

                #endregion
            }
            else
            {
                #region plusieurs statuts avis de conformite

                foreach (var engagPrati in lesEngagementsPratiques.ListeAvisConformite)
                {
                    i = engagPrati.ListeStatutAvisConformite.Count - 1;
                    bool trouv = false;
                    DateTime datDebNonParticipation = objParamEntree.DateRecherche.Value;
                    List<ModifierPeriodeAvisSorti> resultPeriodeAvisSorti = new List<ModifierPeriodeAvisSorti>();
                    do
                    {
                        var item = lesEngagementsPratiques.ListeAvisConformite[i];
                        var status = item.ListeStatutAvisConformite.Where(w => w.StatutEngagement == "AUT" || w.StatutEngagement == "SUS");

                        if (status.Count() > 0)
                        {
                            periodeAvisEntre.NumeroSequentielEngagement = item.NumeroSequentielEngagement.Value;
                            periodeAvisEntre.DateDebutActuelle = item.DateDebutEngagement;
                            periodeAvisEntre.DateDebutNouvelle = item.DateDebutEngagement;
                            periodeAvisEntre.IdentifiantMAJ = "PLF1";


                            periodeAvisEntre.DateFinActuelle = item.ListeStatutAvisConformite[i].DateFinStatutEngagement;
                            if (i > 0)
                            {
                                periodeAvisEntre.DateFinNouvelle = item.ListeStatutAvisConformite[i - 1].DateFinStatutEngagement;
                            }

                            var val = item.ListeStatutAvisConformite;
                            if (datDebNonParticipation >= val[i].DateDebutStatutEngagement && datDebNonParticipation <= val[i].DateFinStatutEngagement)
                            {
                                periodeAvisEntre.DateFinNouvelle = datDebNonParticipation.AddDays(-1);
                                trouv = true;


                            }

                            #region Fermeture de l'avis                              

                            FermetureAvisConformite(periodeAvisEntre, param.NouvPerAdmis.Dd, "TER", "21");

                            #endregion

                            #region recherche engagements postérieurs à la date de non participation 

                            AnnulationAvisConformite(param.NoSeqIntervenant, param.NouvPerAdmis.Dd, periodeAvisEntre.NumeroSequentielEngagement);

                            #endregion

                            #region Refaire le calcul de la repartition de la pratique
                            //-Appel PLE1   - Fin du Process                               
                            var datDeb = periodeAvisEntre.DateFinNouvelle.Value.AddDays(-15);
                            var datFin = periodeAvisEntre.DateFinNouvelle.Value;
                            AppelPLE1(param.NoSeqIntervenant, datDeb, datFin);
                            #endregion


                            if (trouv)
                            { break; }
                        }
                        i--;
                    }
                    while (i >= 0);
                }

                #endregion
            }
        }

        IList<IMsgTrait> ModifierPeriodeAvisConf(bool aUnSeulStatut, EntiteCPOAvis.AvisConformite avisActif, DateTime datDebNonPartn, string codeRaisonStatutAvisConf)
        {
            ModifierPeriodeAvisEntre modifierPeriodeAvisEntre = new ModifierPeriodeAvisEntre();
            var messagesErreurs = new List<IMsgTrait>();
            if (aUnSeulStatut)
            {
                #region un seul statut avis de conformite


                var item = avisActif;

                modifierPeriodeAvisEntre.NumeroSequentielEngagement = item.NumeroSequentielEngagement.Value;
                modifierPeriodeAvisEntre.DateDebutActuelle = item.DateDebutEngagement;
                modifierPeriodeAvisEntre.DateFinActuelle = item.DateFinEngagement;
                modifierPeriodeAvisEntre.DateDebutNouvelle = item.DateDebutEngagement;
                modifierPeriodeAvisEntre.IdentifiantMAJ = "PLF1";
                modifierPeriodeAvisEntre.DateFinNouvelle = datDebNonPartn.AddDays(-1);

                //-RG              
                modifierPeriodeAvisEntre.CodeRaisonStatut = item.ListeStatutAvisConformite.Where(s => s.StatutEngagement != "TER").FirstOrDefault().CodeRaisonStatutEngagement;

                messagesErreurs = FermetureAvisConformite(modifierPeriodeAvisEntre, datDebNonPartn, "TER", codeRaisonStatutAvisConf).ToList();

                return messagesErreurs.ToList();
                #endregion
            }
            else
            {
                #region plusieurs status pour l'avis de conformite

                int i = avisActif.ListeStatutAvisConformite.Count - 1;

                avisActif.ListeStatutAvisConformite = avisActif.ListeStatutAvisConformite.OrderBy(o => o.DateDebutStatutEngagement).ToList();
                bool trouv = false;
                do
                {

                    modifierPeriodeAvisEntre.NumeroSequentielEngagement = avisActif.NumeroSequentielEngagement.Value;
                    modifierPeriodeAvisEntre.DateDebutActuelle = avisActif.DateDebutEngagement;
                    modifierPeriodeAvisEntre.DateDebutNouvelle = avisActif.DateDebutEngagement;
                    modifierPeriodeAvisEntre.IdentifiantMAJ = "PLF1";


                    modifierPeriodeAvisEntre.DateFinActuelle = avisActif.ListeStatutAvisConformite[i].DateFinStatutEngagement;
                    if (i > 0)
                    {
                        modifierPeriodeAvisEntre.DateFinNouvelle = avisActif.ListeStatutAvisConformite[i - 1].DateFinStatutEngagement;
                    }

                    var val = avisActif.ListeStatutAvisConformite;
                    //-RG
                    modifierPeriodeAvisEntre.CodeRaisonStatut = val[i].CodeRaisonStatutEngagement;


                    if (i == 0 || (datDebNonPartn >= val[i].DateDebutStatutEngagement && datDebNonPartn <= val[i].DateFinStatutEngagement))
                    {
                        modifierPeriodeAvisEntre.DateFinNouvelle = datDebNonPartn.AddDays(-1);
                        trouv = true;

                    }

                    messagesErreurs.AddRange(FermetureAvisConformite(modifierPeriodeAvisEntre, datDebNonPartn, "TER", codeRaisonStatutAvisConf));
                    if (messagesErreurs.Count > 0)
                    {
                        break;
                    }
                    if (trouv)
                    { break; }
                    i--;
                    modifierPeriodeAvisEntre = new ModifierPeriodeAvisEntre();
                }
                while (i >= 0);


                #endregion

                return messagesErreurs.ToList();
            }

        }

        ModifierPeriodeAvisEntre CreationPeriodeAvis(int i, ObtenirLesAvisConformiteSorti lesEngagementsPratiques, ObtenirLesAvisConformiteEntre objParamEntree)
        {
            var item = lesEngagementsPratiques.ListeAvisConformite[i];

            ModifierPeriodeAvisEntre periodeAvisEntre = new ModifierPeriodeAvisEntre();
            periodeAvisEntre.NumeroSequentielEngagement = item.NumeroSequentielEngagement.Value;
            periodeAvisEntre.DateDebutActuelle = item.DateDebutEngagement;
            periodeAvisEntre.DateFinActuelle = item.DateFinEngagement;
            periodeAvisEntre.DateDebutNouvelle = item.DateDebutEngagement;
            periodeAvisEntre.IdentifiantMAJ = "PLF1";
            periodeAvisEntre.DateFinNouvelle = objParamEntree.DateRecherche.Value.AddDays(-1);

            return periodeAvisEntre;
        }

        /// <summary>
        /// Permet de verifier si au moins un engagement est actif après la date de non participation en vue d'une annulation,
        /// si oui ,un couriel est envoye
        /// </summary>
        /// <returns></returns>
        bool VerifierEngagemnentActif(long numseqDispensateur, DateTime datDebNonPartn, EnvoyCourlEntre objParamEntreCourl,OperationEvt operationEvt)
        {
            ContenuCourlEntre contenuEntre = new ContenuCourlEntre
            {
                NumeroSequentielDispensateur = numseqDispensateur,
                DatDebNonPartn = datDebNonPartn,                
                Evt = operationEvt
            };
            var resultAvisConformite = ObtenirLesAvisConfPostProfessionnel(numseqDispensateur, datDebNonPartn, true).Count > 0;
            if (resultAvisConformite)
            {
                EnvoyerCourlConfr(objParamEntreCourl, EnumRaisonCourriel.AvisConformite, contenuEntre);
            }
            var resultDerogation = ObtenirLesDerogationsActivPostProfessionnel(numseqDispensateur, datDebNonPartn, true).Count > 0;
            if (resultDerogation)
            {
                EnvoyerCourlConfr(objParamEntreCourl, EnumRaisonCourriel.Derogation, contenuEntre);
            }
            var resultAutorisation = ObtenirLesAutorisationsActivPostProfessionnel(numseqDispensateur, datDebNonPartn, true).Count > 0;
            if (resultAutorisation)
            {
                EnvoyerCourlConfr(objParamEntreCourl, EnumRaisonCourriel.Autorisation, contenuEntre);
            }
            return (resultAvisConformite || resultDerogation || resultAutorisation);

        }

        /// <summary>
        /// recupere toute sles derogations inactives d'"un medecin omnipraticienn
        /// </summary>
        /// <param name="numseqDispensateur"></param>
        /// <returns></returns>
        List<PRE_Entites_cpo.Derogation.Entite.Derogation> ObtenirLesDerogationsInactives(long numseqDispensateur)
        {

            ObtenirDerogationsProfessionnelSanteEntre objParamEntree = new ObtenirDerogationsProfessionnelSanteEntre();
            objParamEntree.NumeroSequentielDispensateur = numseqDispensateur;
            objParamEntree.IndicateurDerogationInactive = "O";//true;  

            return _derogation.ObtenirDerogationProfessionnel(objParamEntree).Derogations;

        }


        List<PL_LogiqueAffaire_cpo.Entites.Autorisation> ObtenirLesAutorisations(long numseqDispensateur)
        {

            LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre objParamEntree = new LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre();
            objParamEntree.NumeroSequentielDispensateur = numseqDispensateur;

            return _autorisation.ObtenirAutorisationPREMQ(objParamEntree).Autorisations;
        }

        /// <summary>
        /// parametre la valeur d'entree et reactive la derogation
        /// </summary>
        /// <param name="numeroSequentielDispensateur"></param>
        /// <param name="dateDebutDerog"></param>
        /// <param name="codeRaisonStatut"></param>
        /// <param name="datDebNonParticipation"></param>
        IList<IMsgTrait> CreerParametreModifierDerogationEntre(long numeroSequentielDispensateur, DateTime dateDebutDerog, string codeRaisonStatut, DateTime datDebNonParticipation)
        {

            var messagesErreurs = new List<IMsgTrait>();

            //-recuperations des infos de la derogation inactive

            int cpt = ObtenirLesDerogationsInactives(numeroSequentielDispensateur).Where(u => u.DateDebut == dateDebutDerog).Count();
            if (cpt > 0 && cpt <= 3)
            {
                var itemInactif = cpt == 2 ? ObtenirLesDerogationsInactives(numeroSequentielDispensateur).Where(u => u.DateDebut == dateDebutDerog
                                                                                                                && u.Statut == "AUT").FirstOrDefault()
                                           : ObtenirLesDerogationsInactives(numeroSequentielDispensateur).Where(u => u.DateDebut == dateDebutDerog
                                                                                                                  && u.Statut == "TER"
                                                                                                                  && u.DateFin != datDebNonParticipation.AddDays(-1)).FirstOrDefault();


                var itemInactifNumSeq = ObtenirLesDerogationsInactives(numeroSequentielDispensateur).Where(u => u.DateDebut == dateDebutDerog).Max(m => m.NumeroSequentiel);
                if (itemInactif != null)
                {
                    ModifierDerogationEntre objParamEntree = new ModifierDerogationEntre();

                    objParamEntree.NumeroSequentiel = itemInactifNumSeq;
                    objParamEntree.NumeroSequentielDispensateur = numeroSequentielDispensateur;
                    objParamEntree.Type = itemInactif.Type;
                    objParamEntree.DateRenouvellement = itemInactif.DateRenouvellement;
                    objParamEntree.DateDebut = itemInactif.DateDebut;
                    objParamEntree.DateFin = itemInactif.DateFin;
                    objParamEntree.Statut = itemInactif.Statut;
                    objParamEntree.CodeRaisonStatut = itemInactif.CodeRaisonStatut;

                    var res = ReactivationDerogationProfessionel(objParamEntree);
                    messagesErreurs.AddRange(res.InfoMsgTrait);
                }
            }
            else
            {
                EnvoyCourlEntre objParamEntreCourl = new EnvoyCourlEntre
                {
                    Expediteur = System.Configuration.ConfigurationManager.AppSettings["AdresseExpediteur"],
                    Destinataire = System.Configuration.ConfigurationManager.AppSettings["AdresseDestinataire"],
                    Format = EnumFormatMessage.Texte,
                    EncodageMsg = EnumEncodMsgCourl.UTF8,
                    Importance = EnumImportanceCourl.Normal
                };
                ContenuCourlEntre contenuEntre = new ContenuCourlEntre
                {
                    NumeroSequentielDispensateur = numeroSequentielDispensateur,
                    DatDebNonPartn = datDebNonParticipation,
                    PlusieurStatutDerogation = true
                };
                EnvoyerCourlConfr(objParamEntreCourl, EnumRaisonCourriel.Derogation, contenuEntre);
            }
            return messagesErreurs.ToList();

        }


        /// <summary>
        /// parametre la valeur d'entree et reactive l'autorisation
        /// </summary>
        /// <param name="numeroSequentielDispensateur"></param>
        /// <param name="dateDebutAutor"></param>
        /// <param name="codeRaisonStatut"></param>
        IList<IMsgTrait> CreerParametreModifierAutorisationEntre(long numeroSequentielDispensateur, DateTime dateDebutAutor, string codeRaisonStatut)
        {
            var messagesErreurs = new List<IMsgTrait>();
            //-recuperations des infos de l'autorisation inactive
            var itemInactif = ObtenirLesAutorisations(numeroSequentielDispensateur).Where(u => u.DateDebut == dateDebutAutor && u.DateHeureInactivation == null).FirstOrDefault();
            var item = ObtenirLesAutorisations(numeroSequentielDispensateur).Where(u => u.DateDebut == dateDebutAutor && u.DateHeureInactivation != null).FirstOrDefault();
            if (item != null && itemInactif != null)
            {
                ModifierAutorisationEntre objParamEntree = new ModifierAutorisationEntre();

                objParamEntree.NumeroSequentiel = itemInactif.NumeroSequence;
                objParamEntree.NumeroSequentielDispensateur = item.NumeroSequenceDispensateur;
                objParamEntree.TypeAutor = item.Type;
                objParamEntree.TypeLgeo = item.TypeLieuGeographique;
                objParamEntree.CodeLgeo = item.CodeLieuGeographique;
                objParamEntree.NumeroSeqRegrAdmnLgeo = item.NumeroSequenceRegroupementAdministratif;
                objParamEntree.DateDebut = item.DateDebut;
                objParamEntree.DateFin = item.DateFin;
                objParamEntree.CodeRaisonStatut = codeRaisonStatut;// "4";

                var res = ReactivationAutorisationProfessionel(objParamEntree);
                messagesErreurs.AddRange(res.InfoMsgTrait);
            }
            return messagesErreurs.ToList();

        }




        #endregion

        #region methodes communes


        /// <summary>
        /// Permet de Reactiver les differents status de l'avis de conformités avant fermeture pour raison de non participation
        /// </summary>
        /// <param name="avisConformites"></param>
        /// <param name="numeroSequentielDispensateur"></param>
        /// <param name="dateNonParticipation"></param>
        /// <param name="ferme"></param>
        /// <param name="codRaisonStatutEntre"></param>
        /// si ferme est vraie, les avis conformites fermés sont traités sinon les avis annulés

        public IList<IMsgTrait> ReactivationAvisConfFermeAnnule(List<EntiteCPOAvis.AvisConformite> avisConformites, long numeroSequentielDispensateur, DateTime dateNonParticipation, bool ferme, CodRaisonStatutEntre codRaisonStatutEntre)
        {
            var messagesErreurs = new List<IMsgTrait>();
            foreach (var avis in avisConformites)
            {

                var cpt = ObtenirNombreStatutsAvisConformite(avis);

                ModifierAvisConformiteStatutSorti modifierAvisConformiteStatutSorti = InactiverAvisConformiteTermine(avis);
                messagesErreurs.AddRange(modifierAvisConformiteStatutSorti.InfoMsgTrait);

                var statutEngagement = ferme ? "TER" : "ANN";
                if (modifierAvisConformiteStatutSorti != null && modifierAvisConformiteStatutSorti.DateHeureOccurence != null)
                {
                    //var statutEngagement = ferme ? "TER" : "ANN";
                    FermetureAvisConformite(avis.NumeroSequentielEngagement.Value, codRaisonStatutEntre.CodeRaisonStatutReactivationAvisConf, statutEngagement, dateNonParticipation);

                    CreerAvisConformiteSorti creerAvisConformiteSorti = ReactiverAvisConformite(avis, dateNonParticipation, ferme, codRaisonStatutEntre.CodeRaisonStatutAvisConf);
                    messagesErreurs.AddRange(creerAvisConformiteSorti.InfoMsgTrait);

                    #region cas complexe     
                    //-un avis pour plusieurs stauts ex - AUT-SUS-AUT    
                    var numSeqEngag = creerAvisConformiteSorti.NumeroSequentielEngagement;
                    if (cpt > 1 && numSeqEngag > 0)
                    {

                        #region recuperation des informations de l'avis créée
                        var intrantAvis = new ObtenirLesAvisConformiteEntre
                        {
                            NumeroSequentielDispensateur = numeroSequentielDispensateur,
                            NumeroSequentielEngagement = numSeqEngag,
                            IndicateurAvisInactive = "N"
                        };
                        var nouvAvisConf = _avisConformite.ObtenirLesAvisConformite(intrantAvis);
                        if (nouvAvisConf.ListeAvisConformite.Any())
                        {
                            var numSeqStatEngag = nouvAvisConf.ListeAvisConformite[0].ListeStatutAvisConformite[0].NumeroSequentielStatutEngagement;

                            #endregion

                            #region creation des status - PLA2

                            var res = InactivationCreationStatuts(avis, nouvAvisConf, numSeqStatEngag.Value, ferme);
                            messagesErreurs.AddRange(res);



                        }
                        #endregion
                    }
                    #endregion

                    #region Fermeture de l'avis....
                    //--l'avis est terminé/annulé avant la periode de non participation--on le remet en l'etat
                    var autreAvisExist = ObtenirDateProchainEngagementAnnuledelaSequence(numeroSequentielDispensateur, avis, statutEngagement, dateNonParticipation);
                    if (autreAvisExist != null)
                    {
                        var intrantAv = new ObtenirLesAvisConformiteEntre
                        {
                            NumeroSequentielDispensateur = numeroSequentielDispensateur,
                            NumeroSequentielEngagement = numSeqEngag,
                            IndicateurAvisInactive = "N"
                        };
                        var nouvAvisConfSorti = _avisConformite.ObtenirLesAvisConformite(intrantAv);
                        if (nouvAvisConfSorti.ListeAvisConformite.Any())
                        {
                            var nouvAvis = nouvAvisConfSorti.ListeAvisConformite[0];
                           
                            var statutAv = avis.ListeStatutAvisConformite.Where(w => w.StatutEngagement == statutEngagement && w.DateHeureOccurenceInactive != null).FirstOrDefault();
                            string codRaison = statutAv != null ? statutAv.CodeRaisonStatutEngagement : codRaisonStatutEntre.CodeRaisonStatutAvisConf;
                          
                            var res = ModifierPeriodeAvisConf(true, nouvAvis, autreAvisExist.Value, codRaison);
                            messagesErreurs.AddRange(res);

                        }
                    }
                    #endregion

                }

            }
            return messagesErreurs.ToList();
        }


        /// <summary>
        /// permet de recuperer la date du prochain engagement annule de la sequence
        /// </summary>
        /// <param name="numeroSequentielDispensateur"></param>
        /// <param name="avis"></param>
        /// <param name="statutEngagement"></param>
        /// <param name="dateNonParticipation"></param>
        /// <returns></returns>
        public DateTime? ObtenirDateProchainEngagementAnnuledelaSequence(long numeroSequentielDispensateur, EntiteCPOAvis.AvisConformite avis, string statutEngagement, DateTime dateNonParticipation)
        {
            ObtenirLesAvisConformiteEntre avEntre = new ObtenirLesAvisConformiteEntre { NumeroSequentielDispensateur = numeroSequentielDispensateur };
            List<EntiteCPOAvis.AvisConformite> avisConformites = _avisConformite.ObtenirLesAvisConformite(avEntre).ListeAvisConformite;
            ObtenirDerogationsProfessionnelSanteEntre derogEntre = new ObtenirDerogationsProfessionnelSanteEntre { NumeroSequentielDispensateur = numeroSequentielDispensateur, IndicateurDerogationInactive = "O" };
            List<PRE_Entites_cpo.Derogation.Entite.Derogation> lesderogations = _derogation.ObtenirDerogationProfessionnel(derogEntre).Derogations.Where(d => d.DateDebut > dateNonParticipation && d.Statut == "ANN").ToList();
            LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre autorisationEntre = new LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre { NumeroSequentielDispensateur = numeroSequentielDispensateur };
            var lesAutorisations = _autorisation.ObtenirAutorisationPREMQ(autorisationEntre).Autorisations.Where(d => d.DateDebut > dateNonParticipation && d.DateHeureInactivation != null).ToList();


            //--l'avis est terminé/annulé avant la periode de non participation--on le remet en l'etat
            EntiteCPOAvis.AvisConformite autreAvisExist = null;
            if (avisConformites.Count() > 1)
            {
                var statTerminAnnule = (from a in avis.ListeStatutAvisConformite
                                        where a.StatutEngagement.Equals(statutEngagement) && a.DateHeureOccurenceInactive != null
                                        && a.DateDebutStatutEngagement.Equals(avis.ListeStatutAvisConformite.Max(m => m.DateFinStatutEngagement).Value.AddDays(1))
                                        select a).FirstOrDefault();

                if (statTerminAnnule != null)
                {
                    autreAvisExist = avisConformites.Where(a => a.DateDebutEngagement == statTerminAnnule.DateDebutStatutEngagement).FirstOrDefault();
                    if (autreAvisExist != null)
                    { return autreAvisExist.DateDebutEngagement; }
                    else if (lesderogations.Count > 0 || lesAutorisations.Count > 0)
                    {
                        return avis.ListeStatutAvisConformite.Max(m => m.DateFinStatutEngagement).Value.AddDays(1);
                    }

                }

            }
            else if (avisConformites.Count == 1 && (lesderogations.Count > 0 || lesAutorisations.Count > 0))
            {
                return avis.ListeStatutAvisConformite.Max(m => m.DateFinStatutEngagement).Value.AddDays(1);
            }
            return null;

        }
        /// <summary>
        /// permet d'obtenir le nombre les differents stauts distinct de l'avis de conformité
        /// </summary>
        /// <param name="avis"></param>
        /// <returns></returns>
        public int ObtenirNombreStatutsAvisConformite(EntiteCPOAvis.AvisConformite avis)
        {
            var result = avis.ListeStatutAvisConformite.Where(s => s.StatutEngagement != "TER" && s.StatutEngagement != "ANN")
                                                        .Select(s => new { s.StatutEngagement, s.DateDebutStatutEngagement })
                                                        .Distinct().ToList();
            return result != null ? result.Count() : 0;
        }
        /// <summary>
        /// Permet de reactiver toute derogation fermée ou annulée pour raison de non particpation
        /// </summary>
        /// <param name="numeroSequentielDispensateur"></param>
        /// <param name="lstDerogFermees"></param>
        /// <param name="lstDerogAnnulees"></param>
        /// <param name="dateNonParticipation"></param>
        /// <returns></returns>       
        public TraiterEngagementSorti ReactiverDerogation(long numeroSequentielDispensateur, List<PRE_Entites_cpo.Derogation.Entite.Derogation> lstDerogFermees, List<PRE_Entites_cpo.Derogation.Entite.Derogation> lstDerogAnnulees, DateTime dateNonParticipation)
        {
            TraiterEngagementSorti traiterEngagementSorti = new TraiterEngagementSorti();
            var messagesErreurs = new List<IMsgTrait>();
            if (lstDerogFermees != null && lstDerogFermees.Count > 0)
            {
                foreach (var derogation in lstDerogFermees)
                {

                    var res = CreerParametreModifierDerogationEntre(numeroSequentielDispensateur, derogation.DateDebut, Constante.EvtModif_CodeRaiStaDerogationDatNPartPosterieur, dateNonParticipation);
                    messagesErreurs.AddRange(res);

                }
            }
            //-reactivation des derogations d'avant annulation
            if (lstDerogAnnulees != null && lstDerogAnnulees.Count > 0)
            {
                foreach (var derogation in lstDerogAnnulees)
                {
                    var res = CreerParametreModifierDerogationEntre(numeroSequentielDispensateur, derogation.DateDebut, Constante.EvtModif_CodeRaiStaDerogationDatNPartPosterieur, dateNonParticipation);
                    messagesErreurs.AddRange(res);
                }
            }
            if (!messagesErreurs.Any())
            {
                traiterEngagementSorti.EstTraite = true;
            }
            traiterEngagementSorti.InfoMsgTrait = messagesErreurs;
            //return messagesErreurs;
            return traiterEngagementSorti;
        }
        /// <summary>
        /// Permet de reactiver toute Autorisation fermée ou annulée pour raison de non particpation
        /// </summary>
        /// <param name="numeroSequentielDispensateur"></param>
        /// <param name="lstAutorisationFermees"></param>
        /// <param name="lstAutorisationAnnulees"></param>
        /// <returns></returns>
        public TraiterEngagementSorti ReactiverAutorisation(long numeroSequentielDispensateur, List<PL_LogiqueAffaire_cpo.Entites.Autorisation> lstAutorisationFermees, List<PL_LogiqueAffaire_cpo.Entites.Autorisation> lstAutorisationAnnulees)
        {
            TraiterEngagementSorti traiterEngagementSorti = new TraiterEngagementSorti();

            var messagesErreurs = new List<IMsgTrait>();
            if (lstAutorisationFermees != null && lstAutorisationFermees.Count > 0)
            {
                foreach (var autorisation in lstAutorisationFermees)
                {

                    var res = CreerParametreModifierAutorisationEntre(numeroSequentielDispensateur, autorisation.DateDebut, Constante.EvtModif_CodeRaiStaAutorisationDatNPartPosterieur);
                    messagesErreurs.AddRange(res);

                }
            }
            //-reactivation des autorisations d'avant annulation
            if (lstAutorisationAnnulees != null && lstAutorisationAnnulees.Count > 0)
            {
                foreach (var autorisation in lstAutorisationAnnulees)
                {
                    var res = CreerParametreModifierAutorisationEntre(numeroSequentielDispensateur, autorisation.DateDebut, Constante.EvtModif_CodeRaiStaAutorisationDatNPartPosterieur);
                    messagesErreurs.AddRange(res);
                }
            }

            if (!messagesErreurs.Any())
            {
                traiterEngagementSorti.EstTraite = true;
            }
            traiterEngagementSorti.InfoMsgTrait = messagesErreurs;

            return traiterEngagementSorti;
        }

        /// <summary>
        /// Permet de reactiver toute avis de conformite fermée ou annulée pour raison de non particpation
        /// </summary>
        /// <param name="numeroSequentielDispensateur"></param>
        /// <param name="dateNonParticipation"></param>
        /// <param name="avisConfFermees"></param>
        /// <param name="avisConfAnnulees"></param>
        /// <param name="codRaisonStatutEntre"></param>
        /// <returns></returns>
        public TraiterEngagementSorti ReactiverAvis(long numeroSequentielDispensateur, DateTime dateNonParticipation, List<EntiteCPOAvis.AvisConformite> avisConfFermees, List<EntiteCPOAvis.AvisConformite> avisConfAnnulees, CodRaisonStatutEntre codRaisonStatutEntre)
        {
            TraiterEngagementSorti traiterEngagementSorti = new TraiterEngagementSorti();
            var messagesErreurs = new List<IMsgTrait>();
            if (avisConfFermees != null && avisConfFermees.Count > 0)
            {
                var res = ReactivationAvisConfFermeAnnule(avisConfFermees, numeroSequentielDispensateur, dateNonParticipation, true, codRaisonStatutEntre);
                messagesErreurs.AddRange(res);
            }
            //-reactivation des avis d'avant annulation
            if (avisConfAnnulees != null && avisConfAnnulees.Count > 0)
            {
                var res = ReactivationAvisConfFermeAnnule(avisConfAnnulees, numeroSequentielDispensateur, dateNonParticipation, false, codRaisonStatutEntre);
                messagesErreurs.AddRange(res);
            }
            if (!messagesErreurs.Any())
            {
                traiterEngagementSorti.EstTraite = true;
            }
            traiterEngagementSorti.InfoMsgTrait = messagesErreurs;
            return traiterEngagementSorti;
        }

        /// <summary>
        /// Permet de verifier il s'agit de l'ajout ou de la modification ou retrait date de spécialité
        /// </summary>
        /// <param name="param"></param>
        /// <returns>False si il s'agit d'une modification ou retrait de date de spécialité sinon retourne True pour l'ajout de la 1ère date de spécialité</returns>
        public bool? VerificationMiseAJourDatePremSpec(AjusEngagDdSpecInscrEntre param)
        {

            if (param.InfoDispOrign != null && param.InfoDispModif != null)
            {
                return !param.InfoDispOrign.DdSpecialite.HasValue && param.InfoDispModif.DdSpecialite.HasValue ? true : false;

            }
            return null;
        }

        /// <summary>
        /// Permet de verifier il s'agit de l'ajout ou de la modification ou retrait date de décès
        /// </summary>
        /// <param name="param"></param>
        /// <returns>False si il s'agit d'une modification ou retrait de date de spécialité sinon retourne True pour l'ajout</returns>
        public bool? VerificationMiseAJourDatePremDec(AjusEngagDecesEntre param)
        {

            if (param.InfoOrignIndiv != null && param.InfoModifIndiv != null)
            {
                return !param.InfoOrignIndiv.DateDeces.HasValue && param.InfoModifIndiv.DateDeces.HasValue ? true : false;

            }
            return null;
        }

        #region modification dossier du medecin
        /// <summary>
        /// Permet de verifier si il ya eu des modifications au dossier du medecin ,si oui un courriel est envoye
        /// </summary>
        /// <returns>si False,aucune modification effectuée</returns>
        public bool VerificationMAJDossier(ObtenirDispensateurIndividuEntre param, DateTime dDNonPartn, EnvoyCourlEntre objParamEntreCourl, OperationEvt operationEvt)
        {

            bool result = false;
            bool resultDatePremSpec = false;
            bool resultDateDeces = false;

            ObtenirDispensateurIndividuSorti dispensateurIndividu = _professionnel.ObtenirInformationProfessionnel(param);
            if (dispensateurIndividu != null)
            {
                if (operationEvt != OperationEvt.OperationPremièreSpecialite)
                {

                    if (dispensateurIndividu.DatesPremiereSpecialite.Any() && dispensateurIndividu.DatesPremiereSpecialite[0].HasValue)
                    {
                        DateTime? datePremSpec = dispensateurIndividu.DatesPremiereSpecialite.FirstOrDefault().Value;
                        resultDatePremSpec = datePremSpec.HasValue && datePremSpec.Value >= dDNonPartn;
                        if (resultDatePremSpec)
                        {
                            ContenuCourlEntre contenuEntre = new ContenuCourlEntre
                            {
                                NumeroSequentielDispensateur = dispensateurIndividu.NumerosSequentielDispensateur.LastOrDefault().Value,
                                NumeroDispensateur = dispensateurIndividu.NumerosDispensateur.LastOrDefault().Value,
                                DateDebPremSpec = datePremSpec.Value
                                ,
                                Evt = operationEvt
                            };
                            EnvoyerCourlConfr(objParamEntreCourl, EnumRaisonCourriel.Specialiste, contenuEntre);
                        }
                    }
                }               
                resultDateDeces = dispensateurIndividu.DatesDecesIndividu.Any() && dispensateurIndividu.DatesDecesIndividu[0].HasValue && operationEvt!=OperationEvt.OperationDeces;

                if (resultDateDeces)
                {
                    ContenuCourlEntre contenuEntre = new ContenuCourlEntre
                    {
                        NumeroSequentielIndividu = dispensateurIndividu.NumerosSequentielIndividu.LastOrDefault().Value,
                        Nom = dispensateurIndividu.NomsIndividu.FirstOrDefault(),
                        Prenom = dispensateurIndividu.PrenomsIndividu.FirstOrDefault(),
                        DateDeces = dispensateurIndividu.DatesDecesIndividu.FirstOrDefault().Value

                        ,
                        Evt = operationEvt
                    };
                    EnvoyerCourlConfr(objParamEntreCourl, EnumRaisonCourriel.Deces, contenuEntre);

                }
                return (resultDatePremSpec || resultDateDeces);

            }

            return result;

        }


        #endregion

        /// <summary>
        /// permet de verifier si il n'ya pas eu de modification au dossier du medecin omnipraticien et si il n'ya pas eu de nouveau engagement apres la date de non partcipation
        /// si oui un courriel est envoyé
        /// </summary>
        /// <param name="noSeqIntervenant"></param>
        /// <param name="dateNParticipation"></param>
        /// <param name="operationEvt"></param>
        /// <returns></returns>
        public bool VerifierMAJDossierEngagement(long noSeqIntervenant, DateTime dateNParticipation, OperationEvt operationEvt)
        {
            long numeroSequentielDispensateur = noSeqIntervenant;

            DateTime dateNonParticipation = dateNParticipation;

            EnvoyCourlEntre objParamEntreCourl = new EnvoyCourlEntre
            {
                Expediteur = System.Configuration.ConfigurationManager.AppSettings["AdresseExpediteur"],
                Destinataire = System.Configuration.ConfigurationManager.AppSettings["AdresseDestinataire"],
                Format = EnumFormatMessage.Texte,
                EncodageMsg = EnumEncodMsgCourl.UTF8,
                Importance = EnumImportanceCourl.Normal
            };
            ObtenirDispensateurIndividuEntre intant = new ObtenirDispensateurIndividuEntre() { NumeroSequentielDispensateur = numeroSequentielDispensateur };
            bool majDossier = VerificationMAJDossier(intant, dateNonParticipation, objParamEntreCourl, operationEvt);
            bool engagementActif = majDossier ? false : VerifierEngagemnentActif(numeroSequentielDispensateur, dateNonParticipation, objParamEntreCourl,operationEvt);

            return majDossier || engagementActif;
        }

        /// <summary>
        /// envoi de courriel
        /// </summary>
        /// <param name="objParamEntre"></param>
        /// <param name="raisonCourriel"></param>
        /// <param name="contenuMsg"></param>
        public bool EnvoyerCourlConfr(EnvoyCourlEntre objParamEntre, EnumRaisonCourriel raisonCourriel, ContenuCourlEntre contenuMsg)
        {
            IMessage objCourl;
            MessageSMTP objSmtp = new MessageSMTP();
            var extrant = false;
            string sujet = string.Empty;
            string message = string.Empty;
            ArrayList contenu = new ArrayList();

            try
            {
                string libelleDateEvtNP = " -Date de début de la non - participation  : ";
                string libelleDateEvtSpec = "- Date de début de première spécialité : ";
                string libelleDateEvtDec = "- Date de décès                    : ";
                string libelleDate = string.Empty;

                switch (raisonCourriel)
                {
                    case EnumRaisonCourriel.Autorisation:
                        sujet = contenuMsg.Evt.HasValue ? contenuMsg.Evt.Value == OperationEvt.OperationNonAdmissibilite ? Constante.TypeEvenementNonparticipation
                                                                                                  : contenuMsg.Evt.Value == OperationEvt.OperationDeces ?
                                                                                                   Constante.TypeEvenemenDeces : Constante.TypeEvenementPremiereSpecialite
                                                                                                  : Constante.TypeEvenementNonparticipation;
                         libelleDate = sujet == Constante.TypeEvenementNonparticipation ? libelleDateEvtNP : sujet.Equals(Constante.TypeEvenementPremiereSpecialite) ? libelleDateEvtSpec
                                                                                                            : libelleDateEvtDec;
                        contenu.Add(Constante.MessageAutorisation);
                        contenu.Add("- Numéro séquentiel du dispensateur      : " + contenuMsg.NumeroSequentielDispensateur.ToString());
                        contenu.Add(libelleDate + contenuMsg.DatDebNonPartn.ToString());
                        break;
                    case EnumRaisonCourriel.AvisConformite:
                        sujet = contenuMsg.Evt.HasValue ? contenuMsg.Evt.Value == OperationEvt.OperationNonAdmissibilite ? Constante.TypeEvenementNonparticipation
                                                                                                  : contenuMsg.Evt.Value == OperationEvt.OperationDeces ?
                                                                                                   Constante.TypeEvenemenDeces : Constante.TypeEvenementPremiereSpecialite
                                                                                                  : Constante.TypeEvenementNonparticipation;
                         libelleDate = sujet == Constante.TypeEvenementNonparticipation ? libelleDateEvtNP : sujet.Equals(Constante.TypeEvenementPremiereSpecialite) ? libelleDateEvtSpec
                                                                                                            : libelleDateEvtDec;
                        contenu.Add(Constante.MessageAvisConformite);
                        contenu.Add("- Numéro séquentiel du dispensateur      : " + contenuMsg.NumeroSequentielDispensateur.ToString());
                        contenu.Add(libelleDate + contenuMsg.DatDebNonPartn.ToString());
                        break;
                    case EnumRaisonCourriel.Derogation:                         
                        sujet = contenuMsg.Evt.HasValue ? contenuMsg.Evt.Value == OperationEvt.OperationNonAdmissibilite ? Constante.TypeEvenementNonparticipation
                                                                                                      : contenuMsg.Evt.Value == OperationEvt.OperationDeces ?
                                                                                                       Constante.TypeEvenemenDeces : Constante.TypeEvenementPremiereSpecialite
                                                                                                      : Constante.TypeEvenementNonparticipation;

                        string msgDerogation = contenuMsg.PlusieurStatutDerogation.HasValue ? Constante.MessageDerogationPlusieurStatuts : Constante.MessageDerogation;
                        contenu.Add(msgDerogation);
                        contenu.Add("- Numéro séquentiel du dispensateur      : " + contenuMsg.NumeroSequentielDispensateur.ToString());

                         libelleDate = sujet == Constante.TypeEvenementNonparticipation ? libelleDateEvtNP : sujet.Equals(Constante.TypeEvenementPremiereSpecialite) ? libelleDateEvtSpec
                                                                                                             : libelleDateEvtDec;
                        contenu.Add(libelleDate + contenuMsg.DatDebNonPartn.ToString());
                        break;
                    case EnumRaisonCourriel.Specialiste:
                        sujet = contenuMsg.Evt.HasValue ? contenuMsg.Evt.Value == OperationEvt.OperationNonAdmissibilite ? Constante.TypeEvenementNonparticipation
                                                                                                               : contenuMsg.Evt.Value == OperationEvt.OperationDeces ?
                                                                                                                Constante.TypeEvenemenDeces : Constante.TypeEvenementPremiereSpecialite
                                                : Constante.TypeEvenementPremiereSpecialite;
                        contenu.Add(Constante.MessageSpecialiste);
                        contenu.Add("- Numéro séquentiel du dispensateur    : " + contenuMsg.NumeroSequentielDispensateur.ToString());
                        contenu.Add("- Numéro du dispensateur               : " + contenuMsg.NumeroDispensateur.ToString());
                        contenu.Add(libelleDateEvtSpec + contenuMsg.DateDebPremSpec.ToString());
                        break;
                    case EnumRaisonCourriel.Deces:
                        sujet = contenuMsg.Evt.HasValue ? contenuMsg.Evt.Value == OperationEvt.OperationNonAdmissibilite ? Constante.TypeEvenementNonparticipation
                                                                                                                      : contenuMsg.Evt.Value == OperationEvt.OperationPremièreSpecialite ?
                                                                                                                       Constante.TypeEvenementPremiereSpecialite : Constante.TypeEvenemenDeces
                                                       : Constante.TypeEvenemenDeces;
                        contenu.Add(Constante.MessageDeces);
                        contenu.Add("- Numéro séquentiel de l’individu  : " + contenuMsg.NumeroSequentielIndividu.ToString());
                        contenu.Add("- Nom                              : " + contenuMsg.Nom);
                        contenu.Add("- Prenom                           : " + contenuMsg.Prenom);
                        contenu.Add(libelleDateEvtDec + contenuMsg.DateDeces.ToString());
                        break;
                }

                objCourl = new MessageCourl
                {
                    Sujet = sujet,
                    Message = string.Join("\n", contenu.ToArray()),
                    Expediteur = objParamEntre.Expediteur,
                    Destinataire = objParamEntre.Destinataire,
                    Format = objParamEntre.Format,
                    EncodageMsg = objParamEntre.EncodageMsg,
                    Importance = objParamEntre.Importance

                };

                objSmtp.Envoyer(objCourl);

                extrant = true;
            }
            catch
            {
                throw;
            }
            return extrant;
        }


        #endregion

    }
}