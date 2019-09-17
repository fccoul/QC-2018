using RAMQ.PRE.PRE_Entites_cpo.PeriodePratique.Parametre;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Professionnel.Interface
{
    /// <summary> 
    ///  Interface des période de pratique
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Décembre 2016
    /// </remarks>
    public interface IPeriodePratique
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

