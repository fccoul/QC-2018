using System;

namespace RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre
{

    /// <summary> 
    ///  Paramètre d'entrée pour obtenir les dispensateurs selon un numéro d'entente
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : Avril 2017
    /// </remarks>
    public class ObtenirDispensateursSelonEntenteEntre
    {

        /// <summary>
        /// Numéro d'entente 
        /// </summary>
        public int NumeroEntente { get; set; }

        /// <summary>
        /// Date de début de la période
        /// </summary>
        public DateTime DateDebutPeriode { get; set; }

        /// <summary>
        /// Date de fin de la période
        /// </summary>
        public DateTime DateFinPeriode { get; set; }

    }
}