using System.Collections.Generic;
using RAMQ.ClasseBase;
using RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Entite;

namespace RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Parametre
{

    /// <summary> 
    /// Entité d'intrant pour l'obtention des territoires permis
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Décembre 2016
    /// </remarks>
    public class ObtenirTerritoiresPermisSorti : ParamSorti
    {

        /// <summary>
        /// Constructeur
        /// </summary>
        public ObtenirTerritoiresPermisSorti()
        {
            TerritoiresPermis = new List<TerritoirePermis>();
        }

        /// <summary>
        /// Territoires permis
        /// </summary>
        public List<TerritoirePermis> TerritoiresPermis { get; set; }
    }
}