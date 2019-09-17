using RAMQ.ClasseBase;
using System;

namespace RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre
{
    /// <summary> 
    ///  Paramètres de sortie pour la modification d'un statut de l'engagement.
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart<br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    public class ModifierStatutEngagementSorti : ParamSorti
    {
        /// <summary>
        /// Date et heure de l'occurence
        /// </summary>
        /// <remarks></remarks>
        public DateTime DateHeureOccurence { get; set; }

        /// <summary>
        /// Numéro séquentiel du statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        public long? NumeroSequentielStatutEngagement { get; set; }
    }
}