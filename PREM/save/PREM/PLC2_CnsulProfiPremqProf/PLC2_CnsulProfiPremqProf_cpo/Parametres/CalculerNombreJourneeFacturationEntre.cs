using System;

namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Parametres
{
    /// <summary>
    /// Paramètre d'entré pour faire le calcule du nombre de journée de facturation
    /// </summary>
    /// <remarks>
    /// Auteur: Jean-Benoit Drouin-Cloutier
    /// </remarks>
    public class CalculerNombreJourneeFacturationEntre
    {
        /// <summary>
        /// Numéro séquentiel du professionnel
        /// </summary>
        public long NumeroSequentielProfessionnel { get; set; }

        /// <summary>
        /// Code RSS
        /// </summary>
        public string CodeRSS { get; set; }

        /// <summary>
        /// Type de lieu
        /// </summary>
        public string TypeLieuGeographique { get; set; }

        /// <summary>
        /// Code de lieu
        /// </summary>
        public string CodeLieuGeographique { get; set; }

        /// <summary>
        /// Numéro regroupement
        /// </summary>
        public long NumeroRegroupement { get; set; }

        /// <summary>
        /// Numéro séquentiel de l’engagement
        /// </summary>
        public long NumeroSequentielEngagement { get; set; }

        /// <summary>
        /// Date de début
        /// </summary>
        public DateTime? DateDebut { get; set; }

        /// <summary>
        /// Date de fin
        /// </summary>
        public DateTime? DateFin { get; set; }
        

        
       
       
        
        

    }
}