
using System;

namespace RAMQ.PRE.PRE_Entites_cpo.DecisionAvisConformite.Parametre
{
	/// <summary>
	/// Paramètre d'entré pour traiter l'annulation des dérogations
	/// </summary>
	/// <remarks>
	/// Auteur: Jean-Benoit Drouin-Cloutier
	/// </remarks>
	public class TraiterAnnulationDerogationEntre
	{

		/// <summary>
		/// Numéro de séquence de la dérogation
		/// </summary>
		public long NumeroSequentielDerogation { get; set; }

		/// <summary>
		/// Date de début de la dérogation
		/// </summary>
		public DateTime DateDebutDerogation { get; set; }

		/// <summary>
		/// Numéro de séquence du dispensateur
		/// </summary>
		public long NumeroSequentielDispensateur { get; set; }

	}
}