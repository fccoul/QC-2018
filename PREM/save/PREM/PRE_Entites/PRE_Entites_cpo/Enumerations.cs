
namespace RAMQ.PRE.PRE_Entites_cpo
{
    /// <summary>
    /// Classes regroupant toutes les énumérations
    /// </summary>
    public class Enumerations
    {
        /// <summary>
        /// Énumération des type de traitement possible à faire pour un avis de conformité
        /// </summary>
        public enum TypeTraitementAvisConformite
        {
            /// <summary>
            /// Traitement de type Transmettre
            /// </summary>
            Transmettre,

            /// <summary>
            /// Traitement de type Enregistrer
            /// </summary>
            Enregistrer,

            /// <summary>
            /// Traitement de type Modifier
            /// </summary>
            Modifier,

            /// <summary>
            /// Traitement de type Annuler
            /// </summary>
            Annuler,

            /// <summary>
            /// Traitement de type Inactiver
            /// </summary>
            Inactiver,

            /// <summary>
            /// Traitement de type Reporter
            /// </summary>
            Reporter,

            /// <summary>
            /// Traitement de type Révoquer
            /// </summary>
            Revoquer,

            /// <summary>
            /// Traitement de type Supprimer
            /// </summary>
            Supprimer
        }

        /// <summary>
        /// Énumération des type de traitement possible à faire pour les suspensions
        /// </summary>
        public enum TypeTraitementSuspension
        {
            /// <summary>
            /// Traitement de type Ajouter
            /// </summary>
            Ajouter,

            /// <summary>
            /// Traitement de type Modifier
            /// </summary>
            Modifier,

            /// <summary>
            /// Traitement de type Annuler
            /// </summary>
            Annuler
        }
        
        /// <summary>
        /// Formats pris en charge pour l'exportation des rapports
        /// </summary>
        public enum TypeFichierSortieRapport
        {
            /// <summary>
            /// Fichier PDF
            /// </summary>
            PDF = 0,
            /// <summary>
            /// Fichier XML
            /// </summary>
            XML = 1
        }        
    }
}