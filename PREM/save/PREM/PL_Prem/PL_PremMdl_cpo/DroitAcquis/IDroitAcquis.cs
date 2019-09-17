
using RAMQ.PRE.PRE_Entites_cpo.DroitAcquis.Parametre;

namespace RAMQ.PRE.PL_PremMdl_cpo.DroitAcquis
{
    /// <summary> 
    /// Interface permettant d'obtenir les informations des droits acquis d'un professionnel
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : 2016-10-04
    /// </remarks>
    public interface IDroitAcquis
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        ObtenirDroitsAquisProfessionnelsSorti ObtenirDroitsAcquisProfs(ObtenirDroitsAquisProfessionnelsEntre intrant);

    }
}