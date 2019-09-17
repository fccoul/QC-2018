using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock;

namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_tst
{
    [TestClass()]
    public class TraitEveneAutreSysTests
    {

        public static PRE_AccesDonne_cpo.PlanRegnMdcal.IPlanRegnMdcal ObtenirAccesDonneesMocke()
        {
            var accesDonnes = Mock.Create<PRE_AccesDonne_cpo.PlanRegnMdcal.IPlanRegnMdcal>(Behavior.Strict);
            return accesDonnes;
        }

        public static PRE_SysExt_cpo.FIP.EPZ3.IInfoDispCnsul ObtenirAccesSysExtMocke()
        {
            var accesDonnes = Mock.Create<PRE_SysExt_cpo.FIP.EPZ3.IInfoDispCnsul>(Behavior.Strict);
            return accesDonnes;
        }


        [TestMethod()]
        public void AjusterAvisConformiteMedResidents_ClasseIntrantDiffDeUne_InfoMsgTraitVide()
        {
            //var classeDeTest = new TraitEveneAutreSys(ObtenirAccesDonneesMocke(), ObtenirAccesSysExtMocke());
            //ParamSortiAjusterAvisConformiteMedResidents sortant;
            //var intrant = new ParamEntreAjusterAvisConformiteMedResidents()
            //{
            //    PvcClaDisp = 2
            //};

            //sortant = classeDeTest.AjusterAvisConformiteMedResidents(intrant);

            //Assert.IsFalse(sortant.InfoMsgTrait.Any());
        }

    }
}