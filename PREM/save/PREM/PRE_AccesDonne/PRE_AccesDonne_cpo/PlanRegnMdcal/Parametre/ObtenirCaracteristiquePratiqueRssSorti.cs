using RAMQ.Attribut;
using RAMQ.ClasseBase;
using System.Collections.Generic;
using System.Data;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{

    /// <summary> 
    ///  Classe de paramètres de sortie pour le service du noyau « Obtenir caractéristique pratique RSS ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : Juin 2017
    /// </remarks>
    public class ObtenirCaracteristiquePratiqueRssSorti : ParamSorti
    {

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        /// <remarks></remarks>
        public ObtenirCaracteristiquePratiqueRssSorti()
        {
            CaracteristiquesPratique = new List<Entite.CaracteristiquePratique>();
        }

        /// <summary>
        /// Liste des caractéristiques de pratique
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pCurListeCarPrati", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.RefCursor)]
        public List<Entite.CaracteristiquePratique> CaracteristiquesPratique { get; set; }

    }

}