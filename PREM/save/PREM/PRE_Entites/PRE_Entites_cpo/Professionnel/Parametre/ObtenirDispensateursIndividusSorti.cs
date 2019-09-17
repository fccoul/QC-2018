using System.Collections.Generic;
using RAMQ.ClasseBase;

namespace RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre
{

    /// <summary> 
    ///  Paramètre de sortie pour obtenir les informations sur la relation dispensateur individu
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Octobre 2016
    /// </remarks>
    public class ObtenirDispensateursIndividusSorti : ParamSorti
    {

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirDispensateursIndividusSorti()
        {
            DispensateursIndividus = new List<ObtenirDispensateurIndividuSorti>();
        }

        #endregion

        #region Propriétés publiques

        /// <summary>
        /// Listes des dispensateurs
        /// </summary>
        public List<ObtenirDispensateurIndividuSorti> DispensateursIndividus { get; set; }

        #endregion

    }
}