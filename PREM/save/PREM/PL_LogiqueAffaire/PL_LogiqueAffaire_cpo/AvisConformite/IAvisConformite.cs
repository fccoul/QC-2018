using RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.AvisConformite
{
    /// <summary> 
    ///  Interface des avis de conformité
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    public interface IAvisConformite
    {
        /// <summary>
        /// Permet d'obtenir une liste des avis de conformité et de leurs statuts
        /// </summary>
        /// <Parametre name="intrant">Parametreètre d'entré</Parametre>
        /// <returns>Une liste des avis de conformité avec leurs statuts</returns>
        /// <remarks></remarks>
        ObtenirLesAvisConformiteSorti ObtenirLesAvisConformite(ObtenirLesAvisConformiteEntre intrant);

        /// <summary>
        /// Permet de modifier la période d'un avis de conformité et son statut
        /// </summary>
        /// <Parametre name="intrant">Parametreètre d'entré</Parametre>
        /// <returns>Retourne les informations de modification de l'avis de conformité</returns>
        /// <remarks></remarks>
        ModifierPeriodeAvisSorti ModifierPeriodeAvis(ModifierPeriodeAvisEntre intrant);


        /// <summary>
        /// Permet de créer un statut de l'engagement
        /// </summary>
        /// <Parametre name="intrant">Paramètre d'entré</Parametre>
        /// <returns>Retourne les informations de la création du statut de l'engagement</returns>
        CreerStatutAvisConformiteSorti CreerStatutAvisConformite(CreerStatutAvisConformiteEntre intrant);

        /// <summary>
        /// Permet de modifier le statut d'un avis de conformité
        /// </summary>
        /// <Parametre name="intrant">Paramètre d'entré</Parametre>
        /// <returns>Retourne les informations de modification du statut de l'avis de conformité</returns>
        ModifierStatutEngagementSorti ModifierStatutAvisConformite(ModifierStatutEngagementEntre intrant);


        /// <summary>
        /// Permet de modifier la raison de fermeture du statut de l'engagement
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        ModifierRaisFermStatutEngagSorti ModifierRaisFermStatutEngag(ModifierRaisFermStatutEngagEntre intrant);

        /// <summary>
        /// Permet de modifier un avis de conformite
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        ModifierAvisConfSorti ModifierAvisConformite(ModifierAvisConfEntre intrant);

        /// <summary>
        ///  Permet la modification des avis de conformités et de ses statuts
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        ModifierAvisConformiteStatutSorti ModifierAvisConformiteStatut(ModifierAvisConformiteStatutEntre intrant);

        /// <summary>
        ///  Permet la création des avis de conformités
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        CreerAvisConformiteSorti CreerAvisConformite(CreerAvisConformiteEntre intrant);

        /// <summary>
        /// Permet de faire l'obtention de la liste des statuts engagement pratique RSS 
        /// </summary>
        /// <param name="intrant">Paramètres d'entrée</param>
        /// <returns>Liste des statuts engagement pratique RSS</returns>
        ObtenirStatutsEngagementPratiqueRSSSorti ObtenirStatutsEngagementPratiqueRSS(ObtenirStatutsEngagementPratiqueRSSEntre intrant);
    }
}
