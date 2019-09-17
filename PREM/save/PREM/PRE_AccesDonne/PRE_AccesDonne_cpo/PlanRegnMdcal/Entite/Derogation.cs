using System;
using RAMQ.Attribut;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite
{

    /// <summary> 
    ///  Dérogation
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Octobre 2016
    /// </remarks>
    public class Derogation
    {

        /// <summary>
        /// Numéro séquentiel de la dérogation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "NO_SEQ_DEROG_PRATI_PROF")]
        public long NumeroSequentiel { get; set; }

        /// <summary>
        ///  Type de dérogation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "TYP_DEROG_PRATI_PROF")]
        public string Type { get; set; }

        /// <summary>
        /// Date de début de la dérogation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "DD_DEROG_PRATI_PROF")]
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Date de renouvellement de la dérogation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "DAT_RENOU_DEROG_PROF")]
        public DateTime? DateRenouvellement { get; set; }

        /// <summary>
        /// Statut de la dérogation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "STA_DEROG_PRATI_PROF")]
        public string Statut { get; set; }

        /// <summary>
        /// Code de raison du statut de la dérogation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "COD_RAIS_STA_DEROG_PROF")]
        public string CodeRaisonStatut { get; set; }

        /// <summary>
        /// Date de fin de la dérogation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "DF_DEROG_PRATI_PROF")]
        public DateTime? DateFin { get; set; }

        /// <summary>
        /// Date et heure de création de l’occurrence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "DHC_OCC")]
        public DateTime DateHeureCreationOccurence { get; set; }

        /// <summary>
        /// Identifiant de l’utilisateur qui a créé l’occurrence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "ID_UTIL_CREAT_OCC")]
        public string IdentifiantCreationOccurence { get; set; }

        /// <summary>
        /// Date et heure d’inactivation de l’occurrence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "DH_INACT_OCC")]
        public DateTime? DateHeureInactivationOccurence { get; set; }

        /// <summary>
        /// Identifiant de l’utilisateur qui a inactivé l’occurrence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "ID_UTIL_INACT_OCC")]
        public string IdentifiantInactivationOccurence { get; set; }

    }

}