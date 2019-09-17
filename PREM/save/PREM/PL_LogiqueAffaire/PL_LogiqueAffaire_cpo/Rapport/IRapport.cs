using System.Collections.Generic;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Rapport.Entite;
using RAMQ.PRE.PRE_Entites_cpo.Rapport.Parametre;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.Rapport
{
    public interface IRapport
    {
        IEnumerable<LigneRapportRepartInterRegionPrati> ObtenirLignesRapportRepartInterRegionPrati(ParamObtnrRappRepartInterRegionPrati intrant);
    }
}