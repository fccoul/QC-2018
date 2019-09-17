using System.Collections.Generic;
using RAMQ.ClasseBase;
using RAMQ.PRE.PRE_Entites_cpo.Securite.Entite;

namespace RAMQ.PRE.PRE_Entites_cpo.Securite.Parametre
{
    /// <summary> 
    ///  Paramètres de retour de la recherche de règles d'accès.
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : 2016-11-02
    /// </remarks>
    public class RechercherContexteRegleAccesSorti : ParamSorti
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public RechercherContexteRegleAccesSorti()
        {
            ContextesDroitAcces = new List<ContexteRegleAcces>();
        }

        /// <summary>
        /// Liste de code de contexte du droite d'accès.
        /// </summary>
        public List<ContexteRegleAcces> ContextesDroitAcces { get; set; }

    }
}
