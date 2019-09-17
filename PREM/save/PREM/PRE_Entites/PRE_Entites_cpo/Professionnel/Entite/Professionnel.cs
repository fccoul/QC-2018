using RAMQ.ClasseBase;

namespace RAMQ.PRE.PRE_Entites_cpo.Professionnel.Entite
{

    /// <summary>
    /// Entite pour les informations d'un professionnel
    /// </summary>
    public class Professionnel : ParamSorti
    {

        /// <summary>
        /// Numéro de pratique
        /// </summary>
        public int? NumeroPratique { get; set; }

        /// <summary>
        /// Nom
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prénom
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Numéro de classe
        /// </summary>
        public int? NumeroClasse { get; set; }

        /// <summary>
        /// Numéro de dispensateur
        /// </summary>
        public int? NumeroDispensateur { get; set; }

        /// <summary>
        /// Numéro séquentiel de dispensateur
        /// </summary>
        public long? NumeroSequentielDispensateur { get; set; }

        /// <summary>
        /// Numéro séquentiel d'individu
        /// </summary>
        public long? NumeroSequentielIndividu { get; set; }

        /// <summary>
        /// Nom afficher
        /// </summary>
        public string NomAfficher { get; set; }
    }
}