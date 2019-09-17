#region Importation
using RAMQ.AccesDonnees.BDOracle;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Admissibilite;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Derogation;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Professionnel;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Parametres;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Professionnel.Interface;
using RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.EngagementPratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.PeriodePratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Pratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using RAMQ.ServiceModel.Erreur;
using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using OutilCommun = RAMQ.PRE.PRE_OutilComun_cpo;
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
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.PerCall, Namespace = "http://PLC2_CnsulProfiPremqProf_svc/1")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class ServCnsulProfiPremqProf : IServCnsulProfiPremqProf
    {

        #region Attribut
        private readonly ICnsulProfiPremqProf _consultationProfilProfessionnel;
        private readonly IDerogation _derogation;
        private readonly IAdmissibilite _admissibilite;
        private readonly IRechercherProfessionnel _professionnel;
        private readonly IEngagementAbence _engagementAbence;
        private IAccesDonnesOra ClientAccesDonnesOra
        {
            get
            {
                return _accesDonnesOra();
            }
        }

        private readonly Func<IAccesDonnesOra> _accesDonnesOra;

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        public ServCnsulProfiPremqProf(ICnsulProfiPremqProf consultationProfilProfessionnel,
                                       IDerogation derogation,
                                       IAdmissibilite admissibilite,
                                       IRechercherProfessionnel professionnel,
                                       IEngagementAbence engagementAbsence,
                                       Func<IAccesDonnesOra> accesDonnesOra)
        {

            if (consultationProfilProfessionnel == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(consultationProfilProfessionnel)} ne peut être null.");
            }

            if (derogation == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(derogation)} ne peut être null.");
            }

            if (admissibilite == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(admissibilite)} ne peut être null.");
            }
            if (professionnel == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(professionnel)} ne peut être null.");
            }
            if (engagementAbsence == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(engagementAbsence)} ne peut être null.");
            }
            if (accesDonnesOra == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(accesDonnesOra)} ne peut être null.");
            }

            _consultationProfilProfessionnel = consultationProfilProfessionnel;
            _derogation = derogation;
            _admissibilite = admissibilite;
            _professionnel = professionnel;
            _engagementAbence = engagementAbsence;
            _accesDonnesOra = accesDonnesOra;

        }

        #endregion

        #region Méthodes publique

        /// <summary>
        /// Permet de modifier une dérogation d'un professionnel de la santé
        /// </summary>
        /// <param name="intrant">Information de la dérogation</param>
        /// <returns>Le nouveau numéro de séquence de la dérogation</returns>
        /// <remarks></remarks>
        public ModifierDerogationSorti ModifierDerogation(ModifierDerogationEntre intrant)
        {
            return AppelerCpo<ModifierDerogationSorti>(x => x.ModifierDerogation(intrant));
        }

        /// <summary>
        /// Permet d'obtenir les dérogations d'un professionnel de la santé
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Liste de dérogations d'un professionnel de la santé</returns>
        /// <remarks></remarks>
        public ObtenirDerogationsProfessionnelSanteSorti ObtenirDerogationsProfessionnelSante(ObtenirDerogationsProfessionnelSanteEntre intrant)
        {
            return AppelerCpo<ObtenirDerogationsProfessionnelSanteSorti>(x => x.ObtenirDerogationProfessionnel(intrant));
        }

        /// <summary>
        /// Permet d'obtenir les engagements de pratique du professionnel
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns>Les engagement de pratique d'un professionnel</returns>
        public ObtenirEngagementPratiqueSorti ObtenirLesEngagementsPratiquesProfessionnel(ObtenirEngagementPratiqueEntre intrant)
        {
            return AppelerCpo<ObtenirEngagementPratiqueSorti>(x => x.ObtenirLesEngagementsPratiquesProfessionnel(intrant));
        }

        /// <summary>
        /// Permet d'obtenir les périodes de pratique d'un professionnel
        /// </summary>
        /// <param name="intrant">Intrant contenant les information de recherche</param>
        /// <returns>Période de pratique d'un professionnel</returns>
        /// <remarks></remarks>
        public ObtenirPeriodePratiqueProfessionnelSorti ObtenirPeriodePratiqueProfessionnel(ObtenirPeriodePratiqueProfessionnelEntre intrant)
        {
            return AppelerCpo<ObtenirPeriodePratiqueProfessionnelSorti>(x => x.ObtenirPeriodePratiqueProfessionnel(intrant));
        }

        /// <summary>
        /// Permet d'obtenir les information sur l'admissibilité du professionnel à facturer
        /// </summary>
        /// <param name="intrant">Information du professionnel</param>
        /// <returns>Les information sur l'admissibilité du professionnel à facturer</returns>
        /// <remarks></remarks>
        public VerifierAdmissibiliteProfessionnelFacturerSorti VerifierAdmissibiliteProfessionnel(VerifierAdmissibiliteProfessionnelFacturerEntre intrant)
        {
            return AppelerCpo<VerifierAdmissibiliteProfessionnelFacturerSorti>(x => x.VerifierAdmissibiliteProfessionnel(intrant));
        }

        /// <summary>
        /// Valider le professionnel
        /// </summary>
        /// <param name="informationProfessionnel">Information du professionnel</param>
        /// <returns>Liste de messages</returns>
        public ValiderProfessionnelSorti ValiderProfessionnel(ValiderProfessionnelEntre informationProfessionnel)
        {
            return AppelerCpo<ValiderProfessionnelSorti>(x => x.ValiderProfessionnel(informationProfessionnel));
        }

        /// <summary>
        /// Permet de calculer le nombre de journée de facturation
        /// </summary>
        /// <param name="intrant">Paramètres d'entré</param>
        /// <returns>Journées facturés</returns>
        public CalculerNbrJrFactProfsSorti CalculerNombreJourneeFacturation(CalculerNbrJrFactProfsEntre intrant)
        {
            return AppelerCpo<CalculerNbrJrFactProfsSorti>(x => x.CalculerNombreJourneeFacturation(intrant));
        }

        /// <summary>
        /// Permet d'obtenir les réduction à la rémunération
        /// </summary>
        /// <param name="intrant">Paramètres d'entré</param>
        /// <returns>Journées facturés</returns>
        public ReductionRemunerationSorti ObtenirReductionRemuneration(ReductionRemunerationEntre intrant)
        {
            return AppelerCpo<ReductionRemunerationSorti>(x => x.ObtenirReductionRemuneration(intrant));
        }

        /// <summary>
        /// Permet d'obtenir le pourcentage maximum
        /// </summary>
        /// <returns>Pourcentage maximum</returns>
        public ObtenirPourcentageMaximumSorti ObtenirPourcentageMaximum()
        {
            return AppelerCpo<ObtenirPourcentageMaximumSorti>(x => x.ObtenirPourcentageMaximum());
        }



        /// <summary>
        /// Permet d'obtenir les informations sur la relation dispensateur individu
        /// </summary>
        /// <param name="intrant">Paramètres d'entrées</param>
        /// <returns>Les informations la relation dispensateur individu</returns>
        /// <remarks></remarks>
        public ObtenirDispensateurIndividuSorti ObtenirInformationProfessionnel(ObtenirDispensateurIndividuEntre intrant)
        {
            return AppelerCpo<ObtenirDispensateurIndividuSorti>(x => x.ObtenirInformationProfessionnel(intrant));
            
        }

        /// <summary> 
        /// Permet l'obtention des périodes d'engagement et absences du professionnel de la santé
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns>Liste des engagements et absences d'avis></returns>
        public ObtenirVuePeriodeEngagementSorti ObtenirPeriodeEngagementsAbsenceProfessionnel(ObtenirVuePeriodeEngagementEntre intrant)
        {
            return AppelerCpo<ObtenirVuePeriodeEngagementSorti>(x => x.ObtenirPeriodeEngagementsAbsenceProfessionnel(intrant));
          
        }

        #endregion

        #region Méthodes privées

        private T AppelerCpo<T>(Func<ICnsulProfiPremqProf, T> fonction)
        {
            T parametreSortie = default(T);

            try
            {
                ClientAccesDonnesOra.Odp.OuvrirCnn();

                parametreSortie = fonction(_consultationProfilProfessionnel);
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw new FaultException<ExceptionRamqIntrn>(new ExceptionRamqIntrn(ex), ex.Message);
            }
            finally
            {
                ClientAccesDonnesOra.Odp.FermerCnn();
            }

            return parametreSortie;

        }


        private T AppelerCpo<T>(Func<IDerogation, T> fonction)
        {
            T parametreSortie = default(T);

            try
            {
                ClientAccesDonnesOra.Odp.OuvrirCnn();
                ClientAccesDonnesOra.Odp.DebuterTransaction();

                parametreSortie = fonction(_derogation);

                if ((parametreSortie as ClasseBase.ParamSorti).InfoMsgTrait.Any())
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

            return parametreSortie;

        }

        private T AppelerCpo<T>(Func<IAdmissibilite, T> fonction)
        {
            T parametreSortie = default(T);

            try
            {
                ClientAccesDonnesOra.Odp.OuvrirCnn();

                parametreSortie = fonction(_admissibilite);
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw new FaultException<ExceptionRamqIntrn>(new ExceptionRamqIntrn(ex), ex.Message);
            }
            finally
            {
                ClientAccesDonnesOra.Odp.FermerCnn();
            }

            return parametreSortie;

        }

        
        private T AppelerCpo<T>(Func<IRechercherProfessionnel, T> fonction)
        {
            T parametreSortie = default(T);

            try
            {
                ClientAccesDonnesOra.Odp.OuvrirCnn();

                parametreSortie = fonction(_professionnel);
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw new FaultException<ExceptionRamqIntrn>(new ExceptionRamqIntrn(ex), ex.Message);
            }
            finally
            {
                ClientAccesDonnesOra.Odp.FermerCnn();
            }

            return parametreSortie;

        }

        private T AppelerCpo<T>(Func<IEngagementAbence, T> fonction)
        {
            T parametreSortie = default(T);

            try
            {
                ClientAccesDonnesOra.Odp.OuvrirCnn();

                parametreSortie = fonction(_engagementAbence);
            }
            catch (Exception ex)
            {
                OutilCommun.Journalisation.JournaliserErreurTechnique(ex);
                throw new FaultException<ExceptionRamqIntrn>(new ExceptionRamqIntrn(ex), ex.Message);
            }
            finally
            {
                ClientAccesDonnesOra.Odp.FermerCnn();
            }

            return parametreSortie;

        }

        #endregion

    }
}

