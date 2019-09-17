using RAMQ.PRE.PRE_Entites_cpo.DroitAcquis.Parametre;
using RAMQ.PRE.PRE_OutilComun_cpo;

namespace RAMQ.PRE.PL_PremMdl_cpo.DroitAcquis
{
    /// <summary> 
    ///  Référentiel qui permet d'obtenir les informations des droits acquis d'un professionnel
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart<br/>
    ///  Date   : 2016-10-04
    /// <br/>
    ///  Historique des modifications<br/>
    ///  ------------------------------------------------------------------------------<br/>
    ///  Auteur : [Auteur]<br/>
    ///  Date   : [aaaa-mm-jj]<br/>
    ///  Description:<br/>
    /// <br/>
    /// </remarks>
    public class DroitAcquisReferentiel : IDroitAcquis
    {

        /// <summary>
        /// Permet d'obtenir les listes des droits acquis actifs et inactifs d'un professionnel
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Les listes des droits acquis actifs et inactifs d'un professionnel</returns>
        /// <remarks></remarks>
        public ObtenirDroitsAquisProfessionnelsSorti ObtenirDroitsAcquisProfs(ObtenirDroitsAquisProfessionnelsEntre intrant)
        {
            return UtilitaireService.AppelerService<svcObtnDroitAcqProf.IServObtnDroitAcqProf,
                                                     svcObtnDroitAcqProf.ServObtnDroitAcqProfClient,
                                                     ObtenirDroitsAquisProfessionnelsSorti>(x => x.ObtenirDroitsAcquisProfs(intrant));
        }
    }
}