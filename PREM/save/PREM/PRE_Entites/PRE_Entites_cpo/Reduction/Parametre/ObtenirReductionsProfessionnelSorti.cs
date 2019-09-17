using RAMQ.ClasseBase;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_Entites_cpo.Reduction.Parametre
{
    /// <summary>
    /// Paramètre de sortie pour l'obtention de la liste des réduction d'un professionnel
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public class ObtenirReductionsProfessionnelSorti : ParamSorti
    {

        /// <summary>
        /// Constructeur
        /// </summary>
        public ObtenirReductionsProfessionnelSorti()
        {
            Reductions = new List<Entite.Reduction>();
        }

        /// <summary>
        /// Liste des réductions
        /// </summary>
        public IEnumerable<Entite.Reduction> Reductions { get; set; }

    }
}