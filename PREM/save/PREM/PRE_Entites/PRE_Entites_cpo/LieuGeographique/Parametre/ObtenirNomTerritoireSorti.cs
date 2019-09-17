using RAMQ.ClasseBase;

namespace RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Parametre
{

    /// <summary> 
    /// Entité d'extrant pour l'obtention du nom d'un territoire
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Décembre 2016
    /// </remarks>
    public class ObtenirNomTerritoireSorti : ParamSorti
    {

        /// <summary>
        /// Nom du territoire
        /// </summary>
        public string NomTerritoire { get; set; }

    }
    
}