using RAMQ.ClasseBase;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_Entites_cpo.Recherche.Entite
{
    /// <summary>
    /// Entité pour les résultats de recherche
    /// </summary>
    public class Resultat : ParamSorti
    {

        /// <summary>
        /// Constructeur
        /// </summary>
        public Resultat()
        {
            ListeResultat = new List<KeyValuePair<long?, string>>();
        }

        /// <summary>
        /// Total des résultats
        /// </summary>
        public int TotalResultat { get; set; }

        /// <summary>
        /// Liste de résultat
        /// </summary>
        public List<KeyValuePair<long?, string>> ListeResultat { get; set; }

    }
}