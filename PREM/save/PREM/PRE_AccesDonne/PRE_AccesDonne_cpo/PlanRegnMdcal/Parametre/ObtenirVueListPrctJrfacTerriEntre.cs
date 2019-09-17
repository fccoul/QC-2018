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
	public class ObtenirVueListPrctJrfacTerriEntre
    {

        /// <summary>
        /// Année recherchée pour le rapport
        /// </summary>
        public int Annee { get; set; }

        /// <summary>
        /// Type répartition recherché
        /// </summary>
        public string TypeRepartition { get; set; }

        /// <summary>
        /// Région recherchée
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Sous-territoire recherché
        /// </summary>
        public string SousTerritoire { get; set; }

    }
}