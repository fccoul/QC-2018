using System.Collections.Generic;
using RAMQ.ClasseBase;

namespace RAMQ.PRE.PRE_Entites_cpo.DroitAcquis.Parametre
{

    /// <summary> 
    /// Paramètre de sortie pour obtenir les droits acquis d'un professionnel
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : 2016-10-04
    /// </remarks>
    public class ObtenirDroitsAquisProfessionnelsSorti : ParamSorti
    {

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirDroitsAquisProfessionnelsSorti()
        {
            ListeDroitsAcquisActifProfs = new List<Entite.DroitAcquisActif>();
            ListeDroitsAcquisInactifProfs = new List<Entite.DroitAcquisInactif>();
        }

        /// <summary>
        /// Liste des droits acquis actifs des professionnels
        /// </summary>
        /// <remarks></remarks>
        public List<Entite.DroitAcquisActif> ListeDroitsAcquisActifProfs { get; set; }

        /// <summary>
        /// Liste des droits acquis inactifs des professionnels
        /// </summary>
        /// <remarks></remarks>
        public List<Entite.DroitAcquisInactif> ListeDroitsAcquisInactifProfs { get; set; }
    }
}