using RAMQ.ClasseBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre
{
    /// <summary> 
    ///  Paramètres de sortie pour la modification de la raison de fermeture du statut de l'engagement
    /// </summary>
    /// <remarks>
    ///  Auteur : Franck COULIBALY <br/>
    ///  Date   : Avril 2018
    /// </remarks>
	public class ModifierRaisFermStatutEngagSorti : ParametreSorti
    {
        /// <summary>
        /// Date et heure de l'occurence
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateHeureOccurence { get; set; }
    }
}