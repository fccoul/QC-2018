using RAMQ.ClasseBase;
using System;

namespace RAMQ.PRE.PRE_Entites_cpo.DecisionAvisConformite.Parametre
{
    /// <summary> 
    /// Paramètre de sortie pour traiter la création d'une dérogation d'avis de conformité.
    /// </summary>
    /// <remarks>
    ///  Auteur : Sébastien Bourdages <br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    public class TraiterDerogationAvisConformiteSorti : ParamSorti
    {
        /// <summary>
        /// Nom complet avec numéro de pratique
        /// </summary>
        public string NomCompletNumeroPratique { get; set; }

        /// <summary>
        /// Description du type de dérogation.
        /// </summary>
        public string DescriptionTypeDerogation { get; set; }

        /// <summary>
        /// Date et heure de création de l'occurence.
        /// </summary>
        public DateTime DateHeureCreationOccurence { get; set; }

        /// <summary>
        /// Date de début.
        /// </summary>
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Question posé
        /// </summary>
        public string QuestionPose { get; set; }

        /// <summary>
        /// Message d'engagement fermé s'il y a lieu (soit Dérogation ou Avis de conformité).
        /// </summary>
        public string MessageFermetureEngagement { get; set; }
    }
}