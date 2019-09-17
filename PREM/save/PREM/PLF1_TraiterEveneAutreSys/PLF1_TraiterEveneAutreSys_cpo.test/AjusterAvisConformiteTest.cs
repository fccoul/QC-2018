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

namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo.test
{
    public class AjusterAvisConformiteTest
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

        private static PL_LogiqueAffaire_cpo.AvisConformite.IAvisConformite ObtenirLogiqueAvisConf()
        {
            var accesDonnes = Substitute.For<PL_LogiqueAffaire_cpo.AvisConformite.IAvisConformite>();
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

        #region VerifierSiClasseUne
        [Theory]
        [InlineData(1)]
        public void VerifierSiClasseUne_PasseUn_OK(int classePassee)
        {
            var classeDeTest = new AjusterAvisConformite(ObtenirAccesDonneesMocke(), ObtenirAccesSysExtMocke(), ObtenirLogiqueAvisConf());
            var resultat = classeDeTest.VerifierSiClasseUne(classePassee);
            Assert.True(resultat);
        }

        [Theory]
        [InlineData(2)]
        public void VerifierSiClasseUne_PasseDeux_Fail(int classePassee)
        {
            var classeDeTest = new AjusterAvisConformite(ObtenirAccesDonneesMocke(), ObtenirAccesSysExtMocke(), ObtenirLogiqueAvisConf());
            var resultat = classeDeTest.VerifierSiClasseUne(classePassee);
            Assert.False(resultat);
        }

        #endregion

        #region VerifierParametresEntree

        [Theory]
        [InlineAutoData]
        public void VerifierParametresEntree_ParamsCorrects_OK(int noSeqDisp, int noSeqIndiv, int classeDisp)
        {
            var classeDeTest = new AjusterAvisConformite(ObtenirAccesDonneesMocke(), ObtenirAccesSysExtMocke(), ObtenirLogiqueAvisConf());
            var intrant = new ParamEntreAjusterAvisConformiteMedResidents()
            {
                DisNoSeq = noSeqDisp,
                IndNoSeq = noSeqIndiv,
                PvcClaDisp = classeDisp
            };
            var resultat = classeDeTest.VerifierParametresEntree(intrant, CreerMockResolutionMessage());
            Assert.Empty(resultat.InfoMsgTrait);
        }

        [Theory]
        [InlineAutoData]
        public void VerifierParametresEntree_ParamNoSeqDispIncorrect_MsgTraitPresent(int noSeqDisp, int noSeqIndiv, int classeDisp)
        {
            var classeDeTest = new AjusterAvisConformite(ObtenirAccesDonneesMocke(), ObtenirAccesSysExtMocke(), ObtenirLogiqueAvisConf());
            var intrant = new ParamEntreAjusterAvisConformiteMedResidents()
            {
                DisNoSeq = -noSeqDisp,
                IndNoSeq = noSeqIndiv,
                PvcClaDisp = classeDisp
            };

            var resultat = classeDeTest.VerifierParametresEntree(intrant, CreerMockResolutionMessage());
            Assert.True(resultat.InfoMsgTrait.Any());
        }

        [Theory]
        [InlineAutoData]
        public void VerifierParametresEntree_ParamNoSeqIndivIncorrect_MsgTraitPresent(int noSeqDisp, int noSeqIndiv, int classeDisp)
        {
            var classeDeTest = new AjusterAvisConformite(ObtenirAccesDonneesMocke(), ObtenirAccesSysExtMocke(), ObtenirLogiqueAvisConf());
            var intrant = new ParamEntreAjusterAvisConformiteMedResidents()
            {
                DisNoSeq = noSeqDisp,
                IndNoSeq = -noSeqIndiv,
                PvcClaDisp = classeDisp
            };

            var resultat = classeDeTest.VerifierParametresEntree(intrant, CreerMockResolutionMessage());
            Assert.True(resultat.InfoMsgTrait.Any());
        }

        [Theory]
        [InlineAutoData]
        public void VerifierParametresEntree_ParamNoClasseIncorrect_MsgTraitPresent(int noSeqDisp, int noSeqIndiv, int classeDisp)
        {
            var classeDeTest = new AjusterAvisConformite(ObtenirAccesDonneesMocke(), ObtenirAccesSysExtMocke(), ObtenirLogiqueAvisConf());
            var intrant = new ParamEntreAjusterAvisConformiteMedResidents()
            {
                DisNoSeq = noSeqDisp,
                IndNoSeq = noSeqIndiv,
                PvcClaDisp = -classeDisp
            };

            var resultat = classeDeTest.VerifierParametresEntree(intrant, CreerMockResolutionMessage());
            Assert.True(resultat.InfoMsgTrait.Any());
        }

        #endregion

        #region ObtenirDispensateursAssociesDeClasseCinq

        [Theory]
        [InlineAutoData]
        public void ObtenirDispensateursAssociesDeClasseCinq_IndivSansDispClasseCinq_ResultatVide(int noSeqIndiv)
        {
            var accesSysExt = ObtenirAccesSysExtMocke();
            accesSysExt.ObtenirRelDispIndiv(Arg.Any<PRE_SysExt_cpo.FIP.EPZ3.Parametre.ObtnRelDispIndivEntre>())
                .Returns(new PRE_SysExt_cpo.FIP.EPZ3.Parametre.ObtnRelDispIndivSorti()
                {
                    NumerosSequentielDispensateur = new List<long?>() { 12345, 54321 },
                    NumerosClasseDispensateur = new List<int?>() { 1, 3 }
                }
                );
            var classeDeTest = new AjusterAvisConformite(ObtenirAccesDonneesMocke(), accesSysExt, ObtenirLogiqueAvisConf());
            var listeFinale = classeDeTest.ObtenirDispensateursAssociesDeClasseCinq(noSeqIndiv);
            Assert.Empty(listeFinale);
        }

        [Theory]
        [InlineAutoData]
        public void ObtenirDispensateursAssociesDeClasseCinq_IndivSansDispClasseCinq_ListeContientNoDisp(int noSeqIndiv, int noDispClasseCinq)
        {
            var accesSysExt = ObtenirAccesSysExtMocke();
            accesSysExt.ObtenirRelDispIndiv(Arg.Any<PRE_SysExt_cpo.FIP.EPZ3.Parametre.ObtnRelDispIndivEntre>())
                .Returns(new PRE_SysExt_cpo.FIP.EPZ3.Parametre.ObtnRelDispIndivSorti()
                {
                    NumerosSequentielDispensateur = new List<long?>() { 12345, noDispClasseCinq },
                    NumerosClasseDispensateur = new List<int?>() { 1, 5 }
                }
                );
            var classeDeTest = new AjusterAvisConformite(ObtenirAccesDonneesMocke(), accesSysExt, ObtenirLogiqueAvisConf());
            var listeFinale = classeDeTest.ObtenirDispensateursAssociesDeClasseCinq(noSeqIndiv);
            Assert.True(listeFinale.Contains(noDispClasseCinq));
        }

        [Theory]
        [InlineAutoData]
        public void ObtenirDispensateursAssociesDeClasseCinq_CompteNoSeqDispSuperieurAuxNoClasse_ResultatVide(int noSeqIndiv, int noDispClasseCinq)
        {
            var accesSysExt = ObtenirAccesSysExtMocke();
            accesSysExt.ObtenirRelDispIndiv(Arg.Any<PRE_SysExt_cpo.FIP.EPZ3.Parametre.ObtnRelDispIndivEntre>())
                .Returns(new PRE_SysExt_cpo.FIP.EPZ3.Parametre.ObtnRelDispIndivSorti()
                {
                    NumerosSequentielDispensateur = new List<long?>() { noDispClasseCinq },
                    NumerosClasseDispensateur = new List<int?>() { 1, 5 }
                }
                );
            var classeDeTest = new AjusterAvisConformite(ObtenirAccesDonneesMocke(), accesSysExt, ObtenirLogiqueAvisConf());
            var listeFinale = classeDeTest.ObtenirDispensateursAssociesDeClasseCinq(noSeqIndiv);
            Assert.Empty(listeFinale);
        }

        #endregion


        #region ObtenirIDAvisConformiteAModifier
        [Fact]
        public void ObtenirIDAvisConformiteAModifier_ListeSansDispensateur_ResultatVide()
        {
            var classeDeTest = new AjusterAvisConformite(ObtenirAccesDonneesMocke(), ObtenirAccesSysExtMocke(), ObtenirLogiqueAvisConf());

            var resultat = classeDeTest.ObtenirIDAvisConformiteAModifier(new List<long>());

            Assert.Empty(resultat);
        }

        [Theory]
        [InlineAutoData]
        public void ObtenirIDAvisConformiteAModifier_AvisValideSansStatut_ResultatVide(long noSeqDisp)
        {
            var classeDeTest = Substitute.For<AjusterAvisConformite>(ObtenirAccesDonneesMocke(), ObtenirAccesSysExtMocke(), ObtenirLogiqueAvisConf());

            var paramRetourne = new PRE_Entites_cpo.AvisConformite.Parametre.ObtenirLesAvisConformiteSorti()
            {
                ListeAvisConformite = new List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>()
                {
                    new PRE_Entites_cpo.AvisConformite.Entite.AvisConformite()
                    {
                        NumeroSequentielDispensateur = noSeqDisp,
                        DateDebutEngagement = DateTime.MinValue,
                        DateFinEngagement = DateTime.MaxValue,
                    }
                }
            };

            classeDeTest.ObtenirAvisConformite(noSeqDisp).Returns(paramRetourne);

            var resultat = classeDeTest.ObtenirIDAvisConformiteAModifier(new List<long>() { noSeqDisp });

            Assert.Empty(resultat);
        }

        [Theory]
        [InlineAutoData]
        public void ObtenirIDAvisConformiteAModifier_AvisValideStatutValide_OK(long noSeqDisp, long noSeqEngagement)
        {
            var classeDeTest = Substitute.For<AjusterAvisConformite>(ObtenirAccesDonneesMocke(), ObtenirAccesSysExtMocke(), ObtenirLogiqueAvisConf());

            var paramRetourne = new PRE_Entites_cpo.AvisConformite.Parametre.ObtenirLesAvisConformiteSorti()
            {
                ListeAvisConformite = new List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>()
                {
                    new PRE_Entites_cpo.AvisConformite.Entite.AvisConformite()
                    {
                        NumeroSequentielDispensateur = noSeqDisp,
                        NumeroSequentielEngagement = noSeqEngagement,
                        DateDebutEngagement = DateTime.MinValue,
                        DateFinEngagement = DateTime.MaxValue,
                        ListeStatutAvisConformite = new List<PRE_Entites_cpo.AvisConformite.Entite.StatutAvisConformite>()
                        {
                            new PRE_Entites_cpo.AvisConformite.Entite.StatutAvisConformite()
                            {
                                StatutEngagement = "AUT",
                                IndicateurStatutEngagementAttente = "O",
                                DateDebutStatutEngagement = DateTime.MinValue,
                                DateFinStatutEngagement = DateTime.MaxValue,
                                NumeroSequentielEngagement = noSeqEngagement
                            }
                        }
                    }
                }
            };

            classeDeTest.ObtenirAvisConformite(noSeqDisp).Returns(paramRetourne);

            var resultat = classeDeTest.ObtenirIDAvisConformiteAModifier(new List<long>() { noSeqDisp });

            Assert.True(resultat.Contains(noSeqEngagement));
        }

        [Theory]
        [InlineAutoData]
        public void ObtenirIDAvisConformiteAModifier_AvisValideStatutEngagementAttenteNon_ResultatVide(long noSeqDisp, long noSeqEngagement)
        {
            var classeDeTest = Substitute.For<AjusterAvisConformite>(ObtenirAccesDonneesMocke(), ObtenirAccesSysExtMocke(), ObtenirLogiqueAvisConf());

            var paramRetourne = new PRE_Entites_cpo.AvisConformite.Parametre.ObtenirLesAvisConformiteSorti()
            {
                ListeAvisConformite = new List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>()
                {
                    new PRE_Entites_cpo.AvisConformite.Entite.AvisConformite()
                    {
                        NumeroSequentielDispensateur = noSeqDisp,
                        NumeroSequentielEngagement = noSeqEngagement,
                        DateDebutEngagement = DateTime.MinValue,
                        DateFinEngagement = DateTime.MaxValue,
                        ListeStatutAvisConformite = new List<PRE_Entites_cpo.AvisConformite.Entite.StatutAvisConformite>()
                        {
                            new PRE_Entites_cpo.AvisConformite.Entite.StatutAvisConformite()
                            {
                                StatutEngagement = "AUT",
                                IndicateurStatutEngagementAttente = "N",
                                DateDebutStatutEngagement = DateTime.MinValue,
                                DateFinStatutEngagement = DateTime.MaxValue,
                                NumeroSequentielEngagement = noSeqEngagement
                            }
                        }
                    }
                }
            };

            classeDeTest.ObtenirAvisConformite(noSeqDisp).Returns(paramRetourne);

            var resultat = classeDeTest.ObtenirIDAvisConformiteAModifier(new List<long>() { noSeqDisp });

            Assert.Empty(resultat);
        }

        [Theory]
        [InlineAutoData]
        public void ObtenirIDAvisConformiteAModifier_AvisValideStatutNonAUT_ResultatVide(long noSeqDisp, long noSeqEngagement)
        {
            var classeDeTest = Substitute.For<AjusterAvisConformite>(ObtenirAccesDonneesMocke(), ObtenirAccesSysExtMocke(), ObtenirLogiqueAvisConf());

            var paramRetourne = new PRE_Entites_cpo.AvisConformite.Parametre.ObtenirLesAvisConformiteSorti()
            {
                ListeAvisConformite = new List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>()
                {
                    new PRE_Entites_cpo.AvisConformite.Entite.AvisConformite()
                    {
                        NumeroSequentielDispensateur = noSeqDisp,
                        NumeroSequentielEngagement = noSeqEngagement,
                        DateDebutEngagement = DateTime.MinValue,
                        DateFinEngagement = DateTime.MaxValue,
                        ListeStatutAvisConformite = new List<PRE_Entites_cpo.AvisConformite.Entite.StatutAvisConformite>()
                        {
                            new PRE_Entites_cpo.AvisConformite.Entite.StatutAvisConformite()
                            {
                                StatutEngagement = "XXX",
                                IndicateurStatutEngagementAttente = "O",
                                DateDebutStatutEngagement = DateTime.MinValue,
                                DateFinStatutEngagement = DateTime.MaxValue,
                                NumeroSequentielEngagement = noSeqEngagement
                            }
                        }
                    }
                }
            };

            classeDeTest.ObtenirAvisConformite(noSeqDisp).Returns(paramRetourne);

            var resultat = classeDeTest.ObtenirIDAvisConformiteAModifier(new List<long>() { noSeqDisp });

            Assert.Empty(resultat);
        }

        [Theory]
        [InlineAutoData]
        public void ObtenirIDAvisConformiteAModifier_AvisValideStatutExpire_ResultatVide(long noSeqDisp, long noSeqEngagement)
        {
            var classeDeTest = Substitute.For<AjusterAvisConformite>(ObtenirAccesDonneesMocke(), ObtenirAccesSysExtMocke(), ObtenirLogiqueAvisConf());

            var paramRetourne = new PRE_Entites_cpo.AvisConformite.Parametre.ObtenirLesAvisConformiteSorti()
            {
                ListeAvisConformite = new List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>()
                {
                    new PRE_Entites_cpo.AvisConformite.Entite.AvisConformite()
                    {
                        NumeroSequentielDispensateur = noSeqDisp,
                        NumeroSequentielEngagement = noSeqEngagement,
                        DateDebutEngagement = DateTime.MinValue,
                        DateFinEngagement = DateTime.MaxValue,
                        ListeStatutAvisConformite = new List<PRE_Entites_cpo.AvisConformite.Entite.StatutAvisConformite>()
                        {
                            new PRE_Entites_cpo.AvisConformite.Entite.StatutAvisConformite()
                            {
                                StatutEngagement = "AUT",
                                IndicateurStatutEngagementAttente = "O",
                                DateDebutStatutEngagement = DateTime.MinValue,
                                DateFinStatutEngagement = DateTime.MinValue,
                                NumeroSequentielEngagement = noSeqEngagement
                            }
                        }
                    }
                }
            };

            classeDeTest.ObtenirAvisConformite(noSeqDisp).Returns(paramRetourne);

            var resultat = classeDeTest.ObtenirIDAvisConformiteAModifier(new List<long>() { noSeqDisp });

            Assert.Empty(resultat);
        }

        [Theory]
        [InlineAutoData]
        public void ObtenirIDAvisConformiteAModifier_AvisExpireStatutValide_ResultatVide(long noSeqDisp, long noSeqEngagement)
        {
            var classeDeTest = Substitute.For<AjusterAvisConformite>(ObtenirAccesDonneesMocke(), ObtenirAccesSysExtMocke(), ObtenirLogiqueAvisConf());

            var paramRetourne = new PRE_Entites_cpo.AvisConformite.Parametre.ObtenirLesAvisConformiteSorti()
            {
                ListeAvisConformite = new List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>()
                {
                    new PRE_Entites_cpo.AvisConformite.Entite.AvisConformite()
                    {
                        NumeroSequentielDispensateur = noSeqDisp,
                        NumeroSequentielEngagement = noSeqEngagement,
                        DateDebutEngagement = DateTime.MinValue,
                        DateFinEngagement = DateTime.MinValue,
                        ListeStatutAvisConformite = new List<PRE_Entites_cpo.AvisConformite.Entite.StatutAvisConformite>()
                        {
                            new PRE_Entites_cpo.AvisConformite.Entite.StatutAvisConformite()
                            {
                                StatutEngagement = "AUT",
                                IndicateurStatutEngagementAttente = "O",
                                DateDebutStatutEngagement = DateTime.MinValue,
                                DateFinStatutEngagement = DateTime.MaxValue,
                                NumeroSequentielEngagement = noSeqEngagement
                            }
                        }
                    }
                }
            };

            classeDeTest.ObtenirAvisConformite(noSeqDisp).Returns(paramRetourne);

            var resultat = classeDeTest.ObtenirIDAvisConformiteAModifier(new List<long>() { noSeqDisp });

            Assert.Empty(resultat);
        }

        #endregion

        #region ObtenirAvisConformite
        [Theory]
        [InlineAutoData]
        public void ObtenirAvisConformite_DispSansAvis_SansErreur(long noSeqDisp)
        {
            var logiqueAvisConf = ObtenirLogiqueAvisConf();
            logiqueAvisConf.ObtenirLesAvisConformite(Arg.Any<PRE_Entites_cpo.AvisConformite.Parametre.ObtenirLesAvisConformiteEntre>())
                .Returns(new PRE_Entites_cpo.AvisConformite.Parametre.ObtenirLesAvisConformiteSorti()
                {
                    ListeAvisConformite = new List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>() { }
                });

            var classeDeTest = new AjusterAvisConformite(ObtenirAccesDonneesMocke(), ObtenirAccesSysExtMocke(), logiqueAvisConf);

            var listeAvis = classeDeTest.ObtenirAvisConformite(noSeqDisp);

            Assert.Empty(listeAvis.InfoMsgTrait);
        }

        [Theory]
        [InlineAutoData]
        public void ObtenirAvisConformite_DispSansAvis_ListeAvisVide(long noSeqDisp)
        {
            var logiqueAvisConf = ObtenirLogiqueAvisConf();
            logiqueAvisConf.ObtenirLesAvisConformite(Arg.Any<PRE_Entites_cpo.AvisConformite.Parametre.ObtenirLesAvisConformiteEntre>())
                .Returns(new PRE_Entites_cpo.AvisConformite.Parametre.ObtenirLesAvisConformiteSorti()
                {
                    ListeAvisConformite = new List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>() { }
                });

            var classeDeTest = new AjusterAvisConformite(ObtenirAccesDonneesMocke(), ObtenirAccesSysExtMocke(), logiqueAvisConf);

            var listeAvis = classeDeTest.ObtenirAvisConformite(noSeqDisp);

            Assert.Empty(listeAvis.ListeAvisConformite);
        }

        [Theory]
        [InlineAutoData]
        public void ObtenirAvisConformite_DispAvecAvis_ListeAvisRemplie(long noSeqDisp, long noSeqAvis)
        {
            var logiqueAvisConf = ObtenirLogiqueAvisConf();
            logiqueAvisConf.ObtenirLesAvisConformite(Arg.Any<PRE_Entites_cpo.AvisConformite.Parametre.ObtenirLesAvisConformiteEntre>())
                .Returns(new PRE_Entites_cpo.AvisConformite.Parametre.ObtenirLesAvisConformiteSorti()
                {
                    ListeAvisConformite = new List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>()
                    {
                        new PRE_Entites_cpo.AvisConformite.Entite.AvisConformite()
                        {
                            NumeroSequentielEngagement = noSeqAvis
                        }
                    }
                });

            var classeDeTest = new AjusterAvisConformite(ObtenirAccesDonneesMocke(), ObtenirAccesSysExtMocke(), logiqueAvisConf);

            var listeAvis = classeDeTest.ObtenirAvisConformite(noSeqDisp);

            Assert.True(listeAvis.ListeAvisConformite.Exists(x => x.NumeroSequentielEngagement == noSeqAvis));
        }
        #endregion

        #region ModifierAvisConformiteACorriger
        [Theory]
        [InlineAutoData]
        public void ModifierAvisConformiteACorriger_AvecDispSansAvis_OK(long noSeqDisp)
        {
            var accesDonneesPRE = ObtenirAccesDonneesMocke();
            accesDonneesPRE.ModifierAvisConformiteStatut(Arg.Any<PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ModifierAvisConformiteStatutEntre>()).
                Returns(new PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ModifierAvisConformiteStatutSorti()
                {
                    InfoMsgTrait = new List<Message.MsgTrait>() { }
                });
            var classeDeTest = new AjusterAvisConformite(accesDonneesPRE, ObtenirAccesSysExtMocke(), ObtenirLogiqueAvisConf());
            classeDeTest.ModifierAvisConformiteACorriger(noSeqDisp, new List<long>());
            Assert.True(true);
        }

        [Theory]
        [InlineAutoData]
        public void ModifierAvisConformiteACorriger_SansDispAvecAvis_OK(List<long> listeIDAvis)
        {
            var accesDonneesPRE = ObtenirAccesDonneesMocke();
            accesDonneesPRE.ModifierAvisConformiteStatut(Arg.Any<PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ModifierAvisConformiteStatutEntre>()).
                Returns(new PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ModifierAvisConformiteStatutSorti()
                {
                    InfoMsgTrait = new List<Message.MsgTrait>() { }
                });
            var classeDeTest = new AjusterAvisConformite(accesDonneesPRE, ObtenirAccesSysExtMocke(), ObtenirLogiqueAvisConf());
            Assert.Throws<ArgumentNullException>(() => classeDeTest.ModifierAvisConformiteACorriger(0, listeIDAvis));
        }
        #endregion
    }
}
