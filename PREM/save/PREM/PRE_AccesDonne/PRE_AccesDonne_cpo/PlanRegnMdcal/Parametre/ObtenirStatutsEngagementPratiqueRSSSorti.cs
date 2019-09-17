using RAMQ.Attribut;
using RAMQ.ClasseBase;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite;
using System.Collections.Generic;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary> 
    ///  Classe de paramètres de sortie pour le service du noyau « Obtenir la liste des statuts engagement pratique RSS  ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Mathys Leleu<br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    public class ObtenirStatutsEngagementPratiqueRSSSorti : ParamSorti
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirStatutsEngagementPratiqueRSSSorti()
        {
            ListeStatutEngagementPratiqueRSS = new List<StatutEngagementPratiqueRSS>();
        }

        /// <summary>
        /// Liste des avis de conformité
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pCurListeSta", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.RefCursor)]
        public IEnumerable<StatutEngagementPratiqueRSS> ListeStatutEngagementPratiqueRSS { get; set; }
    }
}