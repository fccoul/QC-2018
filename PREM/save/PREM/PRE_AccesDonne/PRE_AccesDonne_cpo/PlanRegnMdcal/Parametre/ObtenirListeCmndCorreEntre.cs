using RAMQ.Attribut;
using System;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary> 
    ///  Classe de paramètres d'entrées pour le service du noyau « Obtenir la liste des commandes de correspondances ».
    /// </summary>
    /// <remarks>
    /// Auteur : Florent Pollart
    /// </remarks>
	public class ObtenirListeCmndCorreEntre
    {
        /// <summary>
        /// Date de début prévue d'envoie
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDateDebut", Direction = ParameterDirection.Input)]
        public DateTime? DateDebutPrevueEnvoie { get; set; }

        /// <summary>
        /// Date de fin prévue d'envoie
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDateFin", Direction = ParameterDirection.Input)]
        public DateTime? DateFinPrevueEnvoie { get; set; }
    }
}