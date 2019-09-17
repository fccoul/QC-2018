using RAMQ.Attribut;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    /// Paramètre d'entré pour l'obtention des réductions à la rémunération
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
	public class ObtenirReductionsRemunerationEntre
    {

        /// <summary>
        /// Numéro de séquence du dispensateur
        /// </summary>
        [ValeurEntite(ElementName = "pNumNoSeqDisp", Direction = ParameterDirection.Input)]
        public long NumeroSequenceDispensateur { get; set; }

        /// <summary>
        /// Si est RPPR uniquement
        /// </summary>
        [ValeurEntite(ElementName = "pVchrRpprUniquement", Direction = ParameterDirection.Input)]
        public string EstRPPRUniquement { get; set; }

        /// <summary>
        /// Tri
        /// </summary>
        [ValeurEntite(ElementName = "pVchrTri", Direction = ParameterDirection.Input)]
        public string Tri { get; set; }
    }
}