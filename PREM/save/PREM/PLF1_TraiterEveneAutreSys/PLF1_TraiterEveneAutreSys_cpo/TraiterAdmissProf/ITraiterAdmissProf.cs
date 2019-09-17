using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite;
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
namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo
{
    public interface ITraiterAdmissProf
    {
        //Point entrée
        ParamSortiTraiterAdmissProf TraiterEvenementSuppression(ParamEntreTraiterAdmissProf intrant);

        ParamSortiTraiterAdmissProf TraiterEvenementAjoutModification(ParamEntreTraiterAdmissProf intrant);

        bool EstUnEvenementDeSuppression(string messageEvenement);
        bool EstUnEvenementDAjout(string messageEvenement);
        bool EstUnEvenementDeModification(string messageEvenement);

    }
}
