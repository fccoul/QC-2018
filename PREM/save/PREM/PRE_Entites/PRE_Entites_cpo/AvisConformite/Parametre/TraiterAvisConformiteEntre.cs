using System;

namespace RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre
{
    /// <summary> 
    /// Paramètre d'entrée pour le traitement des avis de conformité
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : 2016-09-21
    /// </remarks>
    public class TraiterAvisConformiteEntre
    {

        /// <summary>
        /// Numéro de pratique
        /// </summary>
        public long? NumeroPratique { get; set; }
        
        /// <summary>
        /// Date de début
        /// </summary>
        public DateTime DateDebut { get; set; }
        
        /// <summary>
        /// Date prévue
        /// </summary>
        public DateTime DatePrevue { get; set; }

        /// <summary>
        /// Territoire
        /// </summary>
        public string Territoire { get; set; }

        /// <summary>
        /// Code de région socio-sanitaire
        /// </summary>
        public string CodeRSS { get; set; }

        /// <summary>
        /// Continuer (lors d'une validation avec question)
        /// </summary>
        public bool Continuer { get; set; }

        /// <summary>
        /// Type d'action
        /// </summary>
        public Enumerations.TypeTraitementAvisConformite TypeAction { get; set; }

        /// <summary>
        /// Question posé
        /// </summary>
        public string QuestionPose { get; set; }

        /// <summary>
        /// Numéro séquentiel de l'avis
        /// </summary>
        public long? NumeroSequentielAvis { get; set; }

        /// <summary>
        /// Numéro séquentiel de du statut
        /// </summary>
        public long? NumeroSequentielStatut { get; set; }

        /// <summary>
        /// Indicateur pour si la date de l'avis a été modifié
        /// </summary>
        public bool DateModifier { get; set; }

        /// <summary>
        /// Indicateur pour si le territoire de l'avis a été modifié
        /// </summary>
        public bool TerritoireModifier { get; set; }
    }
}
