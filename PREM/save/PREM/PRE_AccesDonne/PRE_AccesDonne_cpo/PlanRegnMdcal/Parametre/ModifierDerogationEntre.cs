using System;
using System.Data;
using RAMQ.Attribut;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{

    /// <summary> 
    ///  Classe de paramètres d'entrées pour le service du noyau « Modifier une dérogation d'un professionnel de la santé ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau<br/>
    ///  Date   : Novembre 2016
    /// </remarks>
    public class ModifierDerogationEntre
    {

        /// <summary>
        /// Numéro séquentiel de la dérogation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqDerogation", Direction = ParameterDirection.Input)]
        public long NumeroSequentiel { get; set; }

        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqDispensateur", Direction = ParameterDirection.Input)]
        public long? NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Type de la dérogation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrTypeDerogation", Direction = ParameterDirection.Input)]
        public string Type { get; set; }

        /// <summary>
        /// Date de renouvellement de la dérogation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDateRenouvellement", Direction = ParameterDirection.Input)]
        public DateTime? DateRenouvellement { get; set; }

        /// <summary>
        /// Date de début de la dérogation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDateDebutDerogation", Direction = ParameterDirection.Input)]
        public DateTime? DateDebut { get; set; }

        /// <summary>
        /// Date de fin de la dérogation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDateFinDerogation", Direction = ParameterDirection.Input)]
        public DateTime? DateFin { get; set; }

        /// <summary>
        /// Statut de la dérogation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrStatutDerogation", Direction = ParameterDirection.Input)]
        public string Statut { get; set; }

        /// <summary>
        /// Code de raison du statut de la dérogation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrCodeRaisonStatut", Direction = ParameterDirection.Input)]
        public string CodeRaisonStatut { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui a modifié l'occurence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrIdentifiantMAJ", Direction = ParameterDirection.Input)]
        public string IdentifiantMAJ { get; set; }

    }
}