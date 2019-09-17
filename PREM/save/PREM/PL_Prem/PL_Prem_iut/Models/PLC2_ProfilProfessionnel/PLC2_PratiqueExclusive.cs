using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RAMQ.PRE.PL_Prem_iut.Models.PLC2_ProfilProfessionnel
{
    /// <summary>
    /// Modèle pour la pratique exclusive
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
	public class PLC2_PratiqueExclusive : PLC2_InformationProfessionnel
    {

        private static IEnumerable<string> _rangeesTableauPratiqueExclusive;

        /// <summary>
        /// Liste d'années
        /// </summary>
        public List<SelectListItem> AnneesPratique { get; set; }

        /// <summary>
        /// Année
        /// </summary>
        public string AnneePratique { get; set; }

        /// <summary>
        /// Liste des engagements de pratiques
        /// </summary>
        public List<SelectListItem> EngagementsPratiqueExclusive { get; set; }

        /// <summary>
        /// Engagement de pratiques
        /// </summary>
        public string EngagementPratiqueExclusive { get; set; }

        /// <summary>
        /// Indicateur pour savoir si la pratique est en dépannage ou non
        /// </summary>
        public bool EstPratiqueDepannage { get; set; }


        /// <summary>
        /// Liste des noms de rangée pour la table des pratiques exclusive
        /// </summary>
        public static List<string> RangeeTablePratiqueExclusive
        {
            get
            {
                if (_rangeesTableauPratiqueExclusive == null)
                {
                    _rangeesTableauPratiqueExclusive = new List<string>(Constantes.NomRangeeTableauPratiqueExclusive.Split(';'));
                }
                return _rangeesTableauPratiqueExclusive.ToList();
            }
        }
    }
}