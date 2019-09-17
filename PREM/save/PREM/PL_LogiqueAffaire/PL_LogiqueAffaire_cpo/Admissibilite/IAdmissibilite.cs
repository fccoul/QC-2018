using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.Admissibilite
{
    /// <summary> 
    ///  Interface des admissibilités
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    public interface IAdmissibilite
    {
        /// <summary>
        /// Permet d'obtenir les information sur l'admissibilité du professionnel à facturer
        /// </summary>
        /// <param name="intrant">Information du professionnel</param>
        /// <returns>Les information sur l'admissibilité du professionnel à facturer</returns>
        /// <remarks></remarks>
        VerifierAdmissibiliteProfessionnelFacturerSorti VerifierAdmissibiliteProfessionnel(VerifierAdmissibiliteProfessionnelFacturerEntre intrant);
    }
}
