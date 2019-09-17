using RAMQ.PRE.PL_Prem_iut.Entite;

namespace RAMQ.PRE.PL_Prem_iut.Securite
{
    /// <summary>
    /// Classe en lien avec la sécurité
    /// </summary>
    public interface ISecurite
    {
        /// <summary>
        /// Obtient la région de la personne connecté
        /// </summary>
        CodeRSSUtilisateur ObtenirCodeRSSUtilisateurCourant();

        /// <summary>
        /// Obtient la région de la personne connecté par la méthode du cookie
        /// </summary>
        CodeRSSUtilisateur ObtenirCodeRSSUtilisateurCookie();
    }
}