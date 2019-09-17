using System.Collections.Generic;
using RAMQ.ClasseBase;

namespace RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre
{

    /// <summary> 
    /// Paramètre de sortie pour l'obtention des avis de conformité
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : 2016-09-21
    /// </remarks>
    public class ObtenirLesAvisConformiteSorti : ParamSorti
    {

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirLesAvisConformiteSorti()
        {
            ListeAvisConformite = new List<Entite.AvisConformite>();
        }

        /// <summary>
        /// Liste des avis de conformité
        /// </summary>
        /// <remarks></remarks>
        public List<Entite.AvisConformite> ListeAvisConformite { get; set; }

    }

}