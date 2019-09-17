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
    public class AvisConformite
    {

        /// <summary>
        /// Numéro séquentiel de l'engagement de pratique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "no_seq_engag_prati")]
        public long? NumeroSequentielEngagement { get; set; }

        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "no_seq_disp")]
        public long? NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Code de région socio-sanitaire
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "cod_rss")]
        public string CodeRegion { get; set; }

        /// <summary>
        /// Date de début de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "dd_engag_prati")]
        public DateTime DateDebutEngagement { get; set; }

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
        /// Date de fin de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "df_engag_prati")]
        public DateTime? DateFinEngagement { get; set; }

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

        /// <summary>
        /// Type du lieu géographique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "typ_lgeo")]
        public string TypeLieuGeographique { get; set; }

        /// <summary>
        /// Code du lieu géographique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "cod_lgeo")]
        public string CodeLieuGeographique { get; set; }

        /// <summary>
        /// Numéro séquentiel de regroupement administratif des lieux géographiques
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "no_seq_regr_admn_lgeo")]
        public long? NumeroSequentielRegroupement { get; set; }
    }
}