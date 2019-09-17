using RAMQ.PRE.PRE_Entites_cpo.PeriodePratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.ObtentionInformation
{
    /// <summary> 
    ///  Interface d'obtention des informations des professionnels à partir des systèmes externes
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Octobre 2016
    /// </remarks>
    public interface IObtenirInformationProfessionnelSystemeExterne
    {
        /// <summary>
        /// Permet d'obtenir la période de pratique d'un professionnel
        /// </summary>
        /// <param name="intrant">Paramètres d'entrées</param>
        /// <returns>Les informations de la période de pratique d'un professionnel</returns>
        /// <remarks></remarks>
        ObtenirPeriodePratiqueProfessionnelSorti ObtenirPeriodePratiqueProfessionnel(ObtenirPeriodePratiqueProfessionnelEntre intrant);

    }

}
