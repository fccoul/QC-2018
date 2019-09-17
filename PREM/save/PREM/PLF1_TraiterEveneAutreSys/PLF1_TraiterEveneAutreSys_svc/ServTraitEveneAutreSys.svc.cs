using RAMQ.AccesDonnees.BDOracle;
using RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo;
using RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.AjusterEngagement.Entite;
using RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.AjusterEngagement.Param;
using RAMQ.ServiceModel.Erreur;
using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using OutilCommun = RAMQ.PRE.PRE_OutilComun_cpo;

namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_svc
{
    /// <summary>
    /// Service PLF1
    /// </summary>
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single,
                     InstanceContextMode = InstanceContextMode.PerCall,
                     Namespace = "http://www.ramq.gouv.qc.ca/PRE/ServTraitEveneAutreSys")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class ServTraitEveneAutreSys : IServTraitEveneAutreSys
    {

        private readonly ITraitEveneAutreSys _traitEveneAutreSys;

        //-
        private readonly IAjusterEngagAvisConfNonParticipation _ajusterEngagAvisConfNonParticipation;
        private IAccesDonnesOra ClientAccesDonnesOra
        {
            get
            {
                return _clientFuncAccesDonnesOra();
            }
        }

        private readonly Func<IAccesDonnesOra> _clientFuncAccesDonnesOra;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="traitEveneAutreSys"></param>
        /// <param name="clientAccesDonnesOra"></param>
        /// <param name="ajusterEngagAvisConfNonParticipation"></param>
        public ServTraitEveneAutreSys(ITraitEveneAutreSys traitEveneAutreSys,
                                   Func<IAccesDonnesOra> clientAccesDonnesOra,
                                   IAjusterEngagAvisConfNonParticipation ajusterEngagAvisConfNonParticipation)
        {
            if (traitEveneAutreSys == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(traitEveneAutreSys)} ne peut être null.");
            }
            if (clientAccesDonnesOra == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(clientAccesDonnesOra)} ne peut être null.");
            }
            if (ajusterEngagAvisConfNonParticipation == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(ajusterEngagAvisConfNonParticipation)} ne peut être null.");
            }


            _traitEveneAutreSys = traitEveneAutreSys;
            _clientFuncAccesDonnesOra = clientAccesDonnesOra;
            _ajusterEngagAvisConfNonParticipation = ajusterEngagAvisConfNonParticipation;
        }


        #region Méthodes publiques

        /// <summary>
        ///
        /// </summary>
        /// <param name="objParamEntree"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public ParamSortiAjusterAvisConformiteMedResidents AjusterAvisConformiteMedResidents(ParamEntreAjusterAvisConformiteMedResidents objParamEntree)
        {
            return AppelerCpo(x => x.AjusterAvisConformiteMedResidents(objParamEntree));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objParamEntree"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [Obsolete("Cette méthode sera remplacée.")]
        public ParamSortiTraiterAdmissProf TraiterAdmissibiliteDuProfessionnel(ParamEntreTraiterAdmissProf objParamEntree)
        {
            return AppelerCpo(x => x.TraiterAdmissibiliteDuProfessionnel(objParamEntree));
        }


        #region sans appel Biztalk
        /// <summary>
        ///  Ajuster les engagements PREM du médecin omnipraticien pour lequel une période
        ///  de non-participation est inscrite.
        /// </summary>
        [Obsolete("veuillez utiliser la methode avec AjusEngagAjouNonPartnEntreBizTalk")]
        public AjusEngagAjouNonPartnSorti AjusterEngagAjouNonPartn(AjusEngagAjouNonPartnEntre param)
        {

            return AppelerCpo<AjusEngagAjouNonPartnSorti>(x => x.TraiterEngagementInscriptionDateNonParticipation(param, OperationEvt.OperationNonAdmissibilite));

        }


        /// <summary>
        ///  Ajuster les engagements PREM du médecin omnipraticien pour lequel une période
        ///  de non-participation est modifiée.
        /// </summary>
        [Obsolete("veuillez utiliser la methode avec AjusEngagModifNonPartnEntreBiztalk")]
        public AjusEngagModifNonPartnSorti AjusterEngagModifNonPartn(AjusEngagModifNonPartnEntre param)
        {
            return AppelerCpo<AjusEngagModifNonPartnSorti>(x => x.TraiterEngagementModifDateNonParticipation(param, OperationEvt.OperationNonAdmissibilite));
        }


        /// <summary>
        ///  Ajuster les engagements PREM du médecin omnipraticien pour lequel une période
        ///  de non-participation est annulée.
        /// </summary>
        [Obsolete("veuillez utiliser la methode avec AjusEngagAnnuNonPartnEntreBizTalk")]
        public AjusEngagAnnuNonPartnSorti AjusterEngagAnnuNonPartn(AjusEngagAnnuNonPartnEntre param)
        {
            return AppelerCpo<AjusEngagAnnuNonPartnSorti>(x => x.TraiterEngagementAnnuDateNonParticipation(param, OperationEvt.OperationNonAdmissibilite));
        }


        /// <summary>
        ///  Ajuster les engagements PREM du médecin omnipraticien pour lequel un déces a 
        ///  été inscrit.
        /// </summary>
        [Obsolete("veuillez utiliser la methode avec AjusEngagDecesEntreBizTalk")]
        public AjusEngagDecesSorti AjusterEngagDeces(AjusEngagDecesEntre param)
        {
            return AppelerCpo<AjusEngagDecesSorti>(x => x.TraiterEngagementDeces(param, OperationEvt.OperationDeces));

        }


        /// <summary>
        ///  Ajuster les engagements PREM du médecin omnipraticien pour lequel une date de
        ///  début de spécialité a été inscrite.
        /// </summary>
        [Obsolete("veuillez utiliser la methode avec AjusEngagDdSpecInscrEntreBizTalk")]
        public AjusEngagDdSpecInscrSorti AjusterEngagDdSpecInscr(AjusEngagDdSpecInscrEntre param)
        {
            return AppelerCpo<AjusEngagDdSpecInscrSorti>(x => x.TraiterEngagementPremiereSpecialiteDeces(param, OperationEvt.OperationPremièreSpecialite));
        }

        #endregion

        #endregion


        #region appel BizTalk
        /// <summary>
        ///  Ajuster les engagements PREM du médecin omnipraticien pour lequel une période
        ///  de non-participation est inscrite.
        /// </summary>
        public AjusEngagAjouNonPartnSorti AjusterEngagAjouNonPartnBiztalk(AjusEngagAjouNonPartnEntreBizTalk paramBizTalk)
        {
            //-cast to AjusEngagAjouNonPartnEntre
            AjusEngagAjouNonPartnEntre param = new AjusEngagAjouNonPartnEntre
            {               
                NoSeqIntervenant = long.Parse(paramBizTalk.NoSeqIntervenant),
                NoSeqPerAdmis = long.Parse(paramBizTalk.NoSeqPerAdmis),
                NouvPerAdmis = new PerAdmis
                {
                    CodRaisNonAdmis = paramBizTalk.NouvPerAdmis.CodRaisNonAdmis,
                    Statut = paramBizTalk.NouvPerAdmis.Statut,
                    Dd = DateTime.Parse(paramBizTalk.NouvPerAdmis.Dd)
                },
                TypeIntervenant = paramBizTalk.TypeIntervenant
            };
            if (!string.IsNullOrWhiteSpace(paramBizTalk.DmAdmis))
            { param.DmAdmis= DateTime.Parse(paramBizTalk.DmAdmis); }

            if (!string.IsNullOrEmpty(paramBizTalk.NouvPerAdmis.Df))
            { param.NouvPerAdmis.Df = DateTime.Parse(paramBizTalk.NouvPerAdmis.Df); }

            return AjusterEngagAjouNonPartn(param);

        }


        /// <summary>
        ///  Ajuster les engagements PREM du médecin omnipraticien pour lequel une période
        ///  de non-participation est modifiée.
        /// </summary>
        public AjusEngagModifNonPartnSorti AjusterEngagModifNonPartnBiztalk(AjusEngagModifNonPartnEntreBiztalk paramBizTalk)
        {
            //-cast to AjusEngagModifNonPartnEntre
            AjusEngagModifNonPartnEntre param = new AjusEngagModifNonPartnEntre
            {                 
                NoSeqIntervenant = long.Parse(paramBizTalk.NoSeqIntervenant),
                NoSeqPerAdmis = long.Parse(paramBizTalk.NoSeqPerAdmis),
                PerAdmisModif = new PerAdmis
                {
                    CodRaisNonAdmis = paramBizTalk.PerAdmisModif.CodRaisNonAdmis,
                    Statut = paramBizTalk.PerAdmisModif.Statut,
                    Dd = DateTime.Parse(paramBizTalk.PerAdmisModif.Dd)
                },
                PerAdmisOrign = new PerAdmis
                {
                    CodRaisNonAdmis = paramBizTalk.PerAdmisOrign.CodRaisNonAdmis,
                    Statut = paramBizTalk.PerAdmisOrign.Statut,
                    Dd = DateTime.Parse(paramBizTalk.PerAdmisOrign.Dd)
                },
                TypeIntervenant = paramBizTalk.TypeIntervenant
            };
            if (!string.IsNullOrEmpty(paramBizTalk.PerAdmisModif.Df))
            { param.PerAdmisModif.Df = DateTime.Parse(paramBizTalk.PerAdmisModif.Df); }
            if (!string.IsNullOrEmpty(paramBizTalk.PerAdmisOrign.Df))
            { param.PerAdmisOrign.Df = DateTime.Parse(paramBizTalk.PerAdmisOrign.Df); }

            if (!string.IsNullOrWhiteSpace(paramBizTalk.DmAdmis))
            { param.DmAdmis = DateTime.Parse(paramBizTalk.DmAdmis); }

            return AjusterEngagModifNonPartn(param);
        }

        /// <summary>
        ///  Ajuster les engagements PREM du médecin omnipraticien pour lequel une période
        ///  de non-participation est annulée.
        /// </summary>
        public AjusEngagAnnuNonPartnSorti AjusterEngagAnnuNonPartnBiztalk(AjusEngagAnnuNonPartnEntreBizTalk paramBizTalk)
        {
            //-cast to AjusEngagAnnuNonPartnEntre
            AjusEngagAnnuNonPartnEntre param = new AjusEngagAnnuNonPartnEntre
            {                 
                NoSeqIntervenant = long.Parse(paramBizTalk.NoSeqIntervenant),
                NoSeqPerAdmis = long.Parse(paramBizTalk.NoSeqPerAdmis),
                PerAdmisAnnu = new PerAdmis
                {
                    CodRaisNonAdmis = paramBizTalk.PerAdmisAnnu.CodRaisNonAdmis,
                    Statut = paramBizTalk.PerAdmisAnnu.Statut,
                    Dd = DateTime.Parse(paramBizTalk.PerAdmisAnnu.Dd)
                },

                TypeIntervenant = paramBizTalk.TypeIntervenant
            };
            if (!string.IsNullOrEmpty(paramBizTalk.PerAdmisAnnu.Df))
            { param.PerAdmisAnnu.Df = DateTime.Parse(paramBizTalk.PerAdmisAnnu.Df); }

            if (!string.IsNullOrWhiteSpace(paramBizTalk.DmAdmis))
            { param.DmAdmis = DateTime.Parse(paramBizTalk.DmAdmis); }

            return AjusterEngagAnnuNonPartn(param);
        }

        /// <summary>
        ///  Ajuster les engagements PREM du médecin omnipraticien pour lequel un déces a 
        ///  été inscrit.
        /// </summary>
        public AjusEngagDecesSorti AjusterEngagDecesBizTalk(AjusEngagDecesEntreBizTalk paramBizTalk)
        {
            //-cast to AjusEngagDecesEntre
            AjusEngagDecesEntre param = new AjusEngagDecesEntre
            {
                InfoModifIndiv = new Individu
                {
                    IdUtilCreat = paramBizTalk.InfoModifIndiv.IdUtilCreat,
                    Langue = paramBizTalk.InfoModifIndiv.Langue,
                    IdUtilMaj = paramBizTalk.InfoModifIndiv.IdUtilMaj,
                    NoSeq = long.Parse(paramBizTalk.InfoModifIndiv.NoSeq),
                    Sexe = paramBizTalk.InfoModifIndiv.Sexe,
                    StatutCivil = paramBizTalk.InfoModifIndiv.StatutCivil,
                    TitreCivilite = paramBizTalk.InfoModifIndiv.TitreCivilite
                },
                InfoOrignIndiv=new Individu
                {
                    IdUtilCreat = paramBizTalk.InfoOrignIndiv.IdUtilCreat,
                    Langue = paramBizTalk.InfoOrignIndiv.Langue,
                    IdUtilMaj = paramBizTalk.InfoOrignIndiv.IdUtilMaj,
                    NoSeq = long.Parse(paramBizTalk.InfoOrignIndiv.NoSeq),
                    Sexe = paramBizTalk.InfoOrignIndiv.Sexe,
                    StatutCivil = paramBizTalk.InfoOrignIndiv.StatutCivil,
                    TitreCivilite = paramBizTalk.InfoOrignIndiv.TitreCivilite
                }
            };

            #region Modif
            if (!string.IsNullOrWhiteSpace(paramBizTalk.InfoModifIndiv.DateDeces))
            { param.InfoModifIndiv.DateDeces = DateTime.Parse(paramBizTalk.InfoModifIndiv.DateDeces); }
            if (!string.IsNullOrWhiteSpace(paramBizTalk.InfoModifIndiv.Dc))
            { param.InfoModifIndiv.Dc = DateTime.Parse(paramBizTalk.InfoModifIndiv.Dc); }
            if (!string.IsNullOrWhiteSpace(paramBizTalk.InfoModifIndiv.Dm))
            { param.InfoModifIndiv.Dm = DateTime.Parse(paramBizTalk.InfoModifIndiv.Dm); }
            #endregion

            #region Origin
            if (!string.IsNullOrWhiteSpace(paramBizTalk.InfoOrignIndiv.DateDeces))
            { param.InfoOrignIndiv.DateDeces = DateTime.Parse(paramBizTalk.InfoOrignIndiv.DateDeces); }
            if (!string.IsNullOrWhiteSpace(paramBizTalk.InfoOrignIndiv.Dc))
            { param.InfoOrignIndiv.Dc = DateTime.Parse(paramBizTalk.InfoOrignIndiv.Dc); }
            if (!string.IsNullOrWhiteSpace(paramBizTalk.InfoOrignIndiv.Dm))
            { param.InfoOrignIndiv.Dm = DateTime.Parse(paramBizTalk.InfoOrignIndiv.Dm); }
            #endregion

            return AjusterEngagDeces(param);

        }

        /// <summary>
        ///  Ajuster les engagements PREM du médecin omnipraticien pour lequel une date de
        ///  début de spécialité a été inscrite.
        /// </summary>
        public AjusEngagDdSpecInscrSorti AjusterEngagDdSpecInscrBizTalk(AjusEngagDdSpecInscrEntreBizTalk paramBizTalk)
        {
            //-cast to AjusEngagDdSpecInscrEntre
            AjusEngagDdSpecInscrEntre param = new AjusEngagDdSpecInscrEntre
            {
                InfoDispModif=new Dispensateur
                {
                    ChiffrePreuve=byte.Parse(paramBizTalk.InfoDispModif.ChiffrePreuve),
                    Classe= byte.Parse(paramBizTalk.InfoDispModif.Classe),
                    IdUtilCreat =paramBizTalk.InfoDispModif.IdUtilCreat,
                    IndEnvoiCourrier=paramBizTalk.InfoDispModif.IndEnvoiCourrier,
                    IndFacturationRecente=paramBizTalk.InfoDispModif.IndFacturationRecente,
                    NoSeq=long.Parse(paramBizTalk.InfoDispModif.NoSeq),
                    NoSeqIndiv=long.Parse(paramBizTalk.InfoDispModif.NoSeqIndiv),
                    Numero=int.Parse(paramBizTalk.InfoDispModif.Numero),
                    Profession=paramBizTalk.InfoDispModif.Profession,
                    TerritoirePermis=paramBizTalk.InfoDispModif.TerritoirePermis
                },
                InfoDispOrign= new Dispensateur
                {
                    ChiffrePreuve = byte.Parse(paramBizTalk.InfoDispOrign.ChiffrePreuve),
                    Classe = byte.Parse(paramBizTalk.InfoDispOrign.Classe),
                    IdUtilCreat = paramBizTalk.InfoDispOrign.IdUtilCreat,
                    IndEnvoiCourrier = paramBizTalk.InfoDispOrign.IndEnvoiCourrier,
                    IndFacturationRecente = paramBizTalk.InfoDispOrign.IndFacturationRecente,
                    NoSeq = long.Parse(paramBizTalk.InfoDispOrign.NoSeq),
                    NoSeqIndiv = long.Parse(paramBizTalk.InfoDispOrign.NoSeqIndiv),
                    Numero = int.Parse(paramBizTalk.InfoDispOrign.Numero),
                    Profession = paramBizTalk.InfoDispOrign.Profession,
                    TerritoirePermis = paramBizTalk.InfoDispOrign.TerritoirePermis
                }
            };

            #region Modif
            if (!string.IsNullOrWhiteSpace(paramBizTalk.InfoDispModif.AnneeGraduation))
            { param.InfoDispModif.AnneeGraduation = short.Parse(paramBizTalk.InfoDispModif.AnneeGraduation); }
            if (!string.IsNullOrWhiteSpace(paramBizTalk.InfoDispModif.DateInscriptionRAMQ))
            { param.InfoDispModif.DateInscriptionRAMQ = DateTime.Parse(paramBizTalk.InfoDispModif.DateInscriptionRAMQ); }
            if (!string.IsNullOrWhiteSpace(paramBizTalk.InfoDispModif.DateObtentionPermis))
            { param.InfoDispModif.DateObtentionPermis = DateTime.Parse(paramBizTalk.InfoDispModif.DateObtentionPermis); }
            if (!string.IsNullOrWhiteSpace(paramBizTalk.InfoDispModif.Dc))
            { param.InfoDispModif.Dc = DateTime.Parse(paramBizTalk.InfoDispModif.Dc); }
            if (!string.IsNullOrWhiteSpace(paramBizTalk.InfoDispModif.DdPratique))
            { param.InfoDispModif.DdPratique = DateTime.Parse(paramBizTalk.InfoDispModif.DdPratique); }
            if (!string.IsNullOrWhiteSpace(paramBizTalk.InfoDispModif.DdSpecialite))
            { param.InfoDispModif.DdSpecialite = DateTime.Parse(paramBizTalk.InfoDispModif.DdSpecialite); }
            if (!string.IsNullOrWhiteSpace(paramBizTalk.InfoDispModif.NombreAnPratiqueHq))
            { param.InfoDispModif.NombreAnPratiqueHq = int.Parse(paramBizTalk.InfoDispModif.NombreAnPratiqueHq); }
            if (!string.IsNullOrWhiteSpace(paramBizTalk.InfoDispModif.NoSeqUniversite))
            { param.InfoDispModif.NoSeqUniversite = long.Parse(paramBizTalk.InfoDispModif.NoSeqUniversite); }
            #endregion

            #region Origin
           
            if (!string.IsNullOrWhiteSpace(paramBizTalk.InfoDispOrign.AnneeGraduation))
            { param.InfoDispOrign.AnneeGraduation = short.Parse(paramBizTalk.InfoDispOrign.AnneeGraduation); }
            if (!string.IsNullOrWhiteSpace(paramBizTalk.InfoDispOrign.DateInscriptionRAMQ))
            { param.InfoDispOrign.DateInscriptionRAMQ = DateTime.Parse(paramBizTalk.InfoDispOrign.DateInscriptionRAMQ); }
            if (!string.IsNullOrWhiteSpace(paramBizTalk.InfoDispOrign.DateObtentionPermis))
            { param.InfoDispOrign.DateObtentionPermis = DateTime.Parse(paramBizTalk.InfoDispOrign.DateObtentionPermis); }
            if (!string.IsNullOrWhiteSpace(paramBizTalk.InfoDispOrign.Dc))
            { param.InfoDispOrign.Dc = DateTime.Parse(paramBizTalk.InfoDispOrign.Dc); }
            if (!string.IsNullOrWhiteSpace(paramBizTalk.InfoDispOrign.DdPratique))
            { param.InfoDispOrign.DdPratique = DateTime.Parse(paramBizTalk.InfoDispOrign.DdPratique); }
            if (!string.IsNullOrWhiteSpace(paramBizTalk.InfoDispOrign.DdSpecialite))
            { param.InfoDispOrign.DdSpecialite = DateTime.Parse(paramBizTalk.InfoDispOrign.DdSpecialite); }
            if (!string.IsNullOrWhiteSpace(paramBizTalk.InfoDispOrign.NombreAnPratiqueHq))
            { param.InfoDispOrign.NombreAnPratiqueHq = int.Parse(paramBizTalk.InfoDispOrign.NombreAnPratiqueHq); }
            if (!string.IsNullOrWhiteSpace(paramBizTalk.InfoDispOrign.NoSeqUniversite))
            { param.InfoDispOrign.NoSeqUniversite = long.Parse(paramBizTalk.InfoDispOrign.NoSeqUniversite); }
            
            #endregion

            //-AnneeGraduation=long.Parse(paramBizTalk.InfoDispModif.AnneeGraduation)
            return AjusterEngagDdSpecInscr(param);  
        }
        #endregion


        #region Méthodes privées

        /// <summary>
        ///  Appel une méthode de la CPO et fait la gestion d'exception
        /// </summary>
        /// <typeparam name="T">Type de retour de la méthode appelée</typeparam>
        /// <param name="fctAExecuter">Fonction anonyme qui encapsule l'appel</param>
        /// <returns></returns>
        /// <remarks></remarks>       
        private T AppelerCpo<T>(Func<ITraitEveneAutreSys, T> fctAExecuter)
        {
            T objParamSorti = default(T);

            try
            {
                ClientAccesDonnesOra.Odp.OuvrirCnn();             
                ClientAccesDonnesOra.Odp.DebuterTransaction();

                objParamSorti = fctAExecuter(_traitEveneAutreSys);

                if ((objParamSorti as ClasseBase.ParamSorti).InfoMsgTrait.Count>0)
                {
                    ClientAccesDonnesOra.Odp.AnnulerTransaction();
                }
                else
                {
                    ClientAccesDonnesOra.Odp.TerminerTransaction();
                }

            }
            catch (Exception ex)
            {
                
                ClientAccesDonnesOra.Odp.AnnulerTransaction();
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw new FaultException<ExceptionRamqIntrn>(new ExceptionRamqIntrn(ex), ex.Message);
            }
            finally
            {
                ClientAccesDonnesOra.Odp.FermerCnn();
            }

            return objParamSorti;
        }


        private T AppelerCpo<T>(Func<IAjusterEngagAvisConfNonParticipation, T> fctAExecuter)
        {
            T objParamSorti = default(T);

            try
            {
                ClientAccesDonnesOra.Odp.OuvrirCnn();
                ClientAccesDonnesOra.Odp.DebuterTransaction();

                objParamSorti = fctAExecuter(_ajusterEngagAvisConfNonParticipation);

                if ((objParamSorti as ClasseBase.ParametreSorti).InfoMsgTrait.Count > 0)
                {
                    ClientAccesDonnesOra.Odp.AnnulerTransaction();
                }
                else
                {
                   ClientAccesDonnesOra.Odp.TerminerTransaction();
                }

            }
            catch (Exception ex)
            {
                ClientAccesDonnesOra.Odp.AnnulerTransaction();
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw new FaultException<ExceptionRamqIntrn>(new ExceptionRamqIntrn(ex), ex.Message);
            }
            finally
            {
                ClientAccesDonnesOra.Odp.FermerCnn();
            }


            return objParamSorti;
        }
        #endregion
    }
}
