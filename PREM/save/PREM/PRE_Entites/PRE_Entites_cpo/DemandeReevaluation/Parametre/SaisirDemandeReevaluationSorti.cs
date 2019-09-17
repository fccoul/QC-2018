using RAMQ.ClasseBase;
using System;

namespace RAMQ.PRE.PRE_Entites_cpo.DemandeReevaluation.Parametre
{
    /// <summary> 
    /// Paramètre de sortie pour saisir les demandes de réévaluation
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Mars 2018
    /// </remarks>
    public class SaisirDemandeReevaluationSorti : ParamSorti
    {
        /// <summary>
        /// Date de début de réévaluation
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateDebutReelle { get; set; }

        /// <summary>
        /// Date de fin de réévaluation
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateFinReelle { get; set; }

    }
}