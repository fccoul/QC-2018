using System;

namespace RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre
{

    /// <summary> 
    ///  Paramètres d'entré pour l'obtention des dérogation d'un professionnel de la santé
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Octobre 2016
    /// </remarks>
    public class ObtenirDerogationsProfessionnelSanteEntre
    {

        /// <summary>
        /// Numéro séquantiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        public long NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Date de recherche
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public DateTime? DateRecherche { get; set; }

        /// <summary>
        /// Indicateur d'une dérogation inactivé
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public string IndicateurDerogationInactive { get; set; }

        /// <summary>
        /// Tri
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public string Tri { get; set; }

        /// <summary>
        /// Date de début
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public DateTime? DateDebut { get; set; }

        /// <summary>
        /// Date de fin
        /// </summary>
        /// <remarks>Optionnel</remarks>
        public DateTime? DateFin { get; set; }

    }

}