using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;

namespace RAMQ.PRE.PL_Prem_iut.Utilitaires
{
    /// <summary>
    /// Classe utilitaire
    /// </summary>
	public class Utilitaire : IUtilitaire
    {
        #region Génération nom professionnel

        /// <summary>
        /// Fonction retournant le nom à afficher comme identifiant du professionnel
        /// </summary>
        /// <param name="professionnel">Objet avec les informations du professionnel</param>
        /// <returns>Le numéro de pratique avec le nom et prénom concaténés</returns>
        public static string GenereNomAffichage(ObtenirDispensateurIndividuSorti professionnel)
        {   //TODO: Vérifier où est-ce qu'on peut mettre cette fonction pour qu'elle soit commune à l'iut et au svc
            return (professionnel.NumerosClasseDispensateur[0].Value * 100000 +
                   professionnel.NumerosDispensateur[0].Value).ToString() + " - " +
                   professionnel.NomsIndividu[0] + ", " +
                   professionnel.PrenomsIndividu[0];
        }

        #endregion


        #region Obtention de la zone de traitement

        /// <summary>
        /// Permet de savoir si l'usager est connecté dans la zone Intranet
        /// </summary>
        /// <returns></returns>
        public static bool EstDansZoneIntranet() {
            return ConfigurationManager.AppSettings.Get(Constantes.ZoneExec.CleZoneExec)
                .Equals(Constantes.ZoneExec.ZoneExecPrsenNtrnt);
        }

        #endregion

        #region Obtention du groupe

        /// <summary>
        /// Permet de savoir si l'usager connecté est dans le groupe recherché
        /// </summary>
        /// <param name="nomGroupe">Nom du groupe recherché</param>
        /// <returns>Vrai si l'usager est dans le groupe sinon faux</returns>
        public static bool EstDansGroupe(string nomGroupe)
        {
            return RAMQ.Securite.Principal.Identite.UsagerDansGroupe(
                new HttpContextWrapper(HttpContext.Current), nomGroupe);
        }

        /// <summary>
        /// Permet d'exposer cette fonction pour les tests unitaires.
        /// Au final on appel tout de même la fonction static.
        /// </summary>
        /// <param name="nomGroupe"></param>
        /// <returns></returns>
        bool IUtilitaire.EstDansGroupe(string nomGroupe)
        {
            return EstDansGroupe(nomGroupe);
        }

        #endregion

        #region Obtention du cookie

        /// <summary>
        /// Permet de retourner ce qui est inscrit dans le cookie spécifié
        /// </summary>
        /// <param name="nomCookie">nom du cookie</param>
        /// <returns>Information du cookie</returns>
        public static string ObtenirCookie(string nomCookie)
        {
            return new Etat.Cookie().ObtenirContxWebApp(nomCookie);
        }

        /// <summary>
        /// Permet d'exposer cette fonction pour les tests unitaires.
        /// Au final on appel tout de même la fonction static.
        /// </summary>
        /// <param name="nomCookie"></param>
        /// <returns></returns>
        string IUtilitaire.ObtenirCookie(string nomCookie)
        {
            return ObtenirCookie(nomCookie);
        }

        #endregion


        #region Conversion

        /// <summary>
        /// Permet de convertir un valeur string en boolean
        /// </summary>
        /// <param name="valeurConvertir">Valeur à convertir</param>
        /// <returns>Vrai ou faux</returns>
        public static bool ConvertirStringEnBoolean(string valeurConvertir)
        {
            if (!string.IsNullOrEmpty(valeurConvertir))
            {
                valeurConvertir = valeurConvertir.ToLower();
                if (valeurConvertir == "true" || valeurConvertir == "oui" || valeurConvertir == "o")
                {
                    return true;
                }
            }

            return false;
        }

        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<int> ObtenirListeAnneesDepuisAnnee(int annee)
        {
            var listeRetournee = new List<int>();

            for (int i = DateTime.Now.Year; i >= annee; i--)
            {
                listeRetournee.Add(i);
            }

            return listeRetournee;
        }
    }
}