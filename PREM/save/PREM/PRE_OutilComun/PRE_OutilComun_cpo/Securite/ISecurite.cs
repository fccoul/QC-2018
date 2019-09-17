using RAMQ.PRE.PRE_Entites_cpo.Securite.Parametre;

namespace RAMQ.PRE.PRE_OutilComun_cpo
{
    /// <summary>
    /// Interface d'opération pour la recherche de règle d'accès dans la base de données d'AGS.
    /// </summary>
    public interface ISecurite
    {
        /// <summary>
        /// Cette méthode demande les contextes et règles d'accès pour un utilisateur.
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        RechercherContexteRegleAccesSorti RechercherContexteRegleAcces(RechercherContexteRegleAccesEntre intrant);
    }
}