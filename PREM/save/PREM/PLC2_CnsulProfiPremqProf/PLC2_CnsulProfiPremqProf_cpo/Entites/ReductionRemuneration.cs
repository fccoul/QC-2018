using System;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Entites
{
    /// <summary>
    /// Classe d'une entité d'une réduction à la rémunération
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public class ReductionRemuneration
    {

        /// <summary>
        /// Numéro séquentiel de réduction
        /// </summary>
        public long NumeroSequentielReduction { get; set; }

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
        /// Type de la réduction
        /// </summary>
        public string TypeReduction { get; set; }

        /// <summary>
        /// Est exemption
        /// </summary>
        public bool EstExemption { get; set; }

        /// <summary>
        /// Raison de l'exemption
        /// </summary>
        public string RaisonExemption { get; set; }
    }
}