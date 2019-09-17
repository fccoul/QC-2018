namespace RAMQ.PRE.PL_Prem_iut.Entite
{
    /// <summary>
    /// Période d'exercice
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public class PeriodeExercice
    {

        /// <summary>
        /// Période
        /// </summary>
        public string Periode { get; set; }

        /// <summary>
        /// Engagement actif pour la période
        /// </summary>
        public string EngagementActif { get; set; }

        /// <summary>
        /// Nombre de jours en pratique partielle restreinte sans y être autorisé
        /// </summary>
        public decimal NombreJourPratique { get; set; }

        /// <summary>
        /// Pourcentage effectué
        /// </summary>
        public decimal PourcentageEffectuer { get; set; }

        /// <summary>
        /// Région du droit d'exercie
        /// </summary>
        public string Region { get; set; }

    }
}