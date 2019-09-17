using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.AjusterEngagement.Param
{
    /// <summary>
    /// Paramètres d'entrée de la méthode d'envoi de courriel
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class ContenuCourlEntre
    {
        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        public long NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Numéro du dispensateur 
        /// </summary>
        public long NumeroDispensateur { get; set; }

        /// <summary>
        /// Date de début de la non-participation 
        /// </summary>
        public DateTime DatDebNonPartn { get; set; }

        /// <summary>
        /// Date de début de première spécialité 
        /// </summary>
        public DateTime DateDebPremSpec { get; set; }

        /// <summary>
        /// Date de décès 
        /// </summary>
        public DateTime DateDeces { get; set; }

        /// <summary>
        /// Nom
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prenom
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Numéro séquentiel de l’individu 
        /// </summary>
        public long NumeroSequentielIndividu{ get; set; }

       
            
        /// <summary>
        /// le statuts de la derogation
        /// </summary>
        public bool? PlusieurStatutDerogation
        {
            get;set;
        }

        /// <summary>
        /// type de l'evenement
        /// </summary>
        public OperationEvt? Evt { get; set; }

    }
}