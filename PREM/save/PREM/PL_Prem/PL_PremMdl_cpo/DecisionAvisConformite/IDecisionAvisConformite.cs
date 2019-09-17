using RAMQ.PRE.PRE_Entites_cpo.DecisionAvisConformite.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre;

namespace RAMQ.PRE.PL_PremMdl_cpo.DecisionAvisConformite
{
    /// <summary> 
    ///  Interface permettant d'obtenir les informations des décision d'avis de conformité.
    /// </summary>
    /// <remarks>
    ///  Auteur : Sébastien Bourdages <br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    public interface IDecisionAvisConformite
    {
        /// <summary>
        /// Traiter la création d'une dérogation d'avis de conformité.
        /// </summary>
        /// <param name="intrant">Paramètre d'entré.</param>
        /// <returns>Paramètre de sortie.</returns>
        /// <remarks></remarks>
        TraiterDerogationAvisConformiteSorti TraiterDerogationAvisConformite(TraiterDerogationAvisConformiteEntre intrant);

        /// <summary>
        /// Permet de faire la gestion des suspension (Ajouter, Modifier, Annuler)
        /// </summary>
        /// <param name="intrant">Paramètre d'entré.</param>
        /// <returns>Paramètre de sortie.</returns>
        TraiterSuspensionAvisConformiteSorti TraiterSuspensionAvisConformite(TraiterSuspensionAvisConformiteEntre intrant);

        /// <summary>
        /// Permet de faire l'annulation des dérogations
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Paramètre de sortie</returns>
        TraiterAnnulationDerogationSorti TraiterAnnulationDerogation(TraiterAnnulationDerogationEntre intrant);
    }
}