﻿using RAMQ.ClasseBase;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary> 
    ///  Classe de paramètres de sortie pour le service du noyau « Obtenir les jours facturés de la pratique PREM par région ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart<br/>
    ///  Date   : Février 2017
    /// </remarks>
	public class ObtenirVueJoursFactPratiRssSorti : ParamSorti
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirVueJoursFactPratiRssSorti()
        {
            ListeJoursFactParRss = new List<JoursFactParRSS>();
        }

        /// <summary>
        /// Liste de journées facturées des professionnels de la santé par RSS
        /// </summary>
        /// <remarks></remarks>
        public IEnumerable<JoursFactParRSS> ListeJoursFactParRss { get; set; }
    }
}