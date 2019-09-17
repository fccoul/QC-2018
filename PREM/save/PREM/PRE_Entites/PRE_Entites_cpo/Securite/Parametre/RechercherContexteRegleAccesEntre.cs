namespace RAMQ.PRE.PRE_Entites_cpo.Securite.Parametre
{
    /// <summary> 
    ///  Paramètre d'entrée pour la recherche de règles d'accès.
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : 2016-11-02
    /// </remarks>
    public class RechercherContexteRegleAccesEntre
    {

        /// <summary>
        /// Le code d'application
        /// </summary>
        public string CodeApplication { get; set; }

        /// <summary>
        /// L'identifiant de l'utilisateur
        /// </summary>
        public string IdentifiantUtilisateur { get; set; }

    }
}