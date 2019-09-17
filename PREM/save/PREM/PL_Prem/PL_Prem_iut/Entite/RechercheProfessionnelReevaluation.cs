using RAMQ.PRE.PRE_Entites_cpo.DemandeReevaluation.Entite;
using System.Collections.Generic;

namespace RAMQ.PRE.PL_Prem_iut.Entite
{
    /// <summary>
    /// Entité pour l'obtention des information d'un professionnel pour les demandes de réévaluation
    /// </summary>
    public class RechercheProfessionnelReevaluation : RechercheProfessionnelInformation
    {
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public RechercheProfessionnelReevaluation()
        {
            DemandesReevaluation = new List<DemandeReevaluation>();
        }

        /// <summary>
        /// Demandes de réévaluation
        /// </summary>
        public List<DemandeReevaluation> DemandesReevaluation { get; set; }

        
    }
}