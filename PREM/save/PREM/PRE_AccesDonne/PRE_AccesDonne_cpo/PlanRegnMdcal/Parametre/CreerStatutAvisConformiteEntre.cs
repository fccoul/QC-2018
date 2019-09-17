using RAMQ.Attribut;
using System;
using System.Collections.Generic;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary> 
    ///  Classe de paramètres d'entrée pour le service du noyau « Créer un statut de l’engagement ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Mathys Leleu<br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    /// 
    public class CreerStatutAvisConformiteEntre
    {

        /// <summary>
        /// Numéro séquentiel de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqEngagement", Direction = ParameterDirection.Input)]
        public long NumeroSequentielEngagement { get; set; }

        /// <summary>
        /// Statut de l'engagement 
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrStatutEngag", Direction = ParameterDirection.Input)]
        public string StatutEngagement { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur créeant le statut
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrIdentifiantCreation", Direction = ParameterDirection.Input)]
        public string IdentifiantCreation { get; set; }

        /// <summary>
        /// Date de début du statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDateDebutStaEngag", Direction = ParameterDirection.Input)]
        public DateTime? DateDebutStatutEngagement { get; set; }

        /// <summary>
        /// Code de raison du statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrCodeRaisonStatut", Direction = ParameterDirection.Input)]
        public string CodeRaisonStatutEngagement { get; set; }

        /// <summary>
        /// Date de fin du statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDateFinStaEngag", Direction = ParameterDirection.Input)]
        public DateTime? DateFinStatutEngagement { get; set; }

    }
}
