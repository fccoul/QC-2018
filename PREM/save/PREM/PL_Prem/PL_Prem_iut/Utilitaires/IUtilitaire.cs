using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PL_Prem_iut.Utilitaires
{
    /// <summary>
    /// Interface de la classe Utilitaire
    /// </summary>
    public interface IUtilitaire
    {
        /// <summary>
        /// Fonction exposé pour des fins de unit testing.
        /// </summary>
        /// <param name="nomGroupe">Nom du groupe à vérifier.</param>
        /// <returns></returns>
        bool EstDansGroupe(string nomGroupe);

        /// <summary>
        /// Fonction exposé pour des fins de unit testing.
        /// </summary>
        /// <param name="nomCookie"></param>
        /// <returns></returns>
        string ObtenirCookie(string nomCookie);
    }
}
