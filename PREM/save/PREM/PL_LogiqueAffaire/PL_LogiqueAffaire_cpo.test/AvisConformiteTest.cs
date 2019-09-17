using RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre;
using NSubstitute;
using Xunit;
using Ploeh.AutoFixture;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.AvisConformite;
using AccesDonne = RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal;
using Ploeh.AutoFixture.Kernel;
using RAMQ.Message;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.test
{
    /// <summary>
    /// Classe de Test pour AvisConformite
    /// </summary>
    public class AvisConformiteTest : Base.TestBase
    {
        private readonly AccesDonne.IPlanRegnMdcal _clientPlanRegnMdcal;
        private readonly IAvisConformite _clientAvisConformite;

        /// <summary>
        /// Constructeur
        /// </summary>
        public AvisConformiteTest()
        {

            _clientPlanRegnMdcal = Substitute.For<AccesDonne.IPlanRegnMdcal>();
            _clientAvisConformite = new AvisConformite.AvisConformite(_clientPlanRegnMdcal);

        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ObtenirLesAvisConformite_AvecParametreEntrer_AvisConformiteRetourner()
        {
            var intrant = Fixture.Create<ObtenirLesAvisConformiteEntre>();
            var extrantMock = Fixture.Create<AccesDonne.Parametre.ObtenirLesAvisConformiteSorti>();

            _clientPlanRegnMdcal.ObtenirLesAvisConformite(Arg.Any<AccesDonne.Parametre.ObtenirLesAvisConformiteEntre>()).Returns(extrantMock);

            var extrant = _clientAvisConformite.ObtenirLesAvisConformite(intrant);

            Assert.True(extrant != null && extrant.ListeAvisConformite.Count > 0);
        }

        [Fact]
        public void MoModifierRaisFermStatutEngag_AvecParametreEntrer_DateHeureMAJRetourner()
        {
            //-Arrange
            Fixture.Customizations.Add(new TypeRelay(
                                     typeof(IMsgTrait),
                                     typeof(MsgTrait)
                                     )
                       );
            var intrant = Fixture.Create<ModifierRaisFermStatutEngagEntre>();
            var extrantMock = Fixture.Create<AccesDonne.Parametre.ModifierRaisFermStatutEngagSorti>();

            //-Act
            _clientPlanRegnMdcal.ModifierRaisFermStatutEngag(Arg.Any<AccesDonne.Parametre.ModifierRaisFermStatutEngagEntre>()).Returns(extrantMock);
            var extrant = _clientAvisConformite.ModifierRaisFermStatutEngag(intrant);

            //-Assert
            Assert.True(extrant.DateHeureOccurence.HasValue);

        }
    }
}