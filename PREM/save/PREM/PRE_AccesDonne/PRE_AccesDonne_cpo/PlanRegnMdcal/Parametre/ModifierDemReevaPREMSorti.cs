using RAMQ.Attribut;
using RAMQ.ClasseBase;
using System;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary> 
    ///  Classe de paramètres de sortie pour le service du noyau « ModifierDemReevaPREM ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois<br/>
    ///  Date   : Mars 2018
    /// </remarks>
    public class ModifierDemReevaPREMSorti : ParamSorti
    {
        
        /// <summary>
        /// Date et heure de M-à-J de l’occurrence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDHMajOccurence", Direction = ParameterDirection.Output)]
        public DateTime DateHeureMAJOccurence { get; set; }
    }
}