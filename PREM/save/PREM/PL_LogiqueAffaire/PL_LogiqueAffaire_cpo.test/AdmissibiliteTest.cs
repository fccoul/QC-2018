using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3;
using NSubstitute;
using Xunit;
using Ploeh.AutoFixture;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Admissibilite;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.test
{
    /// <summary>
    /// Classe de Test pour Admissibilite
    /// </summary>
    public class AdmissibiliteTest : Base.TestBase
    {

        private readonly IInfoDispCnsul _clientInformationDispensateur;
        private readonly IAdmissibilite _clientAdmissibilite;

        /// <summary>
        /// Constructeur
        /// </summary>
        public AdmissibiliteTest()
        {

            _clientInformationDispensateur = Substitute.For<IInfoDispCnsul>();
            _clientAdmissibilite = new Admissibilite.Admissibilite(_clientInformationDispensateur);

        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void VerifierAdmissibiliteProfessionnel_AvecParametreEntre_Succes()
        {
            var intrant = Fixture.Create<VerifierAdmissibiliteProfessionnelFacturerEntre>();
            var extrantMock = Fixture.Create<VerifierAdmissibiliteProfessionnelFacturerSorti>();
            extrantMock.InfoMsgTrait.Clear();

            _clientInformationDispensateur.VerifierAdmissibiliteProfessionnel(Arg.Any<VerifierAdmissibiliteProfessionnelFacturerEntre>()).Returns(extrantMock);

            var extrant = _clientAdmissibilite.VerifierAdmissibiliteProfessionnel(intrant);


            Assert.True(extrant != null && extrant.PeriodesAdmissibilite.Count > 0);
        }
    }
}