using RAMQ.Attribut;
using RAMQ.ClasseBase;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    /// Paramètre de sorti du service du noyau TraitementReptnJournalier
    /// </summary>
    public class TraiterRepartitionJournalierSorti : ParamSorti
    {

        /// <summary>
        /// Nombre de service traité.
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNbServiceTraite", Direction = ParameterDirection.Output)]
        public long NombreServiceTraite { get; set; }

        /// <summary>
        /// Nombre de service enregistré.
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNbServiceEnregistre", Direction = ParameterDirection.Output)]
        public long NombreServiceEnregistre { get; set; }

        /// <summary>
        /// Nombre de rejet.
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNbRejet", Direction = ParameterDirection.Output)]
        public long NombreRejet { get; set; }
    }
}