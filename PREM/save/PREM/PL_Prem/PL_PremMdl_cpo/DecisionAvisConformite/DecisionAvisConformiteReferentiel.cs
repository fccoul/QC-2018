using RAMQ.PRE.PRE_Entites_cpo.DecisionAvisConformite.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre;
using RAMQ.PRE.PRE_OutilComun_cpo;

namespace RAMQ.PRE.PL_PremMdl_cpo.DecisionAvisConformite
{
    /// <summary> 
    ///  Référentiel qui permet d'obtenir les informations des décisions d'avis de conformité.
    /// </summary>
    /// <remarks>
    ///  Auteur : Sébastien Bourdages <br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    public class DecisionAvisConformiteReferentiel : IDecisionAvisConformite
    {
        /// <summary>
        /// Traiter la création d'une dérogation d'avis de conformité.
        /// </summary>
        /// <param name="intrant">Paramètre d'entré.</param>
        /// <returns>Paramètre de sortie.</returns>
        /// <remarks></remarks>
        public TraiterDerogationAvisConformiteSorti TraiterDerogationAvisConformite(TraiterDerogationAvisConformiteEntre intrant)
        {
            return UtilitaireService.AppelerService<svcSaisDecisAvisConf.IServSaisDecisAvisConf,
                                                    svcSaisDecisAvisConf.ServSaisDecisAvisConfClient,
                                                    TraiterDerogationAvisConformiteSorti>(x => x.TraiterDerogationAvisConformite(intrant));
        }

        /// <summary>
        /// Permet de faire la gestion des suspension (Ajouter, Modifier, Annuler)
        /// </summary>
        /// <param name="intrant">Paramètre d'entré.</param>
        /// <returns>Paramètre de sortie.</returns>
        public TraiterSuspensionAvisConformiteSorti TraiterSuspensionAvisConformite(TraiterSuspensionAvisConformiteEntre intrant)
        {
            return UtilitaireService.AppelerService<svcSaisDecisAvisConf.IServSaisDecisAvisConf,
                                                    svcSaisDecisAvisConf.ServSaisDecisAvisConfClient,
                                                    TraiterSuspensionAvisConformiteSorti>(x => x.TraiterSuspensionAvisConformite(intrant));
        }
        
        /// <summary>
        /// Permet de faire l'annulation des dérogations
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Paramètre de sortie</returns>
        public TraiterAnnulationDerogationSorti TraiterAnnulationDerogation(TraiterAnnulationDerogationEntre intrant)
        {
            return UtilitaireService.AppelerService<svcSaisDecisAvisConf.IServSaisDecisAvisConf,
                                                    svcSaisDecisAvisConf.ServSaisDecisAvisConfClient,
                                                    TraiterAnnulationDerogationSorti>(x => x.TraiterAnnulationDerogation(intrant));
        }

    }
}