using NSubstitute;
using Xunit;
using Ploeh.AutoFixture;
using RAMQ.PRE.PRE_Entites_cpo.Autorisation.Parametre;
using AccesDonne = RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.ObtentionInformation;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.test.ObtentionInformation
{
    /// <summary>
    /// lasse de test pour l'obtention des information des professionnel des systèmes internes
    /// </summary>
    public class ObtenirInformationProfessionnelSystemeInterneTest : Base.TestBase
    {

        #region Attributs

        private readonly AccesDonne.IPlanRegnMdcal _clientPlanRegionnalMedical;

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        public ObtenirInformationProfessionnelSystemeInterneTest()
        {

            _clientPlanRegionnalMedical = Substitute.For<AccesDonne.IPlanRegnMdcal>();

        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ObtenirAutorisationProfessionnelSante_AvecParametreEntrer_AutorisationsRetourner()
        {
            var intrant = Fixture.Create<ObtenirLesAutorisationsProfessionnelEntre>();
            var extrantMock = Fixture.Create<AccesDonne.Parametre.ObtenirAutorisationsSorti>();

            _clientPlanRegionnalMedical.ObtenirAutorisationsProfessionnelSante(Arg.Any<AccesDonne.Parametre.ObtenirAutorisationsEntre>()).Returns(extrantMock);

            var extrant = _clientObtentionInformationObtention.ObtenirAutorisationProfessionnelSante(intrant);


            Assert.True(extrant != null && extrant.Autorisations.Count > 0);

        }
    }
}