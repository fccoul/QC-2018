using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit2;
using RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.AvisConformite;
using RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.AjusterEngagement.Param;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Derogation;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Autorisation;
using EntiteCPO = RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre;
using LAAutorisatonParametres = RAMQ.PRE.PL_LogiqueAffaire_cpo.Parametres;
using RAMQ.PRE.PRE_Entites_cpo.Autorisation.Parametre;
using Ploeh.AutoFixture.Kernel;
using RAMQ.Message;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Professionnel;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using RAMQ.Enumeration;
using RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.AjusterEngagement.Constante;

namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.test
{
    public class TraitEveneAutreSysTest : Base.TestBase
    {



        #region Attributs
        private readonly IAjusterEngagAvisConfNonParticipation _ajusterEngag;

        private readonly IAvisConformite _avisConformite;
        private readonly IDerogation _derogation;
        private readonly IAutorisation _autorisation;
        private readonly IRechercherProfessionnel _professionnel;


        #endregion

        #region Constructeur
        public TraitEveneAutreSysTest()
        {
            //_ajusterEngag = Substitute.For<IAjusterEngagAvisConfNonParticipation>(); //--to delete

            _avisConformite = Substitute.For<IAvisConformite>();
            _derogation = Substitute.For<IDerogation>();
            _autorisation = Substitute.For<IAutorisation>();
            _professionnel = Substitute.For<IRechercherProfessionnel>();
            _ajusterEngag = new AjusterEngagAvisConfNonParticipation(_avisConformite, _derogation, _autorisation, _professionnel);

        }

        #endregion

        #region Medecin Residents
        public static PRE_AccesDonne_cpo.PlanRegnMdcal.IPlanRegnMdcal ObtenirAccesDonneesMocke()
        {
            var accesDonnes = Substitute.For<PRE_AccesDonne_cpo.PlanRegnMdcal.IPlanRegnMdcal>();
            return accesDonnes;
        }

        public static PRE_SysExt_cpo.FIP.EPZ3.IInfoDispCnsul ObtenirAccesSysExtMocke()
        {
            var accesDonnes = Substitute.For<PRE_SysExt_cpo.FIP.EPZ3.IInfoDispCnsul>();
            return accesDonnes;
        }

        [Theory]
        [InlineData(2)]
        [InlineData(0)]
        [InlineData(99)]
        public void AjusterAvisConformiteMedResidents_ClasseNonTraitee_OK(int classeDisp)
        {
            var ajusterAvis = Substitute.For<IAjusterAvisConformite>();
            ajusterAvis.VerifierParametresEntree(Arg.Any<ParamEntreAjusterAvisConformiteMedResidents>()).Returns(new ParamSortiAjusterAvisConformiteMedResidents());
            ajusterAvis.VerifierSiClasseUne(classeDisp).Returns(false);

            var classeDeTest = new TraitEveneAutreSys(ajusterAvis, Substitute.For<ITraiterAdmissProf>());

            var intrant = new ParamEntreAjusterAvisConformiteMedResidents()
            {
                PvcClaDisp = classeDisp,
                IndNoSeq = 12345,
                DisNoSeq = 54321
            };

            var sortant = classeDeTest.AjusterAvisConformiteMedResidents(intrant);

            ajusterAvis.Received(1).VerifierSiClasseUne(classeDisp);
            ajusterAvis.DidNotReceiveWithAnyArgs().ObtenirDispensateursAssociesDeClasseCinq(Arg.Any<int>());
            Assert.False(sortant.InfoMsgTrait.Any());
        }

        [Theory]
        [InlineData(1)]
        public void AjusterAvisConformiteMedResidents_ClasseEstATraiter_OK(int classeDisp)
        {
            var ajusterAvis = Substitute.For<IAjusterAvisConformite>();
            ajusterAvis.VerifierParametresEntree(Arg.Any<ParamEntreAjusterAvisConformiteMedResidents>()).Returns(new ParamSortiAjusterAvisConformiteMedResidents());
            ajusterAvis.VerifierSiClasseUne(classeDisp).Returns(true);
            ajusterAvis.VerifierSiMedResidentPresent(Arg.Any<List<long>>()).Returns(false);

            var classeDeTest = new TraitEveneAutreSys(ajusterAvis, Substitute.For<ITraiterAdmissProf>());

            var intrant = new ParamEntreAjusterAvisConformiteMedResidents()
            {
                PvcClaDisp = classeDisp,
                IndNoSeq = 12345,
                DisNoSeq = 54321
            };

            var sortant = classeDeTest.AjusterAvisConformiteMedResidents(intrant);

            ajusterAvis.Received(1).VerifierSiClasseUne(classeDisp);
            ajusterAvis.Received(1).ObtenirDispensateursAssociesDeClasseCinq(Arg.Any<int>());
            ajusterAvis.DidNotReceiveWithAnyArgs().ObtenirIDAvisConformiteAModifier(Arg.Any<List<long>>());
            Assert.False(sortant.InfoMsgTrait.Any());
        }

        [Fact]
        public void AjusterAvisConformiteMedResidents_IndividuSansDispensateurClasseCinq_OK()
        {
            var ajusterAvis = Substitute.For<IAjusterAvisConformite>();
            ajusterAvis.VerifierParametresEntree(Arg.Any<ParamEntreAjusterAvisConformiteMedResidents>()).Returns(new ParamSortiAjusterAvisConformiteMedResidents());
            ajusterAvis.VerifierSiClasseUne(Arg.Any<int>()).Returns(true);
            ajusterAvis.VerifierSiMedResidentPresent(Arg.Any<List<long>>()).Returns(true);
            ajusterAvis.VerifierSiAvisATraiter(Arg.Any<List<long>>()).Returns(false);

            var classeDeTest = new TraitEveneAutreSys(ajusterAvis, Substitute.For<ITraiterAdmissProf>());

            var intrant = new ParamEntreAjusterAvisConformiteMedResidents()
            {
                PvcClaDisp = 1,
                IndNoSeq = 12345,
                DisNoSeq = 54321
            };

            var sortant = classeDeTest.AjusterAvisConformiteMedResidents(intrant);

            ajusterAvis.Received(1).VerifierSiClasseUne(Arg.Any<int>());
            ajusterAvis.Received(1).ObtenirDispensateursAssociesDeClasseCinq(Arg.Any<int>());
            ajusterAvis.Received(1).ObtenirIDAvisConformiteAModifier(Arg.Any<List<long>>());
            ajusterAvis.DidNotReceiveWithAnyArgs().ModifierAvisConformiteACorriger(Arg.Any<long>(), Arg.Any<List<long>>());
            Assert.False(sortant.InfoMsgTrait.Any());
        }

        [Theory]
        [InlineAutoData]
        public void AjusterAvisConformiteMedResidents_IndividuAvecDispensateurClasseCinq_OK(int noSequentielIndiv, long noSequentielDisp, long numAvis)
        {
            var ajusterAvis = Substitute.For<IAjusterAvisConformite>();
            ajusterAvis.VerifierParametresEntree(Arg.Any<ParamEntreAjusterAvisConformiteMedResidents>()).Returns(new ParamSortiAjusterAvisConformiteMedResidents());
            ajusterAvis.VerifierSiClasseUne(Arg.Any<int>()).Returns(true);
            ajusterAvis.VerifierSiMedResidentPresent(Arg.Any<List<long>>()).Returns(true);
            ajusterAvis.VerifierSiAvisATraiter(Arg.Any<List<long>>()).Returns(true);
            ajusterAvis.ObtenirIDAvisConformiteAModifier(Arg.Any<List<long>>()).Returns(new List<long>() { numAvis });

            var classeDeTest = new TraitEveneAutreSys(ajusterAvis, Substitute.For<ITraiterAdmissProf>());

            var intrant = new ParamEntreAjusterAvisConformiteMedResidents()
            {
                PvcClaDisp = 1,
                IndNoSeq = noSequentielIndiv,
                DisNoSeq = noSequentielDisp
            };

            var sortant = classeDeTest.AjusterAvisConformiteMedResidents(intrant);

            ajusterAvis.Received(1).VerifierSiClasseUne(Arg.Any<int>());
            ajusterAvis.Received(1).ObtenirDispensateursAssociesDeClasseCinq(Arg.Any<int>());
            ajusterAvis.Received(1).ObtenirIDAvisConformiteAModifier(Arg.Any<List<long>>());
            ajusterAvis.Received(1).ModifierAvisConformiteACorriger(intrant.DisNoSeq, Arg.Is<List<long>>(x => x.Contains(numAvis)));
            Assert.False(sortant.InfoMsgTrait.Any());
        }
        #endregion

        #region TraiterAdmissibiliteDuProfessionnel

        [Theory]
        [InlineData(Constantes.MessageEvenementSuppression)]
        public void TraiterAdmissibiliteDuProfessionnel_EmprunteCheminSuppression_OK(string messageEvenement)
        {
            var traiterAdmiss = Substitute.For<ITraiterAdmissProf>();
            traiterAdmiss.EstUnEvenementDeSuppression(messageEvenement).Returns(true);
            traiterAdmiss.TraiterEvenementSuppression(Arg.Any<ParamEntreTraiterAdmissProf>())
                .Returns(new ParamSortiTraiterAdmissProf());

            var classeDeTest = new TraitEveneAutreSys(Substitute.For<IAjusterAvisConformite>(), traiterAdmiss);

            var intrant = new ParamEntreTraiterAdmissProf()
            {
                DHEvenement = DateTime.Now,
                DisNoSeq = 12345,
                MessageEvenement = messageEvenement
            };

            try
            {
                classeDeTest.TraiterAdmissibiliteDuProfessionnel(intrant);
            }
            catch (Exception)
            {

            }

            traiterAdmiss.Received(1).TraiterEvenementSuppression(Arg.Any<ParamEntreTraiterAdmissProf>());
        }

        [Theory]
        [InlineData(Constantes.MessageEvenementAjout)]
        public void TraiterAdmissibiliteDuProfessionnel_EmprunteCheminAjout_OK(string messageEvenement)
        {
            var traiterAdmiss = Substitute.For<ITraiterAdmissProf>();
            traiterAdmiss.EstUnEvenementDAjout(messageEvenement).Returns(true);
            traiterAdmiss.TraiterEvenementSuppression(Arg.Any<ParamEntreTraiterAdmissProf>())
                .Returns(new ParamSortiTraiterAdmissProf());

            var classeDeTest = new TraitEveneAutreSys(Substitute.For<IAjusterAvisConformite>(), traiterAdmiss);

            var intrant = new ParamEntreTraiterAdmissProf()
            {
                DHEvenement = DateTime.Now,
                DisNoSeq = 12345,
                MessageEvenement = messageEvenement
            };

            try
            {
                classeDeTest.TraiterAdmissibiliteDuProfessionnel(intrant);
            }
            catch (Exception)
            {

            }

            traiterAdmiss.Received(1).TraiterEvenementAjoutModification(Arg.Any<ParamEntreTraiterAdmissProf>());
        }

        [Theory]
        [InlineData(Constantes.MessageEvenementAjout)]
        public void TraiterAdmissibiliteDuProfessionnel_EmprunteCheminModification_OK(string messageEvenement)
        {
            var traiterAdmiss = Substitute.For<ITraiterAdmissProf>();
            traiterAdmiss.EstUnEvenementDeModification(messageEvenement).Returns(true);
            traiterAdmiss.TraiterEvenementSuppression(Arg.Any<ParamEntreTraiterAdmissProf>())
                .Returns(new ParamSortiTraiterAdmissProf());

            var classeDeTest = new TraitEveneAutreSys(Substitute.For<IAjusterAvisConformite>(), traiterAdmiss);

            var intrant = new ParamEntreTraiterAdmissProf()
            {
                DHEvenement = DateTime.Now,
                DisNoSeq = 12345,
                MessageEvenement = messageEvenement
            };

            try
            {
                classeDeTest.TraiterAdmissibiliteDuProfessionnel(intrant);
            }
            catch (Exception)
            {

            }

            traiterAdmiss.Received(1).TraiterEvenementAjoutModification(Arg.Any<ParamEntreTraiterAdmissProf>());
        }

        #endregion


        #region Gestion des evenements A4-A8

        #region Constructeur
        [Fact]
        public void AjusterEngagAvisConfNonParticipation_parametreConstructeurManquant_Erreur()
        {
            Assert.ThrowsAny<Exception>(() => new AjusterEngagAvisConfNonParticipation(null, null, null, null));
        }

        [Fact]
        public void AjusterEngagAvisConfNonParticipation_PremierParametreConstructeurManquant_Erreur()
        {
            Assert.ThrowsAny<Exception>(() => new AjusterEngagAvisConfNonParticipation(null, _derogation, _autorisation, null));
        }

        [Fact]
        public void AjusterEngagAvisConfNonParticipation_SecondParameterConstructeurManquant_Erreur()
        {
            Assert.ThrowsAny<Exception>(() => new AjusterEngagAvisConfNonParticipation(_avisConformite, null, _autorisation, null));
        }

        [Fact]
        public void AjusterEngagAvisConfNonParticipation_TroisiemeParameterConstructeurManquant_Erreur()
        {
            Assert.ThrowsAny<Exception>(() => new AjusterEngagAvisConfNonParticipation(_avisConformite, _derogation, null, null));
        }

        [Fact]
        public void AjusterEngagAvisConfNonParticipation_QuatriemeParameterConstructeurManquant_Erreur()
        {
            Assert.ThrowsAny<Exception>(() => new AjusterEngagAvisConfNonParticipation(_avisConformite, _derogation, _autorisation, null));
        }

        #endregion

        #region A4

        #region Avis de Conformite
        [Fact]
        public void TraiterEngagementActifNonParticipation_test_OK()
        {
            //Arrange
            var planRegMdcal = Substitute.For<PRE_AccesDonne_cpo.PlanRegnMdcal.IPlanRegnMdcal>();
            var ajusterAvisConformite = new AvisConformite(planRegMdcal);

            var extrant = Fixture.Create<PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ObtenirLesAvisConformiteSorti>();
            planRegMdcal.ObtenirLesAvisConformite(Arg.Any<PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ObtenirLesAvisConformiteEntre>()).Returns(extrant);
            //Act                    
            var obtenirLesAvisConformiteEntre = Fixture.Create<ObtenirLesAvisConformiteEntre>();
            var sortant = ajusterAvisConformite.ObtenirLesAvisConformite(obtenirLesAvisConformiteEntre);


            //-Assert
            planRegMdcal.Received(1).ObtenirLesAvisConformite(Arg.Any<PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ObtenirLesAvisConformiteEntre>());

        }



        [Fact]
        public void ObtenirAvisConfActifNonParticipation_AucunEngagDDNONPartn_OK()
        {
            //-Arrange
            var intrantMock = Fixture.Build<ObtenirLesAvisConformiteEntre>().Without(u => u.NumeroSequentielEngagement)
                                                                              .Without(u => u.CodeRegion)
                                                                              .Without(u => u.IndicateurAttenteTransmission)
                                                                              .Without(u => u.DateDebut)
                                                                              .Without(u => u.DateFin)
                                                                              .Create();
            var extrantMock = Fixture.Create<ObtenirLesAvisConformiteSorti>();
            Random gen = new Random();
            //-Act           
            extrantMock.ListeAvisConformite.ForEach(u => u.DateHeureOccurenceInactive = intrantMock.DateRecherche.Value.AddDays(-gen.Next(3)));
            _avisConformite.ObtenirLesAvisConformite(Arg.Any<ObtenirLesAvisConformiteEntre>()).Returns(extrantMock);

            var extrant = _ajusterEngag.ObtenirLesEngagementsPratiquesProfessionnel(intrantMock);


            //-Assert
            Assert.Collection(extrant.ListeAvisConformite, item => Assert.True(item.DateHeureOccurenceInactive <= intrantMock.DateRecherche),
                                                           item => Assert.True(item.DateHeureOccurenceInactive <= intrantMock.DateRecherche),
                                                           item => Assert.True(item.DateHeureOccurenceInactive <= intrantMock.DateRecherche));
        }


        [Fact]
        public void ObtenirAvisConfActifNonParticipation_UnEngagOuPlusTrouvDDNONPartn_OK()
        {
            //-Arrange
            #region Arrange
            var intrantMock = Fixture.Build<ObtenirLesAvisConformiteEntre>().Without(u => u.NumeroSequentielEngagement)
                                                                             .Without(u => u.CodeRegion)
                                                                             .Without(u => u.IndicateurAttenteTransmission)
                                                                             .Without(u => u.DateDebut)
                                                                             .Without(u => u.DateFin)
                                                                         .Create();

            var extrantMock = Fixture.Create<ObtenirLesAvisConformiteSorti>();
            Random gen = new Random();

            extrantMock.ListeAvisConformite[0].DateHeureOccurenceInactive = null;
            extrantMock.ListeAvisConformite[0].ListeStatutAvisConformite[0].StatutEngagement = "AUT";
            extrantMock.ListeAvisConformite[0].ListeStatutAvisConformite[1].StatutEngagement = "ANN";
            extrantMock.ListeAvisConformite[0].ListeStatutAvisConformite[2].StatutEngagement = "TER";

            extrantMock.ListeAvisConformite[0].DateDebutEngagement = intrantMock.DateRecherche.Value.AddDays(-gen.Next(3));
            extrantMock.ListeAvisConformite[1].DateHeureOccurenceInactive = null;
            extrantMock.ListeAvisConformite[1].ListeStatutAvisConformite[0].StatutEngagement = "SUS";
            extrantMock.ListeAvisConformite[1].ListeStatutAvisConformite[1].StatutEngagement = "AUT";

            extrantMock.ListeAvisConformite[1].DateDebutEngagement = intrantMock.DateRecherche.Value.AddDays(-gen.Next(3));
            extrantMock.ListeAvisConformite[1].DateHeureOccurenceInactive = null;
            #endregion

            foreach (var item in extrantMock.ListeAvisConformite)
            {
                item.ListeStatutAvisConformite = item.ListeStatutAvisConformite.Where(w => w.StatutEngagement == "AUT" || w.StatutEngagement == "SUS").ToList();

            }
            _ajusterEngag.ObtenirLesEngagementsPratiquesProfessionnel(Arg.Any<ObtenirLesAvisConformiteEntre>()).Returns(extrantMock);

            //-Act
            #region Act 
            var extrant = _ajusterEngag.ObtenirLesEngagementsPratiquesProfessionnel(intrantMock);

            #endregion

            //-Assert
            if (extrant.ListeAvisConformite[0].DateDebutEngagement < extrant.ListeAvisConformite[0].DateFinEngagement.Value)
            {
                Assert.InRange(intrantMock.DateRecherche.Value, extrant.ListeAvisConformite[0].DateDebutEngagement, extrant.ListeAvisConformite[0].DateFinEngagement.Value);
            }

            Assert.True(extrant.ListeAvisConformite[1].DateDebutEngagement <= intrantMock.DateRecherche && extrant.ListeAvisConformite[1].DateHeureOccurenceInactive == null);

            Assert.True(extrantMock.ListeAvisConformite[0].ListeStatutAvisConformite.Count.Equals(1));

            Assert.True(extrantMock.ListeAvisConformite[1].ListeStatutAvisConformite.Count.Equals(2));
        }


        [Fact]
        public void TraiterAvisConfActifNonParticipation_UnEngagAvecUnStatutEngagTrouvDDNONPartn_FermetureOK()
        {
            //--- cas d'une seule occurence de statut(AUT,SUS) pour l'avis de conformité
            //-Arrange
            #region Arrange
            Fixture.Customizations.Add(new TypeRelay(
                                                   typeof(IMsgTrait),
                                                   typeof(MsgTrait)
                                                   )
                                     );
            var intrantMock = Fixture.Build<ObtenirLesAvisConformiteEntre>().Without(u => u.NumeroSequentielEngagement)
                                                                             .Without(u => u.CodeRegion)
                                                                             .Without(u => u.IndicateurAttenteTransmission)
                                                                             .Without(u => u.DateDebut)
                                                                             .Without(u => u.DateFin)
                                                                         .Create();
            var extrantMock = Fixture.Create<ObtenirLesAvisConformiteSorti>();
            Random gen = new Random();

            extrantMock.ListeAvisConformite[1].DateDebutEngagement = intrantMock.DateRecherche.Value.AddDays(-gen.Next(3));
            extrantMock.ListeAvisConformite[1].DateHeureOccurenceInactive = null;
            extrantMock.ListeAvisConformite[1].ListeStatutAvisConformite[0].StatutEngagement = "AUT";


            _ajusterEngag.ObtenirLesEngagementsPratiquesProfessionnel(Arg.Any<ObtenirLesAvisConformiteEntre>()).Returns(extrantMock);
            var extrant = _ajusterEngag.ObtenirLesEngagementsPratiquesProfessionnel(intrantMock);

            ModifierPeriodeAvisEntre modifierPeriodeAvisEntre = Fixture.Build<ModifierPeriodeAvisEntre>().With(u => u.NumeroSequentielEngagement, extrantMock.ListeAvisConformite[1].NumeroSequentielEngagement)
                                                                                                         .With(u => u.DateDebutActuelle, extrantMock.ListeAvisConformite[1].DateDebutEngagement)
                                                                                                         .With(u => u.DateDebutNouvelle, extrantMock.ListeAvisConformite[1].DateDebutEngagement)
                                                                                                         .With(u => u.DateFinActuelle, intrantMock.DateRecherche.Value.AddDays(-1))
                                                                                                         .With(u => u.IdentifiantMAJ, "PLF1")
                                                                     .Create();

            ModifierPeriodeAvisSorti modifierPeriodeAvisSorti = Fixture.Create<ModifierPeriodeAvisSorti>();
            #endregion
            //-Act

            #region Act
            _ajusterEngag.ModifierPeriodeLesAvisConformites(Arg.Any<ModifierPeriodeAvisEntre>()).Returns(modifierPeriodeAvisSorti);
            var result = _ajusterEngag.ModifierPeriodeLesAvisConformites(modifierPeriodeAvisEntre);

            ModifierRaisFermStatutEngagEntre modifierRaisFermStatutEngagEntre = Fixture.Build<ModifierRaisFermStatutEngagEntre>().With(u => u.NumeroSequentielStatutEngagement, extrantMock.ListeAvisConformite[1].ListeStatutAvisConformite[0].NumeroSequentielEngagement)
                                                                                                                               .With(u => u.IdentifiantMAJ, "PLF1")
                                                                                                                               .With(u => u.CodeRaisonStatut, "21")
                                                                                     .Create();
            ModifierRaisFermStatutEngagSorti modifierRaisFermStatutEngagSorti = Fixture.Create<ModifierRaisFermStatutEngagSorti>();
            _ajusterEngag.ModifierRaisonFermetureStatEngag(Arg.Any<ModifierRaisFermStatutEngagEntre>()).Returns(modifierRaisFermStatutEngagSorti);
            var res = _ajusterEngag.ModifierRaisonFermetureStatEngag(modifierRaisFermStatutEngagEntre);

            #endregion

            //-Assert
            Assert.True(result.DateHeureOccurence.HasValue);

            Assert.True(res.DateHeureOccurence.HasValue);


        }


        [Theory]
        [InlineAutoData]
        public void ObtenirLesAvisConfPostProfessionnel_AvisConformites_Ok(long numseqDispensateur, DateTime dDNonPartn, bool post)
        {
            //-Arrange
            var extrantMock = Fixture.Create<ObtenirLesAvisConformiteSorti>();
            extrantMock.ListeAvisConformite[0].ListeStatutAvisConformite[0].StatutEngagement = "AUT";
            extrantMock.ListeAvisConformite[0].ListeStatutAvisConformite[0].DateFinStatutEngagement = null;
            _avisConformite.ObtenirLesAvisConformite(Arg.Any<ObtenirLesAvisConformiteEntre>()).Returns(extrantMock);

            //-Act
            var extrant = _ajusterEngag.ObtenirLesAvisConfPostProfessionnel(numseqDispensateur, dDNonPartn, post);

            //-Assert
            Assert.True(extrant.Count > 0);
        }

        [Fact]
        public void FermerAvisConfProfessionel_FermetureAvisUnStat_OK()
        {
            //-Arrange
            Fixture.Customizations.Add(new TypeRelay(
                                                   typeof(IMsgTrait),
                                                   typeof(MsgTrait)
                                                   )
                                     );
            var intrantMock = Fixture.Create<ObtenirLesAvisConformiteSorti>();
            var lstObjParametre = intrantMock.ListeAvisConformite;
            var mockPeriodeAvisSorti = Fixture.Create<ModifierPeriodeAvisSorti>();
            var mockRais = Fixture.Create<ModifierRaisFermStatutEngagSorti>();
            _avisConformite.ModifierPeriodeAvis(Arg.Any<ModifierPeriodeAvisEntre>()).Returns(mockPeriodeAvisSorti);
            _avisConformite.ModifierRaisFermStatutEngag(Arg.Any<ModifierRaisFermStatutEngagEntre>()).Returns(mockRais);

            DateTime dDNonPartn = new DateTime(2017, 2, 25);

            lstObjParametre[0].DateDebutEngagement = new DateTime(2017, 1, 2);
            var lstStatuSEngag = lstObjParametre[0].ListeStatutAvisConformite;
            lstStatuSEngag[0].DateFinStatutEngagement = null;
            lstStatuSEngag[0].DateDebutStatutEngagement = new DateTime(2017, 1, 2);
            lstStatuSEngag[0].StatutEngagement = "AUT";


            lstObjParametre.RemoveAt(1);
            lstObjParametre.RemoveAt(1);
            lstStatuSEngag.RemoveAt(1);
            lstStatuSEngag.RemoveAt(1);

            var codRaisonStatutEntre = Constante.CodeRaisonStatutAvisConf_DateNonPartn;
            //-Act
            var extrant = _ajusterEngag.FermerAvisConfProfessionel(lstObjParametre, dDNonPartn, codRaisonStatutEntre);

            //-Assert

            Assert.NotNull(extrant);


        }

        [Fact]
        public void FermerAvisConfProfessionel_FermetureAvisPlusieursStat_OK()
        {
            //-Arrange
            //-DAte denon participartion posterieur a date debut du dernier statut actif
            Fixture.Customizations.Add(new TypeRelay(
                                                   typeof(IMsgTrait),
                                                   typeof(MsgTrait)
                                                   )
                                     );
            var intrantMock = Fixture.Create<ObtenirLesAvisConformiteSorti>();
            var lstObjParametre = intrantMock.ListeAvisConformite;
            var mockPeriodeAvisSorti = Fixture.Create<ModifierPeriodeAvisSorti>();
            var mockRais = Fixture.Create<ModifierRaisFermStatutEngagSorti>();
            _avisConformite.ModifierPeriodeAvis(Arg.Any<ModifierPeriodeAvisEntre>()).Returns(mockPeriodeAvisSorti);
            _avisConformite.ModifierRaisFermStatutEngag(Arg.Any<ModifierRaisFermStatutEngagEntre>()).Returns(mockRais);

            //DateTime dDNonPartn = new DateTime(2017, 2, 25);
            lstObjParametre.RemoveAt(1);
            lstObjParametre.RemoveAt(1);
            DateTime dDNonPartn = new DateTime(2018, 6, 6);
            var lstStatuSEngag = lstObjParametre[0].ListeStatutAvisConformite;

            lstObjParametre[0].DateDebutEngagement = new DateTime(2004, 3, 1);

            lstStatuSEngag[2].DateDebutStatutEngagement = new DateTime(2018, 5, 1);
            lstStatuSEngag[2].StatutEngagement = "AUT";
            lstStatuSEngag[2].DateFinStatutEngagement = null; // Non fourni : toujours en cours

            lstStatuSEngag[1].DateFinStatutEngagement = new DateTime(2018, 4, 30);
            lstStatuSEngag[1].DateDebutStatutEngagement = new DateTime(2018, 4, 1);
            lstStatuSEngag[1].StatutEngagement = "SUS";

            lstStatuSEngag[0].DateFinStatutEngagement = new DateTime(2018, 3, 31);
            lstStatuSEngag[0].DateDebutStatutEngagement = new DateTime(2004, 3, 1);
            lstStatuSEngag[0].StatutEngagement = "AUT";

            var codRaisonStatutEntre = Constante.CodeRaisonStatutAvisConf_DateNonPartn;
            //-Act
            var extrant = _ajusterEngag.FermerAvisConfProfessionel(lstObjParametre, dDNonPartn, codRaisonStatutEntre);

            //-Assert

            Assert.NotNull(extrant);


        }

        [Fact]
        public void FermerAvisConfProfessionel_FermetureAvisPlusieursStat1_OK()
        {
            //-Arrange
            Fixture.Customizations.Add(new TypeRelay(
                                                   typeof(IMsgTrait),
                                                   typeof(MsgTrait)
                                                   )
                                     );
            var intrantMock = Fixture.Create<ObtenirLesAvisConformiteSorti>();
            var lstObjParametre = intrantMock.ListeAvisConformite;
            var mockPeriodeAvisSorti = Fixture.Create<ModifierPeriodeAvisSorti>();
            mockPeriodeAvisSorti.InfoMsgTrait.Clear();
            var mockRais = Fixture.Create<ModifierRaisFermStatutEngagSorti>();
            mockRais.InfoMsgTrait.Clear();
            _avisConformite.ModifierPeriodeAvis(Arg.Any<ModifierPeriodeAvisEntre>()).Returns(mockPeriodeAvisSorti);
            _avisConformite.ModifierRaisFermStatutEngag(Arg.Any<ModifierRaisFermStatutEngagEntre>()).Returns(mockRais);

            DateTime dDNonPartn = new DateTime(2017, 2, 25);
            lstObjParametre.RemoveAt(1);
            lstObjParametre.RemoveAt(1);
      
            var lstStatuSEngag = lstObjParametre[0].ListeStatutAvisConformite;

            lstObjParametre[0].DateDebutEngagement = new DateTime(2017, 1, 2);

            lstStatuSEngag[2].DateDebutStatutEngagement = new DateTime(2017, 12, 15);
            lstStatuSEngag[2].StatutEngagement = "AUT";
            lstStatuSEngag[2].DateFinStatutEngagement = null; // Non fourni : toujours en cours

            lstStatuSEngag[1].DateFinStatutEngagement = new DateTime(2017, 12, 14);
            lstStatuSEngag[1].DateDebutStatutEngagement = new DateTime(2017, 10, 4);
            lstStatuSEngag[1].StatutEngagement = "SUS";

            lstStatuSEngag[0].DateFinStatutEngagement = new DateTime(2017, 10, 3);
            lstStatuSEngag[0].DateDebutStatutEngagement = new DateTime(2017, 1, 2);
            lstStatuSEngag[0].StatutEngagement = "AUT";

            var codRaisonStatutEntre = Constante.CodeRaisonStatutAvisConf_DateNonPartn;
            //-Act
            var extrant = _ajusterEngag.FermerAvisConfProfessionel(lstObjParametre, dDNonPartn, codRaisonStatutEntre);

            //-Assert

            Assert.NotNull(extrant);


        }

        [Theory]
        [InlineAutoData]
        public void AnnulationAvisConf_AnnulationAvis_OK(long numseqDispensateur, DateTime dDNonPartn)
        {
            //-Arrange            
            var mockCeerStatus = Fixture.Create<CreerStatutAvisConformiteSorti>();
            mockCeerStatus.InfoMsgTrait.Clear();
            var mockAvis = Fixture.Create<ObtenirLesAvisConformiteSorti>();
            _avisConformite.ObtenirLesAvisConformite(Arg.Any<ObtenirLesAvisConformiteEntre>()).Returns(mockAvis);
            _avisConformite.CreerStatutAvisConformite(Arg.Any<CreerStatutAvisConformiteEntre>()).Returns(mockCeerStatus);
            //-Act
            var extrant = _ajusterEngag.AnnulerAvisConf(numseqDispensateur, dDNonPartn, Constante.CodeRaisonStatutAvisConf_DateNonPartn);

            //-Assert
            Assert.True(extrant.Count == 0);
        }


        #endregion

        #region Derogation

        [Theory]
        [InlineAutoData]
        public void ObtenirLesDerogationsActivPostProfessionnel_derogationActiveRetourner_OK(long numseqDispensateur, DateTime dDNonPartn, bool post)
        {
            //-Arrange
            var extMockDerog = Fixture.Create<EntiteCPO.ObtenirDerogationsProfessionnelSanteSorti>();
            extMockDerog.Derogations[0].Statut = "AUT";
            extMockDerog.Derogations[0].DateDebut = dDNonPartn.AddDays(-5);
            extMockDerog.Derogations[0].DateHeureInactivationOccurence = null;
            extMockDerog.Derogations[1].Statut = "ANN";
            extMockDerog.Derogations[2].Statut = "AUT";
            extMockDerog.Derogations[2].DateDebut = dDNonPartn.AddDays(2);
            extMockDerog.Derogations[2].DateHeureInactivationOccurence = null;
            _derogation.ObtenirDerogationProfessionnel(Arg.Any<EntiteCPO.ObtenirDerogationsProfessionnelSanteEntre>()).Returns(extMockDerog);
            
            //-Act       
            var extrant = _ajusterEngag.ObtenirLesDerogationsActivPostProfessionnel(numseqDispensateur, dDNonPartn, post);
            //-Assert
            Assert.True(extrant.Count > 0);



        }

        [Theory]
        [InlineAutoData]
        public void ObtenirLesDerogationsActivPostProfessionnel_derogationActiveAFermer_Aucune(long numseqDispensateur, DateTime dDNonPartn, bool post)
        {
            //-Arrange
            var extMockDerog = Fixture.Create<EntiteCPO.ObtenirDerogationsProfessionnelSanteSorti>();
            extMockDerog.Derogations[0].Statut = "AUT";
            extMockDerog.Derogations[0].DateDebut = dDNonPartn.AddDays(2);
            extMockDerog.Derogations[0].DateFin = null;
            extMockDerog.Derogations[0].DateHeureInactivationOccurence = null;
           
            extMockDerog.Derogations[1].Statut = "TER";
            extMockDerog.Derogations[1].DateDebut = dDNonPartn.AddDays(2);
            extMockDerog.Derogations[1].DateFin = dDNonPartn.AddDays(10); 
            extMockDerog.Derogations[1].DateHeureInactivationOccurence = null;

            extMockDerog.Derogations[2].Statut = "ANN";

            _derogation.ObtenirDerogationProfessionnel(Arg.Any<EntiteCPO.ObtenirDerogationsProfessionnelSanteEntre>()).Returns(extMockDerog);
            post = false;
            //-Act       
            var extrant = _ajusterEngag.ObtenirLesDerogationsActivPostProfessionnel(numseqDispensateur, dDNonPartn, post);
            //-Assert
            Assert.True(extrant.Count == 0);



        }
        [Theory]
        [InlineAutoData]
        public void ObtenirLesDerogationsActivPostProfessionnel_derogationActiveAFermer_Trouve(long numseqDispensateur, DateTime dDNonPartn, bool post)
        {
            //-Arrange
            var extMockDerog = Fixture.Create<EntiteCPO.ObtenirDerogationsProfessionnelSanteSorti>();
            extMockDerog.Derogations[0].Statut = "AUT";
            extMockDerog.Derogations[0].DateDebut = dDNonPartn.AddDays(-5);
            extMockDerog.Derogations[0].DateFin = null;
            extMockDerog.Derogations[0].DateHeureInactivationOccurence = null;

            extMockDerog.Derogations[1].Statut = "TER";
            extMockDerog.Derogations[1].DateDebut = dDNonPartn.AddDays(-5);
            //extMockDerog.Derogations[1].DateFin = dDNonPartn.AddDays(-1);
            extMockDerog.Derogations[1].DateFin = dDNonPartn.AddDays(25);
            extMockDerog.Derogations[1].DateHeureInactivationOccurence = null;

            extMockDerog.Derogations[2].Statut = "ANN";
            _derogation.ObtenirDerogationProfessionnel(Arg.Any<EntiteCPO.ObtenirDerogationsProfessionnelSanteEntre>()).Returns(extMockDerog);
            post = false;
            //-Act       
            var extrant = _ajusterEngag.ObtenirLesDerogationsActivPostProfessionnel(numseqDispensateur, dDNonPartn, post);
            //-Assert
            Assert.True(extrant.Count > 0);



        }

        [Theory]
        [InlineAutoData]
        public void ObtenirLesDerogationsActivPostProfessionnel_derogationActiveAFermerAUTetTER_Trouve(long numseqDispensateur, DateTime dDNonPartn, bool post)
        {
            //-Arrange
            //--la derneire derogation est toujours en cours...
            var extMockDerog = Fixture.Create<EntiteCPO.ObtenirDerogationsProfessionnelSanteSorti>();
            extMockDerog.Derogations[0].Statut = "AUT";
            extMockDerog.Derogations[0].DateDebut = dDNonPartn.AddDays(-5);
            extMockDerog.Derogations[0].DateFin = null;
            extMockDerog.Derogations[0].DateHeureInactivationOccurence = null;

            extMockDerog.Derogations[1].Statut = "TER";
            extMockDerog.Derogations[1].DateDebut = dDNonPartn.AddDays(-5);
            //extMockDerog.Derogations[1].DateFin = dDNonPartn.AddDays(-1);
            extMockDerog.Derogations[1].DateFin = dDNonPartn.AddDays(25);
            extMockDerog.Derogations[1].DateHeureInactivationOccurence = null;

            extMockDerog.Derogations[2].Statut = "AUT";
            extMockDerog.Derogations[2].DateDebut = dDNonPartn.AddDays(-2);
            extMockDerog.Derogations[2].DateFin = null;

            _derogation.ObtenirDerogationProfessionnel(Arg.Any<EntiteCPO.ObtenirDerogationsProfessionnelSanteEntre>()).Returns(extMockDerog);
            post = false;
            //-Act       
            var extrant = _ajusterEngag.ObtenirLesDerogationsActivPostProfessionnel(numseqDispensateur, dDNonPartn, post);
            //-Assert
            Assert.True(extrant.Count > 0);



        }

        [Theory]
        [InlineAutoData]
        public void ObtenirLesDerogModifActivPostProfessionnel_derogationActiveRetourner_OK(long numseqDispensateur, DateTime dDNonPartn, bool post)
        {
            //-Arrange
            var extMockDerog = Fixture.Create<EntiteCPO.ObtenirDerogationsProfessionnelSanteSorti>();
            extMockDerog.Derogations[0].Statut = "AUT";
            extMockDerog.Derogations[0].DateDebut = dDNonPartn.AddDays(-5);
            extMockDerog.Derogations[0].DateHeureInactivationOccurence = null;
            extMockDerog.Derogations[1].Statut = "ANN";
            extMockDerog.Derogations[1].DateDebut = dDNonPartn.AddDays(12);
            extMockDerog.Derogations[2].Statut = "AUT";
            extMockDerog.Derogations[2].DateDebut = dDNonPartn.AddDays(2);
            extMockDerog.Derogations[2].DateHeureInactivationOccurence = null;
            _derogation.ObtenirDerogationProfessionnel(Arg.Any<EntiteCPO.ObtenirDerogationsProfessionnelSanteEntre>()).Returns(extMockDerog);

            //-Act       
            var extrant = _ajusterEngag.ObtenirLesDerogModifActivPostProfessionnel(numseqDispensateur, dDNonPartn, post);
            //-Assert
            Assert.True(extrant.Count > 0);



        }

        [Fact]
        public void FermerDerogationProfessionel_FermetureDerogation_OK()
        {
            //-Arrange
            string codeRaison = "7";
            var intrantMock = Fixture.Create<EntiteCPO.ModifierDerogationEntre>();
            intrantMock.CodeRaisonStatut = codeRaison;

            var extrantMock = Fixture.Create<EntiteCPO.ModifierDerogationSorti>();

            extrantMock.NouveauNumeroSequentiel = 914589;
            extrantMock.InfoMsgTrait.Clear();
            _derogation.ModifierDerogation(Arg.Any<EntiteCPO.ModifierDerogationEntre>()).Returns(extrantMock);
            DateTime datDebNonPartn = new DateTime(2018, 4, 10);

            //-Act
            var extrant = _ajusterEngag.FermerDerogationProfessionel(intrantMock, datDebNonPartn);

            //-Assert             
            Assert.True(extrant.NouveauNumeroSequentiel.Equals(extrantMock.NouveauNumeroSequentiel));
            

        }

        [Fact]
        public void AnnulationDerogation_AnnulationDerogation_OK()
        {
            //-Arrange
            string codeRaison = "7";
            var intrantMock = Fixture.Create<EntiteCPO.ModifierDerogationEntre>();
            intrantMock.CodeRaisonStatut = codeRaison;
            var extrantMock = Fixture.Create<EntiteCPO.ModifierDerogationSorti>();
            extrantMock.NouveauNumeroSequentiel = 10001;

            extrantMock.InfoMsgTrait.Clear();
            _derogation.ModifierDerogation(Arg.Any<EntiteCPO.ModifierDerogationEntre>()).Returns(extrantMock);


            //-Act          
            var extrant = _ajusterEngag.AnnulationDerogationPosterieurDateNonPartipation(intrantMock);

            //-Assert
            Assert.True(extrant.NouveauNumeroSequentiel.Equals(extrantMock.NouveauNumeroSequentiel));

        }

        [Fact]
        public void TraiterDerogationDateNonParticipation_Traitement_OK()
        {
            //-Arrange
            long numseq = 180211;
            DateTime datDebNonpartn = new DateTime(2018, 4, 20);
            string codRaisonStatut = Constante.CodeRaisonStatutDerogation_DateNonPartn;

            var extMockDerog = Fixture.Create<EntiteCPO.ObtenirDerogationsProfessionnelSanteSorti>();
            extMockDerog.Derogations[0].Statut = "AUT";
            extMockDerog.Derogations[0].DateDebut = datDebNonpartn.AddDays(-5);
            extMockDerog.Derogations[0].DateFin = datDebNonpartn.AddDays(4);

            extMockDerog.Derogations[1].Statut = "ANN";
            extMockDerog.Derogations[2].Statut = "AUT";
            extMockDerog.Derogations[2].DateDebut = datDebNonpartn.AddDays(2);
            _derogation.ObtenirDerogationProfessionnel(Arg.Any<EntiteCPO.ObtenirDerogationsProfessionnelSanteEntre>()).Returns(extMockDerog);
            var extrantMock = Fixture.Create<EntiteCPO.ModifierDerogationSorti>();
            extrantMock.NouveauNumeroSequentiel = 914589;
            extrantMock.InfoMsgTrait.Clear();
            _derogation.ModifierDerogation(Arg.Any<EntiteCPO.ModifierDerogationEntre>()).Returns(extrantMock);

            //-Act         
           // var resultDerogation = _ajusterEngag.TraiterDerogationDateNonParticipation(numseq, datDebNonpartn, codRaisonStatut);
            var resultDerogation = _ajusterEngag.TraiterDerogationDateNonParticipation(numseq, datDebNonpartn, codRaisonStatut,true);

            //-Assert           
            //Assert.True(resultDerogation.Count==0);
            Assert.True(resultDerogation.EstTraite);
        }


        [Fact]
        public void TraiterDerogationModifDateNonParticipation_Traitement_OK()
        {
            //-Arrange
            long numseq = 180211;
            DateTime datDebNonpartn = new DateTime(2018, 4, 20);
            string codRaisonStatut = Constante.CodeRaisonStatutDerogation_DateNonPartn;

            var extMockDerog = Fixture.Create<EntiteCPO.ObtenirDerogationsProfessionnelSanteSorti>();
            extMockDerog.Derogations[0].Statut = "AUT";
            extMockDerog.Derogations[0].DateDebut = datDebNonpartn.AddDays(-5);
            extMockDerog.Derogations[0].DateFin = datDebNonpartn.AddDays(4);

            extMockDerog.Derogations[1].Statut = "ANN";
            extMockDerog.Derogations[2].Statut = "AUT";
            extMockDerog.Derogations[2].DateDebut = datDebNonpartn.AddDays(2);
            _derogation.ObtenirDerogationProfessionnel(Arg.Any<EntiteCPO.ObtenirDerogationsProfessionnelSanteEntre>()).Returns(extMockDerog);
            var extrantMock = Fixture.Create<EntiteCPO.ModifierDerogationSorti>();
            extrantMock.NouveauNumeroSequentiel = 914589;
            extrantMock.InfoMsgTrait.Clear();
            _derogation.ModifierDerogation(Arg.Any<EntiteCPO.ModifierDerogationEntre>()).Returns(extrantMock);

            //-Act         
            // var resultDerogation = _ajusterEngag.TraiterDerogationDateNonParticipation(numseq, datDebNonpartn, codRaisonStatut);
            var resultDerogation = _ajusterEngag.TraiterDerogationDateNonParticipation(numseq, datDebNonpartn, codRaisonStatut, false);

            //-Assert           
            //Assert.True(resultDerogation.Count==0);
            Assert.True(resultDerogation.EstTraite);
        }

        [Fact]
        public void TraiterDerogationDateNonParticipation_Traitement_KO()
        {
            //-Arrange
            long numseq = 180211;
            DateTime datDebNonpartn = new DateTime(2018, 4, 20);
            string codRaisonStatut = Constante.CodeRaisonStatutDerogation_DateNonPartn;

            var extMockDerog = Fixture.Create<EntiteCPO.ObtenirDerogationsProfessionnelSanteSorti>();
            extMockDerog.Derogations[0].Statut = "AUT";
            extMockDerog.Derogations[0].DateDebut = datDebNonpartn.AddDays(-5);
            extMockDerog.Derogations[0].DateFin = datDebNonpartn.AddDays(4);
            extMockDerog.Derogations[0].DateHeureInactivationOccurence = null;

            extMockDerog.Derogations[1].Statut = "ANN";
            extMockDerog.Derogations[2].Statut = "AUT";
            extMockDerog.Derogations[2].DateDebut = datDebNonpartn.AddDays(2);
            extMockDerog.Derogations[2].DateHeureInactivationOccurence = null;
            _derogation.ObtenirDerogationProfessionnel(Arg.Any<EntiteCPO.ObtenirDerogationsProfessionnelSanteEntre>()).Returns(extMockDerog);
            var extrantMock = Fixture.Create<EntiteCPO.ModifierDerogationSorti>();
            extrantMock.NouveauNumeroSequentiel = 914589;
            _derogation.ModifierDerogation(Arg.Any<EntiteCPO.ModifierDerogationEntre>()).Returns(extrantMock);

            //-Act         
            //var resultDerogation = _ajusterEngag.TraiterDerogationDateNonParticipation(numseq, datDebNonpartn, codRaisonStatut);
            var resultDerogation = _ajusterEngag.TraiterDerogationDateNonParticipation(numseq, datDebNonpartn, codRaisonStatut,true);

            //-Assert                    
            Assert.False(resultDerogation.EstTraite);
        }

        #endregion

        #region Autorisation

        [Theory]
        [InlineData(12456, false)]
        [InlineData(12456, true)]
        public void ObtenirLesAutorisationsProfessionnelSorti_Autorisations_OK(long numseqDispensateur, bool post)
        {
            //-Arrange
            DateTime dDNonPartn = new DateTime(2018, 4, 10);
            var intantMock = Fixture.Create<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre>();
            var extrantMock = Fixture.Create<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelSorti>();
            _autorisation.ObtenirAutorisationPREMQ(Arg.Any<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre>()).Returns(extrantMock);
            extrantMock.Autorisations[0].DateDebut = new DateTime(2018, 4, 01);          
            extrantMock.Autorisations[2].DateDebut = new DateTime(2018, 8, 01);
            //-Act
            var extrant = _ajusterEngag.ObtenirLesAutorisationsActivPostProfessionnel(numseqDispensateur, dDNonPartn, post);

            //-Assert            
            Assert.True(extrant.Count > 0);

        }

        [Theory]
        [InlineData(12456, false)]
        [InlineData(12456, true)]
        public void ObtenirLesAutorisationsModifProfessionnelSorti_Autorisations_OK(long numseqDispensateur, bool post)
        {
            //-Arrange
            DateTime dDNonPartn = new DateTime(2018, 4, 10);
            var intantMock = Fixture.Create<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre>();
            var extrantMock = Fixture.Create<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelSorti>();
            extrantMock.Autorisations[0].DateDebut= new DateTime(2018, 4, 01);
            extrantMock.Autorisations[0].DateFin= new DateTime(2018, 10, 10);
            extrantMock.Autorisations[0].CodeRaisonStatut = "07";

            extrantMock.Autorisations[2].DateDebut = new DateTime(2018, 8, 01);            
            extrantMock.Autorisations[2].CodeRaisonStatut = "07";
            _autorisation.ObtenirAutorisationPREMQ(Arg.Any<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre>()).Returns(extrantMock);

            //-Act
            var extrant = _ajusterEngag.ObtenirLesAutorisationsModifActivPostProfessionnel(numseqDispensateur, dDNonPartn, post);

            //-Assert            
            Assert.True(extrant.Count > 0);

        }


        [Fact]
        public void FermerAutorisationProfessionel_Fermeture_OK()
        {
            //-Arrange
            string codeRaison = "3";
            var intrantMock = Fixture.Create<ModifierAutorisationEntre>();
            intrantMock.CodeRaisonStatut = codeRaison;


            Fixture.Customizations.Add(new TypeRelay(
                                                     typeof(IMsgTrait),
                                                     typeof(MsgTrait)
                                                     )
                                       );

            var extrantMock = Fixture.Create<ModifierAutorisationSorti>();

            extrantMock.NouveauNumeroSequentiel = 814580;
            extrantMock.InfoMsgTrait.Clear();
            _autorisation.ModifierAutorisation(Arg.Any<ModifierAutorisationEntre>()).Returns(extrantMock);
            DateTime datDebNonPartn = new DateTime(2018, 4, 10);
            //-Act
            var extrant = _ajusterEngag.FermerAutorisationProfessionel(intrantMock, datDebNonPartn);

            //-Assert
            if (intrantMock.DateDebut > intrantMock.DateFin)
            {
                Assert.True(extrant == null);
            }
            else
            {
                Assert.True(extrant.NouveauNumeroSequentiel.Equals(extrantMock.NouveauNumeroSequentiel));
            }

        }


        [Fact]
        public void AnnulationAutorisation_Annulation_OK()
        {
            //-Arrange
            string codeRaison = "7";
            var intrantMock = Fixture.Create<ModifierAutorisationEntre>();
            intrantMock.CodeRaisonStatut = codeRaison;
            Fixture.Customizations.Add(new TypeRelay(typeof(IMsgTrait), typeof(MsgTrait)));
            var extrantMock = Fixture.Create<ModifierAutorisationSorti>();
            extrantMock.NouveauNumeroSequentiel = 10005;

            extrantMock.InfoMsgTrait.Clear();
            _autorisation.ModifierAutorisation(Arg.Any<ModifierAutorisationEntre>()).Returns(extrantMock);


            //-Act           
            var extrant = _ajusterEngag.AnnulationAutorisationPosterieurDateNonPartipation(intrantMock);

            //-Assert  
            Assert.True(extrant.NouveauNumeroSequentiel.Equals(extrantMock.NouveauNumeroSequentiel));

        }

        [Fact]
        public void TraiterAutorisationDateNonParticipation_Traitement_OK()
        {
            //-Arrange
            long numseq = 180211;
            DateTime datDebNonpartn = new DateTime(2018, 4, 20);
            CodeRaisonStatutAutorisation codeRaisonAut = new CodeRaisonStatutAutorisation
            {
                Fermeture = Constante.CodeRaisonStatutAutorisationFerm_DateNonPartn,
                Annulation = Constante.CodeRaisonStatutDerogation_DateNonPartn
            };

            var extMockAutor = Fixture.Create<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelSorti>();
            extMockAutor.Autorisations[0].DateDebut = datDebNonpartn.AddDays(-5);
            extMockAutor.Autorisations[0].DateFin = datDebNonpartn.AddDays(4);
            extMockAutor.Autorisations[2].DateDebut = datDebNonpartn.AddDays(2);

            _autorisation.ObtenirAutorisationPREMQ(Arg.Any<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre>()).Returns(extMockAutor);

            Fixture.Customizations.Add(new TypeRelay(
                                                    typeof(IMsgTrait),
                                                    typeof(MsgTrait)
                                                    )
                                      );

            var extMock = Fixture.Create<ModifierAutorisationSorti>();
            extMock.NouveauNumeroSequentiel = 914589;
            extMock.InfoMsgTrait.Clear();

            _autorisation.ModifierAutorisation(Arg.Any<ModifierAutorisationEntre>()).Returns(extMock);

            //-Act 
            var resultAutorisation = _ajusterEngag.TraiterAutorisationDateNonParticipation(numseq, datDebNonpartn, codeRaisonAut,false);


            //-Assert
            Assert.True(resultAutorisation.EstTraite);
        }

        [Fact]
        public void TraiterAutorisationDateNonParticipation_NouvelleDateParticipationAnterieureTraitement_OK()
        {
            //-Arrange
            long numseq = 180211;
            DateTime datDebNonpartn = new DateTime(2018, 4, 20);
            CodeRaisonStatutAutorisation codeRaisonAut = new CodeRaisonStatutAutorisation
            {
                Fermeture = Constante.CodeRaisonStatutAutorisationFerm_DateNonPartn,
                Annulation = Constante.CodeRaisonStatutDerogation_DateNonPartn
            };

            var extMockAutor = Fixture.Create<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelSorti>();
            extMockAutor.Autorisations[0].DateDebut = datDebNonpartn.AddDays(-5);
            extMockAutor.Autorisations[0].DateFin = datDebNonpartn.AddDays(4);
            extMockAutor.Autorisations[2].DateDebut = datDebNonpartn.AddDays(2);

            _autorisation.ObtenirAutorisationPREMQ(Arg.Any<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre>()).Returns(extMockAutor);

            Fixture.Customizations.Add(new TypeRelay(
                                                    typeof(IMsgTrait),
                                                    typeof(MsgTrait)
                                                    )
                                      );

            var extMock = Fixture.Create<ModifierAutorisationSorti>();
            extMock.NouveauNumeroSequentiel = 914589;
            extMock.InfoMsgTrait.Clear();

            _autorisation.ModifierAutorisation(Arg.Any<ModifierAutorisationEntre>()).Returns(extMock);

            //-Act 
            var resultAutorisation = _ajusterEngag.TraiterAutorisationDateNonParticipation(numseq, datDebNonpartn, codeRaisonAut, true);


            //-Assert
            Assert.True(resultAutorisation.EstTraite);
        }

        public void TraiterAutorisationDateNonParticipation_Traitement_KO()
        {
            //-Arrange
            long numseq = 180211;
            DateTime datDebNonpartn = new DateTime(2018, 4, 20);
            CodeRaisonStatutAutorisation codeRaisonAut = new CodeRaisonStatutAutorisation
            {
                Fermeture = Constante.CodeRaisonStatutAutorisationFerm_DateNonPartn,
                Annulation = Constante.CodeRaisonStatutDerogation_DateNonPartn
            };

            var extMockAutor = Fixture.Create<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelSorti>();
            extMockAutor.Autorisations[0].DateDebut = datDebNonpartn.AddDays(-5);
            extMockAutor.Autorisations[0].DateFin = datDebNonpartn.AddDays(4);
            extMockAutor.Autorisations[2].DateDebut = datDebNonpartn.AddDays(2);

            _autorisation.ObtenirAutorisationPREMQ(Arg.Any<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre>()).Returns(extMockAutor);

            Fixture.Customizations.Add(new TypeRelay(
                                                    typeof(IMsgTrait),
                                                    typeof(MsgTrait)
                                                    )
                                      );

            var extMock = Fixture.Create<ModifierAutorisationSorti>();
            extMock.NouveauNumeroSequentiel = 914589;
            _autorisation.ModifierAutorisation(Arg.Any<ModifierAutorisationEntre>()).Returns(extMock);

            //-Act 
            var resultAutorisation = _ajusterEngag.TraiterAutorisationDateNonParticipation(numseq, datDebNonpartn, codeRaisonAut,false);


            //-Assert
            Assert.False(resultAutorisation.EstTraite);
        }
        #endregion

        #endregion

        #region A6

        [Fact]
        public void VerificationMAJDossier_MAJDossierDatePremSpecialiteNull_Nontrouve()
        {
            //-Arrange
            DateTime dDNonPartn = new DateTime(2017, 2, 25);
            var intrantMock = Fixture.Create<ObtenirDispensateurIndividuEntre>();
            var extrantMock = Fixture.Create<ObtenirDispensateurIndividuSorti>();
            extrantMock.DatesPremiereSpecialite.Clear();

            _professionnel.ObtenirInformationProfessionnel(Arg.Any<ObtenirDispensateurIndividuEntre>()).Returns(extrantMock);
            var envoyCourlEntreMock = Fixture.Create<EnvoyCourlEntre>();
            envoyCourlEntreMock.Expediteur = System.Configuration.ConfigurationManager.AppSettings["AdresseExpediteur"];
            envoyCourlEntreMock.Destinataire = System.Configuration.ConfigurationManager.AppSettings["AdresseDestinataire"];
            var operation = OperationEvt.OperationPremièreSpecialite;
            //-Act     
            var extrant = _ajusterEngag.VerificationMAJDossier(intrantMock, dDNonPartn, envoyCourlEntreMock, operation);
            //-Assert
            Assert.True(extrant);

        }
        [Fact]
        public void VerificationMAJDossier_MAJDossierDatePremSpecialite_Nontrouve()
        {
            //-Arrange
            var intrantMock = Fixture.Create<ObtenirDispensateurIndividuEntre>();
            var extrantMock = Fixture.Create<ObtenirDispensateurIndividuSorti>();

            DateTime dDNonPartn = extrantMock.DatesPremiereSpecialite[0].Value.AddDays(10);

            _professionnel.ObtenirInformationProfessionnel(Arg.Any<ObtenirDispensateurIndividuEntre>()).Returns(extrantMock);
            var envoyCourlEntreMock = Fixture.Create<EnvoyCourlEntre>();
            envoyCourlEntreMock.Expediteur = System.Configuration.ConfigurationManager.AppSettings["AdresseExpediteur"];
            envoyCourlEntreMock.Destinataire = System.Configuration.ConfigurationManager.AppSettings["AdresseDestinataire"];
            var operation = OperationEvt.OperationNonAdmissibilite;
            //-Act     
            var extrant = _ajusterEngag.VerificationMAJDossier(intrantMock, dDNonPartn, envoyCourlEntreMock, operation);
            //-Assert
            Assert.True(extrant);

        }

        [Fact]
        public void VerificationMAJDossier_MAJDossierDatePremSpecialite_trouve()
        {
            //-Arrange 
            var intrantMock = Fixture.Create<ObtenirDispensateurIndividuEntre>();
            var extrantMock = Fixture.Create<ObtenirDispensateurIndividuSorti>();

            DateTime dDNonPartn = extrantMock.DatesPremiereSpecialite[0].Value.AddDays(-10);

            _professionnel.ObtenirInformationProfessionnel(Arg.Any<ObtenirDispensateurIndividuEntre>()).Returns(extrantMock);
            var envoyCourlEntreMock = Fixture.Create<EnvoyCourlEntre>();
            envoyCourlEntreMock.Expediteur = System.Configuration.ConfigurationManager.AppSettings["AdresseExpediteur"];
            envoyCourlEntreMock.Destinataire = System.Configuration.ConfigurationManager.AppSettings["AdresseDestinataire"];
            var operation = OperationEvt.OperationPremièreSpecialite;
            //-Act     
            var extrant = _ajusterEngag.VerificationMAJDossier(intrantMock, dDNonPartn, envoyCourlEntreMock, operation);
            //-Assert
            Assert.True(extrant);

        }

        [Fact]
        public void VerificationMAJDossier_MAJDossierDatePremSpecDateDeces_nontrouve()
        {
            //-Arrange           
            var intrantMock = Fixture.Create<ObtenirDispensateurIndividuEntre>();
            var extrantMock = Fixture.Create<ObtenirDispensateurIndividuSorti>();
            var envoyCourlEntreMock = Fixture.Create<EnvoyCourlEntre>();
            DateTime dDNonPartn = extrantMock.DatesPremiereSpecialite[0].Value.AddDays(-10);
            extrantMock.DatesDecesIndividu.Clear();
            _professionnel.ObtenirInformationProfessionnel(Arg.Any<ObtenirDispensateurIndividuEntre>()).Returns(extrantMock);
            envoyCourlEntreMock.Expediteur = System.Configuration.ConfigurationManager.AppSettings["AdresseExpediteur"];
            envoyCourlEntreMock.Destinataire = System.Configuration.ConfigurationManager.AppSettings["AdresseDestinataire"];
            var operation = OperationEvt.OperationDeces;
            //-Act     
            var extrant = _ajusterEngag.VerificationMAJDossier(intrantMock, dDNonPartn, envoyCourlEntreMock, operation);
            //-Assert
            Assert.True(extrant);

        }

        [Fact]
        public void VerificationMAJDossier_MAJDossierDateDeces_evtDeces_OK()
        {
            //-Arrange           
            var intrantMock = Fixture.Create<ObtenirDispensateurIndividuEntre>();
            var extrantMock = Fixture.Create<ObtenirDispensateurIndividuSorti>();
            var envoyCourlEntreMock = Fixture.Create<EnvoyCourlEntre>();
            DateTime dDNonPartn = extrantMock.DatesPremiereSpecialite[0].Value.AddDays(-10);
            extrantMock.DatesPremiereSpecialite.Clear();

            _professionnel.ObtenirInformationProfessionnel(Arg.Any<ObtenirDispensateurIndividuEntre>()).Returns(extrantMock);
            envoyCourlEntreMock.Expediteur = System.Configuration.ConfigurationManager.AppSettings["AdresseExpediteur"];
            envoyCourlEntreMock.Destinataire = System.Configuration.ConfigurationManager.AppSettings["AdresseDestinataire"];
            var operation = OperationEvt.OperationDeces;
            //-Act     
            var extrant = _ajusterEngag.VerificationMAJDossier(intrantMock, dDNonPartn, envoyCourlEntreMock, operation);
            //-Assert
            Assert.False(extrant);
        }

        [Fact]
        public void VerificationMAJDossier_MAJDossierDateDeces_evtModificationNonPar_OK()
        {
            //-Arrange           
            var intrantMock = Fixture.Create<ObtenirDispensateurIndividuEntre>();
            var extrantMock = Fixture.Create<ObtenirDispensateurIndividuSorti>();
            var envoyCourlEntreMock = Fixture.Create<EnvoyCourlEntre>();
            DateTime dDNonPartn = extrantMock.DatesPremiereSpecialite[0].Value.AddDays(-10);
            extrantMock.DatesPremiereSpecialite.Clear();

            _professionnel.ObtenirInformationProfessionnel(Arg.Any<ObtenirDispensateurIndividuEntre>()).Returns(extrantMock);
            envoyCourlEntreMock.Expediteur = System.Configuration.ConfigurationManager.AppSettings["AdresseExpediteur"];
            envoyCourlEntreMock.Destinataire = System.Configuration.ConfigurationManager.AppSettings["AdresseDestinataire"];
            var operation = OperationEvt.OperationNonAdmissibilite;
            //-Act     
            var extrant = _ajusterEngag.VerificationMAJDossier(intrantMock, dDNonPartn, envoyCourlEntreMock, operation);
            //-Assert
            Assert.True(extrant);
        }

        #region Avis Conformite
        [Theory]
        [InlineAutoData]
        public void ObtenirLesAvisConfFermeesAnnulees_AvisConformitesFeremes_OK(long numseqDispensateur, DateTime dDNonPartn)
        {
            //-Arrange

            var extMock = Fixture.Create<ObtenirLesAvisConformiteSorti>();

            extMock.ListeAvisConformite[0].ListeStatutAvisConformite[0].StatutEngagement = "TER";
            extMock.ListeAvisConformite[0].DateFinEngagement = dDNonPartn.AddDays(-1);
            extMock.ListeAvisConformite[0].ListeStatutAvisConformite[0].CodeRaisonStatutEngagement = "21";

            _avisConformite.ObtenirLesAvisConformite(Arg.Any<ObtenirLesAvisConformiteEntre>()).Returns(extMock);


            //-Act
            var extrant = _ajusterEngag.ObtenirLesAvisConfFermeesAnnulees(numseqDispensateur, dDNonPartn, true);

            //-Assert
            Assert.True(extrant.Count > 0);
        }


        [Fact]
        public void InactiverAvisConformiteTermine_Inactivation_OK()
        {
            //-Arrange
            var intrantMock = Fixture.Create<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>();
            Fixture.Customizations.Add(new TypeRelay(
                                                  typeof(IMsgTrait),
                                                  typeof(MsgTrait)
                                                  )
                                    );
            var extrantMock = Fixture.Create<ModifierAvisConformiteStatutSorti>();
            _avisConformite.ModifierAvisConformiteStatut(Arg.Any<ModifierAvisConformiteStatutEntre>()).Returns(extrantMock);
            //-Act
            var extrant = _ajusterEngag.InactiverAvisConformiteTermine(intrantMock);

            //-Assert
            Assert.NotNull(extrantMock.DateHeureOccurence);

        }

        [Theory]
        [InlineAutoData]
        public void ReactiverAvisConformite_Reactivation_Ok(DateTime dDNonPartn)
        {
            //-Arrange
            var intrantMock = Fixture.Create<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>();
            intrantMock.ListeStatutAvisConformite.RemoveAt(1);
            intrantMock.ListeStatutAvisConformite[0].DateDebutStatutEngagement = dDNonPartn;
            intrantMock.ListeStatutAvisConformite[0].CodeRaisonStatutEngagement = "21";
            intrantMock.ListeStatutAvisConformite[0].StatutEngagement = "TER";
            intrantMock.ListeStatutAvisConformite[1].DateFinStatutEngagement = dDNonPartn.AddDays(-1);

            var extrantMock = Fixture.Create<CreerAvisConformiteSorti>();
            extrantMock.NumeroSequentielEngagement = 1234567;

            _avisConformite.CreerAvisConformite(Arg.Any<CreerAvisConformiteEntre>()).Returns(extrantMock);

            var codraisonEntre = Fixture.Create<CodRaisonStatutEntre>();
            codraisonEntre.CodeRaisonStatutAvisConf = Constante.CodeRaisonStatutAvisConf_DateNonPartn;

            //-Act
            var extrant = _ajusterEngag.ReactiverAvisConformite(intrantMock, dDNonPartn, true, codraisonEntre.CodeRaisonStatutAvisConf);

            //-Assert  
            Assert.True(extrant.NumeroSequentielEngagement > 0);
            Assert.Equal(1234567, extrant.NumeroSequentielEngagement);


        }
        #endregion

        #region Derogation
        [Theory]
        [InlineAutoData]
        public void ObtenirLesDerogationsProfessionnelFermeesAnnulees_DerogationFermee_OK(long numseqDispensateur, DateTime dDNonPartn)
        {
            //-Arrange

            var extMockDerog = Fixture.Create<EntiteCPO.ObtenirDerogationsProfessionnelSanteSorti>();
            extMockDerog.Derogations[0].Statut = "TER";
            extMockDerog.Derogations[0].DateFin = dDNonPartn.AddDays(-1);
            extMockDerog.Derogations[0].CodeRaisonStatut = "07";

            extMockDerog.Derogations[1].Statut = "ANN";
            extMockDerog.Derogations[2].Statut = "AUT";
            extMockDerog.Derogations[2].DateDebut = dDNonPartn.AddDays(2);
            _derogation.ObtenirDerogationProfessionnel(Arg.Any<EntiteCPO.ObtenirDerogationsProfessionnelSanteEntre>()).Returns(extMockDerog);

            var codeRaisonStatut = Constante.CodeRaisonStatutDerogation_DateNonPartn;
            //-Act
            var extrant = _ajusterEngag.ObtenirLesDerogationsProfessionnelFermeesAnnulees(numseqDispensateur, dDNonPartn, true, codeRaisonStatut);

            //-Assert
            Assert.True(extrant.Count > 0);
        }

        [Fact]
        public void ReactivationDerogationProfessionel_Reactivation_OK()
        {
            //-Arrange
            string codeRaison = "8";
            var intrantMock = Fixture.Create<EntiteCPO.ModifierDerogationEntre>();
            intrantMock.CodeRaisonStatut = codeRaison;
            intrantMock.CodeRaisonStatut = null;

            var extrantMock = Fixture.Create<EntiteCPO.ModifierDerogationSorti>();
            extrantMock.NouveauNumeroSequentiel = 914589;
            extrantMock.InfoMsgTrait.Clear();

            _derogation.ModifierDerogation(Arg.Any<EntiteCPO.ModifierDerogationEntre>()).Returns(extrantMock);


            //-Act
            var extrant = _ajusterEngag.ReactivationDerogationProfessionel(intrantMock);

            //-Assert           
            Assert.True(extrant.NouveauNumeroSequentiel.Equals(extrantMock.NouveauNumeroSequentiel));


        }
        #endregion

        #region Autorisation
        [Theory]
        [InlineAutoData]
        public void ObtenirLesAutorisationsProfessionnelFermeesAnnulees_AutorisationFermee_OK(long numseqDispensateur, DateTime dDNonPartn)
        {
            //-Arrange          
            var intantMock = Fixture.Create<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre>();
            var extrantMock = Fixture.Create<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelSorti>();
            extrantMock.Autorisations[0].DateFin = dDNonPartn.AddDays(-1);
            extrantMock.Autorisations[0].CodeRaisonStatut = "07";//"03";
            extrantMock.Autorisations[2].DateFin = dDNonPartn.AddDays(2);
            extrantMock.Autorisations[2].CodeRaisonStatut = "07";
            _autorisation.ObtenirAutorisationPREMQ(Arg.Any<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre>()).Returns(extrantMock);

            var codeRaisonStatut = Constante.CodeRaisonStatutDerogation_DateNonPartn;

            //-Act
            var extrant = _ajusterEngag.ObtenirLesAutorisationsProfessionnelFermeesAnnulees(numseqDispensateur, dDNonPartn, true, codeRaisonStatut);

            //-Assert
            Assert.True(extrant.Count > 0);
        }

        [Fact]
        public void ReactivationAutorisationProfessionel_Reactivation_OK()
        {
            //-Arrange
            string codeRaison = "4";
            var intrantMock = Fixture.Create<ModifierAutorisationEntre>();
            intrantMock.CodeRaisonStatut = codeRaison;
            Fixture.Customizations.Add(new TypeRelay(
                                                   typeof(IMsgTrait),
                                                   typeof(MsgTrait)
                                                   )
                                     );
            var extrantMock = Fixture.Create<ModifierAutorisationSorti>();
            extrantMock.NouveauNumeroSequentiel = 914589;
            extrantMock.InfoMsgTrait.Clear();

            _autorisation.ModifierAutorisation(Arg.Any<ModifierAutorisationEntre>()).Returns(extrantMock);


            //-Act
            var extrant = _ajusterEngag.ReactivationAutorisationProfessionel(intrantMock);

            //-Assert           
            Assert.True(extrant.NouveauNumeroSequentiel.Equals(extrantMock.NouveauNumeroSequentiel));


        }
        #endregion

        #endregion

        #region A5

        public void TraiterEngagementModifDateNonParticipation_traitement_OK()
        {
            //-Arrange
            var intrantMock = Fixture.Create<AjusEngagModifNonPartnEntre>();
            var derogationSortiMock = Fixture.Create<EntiteCPO.ObtenirDerogationsProfessionnelSanteSorti>();
            derogationSortiMock.Derogations[0].Statut = "AUT";
            derogationSortiMock.Derogations[2].Statut = "AUT";

            _derogation.ObtenirDerogationProfessionnel(Arg.Any<EntiteCPO.ObtenirDerogationsProfessionnelSanteEntre>()).Returns(derogationSortiMock);
            //-Act
            var extrant = _ajusterEngag.TraiterEngagementModifDateNonParticipation(intrantMock, OperationEvt.OperationNonAdmissibilite);

            //-Assert
            Assert.Empty(extrant.InfoMsgTrait);

        }

        [Theory]
        [InlineAutoData]
        public void VerifierMAJDossierEngagement_verificationtrouve_OK(long noSeqIntervenant, DateTime dateNParticipation)
        {
            //-Arrange
            var professionalSorti = Fixture.Create<ObtenirDispensateurIndividuSorti>();
            _professionnel.ObtenirInformationProfessionnel(Arg.Any<ObtenirDispensateurIndividuEntre>()).Returns(professionalSorti);
            var avisConformiteSorti = Fixture.Create<ObtenirLesAvisConformiteSorti>();
            _avisConformite.ObtenirLesAvisConformite(Arg.Any<ObtenirLesAvisConformiteEntre>()).Returns(avisConformiteSorti);
            var operation = OperationEvt.OperationNonAdmissibilite;
            //-Act
            var extrant = _ajusterEngag.VerifierMAJDossierEngagement(noSeqIntervenant, dateNParticipation, operation);
            //-Assert
            Assert.IsType<bool>(extrant);
        }
        #endregion

        #region A8

        #endregion

        #region Courriel
        [Fact]
        public void EnvoyerCourlConfr_courrielenvoye_OK()
        {
            //-Arrange
            var intrantMock = Fixture.Create<EnvoyCourlEntre>();
            intrantMock.Expediteur = System.Configuration.ConfigurationManager.AppSettings["AdresseExpediteur"];
            intrantMock.Destinataire = System.Configuration.ConfigurationManager.AppSettings["AdresseDestinataire"];
            intrantMock.Format = EnumFormatMessage.Texte;
            intrantMock.EncodageMsg = EnumEncodMsgCourl.UTF8;
            intrantMock.Importance = EnumImportanceCourl.Normal;

            var contentMsgMock = Fixture.Create<ContenuCourlEntre>();
            contentMsgMock.Evt = null;
            //-Act
            var extrant = _ajusterEngag.EnvoyerCourlConfr(intrantMock, EnumRaisonCourriel.Specialiste, contentMsgMock);

            //-Assert
            Assert.True(extrant);
        }

        [Fact]
        public void EnvoyerCourlConfr_courrielenvoyeDecespourEvenementDeces_OK()
        {
            //-Arrange
            var intrantMock = Fixture.Create<EnvoyCourlEntre>();
            intrantMock.Expediteur = System.Configuration.ConfigurationManager.AppSettings["AdresseExpediteur"];
            intrantMock.Destinataire = System.Configuration.ConfigurationManager.AppSettings["AdresseDestinataire"];
            intrantMock.Format = EnumFormatMessage.Texte;
            intrantMock.EncodageMsg = EnumEncodMsgCourl.UTF8;
            intrantMock.Importance = EnumImportanceCourl.Normal;

            var contentMsgMock = Fixture.Create<ContenuCourlEntre>();
            contentMsgMock.Evt = OperationEvt.OperationDeces;
            //-Act
            var extrant = _ajusterEngag.EnvoyerCourlConfr(intrantMock, EnumRaisonCourriel.Deces, contentMsgMock);

            //-Assert
            Assert.True(extrant);
        }

        [Fact]
        public void EnvoyerCourlConfr_courrielenvoyeSpecpourEvenementSpecialite_OK()
        {
            //-Arrange
            var intrantMock = Fixture.Create<EnvoyCourlEntre>();
            intrantMock.Expediteur = System.Configuration.ConfigurationManager.AppSettings["AdresseExpediteur"];
            intrantMock.Destinataire = System.Configuration.ConfigurationManager.AppSettings["AdresseDestinataire"];
            intrantMock.Format = EnumFormatMessage.Texte;
            intrantMock.EncodageMsg = EnumEncodMsgCourl.UTF8;
            intrantMock.Importance = EnumImportanceCourl.Normal;

            var contentMsgMock = Fixture.Create<ContenuCourlEntre>();
            contentMsgMock.Evt = OperationEvt.OperationPremièreSpecialite;
            //-Act
            var extrant = _ajusterEngag.EnvoyerCourlConfr(intrantMock, EnumRaisonCourriel.Specialiste, contentMsgMock);

            //-Assert
            Assert.True(extrant);
        }

        [Fact]
        public void EnvoyerCourlConfr_courrielenvoyeDecespourEvenementAnnulationNonParticipation_OK()
        {
            //-Arrange
            var intrantMock = Fixture.Create<EnvoyCourlEntre>();
            intrantMock.Expediteur = System.Configuration.ConfigurationManager.AppSettings["AdresseExpediteur"];
            intrantMock.Destinataire = System.Configuration.ConfigurationManager.AppSettings["AdresseDestinataire"];
            intrantMock.Format = EnumFormatMessage.Texte;
            intrantMock.EncodageMsg = EnumEncodMsgCourl.UTF8;
            intrantMock.Importance = EnumImportanceCourl.Normal;

            var contentMsgMock = Fixture.Create<ContenuCourlEntre>();
            contentMsgMock.Evt = OperationEvt.OperationNonAdmissibilite;
            //-Act
            var extrant = _ajusterEngag.EnvoyerCourlConfr(intrantMock, EnumRaisonCourriel.Deces, contentMsgMock);

            //-Assert
            Assert.True(extrant);
        }

        [Fact]
        public void EnvoyerCourlConfr_courrielenvoyeDecespourEvenementSpecialite_OK()
        {
            //-Arrange
            var intrantMock = Fixture.Create<EnvoyCourlEntre>();
            intrantMock.Expediteur = System.Configuration.ConfigurationManager.AppSettings["AdresseExpediteur"];
            intrantMock.Destinataire = System.Configuration.ConfigurationManager.AppSettings["AdresseDestinataire"];
            intrantMock.Format = EnumFormatMessage.Texte;
            intrantMock.EncodageMsg = EnumEncodMsgCourl.UTF8;
            intrantMock.Importance = EnumImportanceCourl.Normal;

            var contentMsgMock = Fixture.Create<ContenuCourlEntre>();
            contentMsgMock.Evt = OperationEvt.OperationPremièreSpecialite;
            //-Act
            var extrant = _ajusterEngag.EnvoyerCourlConfr(intrantMock, EnumRaisonCourriel.Deces, contentMsgMock);

            //-Assert
            Assert.True(extrant);
        }

        [Fact]
        public void EnvoyerCourlConfr_courrielEnvoyeSpecialitepourEvenementDeces_OK()
        {
            //-Arrange
            var intrantMock = Fixture.Create<EnvoyCourlEntre>();
            intrantMock.Expediteur = System.Configuration.ConfigurationManager.AppSettings["AdresseExpediteur"];
            intrantMock.Destinataire = System.Configuration.ConfigurationManager.AppSettings["AdresseDestinataire"];
            intrantMock.Format = EnumFormatMessage.Texte;
            intrantMock.EncodageMsg = EnumEncodMsgCourl.UTF8;
            intrantMock.Importance = EnumImportanceCourl.Normal;

            var contentMsgMock = Fixture.Create<ContenuCourlEntre>();
            contentMsgMock.Evt = OperationEvt.OperationDeces;
            //-Act
            var extrant = _ajusterEngag.EnvoyerCourlConfr(intrantMock, EnumRaisonCourriel.Specialiste, contentMsgMock);

            //-Assert
            Assert.True(extrant);
        }

        [Fact]
        public void EnvoyerCourlConfr_courrielenvoyeSpecialitepourEvenementAnnulationNonParticipation_OK()
        {
            //-Arrange
            var intrantMock = Fixture.Create<EnvoyCourlEntre>();
            intrantMock.Expediteur = System.Configuration.ConfigurationManager.AppSettings["AdresseExpediteur"];
            intrantMock.Destinataire = System.Configuration.ConfigurationManager.AppSettings["AdresseDestinataire"];
            intrantMock.Format = EnumFormatMessage.Texte;
            intrantMock.EncodageMsg = EnumEncodMsgCourl.UTF8;
            intrantMock.Importance = EnumImportanceCourl.Normal;

            var contentMsgMock = Fixture.Create<ContenuCourlEntre>();
            contentMsgMock.Evt = OperationEvt.OperationNonAdmissibilite;
            //-Act
            var extrant = _ajusterEngag.EnvoyerCourlConfr(intrantMock, EnumRaisonCourriel.Specialiste, contentMsgMock);

            //-Assert
            Assert.True(extrant);
        }

 

        [Fact]
        public void EnvoyerCourlConfr_courrielenvoyeDerogationplusieursStatus_OK()
        {
            //-Arrange
            var intrantMock = Fixture.Create<EnvoyCourlEntre>();
            intrantMock.Expediteur = System.Configuration.ConfigurationManager.AppSettings["AdresseExpediteur"];
            intrantMock.Destinataire = System.Configuration.ConfigurationManager.AppSettings["AdresseDestinataire"];
            intrantMock.Format = EnumFormatMessage.Texte;
            intrantMock.EncodageMsg = EnumEncodMsgCourl.UTF8;
            intrantMock.Importance = EnumImportanceCourl.Normal;
            

            var contentMsgMock = Fixture.Create<ContenuCourlEntre>();
            contentMsgMock.PlusieurStatutDerogation = true;
            //-Act
            var extrant = _ajusterEngag.EnvoyerCourlConfr(intrantMock, EnumRaisonCourriel.Derogation, contentMsgMock);

            //-Assert
            Assert.True(extrant);
        }


        [Fact]
        public void EnvoyerCourlConfr_AvisConfActifDecescourrielenvoye_OK()
        {
            //-Arrange
            var intrantMock = Fixture.Create<EnvoyCourlEntre>();
            intrantMock.Expediteur = System.Configuration.ConfigurationManager.AppSettings["AdresseExpediteur"];
            intrantMock.Destinataire = System.Configuration.ConfigurationManager.AppSettings["AdresseDestinataire"];
            intrantMock.Format = EnumFormatMessage.Texte;
            intrantMock.EncodageMsg = EnumEncodMsgCourl.UTF8;
            intrantMock.Importance = EnumImportanceCourl.Normal;

            var contentMsgMock = Fixture.Create<ContenuCourlEntre>();
            contentMsgMock.Evt = OperationEvt.OperationDeces;
            //-Act
            var extrant = _ajusterEngag.EnvoyerCourlConfr(intrantMock, EnumRaisonCourriel.AvisConformite, contentMsgMock);

            //-Assert
            Assert.True(extrant);
        }

        [Fact]
        public void EnvoyerCourlConfr_AvisConfcourrielenvoyeEvtRenseigne_OK()
        {
            //-Arrange
            var intrantMock = Fixture.Create<EnvoyCourlEntre>();
            intrantMock.Expediteur = System.Configuration.ConfigurationManager.AppSettings["AdresseExpediteur"];
            intrantMock.Destinataire = System.Configuration.ConfigurationManager.AppSettings["AdresseDestinataire"];
            intrantMock.Format = EnumFormatMessage.Texte;
            intrantMock.EncodageMsg = EnumEncodMsgCourl.UTF8;
            intrantMock.Importance = EnumImportanceCourl.Normal;

            var contentMsgMock = Fixture.Create<ContenuCourlEntre>();
            contentMsgMock.Evt = OperationEvt.OperationNonAdmissibilite;
            //-Act
            var extrant = _ajusterEngag.EnvoyerCourlConfr(intrantMock, EnumRaisonCourriel.AvisConformite, contentMsgMock);

            //-Assert
            Assert.True(extrant);
        }
        [Fact]
        public void EnvoyerCourlConfr_AvisConfcourrielenvoyeEvtNull_OK()
        {
            //-Arrange
            var intrantMock = Fixture.Create<EnvoyCourlEntre>();
            intrantMock.Expediteur = System.Configuration.ConfigurationManager.AppSettings["AdresseExpediteur"];
            intrantMock.Destinataire = System.Configuration.ConfigurationManager.AppSettings["AdresseDestinataire"];
            intrantMock.Format = EnumFormatMessage.Texte;
            intrantMock.EncodageMsg = EnumEncodMsgCourl.UTF8;
            intrantMock.Importance = EnumImportanceCourl.Normal;

            var contentMsgMock = Fixture.Create<ContenuCourlEntre>();
            contentMsgMock.Evt = null;
            //-Act
            var extrant = _ajusterEngag.EnvoyerCourlConfr(intrantMock, EnumRaisonCourriel.AvisConformite, contentMsgMock);

            //-Assert
            Assert.True(extrant);
        }

        [Fact]
        public void EnvoyerCourlConfr_AutorisationcourrielenvoyeEvtRenseigne_OK()
        {
            //-Arrange
            var intrantMock = Fixture.Create<EnvoyCourlEntre>();
            intrantMock.Expediteur = System.Configuration.ConfigurationManager.AppSettings["AdresseExpediteur"];
            intrantMock.Destinataire = System.Configuration.ConfigurationManager.AppSettings["AdresseDestinataire"];
            intrantMock.Format = EnumFormatMessage.Texte;
            intrantMock.EncodageMsg = EnumEncodMsgCourl.UTF8;
            intrantMock.Importance = EnumImportanceCourl.Normal;

            var contentMsgMock = Fixture.Create<ContenuCourlEntre>();
            contentMsgMock.Evt = OperationEvt.OperationNonAdmissibilite;
            //-Act
            var extrant = _ajusterEngag.EnvoyerCourlConfr(intrantMock, EnumRaisonCourriel.Autorisation, contentMsgMock);

            //-Assert
            Assert.True(extrant);
        }
        [Fact]
        public void EnvoyerCourlConfr_AutorisationcourrielenvoyeEvtNull_OK()
        {
            //-Arrange
            var intrantMock = Fixture.Create<EnvoyCourlEntre>();
            intrantMock.Expediteur = System.Configuration.ConfigurationManager.AppSettings["AdresseExpediteur"];
            intrantMock.Destinataire = System.Configuration.ConfigurationManager.AppSettings["AdresseDestinataire"];
            intrantMock.Format = EnumFormatMessage.Texte;
            intrantMock.EncodageMsg = EnumEncodMsgCourl.UTF8;
            intrantMock.Importance = EnumImportanceCourl.Normal;

            var contentMsgMock = Fixture.Create<ContenuCourlEntre>();
            contentMsgMock.Evt = null;
            //-Act
            var extrant = _ajusterEngag.EnvoyerCourlConfr(intrantMock, EnumRaisonCourriel.Autorisation, contentMsgMock);

            //-Assert
            Assert.True(extrant);
        }

        [Fact]
        public void EnvoyerCourlConfr_AutorisationActifDecescourrielenvoye_OK()
        {
            //-Arrange
            var intrantMock = Fixture.Create<EnvoyCourlEntre>();
            intrantMock.Expediteur = System.Configuration.ConfigurationManager.AppSettings["AdresseExpediteur"];
            intrantMock.Destinataire = System.Configuration.ConfigurationManager.AppSettings["AdresseDestinataire"];
            intrantMock.Format = EnumFormatMessage.Texte;
            intrantMock.EncodageMsg = EnumEncodMsgCourl.UTF8;
            intrantMock.Importance = EnumImportanceCourl.Normal;

            var contentMsgMock = Fixture.Create<ContenuCourlEntre>();
            contentMsgMock.Evt = OperationEvt.OperationDeces;
            //-Act
            var extrant = _ajusterEngag.EnvoyerCourlConfr(intrantMock, EnumRaisonCourriel.Autorisation, contentMsgMock);

            //-Assert
            Assert.True(extrant);
        }

        [Fact]
        public void EnvoyerCourlConfr_AutorisationActifSpeccourrielenvoye_OK()
        {
            //-Arrange
            var intrantMock = Fixture.Create<EnvoyCourlEntre>();
            intrantMock.Expediteur = System.Configuration.ConfigurationManager.AppSettings["AdresseExpediteur"];
            intrantMock.Destinataire = System.Configuration.ConfigurationManager.AppSettings["AdresseDestinataire"];
            intrantMock.Format = EnumFormatMessage.Texte;
            intrantMock.EncodageMsg = EnumEncodMsgCourl.UTF8;
            intrantMock.Importance = EnumImportanceCourl.Normal;

            var contentMsgMock = Fixture.Create<ContenuCourlEntre>();
            contentMsgMock.Evt = OperationEvt.OperationPremièreSpecialite;
            //-Act
            var extrant = _ajusterEngag.EnvoyerCourlConfr(intrantMock, EnumRaisonCourriel.Autorisation, contentMsgMock);

            //-Assert
            Assert.True(extrant);
        }

        [Fact]
        public void EnvoyerCourlConfr_AvisConfActifSpecialitecourrielenvoye_OK()
        {
            //-Arrange
            var intrantMock = Fixture.Create<EnvoyCourlEntre>();
            intrantMock.Expediteur = System.Configuration.ConfigurationManager.AppSettings["AdresseExpediteur"];
            intrantMock.Destinataire = System.Configuration.ConfigurationManager.AppSettings["AdresseDestinataire"];
            intrantMock.Format = EnumFormatMessage.Texte;
            intrantMock.EncodageMsg = EnumEncodMsgCourl.UTF8;
            intrantMock.Importance = EnumImportanceCourl.Normal;

            var contentMsgMock = Fixture.Create<ContenuCourlEntre>();
            contentMsgMock.Evt = OperationEvt.OperationPremièreSpecialite;
            //-Act
            var extrant = _ajusterEngag.EnvoyerCourlConfr(intrantMock, EnumRaisonCourriel.AvisConformite, contentMsgMock);

            //-Assert
            Assert.True(extrant);
        }
        #endregion

        #endregion

        [Theory]
        [InlineAutoData]
        public void ReactiverDerogation_reactivation_OK(long numeroSequentielDispensateur, List<PRE_Entites_cpo.Derogation.Entite.Derogation> lstDerogFermees, List<PRE_Entites_cpo.Derogation.Entite.Derogation> lstDerogAnnulees,DateTime dateNonParticipation)
        {
            //-Arrange
            var derogationSortiMock = Fixture.Create<EntiteCPO.ObtenirDerogationsProfessionnelSanteSorti>();
            derogationSortiMock.Derogations[0].DateDebut = lstDerogFermees[0].DateDebut;
            derogationSortiMock.Derogations[0].Statut = "AUT";
            derogationSortiMock.Derogations[2].DateDebut = lstDerogAnnulees[0].DateDebut;
            derogationSortiMock.Derogations[2].Statut = "AUT";
            _derogation.ObtenirDerogationProfessionnel(Arg.Any<EntiteCPO.ObtenirDerogationsProfessionnelSanteEntre>()).Returns(derogationSortiMock);
            var modifierDerogationMockSorti = Fixture.Create<EntiteCPO.ModifierDerogationSorti>();
            modifierDerogationMockSorti.InfoMsgTrait.Clear();
            _derogation.ModifierDerogation(Arg.Any<EntiteCPO.ModifierDerogationEntre>()).Returns(modifierDerogationMockSorti);

            //-Act
            var extrant = _ajusterEngag.ReactiverDerogation(numeroSequentielDispensateur, lstDerogFermees, lstDerogAnnulees, dateNonParticipation);

            //-Assert
            Assert.NotNull(extrant);
            Assert.True(extrant.EstTraite);

        }
        [Theory]
        [InlineAutoData]
        public void ReactiverDerogation_reactivation_KO(long numeroSequentielDispensateur, List<PRE_Entites_cpo.Derogation.Entite.Derogation> lstDerogFermees, List<PRE_Entites_cpo.Derogation.Entite.Derogation> lstDerogAnnulees,DateTime dateNonParticipation)
        {
            //-Arrange
            var derogationSortiMock = Fixture.Create<EntiteCPO.ObtenirDerogationsProfessionnelSanteSorti>();
            derogationSortiMock.Derogations[0].DateDebut = lstDerogFermees[0].DateDebut;
            derogationSortiMock.Derogations[0].Statut = "AUT";
            derogationSortiMock.Derogations[1].DateDebut = lstDerogFermees[0].DateDebut;
            derogationSortiMock.Derogations[1].Statut = "TER";
            derogationSortiMock.Derogations[2].DateDebut = lstDerogAnnulees[0].DateDebut;
            derogationSortiMock.Derogations[2].Statut = "AUT";
            _derogation.ObtenirDerogationProfessionnel(Arg.Any<EntiteCPO.ObtenirDerogationsProfessionnelSanteEntre>()).Returns(derogationSortiMock);
            var modifierDerogationMockSorti = Fixture.Create<EntiteCPO.ModifierDerogationSorti>();
            _derogation.ModifierDerogation(Arg.Any<EntiteCPO.ModifierDerogationEntre>()).Returns(modifierDerogationMockSorti);

            //-Act
            var extrant = _ajusterEngag.ReactiverDerogation(numeroSequentielDispensateur, lstDerogFermees, lstDerogAnnulees, dateNonParticipation);

            //-Assert
            Assert.NotNull(extrant);
            Assert.False(extrant.EstTraite);

        }

        [Theory]
        [InlineAutoData]
        public void ReactiverAutorisation_reactivation_OK(long numeroSequentielDispensateur, List<PL_LogiqueAffaire_cpo.Entites.Autorisation> lstAutorisationFermees, List<PL_LogiqueAffaire_cpo.Entites.Autorisation> lstAutorisationAnnulees)
        {
            //-Arrange
            Fixture.Customizations.Add(new TypeRelay(
                                                   typeof(IMsgTrait),
                                                   typeof(MsgTrait)
                                                   )
                                     );
            var autorisationSortiMock = Fixture.Create<PL_LogiqueAffaire_cpo.Parametres.ObtenirLesAutorisationsProfessionnelSorti>();
            autorisationSortiMock.Autorisations[0].DateDebut = lstAutorisationFermees[0].DateDebut;
            autorisationSortiMock.Autorisations[2].DateDebut = lstAutorisationAnnulees[2].DateDebut;
            _autorisation.ObtenirAutorisationPREMQ(Arg.Any<PL_LogiqueAffaire_cpo.Parametres.ObtenirLesAutorisationsProfessionnelEntre>()).Returns(autorisationSortiMock);
            var modifierAutorisationMockSorti = Fixture.Create<PRE_Entites_cpo.Autorisation.Parametre.ModifierAutorisationSorti>();
            modifierAutorisationMockSorti.InfoMsgTrait.Clear();
            _autorisation.ModifierAutorisation(Arg.Any<PRE_Entites_cpo.Autorisation.Parametre.ModifierAutorisationEntre>()).Returns(modifierAutorisationMockSorti);

            //-Act
            var extrant = _ajusterEngag.ReactiverAutorisation(numeroSequentielDispensateur, lstAutorisationFermees, lstAutorisationAnnulees);

            //-Assert
            Assert.NotNull(extrant);
            Assert.True(extrant.EstTraite);

        }

        [Theory]
        [InlineAutoData]
        public void ReactiverAutorisation_reactivation_KO(long numeroSequentielDispensateur, List<PL_LogiqueAffaire_cpo.Entites.Autorisation> lstAutorisationFermees, List<PL_LogiqueAffaire_cpo.Entites.Autorisation> lstAutorisationAnnulees)
        {
            //-Arrange
            Fixture.Customizations.Add(new TypeRelay(
                                                   typeof(IMsgTrait),
                                                   typeof(MsgTrait)
                                                   )
                                     );
            var autorisationSortiMock = Fixture.Create<PL_LogiqueAffaire_cpo.Parametres.ObtenirLesAutorisationsProfessionnelSorti>();
            autorisationSortiMock.Autorisations[0].DateDebut = lstAutorisationFermees[0].DateDebut;
            autorisationSortiMock.Autorisations[2].DateDebut = lstAutorisationAnnulees[2].DateDebut;
           
            _autorisation.ObtenirAutorisationPREMQ(Arg.Any<PL_LogiqueAffaire_cpo.Parametres.ObtenirLesAutorisationsProfessionnelEntre>()).Returns(autorisationSortiMock);
            var modifierAutorisationMockSorti = Fixture.Create<PRE_Entites_cpo.Autorisation.Parametre.ModifierAutorisationSorti>();
            _autorisation.ModifierAutorisation(Arg.Any<PRE_Entites_cpo.Autorisation.Parametre.ModifierAutorisationEntre>()).Returns(modifierAutorisationMockSorti);

            //-Act
            var extrant = _ajusterEngag.ReactiverAutorisation(numeroSequentielDispensateur, lstAutorisationFermees, lstAutorisationAnnulees);

            //-Assert
            Assert.NotNull(extrant);
            //Assert.False(extrant.EstTraite);

        }

        [Theory]
        [InlineAutoData]
        public void ReactiverAvis_traitementAvis_OK(long numeroSequentielDispensateur, DateTime dateNonParticipation, List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> avisConfFermees, List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> avisConfAnnulees)
        {
            //-Arrange

            Fixture.Customizations.Add(new TypeRelay(
                                                   typeof(IMsgTrait),
                                                   typeof(MsgTrait)
                                                   )
                                     );

            var avisSortiMock = Fixture.Create<ObtenirLesAvisConformiteSorti>();
            avisSortiMock.ListeAvisConformite[0].DateDebutEngagement = avisConfFermees[0].DateDebutEngagement;
            //avisSortiMock.ListeAvisConformite[0].ListeStatutAvisConformite[0].StatutEngagement = "TER";
            avisSortiMock.ListeAvisConformite[0].ListeStatutAvisConformite[0].CodeRaisonStatutEngagement = "21";

            avisSortiMock.ListeAvisConformite[2].DateDebutEngagement = avisConfAnnulees[2].DateDebutEngagement;
            _avisConformite.ObtenirLesAvisConformite(Arg.Any<ObtenirLesAvisConformiteEntre>()).Returns(avisSortiMock);

            var modifierAvisConformiteStatut = Fixture.Create<PRE_Entites_cpo.AvisConformite.Parametre.ModifierAvisConformiteStatutSorti>();
            modifierAvisConformiteStatut.InfoMsgTrait.Clear();
            _avisConformite.ModifierAvisConformiteStatut(Arg.Any<PRE_Entites_cpo.AvisConformite.Parametre.ModifierAvisConformiteStatutEntre>()).Returns(modifierAvisConformiteStatut);
            var modifierRaisFermStatutEngagSorti = Fixture.Create<PRE_Entites_cpo.AvisConformite.Parametre.ModifierRaisFermStatutEngagSorti>();
            modifierRaisFermStatutEngagSorti.InfoMsgTrait.Clear();
            _avisConformite.ModifierRaisFermStatutEngag(Arg.Any<PRE_Entites_cpo.AvisConformite.Parametre.ModifierRaisFermStatutEngagEntre>()).Returns(modifierRaisFermStatutEngagSorti);
            var creerAvisConformiteSorti = Fixture.Create<PRE_Entites_cpo.AvisConformite.Parametre.CreerAvisConformiteSorti>();
            creerAvisConformiteSorti.InfoMsgTrait.Clear();
            _avisConformite.CreerAvisConformite(Arg.Any<PRE_Entites_cpo.AvisConformite.Parametre.CreerAvisConformiteEntre>()).Returns(creerAvisConformiteSorti);

            var codraisonEntre = Fixture.Create<CodRaisonStatutEntre>();
            codraisonEntre.CodeRaisonStatutAvisConf = Constante.CodeRaisonStatutAvisConf_DateNonPartn;
            codraisonEntre.CodeRaisonStatutReactivationAvisConf = Constante.EvtModif_CodeRaiStaAvisDatNPartPosterieur;

            var extMockDerog = Fixture.Create<EntiteCPO.ObtenirDerogationsProfessionnelSanteSorti>();
            _derogation.ObtenirDerogationProfessionnel(Arg.Any<EntiteCPO.ObtenirDerogationsProfessionnelSanteEntre>()).Returns(extMockDerog);
            var extrantMock = Fixture.Create<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelSorti>();
            _autorisation.ObtenirAutorisationPREMQ(Arg.Any<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre>()).Returns(extrantMock);

            //-Act
            var extrant = _ajusterEngag.ReactiverAvis(numeroSequentielDispensateur, dateNonParticipation, avisConfFermees, avisConfAnnulees, codraisonEntre);

            //-Assert
            Assert.NotNull(extrant);
            Assert.True(extrant.EstTraite);
        }

        [Theory]
        [InlineAutoData]
        public void ReactiverAvis_traitementAvis_KO(long numeroSequentielDispensateur, DateTime dateNonParticipation, List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> avisConfFermees, List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> avisConfAnnulees)
        {
            //-Arrange

            Fixture.Customizations.Add(new TypeRelay(
                                                   typeof(IMsgTrait),
                                                   typeof(MsgTrait)
                                                   )
                                     );

            var avisSortiMock = Fixture.Create<ObtenirLesAvisConformiteSorti>();
            avisSortiMock.ListeAvisConformite[0].DateDebutEngagement = avisConfFermees[0].DateDebutEngagement;
            //avisSortiMock.ListeAvisConformite[0].ListeStatutAvisConformite[0].StatutEngagement = "TER";
            avisSortiMock.ListeAvisConformite[0].ListeStatutAvisConformite[0].CodeRaisonStatutEngagement = "21";

            avisSortiMock.ListeAvisConformite[2].DateDebutEngagement = avisConfAnnulees[2].DateDebutEngagement;
            _avisConformite.ObtenirLesAvisConformite(Arg.Any<ObtenirLesAvisConformiteEntre>()).Returns(avisSortiMock);

            var modifierAvisConformiteStatut = Fixture.Create<PRE_Entites_cpo.AvisConformite.Parametre.ModifierAvisConformiteStatutSorti>();
            _avisConformite.ModifierAvisConformiteStatut(Arg.Any<PRE_Entites_cpo.AvisConformite.Parametre.ModifierAvisConformiteStatutEntre>()).Returns(modifierAvisConformiteStatut);
            var modifierRaisFermStatutEngagSorti = Fixture.Create<PRE_Entites_cpo.AvisConformite.Parametre.ModifierRaisFermStatutEngagSorti>();
            _avisConformite.ModifierRaisFermStatutEngag(Arg.Any<PRE_Entites_cpo.AvisConformite.Parametre.ModifierRaisFermStatutEngagEntre>()).Returns(modifierRaisFermStatutEngagSorti);
            var creerAvisConformiteSorti = Fixture.Create<PRE_Entites_cpo.AvisConformite.Parametre.CreerAvisConformiteSorti>();
            _avisConformite.CreerAvisConformite(Arg.Any<PRE_Entites_cpo.AvisConformite.Parametre.CreerAvisConformiteEntre>()).Returns(creerAvisConformiteSorti);

            var codraisonEntre = Fixture.Create<CodRaisonStatutEntre>();
            codraisonEntre.CodeRaisonStatutAvisConf = Constante.CodeRaisonStatutAvisConf_DateNonPartn;
            codraisonEntre.CodeRaisonStatutReactivationAvisConf = Constante.EvtModif_CodeRaiStaAvisDatNPartPosterieur;

            var extMockDerog = Fixture.Create<EntiteCPO.ObtenirDerogationsProfessionnelSanteSorti>();
            _derogation.ObtenirDerogationProfessionnel(Arg.Any<EntiteCPO.ObtenirDerogationsProfessionnelSanteEntre>()).Returns(extMockDerog);            
            var extrantMock = Fixture.Create<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelSorti>();
            _autorisation.ObtenirAutorisationPREMQ(Arg.Any<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre>()).Returns(extrantMock);
            //-Act
            var extrant = _ajusterEngag.ReactiverAvis(numeroSequentielDispensateur, dateNonParticipation, avisConfFermees, avisConfAnnulees, codraisonEntre);

            //-Assert
            Assert.NotNull(extrant);
            Assert.False(extrant.EstTraite);
        }


        [Fact]
        public void VerificationMiseAJourDatePremSpec()
        {
            //-Arrange
            var intrantMock = Fixture.Create<AjusEngagDdSpecInscrEntre>();
            intrantMock.InfoDispModif.DdSpecialite = null;
            //intrantMock.InfoDispOrign.DdSpecialite = null;
            //-Act
            var extrant = _ajusterEngag.VerificationMiseAJourDatePremSpec(intrantMock);

            //-Assert
            //Assert.True(extrant.Value);
            Assert.False(extrant.Value);
        }

        [Theory]
        [InlineAutoData]
        public void AjusterEngagDeces(AjusEngagDecesEntre param)
        {
            //-Arrange
            var mockInformationSorti = Fixture.Create<ObtenirDispensateurIndividuSorti>();
            _professionnel.ObtenirInformationProfessionnel(Arg.Any<ObtenirDispensateurIndividuEntre>()).Returns(mockInformationSorti);
            //-Act
            var extrant = _ajusterEngag.TraiterEngagementDeces(param, OperationEvt.OperationDeces);

            //-Assert
            Assert.NotNull(extrant);
        }

        [Theory]
        [InlineAutoData]
        public void InactivationCreationStatuts_DateFinNull_traitementOK(PRE_Entites_cpo.AvisConformite.Entite.AvisConformite avis, ObtenirLesAvisConformiteSorti nouvAvis, long numSeqStatEngag)
        {
            //-Arrange
            var modifierStatutEngagementSortiMock = Fixture.Create<ModifierStatutEngagementSorti>();
            modifierStatutEngagementSortiMock.InfoMsgTrait.Clear();
            _avisConformite.ModifierStatutAvisConformite(Arg.Any<ModifierStatutEngagementEntre>()).Returns(modifierStatutEngagementSortiMock);
            var creerStatutAvisConformiteSortiMock = Fixture.Create<CreerStatutAvisConformiteSorti>();
            creerStatutAvisConformiteSortiMock.InfoMsgTrait.Clear();
            _avisConformite.CreerStatutAvisConformite(Arg.Any<CreerStatutAvisConformiteEntre>()).Returns(creerStatutAvisConformiteSortiMock);
            avis.ListeStatutAvisConformite[0].StatutEngagement = "AUT";
            avis.ListeStatutAvisConformite[1].StatutEngagement = "SUS";
            avis.ListeStatutAvisConformite[2].StatutEngagement = "AUT";
            avis.ListeStatutAvisConformite[2].DateDebutStatutEngagement = avis.ListeStatutAvisConformite.Min(m => m.DateFinStatutEngagement).Value.AddDays(1);
            avis.ListeStatutAvisConformite[2].DateFinStatutEngagement = null;
            //-Act
            var extrant = _ajusterEngag.InactivationCreationStatuts(avis, nouvAvis, numSeqStatEngag, true);

            //-Assert
            Assert.True(extrant.Count == 0);
        }


        [Theory]
        [InlineAutoData]
        public void ReactiverAvis_traitementAvisFermesplusieursStatut_OK(List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> avisConfFermees, List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> avisConfAnnulees)
        {
            //-Arrange
            long numeroSequentielDispensateur = 5566;
            DateTime dateNonParticipation = new DateTime(2018, 4, 15);
            #region formattage
            Fixture.Customizations.Add(new TypeRelay(
                                                   typeof(IMsgTrait),
                                                   typeof(MsgTrait)
                                                   )
                                     );


            var avisSortiMock = Fixture.Create<ObtenirLesAvisConformiteSorti>();
            avisSortiMock.ListeAvisConformite[0].DateDebutEngagement = avisConfFermees[0].DateDebutEngagement;            
            avisSortiMock.ListeAvisConformite[0].ListeStatutAvisConformite[0].CodeRaisonStatutEngagement = "21";

            avisSortiMock.ListeAvisConformite[2].DateDebutEngagement = avisConfAnnulees[2].DateDebutEngagement;
            _avisConformite.ObtenirLesAvisConformite(Arg.Any<ObtenirLesAvisConformiteEntre>()).Returns(avisSortiMock);

            var modifierAvisConformiteStatut = Fixture.Create<PRE_Entites_cpo.AvisConformite.Parametre.ModifierAvisConformiteStatutSorti>();
            modifierAvisConformiteStatut.InfoMsgTrait.Clear();
            _avisConformite.ModifierAvisConformiteStatut(Arg.Any<PRE_Entites_cpo.AvisConformite.Parametre.ModifierAvisConformiteStatutEntre>()).Returns(modifierAvisConformiteStatut);
            var modifierRaisFermStatutEngagSorti = Fixture.Create<PRE_Entites_cpo.AvisConformite.Parametre.ModifierRaisFermStatutEngagSorti>();
            modifierRaisFermStatutEngagSorti.InfoMsgTrait.Clear();
            _avisConformite.ModifierRaisFermStatutEngag(Arg.Any<PRE_Entites_cpo.AvisConformite.Parametre.ModifierRaisFermStatutEngagEntre>()).Returns(modifierRaisFermStatutEngagSorti);
            var creerAvisConformiteSorti = Fixture.Create<PRE_Entites_cpo.AvisConformite.Parametre.CreerAvisConformiteSorti>();
            creerAvisConformiteSorti.InfoMsgTrait.Clear();
            _avisConformite.CreerAvisConformite(Arg.Any<PRE_Entites_cpo.AvisConformite.Parametre.CreerAvisConformiteEntre>()).Returns(creerAvisConformiteSorti);

            var creerStatutAvisConformiteSortiMock=Fixture.Create< CreerStatutAvisConformiteSorti>();
            creerStatutAvisConformiteSortiMock.InfoMsgTrait.Clear();
            _avisConformite.CreerStatutAvisConformite(Arg.Any<CreerStatutAvisConformiteEntre>()).Returns(creerStatutAvisConformiteSortiMock);

            var modifierStatutEngagementSortiMock = Fixture.Create<ModifierStatutEngagementSorti>();
            modifierStatutEngagementSortiMock.InfoMsgTrait.Clear();
            _avisConformite.ModifierStatutAvisConformite(Arg.Any<ModifierStatutEngagementEntre>()).Returns(modifierStatutEngagementSortiMock);
            var codraisonEntre = Fixture.Create<CodRaisonStatutEntre>();
            codraisonEntre.CodeRaisonStatutAvisConf = Constante.CodeRaisonStatutAvisConf_DateNonPartn;
            codraisonEntre.CodeRaisonStatutReactivationAvisConf = Constante.EvtModif_CodeRaiStaAvisDatNPartPosterieur;

            var modifierPeriodeAvisMockSorti = Fixture.Create<ModifierPeriodeAvisSorti>();
            modifierPeriodeAvisMockSorti.InfoMsgTrait.Clear();
            _avisConformite.ModifierPeriodeAvis(Arg.Any<ModifierPeriodeAvisEntre>()).Returns(modifierPeriodeAvisMockSorti);

            var extMockDerog = Fixture.Create<EntiteCPO.ObtenirDerogationsProfessionnelSanteSorti>();
            _derogation.ObtenirDerogationProfessionnel(Arg.Any<EntiteCPO.ObtenirDerogationsProfessionnelSanteEntre>()).Returns(extMockDerog);
            var extrantMock = Fixture.Create<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelSorti>();
            _autorisation.ObtenirAutorisationPREMQ(Arg.Any<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre>()).Returns(extrantMock);
            #endregion

            avisConfAnnulees.Clear();

            avisConfFermees.RemoveAt(1);
            avisConfFermees.RemoveAt(1);
            avisConfFermees[0].DateDebutEngagement = new DateTime(2004, 1, 1);
            avisConfFermees[0].DateFinEngagement = new DateTime(2018, 4, 14);


            avisConfFermees[0].ListeStatutAvisConformite = new List<PRE_Entites_cpo.AvisConformite.Entite.StatutAvisConformite>();

            avisConfFermees[0].ListeStatutAvisConformite.Add(new PRE_Entites_cpo.AvisConformite.Entite.StatutAvisConformite
            {
                StatutEngagement = "AUT",
                DateDebutStatutEngagement = new DateTime(2004, 1, 1),
                DateFinStatutEngagement = new DateTime(2018, 3, 31),
                DateHeureOccurenceInactive = null
            });
            avisConfFermees[0].ListeStatutAvisConformite.Add(new PRE_Entites_cpo.AvisConformite.Entite.StatutAvisConformite
            {
                StatutEngagement = "AUT",
                DateDebutStatutEngagement = new DateTime(2018, 5, 1),
                DateFinStatutEngagement = null,
                DateHeureOccurenceInactive = new DateTime(2018, 7, 5)
            });
            avisConfFermees[0].ListeStatutAvisConformite.Add(new PRE_Entites_cpo.AvisConformite.Entite.StatutAvisConformite
            {

                StatutEngagement = "AUT",
                DateDebutStatutEngagement = new DateTime(2004, 1, 1),
                DateFinStatutEngagement = null,
                DateHeureOccurenceInactive = new DateTime(2018, 7, 5)
            });
            avisConfFermees[0].ListeStatutAvisConformite.Add(new PRE_Entites_cpo.AvisConformite.Entite.StatutAvisConformite
            {

                StatutEngagement = "SUS",
                DateDebutStatutEngagement = new DateTime(2018, 4, 1),
                DateFinStatutEngagement = new DateTime(2018, 4, 30),
                DateHeureOccurenceInactive = new DateTime(2018, 7, 5)
            });
            avisConfFermees[0].ListeStatutAvisConformite.Add(new PRE_Entites_cpo.AvisConformite.Entite.StatutAvisConformite
            {

                StatutEngagement = "SUS",
                DateDebutStatutEngagement = new DateTime(2018, 4, 1),
                DateFinStatutEngagement = new DateTime(2018, 4, 14),
                DateHeureOccurenceInactive = null,
            });
            avisConfFermees[0].ListeStatutAvisConformite.Add(new PRE_Entites_cpo.AvisConformite.Entite.StatutAvisConformite
            {

                StatutEngagement = "TER",
                DateDebutStatutEngagement = new DateTime(2018, 4, 15),
                DateFinStatutEngagement = null,
                DateHeureOccurenceInactive = null,
                CodeRaisonStatutEngagement="21"
            });
            avisConfFermees[0].ListeStatutAvisConformite.Add(new PRE_Entites_cpo.AvisConformite.Entite.StatutAvisConformite
            {

                StatutEngagement = "TER",
                DateDebutStatutEngagement = new DateTime(2018, 5, 1),
                DateFinStatutEngagement = null,
                DateHeureOccurenceInactive = new DateTime(2018, 7, 5),
            });





            //-Act
            var extrant = _ajusterEngag.ReactiverAvis(numeroSequentielDispensateur, dateNonParticipation, avisConfFermees, avisConfAnnulees, codraisonEntre);

            //-Assert
            Assert.NotNull(extrant);
            Assert.True(extrant.EstTraite);
        }


        //[Theory]
        //[InlineAutoData]
        public void ReactivationAvisConfFermeAnnule_avisplusisuersStatutAUT_reactivation(List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> avisConformites,long numeroSequentielDispensateur, DateTime dateNonParticipation, bool ferme, CodRaisonStatutEntre codRaisonStatutEntre)
        {
            //-Arrange
            avisConformites[0].ListeStatutAvisConformite[0].StatutEngagement = "AUT";
           
            avisConformites[0].ListeStatutAvisConformite[1].StatutEngagement = "AUT";
            avisConformites[0].ListeStatutAvisConformite[1].DateDebutStatutEngagement = avisConformites[0].ListeStatutAvisConformite[0].DateDebutStatutEngagement.AddDays(10);

            avisConformites[0].ListeStatutAvisConformite[2].StatutEngagement = "SUS";
            //avisConformites[0].ListeStatutAvisConformite[2].StatutEngagement = "TER";
            //avisConformites[0].ListeStatutAvisConformite[2].StatutEngagement = "ANN";
            //-Act
            var extrant = _ajusterEngag.ReactivationAvisConfFermeAnnule(avisConformites, numeroSequentielDispensateur,dateNonParticipation, ferme, codRaisonStatutEntre);

            //-Assert
            Assert.True(extrant.Count == 0);
        }

        [Fact]
        public void ObtenirNombreStatutsAvisConformite_avisplusieursStatutAUTDateDebutDifferente_et_SUS_trouve()
        {
            //-Arrange
            var intrantMock = Fixture.Create<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>();
            intrantMock.ListeStatutAvisConformite[0].StatutEngagement = "AUT";
            intrantMock.ListeStatutAvisConformite[1].StatutEngagement = "AUT";
            intrantMock.ListeStatutAvisConformite[1].DateDebutStatutEngagement = intrantMock.ListeStatutAvisConformite[0].DateDebutStatutEngagement.AddDays(10);

            intrantMock.ListeStatutAvisConformite[2].StatutEngagement = "SUS";
            var excepted = 3;
            //-Act
            var result = _ajusterEngag.ObtenirNombreStatutsAvisConformite(intrantMock);

            //-Assert
            Assert.True(result ==excepted);
        }

        [Fact]
        public void ObtenirNombreStatutsAvisConformite_avisplusieursStatutAUTDateDebutidentique_et_SUS_trouve()
        {
            //-Arrange
            var intrantMock = Fixture.Create<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>();
            intrantMock.ListeStatutAvisConformite[0].StatutEngagement = "AUT";
            intrantMock.ListeStatutAvisConformite[1].StatutEngagement = "AUT";
            intrantMock.ListeStatutAvisConformite[1].DateDebutStatutEngagement = intrantMock.ListeStatutAvisConformite[0].DateDebutStatutEngagement;

            intrantMock.ListeStatutAvisConformite[2].StatutEngagement = "SUS";

            var excepted = 2;
            //-Act
            var result = _ajusterEngag.ObtenirNombreStatutsAvisConformite(intrantMock);

            //-Assert
            Assert.Equal(excepted,result);
        }

        [Fact]
        public void ObtenirNombreStatutsAvisConformite_avisplusieursStatutAUTDateDebutidentique_et_TER_trouve()
        {
            //-Arrange
            var intrantMock = Fixture.Create<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>();
            intrantMock.ListeStatutAvisConformite[0].StatutEngagement = "AUT";
            intrantMock.ListeStatutAvisConformite[1].StatutEngagement = "AUT";
            intrantMock.ListeStatutAvisConformite[1].DateDebutStatutEngagement = intrantMock.ListeStatutAvisConformite[0].DateDebutStatutEngagement;

            intrantMock.ListeStatutAvisConformite[2].StatutEngagement = "TER";

            var excepted = 1;
            //-Act
            var result = _ajusterEngag.ObtenirNombreStatutsAvisConformite(intrantMock);

            //-Assert
            Assert.Equal(excepted, result);
        }

        [Fact]
        public void ObtenirNombreStatutsAvisConformite_avisplusieursStatutAUTDateDebutDifferente_et_ANN_trouve()
        {
            //-Arrange
            var intrantMock = Fixture.Create<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>();
            intrantMock.ListeStatutAvisConformite[0].StatutEngagement = "AUT";
            intrantMock.ListeStatutAvisConformite[1].StatutEngagement = "AUT";
            intrantMock.ListeStatutAvisConformite[1].DateDebutStatutEngagement = intrantMock.ListeStatutAvisConformite[0].DateDebutStatutEngagement.AddDays(4);

            intrantMock.ListeStatutAvisConformite[2].StatutEngagement = "ANN";

            var excepted = 2;
            //-Act
            var result = _ajusterEngag.ObtenirNombreStatutsAvisConformite(intrantMock);

            //-Assert
            Assert.Equal(excepted, result);
        }

        [Theory]
        [InlineAutoData]
        public void ObtenirDateProchainEngagementAnnuledelaSequence_PlusiuersAvisDanslasequence_AvisSuivantTrouve(long numeroSequentielDispensateur,DateTime dateNonParticipation)
        {
            //-Arrange
            var intrantMock = Fixture.Create<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>();
            intrantMock.ListeStatutAvisConformite[2].StatutEngagement = "TER";
            var datDeb = intrantMock.ListeStatutAvisConformite.Max(m => m.DateFinStatutEngagement).Value.AddDays(1);
            intrantMock.ListeStatutAvisConformite[2].DateDebutStatutEngagement = datDeb;

            var obtenirLesAvisConformiteMockSorti = Fixture.Create<ObtenirLesAvisConformiteSorti>();                      
            _avisConformite.ObtenirLesAvisConformite(Arg.Any<ObtenirLesAvisConformiteEntre>()).Returns(obtenirLesAvisConformiteMockSorti);
            var avisConformites = obtenirLesAvisConformiteMockSorti.ListeAvisConformite;
            avisConformites[1].DateDebutEngagement = intrantMock.ListeStatutAvisConformite[2].DateDebutStatutEngagement;


            var extMockDerog = Fixture.Create<EntiteCPO.ObtenirDerogationsProfessionnelSanteSorti>();
            _derogation.ObtenirDerogationProfessionnel(Arg.Any<EntiteCPO.ObtenirDerogationsProfessionnelSanteEntre>()).Returns(extMockDerog);
            var extrantMock = Fixture.Create<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelSorti>();
            _autorisation.ObtenirAutorisationPREMQ(Arg.Any<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre>()).Returns(extrantMock);
            //-Act
            var extrant = _ajusterEngag.ObtenirDateProchainEngagementAnnuledelaSequence(numeroSequentielDispensateur, intrantMock, "TER", dateNonParticipation);

            //-Assert
            Assert.NotNull(extrant);
        }

        [Theory]
        [InlineAutoData]
        public void ObtenirDateProchainEngagementAnnuledelaSequence_PlusiuersAvisDanslasequence_AvisSuivantAbsent(long numeroSequentielDispensateur, DateTime dateNonParticipation)
        {
            //-Arrange
            var intrantMock = Fixture.Create<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>();
            intrantMock.ListeStatutAvisConformite[2].StatutEngagement = "TER";
            var datDeb = intrantMock.ListeStatutAvisConformite.Max(m => m.DateFinStatutEngagement).Value.AddDays(1);
            intrantMock.ListeStatutAvisConformite[2].DateDebutStatutEngagement = datDeb;

            var obtenirLesAvisConformiteMockSorti = Fixture.Create<ObtenirLesAvisConformiteSorti>();
            _avisConformite.ObtenirLesAvisConformite(Arg.Any<ObtenirLesAvisConformiteEntre>()).Returns(obtenirLesAvisConformiteMockSorti);
            var avisConformites = obtenirLesAvisConformiteMockSorti.ListeAvisConformite;


            var extMockDerog = Fixture.Create<EntiteCPO.ObtenirDerogationsProfessionnelSanteSorti>();
            _derogation.ObtenirDerogationProfessionnel(Arg.Any<EntiteCPO.ObtenirDerogationsProfessionnelSanteEntre>()).Returns(extMockDerog);
            var extrantMock = Fixture.Create<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelSorti>();
            _autorisation.ObtenirAutorisationPREMQ(Arg.Any<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre>()).Returns(extrantMock);
            extrantMock.Autorisations.Clear();
            //-Act
            var extrant = _ajusterEngag.ObtenirDateProchainEngagementAnnuledelaSequence(numeroSequentielDispensateur, intrantMock, "TER", dateNonParticipation);

            //-Assert
            Assert.Null(extrant);
        }

        [Theory]
        [InlineAutoData]
        public void ObtenirDateProchainEngagementAnnuledelaSequence_unSeulAvisDanslasequence_EnagagementSuivantAbsent(long numeroSequentielDispensateur, DateTime dateNonParticipation)
        {
            //-Arrange
            var intrantMock = Fixture.Create<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>();
            intrantMock.ListeStatutAvisConformite[2].StatutEngagement = "TER";
            var datDeb = intrantMock.ListeStatutAvisConformite.Max(m => m.DateFinStatutEngagement).Value.AddDays(1);
            intrantMock.ListeStatutAvisConformite[2].DateDebutStatutEngagement = datDeb;

            var obtenirLesAvisConformiteMockSorti = Fixture.Create<ObtenirLesAvisConformiteSorti>();
            _avisConformite.ObtenirLesAvisConformite(Arg.Any<ObtenirLesAvisConformiteEntre>()).Returns(obtenirLesAvisConformiteMockSorti);
            var avisConformites = obtenirLesAvisConformiteMockSorti.ListeAvisConformite;

            avisConformites.RemoveAt(1);
            avisConformites.RemoveAt(1);

            var extMockDerog = Fixture.Create<EntiteCPO.ObtenirDerogationsProfessionnelSanteSorti>();
            extMockDerog.Derogations.Clear();
            _derogation.ObtenirDerogationProfessionnel(Arg.Any<EntiteCPO.ObtenirDerogationsProfessionnelSanteEntre>()).Returns(extMockDerog);            
            var extrantMock = Fixture.Create<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelSorti>();
            _autorisation.ObtenirAutorisationPREMQ(Arg.Any<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre>()).Returns(extrantMock);
            extrantMock.Autorisations.Clear();
           //-Act
           var extrant = _ajusterEngag.ObtenirDateProchainEngagementAnnuledelaSequence(numeroSequentielDispensateur, intrantMock, "TER", dateNonParticipation);

            //-Assert
            Assert.Null(extrant);
        }

        [Theory]
        [InlineAutoData]
        public void ObtenirDateProchainEngagementAnnuledelaSequence_unSeulAvisDanslasequence_ProchainEngagDerogation(long numeroSequentielDispensateur, DateTime dateNonParticipation)
        {
            //-Arrange
            var intrantMock = Fixture.Create<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>();
            intrantMock.ListeStatutAvisConformite[2].StatutEngagement = "TER";
            var datDeb = intrantMock.ListeStatutAvisConformite.Max(m => m.DateFinStatutEngagement).Value.AddDays(1);
            intrantMock.ListeStatutAvisConformite[2].DateDebutStatutEngagement = datDeb;

            var obtenirLesAvisConformiteMockSorti = Fixture.Create<ObtenirLesAvisConformiteSorti>();
            _avisConformite.ObtenirLesAvisConformite(Arg.Any<ObtenirLesAvisConformiteEntre>()).Returns(obtenirLesAvisConformiteMockSorti);
            var avisConformites = obtenirLesAvisConformiteMockSorti.ListeAvisConformite;

            avisConformites.RemoveAt(1);
            avisConformites.RemoveAt(1);


            var extMockDerog = Fixture.Create<EntiteCPO.ObtenirDerogationsProfessionnelSanteSorti>();
            _derogation.ObtenirDerogationProfessionnel(Arg.Any<EntiteCPO.ObtenirDerogationsProfessionnelSanteEntre>()).Returns(extMockDerog);
            var execpted = intrantMock.ListeStatutAvisConformite.Max(m => m.DateFinStatutEngagement).Value.AddDays(1);
            var extrantMock = Fixture.Create<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelSorti>();
            _autorisation.ObtenirAutorisationPREMQ(Arg.Any<LAAutorisatonParametres.ObtenirLesAutorisationsProfessionnelEntre>()).Returns(extrantMock);
           
            //-Act
            var extrant = _ajusterEngag.ObtenirDateProchainEngagementAnnuledelaSequence(numeroSequentielDispensateur, intrantMock, "TER", dateNonParticipation);

            //-Assert
            Assert.Equal(execpted, extrant);


        }

        [Theory]
        [InlineAutoData]
        public void ObtenirNumSeqStatutEngagementPratique_numSeqStatutEngag_trouve(long numeroSequentielEngagement, DateTime dateNonParticipation, string statutEngagement)
        {
            //-Arrange          
            Fixture.Customizations.Add(new TypeRelay(
                                         typeof(IMsgTrait),
                                         typeof(MsgTrait)
                                         )
                           );
            var mockSorti = Fixture.Create<ObtenirStatutsEngagementPratiqueRSSSorti>();
            _ajusterEngag.ObtenirStatutsEngagementPratiqueRSS(Arg.Any<ObtenirStatutsEngagementPratiqueRSSEntre>()).Returns(mockSorti);
            //-Act
            var extrant = _ajusterEngag.ObtenirNumSeqStatutEngagementPratique(numeroSequentielEngagement, dateNonParticipation, statutEngagement);

            //-Assert
            Assert.True(extrant > 0);
        }
    }

}
