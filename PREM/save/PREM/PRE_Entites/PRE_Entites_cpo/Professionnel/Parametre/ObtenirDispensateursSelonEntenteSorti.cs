using System.Collections.Generic;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Entite;
using RAMQ.ClasseBase;

namespace RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre
{
    /// <summary> 
    ///  Paramètre de sorti pour obtenir les dispensateurs selon un numéro d'entente
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : Avril 2017
    /// </remarks>
    public class ObtenirDispensateursSelonEntenteSorti : ParamSorti
    {

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirDispensateursSelonEntenteSorti()
        {
            Dispensateurs = new List<ProfessionnelNumEntente>();
        }

        #endregion

        #region Propriétés publiques

        /// <summary>
        /// Liste des dispensateurs
        /// </summary>
        public List<ProfessionnelNumEntente> Dispensateurs { get; set; }

        #endregion
    }
}