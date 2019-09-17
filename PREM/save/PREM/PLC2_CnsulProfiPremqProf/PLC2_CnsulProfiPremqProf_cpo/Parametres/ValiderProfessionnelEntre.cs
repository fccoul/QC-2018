using System;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Parametres
{
    /// <summary>
    /// Classe de paramètre d'entrer pour la validation du professionnel
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
	public class ValiderProfessionnelEntre
    {

        /// <summary>
        /// Date de décès
        /// </summary>
        public DateTime? DateDeces { get; set; }

        /// <summary>
        /// Date de première spécialité
        /// </summary>
        public DateTime? DatePremiereSpecialite { get; set; }

        /// <summary>
        /// Numéro du dispensateur
        /// </summary>
        public int? NumeroDispensateur { get; set; }

        /// <summary>
        /// Numéro de classe du dispensateur
        /// </summary>
        public int? NumeroClasseDispensateur { get; set; }

    }
}
