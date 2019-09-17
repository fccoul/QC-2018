using System;
using RAMQ.ClasseBase;

namespace RAMQ.PRE.PRE_Entites_cpo.PeriodePratique.Parametre
{

    /// <summary> 
    ///  Paramètres de sortie pour l'obtention des périodes de pratique d'un professionnel
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : 2016-09-16
    /// </remarks>
    public class ObtenirPeriodePratiqueProfessionnelSorti : ParamSorti
    {

        /// <summary>
        /// Numéro séquentiel de la pratique 
        /// </summary>
        public long NumeroSequencePratique { get; set; }

        /// <summary>
        /// Date de première facturation
        /// </summary>
        public DateTime? DatePremiereFacturation { get; set; }

        /// <summary>
        /// Date de dernière facturation 
        /// </summary>
        public DateTime? DateDerniereFacturation { get; set; }

        /// <summary>
        /// Type de pratique
        /// </summary>
        public int NumeroTypePratique { get; set; }
        
    }

}