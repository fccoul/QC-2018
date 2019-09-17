using RAMQ.Attribut;
using RAMQ.ClasseBase;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite;
using System.Collections.Generic;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary> 
    ///  Classe de paramètres de sortie pour le service du noyau « Obtenir les jours facturés de la pratique PREM par territoire ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart<br/>
    ///  Date   : Février 2017
    /// </remarks>
	public class ObtenirJoursFactPratiTerriSorti : ParamSorti
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirJoursFactPratiTerriSorti()
        {
            ListeJourFactProfsRSS = new List<PratiqueTerritoire>();
        }

        /// <summary>
        /// Liste de journées facturées des professionnels de la santé par RSS
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pCurListeJourFactProfsRSS", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.RefCursor)]
        public List<PratiqueTerritoire> ListeJourFactProfsRSS { get; set; }
    }
}