using NSubstitute;
using Ploeh.AutoFixture;
using RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3;
using RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3.Parametre;
using Xunit;
using Entite = RAMQ.PRE.PRE_Entites_cpo.PeriodePratique.Parametre;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.test.ObtentionInformation
{
    /// <summary>
    /// Classe de test pour l'obtention des information des professionnel des systèmes externes
    /// </summary>
    public class ObtenirInformationProfessionnelSystemeExterneTest : Base.TestBase
    {

        private readonly IInfoDispCnsul _clientInformationDispensateur;
       // private readonly IObtenirInformationProfessionnelSystemeExterne _clientObtentionInformation;

        /// <summary>
        /// Constructeur
        /// </summary>
        public ObtenirInformationProfessionnelSystemeExterneTest()
        {

            _clientInformationDispensateur = Substitute.For<IInfoDispCnsul>();
            //_clientObtentionInformation = new ObtenirInformationProfessionnelSystemeExterne(_clientInformationDispensateur);

        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ObtenirPeriodePratiqueProfessionnel_AvecParametreEntre_Succes()
        {
            var intrant = Fixture.Create<Entite.ObtenirPeriodePratiqueProfessionnelEntre>();
            var extrantMock = Fixture.Create<ObtenirPeriodePratiqueProfessionnelSorti>();

            _clientInformationDispensateur.ObtenirPeriodePratiqueProfessionnel(Arg.Any<ObtenirPeriodePratiqueProfessionnelEntre>()).Returns(extrantMock);


            var extrant = _clientObtentionInformation.ObtenirPeriodePratiqueProfessionnel(intrant);


            Assert.NotNull(extrant);

        }

    }
}