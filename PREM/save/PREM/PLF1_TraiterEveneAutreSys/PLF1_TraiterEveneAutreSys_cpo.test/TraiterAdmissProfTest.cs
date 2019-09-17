using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit2;
using RAMQ.PRE.PRE_OutilComun_cpo;
using RAMQ.Message;

/// <summary>
/// 
/// </summary>
/// <remarks>
/// </remarks>
namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.test
{
    public class TraiterAdmissProfTest
    {

        #region Méthodes statiques
        private static PRE_AccesDonne_cpo.PlanRegnMdcal.IPlanRegnMdcal ObtenirAccesDonneesMocke()
        {
            var accesDonnes = Substitute.For<PRE_AccesDonne_cpo.PlanRegnMdcal.IPlanRegnMdcal>();
            return accesDonnes;
        }

        private static PRE_SysExt_cpo.FIP.EPZ3.IInfoDispCnsul ObtenirAccesSysExtMocke()
        {
            var accesDonnes = Substitute.For<PRE_SysExt_cpo.FIP.EPZ3.IInfoDispCnsul>();
            return accesDonnes;
        }

        private static PL_LogiqueAffaire_cpo.AvisConformite.IAvisConformite ObtenirLogiqueAffaireAvisConformite()
        {
            var accesDonnes = Substitute.For<PL_LogiqueAffaire_cpo.AvisConformite.IAvisConformite>();
            return accesDonnes;
        }

        private static PL_LogiqueAffaire_cpo.Derogation.IDerogation ObtenirLogiqueAffaireDerogation()
        {
            var accesDonnes = Substitute.For<PL_LogiqueAffaire_cpo.Derogation.IDerogation>();
            return accesDonnes;
        }

        /// <summary>
        /// Méthode permettant de mocké le message de traitement
        /// </summary>
        /// <param name="idMessage"></param>
        /// <param name="descriptionMessage"></param>
        /// <param name="codeSeverite"></param>
        /// <param name="codeApplication"></param>
        private static RAMQ.Message.IResolutionMessage CreerMockResolutionMessage()
        {
            var clientResolutionMessage = Substitute.For<RAMQ.Message.IResolutionMessage>();
            clientResolutionMessage.ResoudrePartiesVariables(Arg.Any<string>(), Arg.Any<IEnumerable<string>>()).Returns(x => string.Format((string)x[0], (string[])x[1]));

            clientResolutionMessage.ObtenirDonneesFichierXml(nameof(PRE), Arg.Any<string>())
                .Returns(new InfoMessage
                {
                    CodSever = "E",
                    TxtMsgFran = "Erreur: {0}"
                });
            return clientResolutionMessage;
        }

        #endregion

        [Fact]
        public void EstUnEvenementDeSuppression_BonneValeur_OK()
        {
            var classeDeTest = new TraiterAdmissProf(Substitute.For<ITraitementDonneesAdmissProf>());
            Assert.True(classeDeTest.EstUnEvenementDeSuppression(Constantes.MessageEvenementSuppression));
        }

        [Fact]
        public void EstUnEvenementDAjout_BonneValeur_OK()
        {
            var classeDeTest = new TraiterAdmissProf(Substitute.For<ITraitementDonneesAdmissProf>());
            Assert.True(classeDeTest.EstUnEvenementDAjout(Constantes.MessageEvenementAjout));
        }

        [Fact]
        public void EstUnEvenementDeModification_BonneValeur_OK()
        {
            var classeDeTest = new TraiterAdmissProf(Substitute.For<ITraitementDonneesAdmissProf>());
            Assert.True(classeDeTest.EstUnEvenementDeModification(Constantes.MessageEvenementModification));
        }

        [Theory]
        [InlineAutoData]
        public void EstUnEvenementDeSuppression_MauvaiseValeur_Fail(string randomData)
        {
            var classeDeTest = new TraiterAdmissProf(Substitute.For<ITraitementDonneesAdmissProf>());
            Assert.False(classeDeTest.EstUnEvenementDeSuppression(randomData));
        }

        [Theory]
        [InlineAutoData]
        public void EstUnEvenementDAjout_MauvaiseValeur_Fail(string randomData)
        {
            var classeDeTest = new TraiterAdmissProf(Substitute.For<ITraitementDonneesAdmissProf>());
            Assert.False(classeDeTest.EstUnEvenementDAjout(randomData));
        }

        [Theory]
        [InlineAutoData]
        public void EstUnEvenementDeModification_MauvaiseValeur_Fail(string randomData)
        {
            var classeDeTest = new TraiterAdmissProf(Substitute.For<ITraitementDonneesAdmissProf>());
            Assert.False(classeDeTest.EstUnEvenementDeModification(randomData));
        }

        [Theory]
        [InlineAutoData]
        public void TraiterEvenementSuppression_DispSansAvisNiDerogations_OK(long noSequentielDisp, DateTime dhEvenement, string messageEvent)
        {
            var traitementDonnees = Substitute.For<ITraitementDonneesAdmissProf>();
            traitementDonnees.ObtenirListeAvisProf(Arg.Any<long>(), Arg.Any<DateTime>()).Returns(new List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>());
            traitementDonnees.ObtenirListeDerogationsProf(Arg.Any<long>(), Arg.Any<DateTime>()).Returns(new List<PRE_Entites_cpo.Derogation.Entite.Derogation>());
            var classeDeTest = new TraiterAdmissProf(traitementDonnees);
            var attrapeException = false;

            try
            {
                classeDeTest.TraiterEvenementSuppression(new ParamEntreTraiterAdmissProf()
                {
                    DisNoSeq = noSequentielDisp,
                    DHEvenement = dhEvenement,
                    MessageEvenement = messageEvent
                });
            }
            catch (Exception)
            {
                attrapeException = true;
            }

            Assert.False(attrapeException);
        }

        [Theory]
        [InlineAutoData]
        public void TraiterEvenementSuppression_DispSansAvis_OK(long noSequentielDisp, DateTime dhEvenement, string messageEvent)
        {
            var traitementDonnees = Substitute.For<ITraitementDonneesAdmissProf>();
            traitementDonnees.ObtenirListeAvisProf(Arg.Any<long>(), Arg.Any<DateTime>()).Returns(new List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>());
            var classeDeTest = new TraiterAdmissProf(traitementDonnees);
            var attrapeException = false;

            try
            {
                classeDeTest.TraiterEvenementSuppression(new ParamEntreTraiterAdmissProf()
                {
                    DisNoSeq = noSequentielDisp,
                    DHEvenement = dhEvenement,
                    MessageEvenement = messageEvent
                });
            }
            catch (Exception)
            {
                attrapeException = true;
            }

            Assert.False(attrapeException);
        }

        [Theory]
        [InlineAutoData]
        public void TraiterEvenementSuppression_DispSansDerogations_OK(long noSequentielDisp, DateTime dhEvenement, string messageEvent)
        {
            var traitementDonnees = Substitute.For<ITraitementDonneesAdmissProf>();
            traitementDonnees.ObtenirListeDerogationsProf(Arg.Any<long>(), Arg.Any<DateTime>()).Returns(new List<PRE_Entites_cpo.Derogation.Entite.Derogation>());
            var classeDeTest = new TraiterAdmissProf(traitementDonnees);
            var attrapeException = false;

            try
            {
                classeDeTest.TraiterEvenementSuppression(new ParamEntreTraiterAdmissProf()
                {
                    DisNoSeq = noSequentielDisp,
                    DHEvenement = dhEvenement,
                    MessageEvenement = messageEvent
                });
            }
            catch (Exception)
            {
                attrapeException = true;
            }

            Assert.False(attrapeException);
        }

        [Fact]
        public void TraiterEvenementAjoutModification_DispSansAvisNiDerogations_RetourPrematureOK()
        {
            var traitementDonnees = Substitute.For<ITraitementDonneesAdmissProf>();
            
            var classeDeTest = new TraiterAdmissProf(traitementDonnees);
            var sortant = classeDeTest.TraiterEvenementAjoutModification(new ParamEntreTraiterAdmissProf()
            {
                DisNoSeq = 12345,
                DHEvenement = DateTime.Now,
                MessageEvenement = Constantes.MessageEvenementAjout
            });

            Assert.True(!sortant.InfoMsgTrait.Any());
            traitementDonnees.Received(1).VerifierListesAvisEtDerogations(Arg.Any<List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>>(),
                                                                            Arg.Any<List<PRE_Entites_cpo.Derogation.Entite.Derogation>>());
            traitementDonnees.DidNotReceive().GarderAvisActifs(Arg.Any<List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>>());
        }

        [Fact]
        public void TraiterEvenementAjoutModification_DispAvecAvisEtDerogations_SansRetourPrematureOK()
        {
            var traitementDonnees = Substitute.For<ITraitementDonneesAdmissProf>();
            traitementDonnees.VerifierListesAvisEtDerogations(Arg.Any<List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>>(),
                                                               Arg.Any<List<PRE_Entites_cpo.Derogation.Entite.Derogation>>())
                                                                            .Returns(true);

            var classeDeTest = new TraiterAdmissProf(traitementDonnees);
            var sortant = classeDeTest.TraiterEvenementAjoutModification(new ParamEntreTraiterAdmissProf()
            {
                DisNoSeq = 12345,
                DHEvenement = DateTime.Now,
                MessageEvenement = Constantes.MessageEvenementAjout
            });

            Assert.True(!sortant.InfoMsgTrait.Any());
            traitementDonnees.Received(1).VerifierListesAvisEtDerogations(Arg.Any<List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>>(),
                                                                            Arg.Any<List<PRE_Entites_cpo.Derogation.Entite.Derogation>>());
            traitementDonnees.Received(1).GarderAvisActifs(Arg.Any<List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>>());
        }

        [Fact]
        public void TraiterEvenementAjoutModification_DispAvecAvisEtDerogations_SansErreur()
        {
            var traitementDonnees = Substitute.For<ITraitementDonneesAdmissProf>();
            traitementDonnees.VerifierListesAvisEtDerogations(Arg.Any<List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>>(),
                                                               Arg.Any<List<PRE_Entites_cpo.Derogation.Entite.Derogation>>())
                                                                            .Returns(true);

            var classeDeTest = new TraiterAdmissProf(traitementDonnees);
            var sortant = classeDeTest.TraiterEvenementAjoutModification(new ParamEntreTraiterAdmissProf()
            {
                DisNoSeq = 12345,
                DHEvenement = DateTime.Now,
                MessageEvenement = Constantes.MessageEvenementAjout
            });

            Assert.True(!sortant.InfoMsgTrait.Any());
        }
    }
}