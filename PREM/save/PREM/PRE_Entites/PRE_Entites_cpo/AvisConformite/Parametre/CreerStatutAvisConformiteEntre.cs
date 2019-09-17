using System;

namespace RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre
{
    /// <summary> 
    /// Paramètre d'entrée pour la création d'un statut de l'engagement
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : 2017-01-23
    /// </remarks>
    public class CreerStatutAvisConformiteEntre
    {

        /// <summary>
        /// Numéro séquentiel de l'engagement
        /// </summary>
        /// <remarks></remarks>
        public long NumeroSequentielEngagement { get; set; }

        /// <summary>
        /// Statut de l'engagement 
        /// </summary>
        /// <remarks></remarks>
        public string StatutEngagement { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur créeant le statut
        /// </summary>
        /// <remarks></remarks>
        public string IdentifiantCreation { get; set; }

        /// <summary>
        /// Date de début du statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateDebutStatutEngagement { get; set; }

        /// <summary>
        /// Code de raison du statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        public string CodeRaisonStatutEngagement { get; set; }

        /// <summary>
        /// Date de fin du statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateFinStatutEngagement { get; set; }

    }
}