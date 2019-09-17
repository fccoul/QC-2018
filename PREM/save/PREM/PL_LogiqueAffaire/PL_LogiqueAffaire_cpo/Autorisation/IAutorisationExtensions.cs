using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.Autorisation.Extensions
{
    /// <summary>
    /// Classe d'extension de l'interface IAutorisation.
    /// </summary>
    public static class IAutorisationExtensions
    {
        /// <summary>
        /// Permet de valider si notre interface est nulle.
        /// </summary>
        /// <param name="value">L'interface à vérifier.</param>
        /// <param name="paramName">Nom du paramètre.</param>
        public static void ValiderNonNull(this IAutorisation value, string paramName)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"Le paramètre : {paramName} ne peut être null.");
            }
        }
    }
}
