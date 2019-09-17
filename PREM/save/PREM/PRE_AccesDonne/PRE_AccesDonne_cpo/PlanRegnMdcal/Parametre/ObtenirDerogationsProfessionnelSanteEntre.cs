using System;
using System.Data;
using RAMQ.Attribut;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{

    /// <summary> 
    ///  Classe de paramètres d'entré pour le service du noyau « Obtenir la liste des dérogations d’un professionnel de la santé ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier<br/>
    ///  Date   : Octobre 2016
    /// </remarks>
    public class ObtenirDerogationsProfessionnelSanteEntre
    {

        /// <summary>
        /// Numéro séquantiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNumeroSequentielDisp", Direction = ParameterDirection.Input)]
        public long NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Date de recherche
        /// </summary>
        /// <remarks>Optionnel</remarks>
        [ValeurEntite(ElementName = "pDatDateRecherche", Direction = ParameterDirection.Input)]
        public DateTime? DateRecherche { get; set; }

        /// <summary>
        /// Indicateur d'une dérogation inactivé
        /// </summary>
        /// <remarks>Optionnel</remarks>
        [ValeurEntite(ElementName = "pVchrIndicateurDerogInactive", Direction = ParameterDirection.Input)]        
        public string IndicateurDerogationInactive { get; set; }

        /// <summary>
        /// Tri
        /// </summary>
        /// <remarks>Optionnel</remarks>
        [ValeurEntite(ElementName = "pVchrTri", Direction = ParameterDirection.Input)]
        public string Tri { get; set; }

        /// <summary>
        /// Date de début
        /// </summary>
        /// <remarks>Optionnel</remarks>
        [ValeurEntite(ElementName = "pDatDateDebut", Direction = ParameterDirection.Input)]
        public DateTime? DateDebut { get; set; }

        /// <summary>
        /// Date de fin
        /// </summary>
        /// <remarks>Optionnel</remarks>
        [ValeurEntite(ElementName = "pDatDateFin", Direction = ParameterDirection.Input)]
        public DateTime? DateFin { get; set; }

    }

}