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
    public class LigneRapportDerogPratiExclu : ILigneRapport
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
        /// TypePratique dérogation
        /// </summary>
        [DataMember(Name = "Type de pratique")]
        public string TypePratique { get; set; }

        /// <summary>
        /// DatePriseEffet dérogation
        /// </summary>
        [DataMember(Name = "Date de prise d'effet")]
        public DateTime DatePriseEffet { get; set; }

        /// <summary>
        /// DateFin dérogation
        /// </summary>
        [DataMember(Name = "Date de fin")]
        public DateTime? DateFin { get; set; }

        /// <summary>
        /// NombreJoursFactures
        /// </summary>
        [DataMember(Name = "Nbr de jr facturés")]
        public double NombreJoursFactures { get; set; }

        /// <summary>
        /// NombreJoursTotatuxFactures
        /// </summary>
        [DataMember(Name = "Nbr de jr totaux fact")]
        public double NombreJoursTotatuxFactures { get; set; }

        /// <summary>
        /// PourcentageEffectif
        /// </summary>
        [DataMember(Name = "% effectué")]
        public double PourcentageEffectue { get; set; }
    }
}