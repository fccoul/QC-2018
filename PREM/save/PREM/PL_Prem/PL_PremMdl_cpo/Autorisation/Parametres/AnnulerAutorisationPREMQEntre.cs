

namespace RAMQ.PRE.PL_PremMdl_cpo.Autorisation.Parametres
{
    /// <summary>
    /// Paramètre d'entré du service AnnulerAutorisationPREMQ
    /// </summary>
    public class AnnulerAutorisationPREMQEntre
    {
        /// <summary>
        /// Numéro séquentiel de l'autorisation à annuler.
        /// </summary>
        /// <remarks></remarks>
        public long NumeroSequentielAutorisation { get; set; }

        /// <summary>
        /// Identifiant utilisateur annulant l'autorisation
        /// </summary>
        /// <remarks></remarks>
        public string IdentifiantUtilisateur { get; set; }
    }
}
