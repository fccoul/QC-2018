using System;

namespace RAMQ.PRE.PRE_Entites_cpo.Pratique.Entite
{
    /// <summary> 
    ///  JoursFactDroitsAcquis
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois <br/>
    ///  Date   : Juillet 2017
    /// </remarks>
	public class JoursFactDroitsAcquis : JoursFactures
    {
        /// <summary>
        ///  Année PREM visée
        /// </summary>
        /// <remarks></remarks>
        public long? AnneePREM { get; set; }

        /// <summary>
        ///  Date de début de période
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DebutPeriode { get; set; }

        /// <summary>
        ///  Date de fin de période
        /// </summary>
        /// <remarks></remarks>
        public DateTime? FinPeriode { get; set; }

        /// <summary>
        ///  Date de début de l'avis
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DebutAvis { get; set; }

        /// <summary>
        ///  Date de fin de l'avis
        /// </summary>
        /// <remarks></remarks>
        public DateTime? FinAvis { get; set; }

        /// <summary>
        /// Regroupement administratif du lieu géographique de l'avis
        /// </summary>
        /// <remarks></remarks>
        public long? NumeroSeqRegrAdmnLGEOAvis { get; set; }

        /// <summary>
        /// Type du lieu géographique de l'avis
        /// </summary>
        /// <remarks></remarks>
        public string TypeLieuGeographique { get; set; }

        /// <summary>
        /// Code du lieu géographique de l'avis
        /// </summary>
        /// <remarks></remarks>
        public string CodeLieuGeographiqueAvis { get; set; }

        /// <summary>
        /// Code RSS de l'avis
        /// </summary>
        /// <remarks></remarks>
        public string CodeRSSAvis { get; set; }

        /// <summary>
        /// Nom du lieu géographique de l'avis
        /// </summary>
        /// <remarks></remarks>
        public string NomTerritoireAvis { get; set; }

        /// <summary>
        /// Pourcentage
        /// </summary>
        /// <remarks></remarks>
        public decimal Pourcentage { get; set; }

        /// <summary>
        /// Total des jours de pratique
        /// </summary>
        public decimal TotalJoursPratique { get; set; }
    }
}