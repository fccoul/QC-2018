using System.Data;
using RAMQ.Attribut;

namespace RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre
{

    /// <summary> 
    ///  Classe de paramètres d'entrées pour le service du noyau 
    ///  « Obtenir les autorisations PREMQ ».
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier<br/>
    ///  Date   : Novembre 2016
    /// </remarks>
    public class ObtenirAutorisationsEntre
    {

        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pNumNumeroSeqDisp", Direction = ParameterDirection.Input)]
        public long NumeroSequentielDispensateur { get; set; }

    }
}