using System;

namespace RAMQ.PRE.PRE_Entites_cpo.DecisionAvisConformite.Entite
{
    /// <summary>
    /// Entite des suspensions
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public class Suspension
    {
        /// <summary>
        /// Avis de conformité
        /// </summary>
        public AvisConformite Avis { get; set; }

        /// <summary>
        /// Numéro séquentiel de la suspension
        /// </summary>
        public long? NumeroSequentiel { get; set; }

        /// <summary>
        /// Satut de la suspension
        /// </summary>
        public string Statut { get; set; }

        /// <summary>
        /// Identifiant utilisateur de celui qui fait l'action (Ajout, Annuler, Modifier)
        /// </summary>
        public string IdentifiantUtilisateur { get; set; }

        /// <summary>
        /// Date de début
        /// </summary>
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Date de fin
        /// </summary>
        public DateTime DateFin { get; set; }

        /// <summary>
        /// Type de suspension (Code de raison de statut)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Indicateur d'inactivation
        /// </summary>
        public string IndicateurInactivation { get; set; }
    }
}