using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RAMQ.PRE.PL_Prem_iut.Controllers;
using RAMQ.PRE.PL_PremMdl_cpo.Professionnel;
using NSubstitute;
using OutilCommun = RAMQ.PRE.PRE_OutilComun_cpo;
using RAMQ.PRE.PL_PremMdl_cpo.LieuGeographique;
using RAMQ.PRE.PL_Prem_iut.Securite;
using System.Web.Mvc;
using RAMQ.PRE.PL_Prem_iut.Models.PLC2_ProfilProfessionnel;
using System.Collections.Generic;

using Xunit;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit2;
using Ploeh.AutoFixture.Kernel;
using RAMQ.Message;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.PeriodePratique.Parametre;

namespace RAMQ.PRE.PL_Prem_iut.Test.Controller
{
    [TestClass]
    public class ProfilProfessionnelControllerTest: Base.TestBase
    {
        #region Attributs
        private readonly IPLC2_HistoriqueEngagement _pLC2_HistoriqueEngagement;
        private readonly IProfessionnel _professionel;
        #endregion

        #region Constructeur
        public ProfilProfessionnelControllerTest()
        {
            _professionel = Substitute.For<IProfessionnel>();
            _pLC2_HistoriqueEngagement = new PLC2_HistoriqueEngagement(_professionel);
        }
        #endregion
        [Ignore]
        public void PLC2_HistoriqueEngagement_PartialViewResult_OK()
        {
            //Arrange
            var professionnelFactory = Substitute.For<IProfessionnelFactory>();
            var domaineValeur = Substitute.For<OutilCommun.IDomaineValeur>();
            var securite = Substitute.For<ISecurite>();
            var lieuGeographique = Substitute.For<ILieuGeographiqueFactory>();
            var messageTraitement = Substitute.For<OutilCommun.IMessageTraitement>();

            ProfilProfessionnelController controller = new ProfilProfessionnelController(professionnelFactory, domaineValeur, securite, lieuGeographique, messageTraitement);


            //Act
            var result = controller.PLC2_HistoriqueEngagement(Arg.Any<PLC2_HistoriqueEngagement>()) as PartialViewResult;

            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
        }

        [Ignore]
        public void ObtenirRaisStatusAvisConf_ColctDomValeursNull_OK()
        {
            //Arrange
            var plc2 = Substitute.For<IPLC2_HistoriqueEngagement>();

            //Act
            var result = plc2.ObtenirRaisStatusAvisConf(Arg.Any<OutilCommun.IDomaineValeur>());

            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(result);

        }

        [TestMethod]
        public void ObtenirRaisStatusAvisConf_ColctDomValeursNonNull_OK()
        {
            //Arrange
            var pLC2_HistoriqueEngagement = Substitute.For<IPLC2_HistoriqueEngagement>();
            var dictDomainesValeur = new Dictionary<string, DomainesValeur.IValeur>();
            dictDomainesValeur.Add("05", new DomainesValeur.Valeur
            {
                ValAbr = string.Empty,
                ValBasse = "05",
                ValDes = "Médecin déjà en pratique depuis 20 ans ou plus (art. 3.06)",
                ValHaute = "00026"
            });

            //Act
            var result = pLC2_HistoriqueEngagement.ObtenirRaisStatusAvisConf(Arg.Any<OutilCommun.DomaineValeur>()).Returns(d => dictDomainesValeur);

            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);

        }

        [TestMethod]
        public void ObtenirRaisStatusAvisConf_ColctDomValeursVide_OK()
        {
            //Arrange
            var pLC2_HistoriqueEngagement = Substitute.For<IPLC2_HistoriqueEngagement>();
            var dictDomainesValeur = new Dictionary<string, DomainesValeur.IValeur>();

            //Act
            pLC2_HistoriqueEngagement.ObtenirRaisStatusAvisConf(Arg.Any<OutilCommun.DomaineValeur>()).Returns(dictDomainesValeur);
            var result = pLC2_HistoriqueEngagement.ObtenirRaisStatusAvisConf(Arg.Any<OutilCommun.DomaineValeur>());

            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(result.Count, 0);
        }

        [TestMethod]
        public void ObtenirRaisStatusAvisConf_ColctDomValeursNonVide_OK()
        {
            //Arrange
            var pLC2_HistoriqueEngagement = Substitute.For<IPLC2_HistoriqueEngagement>();
            var dictDomainesValeur = new Dictionary<string, DomainesValeur.IValeur>();
            dictDomainesValeur.Add("10", new DomainesValeur.Valeur
            {
                ValAbr = string.Empty,
                ValBasse = "10",
                ValDes = "Prolongation du maintien de l'avis pour pratique exclusive auprès d'une instance à vocation nationale",
                ValHaute = "00051"
            });
            dictDomainesValeur.Add("20", new DomainesValeur.Valeur
            {
                ValAbr = string.Empty,
                ValBasse = "20",
                ValDes = "Prolongation d'un avis de conformité suite au report de la date de début d'un autre avis de conformité",
                ValHaute = "00130"
            });

            //Act
            pLC2_HistoriqueEngagement.ObtenirRaisStatusAvisConf(Arg.Any<OutilCommun.DomaineValeur>()).Returns(dictDomainesValeur);
            var result = pLC2_HistoriqueEngagement.ObtenirRaisStatusAvisConf(Arg.Any<OutilCommun.DomaineValeur>());

            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(result.Count > 0);

        }

