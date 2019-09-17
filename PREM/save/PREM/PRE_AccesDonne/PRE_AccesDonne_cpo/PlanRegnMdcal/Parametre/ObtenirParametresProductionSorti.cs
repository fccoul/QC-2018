using RAMQ.Attribut;
using RAMQ.ClasseBase;
using System.Collections.Generic;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{

    /// <summary>
    /// Classe de paramètres de sorties pour le service du noyau « Obtenir une liste de paramètres de production ».
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public class ObtenirParametresProductionSorti : ParamSorti
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public ObtenirParametresProductionSorti()
        {
            Parametres = new List<Entite.ParametreProduction>();
        }

        /// <summary>
        /// Liste des paramètres trouvé
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pCurListeParamProd", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.RefCursor)]
        public List<Entite.ParametreProduction> Parametres { get; set; }

    }

}