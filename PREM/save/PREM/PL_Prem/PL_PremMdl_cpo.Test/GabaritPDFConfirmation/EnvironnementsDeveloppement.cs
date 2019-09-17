using System.Collections;
using System.Collections.Generic;

namespace RAMQ.PRE.PL_PremMdl_cpo.Test.GabaritPDFConfirmation
{
    /// <summary>
    /// Cette classe permet de récupérer tous les paliers de développements
    /// </summary>
    /// <remarks>
    /// Auteur : Alexis Garon-Michaud
    /// Date   : Avril 2017
    /// </remarks>
    public class EnvironnementsDeveloppement : IEnumerable<object[]>
    {
        private readonly List<object[]> _environnementsDeveloppement = new List<object[]>
        {
            new object[] {Environnement.Unitaire},
            new object[] {Environnement.Fonctionnel},
            new object[] {Environnement.Integration},
            new object[] {Environnement.Acceptation},
            new object[] {Environnement.PreDev},
            new object[] {Environnement.Techno},
            new object[] {Environnement.Urgence},
            new object[] {Environnement.Formation},
            new object[] {Environnement.Partenaire}
        };

        /// <summary>
        /// Retourne un énumérateur qui itère au sein de la collection
        /// </summary>
        /// <returns></returns>
        public IEnumerator<object[]> GetEnumerator()
        {
            return _environnementsDeveloppement.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}