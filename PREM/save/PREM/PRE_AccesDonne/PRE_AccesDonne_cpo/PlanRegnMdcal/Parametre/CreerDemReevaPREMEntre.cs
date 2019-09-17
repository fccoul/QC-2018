using RAMQ.Attribut;
using System;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    /// Paramètre d'entré du service du noyau CreerDemReevaPREM
    /// </summary>
    public class CreerDemReevaPREMEntre
    {
        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqDisp", Direction = ParameterDirection.Input)]
        public long? NumeroSequentielDisp { get; set; }

        /// <summary>
        /// Identifiant utilisateur qui crée la demande
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrIdentifiantCreat", Direction = ParameterDirection.Input)]
        public string IdentifiantUtilisateur { get; set; }

        /// <summary>
        /// Date de début de la demande
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDebutReeva", Direction = ParameterDirection.Input)]
        public DateTime? DatDebutReeva { get; set; }


        /// <summary>
        /// Date de fin de la demande
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatFinReeva", Direction = ParameterDirection.Input)]
        public DateTime? DatFinReeva { get; set; }

        /// <summary>
        /// Numéro de catégorie de la demande
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumCatgReeva", Direction = ParameterDirection.Input)]
        public long? NumeroCategorieReeva { get; set; }

        /// <summary>
        /// Code de la source de la demande
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumCodSourceDem", Direction = ParameterDirection.Input)]
        public long? CodeSourceDemande { get; set; }
    }
}
