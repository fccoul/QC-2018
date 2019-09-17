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
    ///  Classe de paramètres de sortie pour le service du noyau « Modifier une Autorisation d'un professionnel de la santé ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Franck COULIBALY<br/>
    ///  Date   : Mai 2018
    /// </remarks>
	public class ModifierAutorisationSorti : ParametreSorti

    //public class ModifierAutorisationSorti : ParamSorti
    {
        /// <summary>
        /// Nouveau numéro séquentiel de l'autorisation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNouveauNoSeqAutorisation", Direction = ParameterDirection.Output)]
        public long NouveauNumeroSequentiel { get; set; }
    }
}