using System;
using System.Data;
using RAMQ.Attribut;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{

    /// <summary> 
    ///  Classe de paramètres d'entrées pour le service du noyau « Modifier la période d'un avis de conformité ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau<br/>
    ///  Date   : Novembre 2016
    /// </remarks>
    public class ModifierPeriodeAvisEntre
    {

        /// <summary>
        /// Numéro séquentiel de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqEngagement", Direction = ParameterDirection.Input)]
        public long NumeroSequentielEngagement { get; set; }

        /// <summary>
        /// Date de début actuelle de l'avis de conformité
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDateDebutEngagActuelle", Direction = ParameterDirection.Input)]
        public DateTime? DateDebutActuelle { get; set; }

        /// <summary>
        /// Date de fin actuelle de l'avis de conformité
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDateFinEngagActuelle", Direction = ParameterDirection.Input)]
        public DateTime? DateFinActuelle { get; set; }

        /// <summary>
        /// Nouvelle date de début de l'avis de conformité
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDateDebutEngagNouvelle", Direction = ParameterDirection.Input)]
        public DateTime? DateDebutNouvelle { get; set; }

        /// <summary>
        /// Nouvelle date de fin de l'avis de conformité
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDateFinEngagNouvelle", Direction = ParameterDirection.Input)]
        public DateTime? DateFinNouvelle { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui a modifié l'occurence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrIdentifiantMAJ", Direction = ParameterDirection.Input)]
        public string IdentifiantMAJ { get; set; }

        /// <summary>
        /// Code de raison du statut de la dérogation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrCodeRaisonStatutEngag", Direction = ParameterDirection.Input)]
        public string CodeRaisonStatut { get; set; }

    }
}