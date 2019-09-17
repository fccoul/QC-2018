using System;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    ///  Classe de paramètres d'entrée pour l'obtention de la vue des pourcentages de jours facturés en RPPR
    /// </summary>
    /// <remarks>
    ///  Auteur : Mathys Leleu<br/>
    ///  Date   : Décembre 2017
    /// </remarks>
	public class ObtenirVueListPrctJrfacRPPREntre
    {

        /// <summary>
        /// Année recherchée pour le rapport
        /// </summary>
        public int Annee { get; set; }

        /// <summary>
        /// Région recherchée
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Pourcentage minimum recherché
        /// </summary>
        public double PourcentageMinimum { get; set; } = -1;

        /// <summary>
        /// Nombre jours total minimum recherché
        /// </summary>
        public double NbreJoursTotalMinimum { get; set; } = -1;

        /// <summary>
        /// Numéro de séquence de dispensateur
        /// </summary>
        public long? DisNoSeq { get; set; }
        

    }
}