using NSubstitute;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;
using RAMQ.Message;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Professionnel;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AccesDonne = RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.test
{
    /// <summary>
    /// Classe de Test pour EngagementAbsence
    /// </summary>
    public class EngagementAbsenceTest: Base.TestBase
    {
        private readonly EngagementAbsence _clientEngagementAbsence;
        private readonly AccesDonne.IPlanRegnMdcal _clientPlanRegionnalMedical;
        /// <summary>
        /// constructeur
        /// </summary>
        public EngagementAbsenceTest()
        {
            _clientPlanRegionnalMedical = Substitute.For<AccesDonne.IPlanRegnMdcal>();
            _clientEngagementAbsence = new EngagementAbsence(_clientPlanRegionnalMedical);
        }

        [Fact]
        public void ObtenirPeriodeEngagementsAbsenceProfessionnel_AvecParameter_PeriodesRetourner()
        {
            //-Arrange
            Fixture.Customizations.Add(new TypeRelay(
                                                     typeof(IMsgTrait),
                                                     typeof(MsgTrait)
                                                     )
                                       );
 
            var intrant = Fixture.Create<ObtenirVuePeriodeEngagementEntre>();
            var extranMock = Fixture.Create<AccesDonne.Parametre.ObtenirVuePeriodesEngagementsSorti>();

            _clientPlanRegionnalMedical.ObtenirVuePeriodesEngagements(Arg.Any<AccesDonne.Parametre.ObtenirVuePeriodesEngagementsEntre>()).Returns(extranMock);           

            //-Act
            var extrant = _clientEngagementAbsence.ObtenirPeriodeEngagementsAbsenceProfessionnel(intrant);

            //-Assert
            Assert.True(extrant != null && extrant.EngagementsPeriode.Count > 0);
        }
    }
}