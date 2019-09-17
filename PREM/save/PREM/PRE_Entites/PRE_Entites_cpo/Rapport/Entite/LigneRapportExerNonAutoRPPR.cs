using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PRE_Entites_cpo.Rapport.Entite
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
    [DataContract]
    public class LigneRapportExerNonAutoRPPR : ILigneRapport
    {
        /// <summary>
        /// Numéro de pratique du dispensateur (classe + no_disp)
        /// </summary>
        [DataMember(Name = "Numéro de pratique")]
        public string NumeroPratique { get; set; }

        /// <summary>
        /// Nom + prénom du dispensateur
        /// </summary>
        [DataMember(Name = "Médecin")]
        public string Medecin { get; set; }
        /// <summary>
        /// Région
        /// </summary>
        [DataMember(Name = "Région")]
        public string Region { get; set; }
        /// <summary>
        /// Jours facturés en RPPR*
        /// </summary>
        [DataMember(Name = "Jours facturés en RPPR")]
        public double NombreJoursFactureRPPR { get; set; }
        /// <summary>
        /// Total jours facturés
        /// </summary>
        [DataMember(Name = "Jours totaux facturés")]
        public double NombreJoursTotauxFactures { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "% effectué")]
        public double PourcentageEffectue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Date de début")]
        public DateTime? DateDebutPeriodeApplication { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Date de fin")]
        public DateTime? DateFinPeriodeApplication { get; set; }
    }
}