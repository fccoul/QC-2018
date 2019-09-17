using RAMQ.ClasseBase;
using System;

namespace RAMQ.PRE.PRE_Entites_cpo.DemandeReevaluation.Parametre
{
    /// <summary> 
    /// Paramètre de sortie pour la modification des demandes de réévaluation
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Mars 2018
    /// </remarks>
    public class ModifierDemandeReevaluationSorti : ParamSorti
    {

        /// <summary>
        /// Date de mise à jour de l'occurence
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateMAJOcc { get; set; }

    }
}