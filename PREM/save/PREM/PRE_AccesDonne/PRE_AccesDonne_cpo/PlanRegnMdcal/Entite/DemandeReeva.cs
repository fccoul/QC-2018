using RAMQ.Attribut;
using System;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite
{

    /// <summary> 
    ///  Demande de réévaluation
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Mars 2018
    /// </remarks>
    public class DemandeReeva
    {

        /// <summary>
        /// Numéro séquentiel de demande
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "NO_SEQ_DEM_REEVA_PREMQ")]
        public long? NumeroSequentielDemReeva { get; set; }

        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "NO_SEQ_DISP")]
        public long? NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Catégorie de réévaluation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "CATG_REEVA_PREMQ")]
        public long CategorieReeva { get; set; }

        /// <summary>
        /// Code source de demande de réévaluation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "COD_SRCE_DEM_REEVA")]
        public long CodeSourceDemReeva { get; set; }

        /// <summary>
        /// Date de début de réévaluation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "DD_PER_REEVA")]
        public DateTime? DateDebutReeva { get; set; }

        /// <summary>
        /// Date de fin de réévaluation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "DF_PER_REEVA")]
        public DateTime? DateFinReeva { get; set; }

        /// <summary>
        /// Date et heure de la création de l'occurence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "DHC_OCC")]
        public DateTime? DateHeureCreation { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui a créé l'occurence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "ID_UTIL_CREAT_OCC")]
        public string IdentifiantCreation { get; set; }

        /// <summary>
        /// Date d'inactivation de l'occurence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "DH_INACT_OCC")]
        public DateTime? DateInact { get; set; }

        /// <summary>
        /// Identifiant utilisateur ayant inactivé l'occurence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "ID_UTIL_INACT_OCC")]
        public string IdentifiantInact { get; set; }

        
    }
}