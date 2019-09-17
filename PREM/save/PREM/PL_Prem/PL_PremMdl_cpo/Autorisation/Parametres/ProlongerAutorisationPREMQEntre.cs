using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PL_PremMdl_cpo.Autorisation.Parametres
{
    /// <summary>
    /// Paramètre d'entré du service ProlongerAutorisationPREMQ
    /// </summary>
    public class ProlongerAutorisationPREMQEntre
    {
        /// <summary>
        /// Numéro séquentiel de l'autorisation à annuler.
        /// </summary>
        /// <remarks></remarks>
        public long NumeroSequentielAutorisation { get; set; }

        /// <summary>
        /// Date de fin d'autorisation PREMQ
        /// </summary>
        /// <remarks></remarks>
        public DateTime DateFinAutorisation { get; set; }

        /// <summary>
        /// Identifiant utilisateur prolongeant l'autorisation
        /// </summary>
        /// <remarks></remarks>
        public string IdentifiantUtilisateur { get; set; }
    }
}
