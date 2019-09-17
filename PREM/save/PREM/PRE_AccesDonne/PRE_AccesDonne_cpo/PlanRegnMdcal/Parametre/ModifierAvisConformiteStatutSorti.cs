using RAMQ.Attribut;
using RAMQ.ClasseBase;
using System;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{

    /// <summary> 
    ///  Classe de paramètres de sortie pour le service du noyau « Modifier un avis de conformité selon son statut ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau<br/>
    ///  Date   : Septembre 2016
    /// </remarks>
    public class ModifierAvisConformiteStatutSorti : ParamSorti
    {

        /// <summary>
        /// Date et heure de l'occurence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDateHeureMajOccurence", Direction = ParameterDirection.Output)]
        public DateTime DateHeureOccurence { get; set; }

    }

}