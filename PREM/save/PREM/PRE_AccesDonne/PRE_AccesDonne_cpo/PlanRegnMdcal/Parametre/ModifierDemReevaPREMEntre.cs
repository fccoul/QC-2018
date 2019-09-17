using RAMQ.Attribut;
using System;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    /// Paramètre d'entré du service du noyau ModifierDemReevaPREM
    /// </summary>
    public class ModifierDemReevaPREMEntre
    {
        /// <summary>
        /// Numéro séquentiel de la demande à annuler.
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqDemReeva", Direction = ParameterDirection.Input)]
        public long NumeroSequentielDemReeva { get; set; }

        /// <summary>
        /// Identifiant utilisateur effectuant la M-à-J la demande
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrIdentifiantMaj", Direction = ParameterDirection.Input)]
        public string IdentifiantUtilisateur { get; set; }

        /// <summary>
        /// Date de début M-à-J la demande
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDebutReeva", Direction = ParameterDirection.Input)]
        public DateTime DatDebutReeva { get; set; }


        /// <summary>
        /// Date de fin M-à-J la demande
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatFinReeva", Direction = ParameterDirection.Input)]
        public DateTime DatFinReeva { get; set; }

    }
}
