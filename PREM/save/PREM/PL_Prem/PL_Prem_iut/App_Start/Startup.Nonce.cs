using Microsoft.Owin;
using Owin;
using System;
using System.Security.Cryptography;

namespace RAMQ.PRE.PL_Prem_iut
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public void ConfigureNonce(IAppBuilder app)
        {
            app.Use((context, next) =>
            {
                var rng = new RNGCryptoServiceProvider();
                var nonceBytes = new byte[32];
                rng.GetBytes(nonceBytes);
                var nonce = Convert.ToBase64String(nonceBytes);
                context.Set("ScriptNonce", nonce);
                context.Response.Headers.Add("Content-Security-Policy",
                    new[] { string.Format("default-src 'none'; base-uri 'self'; block-all-mixed-content; connect-src 'self' *.ramq.gouv.qc.ca *.ramq.gov; child-src 'none'; font-src 'self'; form-action 'self'; frame-ancestors 'none'; img-src 'self'; media-src 'none'; object-src 'none'; script-src 'self' 'nonce-{0}'; style-src 'self';", nonce) });
                return next();
            });
        }
    }
}