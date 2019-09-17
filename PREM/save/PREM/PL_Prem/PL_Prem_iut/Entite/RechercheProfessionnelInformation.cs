using System;
using System.Collections.Generic;

namespace RAMQ.PRE.PL_Prem_iut.Entite
{
    /// <summary>
    /// Entité pour l'obtention des information d'un professionnel en entré
    /// </summary>
    public class RechercheProfessionnelInformation
    {
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public RechercheProfessionnelInformation()
        {
            MessageErreurs = new List<string>();
        }

        /// <summary>
        /// Nom à l'affichage
        /// </summary>
        public string NomAffichage { get; set; }

        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        public long? NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Numéro séquentiel d'individu
        /// </summary>
        public long? NumeroSequentielIndividu { get; set; }

        /// <summary>
        /// Message d'erreur
        /// </summary>
        public List<string> MessageErreurs { get; set; }

        /// <summary>
        /// Date de décès
        /// </summary>
        public DateTime? DateDeces { get; set; }

        /// <summary>
        /// Date de spécialité
        /// </summary>
        public DateTime? DateSpecialite { get; set; }
        
        /// <summary>
        /// Date d'obtention de permis
        /// </summary>
        public DateTime? DateObtentionPermis { get; set; }
    }
}