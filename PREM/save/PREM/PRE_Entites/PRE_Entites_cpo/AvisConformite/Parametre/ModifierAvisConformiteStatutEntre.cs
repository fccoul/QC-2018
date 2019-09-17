using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre
{
    /// <summary> 
    ///  Classe de paramètres d'entrées pour le service du noyau « Modifier un avis de conformité selon son statut ».
    /// </summary>
    /// <remarks>
    ///  Auteur : ranck COULIBALY<br/>
    ///  Date   : Mai 2018
    /// </remarks>
    public class ModifierAvisConformiteStatutEntre
    {
        /// <summary>
        /// Numéro séquentiel de l'engagement
        /// </summary>
        /// <remarks></remarks>        
        public long NumeroSequentielEngagement { get; set; }

        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>        
        public long? NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui a modifié l'occurence
        /// </summary>
        /// <remarks></remarks>        
        public string IdentifiantMAJ { get; set; }

        /// <summary>
        /// Type de lieu géographique
        /// </summary>
        /// <remarks></remarks>       
        public string TypeLieuGeographique { get; set; }

        /// <summary>
        /// Code de lieu géographique
        /// </summary>
        /// <remarks></remarks>        
        public string CodeLieuGeographique { get; set; }

        /// <summary>
        /// Numéro séquentiel de regroupement administratif des lieux géographiques
        /// </summary>
        /// <remarks></remarks>      
        public long? NumeroSequentielRegroupement { get; set; }

        /// <summary>
        /// Indicateur d'inactivation d'occurrence
        /// </summary>
        /// <remarks></remarks>      
        public string IndicateurInactivationOccurence { get; set; }
    }
}