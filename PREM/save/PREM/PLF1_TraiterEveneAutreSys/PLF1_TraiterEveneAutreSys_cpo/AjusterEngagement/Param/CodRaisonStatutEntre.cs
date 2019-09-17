using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.AjusterEngagement.Param
{
    /// <summary>
    /// Class de paramètres des codes de raison de statuts
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class CodRaisonStatutEntre
    {
        /// <summary>
        /// Code raison statut pour l'avis de non conformité  - periode de non admissibilite / date de premère spcialité
        /// </summary>
        public string CodeRaisonStatutAvisConf { get; set; }

        /// <summary>
        /// Code raison statut - Reactivation pour l'avis de non conformité  - periode de non admissibilite / date de premère spcialité
        /// </summary>
        public string CodeRaisonStatutReactivationAvisConf { get; set; }

        /// <summary>
        /// Code raison statut pour Derogation(Fermeture)  - periode de non admissibilite / date de premère spcialité
        /// </summary>
        public string CodeRaisonStatutDerogation{ get; set; }

        /// <summary>
        /// Code raison statut pour Autorisation      
        /// </summary>
        public CodeRaisonStatutAutorisation CodeRaisonStatutAutorisation { get; set; }
    }

    /// <summary>
    /// Code raison statut pour Autorisation      
    /// </summary>
    public class CodeRaisonStatutAutorisation
    {
        /// <summary>
        /// Code raison statut pour Autorisation Fermeture  - periode de non admissibilite / date de premère spcialité      
        /// </summary>
        public string Fermeture {get;set;}
        /// <summary>
        /// Code raison statut pour Autorisation Annulation  - periode de non admissibilite / date de premère spcialité        
        /// </summary>
        public string Annulation {get;set;}
    }
    /// <summary>
    /// type d'operation de l'evenement
    /// </summary>
    public enum OperationEvt
    {
        OperationNonAdmissibilite,
        OperationPremièreSpecialite,
        OperationDeces
    }
    
}