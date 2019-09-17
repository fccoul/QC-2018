using System;
using RAMQ.ClasseBase;

namespace RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre
{

    /// <summary> 
    /// Paramètre de sortie pour le traitement des avis de conformité
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : 2016-09-21
    /// </remarks>
    public class TraiterAvisConformiteSorti : ParamSorti
    {

        /// <summary>
        /// Nom complet avec numéro de pratique
        /// </summary>
        public string NomCompletNumeroPratique { get; set; }

        /// <summary>
        /// Date de création
        /// </summary>
        public DateTime? DateCreation { get; set; }

        /// <summary>
        /// Nom du territoire
        /// </summary>
        public string NomTerritoire { get; set; }

        /// <summary>
        /// Question posé
        /// </summary>
        public string QuestionPose { get; set; }

    }

}