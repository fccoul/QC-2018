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
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class ModifierRaisFermStatutEngagEntre 
    {
        /// <summary>
        /// Numéro séquentiel du statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNoSeqStatut", Direction = ParameterDirection.Input)]
        public long NumeroSequentielStatutEngagement { get; set; }


        /// <summary>
        /// Identifiant de l'utilisateur qui a nis à jour l'occurence
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrIdentifiantMAJ", Direction = ParameterDirection.Input)]

        public string IdentifiantMAJ { get; set; }
        /// <summary>
        /// Code de raison du statut de l'engagement
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pVchrCodeRaisonStatut", Direction = ParameterDirection.Input)]
        public string CodeRaisonStatut { get; set; }



    }
}