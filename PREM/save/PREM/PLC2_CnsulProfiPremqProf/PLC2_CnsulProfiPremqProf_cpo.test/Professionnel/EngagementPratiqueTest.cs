using NSubstitute;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;
using Ploeh.AutoFixture.Xunit2;
using RAMQ.Message;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Admissibilite;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Autorisation;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.AvisConformite;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Derogation;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Professionnel;
using RAMQ.PRE.PL_RegleAffaiComne_cpo.Territoire.Entite;
using RAMQ.PRE.PL_RegleAffaiComne_cpo.Territoire.Factory;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Professionnel;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Professionnel.Interface;
using RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.EngagementPratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.PeriodePratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Pratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using System;
using System.Collections.Generic;
using Xunit;
using LAAutorisatonParametres = RAMQ.PRE.PL_LogiqueAffaire_cpo.Parametres;
using Entite = RAMQ.PRE.PRE_Entites_cpo.EngagementPratique.Entite;
using RAMQ.PRE.PRE_OutilComun_cpo;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Entite;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Entites;

using EntiteAvisConformite = RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Entite;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.test.Professionnel
{
    /// <summary>
    /// Classe de test pour les engagement de pratiques
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public class EngagementPratiqueTest : Base.TestBase
    {

        #region  Attributs

        private readonly IEngagementPratique _engagement;
        private readonly IAvisConformite _avisConformite;
        private readonly IObtenirNomTerritoireFactory _nomTerritoireFactory;
        private readonly IDerogation _derogation;
        private readonly IAutorisation _autorisation;
        private readonly IPeriodePratique _periodePratique;
        private readonly IJourneeFacturation _journeeFacturation;

        private readonly IEngagementAbence _engagementAbence;
        private readonly IRechercherProfessionnel _professionnel;
        private readonly IAdmissibilite _admissibilite;
        #endregion

        #region Constructeur 

        /// <summary>
        /// Constructeur
        /// </summary>
        public EngagementPratiqueTest()
        {
            _avisConformite = Substitute.For<IAvisConformite>();
            _nomTerritoireFactory = Substitute.For<IObtenirNomTerritoireFactory>();
            _derogation = Substitute.For<IDerogation>();
            _autorisation = Substitute.For<IAutorisation>();
            _periodePratique = Substitute.For<IPeriodePratique>();
            _journeeFacturation = Substitute.For<IJourneeFacturation>();

            _engagementAbence = Substitute.For<IEngagementAbence>();
            _professionnel = Substitute.For<IRechercherProfessionnel>();
            _admissibilite = Substitute.For<IAdmissibilite>();

            _engagement = new EngagementPratique(_periodePratique,
                                                 _avisConformite,
                                                 _nomTerritoireFactory,
                                                 _derogation,
                                                 _autorisation,
                                                 _journeeFacturation
                                                 , _engagementAbence,
                                                 _professionnel
                                                 , _admissibilite);
        }

        #endregion

        #region Test constructeur

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void EngagementPratique_PremierParametreConstructeurManquant_Erreur()
        {

            Assert.ThrowsAny<Exception>(() => new EngagementPratique(null, _avisConformite, _nomTerritoireFactory, _derogation, _autorisation, _journeeFacturation, _engagementAbence, _professionnel, _admissibilite));
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void EngagementPratique_DeuxiemeParametreConstructeurManquant_Erreur()
        {

            Assert.ThrowsAny<Exception>(() => new EngagementPratique(_periodePratique, null, _nomTerritoireFactory, _derogation, _autorisation, _journeeFacturation, _engagementAbence, _professionnel, _admissibilite));
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void EngagementPratique_TroisiemeParametreConstructeurManquant_Erreur()
        {

            Assert.ThrowsAny<Exception>(() => new EngagementPratique(_periodePratique, _avisConformite, null, _derogation, _autorisation, _journeeFacturation, _engagementAbence, _professionnel, _admissibilite));
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void EngagementPratique_QuatriemeParametreConstructeurManquant_Erreur()
        {

            Assert.ThrowsAny<Exception>(() => new EngagementPratique(_periodePratique, _avisConformite, _nomTerritoireFactory, null, _autorisation, _journeeFacturation, _engagementAbence, _professionnel, _admissibilite));
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void EngagementPratique_cinquiemeParametreConstructeurManquant_Erreur()
        {

            Assert.ThrowsAny<Exception>(() => new EngagementPratique(_periodePratique, _avisConformite, _nomTerritoireFactory, _derogation, null, _journeeFacturation, _engagementAbence, _professionnel, _admissibilite));
        }


        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void EngagementPratique_SixiemParametreConstructeurManquant_Erreur()
        {

            Assert.ThrowsAny<Exception>(() => new EngagementPratique(_periodePratique, _avisConformite, _nomTerritoireFactory, _derogation, _autorisation, _journeeFacturation, null, _professionnel, _admissibilite));
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void EngagementPratique_AvantdernierParametreConstructeurManquant_Erreur()
        {

            Assert.ThrowsAny<Exception>(() => new EngagementPratique(_periodePratique, _avisConformite, _nomTerritoireFactory, _derogation, _autorisation, _journeeFacturation, _engagementAbence, null, _admissibilite));
        }
        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void EngagementPratique_dernierParametreConstructeurManquant_Erreur()
        {

            Assert.ThrowsAny<Exception>(() => new EngagementPratique(_periodePratique, _avisConformite, _nomTerritoireFactory, _derogation, _autorisation, _journeeFacturation, _engagementAbence, _professionnel, null));
        }
        #endregion

        #region Tests période de pratique

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ObtenirPeriodePratiqueProfessionnel_ObtenirPeriodePratique_DateRetourner()
        {

            //Arranger
            var intrant = Fixture.Create<long>();
            var extrantMock = Fixture.Create<ObtenirPeriodePratiqueProfessionnelSorti>();
            extrantMock.InfoMsgTrait.Clear(); //Vider la liste des erreur remplie automatiquement par substitution
            _periodePratique.ObtenirPeriodePratiqueProfessionnel(Arg.Any<ObtenirPeriodePratiqueProfessionnelEntre>()).Returns(extrantMock);
            //Action
            var extrant = _engagement.ObtenirPeriodePratiqueProfessionnel(intrant);

            //Assertion
            Assert.True(extrant.HasValue);

        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ObtenirPeriodePratiqueProfessionnel_ObtenirPeriodePratique_DateNonTrouver()
        {

            //Arranger
            var intrant = Fixture.Create<long>();
            var extrantMock = Fixture.Create<ObtenirPeriodePratiqueProfessionnelSorti>();
            extrantMock.InfoMsgTrait.Clear(); //Vider la liste des erreur remplie automatiquement par substitution
            extrantMock.DatePremiereFacturation = null;
            _periodePratique.ObtenirPeriodePratiqueProfessionnel(Arg.Any<ObtenirPeriodePratiqueProfessionnelEntre>()).Returns(extrantMock);
            //Action
            var extrant = _engagement.ObtenirPeriodePratiqueProfessionnel(intrant);

            //Assertion
            Assert.False(extrant.HasValue);

        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ObtenirPeriodePratiqueProfessionnel_ObtenirPeriodePratique_AvecErreur()
        {
            //Arranger
            var intrant = Fixture.Create<long>();
            var extrantMock = Fixture.Create<ObtenirPeriodePratiqueProfessionnelSorti>();
            _periodePratique.ObtenirPeriodePratiqueProfessionnel(Arg.Any<ObtenirPeriodePratiqueProfessionnelEntre>()).Returns(extrantMock);

            //Action
            Exception ex = Assert.Throws<Exception>(() => _engagement.ObtenirPeriodePratiqueProfessionnel(intrant));

            //Assertion
            Assert.Equal("Erreur obtention période de pratique", ex.Message);
        }


        #endregion

        #region Tests dérogations

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ObtenirDerogations_ObtenirDerogations_DerogationsRetourner()
        {

            //Arranger
            var intrant = Fixture.Create<long>();
            var extrantMock = Fixture.Create<ObtenirDerogationsProfessionnelSanteSorti>();
            var extrantCalculerJourFacturer = Fixture.Create<CalculerNbrJrFactProfsSorti>();

            extrantMock.InfoMsgTrait.Clear();
            extrantCalculerJourFacturer.InfoMsgTrait.Clear();

            _journeeFacturation.CalculerNombreJourneeFacturation(Arg.Any<CalculerNbrJrFactProfsEntre>()).Returns(extrantCalculerJourFacturer);
            _derogation.ObtenirDerogationProfessionnel(Arg.Any<ObtenirDerogationsProfessionnelSanteEntre>()).Returns(extrantMock);

            //Action
            var extrant = _engagement.ObtenirDerogations(intrant);

            //Assertion
            Assert.True(extrant.Count > 0);
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ObtenirDerogations_ObtenirDerogation_AvecException()
        {
            //Arranger
            var intrant = Fixture.Create<long>();
            var extrantMock = Fixture.Create<ObtenirDerogationsProfessionnelSanteSorti>();
            _derogation.ObtenirDerogationProfessionnel(Arg.Any<ObtenirDerogationsProfessionnelSanteEntre>()).Returns(extrantMock);

            //Action
            var extrant = _engagement.ObtenirDerogations(intrant);

            //Assertion
            Assert.True(extrant.Count == 0);
        }


        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ObtenirDerogations_ObtenirDerogation_ListeDerogationsVide()
        {
            //Arranger
            var intrant = Fixture.Create<long>();
            var extrantMock = Fixture.Create<ObtenirDerogationsProfessionnelSanteSorti>();
            extrantMock.InfoMsgTrait.Clear();
            extrantMock.Derogations.Clear();
            _derogation.ObtenirDerogationProfessionnel(Arg.Any<ObtenirDerogationsProfessionnelSanteEntre>()).Returns(extrantMock);

            //Action
            var extrant = _engagement.ObtenirDerogations(intrant);

            //Assertion
            Assert.True(extrant.Count == 0);
        }


        #endregion

        #region Tests avis de conformités

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ObtenirAvisConformite_AvecNumeroSequenceDispensateur_DerogationsRetourner()
        {
            //Arranger
            var intrant = Fixture.Create<long>();
            var extrantMock = Fixture.Create<ObtenirLesAvisConformiteSorti>();
            var extrantCalculerJourFacturer = Fixture.Create<CalculerNbrJrFactProfsSorti>();
            var extrantNomTerritoireMock = Fixture.Create<NomTerritoire>();
            var typeTerritoire = Fixture.Create<string>();

            extrantCalculerJourFacturer.InfoMsgTrait.Clear();
            extrantMock.InfoMsgTrait.Clear();
            _journeeFacturation.CalculerNombreJourneeFacturation(Arg.Any<CalculerNbrJrFactProfsEntre>()).Returns(extrantCalculerJourFacturer);
            _avisConformite.ObtenirLesAvisConformite(Arg.Any<ObtenirLesAvisConformiteEntre>()).Returns(extrantMock);

            //S'assurer qu'il y a un type valide pour l'instanciation de la factory
            //Probablement pas la bonne chose à faire.
            foreach (var avis in extrantMock.ListeAvisConformite)
            {
                avis.TypeLieuGeographique = "RSS";
            }
            _nomTerritoireFactory.Instancier("RSS").ObtenirNomTerritoire(Arg.Any<ObtenirNomTerritoireEntre>()).Returns(extrantNomTerritoireMock);

            //Action
            var extrant = _engagement.ObtenirLesAvisConformite(intrant);

            //Assertion
            Assert.True(extrant.Count > 0);
        }

        #endregion

        #region Test autorisations

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ObtenirAutorisations_AvecNumeroSequenceDispensateur_AutorisationsRetourner()
        {
            //Arranger
            var intrant = Fixture.Create<long>();
            var extrantMock = Fixture.Create<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelSorti>();

            extrantMock.InfoMsgTrait.Clear();
            _autorisation.ObtenirAutorisationPREMQ(Arg.Any<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre>()).Returns(extrantMock);

            //Action
            var extrant = _engagement.ObtenirAutorisations(intrant);

            //Assertion
            Assert.True(extrant.Count > 0);
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ObtenirAutorisations_AvecNumeroSequenceDispensateur_AvecErreur()
        {
            //Arranger
            var intrant = Fixture.Create<long>();
            var extrantMock = Fixture.Create<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelSorti>();
            _autorisation.ObtenirAutorisationPREMQ(Arg.Any<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre>()).Returns(extrantMock);

            //Action
            var extrant = _engagement.ObtenirAutorisations(intrant);

            //Assertion
            Assert.True(extrant.Count == 0);
        }


        //-25
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numseqDispensateur"></param>
        [Theory]
        [InlineAutoData]
        public void ObtenirDateDebutHistoriqueEngagement_DatePremFactAvantPremierEngag_DatePremFactRetour(long numseqDispensateur)
        {

            //-Arrange
            Fixture.Customizations.Add(new TypeRelay(
                                                typeof(IMsgTrait),
                                                typeof(MsgTrait)
                                                )
                                  );

            //-Date 1er engagement
            ObtenirVuePeriodeEngagementSorti viewSorti = Fixture.Create<ObtenirVuePeriodeEngagementSorti>();
            viewSorti.EngagementsPeriode.RemoveAt(1);
            viewSorti.EngagementsPeriode.RemoveAt(1);
            _engagementAbence.ObtenirPeriodeEngagementsAbsenceProfessionnel(Arg.Any<ObtenirVuePeriodeEngagementEntre>()).Returns(viewSorti);

            //-Date 1ere facturation
            ObtenirPeriodePratiqueProfessionnelSorti mockPeriodePratiqueProfessionnelSorti = Fixture.Create<ObtenirPeriodePratiqueProfessionnelSorti>();
            mockPeriodePratiqueProfessionnelSorti.DatePremiereFacturation = viewSorti.EngagementsPeriode[0].DateDebutEngagement.Value.AddDays(-10);
            mockPeriodePratiqueProfessionnelSorti.InfoMsgTrait.Clear();
            _periodePratique.ObtenirPeriodePratiqueProfessionnel(Arg.Any<ObtenirPeriodePratiqueProfessionnelEntre>()).Returns(mockPeriodePratiqueProfessionnelSorti);

            //-Date Obtention Permis
            var extrantMockInfosPro = Fixture.Create<ObtenirDispensateurIndividuSorti>();
            _professionnel.ObtenirInformationProfessionnel(Arg.Any<ObtenirDispensateurIndividuEntre>()).Returns(extrantMockInfosPro);

            //-Act
            var extrant = _engagement.ObtenirDateDebutHistoriqueEngagementAbs(numseqDispensateur);
            var excepted = mockPeriodePratiqueProfessionnelSorti.DatePremiereFacturation;

            //-Assert
            Assert.Equal(excepted, extrant);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numseqDispensateur"></param>
        [Theory]
        [InlineAutoData]
        public void ObtenirDateDebutHistoriqueEngagement_DatePremFactApresPremierEngag_DateObtentionPermisRetour(long numseqDispensateur)
        {

            //-Arrange
            Fixture.Customizations.Add(new TypeRelay(
                                                typeof(IMsgTrait),
                                                typeof(MsgTrait)
                                                )
                                  );
            //-Date 1er engagement
            ObtenirVuePeriodeEngagementSorti viewSorti = Fixture.Create<ObtenirVuePeriodeEngagementSorti>();
            viewSorti.EngagementsPeriode.RemoveAt(1);

            _engagementAbence.ObtenirPeriodeEngagementsAbsenceProfessionnel(Arg.Any<ObtenirVuePeriodeEngagementEntre>()).Returns(viewSorti);

            //-Date 1ere facturation
            ObtenirPeriodePratiqueProfessionnelSorti mockPeriodePratiqueProfessionnelSorti = Fixture.Create<ObtenirPeriodePratiqueProfessionnelSorti>();
            mockPeriodePratiqueProfessionnelSorti.DatePremiereFacturation = viewSorti.EngagementsPeriode[0].DateDebutEngagement.Value.AddDays(30);
            mockPeriodePratiqueProfessionnelSorti.InfoMsgTrait.Clear();
            _periodePratique.ObtenirPeriodePratiqueProfessionnel(Arg.Any<ObtenirPeriodePratiqueProfessionnelEntre>()).Returns(mockPeriodePratiqueProfessionnelSorti);

            //-Date Obtention Permis
            var extrantMockInfosPro = Fixture.Create<ObtenirDispensateurIndividuSorti>();
            _professionnel.ObtenirInformationProfessionnel(Arg.Any<ObtenirDispensateurIndividuEntre>()).Returns(extrantMockInfosPro);

            //-Act
            var extrant = _engagement.ObtenirDateDebutHistoriqueEngagementAbs(numseqDispensateur);


            //-Assert
            Xunit.Assert.Equal(extrantMockInfosPro.DatesObtentionPermis[0].Value, extrant);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numseqDispensateur"></param>
        /// <param name="datePremFac"></param>
        [Theory]
        [InlineAutoData]
        public void ObtenirDateDebutHistoriqueEngagement_AucunEngagementAbsence_DateObtenPermisRetour(long numseqDispensateur, DateTime? datePremFac)
        {

            //-Arrange
            Fixture.Customizations.Add(new TypeRelay(
                                                typeof(IMsgTrait),
                                                typeof(MsgTrait)
                                                )
                                  );

            //-Date 1er engagement
            ObtenirVuePeriodeEngagementSorti viewSorti = Fixture.Create<ObtenirVuePeriodeEngagementSorti>();
            viewSorti.EngagementsPeriode.RemoveAt(1);
            viewSorti.EngagementsPeriode.RemoveAt(1);
            viewSorti.EngagementsPeriode[0].Type = "ABS";
            _engagementAbence.ObtenirPeriodeEngagementsAbsenceProfessionnel(Arg.Any<ObtenirVuePeriodeEngagementEntre>()).Returns(viewSorti);

            //-Date 1ere facturation
            ObtenirPeriodePratiqueProfessionnelSorti mockPeriodePratiqueProfessionnelSorti = Fixture.Create<ObtenirPeriodePratiqueProfessionnelSorti>();
            mockPeriodePratiqueProfessionnelSorti.DatePremiereFacturation = null;
            mockPeriodePratiqueProfessionnelSorti.InfoMsgTrait.Clear();
            _periodePratique.ObtenirPeriodePratiqueProfessionnel(Arg.Any<ObtenirPeriodePratiqueProfessionnelEntre>()).Returns(mockPeriodePratiqueProfessionnelSorti);

            //-Date Obtention Permis
            var extrantMockInfosPro = Fixture.Create<ObtenirDispensateurIndividuSorti>();
            _professionnel.ObtenirInformationProfessionnel(Arg.Any<ObtenirDispensateurIndividuEntre>()).Returns(extrantMockInfosPro);


            //-Act
            var extrant = _engagement.ObtenirDateDebutHistoriqueEngagementAbs(numseqDispensateur);


            //-Assert
            Assert.Equal(extrantMockInfosPro.DatesObtentionPermis[0].Value, extrant);


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numseqDispensateur"></param>
        [Theory]
        [InlineAutoData]
        public void ObtenirDateDebutHistoriqueEngagement_DateObtenionPernistAnterieurAnnePrem_DateAnnePremRetour(long numseqDispensateur)
        {

            //-Arrange

            Fixture.Customizations.Add(new TypeRelay(
                                                           typeof(IMsgTrait),
                                                           typeof(MsgTrait)
                                                           )
                                             );
            //-Date 1er engagement
            ObtenirVuePeriodeEngagementSorti viewSorti = Fixture.Create<ObtenirVuePeriodeEngagementSorti>();
            viewSorti.EngagementsPeriode.RemoveAt(1);
            viewSorti.EngagementsPeriode.RemoveAt(1);
            var excepted = new DateTime(2004, 3, 1);
            _engagementAbence.ObtenirPeriodeEngagementsAbsenceProfessionnel(Arg.Any<ObtenirVuePeriodeEngagementEntre>()).Returns(viewSorti);

            //-Date 1ere facturation
            ObtenirPeriodePratiqueProfessionnelSorti mockPeriodePratiqueProfessionnelSorti = Fixture.Create<ObtenirPeriodePratiqueProfessionnelSorti>();
            mockPeriodePratiqueProfessionnelSorti.DatePremiereFacturation = viewSorti.EngagementsPeriode[0].DateDebutEngagement.Value.AddDays(30);
            mockPeriodePratiqueProfessionnelSorti.InfoMsgTrait.Clear();
            _periodePratique.ObtenirPeriodePratiqueProfessionnel(Arg.Any<ObtenirPeriodePratiqueProfessionnelEntre>()).Returns(mockPeriodePratiqueProfessionnelSorti);

            //-Date Obtention Permis
            var extrantMockInfosPro = Fixture.Create<ObtenirDispensateurIndividuSorti>();
            extrantMockInfosPro.DatesObtentionPermis[0] = excepted.AddYears(-20);
            _professionnel.ObtenirInformationProfessionnel(Arg.Any<ObtenirDispensateurIndividuEntre>()).Returns(extrantMockInfosPro);



            //-Act
            var extrant = _engagement.ObtenirDateDebutHistoriqueEngagementAbs(numseqDispensateur);


            //-Assert

            Xunit.Assert.Equal(excepted, extrant);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroDispensateur"></param>
        /// <param name="numeroClasseDispensateur"></param>
        /// <param name="datePrevue"></param>
        [Theory]
        [InlineAutoData]
        public void ObtenirlesPeriodesNonParticipation_periodeNonParticiation_Trouve(int numeroDispensateur, int numeroClasseDispensateur, DateTime datePrevue)
        {
            //-Arrange
            Fixture.Customizations.Add(new TypeRelay(
                                                      typeof(IMsgTrait),
                                                      typeof(MsgTrait)
                                                      )
                                        );
            var admissibiliteSorti = Fixture.Create<VerifierAdmissibiliteProfessionnelFacturerSorti>();
            admissibiliteSorti.PeriodesAdmissibilite[0].StatutAdmissibilite = "NA";
            admissibiliteSorti.PeriodesAdmissibilite[0].CodeRaisonNonAdmissibilite = "NPAR";

            _admissibilite.VerifierAdmissibiliteProfessionnel(Arg.Any<VerifierAdmissibiliteProfessionnelFacturerEntre>()).Returns(admissibiliteSorti);

            //-Act
            var extrant = _engagement.ObtenirlesPeriodesNonParticipation(numeroClasseDispensateur, numeroClasseDispensateur, datePrevue);

            //-Assert
            Assert.True(extrant.Count > 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <param name="engagementPratiqueFusionnes"></param>
        [Theory]
        [InlineAutoData]
        public void ObtenirEngagementPratiquesFormate_ABsAvis_OK(ObtenirEngagementPratiqueEntre intrant, List<Entite.EngagementPratique> engagementPratiqueFusionnes)
        {
            //-Arrange
            Fixture.Customizations.Add(new TypeRelay(
                                          typeof(IMsgTrait),
                                          typeof(MsgTrait)
                                          )
                            );
            var mockEngAbsSorti = Fixture.Create<ObtenirVuePeriodeEngagementSorti>();
            _engagementAbence.ObtenirPeriodeEngagementsAbsenceProfessionnel(Arg.Any<ObtenirVuePeriodeEngagementEntre>()).Returns(mockEngAbsSorti);
            var mockPeriodPartiqSorti = Fixture.Create<ObtenirPeriodePratiqueProfessionnelSorti>();
            mockPeriodPartiqSorti.InfoMsgTrait.Clear();
            _periodePratique.ObtenirPeriodePratiqueProfessionnel(Arg.Any<ObtenirPeriodePratiqueProfessionnelEntre>()).Returns(mockPeriodPartiqSorti);
            var mockDispInd = Fixture.Create<ObtenirDispensateurIndividuSorti>();
            _professionnel.ObtenirInformationProfessionnel(Arg.Any<ObtenirDispensateurIndividuEntre>()).Returns(mockDispInd);
            engagementPratiqueFusionnes[0].Description = Constantes.DescriptionTypeEngagement.TypeAbsenceAvis;
            //-Act
            var extrant = _engagement.ObtenirEngagementPratiquesFormate(intrant, engagementPratiqueFusionnes);
            //-Assert
            Assert.True(extrant.Count > 0);
        }

        /// <summary>
        /// 
        /// </summary>
        [Theory]
        [InlineAutoData]
        public void ConstruireChevauchementPeriodeAbsEtNonParticipation_absSupprimeRG1_ok(List<Entite.EngagementPratique> lstAbs, List<AdmissibiliteFacturer> lstNpar)
        {
            //-Arrange
            lstNpar.RemoveAt(0);
            lstNpar.RemoveAt(0);
            lstNpar[0].DateDebutAdmissibilite = new DateTime(2017,4,6);
            lstNpar[0].DateFinAdmissibilite = null;

            lstAbs[0].Periode.DateDebut = new DateTime(1900, 1, 1);
            lstAbs[0].Periode.DateFin = new DateTime(2008, 7, 13);
            lstAbs[1].Periode.DateDebut = new DateTime(2008, 4, 16);
            lstAbs[1].Periode.DateFin = new DateTime(2015, 5, 17);
            lstAbs[2].Periode.DateDebut = new DateTime(2018, 1, 7);
            lstAbs[2].Periode.DateFin = null;
            //-Act
            var extrant=_engagement.ConstruireChevauchementPeriodeAbsEtNonParticipation(lstAbs,lstNpar);
            //-Assert
            Assert.True(extrant.AjouterPeriodeAbs.Count == 0);
            Assert.True(extrant.SupprimerPeriodeAbs.Count > 0);
        }

        // <summary>
        /// 
        /// </summary>
        [Theory]
        [InlineAutoData]
        public void ConstruireChevauchementPeriodeAbsEtNonParticipation_absSupprimeRG8_ok(List<Entite.EngagementPratique> lstAbs, List<AdmissibiliteFacturer> lstNpar)
        {
            //-Arrange
            lstNpar.RemoveAt(0);
            lstNpar.RemoveAt(0);
            lstNpar[0].DateDebutAdmissibilite = new DateTime(2017, 4, 6);
            lstNpar[0].DateFinAdmissibilite = new DateTime(2018,4,5);

            lstAbs[0].Periode.DateDebut = new DateTime(1900, 1, 1);
            lstAbs[0].Periode.DateFin = new DateTime(2008, 7, 13);
            lstAbs[1].Periode.DateDebut = new DateTime(2008, 4, 16);
            lstAbs[1].Periode.DateFin = new DateTime(2015, 5, 17);
            lstAbs[2].Periode.DateDebut = new DateTime(2018, 1, 7);
            lstAbs[2].Periode.DateFin = new DateTime(2018,3,20);
            var excepted = new Entite.EngagementPratique { Periode = new Entite.Periode { DateDebut = new DateTime(2018, 1, 7), DateFin = new DateTime(2018, 3, 20) } };
            //-Act
            var extrant = _engagement.ConstruireChevauchementPeriodeAbsEtNonParticipation(lstAbs, lstNpar);
            //-Assert
            Assert.True(extrant.AjouterPeriodeAbs.Count==0);
            Assert.True(extrant.SupprimerPeriodeAbs.Count>0);
            Assert.Equal(excepted.Periode, extrant.SupprimerPeriodeAbs[0].Periode, new PeriodeComparer());
        }

        // <summary>
        /// 
        /// </summary>
        [Theory]
        [InlineAutoData]
        public void ConstruireChevauchementPeriodeAbsEtNonParticipation_absSupprimeRG9_ok(List<Entite.EngagementPratique> lstAbs, List<AdmissibiliteFacturer> lstNpar)
        {
            //-Arrange
            lstNpar.RemoveAt(0);
            lstNpar.RemoveAt(0);
            lstNpar[0].DateDebutAdmissibilite = new DateTime(2017, 4, 6);
            lstNpar[0].DateFinAdmissibilite = null;

            lstAbs[0].Periode.DateDebut = new DateTime(1900, 1, 1);
            lstAbs[0].Periode.DateFin = new DateTime(2008, 7, 13);
            lstAbs[1].Periode.DateDebut = new DateTime(2008, 4, 16);
            lstAbs[1].Periode.DateFin = new DateTime(2015, 5, 17);
            lstAbs[2].Periode.DateDebut = new DateTime(2018, 1, 7);
            lstAbs[2].Periode.DateFin = new DateTime(2018, 3, 20);

            var excepted = new Entite.EngagementPratique { Periode = new Entite.Periode { DateDebut = new DateTime(2018, 1, 7), DateFin = new DateTime(2018, 3, 20) } };
            //-Act
            var extrant = _engagement.ConstruireChevauchementPeriodeAbsEtNonParticipation(lstAbs, lstNpar);
            //-Assert
            Assert.True(extrant.AjouterPeriodeAbs.Count == 0);
            Assert.True(extrant.SupprimerPeriodeAbs.Count > 0);
            Assert.Equal(excepted.Periode, extrant.SupprimerPeriodeAbs[0].Periode, new PeriodeComparer());
        }

        // <summary>
        /// 
        /// </summary>
        [Theory]
        [InlineAutoData]
        public void ConstruireChevauchementPeriodeAbsEtNonParticipation_absAjouteRG2_ok(List<Entite.EngagementPratique> lstAbs, List<AdmissibiliteFacturer> lstNpar)
        {
            //-Arrange
            lstNpar.RemoveAt(0);
            lstNpar.RemoveAt(0);
            lstNpar[0].DateDebutAdmissibilite = new DateTime(2018, 4, 6);
            lstNpar[0].DateFinAdmissibilite = null;

            lstAbs[0].Periode.DateDebut = new DateTime(1900, 1, 1);
            lstAbs[0].Periode.DateFin = new DateTime(2008, 7, 13);
            lstAbs[1].Periode.DateDebut = new DateTime(2008, 4, 16);
            lstAbs[1].Periode.DateFin = new DateTime(2015, 5, 17);
            lstAbs[2].Periode.DateDebut = new DateTime(2018, 1, 7);
            lstAbs[2].Periode.DateFin = null;
            var excepted = new Entite.EngagementPratique { Periode = new Entite.Periode { DateDebut = new DateTime(2018, 1, 7), DateFin = new DateTime(2018, 4, 5) } };
            //-Act
            var extrant = _engagement.ConstruireChevauchementPeriodeAbsEtNonParticipation(lstAbs, lstNpar);
            //-Assert
          
            Assert.True(extrant.SupprimerPeriodeAbs.Count == 0);
            Assert.True(extrant.AjouterPeriodeAbs.Count > 0);
            Assert.Equal(excepted.Periode, extrant.AjouterPeriodeAbs[0].Periode,new PeriodeComparer());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstAbs"></param>
        /// <param name="lstNpar"></param>
        [Theory]
        [InlineAutoData]
        public void ConstruireChevauchementPeriodeAbsEtNonParticipation_absAjouteRG3_ok(List<Entite.EngagementPratique> lstAbs, List<AdmissibiliteFacturer> lstNpar)
        {
            //-Arrange
            lstNpar.RemoveAt(0);
            lstNpar.RemoveAt(0);
            lstNpar[0].DateDebutAdmissibilite = new DateTime(2018, 4, 6);
            lstNpar[0].DateFinAdmissibilite = new DateTime(2018, 7, 22);

            lstAbs[0].Periode.DateDebut = new DateTime(1900, 1, 1);
            lstAbs[0].Periode.DateFin = new DateTime(2008, 7, 13);
            lstAbs[1].Periode.DateDebut = new DateTime(2008, 4, 16);
            lstAbs[1].Periode.DateFin = new DateTime(2015, 5, 17);
            lstAbs[2].Periode.DateDebut = new DateTime(2018, 6, 7);
            lstAbs[2].Periode.DateFin = null;
            var excepted = new Entite.EngagementPratique { Periode = new Entite.Periode { DateDebut = new DateTime(2018, 7, 23), DateFin = new DateTime(2999, 12, 30) } };
        
            //-Act
            var extrant = _engagement.ConstruireChevauchementPeriodeAbsEtNonParticipation(lstAbs, lstNpar);
            //-Assert

            Assert.True(extrant.SupprimerPeriodeAbs.Count == 0);
            Assert.True(extrant.AjouterPeriodeAbs.Count > 0);
            Assert.Equal(excepted.Periode, extrant.AjouterPeriodeAbs[0].Periode, new PeriodeComparer());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstAbs"></param>
        /// <param name="lstNpar"></param>
        [Theory]
        [InlineAutoData]
        public void ConstruireChevauchementPeriodeAbsEtNonParticipation_absAjouteRG4_ok(List<Entite.EngagementPratique> lstAbs, List<AdmissibiliteFacturer> lstNpar)
        {
            //-Arrange
            lstNpar.RemoveAt(0);
            lstNpar.RemoveAt(0);
            lstNpar[0].DateDebutAdmissibilite = new DateTime(2018, 4, 6);
            lstNpar[0].DateFinAdmissibilite = new DateTime(2018, 7, 22);

            lstAbs[0].Periode.DateDebut = new DateTime(1900, 1, 1);
            lstAbs[0].Periode.DateFin = new DateTime(2008, 7, 13);
            lstAbs[1].Periode.DateDebut = new DateTime(2008, 4, 16);
            lstAbs[1].Periode.DateFin = new DateTime(2015, 5, 17);
            lstAbs[2].Periode.DateDebut = new DateTime(2018, 1, 7);
            lstAbs[2].Periode.DateFin = null;
            var excepted1 = new Entite.EngagementPratique { Periode = new Entite.Periode { DateDebut = new DateTime(2018, 1, 7), DateFin = new DateTime(2018, 4, 5) } };
            var excepted2 = new Entite.EngagementPratique { Periode = new Entite.Periode { DateDebut = new DateTime(2018, 7, 23), DateFin = new DateTime(2999, 12, 30) } };

            //-Act
            var extrant = _engagement.ConstruireChevauchementPeriodeAbsEtNonParticipation(lstAbs, lstNpar);
            //-Assert

            Assert.True(extrant.SupprimerPeriodeAbs.Count == 0);
            Assert.True(extrant.AjouterPeriodeAbs.Count ==2);
            Assert.Equal(excepted1.Periode, extrant.AjouterPeriodeAbs[0].Periode, new PeriodeComparer());
            Assert.Equal(excepted2.Periode, extrant.AjouterPeriodeAbs[1].Periode, new PeriodeComparer());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstAbs"></param>
        /// <param name="lstNpar"></param>
        [Theory]
        [InlineAutoData]
        public void ConstruireChevauchementPeriodeAbsEtNonParticipation_absAjouteRG5_1_ok(List<Entite.EngagementPratique> lstAbs, List<AdmissibiliteFacturer> lstNpar)
        {
            //-Arrange
            lstNpar.RemoveAt(0);
            lstNpar.RemoveAt(0);
            lstNpar[0].DateDebutAdmissibilite = new DateTime(2018, 4, 6);
            lstNpar[0].DateFinAdmissibilite = new DateTime(2018, 7, 22);

            lstAbs[0].Periode.DateDebut = new DateTime(1900, 1, 1);
            lstAbs[0].Periode.DateFin = new DateTime(2008, 7, 13);
            lstAbs[1].Periode.DateDebut = new DateTime(2008, 4, 16);
            lstAbs[1].Periode.DateFin = new DateTime(2015, 5, 17);
            lstAbs[2].Periode.DateDebut = new DateTime(2018, 1, 7);
            lstAbs[2].Periode.DateFin = new DateTime(2018, 7, 8);

            var excepted = new Entite.EngagementPratique { Periode = new Entite.Periode { DateDebut = new DateTime(2018, 1, 7), DateFin = new DateTime(2018, 4, 5) } };
           

            //-Act
            var extrant = _engagement.ConstruireChevauchementPeriodeAbsEtNonParticipation(lstAbs, lstNpar);
            //-Assert

            Assert.True(extrant.SupprimerPeriodeAbs.Count == 0);
            Assert.True(extrant.AjouterPeriodeAbs.Count > 0);
            Assert.Equal(excepted.Periode, extrant.AjouterPeriodeAbs[0].Periode, new PeriodeComparer());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstAbs"></param>
        /// <param name="lstNpar"></param>
        [Theory]
        [InlineAutoData]
        public void ConstruireChevauchementPeriodeAbsEtNonParticipation_absAjouteRG5_2_ok(List<Entite.EngagementPratique> lstAbs, List<AdmissibiliteFacturer> lstNpar)
        {
            //-Arrange
            lstNpar.RemoveAt(0);
            lstNpar.RemoveAt(0);
            lstNpar[0].DateDebutAdmissibilite = new DateTime(2018, 5, 24);
            lstNpar[0].DateFinAdmissibilite = new DateTime(2018, 7, 1);

            lstAbs[0].Periode.DateDebut = new DateTime(2007, 1, 1);
            lstAbs[0].Periode.DateFin = new DateTime(2009, 7, 1);
            lstAbs[1].Periode.DateDebut = new DateTime(2018, 3, 11);
            lstAbs[1].Periode.DateFin = new DateTime(2018, 6, 17);
            lstAbs.RemoveAt(2);


           var excepted = new Entite.EngagementPratique { Periode = new Entite.Periode { DateDebut = new DateTime(2018, 3, 11), DateFin = new DateTime(2018, 5, 23) } };


            //-Act
            var extrant = _engagement.ConstruireChevauchementPeriodeAbsEtNonParticipation(lstAbs, lstNpar);
            //-Assert

            Assert.True(extrant.SupprimerPeriodeAbs.Count == 0);
            Assert.True(extrant.AjouterPeriodeAbs.Count > 0);
            Assert.Equal(excepted.Periode, extrant.AjouterPeriodeAbs[0].Periode, new PeriodeComparer());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstAbs"></param>
        /// <param name="lstNpar"></param>
        [Theory]
        [InlineAutoData]
        public void ConstruireChevauchementPeriodeAbsEtNonParticipation_absAjouteRG6_ok(List<Entite.EngagementPratique> lstAbs, List<AdmissibiliteFacturer> lstNpar)
        {
            //-Arrange
            lstNpar.RemoveAt(0);
            lstNpar.RemoveAt(0);
            lstNpar[0].DateDebutAdmissibilite = new DateTime(2018, 4, 6);
            lstNpar[0].DateFinAdmissibilite = new DateTime(2018, 7, 22);

            lstAbs[0].Periode.DateDebut = new DateTime(1900, 1, 1);
            lstAbs[0].Periode.DateFin = new DateTime(2008, 7, 13);
            lstAbs[1].Periode.DateDebut = new DateTime(2008, 4, 16);
            lstAbs[1].Periode.DateFin = new DateTime(2015, 5, 17);
            lstAbs[2].Periode.DateDebut = new DateTime(2018, 1, 7);
            lstAbs[2].Periode.DateFin = new DateTime(2018, 7, 30);

            var excepted1 = new Entite.EngagementPratique { Periode = new Entite.Periode { DateDebut = new DateTime(2018, 1, 7), DateFin = new DateTime(2018, 4, 5) } };
            var excepted2 = new Entite.EngagementPratique { Periode = new Entite.Periode { DateDebut = new DateTime(2018, 7, 23), DateFin = new DateTime(2018, 7, 30) } };

            //-Act
            var extrant = _engagement.ConstruireChevauchementPeriodeAbsEtNonParticipation(lstAbs, lstNpar);

            //-Assert
            Assert.True(extrant.SupprimerPeriodeAbs.Count == 0);
            Assert.True(extrant.AjouterPeriodeAbs.Count == 2);
            Assert.Equal(excepted1.Periode, extrant.AjouterPeriodeAbs[0].Periode, new PeriodeComparer());
            Assert.Equal(excepted2.Periode, extrant.AjouterPeriodeAbs[1].Periode, new PeriodeComparer());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstAbs"></param>
        /// <param name="lstNpar"></param>
        [Theory]
        [InlineAutoData]
        public void ConstruireChevauchementPeriodeAbsEtNonParticipation_absAjouteRG7_ok(List<Entite.EngagementPratique> lstAbs, List<AdmissibiliteFacturer> lstNpar)
        {
            //-Arrange
            lstNpar.RemoveAt(0);
            lstNpar.RemoveAt(0);
            lstNpar[0].DateDebutAdmissibilite = new DateTime(2018, 4, 6);
            lstNpar[0].DateFinAdmissibilite = new DateTime(2018, 7, 22);

            lstAbs[0].Periode.DateDebut = new DateTime(1900, 1, 1);
            lstAbs[0].Periode.DateFin = new DateTime(2008, 7, 13);
            lstAbs[1].Periode.DateDebut = new DateTime(2008, 4, 16);
            lstAbs[1].Periode.DateFin = new DateTime(2015, 5, 17);
            lstAbs[2].Periode.DateDebut = new DateTime(2018, 5, 2);
            lstAbs[2].Periode.DateFin = new DateTime(2018, 7, 30);

            var excepted = new Entite.EngagementPratique { Periode = new Entite.Periode { DateDebut = new DateTime(2018, 7, 23), DateFin = new DateTime(2018, 7, 30) } };            

            //-Act
            var extrant = _engagement.ConstruireChevauchementPeriodeAbsEtNonParticipation(lstAbs, lstNpar);

            //-Assert
            Assert.True(extrant.SupprimerPeriodeAbs.Count == 0);
            Assert.True(extrant.AjouterPeriodeAbs.Count >0 );
            Assert.Equal(excepted.Periode, extrant.AjouterPeriodeAbs[0].Periode, new PeriodeComparer());
     
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstAbs"></param>
        /// <param name="lstNpar"></param>
        [Theory]
        [InlineAutoData]
        public void ConstruireChevauchementPeriodeAbsEtNonParticipation_absAjouteRG10_ok(List<Entite.EngagementPratique> lstAbs, List<AdmissibiliteFacturer> lstNpar)
        {
            //-Arrange
            lstNpar.RemoveAt(0);
            lstNpar.RemoveAt(0);
            lstNpar[0].DateDebutAdmissibilite = new DateTime(2018, 4, 6);
            lstNpar[0].DateFinAdmissibilite = null;

            lstAbs[0].Periode.DateDebut = new DateTime(1900, 1, 1);
            lstAbs[0].Periode.DateFin = new DateTime(2008, 7, 13);
            lstAbs[1].Periode.DateDebut = new DateTime(2008, 4, 16);
            lstAbs[1].Periode.DateFin = new DateTime(2015, 5, 17);
            lstAbs[2].Periode.DateDebut = new DateTime(2018, 2, 9);
            lstAbs[2].Periode.DateFin = new DateTime(2018, 7, 30);

            var excepted = new Entite.EngagementPratique { Periode = new Entite.Periode { DateDebut = new DateTime(2018, 2, 9), DateFin = new DateTime(2018, 4, 5) } };

            //-Act
            var extrant = _engagement.ConstruireChevauchementPeriodeAbsEtNonParticipation(lstAbs, lstNpar);

            //-Assert
            Assert.True(extrant.SupprimerPeriodeAbs.Count == 0);
            Assert.True(extrant.AjouterPeriodeAbs.Count > 0);
            Assert.Equal(excepted.Periode, extrant.AjouterPeriodeAbs[0].Periode, new PeriodeComparer());

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrantVue"></param>
        /// <param name="statutAvis"></param>
        [Theory]
        [InlineAutoData]
        public void ObtenirDateDebuthistoriqueDansAvis_DeuxavisPlusuneAbs_OK(EntiteAvisConformite.StatutAvisConformite statutAvis)
        {
            //-Arrange
            Fixture.Customizations.Add(new TypeRelay(
                                        typeof(IMsgTrait),
                                        typeof(MsgTrait)
                                        )
                          );
            
            var intrant = Fixture.Create<ObtenirVuePeriodeEngagementEntre>();
            var extrantMock = Fixture.Create<ObtenirVuePeriodeEngagementSorti>();
            extrantMock.InfoMsgTrait.Clear();           
            _engagementAbence.ObtenirPeriodeEngagementsAbsenceProfessionnel(Arg.Any< ObtenirVuePeriodeEngagementEntre>()).Returns(extrantMock);
            /*
            var pratiqMock = Fixture.Create<ObtenirPeriodePratiqueProfessionnelSorti>();            
            _periodePratique.ObtenirPeriodePratiqueProfessionnel(Arg.Any<ObtenirPeriodePratiqueProfessionnelEntre>()).Returns(pratiqMock);
            pratiqMock.InfoMsgTrait.Clear();
            
           var infosDispMock = Fixture.Create<ObtenirDispensateurIndividuSorti>();
            _professionnel.ObtenirInformationProfessionnel(Arg.Any<ObtenirDispensateurIndividuEntre>()).Returns(infosDispMock);
            infosDispMock.InfoMsgTrait.Clear();
            */

            extrantMock.EngagementsPeriode[0].Type = "ABS";
            extrantMock.EngagementsPeriode[0].DateDebutEngagement = new DateTime(1900, 1, 1);
            extrantMock.EngagementsPeriode[0].DateFinEngagement = new DateTime(2003, 12, 31);
            extrantMock.EngagementsPeriode[1].Type = "AVIS";
            extrantMock.EngagementsPeriode[1].DateDebutEngagement = new DateTime(2004, 1, 1);
            extrantMock.EngagementsPeriode[1].DateFinEngagement = new DateTime(2010, 2, 28);
            extrantMock.EngagementsPeriode[2].Type = "AVIS";
            extrantMock.EngagementsPeriode[2].DateDebutEngagement = new DateTime(2010, 3, 1);
            extrantMock.EngagementsPeriode[0].DateFinEngagement = new DateTime(2999, 12, 31);

            
            statutAvis.DateDebutStatutEngagement= new DateTime(2010, 3, 1);

            var statutAvis2 = statutAvis;
           
            //-Act
            var extrant = _engagement.ObtenirDateDebuthistoriqueDansAvis(extrantMock, statutAvis);
            statutAvis2.DateDebutStatutEngagement = new DateTime(2004, 1, 1);
            var extrant2 = _engagement.ObtenirDateDebuthistoriqueDansAvis(extrantMock, statutAvis2);

            //-Assert
            Assert.True(extrant);
           Assert.False(extrant2);

         
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numSeq"></param>
        /// <param name="statutAvis"></param>
        [Theory]
        [InlineAutoData]
        public void ObtenirDateDebuthistoriqueDansAvis_unAvisPlusAbsAnterieureEtPosterieure_OK(EntiteAvisConformite.StatutAvisConformite statutAvis)
        {
            //-Arrange
            Fixture.Customizations.Add(new TypeRelay(
                                        typeof(IMsgTrait),
                                        typeof(MsgTrait)
                                        )
                          );
            var intrant = Fixture.Create<ObtenirVuePeriodeEngagementEntre>();
            var extrantMock = Fixture.Create<ObtenirVuePeriodeEngagementSorti>();
            extrantMock.InfoMsgTrait.Clear();
            _engagementAbence.ObtenirPeriodeEngagementsAbsenceProfessionnel(Arg.Any<ObtenirVuePeriodeEngagementEntre>()).Returns(extrantMock);

            
            extrantMock.EngagementsPeriode[0].Type = "ABS";
            extrantMock.EngagementsPeriode[0].DateDebutEngagement = new DateTime(1900, 1, 1);
            extrantMock.EngagementsPeriode[0].DateFinEngagement = new DateTime(2011, 11, 10);
            extrantMock.EngagementsPeriode[1].Type = "AVIS";
            extrantMock.EngagementsPeriode[1].DateDebutEngagement = new DateTime(2011, 11, 11);
            extrantMock.EngagementsPeriode[2].Type = "ABS";
            extrantMock.EngagementsPeriode[2].DateDebutEngagement = new DateTime(2017, 6, 2);

            statutAvis.DateDebutStatutEngagement = new DateTime(2011, 11, 11);

            //-Act
            var extrant = _engagement.ObtenirDateDebuthistoriqueDansAvis(extrantMock, statutAvis);
            

            //-Assert
            Assert.True(extrant);
           


        }
        #endregion
    }
}