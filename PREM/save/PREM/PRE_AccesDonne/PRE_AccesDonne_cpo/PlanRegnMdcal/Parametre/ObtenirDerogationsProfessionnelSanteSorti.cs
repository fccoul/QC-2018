using RAMQ.Attribut;
using RAMQ.ClasseBase;
using System.Collections.Generic;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{

    /// <summary> 
    ///  Classe de paramètres de sortie pour le service du noyau « Obtenir la liste des dérogations d’un professionnel de la santé ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier<br/>
    ///  Date   : Octobre 2016
    /// </remarks>
    public class ObtenirDerogationsProfessionnelSanteSorti : ParamSorti
    {

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        /// <remarks></remarks>
        public ObtenirDerogationsProfessionnelSanteSorti()
        {
            Derogations = new List<Entite.Derogation>();
        }

        /// <summary>
        /// Liste de dérogation
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pCurListeDerogation", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.RefCursor)]
        public List<Entite.Derogation> Derogations { get; set; }

    }

}