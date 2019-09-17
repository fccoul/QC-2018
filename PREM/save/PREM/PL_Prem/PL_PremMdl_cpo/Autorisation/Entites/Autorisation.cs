using System;

namespace RAMQ.PRE.PL_PremMdl_cpo.Autorisation.Entites
{

    /// <summary> 
    /// Entité d'une autorisation
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Novembre 2016
    /// </remarks>
    public class Autorisation
    {

        /// <summary>
        /// Numéro de séquence de l'autorisation
        /// </summary>
        /// <returns></returns>
        public long NumeroSequenceAutorisation { get; set; }

        /// <summary>
        /// Numéro de séquence du dispensateur
        /// </summary>
        public long NumeroSequenceDispensateur { get; set; }

        /// <summary>
        /// Type lieu géographique
        /// </summary>
        /// <returns></returns>
        public string TypeLieuGeographique { get; set; }

        /// <summary>
        /// Code lieu géographique
        /// </summary>
        /// <returns></returns>
        public string CodeLieuGeographique { get; set; }

        /// <summary>
        /// Numéro séquentiel identifiant un regroupement administratif des lieux géographiques.
        /// </summary>
        /// <returns></returns>
        public int NumeroSequenceRegroupementAdministratif { get; set; }

        /// <summary>
        /// Type d'autorisation
        /// </summary>
        /// <returns></returns>
        public string TypeAutorisation { get; set; }

        /// <summary>
        /// Date de début de l'autorisation
        /// </summary>
        /// <returns></returns>
        public DateTime DateDebut { get; set; }

        /// <summary>
        /// Date de fin de l'autorisation
        /// </summary>
        /// <returns>Nullable</returns>
        public DateTime? DateFin { get; set; }


        /// <summary>
        /// Date heure création de l'occurence
        /// </summary>
        /// <returns></returns>
        public DateTime? DateHeureCreation { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui a créé l'occurrence.
        /// </summary>
        /// <returns></returns>
        public string IdUtilisateurCreateur { get; set; }

        /// <summary>
        /// Date et heure de l'inactivation de l'occurrence.
        /// </summary>
        /// <returns></returns>
        public DateTime? DateHeureInactivation { get; set; }

        /// <summary>
        /// Identifiant de l'utilisateur qui a inactivé l'occurrence.
        /// </summary>
        /// <returns></returns>
        public string IdUtilisateurInactivation { get; set; }

    }
}
