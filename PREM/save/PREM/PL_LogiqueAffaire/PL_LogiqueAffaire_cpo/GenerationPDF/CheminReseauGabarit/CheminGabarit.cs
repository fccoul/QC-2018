using System;
using System.Configuration;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.CheminReseauGabarit
{
    /// <summary> 
    ///  Cette classe permet de récupérer le chemin physique
    ///  d'un gabarit sur le réseau.
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class CheminGabarit : ICheminGabarit
    {
        private readonly ILecteurConfiguration _lecteurConfiguration;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="lecteurConfiguration">lecteur de configurations</param>
        public CheminGabarit(ILecteurConfiguration lecteurConfiguration)
        {
            ValidateurParametreObligatoire.ValiderParametreNull(lecteurConfiguration, nameof(lecteurConfiguration));

            _lecteurConfiguration = lecteurConfiguration;
        }

        /// <summary>
        /// Obtenir le chemin réseau d'un gabarit selon le type de gabarit
        /// </summary>
        /// <param name="typeGabarit">Type de gabarit</param>
        /// <returns>Retourne le chemin sur le réseau du gabarit selon le type de gaabrit</returns>
        public string Obtenir(TypeGabarit typeGabarit)
        {
            var nomCleConfiguration = ObtenirNomCleConfiguration(typeGabarit);
            string cheminPhysiqueGabarit = ObtenirCheminPhysiqueGabarit(nomCleConfiguration);

            return cheminPhysiqueGabarit;
        }

        private string ObtenirCheminPhysiqueGabarit(string nomCleConfiguration)
        {
            var cheminPhysiqueGabarit = _lecteurConfiguration.LireConfiguration(nomCleConfiguration);

            if (string.IsNullOrEmpty(cheminPhysiqueGabarit))
            {
                throw new ConfigurationErrorsException($"La clé : {nomCleConfiguration} n'est pas présente dans le fichier de configuration.");
            }

            return cheminPhysiqueGabarit;
        }

        private string ObtenirNomCleConfiguration(TypeGabarit typeGabarit)
        {
            var nomCleConfiguration = string.Empty;

            switch (typeGabarit)
            {
                case TypeGabarit.ConfirmationAvisConformite:
                    nomCleConfiguration = "GabaritXslConfirmationAvisConformite";
                    break;
                case TypeGabarit.ConfirmationSuspension:
                    nomCleConfiguration = "GabaritXslConfirmationSuspension";
                    break;
                case TypeGabarit.ConfirmationModificationSuspension:
                    nomCleConfiguration = "GabaritXslConfirmationModificationSuspension";
                    break;
                case TypeGabarit.ConfirmationDerogation:
                    nomCleConfiguration = "GabaritXslConfirmationDerogation";
                    break;
                default:
                    throw new NotSupportedException($"La valeur de la variable {nameof(typeGabarit)} : {typeGabarit.ToString()} n'est pas supportée.");
            }

            return nomCleConfiguration;
        }
    }
}