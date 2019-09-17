using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Entite;

namespace RAMQ.PRE.PRE_Entites_cpo.DecisionAvisConformite.Parametre
{
    /// <summary>
    /// Paramètre d'entré pour traiter l'ajout et la modification des suspensions.
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public class TraiterSuspensionAvisConformiteEntre
    {
        /// <summary>
        /// Avis de conformite
        /// </summary>
        public AvisConformite.Entite.AvisConformite Avis { get; set; }

        /// <summary>
        /// Nouvelle suspension
        /// </summary>
        public StatutAvisConformite NouvelleSuspension { get; set; }

        /// <summary>
        /// Type de l'action
        /// </summary>
        public Enumerations.TypeTraitementSuspension TypeAction { get; set; }

    }
}