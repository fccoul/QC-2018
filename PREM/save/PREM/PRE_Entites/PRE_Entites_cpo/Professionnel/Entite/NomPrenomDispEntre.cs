using RAMQ.ClasseBase;
using System;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_Entites_cpo.Professionnel.Entite
{
    /// <summary>
    /// NomPrenomDispEntre
    /// </summary>
    public class NomPrenomDispEntre
    {
        /// <summary>
        /// Nom
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prénom
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Numéro de classe
        /// </summary>
        public int? NumeroClasse { get; set; }

        /// <summary>
        /// Numéro de dispensateur
        /// </summary>
        public int? NumeroDispensateur { get; set; }

        /// <summary>
        /// Numéro séquentiel de dispensateur
        /// </summary>
        public long? NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Identifiant du dispensateur
        /// </summary>
        public string Identifiant { get; set; }

        /// <summary>
        /// Type Identifiant du dispensateur
        /// </summary>
        public string TypeIdentifiant { get; set; }

        /// <summary>
        /// Date de service
        /// </summary>
        public DateTime? DateService { get; set; }
    }
}