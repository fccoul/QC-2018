using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre
{
    /// <summary> 
    ///  Classe de paramètres d'entrées pour le service du noyau « Modifier un avis de conformit ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Franck COULIBALY<br/>
    ///  Date   : Mai 2018
    /// </remarks>
    public class ModifierAvisConfEntre
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
        /// Code de région socio-sanitaire 
        /// </summary>
        /// <remarks></remarks>
        public string CodeRSS { get; set; }

        /// <summary>
        /// Date debut de l'avis de conformite
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateDebut { get; set; }

        /// <summary>
        /// Date debut de l'avis de conformite
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateFin { get; set; }
    }
}