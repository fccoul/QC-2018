using RAMQ.Attribut;
using System;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite
{
    /// <summary> 
    ///  Exemption
    /// </summary>
    /// <remarks>
    /// Auteur : Florent Pollart
    /// </remarks>
    public class Exemption
    {
        /// <summary>
        /// Numéro séquentiel de la réduction
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "no_seq_red")]
        public long NumeroSequentielReduction { get; set; }

        /// <summary>
        /// Numéro séquentiel d'exemption
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "no_seq_ex")]
        public long NumeroSequentielExemption{ get; set; }

        /// <summary>
        /// Date de début de l'exemption
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "dat_dd_ex")]
        public DateTime DateDebutExemption{ get; set; }

        /// <summary>
        /// Date de fin de l'exemption
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "dat_fin_ex")]
        public DateTime DateFinExemption { get; set; }

        /// <summary>
        /// Raise de l'exemption
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "raison_exemption")]
        public string RaisonExemption { get; set; }

        /// <summary>
        /// Raise d'annulation de l'exemption
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "raison_ann_exemption")]
        public string RaisonAnnExemption { get; set; }
    }
}