using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre
{
    /// <summary> 
    ///  Paramètres d'entrée  pour l'obtention de la liste des statuts engagement pratique RSS 
    /// </summary>
    /// <remarks>
    ///  Auteur : Franck COULIBALY <br/>
    ///  Date   : Juillet 2018
    /// </remarks>
    public class ObtenirStatutsEngagementPratiqueRSSEntre
    {
        /// <summary>
        /// Numéro séquentiel de l'engagement
        /// </summary>
        /// <remarks></remarks>        
        public long? NumeroSequentielStatutEngagement { get; set; }

        /// <summary>
        /// Numéro séquentiel de l'engagement
        /// </summary>
        /// <remarks></remarks>      
        public long? NumeroSequentielEngagement { get; set; }

        /// <summary>
        /// Code de raison de l'engagement
        /// </summary>
        /// <remarks></remarks>         
        public short? CodeRaisonEngagement { get; set; }

        /// <summary>
        /// Statue engagement territoire
        /// </summary>
        /// <remarks></remarks>        
        public string StatutEngagementTerritoire { get; set; }

        /// <summary>
        /// Date de début du statut de l'engagement territoire
        /// </summary>
        /// <remarks></remarks>        
        public DateTime? DateDebutStatutEngagementTerritoire { get; set; }

        /// <summary>
        /// Date de fin du statut de l'engagement territoire
        /// </summary>
        /// <remarks></remarks>        
        public DateTime? DateFinStatutEngagementTerritoire { get; set; }
    }
}