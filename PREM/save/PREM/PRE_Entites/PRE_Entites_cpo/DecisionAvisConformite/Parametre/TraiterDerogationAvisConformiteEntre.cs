using System;

namespace RAMQ.PRE.PRE_Entites_cpo.DecisionAvisConformite.Parametre
{
    /// <summary> 
    /// Paramètre d'entré pour traiter la création d'une dérogation d'avis de conformité.
    /// </summary>
    /// <remarks>
    ///  Auteur : Sébastien Bourdages <br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    public class TraiterDerogationAvisConformiteEntre
    {
        /// <summary>
        /// Numéro de pratique
        /// </summary>
        public long NumeroPratique { get; set; }
        
        /// <summary>
        /// Date de début de la dérogation.
        /// </summary>
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Type de la dérogation.
        /// </summary>
        public string TypeDerogation { get; set; }

        /// <summary>
        /// TODO SEB
        /// </summary>
        public bool Continuer { get; set; }

        /// <summary>
        /// TODO SEB
        /// </summary>
        public string QuestionPose { get; set; }
    }
}