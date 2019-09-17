using RAMQ.DomainesValeur;

namespace RAMQ.PRE.PRE_OutilComun_cpo
{
    /// <summary>
    /// Classe de domaine de valeur
    /// </summary>
    public interface IDomaineValeur
    {
        /// <summary>
        /// Obtenir le nom RSS dans le domaine de valeur
        /// </summary>
        /// <returns></returns>
        DomVal ObtenirNomRssDomaineValeur();

        /// <summary>
        /// Obtenir le nom du type de dérogation dans le domaine de valeur
        /// </summary>
        /// <returns></returns>
        DomVal ObtenirNomTypeDerogationDomaineValeur();


        /// <summary>
        /// Permet d'obtenir les descriptions associées aux codes de raison du statut d'engagement
        /// </summary>
        /// <returns>Liste de description des codes de raison du statut d'engagement</returns>
        DomVal ObtenirDescriptionCodeRaisonStatutEngagement();

        /// <summary>
        /// Permet d'obtenir les descriptions associées aux codes de source de demandes de réévaluation
        /// </summary>
        /// <returns>Liste de description des codes source de demandes de réévaluation</returns>
        DomVal ObtenirDescriptionCodeSourceDemandeReevaluation();

        /// <summary>
        /// Demande_026
        /// Permet d'obtenir les descriptions associées aux codes de catégorie de demandes de réévaluation
        /// </summary>
        /// <returns>Liste de description des codes de catégorie de demandes de réévaluation</returns>
        DomVal ObtenirDescriptionCategorieReevaluationPREMQ();

        /// <summary>
        ///   /// Demande_026
        /// Permet d'obtenir les descriptions associé aux codes de raison du statut de derogation
        /// </summary>
        /// <returns>Liste de description des codes de raison du statut derogation</returns>
        DomVal ObtenirDescriptionCodeRaisonStatutDerogation();

        /// <summary>
        /// Permet d'obtenir les descriptions associé aux codes de raison de la modification, de l'annulation ou de la restitution de l'autorisation PREM d'un médecin omnipraticien
        /// </summary>
        /// <returns>Liste de description des codes de raison du statut la modification, de l'annulation ou de la restitution de l'autorisation PREM d'un médecin omnipraticien</returns>
        DomVal ObtenirDescriptionCodeRaisonStatutAutorisation();
    }
}