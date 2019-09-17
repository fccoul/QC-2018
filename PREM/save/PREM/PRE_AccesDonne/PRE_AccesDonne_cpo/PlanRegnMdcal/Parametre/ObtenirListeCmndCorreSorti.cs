using RAMQ.Attribut;
using RAMQ.ClasseBase;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite;
using System.Collections.Generic;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary> 
    ///  Classe de paramètres de sorties pour le service du noyau « Obtenir la liste des commandes de correspondances ».
    /// </summary>
    /// <remarks>
    /// Auteur : Florent Pollart
    /// </remarks>
	public class ObtenirListeCmndCorreSorti : ParamSorti
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirListeCmndCorreSorti()
        {
            ListeCorrespondances = new List<Correspondance>();
        }

        /// <summary>
        /// Liste des avis de conformité
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pCurListeCorrespondances", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.RefCursor)]
        public List<Correspondance> ListeCorrespondances { get; set; }
    }
}