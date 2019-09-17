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
    public class LigneRapportAvisConfActifsParTerritoire : ILigneRapport
    {
        /// <summary>
        /// Numéro de pratique
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
        /// 
        /// </summary>
        [DataMember]
        public string Region { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string SousTerritoire { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string StatutAvisConformite { get; set; }
    }
}