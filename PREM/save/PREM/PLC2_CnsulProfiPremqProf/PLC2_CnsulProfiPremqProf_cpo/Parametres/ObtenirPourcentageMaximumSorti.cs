using RAMQ.ClasseBase;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Parametres
{
    /// <summary>
    /// Paramètre d'entré pour l'obtention du pourcentage maximum
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public class ObtenirPourcentageMaximumSorti : ParamSorti
    {
        /// <summary>
        /// Pourcentage maximum
        /// </summary>
        public decimal PourcentageMaximum { get; set; }
    }
}