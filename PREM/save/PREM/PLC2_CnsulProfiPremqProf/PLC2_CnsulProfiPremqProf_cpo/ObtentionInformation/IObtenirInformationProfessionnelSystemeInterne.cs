using RAMQ.PRE.PRE_Entites_cpo.Autorisation.Parametre;


namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.ObtentionInformation
{
    /// <summary> 
    ///  Interface d'obtention des informations des professionnels
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Octobre 2016
    /// </remarks>
    public interface IObtenirInformationProfessionnelSystemeInterne
    {

        /// <summary>
        /// Permet de modifier une dérogation d'un professionnels de la santé
        /// </summary>
        /// <Parametre name="intrant">Paramètres d'entré</Parametre>
        /// <returns>Le nouveau numéro séquentiel de la dérogation</returns>
        /// <remarks></remarks>
        ObtenirLesAutorisationsProfessionnelSorti ObtenirAutorisationProfessionnelSante(ObtenirLesAutorisationsProfessionnelEntre intrant);

    }
}