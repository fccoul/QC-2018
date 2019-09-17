using System;
using RAMQ.Attribut;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite
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
        [ValeurEntite(ElementName = "CRE_COD_RSS")]
        public string CodeRss { get; set; }

        /// <summary>
        ///  Type de caracteristique pratique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "CRE_TYP_CAR_PRATI")]
        public string TypeCaracteristiquePratique { get; set; }

        /// <summary>
        /// Date de début de la caracteristique pratique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "CRE_DD_CAR_PRATI_REGN")]
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Date de création de la caracteristique pratique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "CRE_DC_OCC")]
        public DateTime DateCreation { get; set; }

        /// <summary>
        /// Date de fin de la caracteristique pratique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "CRE_DF_CAR_PRATI_REGN")]
        public DateTime? DateFin { get; set; }
    }
}