namespace RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Parametre
{

    /// <summary> 
    /// Entité d'intrant pour l'obtention de l'information sur les territoire RLS
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Octobre 2016
    /// </remarks>
    public class ObtenirInformationTerritoireRLSEntre
    {

        /// <summary>
        /// Code territoire RLS
        /// </summary>
        public string CodeTerritoireRLS { get; set; }

        /// <summary>
        /// Code de région socio-sanitaire
        /// </summary>
        public string CodeRegionSocioSanitaire { get; set; }

    }

}