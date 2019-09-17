using RAMQ.ClasseBase;
using System;

namespace RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre
{

    /// <summary> 
    /// Paramètre de sortie pour la modification d'une période d'un avis de conformité
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau<br/>
    ///  Date   : Novembre 2016
    /// </remarks>
    public class ModifierPeriodeAvisSorti : ParamSorti
    {

        /// <summary>
        /// Date et heure de l'occurence
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateHeureOccurence { get; set; }

    }

}