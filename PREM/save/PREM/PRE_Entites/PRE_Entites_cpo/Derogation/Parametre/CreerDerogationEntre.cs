using System;

namespace RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre
{
    /// <summary> 
    ///  Paramètres d'entré pour la création d'une dérogation d'un professionnel de la santé.
    /// </summary>
    /// <remarks>
    ///  Auteur : Sébastien Bourdages <br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    public class CreerDerogationEntre
    {
        /// <summary>
        /// Numéro séquentiel du dispensateur.
        /// </summary>
        /// <remarks></remarks>
        public long NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Type de la dérogation.
        /// </summary>
        /// <remarks></remarks>
        public string Type { get; set; }

        /// <summary>
        /// Code de raison du statut de dérogation.
        /// </summary>
        /// <remarks></remarks>
        public int? CodeRaisonStatutDerogation { get; set; }

        /// <summary>
        /// Date de début de la dérogation.
        /// </summary>
        /// <remarks></remarks>
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui crée l'occurence.
        /// </summary>
        /// <remarks></remarks>
        public string IdentifiantCreation { get; set; }
    }
}