using System;
using RAMQ.Attribut;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite
{

    /// <summary> 
    ///  Refus
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Septembre 2016
    /// </remarks>
    public class StatutAvisConformite
    {

        /// <summary>
        /// Numéro séquentiel du statut de l'engagement de pratique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "no_seq_sta_engag_prati")]
        public long? NumeroSequentielStatutEngagement { get; set; }

        /// <summary>
        /// Numéro séquentiel de l'engagement de pratique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "no_seq_engag_prati")]
        public long? NumeroSequentielEngagement { get; set; }

        /// <summary>
        /// Statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "sta_engag_terri")]
        public string StatutEngagement { get; set; }

        /// <summary>
        /// Indicateur du statut de l'engagement en attente
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "ind_sta_engag_atten")]
        public string IndicateurStatutEngagementAttente { get; set; }

        /// <summary>
        /// Date et heure de l'occurence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "dhc_occ")]
        public DateTime? DateHeureOccurence { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui a créé l'occurence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "id_util_creat_occ")]
        public string IdentifiantCreation { get; set; }

        /// <summary>
        /// Date de début du statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "dd_sta_engag_terri")]
        public DateTime DateDebutStatutEngagement { get; set; }

        /// <summary>
        /// Code de raison du statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "cod_rais_sta_engag")]
        public string CodeRaisonStatutEngagement { get; set; }

        /// <summary>
        /// Date de fin du statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "df_sta_engag_terri")]
        public DateTime? DateFinStatutEngagement { get; set; }

        /// <summary>
        /// Date et heure de la modification de l'occurence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "dhm_occ")]
        public DateTime? DateHeureOccurenceMAJ { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui a modifié l'occurence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "id_util_maj_occ")]
        public string IdentifiantMAJ { get; set; }

        /// <summary>
        /// Date et heure de l'inactivité de l'occurence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "dh_inact_occ")]
        public DateTime? DateHeureOccurenceInactive { get; set; }

    }
}