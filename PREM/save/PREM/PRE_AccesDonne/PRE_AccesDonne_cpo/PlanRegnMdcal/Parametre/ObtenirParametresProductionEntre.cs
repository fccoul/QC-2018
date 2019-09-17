using System;
using System.Data;
using RAMQ.Attribut;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    /// Classe de paramètres d'entrées pour le service du noyau « Obtenir une liste de paramètres de production ».
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public class ObtenirParametresProductionEntre
    {
        /// <summary>
        /// Liste de nom de paramètres
        /// </summary>
        [ValeurEntite(ElementName = "pTblNomParamProd", Direction = ParameterDirection.Input)]
        public List<string> NomsParametres { get; set; }

    }
}