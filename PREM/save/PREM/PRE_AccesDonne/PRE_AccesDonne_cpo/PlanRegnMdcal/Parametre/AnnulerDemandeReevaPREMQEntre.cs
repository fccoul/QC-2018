using RAMQ.Attribut;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    /// Paramètre d'entré du service du noyau AnnulerDemReevaPREM
    /// </summary>
    public class AnnulerDemandeReevaPREMQEntre
    {
        /// <summary>
        /// Numéro séquentiel de la demande à annuler.
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqDemReeva", Direction = ParameterDirection.Input)]
        public long NumeroSequentielDemReeva { get; set; }

        /// <summary>
        /// Identifiant utilisateur annulant la demande
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrUtilInact", Direction = ParameterDirection.Input)]
        public string IdentifiantUtilisateur { get; set; }
    }
}
