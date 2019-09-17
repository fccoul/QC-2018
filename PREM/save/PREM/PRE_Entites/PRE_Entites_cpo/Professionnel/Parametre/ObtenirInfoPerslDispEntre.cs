using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Entite;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre
{
    /// <summary>
    ///  Paramètres d'entrée pour l'obtention des informations personnelles d'un dispensateur
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class ObtenirInfoPerslDispEntre
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirInfoPerslDispEntre()
        {
            NumerosEtClassesDispensateurs = new List<NumeroEtClasseDisp>();
        }

        /// <summary>
        /// Liste des numeros et classes des dispensateurs
        /// </summary>
        public List<NumeroEtClasseDisp> NumerosEtClassesDispensateurs { get; set; }

        /// <summary>
        /// Nom du Dispensateur
        /// </summary>
        public string NomDispensateur { get; set; }

        /// <summary>
        /// Prenom du Dispensateur
        /// </summary>
        public string PrenomDispensateur { get; set; }
    }
}