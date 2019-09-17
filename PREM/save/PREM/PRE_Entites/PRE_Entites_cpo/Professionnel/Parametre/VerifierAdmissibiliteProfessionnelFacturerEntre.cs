using System;

namespace RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre
{
    /// <summary> 
    ///  Paramètre d'entrée pour obtenir les informations sur l'admissibilité d'un professionnel à facturer
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Novembre 2016
    /// </remarks>
    public class VerifierAdmissibiliteProfessionnelFacturerEntre
    {

        /// <summary>
        /// Numéro de classe
        /// </summary>
        public int NumeroClasse { get; set; }

        /// <summary>
        /// Numéro de dispensateur
        /// </summary>
        public int NumeroDispensateur { get; set; }

        /// <summary>
        /// Date de début d'admissibilité
        /// </summary>
        public DateTime DateDebutPeriode { get; set; }

        /// <summary>
        /// Date de fin d'admissibilité
        /// </summary>
        public DateTime DateFinPeriode { get; set; }
    }
}