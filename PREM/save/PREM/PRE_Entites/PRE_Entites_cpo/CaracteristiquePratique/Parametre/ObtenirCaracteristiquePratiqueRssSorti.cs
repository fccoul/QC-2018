using System.Collections.Generic;
using RAMQ.ClasseBase;

namespace RAMQ.PRE.PRE_Entites_cpo.CaracteristiquePratique.Parametre
{

    /// <summary> 
    ///  Paramètres de sortie pour l'obtention des caractéristiques pratique RSS
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
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
        public List<Entite.CaracteristiquePratique> CaracteristiquesPratique { get; set; }

    }
}