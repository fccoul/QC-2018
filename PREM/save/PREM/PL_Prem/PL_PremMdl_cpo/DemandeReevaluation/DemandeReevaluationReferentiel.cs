using RAMQ.PRE.PRE_Entites_cpo.DemandeReevaluation.Parametre;
using RAMQ.PRE.PRE_OutilComun_cpo;
using RAMQ.PRE.PL_PremMdl_cpo.svcCreerDemReeva;

namespace RAMQ.PRE.PL_PremMdl_cpo.DemandeReevaluation
{
    /// <summary> 
    ///  Référentiel qui permet d'obtenir les informations des avis de conformité.
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Mars 2018
    /// </remarks>
    public class DemandeReevaluationReferentiel : IDemandeReevaluation
    {
        /// <summary>
        /// Annuler une demande de réévaluation
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        public AnnulerDemandeReevaluationSorti AnnulerDemandeReevaluation(AnnulerDemandeReevaluationEntre intrant)
        {

            return UtilitaireService.AppelerService<svcCreerDemReeva.IServCreerDemReeva,
                                                    svcCreerDemReeva.ServCreerDemReevaClient,
                                                    AnnulerDemandeReevaluationSorti>
                                                    (x => x.AnnulerDemandeReevaluation(intrant)); 

        }

        /// <summary>
        /// Saisir une demande de réévaluation
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        public SaisirDemandeReevaluationSorti SaisirDemandeReevaluation(SaisirDemandeReevaluationEntre intrant)
        {
            return UtilitaireService.AppelerService<svcCreerDemReeva.IServCreerDemReeva,
                                                    svcCreerDemReeva.ServCreerDemReevaClient,
                                                    SaisirDemandeReevaluationSorti>
                                                    (x => x.SaisirDemandeReevaluation(intrant));
        }

        /// <summary>
        /// Obtenir une demande de réévaluation
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        public ObtenirDemandeReevaluationSorti ObtenirDemandeReevaluation(ObtenirDemandeReevaluationEntre intrant)
        {
            return UtilitaireService.AppelerService<svcCreerDemReeva.IServCreerDemReeva,
                                                    svcCreerDemReeva.ServCreerDemReevaClient,
                                                    ObtenirDemandeReevaluationSorti>
                                                    (x => x.ObtenirDemandeReevaluation(intrant));
        }

        /// <summary>
        /// Obtenir une demande de réévaluation
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        public ValiderProfessionnelSorti ValiderProfessionnel(ValiderProfessionnelEntre intrant)
        {
            return UtilitaireService.AppelerService<svcCreerDemReeva.IServCreerDemReeva,
                                                    svcCreerDemReeva.ServCreerDemReevaClient, 
                                                    ValiderProfessionnelSorti>
                                                    (x => x.ValiderProfessionnel(intrant));
        }

    }
}