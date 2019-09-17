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
	public class LigneRapportRepartInterRegionPrati : ILigneRapport
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
        /// 
        /// </summary>
        [DataMember(Name = "Région")]
        public string Region { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Sous-territoire")]
        public string SousTerritoire { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Nbr de jours facturés")]
        public double NombreJoursFactures { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "% effectué")]
        public double PourcentageEffectue { get; set; }
    }
}