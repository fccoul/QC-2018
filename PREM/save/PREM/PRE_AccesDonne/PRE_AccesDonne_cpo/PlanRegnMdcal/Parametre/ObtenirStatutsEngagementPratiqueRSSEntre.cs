using RAMQ.Attribut;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary> 
    ///  Classe de paramètres d'entrées pour le service du noyau « Obtenir la liste des statuts engagement pratique RSS  ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Mathys Leleu<br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    public class ObtenirStatutsEngagementPratiqueRSSEntre
    {
        /// <summary>
        /// Numéro séquentiel de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNoSeqStaEngagPrati", Direction = ParameterDirection.Input)]
        public long? NumeroSequentielStatutEngagement { get; set; }

        /// <summary>
        /// Numéro séquentiel de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNoSeqEngagPrati", Direction = ParameterDirection.Input)]
        public long? NumeroSequentielEngagement { get; set; }

        /// <summary>
        /// Code de raison de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pCodRaisStaEngag", Direction = ParameterDirection.Input)]
        public short? CodeRaisonEngagement { get; set; }

        /// <summary>
        /// Statue engagement territoire
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pStaEngagTerri", Direction = ParameterDirection.Input)]
        public string StatutEngagementTerritoire { get; set; }

        /// <summary>
        /// Date de début du statut de l'engagement territoire
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDDStaEngagTerri", Direction = ParameterDirection.Input)]
        public DateTime? DateDebutStatutEngagementTerritoire { get; set; }

        /// <summary>
        /// Date de fin du statut de l'engagement territoire
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDFStaEngagTerri", Direction = ParameterDirection.Input)]
        public DateTime? DateFinStatutEngagementTerritoire { get; set; }
    }
}