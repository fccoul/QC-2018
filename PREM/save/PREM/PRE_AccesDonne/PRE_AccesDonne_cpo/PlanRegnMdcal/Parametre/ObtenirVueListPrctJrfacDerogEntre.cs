using System;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    ///  Classe de paramètres d'entrée pour l'obtention de la vue des pourcentages de jours facturés en dérogation
    /// </summary>
    /// <remarks>
    ///  Auteur : Mathys Leleu<br/>
    ///  Date   : Octobre 2017
    /// </remarks>
	public class ObtenirVueListPrctJrfacDerogEntre
    {

        /// <summary>
        /// Année recherchée pour le rapport
        /// </summary>
        public int Annee { get; set; }

        /// <summary>
        /// Type pratique recherché
        /// </summary>
        public string TypePratique { get; set; }

        /// <summary>
        /// Pourcentage maximum recherché
        /// </summary>
        public double PourcentageMaximum { get; set; } = 101;

    }
}