using System;
using RAMQ.ClasseBase;

namespace RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre
{

    /// <summary> 
    /// Paramètre de sortie pour la création d'un statut de l'engagement
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : 2017-01-23
    /// </remarks>
    public class CreerStatutAvisConformiteSorti : ParamSorti
    {

        /// <summary>
        /// Numéro séquentiel du statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        public long NumeroSequentielStatutEngagement { get; set; }
        /// <summary>
        /// Date et heure de l'occurence
        /// </summary>
        /// <remarks></remarks>
        public DateTime DateHeureOccurence { get; set; }

    }

}