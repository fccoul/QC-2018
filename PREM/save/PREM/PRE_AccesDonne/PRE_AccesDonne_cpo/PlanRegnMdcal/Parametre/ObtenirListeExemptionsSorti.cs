using RAMQ.Attribut;
using RAMQ.ClasseBase;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite;
using System.Collections.Generic;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{
    /// <summary> 
    ///  Classe de paramètres de sorties pour le service du noyau « Obtenir les exemptions d’une réduction ».
    /// </summary>
    /// <remarks>
    /// Auteur : Florent Pollart
    /// </remarks>
	public class ObtenirListeExemptionsSorti : ParamSorti
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirListeExemptionsSorti()
        {
            ListeExemptions = new List<Exemption>();
        }

        /// <summary>
        /// Liste des avis de conformité
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pCurListeExemptions", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.RefCursor)]
        public List<Exemption> ListeExemptions { get; set; }
    }
}