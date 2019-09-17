using System.Configuration;

namespace RAMQ.PRE.PL_Prem_iut.Utilitaires
{
    /// <summary>
    /// Classe pour les configurations dans le web.config
    /// </summary>
	public class Configuration
    {
        private Configuration() { }


        private const string CleGroupeSupport = "PRE_CnsulSuppo";
        private const string CleGroupeDRMG = "PRE_SaisAvisConfDRMG";
        private const string CleGroupeComiteParitaire = "PRE_SaisDecisComtParit";
        private const string CleGroupeConsultationProfilPrem = "PRE_CnsulProfiProf";
        private const string CleURLEPL4 = "UrlEPL4";
        private const string CleURLEPL4Intra = "UrlEPL4Intra";
        private const string CleAfficherMenuPLA1 = "AfficherMenuPLA1";
        private const string CleAfficherMenuPLA2 = "AfficherMenuPLA2";
        private const string CleAfficherMenuPLC1 = "AfficherMenuPLC1";
        private const string CleAfficherMenuPLC2 = "AfficherMenuPLC2";
        private const string CleAfficherOngletRPPR = "AfficherOngletRPPR";
        private const string CleAfficherMenuPLC1RPPR = "AfficherMenuPLC1RPPR";

        /// <summary>
        /// Groupe de support
        /// </summary>
        public static string GroupeSupport
        {
            get { return ConfigurationManager.AppSettings.Get(CleGroupeSupport); }
        }

        /// <summary>
        /// Groupe pour les DRMG
        /// </summary>
        public static string GroupeDRMG
        {
            get { return ConfigurationManager.AppSettings.Get(CleGroupeDRMG); }
        }

        /// <summary>
        /// Groupe pour le comité paritaire
        /// </summary>
        public static string GroupeComiteParitaire
        {
            get { return ConfigurationManager.AppSettings.Get(CleGroupeComiteParitaire); }
        }

        /// <summary>
        /// Groupe pour la consultation du profil PREM
        /// </summary>
        public static string GroupeConsultationProfilPrem
        {
            get { return ConfigurationManager.AppSettings.Get(CleGroupeConsultationProfilPrem); }
        }

        /// <summary>
        /// Indicateur d'affichage du menu PLA1
        /// </summary>
        public static string AfficherPLA1
        {
            get { return ConfigurationManager.AppSettings.Get(CleAfficherMenuPLA1); }
        }

        /// <summary>
        /// Indicateur d'affichage du menu PLA2
        /// </summary>
        public static string AfficherPLA2
        {
            get { return ConfigurationManager.AppSettings.Get(CleAfficherMenuPLA2); }
        }

        /// <summary>
        /// Indicateur d'affichage du menu PLC1
        /// </summary>
        public static string AfficherPLC1
        {
            get { return ConfigurationManager.AppSettings.Get(CleAfficherMenuPLC1); }
        }

        /// <summary>
        /// Indicateur d'affichage du menu PLC2
        /// </summary>
        public static string AfficherPLC2
        {
            get { return ConfigurationManager.AppSettings.Get(CleAfficherMenuPLC1); }
        }

        /// <summary>
        /// Indicateur d'affichage de l'onglet RPPR
        /// </summary>
        public static string AfficherOngletRPPR
        {
            get { return ConfigurationManager.AppSettings.Get(CleAfficherOngletRPPR); }
        }

        /// <summary>
        /// Indicateur d'affichage de du menu PLC1 RPPR
        /// </summary>
        public static string AfficherPLC1RPPR
        {
            get { return ConfigurationManager.AppSettings.Get(CleAfficherMenuPLC1RPPR); }
        }

    }
}