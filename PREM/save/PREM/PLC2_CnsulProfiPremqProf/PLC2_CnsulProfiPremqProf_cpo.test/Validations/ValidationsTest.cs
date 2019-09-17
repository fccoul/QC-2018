using NSubstitute;
using Ploeh.AutoFixture;
using RAMQ.PRE.PL_RegleAffaiComne_cpo.Validations;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Parametres;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Validations;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Entite;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using LogiqueAffaire = RAMQ.PRE.PL_LogiqueAffaire_cpo.Admissibilite;
using OutilsCommun = RAMQ.PRE.PRE_OutilComun_cpo;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.test.Validations
{
    /// <summary>
    /// Classe de test pour les validations
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public class ValidationsTest : Base.TestBase
    {

        #region Attributs

        private readonly IValidations _validations;
        private readonly IReglesValidations _reglesValidations;
        private readonly LogiqueAffaire.IAdmissibilite _admissibilite;
        private readonly OutilsCommun.IMessageTraitement _messageTraitement;

        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public ValidationsTest()
        {

            _reglesValidations = Substitute.For<IReglesValidations>();
            _admissibilite = Substitute.For<LogiqueAffaire.IAdmissibilite>();
            _messageTraitement = new OutilsCommun.MessageTraitement(new Message.ResolutionMessage());//Substitute.For<OutilsCommun.IMessageTraitement>();

            _validations = new PLC2_CnsulProfiPremqProf_cpo.Validations.Validations(_reglesValidations, _admissibilite, _messageTraitement);

        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ValiderProfessionnel_DecederAvantMars2004_CodeRetour148723()
        {

            //Arranger
            var intrant = Fixture.Create<ValiderProfessionnelEntre>();

            //_admissibilite.VerifierAdmissibiliteProfessionnel(Fixture.Create<VerifierAdmissibiliteProfessionnelFacturerEntre>()).Returns(Fixture.Create<VerifierAdmissibiliteProfessionnelFacturerSorti>());
            _reglesValidations.VerifierDeces(Arg.Any<DateTime>(), Arg.Any<DateTime>()).Returns(true);

            //Action
            var extrant = _validations.ValiderProfessionnel(intrant);

            //Assertion;
            Assert.True(extrant.InfoMsgTrait.First().IdMsg == "148723");

        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ValiderProfessionnel_NonAdmissibleAvantMars2004_CodeRetour148723()
        {
            //Arranger
            var intrant = Fixture.Create<ValiderProfessionnelEntre>();
            var extrantAdmissibiliteMock = Fixture.Create<VerifierAdmissibiliteProfessionnelFacturerSorti>();

            extrantAdmissibiliteMock.PeriodesAdmissibilite = new List<AdmissibiliteFacturer>() {
                new AdmissibiliteFacturer() {
                    CodeRaisonNonAdmissibilite = "NPAR",
                    StatutAdmissibilite = "NA",
                    DateDebutAdmissibilite = new DateTime(2004,1,1),
                    DateFinAdmissibilite = null
                }
            };

            _reglesValidations.VerifierDeces(Arg.Any<DateTime>(), Arg.Any<DateTime>()).Returns(false);
            _admissibilite.VerifierAdmissibiliteProfessionnel(Arg.Any<VerifierAdmissibiliteProfessionnelFacturerEntre>()).Returns(extrantAdmissibiliteMock);

            //Action
            var extrant = _validations.ValiderProfessionnel(intrant);

            //Assertion;
            Assert.True(extrant.InfoMsgTrait.First().IdMsg == "148723");
        }


        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ValiderProfessionnel_DecederAvantDateDuJour_CodeRetour148724()
        {

            //Arranger
            var intrant = Fixture.Create<ValiderProfessionnelEntre>();
            var extrantAdmissibiliteMock = Fixture.Create<VerifierAdmissibiliteProfessionnelFacturerSorti>();

            extrantAdmissibiliteMock.PeriodesAdmissibilite = new List<AdmissibiliteFacturer>() {
                new AdmissibiliteFacturer() {
                    CodeRaisonNonAdmissibilite = "NPAR",
                    StatutAdmissibilite = "NA",
                    DateDebutAdmissibilite = new DateTime(2005,1,1),
                    DateFinAdmissibilite = null
                }
            };
            
            _reglesValidations.VerifierDeces(Arg.Any<DateTime>(), Arg.Any<DateTime>()).Returns(false,false,true);
            _admissibilite.VerifierAdmissibiliteProfessionnel(Arg.Any<VerifierAdmissibiliteProfessionnelFacturerEntre>()).Returns(extrantAdmissibiliteMock);

            //Action
            var extrant = _validations.ValiderProfessionnel(intrant);

            //Assertion;
            Assert.True(extrant.InfoMsgTrait.First().IdMsg == "148724" && extrant.InfoMsgTrait.First().TxtMsgFran.Contains("décédé"));

        }


        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ValiderProfessionnel_NonSpecialisteAvantDateDuJour_CodeRetour148724()
        {

            //Arranger
            var intrant = Fixture.Create<ValiderProfessionnelEntre>();
            var extrantAdmissibiliteMock = Fixture.Create<VerifierAdmissibiliteProfessionnelFacturerSorti>();

            extrantAdmissibiliteMock.PeriodesAdmissibilite = new List<AdmissibiliteFacturer>() {
                new AdmissibiliteFacturer() {
                    CodeRaisonNonAdmissibilite = "NPAR",
                    StatutAdmissibilite = "NA",
                    DateDebutAdmissibilite = new DateTime(2005,1,1),
                    DateFinAdmissibilite = null
                }
            };

            _reglesValidations.VerifierDeces(Arg.Any<DateTime>(), Arg.Any<DateTime>()).Returns(false, false, false);
            _admissibilite.VerifierAdmissibiliteProfessionnel(Arg.Any<VerifierAdmissibiliteProfessionnelFacturerEntre>()).Returns(extrantAdmissibiliteMock);
            _reglesValidations.VerifierSpecialiste(Arg.Any<DateTime>(), Arg.Any<DateTime>()).Returns(true);

            //Action
            var extrant = _validations.ValiderProfessionnel(intrant);

            //Assertion;
            Assert.True(extrant.InfoMsgTrait.First().IdMsg == "148724" && extrant.InfoMsgTrait.First().TxtMsgFran.Contains("spécialiste"));

        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ValiderProfessionnel_NonParticipantAvantDateDuJour_CodeRetour148724()
        {

            //Arranger
            var intrant = Fixture.Create<ValiderProfessionnelEntre>();
            var extrantAdmissibiliteMock = Fixture.Create<VerifierAdmissibiliteProfessionnelFacturerSorti>();
            var extrantParticipantMock = Fixture.Create<VerifierAdmissibiliteProfessionnelFacturerSorti>();

            extrantAdmissibiliteMock.PeriodesAdmissibilite = new List<AdmissibiliteFacturer>() {
                new AdmissibiliteFacturer() {
                    CodeRaisonNonAdmissibilite = "NPAR",
                    StatutAdmissibilite = "NA",
                    DateDebutAdmissibilite = new DateTime(2005,1,1),
                    DateFinAdmissibilite = null
                }
            };

            extrantParticipantMock.PeriodesAdmissibilite = new List<AdmissibiliteFacturer>() {
                new AdmissibiliteFacturer() {
                    CodeRaisonNonAdmissibilite = "NPAR",
                    StatutAdmissibilite = "NA",
                    DateDebutAdmissibilite = new DateTime(2004,1,1),
                    DateFinAdmissibilite = null
                }
            };


            _reglesValidations.VerifierDeces(Arg.Any<DateTime>(), Arg.Any<DateTime>()).Returns(false, false, false);
            _admissibilite.VerifierAdmissibiliteProfessionnel(Arg.Any<VerifierAdmissibiliteProfessionnelFacturerEntre>()).Returns(extrantAdmissibiliteMock, extrantParticipantMock);
            _reglesValidations.VerifierSpecialiste(Arg.Any<DateTime>(), Arg.Any<DateTime>()).Returns(false);

            //Action
            var extrant = _validations.ValiderProfessionnel(intrant);

            //Assertion;
            Assert.True(extrant.InfoMsgTrait.First().IdMsg == "148724" && extrant.InfoMsgTrait.First().TxtMsgFran.Contains("non-participant"));

        }
    }
}