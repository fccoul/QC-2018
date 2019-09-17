using RAMQ.Attribut;
using RAMQ.ClasseBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary> 
    ///  Classe de paramètres de sortie pour le service du noyau « Modifier  un avis de conformité  ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Franck COULIBALY <br/>
    ///  Date   : Mai 2018
    /// </remarks>
    public class ModifierAvisConformiteSorti: ParametreSorti
    {
        /// <summary>
        /// Date et heure de l'occurence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDateHeureOccurence", Direction = ParameterDirection.Output)]
        public DateTime DateHeureOccurence { get; set; }
    }
}