using RAMQ.PRE.PL_PremMdl_cpo.svcCreerDemReeva;
using RAMQ.PRE.PRE_Entites_cpo.DemandeReevaluation.Parametre;

namespace RAMQ.PRE.PL_PremMdl_cpo.DemandeReevaluation
{
    /// <summary> 
    ///  Interface permettant d'accéder aux demandes de réévaluation
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Mars 2018
    /// </remarks>
    public interface IDemandeReevaluation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        AnnulerDemandeReevaluationSorti AnnulerDemandeReevaluation(AnnulerDemandeReevaluationEntre intrant);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        SaisirDemandeReevaluationSorti SaisirDemandeReevaluation(SaisirDemandeReevaluationEntre intrant);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        ObtenirDemandeReevaluationSorti ObtenirDemandeReevaluation(ObtenirDemandeReevaluationEntre intrant);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        ValiderProfessionnelSorti ValiderProfessionnel(ValiderProfessionnelEntre intrant);



    }
}