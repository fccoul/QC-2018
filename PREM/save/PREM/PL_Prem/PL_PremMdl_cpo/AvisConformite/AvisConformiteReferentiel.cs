using System;
using RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre;
using RAMQ.PRE.PRE_OutilComun_cpo;

namespace RAMQ.PRE.PL_PremMdl_cpo.AvisConformite
{
    /// <summary> 
    ///  Référentiel qui permet d'obtenir les informations des avis de conformité.
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Septembre 2016
    /// </remarks>
    public class AvisConformiteReferentiel : IAvisConformite
    {
        /// <summary>
        /// Permet la création d'un avis de conformité
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Les informations sur l'état de l'opération</returns>
        /// <remarks></remarks>
        public CreerAvisConformiteSorti CreerAvisConformite(CreerAvisConformiteEntre intrant)
        {
            return UtilitaireService.AppelerService<svcSaisAvisConf.IServSaisAvisConf, 
                                                    svcSaisAvisConf.ServSaisAvisConfClient, 
                                                    CreerAvisConformiteSorti>
                                                    (x => x.CreerAvisConformite(intrant));
        }

        /// <summary>
        /// Permet la modification d'un avis de conformité et son statut
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Les informations sur l'état de l'opération</returns>
        /// <remarks></remarks>
        public ModifierAvisConformiteSorti ModifierAvisConformite(ModifierAvisConformiteEntre intrant)
        {
            return UtilitaireService.AppelerService<svcSaisAvisConf.IServSaisAvisConf, 
                                                    svcSaisAvisConf.ServSaisAvisConfClient, 
                                                    ModifierAvisConformiteSorti>
                                                    (x => x.ModifierAvisConformite(intrant));
        }

        /// <summary>
        /// Permet d'obtenir une liste des avis de conformité et de leurs statuts
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Une liste des avis de conformité avec leurs statuts</returns>
        /// <remarks></remarks>
        public ObtenirLesAvisConformiteSorti ObtenirLesAvisConformite(ObtenirLesAvisConformiteEntre intrant)
        {
            return UtilitaireService.AppelerService<svcSaisAvisConf.IServSaisAvisConf, 
                                                    svcSaisAvisConf.ServSaisAvisConfClient, 
                                                    ObtenirLesAvisConformiteSorti>
                                                    (x => x.ObtenirLesAvisConformite(intrant));
        }

        /// <summary>
        /// Permet de modifier la période d'un avis de conformité et son statut
        /// </summary>
        /// <Parametre name="intrant">Parametreètre d'entré</Parametre>
        /// <returns>Retourne les informations de modification de l'avis de conformité</returns>
        /// <remarks></remarks>
        public ModifierPeriodeAvisSorti ModifierPeriodeAvis(ModifierPeriodeAvisEntre intrant)
        {
            return UtilitaireService.AppelerService<svcSaisAvisConf.IServSaisAvisConf, 
                                                    svcSaisAvisConf.ServSaisAvisConfClient,
                                                    ModifierPeriodeAvisSorti>
                                                    (x => x.ModifierPeriodeAvis(intrant));
        }

        /// <summary>
        /// Fonction pour effectuer les traitements sur les avis de conformité
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        public TraiterAvisConformiteSorti TraiterAvisConformite(TraiterAvisConformiteEntre intrant)
        {
            return UtilitaireService.AppelerService<svcSaisAvisConf.IServSaisAvisConf, 
                                                    svcSaisAvisConf.ServSaisAvisConfClient, 
                                                    TraiterAvisConformiteSorti>
                                                    (x => x.TraiterAvisConformite(intrant));
        }

        /// <summary>
        /// Permet de faire les traitements sur les avis de conformité
        /// </summary>
        /// <param name="intrant">numéro de pratique</param>
        /// <returns></returns>
        public ValiderAvisDerogationEnCoursSorti ValidationAvisDerogationEnCours(ValiderAvisDerogationEnCoursEntre intrant)
        {
            return UtilitaireService.AppelerService<svcSaisAvisConf.IServSaisAvisConf,
                                                    svcSaisAvisConf.ServSaisAvisConfClient, 
                                                    ValiderAvisDerogationEnCoursSorti>
                                                    (x => x.ValidationAvisDerogationEnCours(intrant));
        }

        /// <summary>
        /// Permet de modifier le statut d'engagement
        /// </summary>
        /// <param name="intrant">Paramètre d'entrée</param>
        /// <returns>Paramètre de sortie</returns>
        public ModifierStatutEngagementSorti ModifierStatutEngagement(ModifierStatutEngagementEntre intrant)
        {
            return UtilitaireService.AppelerService<svcSaisAvisConf.IServSaisAvisConf,
                                                     svcSaisAvisConf.ServSaisAvisConfClient,
                                                     ModifierStatutEngagementSorti>
                                                     (x => x.ModifierStatutEngagement(intrant));
        }

        /// <summary>
        /// Permet de créer le statut d'engagement
        /// </summary>
        /// <param name="intrant">Paramètre d'entrée</param>
        /// <returns>Paramètre de sortie</returns>
        public CreerStatutAvisConformiteSorti CreerStatutEngagement(CreerStatutAvisConformiteEntre intrant)
        {
            return UtilitaireService.AppelerService<svcSaisAvisConf.IServSaisAvisConf,
                                                     svcSaisAvisConf.ServSaisAvisConfClient,
                                                     CreerStatutAvisConformiteSorti>
                                                     (x => x.CreerStatutAvisConformite(intrant));
        }
    }
}