using RAMQ.ClasseBase;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Entite;
using System;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre
{
    /// <summary>
    /// Paramètres de sortie pour l'obtention des informations personnelles d'un ou plusieurs dispensateur(s)
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class ObtenirInfoPerslDispSorti : ParamSorti
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirInfoPerslDispSorti()
        {
            InformationsPersonnellesDisp = new List<InfoPersonnelleslDisp>();
        }

        /// <summary>
        /// Liste des informations personnelles des dispensateurs
        /// </summary>
        public List<InfoPersonnelleslDisp> InformationsPersonnellesDisp { get; set; }
    }
}