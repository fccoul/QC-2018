using RAMQ.Attribut;
using RAMQ.ClasseBase;
using System;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary> 
    ///  Classe de paramètres de sortie pour le service du noyau « CreerDemReevaPREM ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois<br/>
    ///  Date   : Mars 2018
    /// </remarks>
    public class CreerDemReevaPREMSorti : ParamSorti
    {
        
        /// <summary>
        /// Date et heure de création de l’occurrence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDHOcc", Direction = ParameterDirection.Output)]
        public DateTime DateHeureCreationOccurence { get; set; }

        /// <summary>
        /// Numéro de séquence de la demande de réévaluation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqDemReeva", Direction = ParameterDirection.Output)]
        public long NoSeqDemReeva { get; set; }
    }
}