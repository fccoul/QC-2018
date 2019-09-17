using RAMQ.ClasseBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre
{
    /// <summary> 
    ///  Classe de paramètres de sorti pour le service du noyau « Modifier un avis de conformité selon son statut ».
    /// </summary>
    /// <remarks>
    ///  Auteur : ranck COULIBALY<br/>
    ///  Date   : Mai 2018
    /// </remarks>
    public class ModifierAvisConformiteStatutSorti : ParametreSorti
    {
        /// <summary>
        /// Date et heure de l'occurence
        /// </summary>
        /// <remarks></remarks>
        public DateTime DateHeureOccurence { get; set; }
    }
}