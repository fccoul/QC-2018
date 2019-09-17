using System.Collections.Generic;

namespace RAMQ.PRE.PRE_Entites_cpo.EngagementPratique.Entite
{

    /// <summary> 
    ///  Entité d'un engagement de pratique
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Novembre 2016
    /// </remarks>
    public class EngagementPratique
    {


        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public EngagementPratique()
        {
            Historiques = new List<Historique>();
        }
        #endregion

        #region Propriétés publiques

        /// <summary>
        /// Numéro de séquence de l'engagement (Dérogation, Avis de conformité, Absence d'avis et autorisation)
        /// </summary>
        public long? NumeroSequence { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        /// <returns></returns>
        public string Description { get; set; }

        /// <summary>
        /// Code de la région
        /// </summary>
        /// <returns></returns>
        public string CodeRegion { get; set; }

        /// <summary>
        /// Nom du territoire
        /// </summary>
        /// <returns></returns>
        public InformationTerritoire Territoire { get; set; }

        /// <summary>
        /// Période
        /// </summary>
        /// <returns></returns>
        public Periode Periode { get; set; }

        /// <summary>
        /// Liste d'historique de l'engagement
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Historique> Historiques { get; set; }

        /// <summary>
        /// Type de dérogation ou d'autorisation
        /// </summary>
        public string Type { get; set; }

        #endregion

    }

}