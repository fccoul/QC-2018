#region Importations
using RAMQ.Message;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Parametres;
using RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.EngagementPratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.PeriodePratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Pratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using RAMQ.ServiceModel.Erreur;
using System.ServiceModel;
#endregion

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_svc
{
    /// <summary> 
    /// Consultation du profil PREM des professionnels
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : 2016-09-16
    /// </remarks>
    [ServiceKnownType(typeof(MsgTrait))]
    [ServiceContract(Namespace = "http://PLC2_CnsulProfiPremqProf_svc/1", SessionMode = SessionMode.NotAllowed)]
    public interface IServCnsulProfiPremqProf
    {

        /// <summary>
        /// Permet d'obtenir les engagements de pratique du professionnel
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns>Les engagement de pratique d'un professionnel</returns>
        [OperationContract()]
        [FaultContract(typeof(ExceptionRamq))]
        ObtenirEngagementPratiqueSorti ObtenirLesEngagementsPratiquesProfessionnel(ObtenirEngagementPratiqueEntre intrant);


        /// <summary>
        /// Permet d'obtenir les périodes de pratique d'un professionnel
        /// </summary>
        /// <param name="intrant">Intrant contenant les information de recherche</param>
        /// <returns>Période de pratique d'un professionnel</returns>
        /// <remarks></remarks>
        [OperationContract()]
        [FaultContract(typeof(ExceptionRamq))]
        ObtenirPeriodePratiqueProfessionnelSorti ObtenirPeriodePratiqueProfessionnel(ObtenirPeriodePratiqueProfessionnelEntre intrant);

        /// <summary>
        /// Permet d'obtenir les dérogations d'un professionnel de la santé
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Liste de dérogations d'un professionnel de la santé</returns>
        /// <remarks></remarks>
        [OperationContract()]
        [FaultContract(typeof(ExceptionRamq))]
        ObtenirDerogationsProfessionnelSanteSorti ObtenirDerogationsProfessionnelSante(ObtenirDerogationsProfessionnelSanteEntre intrant);

        /// <summary>
        /// Permet d'obtenir les information sur l'admissibilité du professionnel à facturer
        /// </summary>
        /// <param name="intrant">Information du professionnel</param>
        /// <returns>Les information sur l'admissibilité du professionnel à facturer</returns>
        /// <remarks></remarks>
        [OperationContract()]
        [FaultContract(typeof(ExceptionRamq))]
        VerifierAdmissibiliteProfessionnelFacturerSorti VerifierAdmissibiliteProfessionnel(VerifierAdmissibiliteProfessionnelFacturerEntre intrant);

        /// <summary>
        /// Permet de modifier une dérogation d'un professionnel de la santé
        /// </summary>
        /// <param name="intrant">Information de la dérogation</param>
        /// <returns>Le nouveau numéro de séquence de la dérogation</returns>
        /// <remarks></remarks>
        [OperationContract()]
        [FaultContract(typeof(ExceptionRamq))]
        ModifierDerogationSorti ModifierDerogation(ModifierDerogationEntre intrant);

        /// <summary>
        /// Valider le professionnel
        /// </summary>
        /// <param name="informationProfessionnel">Information du professionnel</param>
        /// <returns>Liste de messages</returns>
        [OperationContract()]
        [FaultContract(typeof(ExceptionRamq))]
        ValiderProfessionnelSorti ValiderProfessionnel(ValiderProfessionnelEntre informationProfessionnel);

        /// <summary>
        /// Permet de calculer le nombre de journée de facturation
        /// </summary>
        /// <param name="intrant">Paramètres d'entré</param>
        /// <returns>Journées facturés</returns>
        [OperationContract()]
        [FaultContract(typeof(ExceptionRamq))]
        CalculerNbrJrFactProfsSorti CalculerNombreJourneeFacturation(CalculerNbrJrFactProfsEntre intrant);

        /// <summary>
        /// Permet d'obtenir les réduction à la rémunération
        /// </summary>
        /// <param name="intrant">Paramètres d'entré</param>
        /// <returns>Journées facturés</returns>
        [OperationContract()]
        [FaultContract(typeof(ExceptionRamq))]
        ReductionRemunerationSorti ObtenirReductionRemuneration(ReductionRemunerationEntre intrant);

        /// <summary>
        /// Permet d'obtenir le pourcentage maximum
        /// </summary>
        /// <returns>Pourcentage maximum</returns>
        [OperationContract()]
        [FaultContract(typeof(ExceptionRamq))]
        ObtenirPourcentageMaximumSorti ObtenirPourcentageMaximum();


        /// <summary>
        /// Permet d'obtenir les informations sur la relation dispensateur individu
        /// </summary>
        /// <param name="intrant">Paramètres d'entrées</param>
        /// <returns>Les informations la relation dispensateur individu</returns>
        /// <remarks></remarks>
        [OperationContract]
        [FaultContract(typeof(ExceptionRamq))]
        ObtenirDispensateurIndividuSorti ObtenirInformationProfessionnel(ObtenirDispensateurIndividuEntre intrant);

        /// <summary>
        /// Permet l'obtention des périodes d'engagement et absences du professionnel de la santé
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns>Liste des engagements et absences d'avis></returns>
        [OperationContract]
        [FaultContract(typeof(ExceptionRamq))]
        ObtenirVuePeriodeEngagementSorti ObtenirPeriodeEngagementsAbsenceProfessionnel(ObtenirVuePeriodeEngagementEntre intrant);
    }
}


