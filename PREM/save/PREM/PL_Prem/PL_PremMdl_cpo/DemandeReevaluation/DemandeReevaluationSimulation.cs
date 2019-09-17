using RAMQ.PRE.PRE_Entites_cpo.DemandeReevaluation.Parametre;
using System;
using RAMQ.PRE.PL_PremMdl_cpo.svcCreerDemReeva;

namespace RAMQ.PRE.PL_PremMdl_cpo.DemandeReevaluation
{
    /// <summary> 
    ///  Référentiel bidon qui permet d'obtenir des demande de réévaluation fictives 
    ///  codés en dur.
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Mars 2018
    /// </remarks>
    public class DemandeReevaluationSimulation : IDemandeReevaluation
    {
        /// <summary>
        /// Annuler une demande de réévaluation
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        public AnnulerDemandeReevaluationSorti AnnulerDemandeReevaluation(AnnulerDemandeReevaluationEntre intrant)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saisir une demande de réévaluation
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        public SaisirDemandeReevaluationSorti SaisirDemandeReevaluation(SaisirDemandeReevaluationEntre intrant)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtenir des demandes de réévaluation
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        public ObtenirDemandeReevaluationSorti ObtenirDemandeReevaluation(ObtenirDemandeReevaluationEntre intrant)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        public ValiderProfessionnelSorti ValiderProfessionnel(ValiderProfessionnelEntre intrant)
        {
            throw new NotImplementedException();
        }
    }
}