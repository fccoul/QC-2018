using RAMQ.Attribut;
using System;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal
{
    /// <summary>
    /// Paramètre d'entré du service du noyau TraitementReptnMensuelMassif
    /// </summary>
    public class TraiterRepartitionMensuelMassifEntre
    {
        /// <summary>
        /// Date du début de la période de répartition.
        /// </summary>
        [ValeurEntite(ElementName = "pDateDebutPeriode", Direction = ParameterDirection.Input)]
        public DateTime DateDebutPeriode { get; set; }

        /// <summary>
        /// Date de fin de la période de répartition.
        /// </summary>
        [ValeurEntite(ElementName = "pDateFinPeriode", Direction = ParameterDirection.Input)]
        public DateTime DateFinPeriode { get; set; }

        /// <summary>
        /// Indicateur de traitement massif.
        /// </summary>
        [ValeurEntite(ElementName = "pVchrIndTraitementMassif", Direction = ParameterDirection.Input)]
        public string IndTraitementMassif { get; set; }
    }
}