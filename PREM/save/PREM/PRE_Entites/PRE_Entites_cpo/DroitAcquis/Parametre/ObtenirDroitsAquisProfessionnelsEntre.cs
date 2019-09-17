using System.Collections.Generic;

namespace RAMQ.PRE.PRE_Entites_cpo.DroitAcquis.Parametre
{
    /// <summary> 
    /// Paramètre d'entré pour obtenir les droits acquis d'un professionnel
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : 2016-10-04
    /// </remarks>
    public class ObtenirDroitsAquisProfessionnelsEntre
    {
        /// <summary>
        /// Liste des numéros séquentiels des professionnels
        /// </summary>
        /// <remarks></remarks>
        public List<long> ListeNumeroSequentielProfs { get; set; }
    }
}