using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.EntiteTest;

/// <summary>
/// 
/// </summary>
/// <remarks>
/// </remarks>
namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo
{
    public class TestService : ITestService
    {
        public ParamSortie AppelerMethodeCPO(ParamEntrer paramEntrer)
        {
            return new ParamSortie
            {
                Sortie = "TestRéussie " + paramEntrer.Entrer
            };
        }
    }
}