namespace RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre
{
    /// <summary> 
    /// Paramètre d'entrée pour la validation d'avis et dérogations en cours
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : 2016-09-21
    /// </remarks>
    public class ValiderAvisDerogationEnCoursEntre
    {

        /// <summary>
        /// Numéro de pratique
        /// </summary>
        public long NumeroPratique { get; set; }

        /// <summary>
        /// Indicateur pour vérifier si un avis est enregistré
        /// </summary>
        public bool VerifierAvisEnAttente { get; set; }

        /// <summary>
        /// Code RSS
        /// </summary>
        public string CodeRSS { get; set; }

    }
}