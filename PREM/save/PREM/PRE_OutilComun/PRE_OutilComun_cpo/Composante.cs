#region Imports
using System;
using System.Data;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Configuration;
using System.Linq;
#endregion


namespace RAMQ.PRE.PRE_OutilComun_cpo
{
    /// <summary> 
    ///  Utilitaire en lien avec la composante
    /// </summary>
    public sealed class Composante
    {

        #region Constructeur

        /// <summary>
        /// Constructeur privé pour empêcher l'instanciation
        /// </summary>
        /// <remarks></remarks>
        private Composante()
        {
        }
        #endregion

        #region Méthode publiques

        /// <summary>
        /// Obtenir l'identifiant de l'utilisateur courant
        /// Pour un contexte web l'identifiant sera celui de l'enveloppe SOAP
        /// Pour un contexte exe/LOT l'identifiant sera le nom de l'exécutable soit SSFU.
        /// </summary>
        /// <returns>l'identifiant de l'utilisateur</returns>
        public static string ObtenirIdUtil()
        {

            string strCodUtil = null;

            if (System.Web.HttpContext.Current != null)
            {
                //Dans le cas d'un traitement web, utilise l'identifiant de l'utilisateur appelant
                strCodUtil = RAMQ.Securite.Principal.Identite.ObtnIdentUtil(System.Web.HttpContext.Current.Request.RequestContext.HttpContext);
            }
            else
            {
                //Dans le cas d'un traitement lot, extraire le SSFU du nom de l'exécutable du lot
                string strExecSplit = Process.GetCurrentProcess().ProcessName.Split(Convert.ToChar(".")).Last();

                string strSsfu = strExecSplit.Split(Convert.ToChar("_")).FirstOrDefault();

                strCodUtil = strSsfu;
            }

            strCodUtil = strCodUtil.Substring(strCodUtil.LastIndexOf("\\") + 1);

            return strCodUtil.ToUpper();
        }

        /// <summary>
        /// Obtenir l'environnement (UNIT, FONCT, INTEG, ACPTN, PROD, etc.) actuel
        /// tel que défini dans les AppSettings du Machine.config
        /// </summary>
        /// <remarks>En majuscules</remarks>
        public static string ObtenirEnvir()
        {
            return ConfigurationManager.AppSettings.Get("Envir").ToUpper();
        }

        /// <summary>
        ///  Essaie de disposer d'un objet.
        /// </summary>
        /// <typeparam name="T">Type de l'objet à disposer</typeparam>
        /// <param name="objetDisposer">Objet à disposer</param>
        /// <remarks></remarks>
        public static void EssayerDispose<T>(T objetDisposer)
        {
            IDisposable objDisposable = default(IDisposable);

            if (objetDisposer != null)
            {
                objDisposable = objetDisposer as IDisposable;
                if (objDisposable != null)
                {
                    objDisposable.Dispose();
                }
            }
        }

        /// <summary>
        /// Récupère l'alias de la composante
        /// </summary>
        /// <param name="composante">Composante</param>
        /// <returns>Retourne l'unité de traitement de l'assemble ou son nom complet</returns>
        /// <remarks></remarks>
        public static string ObtenirCodUt(Assembly composante)
        {

            string strTitre = ObtenirTitreCpo(composante);
            string strRegle = "RAMQ\\.\\w{2,3}\\.(?<UT>[^_.]+)";
            Match objMatchRegex = Regex.Match(strTitre.ToUpper(), strRegle);
            //Group objGrpUt = objMatchRegex.Groups.Item("UT");

            Group objGrpUt = objMatchRegex.Groups["UT"];

            return objGrpUt.Success ? objGrpUt.Value : strTitre;
        }

        /// <summary>
        /// Obtenir le Titre de l'assembly
        /// </summary>
        /// <param name="composante">Composante</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string ObtenirTitreCpo(Assembly composante)
        {
            return composante.GetCustomAttributes(typeof(AssemblyTitleAttribute), false).Select(a => a as AssemblyTitleAttribute).FirstOrDefault().Title;
        }

        #endregion

    }
}


