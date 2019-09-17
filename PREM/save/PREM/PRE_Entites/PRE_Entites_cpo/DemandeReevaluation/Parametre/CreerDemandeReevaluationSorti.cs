using RAMQ.ClasseBase;
using System;

namespace RAMQ.PRE.PRE_Entites_cpo.DemandeReevaluation.Parametre
{
    /// <summary> 
    /// Paramètre de sortie pour la création des demandes de réévaluation
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Mars 2018
    /// </remarks>
    public class CreerDemandeReevaluationSorti : ParamSorti
    {
        /// <summary>
        /// Numéro de séquence de la demande
        /// </summary>
        /// <remarks></remarks>
        public long? NoSeqDemReeva { get; set; }

        /// <summary>
        /// Date de création de l'occurence
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateOcc { get; set; }

    }
}