using RAMQ.Message;
using RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.AjusterEngagement.Param;
using RAMQ.ServiceModel.Erreur;
using System.ServiceModel;

namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_svc
{
    /// <summary>
    /// 
    /// </summary>

    [ServiceKnownType(typeof(MsgTrait))]

    [ServiceContract(Namespace = "http://www.ramq.gouv.qc.ca/PRE/NomSignificatif",
                     SessionMode = SessionMode.NotAllowed)]  
    public interface IServTraitEveneAutreSys
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="objParamEntree"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [OperationContract()]
        [FaultContract(typeof(ExceptionRamqIntrn))]
        ParamSortiAjusterAvisConformiteMedResidents AjusterAvisConformiteMedResidents(ParamEntreAjusterAvisConformiteMedResidents objParamEntree);

        /// <summary>
        ///
        /// </summary>
        /// <param name="objParamEntree"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        [OperationContract()]
        [FaultContract(typeof(ExceptionRamqIntrn))]
        ParamSortiTraiterAdmissProf TraiterAdmissibiliteDuProfessionnel(ParamEntreTraiterAdmissProf objParamEntree);

        /// <summary>
        ///  Ajuster les engagements PREM du médecin omnipraticien pour lequel une période
        ///  de non-participation est inscrite.
        /// </summary>
        [OperationContract()]
        [FaultContract(typeof(ExceptionRamqIntrn))]
        AjusEngagAjouNonPartnSorti AjusterEngagAjouNonPartn(AjusEngagAjouNonPartnEntre param);

        /// <summary>
        ///  Ajuster les engagements PREM du médecin omnipraticien pour lequel une période
        ///  de non-participation est modifiée.
        /// </summary>
        [OperationContract()]
        [FaultContract(typeof(ExceptionRamqIntrn))]
        AjusEngagModifNonPartnSorti AjusterEngagModifNonPartn(AjusEngagModifNonPartnEntre param);

        /// <summary>
        ///  Ajuster les engagements PREM du médecin omnipraticien pour lequel une période
        ///  de non-participation est annulée.
        /// </summary>
        [OperationContract()]
        [FaultContract(typeof(ExceptionRamqIntrn))]
        AjusEngagAnnuNonPartnSorti AjusterEngagAnnuNonPartn(AjusEngagAnnuNonPartnEntre param);

        /// <summary>
        ///  Ajuster les engagements PREM du médecin omnipraticien pour lequel un déces a 
        ///  été inscrit.
        /// </summary>
        [OperationContract()]
        [FaultContract(typeof(ExceptionRamqIntrn))]
        AjusEngagDecesSorti AjusterEngagDeces(AjusEngagDecesEntre param);

        /// <summary>
        ///  Ajuster les engagements PREM du médecin omnipraticien pour lequel une date de
        ///  début de spécialité a été inscrite.
        /// </summary>
        [OperationContract()]
        [FaultContract(typeof(ExceptionRamqIntrn))]
        AjusEngagDdSpecInscrSorti AjusterEngagDdSpecInscr(AjusEngagDdSpecInscrEntre param);

        #region Appel Biztalk
        /// <summary>
        ///  Ajuster les engagements PREM du médecin omnipraticien pour lequel une période
        ///  de non-participation est inscrite.
        /// </summary>
        [OperationContract()]
        [FaultContract(typeof(ExceptionRamqIntrn))]
        AjusEngagAjouNonPartnSorti AjusterEngagAjouNonPartnBiztalk(AjusEngagAjouNonPartnEntreBizTalk param);


        /// <summary>
        ///  Ajuster les engagements PREM du médecin omnipraticien pour lequel une période
        ///  de non-participation est modifiée.
        /// </summary>
        [OperationContract()]
        [FaultContract(typeof(ExceptionRamqIntrn))]
        AjusEngagModifNonPartnSorti AjusterEngagModifNonPartnBiztalk(AjusEngagModifNonPartnEntreBiztalk param);

        /// <summary>
        ///  Ajuster les engagements PREM du médecin omnipraticien pour lequel une période
        ///  de non-participation est annulée.
        /// </summary>
        [OperationContract()]
        [FaultContract(typeof(ExceptionRamqIntrn))]
        AjusEngagAnnuNonPartnSorti AjusterEngagAnnuNonPartnBiztalk(AjusEngagAnnuNonPartnEntreBizTalk param);

        /// <summary>
        ///  Ajuster les engagements PREM du médecin omnipraticien pour lequel un déces a 
        ///  été inscrit.
        /// </summary>
        [OperationContract()]
        [FaultContract(typeof(ExceptionRamqIntrn))]
        AjusEngagDecesSorti AjusterEngagDecesBizTalk(AjusEngagDecesEntreBizTalk param);

        /// <summary>
        ///  Ajuster les engagements PREM du médecin omnipraticien pour lequel une date de
        ///  début de spécialité a été inscrite.
        /// </summary>
        [OperationContract()]
        [FaultContract(typeof(ExceptionRamqIntrn))]
        AjusEngagDdSpecInscrSorti AjusterEngagDdSpecInscrBizTalk(AjusEngagDdSpecInscrEntreBizTalk param);
        #endregion

    }
}
