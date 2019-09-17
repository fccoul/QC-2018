using System.Collections.Generic;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Entite;
using RAMQ.ClasseBase;

namespace RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre
{
    /// <summary> 
    ///  Paramètre de sortie pour obtenir les noms, prenoms d'une liste de dispensateurs
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : Avril 2017
    /// </remarks>
    public class ObtenirNomPrenomListeDispensateursSorti : ParamSorti
    {

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirNomPrenomListeDispensateursSorti()
        {
            InfoDispensateurs = new List<NomPrenomDispSorti>();
        }

        #endregion

        #region Propriétés publiques

        /// <summary>
        /// Liste des dispensateurs
        /// </summary>
        public List<NomPrenomDispSorti> InfoDispensateurs { get; set; }

        #endregion

    }
}