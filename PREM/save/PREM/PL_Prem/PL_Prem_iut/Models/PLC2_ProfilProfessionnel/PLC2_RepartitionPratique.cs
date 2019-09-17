using System.Collections.Generic;
using System.Web.Mvc;

namespace RAMQ.PRE.PL_Prem_iut.Models.PLC2_ProfilProfessionnel
{
    /// <summary>
    /// Modèle pour la répartition de la pratique
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
	public class PLC2_RepartitionPratique : PLC2_InformationProfessionnel
    {

        /// <summary>
        /// Liste d'années
        /// </summary>
        public List<SelectListItem> AnneesRepartition { get; set; }

        /// <summary>
        /// Année
        /// </summary>
        public string AnneeRepartition { get; set; }

        /// <summary>
        /// Liste d'engagement de pratiques
        /// </summary>
        public List<SelectListItem> EngagementPratiques { get; set; } = new List<SelectListItem>();

        /// <summary>
        /// Engagement Pratique
        /// </summary>
        public string EngagementPratiqueRepartition { get; set; }

        /// <summary>
        /// Liste des pratiques
        /// </summary>
        public List<SelectListItem> Pratiques { get; set; } = new List<SelectListItem>() {
            new SelectListItem() { Value ="Inter" , Text = "Interrégionale" },
            new SelectListItem() { Value ="Intra" , Text = "Intrarégionale " }
        };

        /// <summary>
        /// Pratique sélectionné
        /// </summary>
        public string Pratique { get; set; }

    }
}