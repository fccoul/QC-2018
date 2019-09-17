using System;
namespace RAMQ.PRE.PL_Prem_iut.Entite
{
    /// <summary>
    /// Droit acquis
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public class DroitExercice
    {

        /// <summary>
        /// Région
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Territoire
        /// </summary>
        public string Territoire { get; set; }

        /// <summary>
        /// Date debut de la Période
        /// </summary>
        public DateTime? DateDebutPeriode { get; set; }

        /// <summary>
        /// Date Fin de la Période
        /// </summary>
        public DateTime? DateFinPeriode { get; set; }


    }
}