using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Parametres;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Professionnel.Interface
{
    /// <summary>
    /// Interface de la réduction à la rémunération
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public interface IReductionRemuneration
    {
        /// <summary>
        /// Obtenir la réduction à la rémunération
        /// </summary>
        /// <param name="intrant">Paramètre d'entrer</param>
        /// <returns>Réductions à la rémunération</returns>
        ReductionRemunerationSorti ObtenirReductionRemuneration(ReductionRemunerationEntre intrant);


    }
}