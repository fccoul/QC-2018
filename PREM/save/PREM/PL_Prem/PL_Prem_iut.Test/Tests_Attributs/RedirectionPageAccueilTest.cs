using NSubstitute;
using RAMQ.PRE.PL_Prem_iut.Attributs;
using RAMQ.PRE.PL_Prem_iut.Controllers;
using RAMQ.PRE.PL_Prem_iut.Utilitaires;
using System;
using System.Collections;
using System.IO;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Xunit;
using ConstantesIUT = RAMQ.PRE.PL_Prem_iut.Constantes;

namespace RAMQ.PRE.PL_Prem_iut.Test.Tests_Attributs
{
    public class RedirectionPageAccueilTest
    {
        UtilitairesContexte _utilContexte;

        /// <summary>
        /// Constructeur du test.
        /// </summary>
        public RedirectionPageAccueilTest()
        {
            _utilContexte = new UtilitairesContexte();
        }

        /// <summary>
        /// Fonction permettant d'initialiser le contexte du controlleur utilisé.
        /// </summary>
        /// <returns>Contexte du controlleur initialisé.</returns>
        public ActionExecutingContext InitControllerContext()
        {
            //Mocking d'un contexte HTTP.
            _utilContexte.CreerStubHttpContext();

            //Mocking d'un contexte d'exécution.
            ActionExecutingContext filterContext = new ActionExecutingContext();
            var controllerTest = new AutorisationController();
            filterContext.Controller = controllerTest;
            filterContext.Controller.ControllerContext = _utilContexte.FakeControllerContext(controllerTest);

            return filterContext;
        }

        [Fact]
        public void OnActionExecuting_RedirectionPLA5_PasDeRedirectionGroupeDRMG()
        {
            //Arrange

            //Mocking d'un contexte d'exécution.
            ActionExecutingContext filterContext = InitControllerContext();

            //Mocking des groupes de sécurité à vérifier.
            IUtilitaire util = Substitute.For<IUtilitaire>();

            //Considérant que la fonction est appelé trois fois de suite et qu'on ne connait pas 
            //nécessairement la valeur des paramètres d'entrés, cette façon de faire nous permet
            //de ne pas se soucier des paramamètres de la fonction et s'assurer de toujours avoir les
            //mêmes valeurs de retour.
            util.EstDansGroupe(Arg.Any<string>()).Returns(true, false, false);

            //Act
            RedirectionPageAccueil testClass = new RedirectionPageAccueil();
            testClass.UtilitaireInjecte = util;
            testClass.OnActionExecuting(filterContext);

            //Assert
            Assert.Null(filterContext.Result);
        }

        [Fact]
        public void OnActionExecuting_RedirectionPLA5_PasDeRedirectionGroupeComiteParitaire()
        {
            //Arrange

            //Mocking d'un contexte d'exécution.
            ActionExecutingContext filterContext = InitControllerContext();

            //Mocking des groupes de sécurité à vérifier.
            IUtilitaire util = Substitute.For<IUtilitaire>();

            //Considérant que la fonction est appelé trois fois de suite et qu'on ne connait pas 
            //nécessairement la valeur des paramètres d'entrés, cette façon de faire nous permet
            //de ne pas se soucier des paramamètres de la fonction et s'assurer de toujours avoir les
            //mêmes valeurs de retour.
            util.EstDansGroupe(Arg.Any<string>()).Returns(false, true, false);

            //Act
            RedirectionPageAccueil testClass = new RedirectionPageAccueil();
            testClass.UtilitaireInjecte = util;
            testClass.OnActionExecuting(filterContext);

            //Assert
            Assert.Null(filterContext.Result);
        }

        [Fact]
        public void OnActionExecuting_RedirectionPLA5_PasDeRedirectionGroupeSupportTypeProfilComiteParitaire()
        {
            //Arrange
            //Mocking d'un contexte d'exécution.
            ActionExecutingContext filterContext = InitControllerContext();

            //Mocking des groupes de sécurité à vérifier.
            IUtilitaire util = Substitute.For<IUtilitaire>();

            //Considérant que la fonction est appelé trois fois de suite et qu'on ne connait pas 
            //nécessairement la valeur des paramètres d'entrés, cette façon de faire nous permet
            //de ne pas se soucier des paramamètres de la fonction et s'assurer de toujours avoir les
            //mêmes valeurs de retour.
            util.EstDansGroupe(Arg.Any<string>()).Returns(false, false, true);
            util.ObtenirCookie(Arg.Any<string>()).Returns(ConstantesIUT.TypeProfil.ComiteParitaire);

            //Act
            RedirectionPageAccueil testClass = new RedirectionPageAccueil();
            testClass.UtilitaireInjecte = util;
            testClass.OnActionExecuting(filterContext);

            //Assert
            Assert.Null(filterContext.Result);
        }

