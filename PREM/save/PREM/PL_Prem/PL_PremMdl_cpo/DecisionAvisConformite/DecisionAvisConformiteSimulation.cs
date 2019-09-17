using RAMQ.PRE.PRE_Entites_cpo.DecisionAvisConformite.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre;
using System;

namespace RAMQ.PRE.PL_PremMdl_cpo.DecisionAvisConformite
{
    /// <summary> 
    ///  Référentiel bidon qui permet d'obtenir les informations des décisions d'avis de conformité fictifs 
    ///  codés en dur.
    /// </summary>
    /// <remarks>
    ///  Auteur : Sébastien Bourdages <br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    public class DecisionAvisConformiteSimulation : IDecisionAvisConformite
    {
        /// <summary>
        /// Traiter la création d'une dérogation d'avis de conformité.
        /// </summary>
        /// <param name="intrant">Paramètre d'entré.</param>
        /// <returns>Paramètre de sortie.</returns>
        /// <remarks></remarks>
        public TraiterDerogationAvisConformiteSorti TraiterDerogationAvisConformite(TraiterDerogationAvisConformiteEntre intrant)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permet de faire la gestion des suspension (Ajouter, Modifier, Annuler)
        /// </summary>
        /// <param name="intrant">Paramètre d'entré.</param>
        /// <returns>Paramètre de sortie.</returns>
        public TraiterSuspensionAvisConformiteSorti TraiterSuspensionAvisConformite(TraiterSuspensionAvisConformiteEntre intrant)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permet de faire l'annulation des dérogations
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Paramètre de sortie</returns>
        public TraiterAnnulationDerogationSorti TraiterAnnulationDerogation(TraiterAnnulationDerogationEntre intrant)
        {
            throw new NotImplementedException();
        }
    }
}