using System;

namespace RAMQ.PRE.PRE_Entites_cpo.Pratique.Entite
{
    /// <summary> 
    ///  Pratique Région
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : Février 2017
    /// </remarks>
	public class PratiqueRegion
    {
        /// <summary>
        ///  Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        public long NoSequentielDisp { get; set; }

        /// <summary>
        /// Nombre de jours PREM/DPNAG
        /// </summary>
        /// <remarks></remarks>
        public decimal NbJoursPremDpnag { get; set; }

        /// <summary>
        /// Nombre de jours PREM
        /// </summary>
        /// <remarks></remarks>
        public decimal NbJoursPrem { get; set; }

        /// <summary>
        /// Nombre de jours DPNAG
        /// </summary>
        /// <remarks></remarks>
        public decimal NbJoursDpnag { get; set; }

        /// <summary>
        /// Nombre de jours IVN
        /// </summary>
        /// <remarks></remarks>
        public decimal NbJoursIvn { get; set; }

        /// <summary>
        /// Nombre de jours localité
        /// </summary>
        /// <remarks></remarks>
        public decimal NbJoursLoc { get; set; }

        /// <summary>
        /// Nombre de jours Hors-Quebec
        /// </summary>
        /// <remarks></remarks>
        public decimal NbJoursHQ { get; set; }

        /// <summary>
        /// Nombre de jours total
        /// </summary>
        /// <remarks></remarks>
        public decimal NbJoursTotal { get; set; }

        /// <summary>
        /// Année de service
        /// </summary>
        /// <remarks></remarks>
        public string Annee { get; set; }

        /// <summary>
        /// Mois de service
        /// </summary>
        /// <remarks></remarks>
        public string Mois { get; set; }

        /// <summary>
        /// Le code de région socio-sanitaire
        /// </summary>
        /// <remarks></remarks>
        public string CodeRSS { get; set; }
    }
}