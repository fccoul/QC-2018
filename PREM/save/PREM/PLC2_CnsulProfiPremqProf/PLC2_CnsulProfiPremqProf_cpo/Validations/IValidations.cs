using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Parametres;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Validations
{

    /// <summary> 
    ///  Classe de validations
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Avril 2017
    /// </remarks>
    public interface IValidations
    {

        /// <summary>
        /// Valider le professionnel
        /// </summary>
        /// <param name="informationProfessionnel">Information du professionnel</param>
        /// <returns>Liste de messages</returns>
        ValiderProfessionnelSorti ValiderProfessionnel(ValiderProfessionnelEntre informationProfessionnel);
    }
}