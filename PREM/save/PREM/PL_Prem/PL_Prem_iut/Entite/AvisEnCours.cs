using System;

namespace RAMQ.PRE.PL_Prem_iut.Entite
{
    /// <summary>
    /// Classe pour les avis en cours
    /// </summary>
    public class AvisEnCours
    {
        /// <summary>
        /// Date de début de pratique
        /// </summary>
        public DateTime? DateDebutPratique { get; set; }
        
        /// <summary>
        /// Id du territoire
        /// </summary>
        public string TerritoireId { get; set; }
        
        /// <summary>
        /// Texte du territoire
        /// </summary>
        public string TerritoireText { get; set; }
        
        /// <summary>
        /// Message d'avertissement
        /// </summary>
        public string MessageAvertissement { get; set; }
    }
}
