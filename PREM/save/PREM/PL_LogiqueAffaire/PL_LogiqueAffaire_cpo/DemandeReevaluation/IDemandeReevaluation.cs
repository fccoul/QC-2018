using RAMQ.PRE.PRE_Entites_cpo.DemandeReevaluation.Parametre;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.DemandeReevaluation
{
    /// <summary> 
    ///  Interface de la classe des demandes de réévaluation
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Mars 2018
    /// </remarks>
    public interface IDemandeReevaluation
    {

        /// <summary>
        /// Permet d'annuler une demande de réévaluation
        /// </summary>
        /// <Parametre name="intrant">Paramètre d'entré</Parametre>
        /// <returns></returns>
        AnnulerDemandeReevaluationSorti AnnulerDemandeReevaluation(AnnulerDemandeReevaluationEntre intrant);

        /// <summary>
        /// Permet de creer une demande de réévaluation
        /// </summary>
        /// <Parametre name="intrant">Paramètre d'entré</Parametre>
        /// <returns></returns>
        CreerDemandeReevaluationSorti CreerDemandeReevaluation(CreerDemandeReevaluationEntre intrant);

        /// <summary>
        /// Permet de modifier une demande de réévaluation
        /// </summary>
        /// <Parametre name="intrant">Paramètre d'entré</Parametre>
        /// <returns></returns>
        /// <remarks></remarks>
        ModifierDemandeReevaluationSorti ModifierDemandeReevaluation(ModifierDemandeReevaluationEntre intrant);

        /// <summary>
        /// Permet d'obtenir une liste des demandes de réévaluation
        /// </summary>
        /// <Parametre name="intrant">Paramètre d'entré</Parametre>
        /// <returns>Une liste des avis de conformité avec leurs statuts</returns>
        /// <remarks></remarks>
        ObtenirDemandeReevaluationSorti ObtenirDemandeReevaluation(ObtenirDemandeReevaluationEntre intrant);
    }
}