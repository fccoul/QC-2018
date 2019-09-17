using System;
using System.Collections.Generic;

namespace RAMQ.PRE.PL_Prem_iut.Models.PLA1_AvisConformite
{
    /// <summary>
    /// Modèle pour les avis en attente
    /// </summary>
    public class PLA1_Attente
    {
        /// <summary>
        /// Numéro de pratique
        /// </summary>
        public string NumeroAvis { get; set; }
        /// <summary>
        /// Liste de numéro de pratique
        /// </summary>
        public List<long?> NumerosAvis { get; set; }

        /// <summary>
        /// Liste de numéro de pratique avec le nom du professionnel
        /// </summary>
        public List<string> NumerosNomsPratique { get; set; }

        /// <summary>
        /// Liste des noms de territoire
        /// </summary>
        public List<string> Territoires { get; set; }

        /// <summary>
        /// Liste des dates prévues
        /// </summary>
        public List<DateTime> DatesPrevues { get; set; }

        /// <summary>
        /// Message d'avertissement
        /// </summary>
        public string MessageAvertissement { get; set; }
    }

}
