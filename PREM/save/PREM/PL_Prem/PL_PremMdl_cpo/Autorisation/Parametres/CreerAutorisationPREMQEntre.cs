using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RAMQ.PRE.PL_PremMdl_cpo.Autorisation.Parametres
{
    /// <summary>
    /// Entité paramètre d'entré du service Créer autorisation PREMQ.
    /// </summary>
    public class CreerAutorisationPREMQEntre
    {

        /// <summary>
        /// Numéro séquentiel du dispensateur
        /// </summary>
        /// <remarks></remarks>
        public long NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Type d'autorisation PREMQ
        /// </summary>
        /// <remarks></remarks>
        public string TypeAutorisationPREMQ { get; set; }

        /// <summary>
        /// Date de début d'autorisation PREMQ
        /// </summary>
        /// <remarks></remarks>
        public DateTime DateDebutAutorisation { get; set; }

        /// <summary>
        /// Date de fin d'autorisation PREMQ
        /// </summary>
        /// <remarks></remarks>
        public DateTime DateFinAutorisation { get; set; }

        /// <summary>
        /// Identifiant utilisateur créateur
        /// </summary>
        /// <remarks></remarks>
        public string IdentifiantUtilisateur { get; set; }
        }
}