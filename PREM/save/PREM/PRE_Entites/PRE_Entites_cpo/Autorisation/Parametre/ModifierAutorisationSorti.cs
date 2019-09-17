using RAMQ.ClasseBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PRE_Entites_cpo.Autorisation.Parametre
{  /// <summary> 
   ///  Paramètres de sortie pour la modification d'une Autorisation d'un professionnel de la santé
   /// </summary>
   /// <remarks>
   ///  Auteur : Franck COULIBALY <br/>
   ///  Date   : Mai 2018
   /// </remarks>
    public class ModifierAutorisationSorti : ParametreSorti
    {
        /// <summary>
        /// Nouveau numéro séquentiel de l'autorisation
        /// </summary>
        /// <remarks></remarks>
        public long NouveauNumeroSequentiel { get; set; }
    }
}