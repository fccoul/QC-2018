#region Imports
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3.Parametre;
#endregion

namespace RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3
{

    /// <summary> 
    /// Interface d'encapsulation des appels à "EPZ3_InfoDispCnsul"
    /// </summary>
    public interface IInfoDispCnsul
    {

        /// <summary>
        /// Obtenir les informations sur la relation dispensateur individu
        /// </summary>
        /// <param name="intrant">Paramètres d'entrées</param>
        /// <returns>Un objet contenant la liste des informations sur la relation dispensateur/individu</returns>
        /// <remarks>
        /// À cause de la limitation de l'index des tableaux de sortie dans COC2_V4 lorsqu'on passe une classe de paramètres,
        /// les tableaux sont déclarés manuellement et on utilise l'ancienne façon d'appeler Oracle.
        /// </remarks>
        ObtnRelDispIndivSorti ObtenirRelDispIndiv(ObtnRelDispIndivEntre intrant);

        /// <summary>
        /// Permet d'obtenir les périodes de pratique d'un professionnel
        /// </summary>
        /// <param name="intrant">Pramètres d'entrées</param>
        /// <returns>Un objet contenant la liste des périodes de pratique d'un professionnel</returns>
        ObtenirPeriodePratiqueProfessionnelSorti ObtenirPeriodePratiqueProfessionnel(ObtenirPeriodePratiqueProfessionnelEntre intrant);


        /// <summary>
        /// Permet d'obtenir les information sur l'admissibilité d'un professionnel à facturer
        /// </summary>
        /// <param name="intrant">Paramètre d'entrées</param>
        /// <returns>Un objet contenant les informations d'admissibilité</returns>
        VerifierAdmissibiliteProfessionnelFacturerSorti VerifierAdmissibiliteProfessionnel(VerifierAdmissibiliteProfessionnelFacturerEntre intrant);

        /// <summary>
        /// Permet d'obtenir les dispensateurs selon un numéro d'entente
        /// </summary>
        /// <param name="intrant">Paramètre d'entrées</param>
        /// <returns>Un objet contenant les informations des dispensateurs</returns>
        ObtenirDispensateursSelonEntenteSorti ObtenirDispensateursSelonEntente(ObtenirDispensateursSelonEntenteEntre intrant);

        /// <summary>
        /// Permet d'obtenir les noms et prenoms d'une liste de dispensateurs
        /// </summary>
        /// <param name="intrant">Paramètre d'entrées</param>
        /// <returns>Un objet contenant les informations des dispensateurs</returns>
        ObtenirNomPrenomListeDispensateursSorti ObtenirNomPrenomListeDispensateur(ObtenirNomPrenomListeDispensateursEntree intrant);

        /// <summary>
        /// Obtenir les informations personnelles sur un dispensateur
        /// </summary>
        /// <param name="intrant">Paramètres d'entrées</param>
        /// <returns>Un objet contenant la liste des informations personnelles d'un dispensateur</returns>
        /// <remarks></remarks>
        ObtenirInfoPerslDispSorti ObtenirInfoPerslDisp(ObtenirInfoPerslDispEntre intrant);
    }
}

