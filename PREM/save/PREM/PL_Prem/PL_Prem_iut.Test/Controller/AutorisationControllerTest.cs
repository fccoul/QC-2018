using RAMQ.PRE.PL_Prem_iut.Controllers;
using RAMQ.PRE.PL_PremMdl_cpo.AvisConformite;
using System.Web.Mvc;
using NSubstitute;

using Xunit;

namespace RAMQ.PRE.PL_Prem_iut.Test.Controller
{
    public class AutorisationControllerTest
    {
        [Fact]
        public void AutorisationController_ActionIndex_ViewResultNotNull()
        {
            //Arrange
            AutorisationController controller = new AutorisationController();

            //Act
            ViewResult result = controller.AjouterAutorisation() as ViewResult;

            //Assert
            Assert.NotNull(result);
        }
    }
}
