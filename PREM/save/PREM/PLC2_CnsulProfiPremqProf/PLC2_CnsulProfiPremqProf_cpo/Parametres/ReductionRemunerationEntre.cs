namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Parametres
{
    /// <summary>
    /// Classe de paramètre d'entrer pour la réduction de la rémunération
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
	public class ReductionRemunerationEntre
    {
        /// <summary>
        /// Numéro séquentiel du médecin omnipraticien
        /// </summary>
        public long NumeroSequentielMedecin { get; set; }

        /// <summary>
        /// RPPR Uniquement
        /// </summary>
        public string RpprUniquement { get; set; }


    }
}