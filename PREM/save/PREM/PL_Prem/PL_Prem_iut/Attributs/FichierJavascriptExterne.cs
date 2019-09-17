using System.IO;
using System.Text;
using System.Web.Mvc;

namespace RAMQ.PRE.PL_Prem_iut.Attributs
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// </remarks>
	public class FichierJavascriptExterne : ActionFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var response = filterContext.HttpContext.Response;
            response.Filter = new EnleverTagsScript(response.Filter);
            response.ContentType = "text/javascript";
        }

        private class EnleverTagsScript : MemoryStream
        {
            private readonly Stream _streamEntre;            

            public EnleverTagsScript(Stream streamEntre)
            {
                _streamEntre = streamEntre;
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                string contenuFichierEntre = Encoding.Default.GetString(buffer, offset, count);
                contenuFichierEntre = contenuFichierEntre.Replace("<script>", "").Replace("</script>", "");

                byte[] contenuFichierSortie = Encoding.Default.GetBytes(contenuFichierEntre);
                _streamEntre.Write(contenuFichierSortie, 0, contenuFichierSortie.GetLength(0));
            }
        }
    }
}