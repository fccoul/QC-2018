namespace RAMQ.PRE.PRE_Entites_cpo.Reduction.Parametre
{
    /// <summary>
    /// Paramètre d'entre pour l'obtention de la liste des réduction d'un professionnel
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public class ObtenirReductionsProfessionnelEntre
    {
        /// <summary>
        /// Numéro séquentiel du médecin omnipraticien
        /// </summary>
        public long NumeroSequentielMedecinOmnipraticien { get; set; }

        /// <summary>
        /// Si est RPPR uniquement
        /// </summary>
        public string EstRPPRUniquement { get; set; }

    }
}