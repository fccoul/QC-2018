using RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre;

namespace RAMQ.PRE.PL_PremMdl_cpo.AvisConformite
{
    /// <summary> 
    ///  Interface permettant d'obtenir les informations des avis de conformité
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Septembre 2016
    /// </remarks>
    public interface IAvisConformite
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        CreerAvisConformiteSorti CreerAvisConformite(CreerAvisConformiteEntre intrant);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        ModifierAvisConformiteSorti ModifierAvisConformite(ModifierAvisConformiteEntre intrant);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        ObtenirLesAvisConformiteSorti ObtenirLesAvisConformite(ObtenirLesAvisConformiteEntre intrant);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        ModifierPeriodeAvisSorti ModifierPeriodeAvis(ModifierPeriodeAvisEntre intrant);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        TraiterAvisConformiteSorti TraiterAvisConformite(TraiterAvisConformiteEntre intrant);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        ValiderAvisDerogationEnCoursSorti ValidationAvisDerogationEnCours(ValiderAvisDerogationEnCoursEntre intrant);

        /// <summary>
        /// Permet de modifier le statut d'engagement
        /// </summary>
        /// <param name="intrant">Paramètre d'entrée</param>
        /// <returns>Paramètre de sortie</returns>
        ModifierStatutEngagementSorti ModifierStatutEngagement(ModifierStatutEngagementEntre intrant);

        /// <summary>
        /// Permet de créer le statut d'engagement
        /// </summary>
        /// <param name="intrant">Paramètre d'entrée</param>
        /// <returns>Paramètre de sortie</returns>
        CreerStatutAvisConformiteSorti CreerStatutEngagement(CreerStatutAvisConformiteEntre intrant);
    }
}