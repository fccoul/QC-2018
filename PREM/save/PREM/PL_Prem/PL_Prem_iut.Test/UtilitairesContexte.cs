using NSubstitute;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RAMQ.PRE.PL_Prem_iut.Test
{
    public class UtilitairesContexte
    {
        private const string RootPath = "/basepath";
        protected static Uri BaseUri
        {
            get { return new Uri("http://localhost:4000"); }
        }

        protected HttpContextBase HttpContextSub { get; private set; }
        protected HttpRequestBase RequestSub { get; private set; }
        protected HttpResponseBase ResponseSub { get; private set; }

        public ControllerContext FakeControllerContext(ControllerBase controller)
        {
            InitialiseFakeHttpContext();
            var routeData = new RouteData();
            routeData.Values.Add("controller", "Autorisation");
            return new ControllerContext(HttpContextSub, routeData, controller);
        }

        public void InitialiseFakeHttpContext(string url = "")
        {
            HttpContextSub = Substitute.For<HttpContextBase>();
            RequestSub = Substitute.For<HttpRequestBase>();
            ResponseSub = Substitute.For<HttpResponseBase>();
            var serverUtilitySub = Substitute.For<HttpServerUtilityBase>();
            var itemsSub = Substitute.For<IDictionary>();
            HttpContextSub.Request.Returns(RequestSub);
            HttpContextSub.Response.Returns(ResponseSub);
            HttpContextSub.Server.Returns(serverUtilitySub);
            HttpContextSub.Items.Returns(itemsSub);
            serverUtilitySub.MapPath("/virtual").Returns("c:/absolute");
            RequestSub.ApplicationPath.Returns(RootPath);
            RequestSub.Url.Returns(BaseUri);
            if (!string.IsNullOrEmpty(url))
            {
                RequestSub.AppRelativeCurrentExecutionFilePath.Returns(url);
            }
        }

        /// <summary>
        /// Méthode permettant de créer un stub du HttpContext
        /// </summary>
        public void CreerStubHttpContext()
        {
            HttpContext.Current = new HttpContext(
               new HttpRequest("", "http://tempuri.org", ""),
               new HttpResponse(new StringWriter())
            );

            HttpContext.Current.User = new GenericPrincipal(
                new GenericIdentity(Environment.UserName),
                new string[0]
            );
        }
    }
}
