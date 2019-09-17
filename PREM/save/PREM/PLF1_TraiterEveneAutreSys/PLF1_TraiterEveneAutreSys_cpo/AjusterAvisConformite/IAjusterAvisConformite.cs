using RAMQ.Message;
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
    public interface IAjusterAvisConformite
    {
        ParamSortiAjusterAvisConformiteMedResidents VerifierParametresEntree(ParamEntreAjusterAvisConformiteMedResidents informationsDispensateur, RAMQ.Message.IResolutionMessage resolutionMessageTrait = null);

        bool VerifierSiClasseUne(int noClasseDispensateur);

        bool VerifierSiMedResidentPresent(List<long> listeNoDispensateurs);

        bool VerifierSiAvisATraiter(List<long> listeIdAvis);


        List<long> ObtenirIDAvisConformiteAModifier(List<long> listeNumNoSeqMedResidents);

        List<long> ObtenirDispensateursAssociesDeClasseCinq(int indNoSeq);


        List<MsgTrait> ModifierAvisConformiteACorriger(long noSequentielDispensateur, List<long> listeIdAvisACorriger);
    }
}
