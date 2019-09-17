using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PL_Prem_iut.Models.PLC1_ConsulterRappPrem
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class PLC1_AvisConfActifsParTerri
    {
        public string NomMedecin { get; set; }
        public string NumeroPratique { get; set; }
        public string PrenomMedecin { get; set; }
        public string Region { get; set; }
        public string SousTerritoire { get; set; }
        public string StatutAvisConformite { get; set; }
    }
}