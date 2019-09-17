using System;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    ///  Classe de paramètres d'entrée pour l'obtention de la vue des pourcentages de jours facturés en avis
    /// </summary>
    /// <remarks>
    ///  Auteur : Mathys Leleu<br/>
    ///  Date   : Octobre 2017
    /// </remarks>
	public class ObtenirVueListPrctJrfacAvisEntre
    {

        /// <summary>
        /// Année recherchée pour le rapport
        /// </summary>
        public int Annee { get; set; }

        /// <summary>
        /// Région recherchée
        /// </summary>
        public string CodeRSS { get; set; }

        /// <summary>
        /// Sous-territoire recherché
        /// </summary>
        public string SousTerritoire { get; set; }

        /// <summary>
        /// Pourcentage maximum recherché
        /// </summary>
        public double PourcentageMaximum { get; set; } = 101;


    }
}