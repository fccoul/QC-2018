using System;

namespace RAMQ.PRE.PL_Prem_iut.Entite
{
	/// <summary>
	/// Classe pour l'avis a modifier
	/// </summary>
	public class AvisAModifier
	{
        /// <summary>
        /// Date de début de l'engagement
        /// </summary>
        public DateTime? DateDebutEngagement { get; set; }

        /// <summary>
        /// Numéro séquentiel du regroupement
        /// </summary>
        public long? NumeroSequentielRegroupement { get; set; }

        /// <summary>
        /// Type de lieu géographique
        /// </summary>
        public string TypeLieuGeographique { get; set; }

        /// <summary>
        /// Code de lieu géographique
        /// </summary>
        public string CodeLieuGeographique { get; set; }

        /// <summary>
        /// Message d'avertissement
        /// </summary>
        public string MessageAvertissement { get; set; }

        /// <summary>
        /// Statut
        /// </summary>
        public string Statut { get; set; }
    }
}