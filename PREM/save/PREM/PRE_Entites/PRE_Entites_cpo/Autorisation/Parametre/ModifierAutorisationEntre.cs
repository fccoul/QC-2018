using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PRE_Entites_cpo.Autorisation.Parametre
{
    /// <summary> 
    ///  Paramètres d'entrée pour la modification d'une autorisation d'un professionnel de la santé
    /// </summary>
    /// <remarks>
    ///  Auteur : Franck COULIBALY<br/>
    ///  Date   : Mai 2018
    /// </remarks>
    public class ModifierAutorisationEntre
    {
        /// <summary>
        /// Numéro séquantiel de l'autorisation
        /// </summary>
        /// <remarks></remarks>
        public long NumeroSequentiel { get; set; }

        /// <summary>
        /// Numéro séquantiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        public long? NumeroSequentielDispensateur { get; set; }

        /// <summary>
        ///  Type de lieu géographique
        /// </summary>
        /// <remarks></remarks>
        public string TypeLgeo { get; set; }

        /// <summary>
        /// Code de lieu géographique
        /// </summary>
        /// <remarks></remarks>
        public string CodeLgeo { get; set; }

        /// <summary>
        /// Numero de sequence de regroupement administratif de lieu géographique
        /// </summary>
        /// <remarks></remarks>
        public long? NumeroSeqRegrAdmnLgeo { get; set; }


        /// <summary>
        /// Type de l'autorisation
        /// </summary>
        /// <remarks></remarks>
        public string TypeAutor { get; set; }

        /// <summary>
        /// Date debut de l'autorisation
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateDebut { get; set; }

        /// <summary>
        /// Date de fin de l'autorisation
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateFin { get; set; }

        /// <summary>
        /// Code qui identifie la région socio-sanitaire
        /// </summary>
        /// <remarks></remarks>
        public string CodRss { get; set; }

        /// <summary>
        /// Code de raison du statut de l'autorisation
        /// </summary>
        /// <remarks></remarks>
        public string CodeRaisonStatut { get; set; }

        /// <summary>
        /// Identifiant de la MAJ
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public string IdentifiantMAJ { get; set; }
    }
}