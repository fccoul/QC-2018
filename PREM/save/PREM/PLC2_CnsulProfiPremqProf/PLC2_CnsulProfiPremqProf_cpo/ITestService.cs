using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
/// <remarks>
/// </remarks>
namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo
{
    public interface ITestService
    {
        EntiteTest.ParamSortie AppelerMethodeCPO(EntiteTest.ParamEntrer paramEntrer);
    }
}
