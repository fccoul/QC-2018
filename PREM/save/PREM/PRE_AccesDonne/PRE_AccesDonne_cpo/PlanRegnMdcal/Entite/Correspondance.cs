using RAMQ.Attribut;
using System;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite
{
    /// <summary> 
    ///  Correspondance
    /// </summary>
    /// <remarks>
    /// Auteur : Florent Pollart
    /// </remarks>
    public class Correspondance
    {
        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "no_seq_disp")]
        public long NumeroSequentielDispensateur{ get; set; }

        /// <summary>
        /// Numéro séquentiel de la réduction
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "no_seq_red")]
        public long NumeroSequentielReduction { get; set; }

        /// <summary>
        /// Type de correspondance
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "typ_corre")]
        public string TypeCorrespondance { get; set; }

        /// <summary>
        /// Date prévue de l'envoie
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "dat_prevu_envoi")]
        public DateTime DatePrevueEnvoie{ get; set; }

        /// <summary>
        /// Date réelle de l'envoie
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "dat_reelle_envoi")]
        public DateTime DateReelleEnvoie { get; set; }

        /// <summary>
        /// Date d'annulation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "dat_ann")]
        public DateTime? DateAnnulation { get; set; }
    }
}