using RAMQ.Attribut;
using RAMQ.ClasseBase;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite;
using System.Collections.Generic;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{

    /// <summary> 
    ///  Classe de paramètres de sortie pour le service du noyau « Obtenir les territoires RPPR ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Maxime Comtois<br/>
    ///  Date   : Aout 2017
    /// <br/>
    ///  Historique des modifications<br/>
    ///  ------------------------------------------------------------------------------<br/>
    ///  Auteur : [Auteur]<br/>
    ///  Date   : [aaaa-mm-jj]<br/>
    ///  Description:<br/>
    /// <br/>
    /// </remarks>
    public class ObtenirTerriRPPRSorti : ParamSorti
    {

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirTerriRPPRSorti()
        {
            ListeTerriRPPR = new List<TerriRPPR>();
        }

        /// <summary>
        /// Liste des territoires RPPR
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pCurListeTerriRPPR", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.RefCursor)]
        public List<TerriRPPR> ListeTerriRPPR { get; set; }

      

    }

}