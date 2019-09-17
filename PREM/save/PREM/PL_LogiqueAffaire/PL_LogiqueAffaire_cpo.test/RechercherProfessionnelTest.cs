using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using EPZ3 = RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3;
using NSubstitute;
using Xunit;
using Ploeh.AutoFixture;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Professionnel;
using AccesDonne = RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal;
using Ploeh.AutoFixture.Kernel;
using RAMQ.Message;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.test
{
    /// <summary>
    /// Classe de Test pour RechercherProfessionnel
    /// </summary>
    public class RechercherProfessionnelTest : Base.TestBase
    {
        private readonly EPZ3.IInfoDispCnsul _clientInfoDispCnsul;
        private readonly IRechercherProfessionnel _clientRechercherProfessionnel;

        /// <summary>
        /// Constructeur
        /// </summary>
        public RechercherProfessionnelTest()
        {

            _clientInfoDispCnsul = Substitute.For<EPZ3.IInfoDispCnsul>();
            _clientRechercherProfessionnel = new RechercherProfessionnel(_clientInfoDispCnsul);


        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ObtenirInformationProfessionnel_AvecParametreEntrer_InformationProfessionnelRetourner()
        {
            var intrant = Fixture.Create<ObtenirDispensateurIndividuEntre>();
            var extrantMock = Fixture.Create<EPZ3.Parametre.ObtnRelDispIndivSorti>();

            _clientInfoDispCnsul.ObtenirRelDispIndiv(Arg.Any<EPZ3.Parametre.ObtnRelDispIndivEntre>()).Returns(extrantMock);

            var extrant = _clientRechercherProfessionnel.ObtenirInformationProfessionnel(intrant);

            Assert.True(extrant != null && extrant.DatesCreationDispensateur != null);


           
        }


      
    }
}