using RAMQ.Attribut;
using System;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite
{

    /// <summary> 
    ///  Autorisation
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Novembre 2016
    /// </remarks>
    public class Autorisation
    {

        /// <summary>
        /// Numéro de séquence de l'autorisation
        /// </summary>
        /// <returns></returns>
        [ValeurEntite(ElementName = "NO_SEQ_AUTOR_PREMQ")]
        public long NumeroSequenceAutorisation { get; set; }

        /// <summary>
        /// Numéro de séquence du dispensateur
        /// </summary>
        [ValeurEntite(ElementName = "NO_SEQ_DISP")]
        public long NumeroSequenceDispensateur { get; set; }

        /// <summary>
        /// Type lieu géographique
        /// </summary>
        /// <returns></returns>
        [ValeurEntite(ElementName = "TYP_LGEO")]
        public string TypeLieuGeographique { get; set; }

        /// <summary>
        /// Code lieu géographique
        /// </summary>
        /// <returns></returns>
        [ValeurEntite(ElementName = "COD_LGEO")]
        public string CodeLieuGeographique { get; set; }

        /// <summary>
        /// Numéro séquentiel identifiant un regroupement administratif des lieux géographiques.
        /// </summary>
        /// <returns></returns>
        [ValeurEntite(ElementName = "NO_SEQ_REGR_ADMN_LGEO")]
        public int NumeroSequenceRegroupementAdministratif { get; set; }

        /// <summary>
        /// Type d'autorisation
        /// </summary>
        /// <returns></returns>
        [ValeurEntite(ElementName = "TYP_AUTOR_PREMQ")]
        public string TypeAutorisation { get; set; }

        /// <summary>
        /// Date de début de l'autorisation
        /// </summary>
        /// <returns></returns>
        [ValeurEntite(ElementName = "DD_AUTOR_PREMQ")]
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Date de fin de l'autorisation
        /// </summary>
        /// <returns>Nullable</returns>
        [ValeurEntite(ElementName = "DF_AUTOR_PREMQ")]
        public DateTime? DateFin { get; set; }


        /// <summary>
        /// Date heure création de l’occurrence
        /// </summary>
        /// <returns></returns>
        [ValeurEntite(ElementName = "DHC_OCC")]
        public DateTime? DateHeureCreation { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui a créé l'occurrence.
        /// </summary>
        /// <returns></returns>
        [ValeurEntite(ElementName = "ID_UTIL_CREAT_OCC")]
        public string IdUtilisateurCreateur { get; set; }

        /// <summary>
        /// Date et heure de l'inactivation de l'occurrence.
        /// </summary>
        /// <returns></returns>
        [ValeurEntite(ElementName = "DH_INACT_OCC")]
        public DateTime DateHeureInactivation { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui a inactivé l'occurrence.
        /// </summary>
        /// <returns></returns>
        [ValeurEntite(ElementName = "ID_UTIL_INACT_OCC")]
        public string IdUtilisateurInactivation { get; set; }

        /// <summary>
        /// Code Rss
        /// </summary>
        /// <returns></returns>
        [ValeurEntite(ElementName = "cod_rss")]
        public string CodeRSS { get; set; }

        /// <summary>
        /// Code de raison du statut de l'autorisation
        /// </summary>
        /// <returns></returns>
        [ValeurEntite(ElementName = "cod_rais_modif_autor")]
        public string CodeRaisonStatut { get; set; }

    }
}