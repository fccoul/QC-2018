using RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre;
using System;

namespace RAMQ.PRE.PL_PremMdl_cpo.AvisConformite
{
    /// <summary> 
    ///  Référentiel bidon qui permet d'obtenir les informations des avis de conformité fictifs 
    ///  codés en dur.
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Septembre 2016
    /// </remarks>
    public class AvisConformiteSimulation : IAvisConformite
    {
        /// <summary>
        /// Permet la création d'un avis de conformité
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Les informations sur l'état de l'opération</returns>
        /// <remarks></remarks>
        public CreerAvisConformiteSorti CreerAvisConformite(CreerAvisConformiteEntre intrant)
        {
            //TODO: Manque à changer le type des paramètres d'entré/sorti
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permet la modification d'un avis de conformité et son statut
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Les informations sur l'état de l'opération</returns>
        /// <remarks></remarks>
        public ModifierAvisConformiteSorti ModifierAvisConformite(ModifierAvisConformiteEntre intrant)
        {
            //TODO: Manque à changer le type des paramètres d'entré/sorti
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permet d'obtenir une liste des avis de conformité et de leurs statuts
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Une liste des avis de conformité avec leurs statuts</returns>
        /// <remarks></remarks>
        public ObtenirLesAvisConformiteSorti ObtenirLesAvisConformite(ObtenirLesAvisConformiteEntre intrant)
        {
            //TODO: Manque à changer le type des paramètres d'entré/sorti
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permet de modifier la période d'un avis de conformité et son statut
        /// </summary>
        /// <Parametre name="intrant">Parametreètre d'entré</Parametre>
        /// <returns>Retourne les informations de modification de l'avis de conformité</returns>
        /// <remarks></remarks>
        public ModifierPeriodeAvisSorti ModifierPeriodeAvis(ModifierPeriodeAvisEntre intrant)
        {
            //TODO: Manque à changer le type des paramètres d'entré/sorti
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fonction pour effectuer les traitements sur les avis de conformité
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns></returns>
        public TraiterAvisConformiteSorti TraiterAvisConformite(TraiterAvisConformiteEntre intrant)
        {
            //TODO: Manque à changer le type des paramètres d'entré/sorti
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permet de faire les traitements sur les avis de conformité
        /// </summary>
        /// <param name="intrant">numéro de pratique</param>
        /// <returns></returns>
        public ValiderAvisDerogationEnCoursSorti ValidationAvisDerogationEnCours(ValiderAvisDerogationEnCoursEntre intrant)
        {
            //TODO: Manque à changer le type des paramètres d'entré/sorti
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permet de modifier le statut d'engagement
        /// </summary>
        /// <param name="intrant">Paramètre d'entrée</param>
        /// <returns>Paramètre de sortie</returns>
        public ModifierStatutEngagementSorti ModifierStatutEngagement(ModifierStatutEngagementEntre intrant)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permet de créer le statut d'engagement
        /// </summary>
        /// <param name="intrant">Paramètre d'entrée</param>
        /// <returns>Paramètre de sortie</returns>
        public CreerStatutAvisConformiteSorti CreerStatutEngagement(CreerStatutAvisConformiteEntre intrant)
        {
            throw new NotImplementedException();
        }
    }
}