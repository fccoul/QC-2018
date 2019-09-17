using RAMQ.Attribut;
using RAMQ.ClasseBase;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite;
using System.Collections.Generic;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{

    /// <summary> 
    ///  Classe de paramètres de sortie pour le service du noyau « Obtenir la liste des avis de conformité ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau<br/>
    ///  Date   : Septembre 2016
    /// <br/>
    ///  Historique des modifications<br/>
    ///  ------------------------------------------------------------------------------<br/>
    ///  Auteur : [Auteur]<br/>
    ///  Date   : [aaaa-mm-jj]<br/>
    ///  Description:<br/>
    /// <br/>
    /// </remarks>
    public class ObtenirLesAvisConformiteSorti : ParamSorti
    {

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirLesAvisConformiteSorti()
        {
            ListeAvisConformite = new List<AvisConformite>();
            ListeStatutAvisConformite = new List<StatutAvisConformite>();
        }

        /// <summary>
        /// Liste des avis de conformité
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pCurListeAvisConformite", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.RefCursor)]
        public List<AvisConformite> ListeAvisConformite { get; set; }

        /// <summary>
        /// Liste des statuts des avis de conformité
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pCurListeStatutAvisConformite", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.RefCursor)]
        public List<StatutAvisConformite> ListeStatutAvisConformite { get; set; }

    }

}