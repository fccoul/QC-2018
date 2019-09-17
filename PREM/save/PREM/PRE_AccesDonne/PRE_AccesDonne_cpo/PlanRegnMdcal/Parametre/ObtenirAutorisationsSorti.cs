using RAMQ.Attribut;
using RAMQ.ClasseBase;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite;
using System.Collections.Generic;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{

    /// <summary> 
    ///  Classe de paramètres de sortie pour le service du noyau « Obtenir les autorisations PREMQ ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier<br/>
    ///  Date   : Septembre 2016
    /// </remarks>
    public class ObtenirAutorisationsSorti : ParamSorti
    {

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirAutorisationsSorti()
        {
            Autorisations = new List<Autorisation>();
        }

        /// <summary>
        /// Liste des autorisations
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pCurListeAutor", Direction = ParameterDirection.Output, TypeSorti = RAMQ.Enumeration.EnumTypeParamSorti.RefCursor)]
        public List<Autorisation> Autorisations { get; set; }
        
    }

}