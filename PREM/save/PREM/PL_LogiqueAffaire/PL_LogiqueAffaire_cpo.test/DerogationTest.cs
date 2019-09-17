using NSubstitute;
using Xunit;
using Ploeh.AutoFixture;
using RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre;
using AccesDonne = RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Derogation;
using OutilCommun = RAMQ.PRE.PRE_OutilComun_cpo;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.test
{
    /// <summary>
    /// Classe de Test pour Derogation
    /// </summary>
    public class DerogationTest : Base.TestBase
    {
        #region Attributs

        private readonly AccesDonne.IPlanRegnMdcal _clientPlanRegionnalMedical;
        private readonly IDerogation _clientDerogation;

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        public DerogationTest()
        {

            _clientPlanRegionnalMedical = Substitute.For<AccesDonne.IPlanRegnMdcal>();
            _clientDerogation = new Derogation.Derogation(_clientPlanRegionnalMedical);

        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ModifierDerogation_AvecParametreEntrer_NouveauNumeroSequentielDifferentZero()
        {
            var intrant = Fixture.Create<ModifierDerogationEntre>();
            var extrantMock = Fixture.Create<AccesDonne.Parametre.ModifierDerogationSorti>();
            extrantMock.InfoMsgTrait.Clear();

            _clientPlanRegionnalMedical.ModifierDerogation(Arg.Any<AccesDonne.Parametre.ModifierDerogationEntre>()).Returns(extrantMock);

            var extrant = _clientDerogation.ModifierDerogation(intrant);


            Assert.True(extrant != null && extrant.NouveauNumeroSequentiel != 0);
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ObtenirDerogationsProfessionnel_AvecParametreEntrer_DerogationRetourner()
        {
            var intrant = Fixture.Create<ObtenirDerogationsProfessionnelSanteEntre>();
            var extrantMock = Fixture.Create<AccesDonne.Parametre.ObtenirDerogationsProfessionnelSanteSorti>();

            _clientPlanRegionnalMedical.ObtenirDerogationsProfessionnelSante(Arg.Any<AccesDonne.Parametre.ObtenirDerogationsProfessionnelSanteEntre>()).Returns(extrantMock);

            var extrant = _clientDerogation.ObtenirDerogationProfessionnel(intrant);

            Assert.True(extrant != null && extrant.Derogations.Count > 0);
        }

        // TODO - Tester CreerDerogation
    }
}