#region Imports

using System.Configuration;

#endregion

namespace RAMQ.PRE.PL_PremMdl_cpo
{

    /// <summary> 
    ///  Classe permettant d'accéder aux paramètres de configuration
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Septembre 2016
    /// </remarks>
    internal sealed class Config
    {

        #region Constantes

        private const string CleSimulationDemandeReevaluation = nameof(SimulationDemandeReevaluation);
        private const string CleSimulationAvisConformite = nameof(SimulationAvisConformite);
        private const string CleSimulationProfessionnel = nameof(SimulationProfessionnel);
        private const string CleSimulationDroitAcquis = nameof(SimulationDroitAcquis);
        private const string CleSimulationLieuGeographique = nameof(SimulationLieuGeographique);
        private const string CleSimulationConsultationProfilProfessionnel = nameof(SimulationConsultationProfilProfessionnel);
        private const string CleSimulationDecisionAvisConformite = nameof(SimulationDecisionAvisConformite);
        private const string CleSimulationGabaritPDFConfirmation = nameof(SimulationGabaritPDFConfirmation);
        private const string CleSimulationRapport = nameof(SimulationRapport);
        private const string CleSimulationAutorisation = nameof(Autorisation);
        #endregion

        #region Constructeur

        /// <summary>
        ///  Constructeur privé pour empêcher l'instantiation de la classe
        /// </summary>
        /// <remarks></remarks>
        private Config()
        {
        }

        #endregion

        #region Propriétés publiques partagées
        /// <summary>
        ///  Indique si on doit utiliser le référentiel simulé pour IDemandeReevaluation
        /// </summary>
        /// <remarks></remarks>
        public static bool SimulationDemandeReevaluation
        {
            get { return LireParametreOuiNon(CleSimulationDemandeReevaluation); }
        }

        /// <summary>
        ///  Indique si on doit utiliser le référentiel simulé pour IAvis.
        /// </summary>
        /// <remarks></remarks>
        public static bool SimulationAvisConformite
        {
            get { return LireParametreOuiNon(CleSimulationAvisConformite); }
        }

        /// <summary>
        /// Indique si on doit utiliser la simulation pour les gabarits de confirmation
        /// </summary>
        public static bool SimulationGabaritPDFConfirmation
        {
            get { return LireParametreOuiNon(CleSimulationGabaritPDFConfirmation); }
        }

        /// <summary>
        ///  Indique si on doit utiliser le référentiel simulé pour IProfessionnel.
        /// </summary>
        /// <remarks></remarks>
        public static bool SimulationProfessionnel
        {
            get { return LireParametreOuiNon(CleSimulationProfessionnel); }
        }

        /// <summary>
        ///  Indique si on doit utiliser le référentiel simulé pour IDroitAcquis.
        /// </summary>
        /// <remarks></remarks>
        public static bool SimulationDroitAcquis
        {
            get { return LireParametreOuiNon(CleSimulationDroitAcquis); }
        }

        /// <summary>
        ///  Indique si on doit utiliser le référentiel simulé pour ILieuGeographique.
        /// </summary>
        /// <remarks></remarks>
        public static bool SimulationLieuGeographique
        {
            get { return LireParametreOuiNon(CleSimulationLieuGeographique); }
        }

        /// <summary>
        ///  Indique si on doit utiliser le référentiel simulé pour IConsultationProfilProfessionnel.
        /// </summary>
        /// <remarks></remarks>
        public static bool SimulationConsultationProfilProfessionnel
        {
            get { return LireParametreOuiNon(CleSimulationConsultationProfilProfessionnel); }
        }

        /// <summary>
        ///  Indique si on doit utiliser le référentiel simulé pour IDecisionAvisConformite.
        /// </summary>
        /// <remarks></remarks>
        public static bool SimulationDecisionAvisConformite
        {
            get { return LireParametreOuiNon(CleSimulationDecisionAvisConformite); }
        }

        /// <summary>
        ///  Indique si on doit utiliser le référentiel simulé pour IRapport.
        /// </summary>
        /// <remarks></remarks>
        public static bool SimulationRapport
        {
            get { return LireParametreOuiNon(CleSimulationRapport); }
        }

        /// <summary>
        ///  Indique si on doit utiliser le référentiel simulé pour IAutorisation.
        /// </summary>
        /// <remarks></remarks>
        public static bool SimulationAutorisation
        {
            get { return LireParametreOuiNon(CleSimulationAutorisation); }
        }

        #endregion

        #region Méthodes privées partagées

        /// <summary>
        ///  Permet de lire un paramètre du fichier de configuration qui peut-avoir la valeur 
        ///  « OUI » ou la valeur « NON ».
        /// </summary>
        /// <param name="cleParametre">Clé du paramètre à lire</param>
        /// <returns>
        ///  Vrai si le paramètre est présent et sa valeur est « OUI », faux dans tous les 
        ///  autres cas.
        /// </returns>
        /// <remarks>
        ///  Si le paramètres est absent ou a une valeur autre que « OUI », sa valeur est 
        ///  réputée être à « NON ».
        /// </remarks>
        private static bool LireParametreOuiNon(string cleParametre)
        {
            string valeur = null;
            valeur = ConfigurationManager.AppSettings.Get(cleParametre);

            return !string.IsNullOrWhiteSpace(valeur) && valeur == Constantes.Oui;
        }

        #endregion
        
    }
}