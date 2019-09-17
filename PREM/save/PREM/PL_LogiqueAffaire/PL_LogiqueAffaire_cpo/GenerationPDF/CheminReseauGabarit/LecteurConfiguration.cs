using System;
using System.Configuration;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.CheminReseauGabarit
{
    /// <summary> 
    ///  Classe permettant de lire des configurations
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class LecteurConfiguration : ILecteurConfiguration
    {
        /// <summary>
        /// Lire une configuration dans la section AppSettings
        /// </summary>
        /// <param name="nomCleConfiguration"></param>
        /// <returns>Retourne la valeur de la clé de configuration passée en paramètre.</returns>
        public string LireConfiguration(string nomCleConfiguration)
        {
            ValiderParametreObligatoire(nomCleConfiguration);

            var valeurCleConfiguration = string.Empty;

            try
            {
                valeurCleConfiguration = ConfigurationManager.AppSettings[nomCleConfiguration];
            }
            catch (ConfigurationErrorsException ex)
            {
                throw new Exception($"Erreur lors de la lecture de la clé de configuration : {nomCleConfiguration}, voici la trace : {ex.Message}.");
            }

            return valeurCleConfiguration ?? string.Empty;
        }

        private void ValiderParametreObligatoire(string nomCleConfiguration)
        {
            if (string.IsNullOrEmpty(nomCleConfiguration))
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(nomCleConfiguration)}, ne peut être nul.");
            }
        }
    }
}