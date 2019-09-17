using RAMQ.Attribut;
using System;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite
{
    /// <summary>
    /// Paramètre de production
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public class ParametreProduction
    {
        /// <summary>
        /// Numéro de séquence
        /// </summary>
        [ValeurEntite(ElementName = "NO_SEQ_PARAM_PROD_PREMQ")]
        public int NumeroSequence { get; set; }

        /// <summary>
        /// Nom du paramètre
        /// </summary>
        [ValeurEntite(ElementName = "NOM_PARAM_PROD_PREMQ")]
        public string NomParametre { get; set; }

        /// <summary>
        /// Type de paramètre
        /// </summary>
        [ValeurEntite(ElementName = "TYP_PARAM_PROD_PREMQ")]
        public string Type { get; set; }

        /// <summary>
        /// Valeur numérique
        /// </summary>
        [ValeurEntite(ElementName = "VAL_NUM_PARAM_PROD_PREMQ")]
        public double? ValeurNumerique { get; set; }

        /// <summary>
        /// Valeur en caractère
        /// </summary>
        [ValeurEntite(ElementName = "VAL_CAR_PARAM_PROD_PREMQ")]
        public string ValeurCaractere { get; set; }

        /// <summary>
        /// Valeur en date
        /// </summary>
        [ValeurEntite(ElementName = "VAL_DAT_PARAM_PROD_PREMQ")]
        public DateTime? ValeurDate { get; set; }

        /// <summary>
        /// Date de début
        /// </summary>
        [ValeurEntite(ElementName = "DD_PARAM_PROD_PREMQ")]
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Date de fin
        /// </summary>
        [ValeurEntite(ElementName = "DF_PARAM_PROD_PREMQ")]
        public DateTime? DateFin { get; set; }

        /// <summary>
        /// Date heure occurrence
        /// </summary>
        [ValeurEntite(ElementName = "DHC_OCC")]
        public DateTime DateCreationOccurrence { get; set; }

        /// <summary>
        /// Identifiant de création
        /// </summary>
        [ValeurEntite(ElementName = "ID_UTIL_CREAT_OCC")]
        public string IdentifiantCreation { get; set; }

        /// <summary>
        /// Date heure modification de l'occurrence
        /// </summary>
        [ValeurEntite(ElementName = "DHM_OCC")]
        public DateTime? DateModificationOccurrence { get; set; }

        /// <summary>
        /// Identifiant de mise-à-jour de l'occurrence
        /// </summary>
        [ValeurEntite(ElementName = "ID_UTIL_MAJ_OCC")]
        public string IdentifiantMajOccurrence { get; set; }
    }
}