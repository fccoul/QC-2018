using System;

namespace RAMQ.PRE.PRE_Entites_cpo.Reduction.Entite
{
    /// <summary>
    /// Réduction
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public class Reduction
    {

        /// <summary>
        /// Numéro Séquentiel
        /// </summary>
        public long NumeroSequentiel { get; set; }

        /// <summary>
        /// Date de début
        /// </summary>
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Date de fin
        /// </summary>
        public DateTime DateFin { get; set; }

        /// <summary>
        /// Raison de la réduction
        /// </summary>
        public string RaisonReduction { get; set; }

        /// <summary>
        /// Engagement
        /// </summary>
        public string Engagement { get; set; }

        /// <summary>
        /// Nombre de jours
        /// </summary>
        public float NombreJours { get; set; }

        /// <summary>
        /// Pourcentage effectué
        /// </summary>
        public float PourcentageEffectuer { get; set; }

        /// <summary>
        /// Code d'application
        /// </summary>
        public string CodeApplication { get; set; }




    }
}