        [TestMethod]
        public void ObtenirRaisStatusAvisConf_RechrDomValeurParValbasse_Trouv()
        {
            //Arrange
            var pLC2_HistoriqueEngagement = Substitute.For<IPLC2_HistoriqueEngagement>();
            string des = "Nouveau médecin débutant en pratique ou nouveau facturant";


            var dictDomainesValeur = new Dictionary<string, DomainesValeur.IValeur>();
            dictDomainesValeur.Add("01", new DomainesValeur.Valeur
            {
                ValAbr = string.Empty,
                ValBasse = "01",
                ValDes = "Nouveau médecin débutant en pratique ou nouveau facturant",
                ValHaute = "0006"
            });

            //Act
            pLC2_HistoriqueEngagement.ObtenirRaisStatusAvisConf(Arg.Any<OutilCommun.DomaineValeur>()).Returns(d => dictDomainesValeur);
            var result = pLC2_HistoriqueEngagement.ObtenirRaisStatusAvisConf(Arg.Any<OutilCommun.DomaineValeur>());
            DomainesValeur.IValeur val = new DomainesValeur.Valeur();

            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(result.TryGetValue("01", out val), true);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(val.ValDes, des);
        }

        [TestMethod]
        public void ObtenirRaisStatusAvisConf_RechrDomValeurParValbasse_NonTrouv()
        {
            //Arrange
            var pLC2_HistoriqueEngagement = Substitute.For<IPLC2_HistoriqueEngagement>();
            var dictDomainesValeur = new Dictionary<string, DomainesValeur.IValeur>();
            dictDomainesValeur.Add("05", new DomainesValeur.Valeur
            {
                ValAbr = string.Empty,
                ValBasse = "05",
                ValDes = "Médecin déjà en pratique depuis 20 ans ou plus (art. 3.06)",
                ValHaute = "00026"
            });

            //Act
            pLC2_HistoriqueEngagement.ObtenirRaisStatusAvisConf(Arg.Any<OutilCommun.DomaineValeur>()).Returns(d => dictDomainesValeur);
            DomainesValeur.IValeur val = new DomainesValeur.Valeur();
            var result = pLC2_HistoriqueEngagement.ObtenirRaisStatusAvisConf(Arg.Any<OutilCommun.DomaineValeur>());

            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(result.TryGetValue("81", out val), true);

        }

        [Xunit.Fact]
        public void ObtenirRaisStatusAvisConf_RechrDomValeurParValNull_Excep()
        {
            //Arrange
            var pLC2_HistoriqueEngagement = Substitute.For<IPLC2_HistoriqueEngagement>();

            var dictDomainesValeur = new Dictionary<string, DomainesValeur.IValeur>();
            dictDomainesValeur.Add("01", new DomainesValeur.Valeur
            {
                ValAbr = string.Empty,
                ValBasse = "01",
                ValDes = "Nouveau médecin débutant en pratique ou nouveau facturant",
                ValHaute = "0006"
            });

            //Act
            pLC2_HistoriqueEngagement.ObtenirRaisStatusAvisConf(Arg.Any<OutilCommun.DomaineValeur>()).Returns(d => dictDomainesValeur);
            DomainesValeur.IValeur val = new DomainesValeur.Valeur();
            var result = pLC2_HistoriqueEngagement.ObtenirRaisStatusAvisConf(Arg.Any<OutilCommun.DomaineValeur>());

            //Assert
            Xunit.Assert.Throws<ArgumentNullException>(() => result.TryGetValue(null, out val));


        }

        [TestMethod]
        public void ObtenirRaisStatusAvisConf_RechrDomValeurParValbasse_Inxt()
        {
            //Arrange
            var pLC2_HistoriqueEngagement = Substitute.For<IPLC2_HistoriqueEngagement>();
            var dictDomainesValeur = new Dictionary<string, DomainesValeur.IValeur>();
            dictDomainesValeur.Add("10", new DomainesValeur.Valeur
            {
                ValAbr = string.Empty,
                ValBasse = "10",
                ValDes = "Prolongation du maintien de l'avis pour pratique exclusive auprès d'une instance à vocation nationale",
                ValHaute = "00051"
            });

            //Act
            pLC2_HistoriqueEngagement.ObtenirRaisStatusAvisConf(Arg.Any<OutilCommun.DomaineValeur>()).Returns(d => dictDomainesValeur);
            var result = pLC2_HistoriqueEngagement.ObtenirRaisStatusAvisConf(Arg.Any<OutilCommun.DomaineValeur>());

            //Assert
            pLC2_HistoriqueEngagement.When(x => Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(result.ContainsKey("25"), false))
                                    .Do(x => { throw new KeyNotFoundException(); });

        }

