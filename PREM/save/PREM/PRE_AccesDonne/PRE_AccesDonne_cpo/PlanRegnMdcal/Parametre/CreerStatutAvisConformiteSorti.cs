using RAMQ.Attribut;
using RAMQ.ClasseBase;
using System;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary> 
    ///  Classe de paramètres de sortie pour le service du noyau « Créer un statut de l’engagement ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Mathys Leleu<br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    public class CreerStatutAvisConformiteSorti : ParamSorti
    {
        /// <summary>
        /// Numéro séquentiel du statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqStaEngag", Direction = ParameterDirection.Output)]
        public long NumeroSequentielStatutEngagement { get; set; }
        /// <summary>
        /// Date et heure de l’occurrence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDateHeureOccurence", Direction = ParameterDirection.Output)]
        public DateTime DateHeureOccurence { get; set; }
    }
}