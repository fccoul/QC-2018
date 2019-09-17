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
    public class LigneRapportAvisConfTermines : ILigneRapport
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string NumeroPratique { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string NomMedecin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string PrenomMedecin { get; set; }
        /// <summary>
        /// Date de fin de l'avis de conformité
        /// </summary>
        [DataMember]
        public DateTime? DateFinAvis { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Raison { get; set; }
        /// <summary>
        /// Région originale
        /// </summary>
        [DataMember]
        public string RegionOriginale { get; set; }
        /// <summary>
        /// Région de destination
        /// </summary>
        [DataMember]
        public string RegionDestination { get; set; }
    }
}