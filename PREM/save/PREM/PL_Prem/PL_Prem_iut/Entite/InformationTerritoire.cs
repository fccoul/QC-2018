using System;

namespace RAMQ.PRE.PL_Prem_iut.Entite
{
    /// <summary>
    /// Classe pour les information sur le territoire
    /// </summary>
    public class InformationTerritoire
    {
        /// <summary>
        /// Date de début de la pratique
        /// </summary>
        public DateTime? DateDebutPratique { get; set; }

        /// <summary>
        /// Numéro séquentiel
        /// </summary>
        public long NumeroSequentiel { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Code
        /// </summary>
        public string Code { get; set; }
    }
}
