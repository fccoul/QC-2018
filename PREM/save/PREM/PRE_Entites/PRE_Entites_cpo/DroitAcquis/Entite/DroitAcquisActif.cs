using System;

namespace RAMQ.PRE.PRE_Entites_cpo.DroitAcquis.Entite
{

    /// <summary> 
    ///  Entité pour les droits acquis actifs
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent  Pollart <br/>
    ///  Date   : 2016-10-04
    /// </remarks>

    public class DroitAcquisActif
    {
        /// <summary>
        /// Message de traitement
        /// </summary>
        /// <remarks></remarks>
        public string MessageTraitement { get; set; }

        /// <summary>
        /// Numéro séquentiel du professionnel
        /// </summary>
        /// <remarks></remarks>
        public long? NumeroSequentielProfessionnel { get; set; }

        /// <summary>
        /// Date de début du droit acquis
        /// </summary>
        /// <remarks></remarks>
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Date de fin du droit acquis
        /// </summary>
        /// <remarks></remarks>
        public DateTime? DateFin { get; set; }

        /// <summary>
        /// Code de région socio-sanitaire
        /// </summary>
        /// <remarks></remarks>
        public string CodeRegionSocioSanitaire { get; set; }

        /// <summary>
        /// Type de lieu géographique
        /// </summary>
        /// <remarks></remarks>
        public string TypeLieuGeographique { get; set; }

        /// <summary>
        /// Code de lieu géographique
        /// </summary>
        /// <remarks></remarks>
        public string CodeLieuGeographique { get; set; }

        /// <summary>
        /// Numéro séquentiel de regroupement administratif
        /// </summary>
        /// <remarks></remarks>
        public long? NumeroSequentielRegrAdmn { get; set; }

    }
}