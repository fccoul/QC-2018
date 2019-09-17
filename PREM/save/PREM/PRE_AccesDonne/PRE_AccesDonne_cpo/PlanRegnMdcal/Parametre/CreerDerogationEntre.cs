using RAMQ.Attribut;
using System;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary> 
    ///  Classe de paramètres d'entrées pour le service du noyau « Créer une dérogation ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Sébastien Bourdages<br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    public class CreerDerogationEntre
    {
        /// <summary>
        /// Numéro séquentiel du dispensateur.
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqDispensateur", Direction = ParameterDirection.Input)]
        public long NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Type de la dérogation.
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrTypeDerogation", Direction = ParameterDirection.Input)]
        public string Type { get; set; }

        /// <summary>
        /// Code de raison du statut de dérogation.
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrCodRaisStaDerog", Direction = ParameterDirection.Input)]
        public int? CodeRaisonStatutDerogation { get; set; }

        /// <summary>
        /// Date de début de la dérogation.
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDebutDerogation", Direction = ParameterDirection.Input)]
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui crée l'occurence.
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrIdentifiantCreation", Direction = ParameterDirection.Input)]
        public string IdentifiantCreation { get; set; }
    }
}