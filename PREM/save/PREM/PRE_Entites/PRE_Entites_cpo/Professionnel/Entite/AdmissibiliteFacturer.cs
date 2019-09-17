using System;

namespace RAMQ.PRE.PRE_Entites_cpo.Professionnel.Entite
{
    /// <summary>
    /// Entité pour l'admissibilité à facturer d'un professionnel
    /// </summary>
    public class AdmissibiliteFacturer
    {

        /// <summary>
        /// Statut d'admissibilité
        /// </summary>
        public string StatutAdmissibilite { get; set; }

        /// <summary>
        /// Date de début de l'admissibilité
        /// </summary>
        public DateTime DateDebutAdmissibilite { get; set; }

        /// <summary>
        /// Date de fin de l'admissibilité
        /// </summary>
        public DateTime? DateFinAdmissibilite { get; set; }

        /// <summary>
        /// Code de raison de la non admissibilité
        /// </summary>
        public string CodeRaisonNonAdmissibilite { get; set; }
    }
}