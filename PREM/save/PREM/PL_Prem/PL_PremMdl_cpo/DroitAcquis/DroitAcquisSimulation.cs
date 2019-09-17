using RAMQ.PRE.PRE_Entites_cpo.DroitAcquis.Parametre;
using System;

namespace RAMQ.PRE.PL_PremMdl_cpo.DroitAcquis
{
    /// <summary> 
    ///  Référentiel bidon qui permet d'obtenir les droits acquis fictifs des professionnels  
    ///  codés en dur.
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : 2016-10-11
    /// <br/>
    ///  Historique des modifications<br/>
    ///  ------------------------------------------------------------------------------<br/>
    ///  Auteur : [Auteur]<br/>
    ///  Date   : [aaaa-mm-jj]<br/>
    ///  Description:<br/>
    /// <br/>
    /// </remarks>
    public class DroitAcquisSimulation : IDroitAcquis
    {

        /// <summary>
        /// Permet d'obtenir les listes des droits acquis actifs et inactifs d'un professionnel
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Les listes des droits acquis actifs et inactifs d'un professionnel</returns>
        /// <remarks></remarks>
        public ObtenirDroitsAquisProfessionnelsSorti ObtenirDroitsAcquisProfs(ObtenirDroitsAquisProfessionnelsEntre intrant)
        {

            //TODO : Faire la simulation
            return new ObtenirDroitsAquisProfessionnelsSorti()
            {
                ListeDroitsAcquisActifProfs = new System.Collections.Generic.List<PRE_Entites_cpo.DroitAcquis.Entite.DroitAcquisActif>()
                {
                    new PRE_Entites_cpo.DroitAcquis.Entite.DroitAcquisActif()
                    {
                        CodeLieuGeographique = "108",
                        CodeRegionSocioSanitaire = "1"
                    },
                    new PRE_Entites_cpo.DroitAcquis.Entite.DroitAcquisActif()
                    {
                        CodeLieuGeographique = "108",
                        CodeRegionSocioSanitaire = "1"
                    }
                }
            };
        }

    }
}