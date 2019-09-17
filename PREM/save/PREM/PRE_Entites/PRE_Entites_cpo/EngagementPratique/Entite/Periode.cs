using System;

namespace RAMQ.PRE.PRE_Entites_cpo.EngagementPratique.Entite
{

    /// <summary> 
    ///  Entité d'une période
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Novembre 2016
    /// </remarks>
    public class Periode
    {

        #region Propriétés publiques

        /// <summary>
        /// Date de début
        /// </summary>
        /// <returns></returns>
        public DateTime? DateDebut { get; set; }

        /// <summary>
        /// Date de fin
        /// </summary>
        /// <returns></returns>
        public DateTime? DateFin { get; set; }

        #endregion

    }
}