using RAMQ.ClasseBase;
using System;

namespace RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre
{

    /// <summary> 
    /// Paramètre de sortie pour la validation d'avis et dérogations en cours
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Décembre 2016
    /// </remarks>
    public class ValiderAvisDerogationEnCoursSorti : ParamSorti
    {

        /// <summary>
        /// Message d'avertissement
        /// </summary>
        public string MessageAvertissement { get; set; }

        /// <summary>
        /// Date de début de pratique
        /// </summary>
        public DateTime? DateDebutPratique { get; set; }

        /// <summary>
        /// ID du territoire
        /// </summary>
        public string TerritoireId { get; set; }

        /// <summary>
        /// Nom du territoire
        /// </summary>
        public string TerritoireNom { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool AvisEnregistrer { get; set;}

        /// <summary>
        /// Numéro séquentiel de l'engagement
        /// </summary>
        public long? NumeroSequentielEngagement { get; set; }

        /// <summary>
        /// Numéro séquentiel du statut de l'engagement
        /// </summary>
        public long? NumeroSequentielStatut { get; set; }
    }

}