using RAMQ.Attribut;
using RAMQ.ClasseBase;
using System;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary> 
    ///  Classe de paramètres de sortie pour le service du noyau « Modifier un statut de l'engagement ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Mathys Leleu<br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    public class ModifierStatutEngagementSorti : ParamSorti
    {
        /// <summary>
        /// Date et heure de l'occurence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDateHeureOccurence", Direction = ParameterDirection.Output)]
        public DateTime DateHeureOccurence { get; set; }

        /// <summary>
        /// Numéro séquentiel du statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNouveauNoSeqStatutEngag", Direction = ParameterDirection.Output)]
        public long? NumeroSequentielStatutEngagement { get; set; }
    }
}