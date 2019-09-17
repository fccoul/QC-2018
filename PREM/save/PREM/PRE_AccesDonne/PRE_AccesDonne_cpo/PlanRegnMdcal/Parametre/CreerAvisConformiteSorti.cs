using RAMQ.Attribut;
using RAMQ.ClasseBase;
using System;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{

    /// <summary> 
    ///  Classe de paramètres de sortie pour le service du noyau « Créer un avis de conformité ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau<br/>
    ///  Date   : Septembre 2016
    /// </remarks>
    public class CreerAvisConformiteSorti : ParamSorti
    {

        /// <summary>
        /// Numéro séquentiel de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqEngagement", Direction = ParameterDirection.Output)]
        public long NumeroSequentielEngagement { get; set; }

        /// <summary>
        /// Date et heure de l'occurence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDateHeureOccurence", Direction = ParameterDirection.Output)]
        public DateTime DateHeureOccurence { get; set; }

    }

}