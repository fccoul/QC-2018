using RAMQ.Attribut;
using System;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite
{
    /// <summary>
    /// Réduction de la rémunération des professionnels
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public class ReductionRemuneration
    {

        /// <summary>
        /// Numéro séquentiel
        /// </summary>
        [ValeurEntite(ElementName = "NO_SEQ_REDUC_REMU")]
        public long NumeroSequence { get; set; }

        /// <summary>
        ///  Numéro séquentiel du dispensateur
        /// </summary>
        [ValeurEntite(ElementName = "NO_SEQ_DISP")]
        public long NumeroSequenceDispensateur { get; set; }

        /// <summary>
        /// Code de raison de la réduction de la rémunération du professionnel de la santé.
        /// </summary>
        [ValeurEntite(ElementName = "COD_RAIS_REDUC_REMU")]
        public string CodeRaison { get; set; }

        /// <summary>
        /// Type du lieu géographique
        /// </summary>
        [ValeurEntite(ElementName = "TYP_LGEO")]
        public string TypeLieuGeographique { get; set; }

        /// <summary>
        /// Code du lieu géographique
        /// </summary>
        [ValeurEntite(ElementName = "COD_LGEO")]
        public string CodeLieuGeographique { get; set; }

        /// <summary>
        ///  Numéro séquentiel de la région administrative du lieu géographique
        /// </summary>
        [ValeurEntite(ElementName = "NO_SEQ_REGR_ADMN_LGEO")]
        public long? NumeroSequenceRegionAdministrativeLieuGeographique { get; set; }

        /// <summary>
        ///  Numéro séquentiel de l'engagement de pratique
        /// </summary>
        [ValeurEntite(ElementName = "NO_SEQ_ENGAG_PRATI")]
        public long? NumeroSequenceEngagementPratique { get; set; }

        /// <summary>
        ///  Numéro séquentiel de la dérogation
        /// </summary>
        [ValeurEntite(ElementName = "NO_SEQ_DEROG_PRATI_PROF")]
        public long? NumeroSequenceDerogation { get; set; }

        /// <summary>
        /// Date de début de la réduction de la rémunération du professionnel de la santé
        /// </summary>
        [ValeurEntite(ElementName = "DD_REDUC_REMU")]
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Date de fin de la réduction de la rémunération du professionnel de la santé
        /// </summary>
        [ValeurEntite(ElementName = "DF_REDUC_REMU")]
        public DateTime DateFin { get; set; }

        /// <summary>
        /// Nombre de jours de facturation pour la réduction.
        /// </summary>
        [ValeurEntite(ElementName = "NBR_JR_FACT_REDUC_REMU")]
        public float NombreJourFacturer { get; set; }

        /// <summary>
        /// Nombre total de journées de facturation pour la période sujet à réduction.
        /// </summary>
        [ValeurEntite(ElementName = "NBR_TOT_JR_FACT_REDUC")]
        public float NombreJourTotalFacturer { get; set; }

        /// <summary>
        /// Code identifiant l'étendue de la réduction de la rémunération du professionnel de la santé.
        /// </summary>
        [ValeurEntite(ElementName = "COD_ETEN_REDUC_REMU")]
        public string CodeEtendu { get; set; }

        /// <summary>
        /// Code de l'état de la réduction de la rémunération du professionnel de la santé.
        /// </summary>
        [ValeurEntite(ElementName = "COD_ETA_REDUC_REMU")]
        public string CodeEtat { get; set; }

        /// <summary>
        /// Code de raison de l'exemption de la réduction de la rémunération du professionnel de la santé
        /// </summary>
        [ValeurEntite(ElementName = "COD_RAIS_EXEMP_REDUC")]
        public string CodeRaisonExemption { get; set; }

        /// <summary>
        /// Code de raison de l'annulation de l'exemption de la réduction de la rémunération du professionnel de la santé.
        /// </summary>
        [ValeurEntite(ElementName = "COD_RAIS_ANNU_EXEMP_REDUC")]
        public string CodeRaisonAnnulationExemption { get; set; }

        /// <summary>
        /// Date et heure de création de l'occurrence.
        /// </summary>
        [ValeurEntite(ElementName = "DHC_OCC")]
        public DateTime DateHeureCreationOccurence { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui a créé l'occurrence.
        /// </summary>
        [ValeurEntite(ElementName = "ID_UTIL_CREAT_OCC")]
        public string IdentifiantUtilisateurCreationOccurence { get; set; }

        /// <summary>
        /// Date et heure de l'inactivation de l'occurrence.
        /// </summary>
        [ValeurEntite(ElementName = "DH_INACT_OCC")]
        public DateTime? DateHeureInactivationOccurence { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui a inactivé l'occurrence.
        /// </summary>
        [ValeurEntite(ElementName = "ID_UTIL_INACT_OCC")]
        public string IdentifiantUtilisateurInactivationOccurence { get; set; }
    }
}