        [Fact]
        public void OnActionExecuting_RedirectionPLA5_PasDeRedirectionGroupeSupportTypeProfilDRMG()
        {
            //Arrange
            //Mocking d'un contexte d'exécution.
            ActionExecutingContext filterContext = InitControllerContext();

            //Mocking des groupes de sécurité à vérifier.
            IUtilitaire util = Substitute.For<IUtilitaire>();

            //Considérant que la fonction est appelé trois fois de suite et qu'on ne connait pas 
            //nécessairement la valeur des paramètres d'entrés, cette façon de faire nous permet
            //de ne pas se soucier des paramamètres de la fonction et s'assurer de toujours avoir les
            //mêmes valeurs de retour.
            util.EstDansGroupe(Arg.Any<string>()).Returns(false, false, true);
            util.ObtenirCookie(Arg.Any<string>()).Returns(ConstantesIUT.TypeProfil.DRMG);

            //Act
            RedirectionPageAccueil testClass = new RedirectionPageAccueil();
            testClass.UtilitaireInjecte = util;
            testClass.OnActionExecuting(filterContext);

            //Assert
            Assert.Null(filterContext.Result);
        }

        [Fact]
        public void OnActionExecuting_RedirectionPLA5_PasDeRedirectionGroupeSupportTypeProfilVide()
        {
            //Arrange
            //Mocking d'un contexte d'exécution.
            ActionExecutingContext filterContext = InitControllerContext();

            //Mocking des groupes de sécurité à vérifier.
            IUtilitaire util = Substitute.For<IUtilitaire>();

            //Considérant que la fonction est appelé trois fois de suite et qu'on ne connait pas 
            //nécessairement la valeur des paramètres d'entrés, cette façon de faire nous permet
            //de ne pas se soucier des paramamètres de la fonction et s'assurer de toujours avoir les
            //mêmes valeurs de retour.
            util.EstDansGroupe(Arg.Any<string>()).Returns(false, false, true);
            util.ObtenirCookie(Arg.Any<string>()).Returns(string.Empty);

            //Act
            RedirectionPageAccueil testClass = new RedirectionPageAccueil();
            testClass.UtilitaireInjecte = util;
            testClass.OnActionExecuting(filterContext);

            //Assert
            Assert.Null(filterContext.Result);
        }

        [Fact]
        public void OnActionExecuting_RedirectionPLA5_RedirectionGroupeSupportTypeProfilBidon()
        {
            //Arrange
            const string BIDON = "BIDON";

            //Mocking d'un contexte d'exécution.
            ActionExecutingContext filterContext = InitControllerContext();

            //Mocking des groupes de sécurité à vérifier.
            IUtilitaire util = Substitute.For<IUtilitaire>();

            //Considérant que la fonction est appelé trois fois de suite et qu'on ne connait pas 
            //nécessairement la valeur des paramètres d'entrés, cette façon de faire nous permet
            //de ne pas se soucier des paramamètres de la fonction et s'assurer de toujours avoir les
            //mêmes valeurs de retour.
            util.EstDansGroupe(Arg.Any<string>()).Returns(false, false, true);
            util.ObtenirCookie(Arg.Any<string>()).Returns(BIDON);

            //Act
            RedirectionPageAccueil testClass = new RedirectionPageAccueil();
            testClass.UtilitaireInjecte = util;
            testClass.OnActionExecuting(filterContext);

            //Assert
            Assert.NotNull(filterContext.Result);
        }

        [Fact]
        public void OnActionExecuting_RedirectionPLA5_RedirectionAucunGroupe()
        {
            //Arrange
            //Mocking d'un contexte d'exécution.
            ActionExecutingContext filterContext = InitControllerContext();

            //Mocking des groupes de sécurité à vérifier.
            IUtilitaire util = Substitute.For<IUtilitaire>();

            //Considérant que la fonction est appelé trois fois de suite et qu'on ne connait pas 
            //nécessairement la valeur des paramètres d'entrés, cette façon de faire nous permet
            //de ne pas se soucier des paramamètres de la fonction et s'assurer de toujours avoir les
            //mêmes valeurs de retour.
            util.EstDansGroupe(Arg.Any<string>()).Returns(false, false, false);

            //Act
            RedirectionPageAccueil testClass = new RedirectionPageAccueil();
            testClass.UtilitaireInjecte = util;
            testClass.OnActionExecuting(filterContext);

            //Assert
            Assert.NotNull(filterContext.Result);
        }


    }
}
