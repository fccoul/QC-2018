using System;

namespace RAMQ.PRE.PRE_Entites_cpo.Pratique.Entite
{
    /// <summary> 
    ///  JoursFactDroitsAcquisDepassement
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Juillet 2017
    /// </remarks>
	public class JoursFactDroitsAcquisDepassement : JoursFactDroitsAcquis
    {
        /// <summary>
        /// Indicateur de respect RPPR
        /// </summary>
        /// <remarks></remarks>
        public string IndicateurRespectRPPR { get; set; }


        /// <summary>
        /// Code RSS de la facturation
        /// </summary>
        /// <remarks></remarks>
        public string CodeRSSfacturation { get; set; }

        /// <summary>
        /// Nom du territoire de la facturation
        /// </summary>
        /// <remarks></remarks>
        public string NomTerritoirefacturation { get; set; }
    }
}