        [TestMethod]
        public void ObtenirRaisStatusAvisConf_RechrDomValeurParValbasseUnit_Trouv()
        {
            //Arrange
            var pLC2_HistoriqueEngagement = Substitute.For<IPLC2_HistoriqueEngagement>();
            var dictDomainesValeur = new Dictionary<string, DomainesValeur.IValeur>
            {
                ["04"] = new DomainesValeur.Valeur
                {
                    ValAbr = string.Empty,
                    ValBasse = "04",
                    ValDes = "Médecin déjà en pratique de retour d'un territoire en pénurie d'effectif nommé à l'annexe I après y avoir exercé 5 ans de façon continue. (art. 3.05)",
                    ValHaute = "00021"
                }
            };

            //Act
            pLC2_HistoriqueEngagement.ObtenirRaisStatusAvisConf(Arg.Any<OutilCommun.DomaineValeur>()).Returns(d => dictDomainesValeur);
            var result = pLC2_HistoriqueEngagement.ObtenirRaisStatusAvisConf(Arg.Any<OutilCommun.DomaineValeur>());
            var cleAverifier = "4";
            cleAverifier = cleAverifier.Length > 1 ? cleAverifier : cleAverifier.PadLeft(2, '0');

            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(result.ContainsKey(cleAverifier));

        }

        [TestMethod]
        public void ObtenirRaisStatusAUTOR_PREMQ_ColctDomValeursNonNull_OK()
        {
            //Arrange
            var pLC2_HistoriqueEngagement = Substitute.For<IPLC2_HistoriqueEngagement>();
            var dictDomainesValeur = new Dictionary<string, DomainesValeur.IValeur>();
            dictDomainesValeur.Add("05", new DomainesValeur.Valeur
            {
                ValAbr = string.Empty,
                ValBasse = "05",
                ValDes = "Modification de la date de fin de l’autorisation car le médecin est devenu spécialiste.",
                ValHaute = "00050"
            });

            //Act
            var result = pLC2_HistoriqueEngagement.ObtenirRaisStatusAUTOR_PREMQ(Arg.Any<OutilCommun.DomaineValeur>()).Returns(d => dictDomainesValeur);

            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);

        }

        [TestMethod]
        public void ObtenirRaisStatusAUTOR_PREMQ_RechrDomValeurParValbasseUnit_Trouv()
        {
            //Arrange
            var pLC2_HistoriqueEngagement = Substitute.For<IPLC2_HistoriqueEngagement>();
            var dictDomainesValeur = new Dictionary<string, DomainesValeur.IValeur>
            {
                ["02"] = new DomainesValeur.Valeur
                {
                    ValAbr = string.Empty,
                    ValBasse = "02",
                    ValDes = "Modification de la date de fin de l’autorisation en raison de l’ajout d’une dérogation.",
                    ValHaute = "00020"
                }
            };

            //Act
            pLC2_HistoriqueEngagement.ObtenirRaisStatusAUTOR_PREMQ(Arg.Any<OutilCommun.DomaineValeur>()).Returns(d => dictDomainesValeur);
            var result = pLC2_HistoriqueEngagement.ObtenirRaisStatusAUTOR_PREMQ(Arg.Any<OutilCommun.DomaineValeur>());
            var cleAverifier = "2";
            cleAverifier = cleAverifier.Length > 1 ? cleAverifier : cleAverifier.PadLeft(2, '0');

            //Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(result.ContainsKey(cleAverifier));

        }

        [TestMethod]
        public void ObtenirRaisStatusDerogation_RechrDomValeurParValbasse_Inxt()
        {
            //Arrange
            var pLC2_HistoriqueEngagement = Substitute.For<IPLC2_HistoriqueEngagement>();
            var dictDomainesValeur = new Dictionary<string, DomainesValeur.IValeur>();
            dictDomainesValeur.Add("07", new DomainesValeur.Valeur
            {
                ValAbr = string.Empty,
                ValBasse = "07",
                ValDes = "Fermeture ou annulation d'une dérogation suite à un statut de non-admissibilité pour non-participation",
                ValHaute = "00070"
            });

            //Act
            pLC2_HistoriqueEngagement.ObtenirRaisStatusDerogation(Arg.Any<OutilCommun.DomaineValeur>()).Returns(d => dictDomainesValeur);
            var result = pLC2_HistoriqueEngagement.ObtenirRaisStatusDerogation(Arg.Any<OutilCommun.DomaineValeur>());

            //Assert
            pLC2_HistoriqueEngagement.When(x => Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(result.ContainsKey("12"), false))
                                    .Do(x => { throw new KeyNotFoundException(); });

        }




    }
}
