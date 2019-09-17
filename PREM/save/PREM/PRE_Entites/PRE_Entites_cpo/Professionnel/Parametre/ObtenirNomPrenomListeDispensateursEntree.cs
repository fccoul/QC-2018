using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Entite;
using System;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre
{

    /// <summary> 
    ///  Paramètre d'entrée pour obtenir les noms, prenoms d'une liste de dispensateurs
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : Juin 2017
    /// </remarks>
    public class ObtenirNomPrenomListeDispensateursEntree
    {
        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirNomPrenomListeDispensateursEntree()
        {
            InfoDispensateurs = new List<NomPrenomDispEntre>();
        }

        #endregion

        #region Propriétés publiques

        /// <summary>
        /// Liste des dispensateurs
        /// </summary>
        public List<NomPrenomDispEntre> InfoDispensateurs { get; set; }

        #endregion
    }
}