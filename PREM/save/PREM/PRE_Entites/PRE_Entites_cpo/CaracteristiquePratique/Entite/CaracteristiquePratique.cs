using System;

namespace RAMQ.PRE.PRE_Entites_cpo.CaracteristiquePratique.Entite
{
    /// <summary> 
    ///  Caractéristique Pratique
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : Juin 2017
    /// </remarks>
    public class CaracteristiquePratique
    {
        /// <summary>
        /// Code RSS
        /// </summary>
        /// <remarks></remarks>
        public string CodeRss { get; set; }

        /// <summary>
        ///  Type de caracteristique pratique
        /// </summary>
        /// <remarks></remarks>
        public string TypeCaracteristiquePratique { get; set; }

        /// <summary>
        /// Date de début de la caracteristique pratique
        /// </summary>
        /// <remarks></remarks>
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Date de création de la caracteristique pratique
        /// </summary>
        /// <remarks></remarks>
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// Date de fin de la caracteristique pratique
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateFin { get; set; }
    }
}