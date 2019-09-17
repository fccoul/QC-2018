using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Parametres;
using RAMQ.PRE.PRE_Entites_cpo.Pratique.Parametre;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Professionnel.Interface
{
    /// <summary>
    /// Interface pour faire l'obtention du calcule du nombre de journée de facturation
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public interface IJourneeFacturation
    {

        /// <summary>
        /// Permet de faire l'appel au calcule du nombre de journée de facturation
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Le calcule des journées facturé</returns>
        CalculerNbrJrFactProfsSorti CalculerNombreJourneeFacturation(CalculerNbrJrFactProfsEntre intrant);


        /// <summary>
        /// Permet d'obtenir le pourcentage maximum
        /// </summary>
        /// <returns>Pourcentage maximum</returns>
        ObtenirPourcentageMaximumSorti ObtenirPourcentageMaximum();
    }
}