using RAMQ.Attribut;
using System;
using System.Collections.Generic;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary>
    /// Classe de paramètres d'entrées pour le service du noyau « ObtenirListeEngagEtAbsAvis »
    /// </summary>
    /// <remarks>
    /// Auteur: Florent Pollart
    /// </remarks>
	public class ObtenirListeEngagementsEtAbsencesAvisEntre
    {
        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNoSeqDisp", Direction = ParameterDirection.Input)]
        public long? NumeroSequentielDispensateur{ get; set; }

        /// <summary>
        /// Date de début
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDD", Direction = ParameterDirection.Input)]
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Date de fin
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pDatDF", Direction = ParameterDirection.Input)]
        public DateTime DateFin { get; set; }

        /// <summary>
        /// Type liste à retourner
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTypListe", Direction = ParameterDirection.Input)]
        public int? TypeListe { get; set; }
    }
}