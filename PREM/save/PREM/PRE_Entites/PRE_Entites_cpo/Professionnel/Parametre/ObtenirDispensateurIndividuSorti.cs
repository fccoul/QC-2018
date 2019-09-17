using System;
using System.Collections.Generic;
using RAMQ.ClasseBase;

namespace RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre
{

    /// <summary> 
    ///  Paramètre de sortie pour obtenir les informations sur la relation dispensateur individu
    /// </summary>
    /// <remarks>
    ///  Auteur : Danick Nadeau <br/>
    ///  Date   : Octobre 2016
    /// </remarks>
    public class ObtenirDispensateurIndividuSorti : ParamSorti
    {

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtenirDispensateurIndividuSorti()
        {
            NumerosSequentielDispensateur = new List<long?>();
            NumerosDispensateur = new List<int?>();
            NumerosSequentielIndividu = new List<long?>();
            NumerosClasseDispensateur = new List<int?>();
            TerritoiresPermis = new List<string>();
            ChiffresPreuveDispensateur = new List<int?>();
            CodesProfession = new List<string>();
            DatesCreationDispensateur = new List<DateTime?>();
            IdentifiantsUtilisateurCreateur = new List<string>();
            DatesObtentionPermis = new List<DateTime?>();
            DatesInscriptionRamq = new List<DateTime?>();
            AnneesGraduation = new List<int?>();
            NumerosSequentielIntervenantGraduation = new List<long?>();
            IndicateursDemandeCourrier = new List<string>();
            IndicateursFacturationRecente = new List<string>();
            DatesPremiereSpecialite = new List<DateTime?>();
            DatesDebutPratique = new List<DateTime?>();
            NombresAnnneesExperienceHorsQuebec = new List<double?>();
            NombresAnneesExperienceQuebecSpecialiste = new List<double?>();
            DroitsAcquisTarifHoraire = new List<string>();
            DatesMAJDispensateur = new List<DateTime?>();
            IdentifiantsUtilisateurModificateur = new List<string>();
            NomsTronqueIndividu = new List<string>();
            PrenomsIndividu = new List<string>();
            NomsIndividu = new List<string>();
            NumeroAssuranceSocialeIndividu = new List<long?>();
            DatesCreationIndividu = new List<DateTime?>();
            IdentifiantsUtilisteurCreateurIndividu = new List<string>();
            LanguesIndividu = new List<string>();
            TitreCiviliteIndividu = new List<string>();
            SexeIndividu = new List<string>();
            DatesNaissanceIndividu = new List<DateTime?>();
            NomsNaissanceIndividu = new List<string>();
            StatutsCivilIndividu = new List<string>();
            DatesDecesIndividu = new List<DateTime?>();
            DatesModificationIndividu = new List<DateTime?>();
            IdentifiantUtilisateurModificateurIndividu = new List<string>();
        }
        #endregion

        #region Propriétés publiques

        /// <summary>
        /// Liste de numéro séquentiel de dispensateur
        /// </summary>
        public List<long?> NumerosSequentielDispensateur { get; set; }

        /// <summary>
        /// Liste de numéro de dispensateur
        /// </summary>
        public List<int?> NumerosDispensateur { get; set; }

        /// <summary>
        /// Liste de numéro séquentiel d'individu
        /// </summary>
        public List<long?> NumerosSequentielIndividu { get; set; }

        /// <summary>
        /// Liste de classe du dispensateur
        /// </summary>
        public List<int?> NumerosClasseDispensateur { get; set; }

        /// <summary>
        /// Liste de territoire de pratique
        /// </summary>
        public List<string> TerritoiresPermis { get; set; }

        /// <summary>
        /// Liste de chiffre preuve
        /// </summary>
        public List<int?> ChiffresPreuveDispensateur { get; set; }

        /// <summary>
        /// Liste de code de profession
        /// </summary>
        public List<string> CodesProfession { get; set; }

        /// <summary>
        /// Liste de date de création du dispensateur
        /// </summary>
        public List<DateTime?> DatesCreationDispensateur { get; set; }

        /// <summary>
        /// Liste d'identifiant créateur du dispensateur
        /// </summary>
        public List<string> IdentifiantsUtilisateurCreateur { get; set; }

        /// <summary>
        /// Liste de date d'obtention de permis
        /// </summary>
        public List<DateTime?> DatesObtentionPermis { get; set; }

        /// <summary>
        /// Liste de date d'inscription à la ramq
        /// </summary>
        public List<DateTime?> DatesInscriptionRamq { get; set; }

        /// <summary>
        /// Liste d'année de graduation
        /// </summary>
        public List<int?> AnneesGraduation { get; set; }

        /// <summary>
        /// Liste de numéro séquentiel identifiant l'intervenant secondaire de type "université"
        /// </summary>
        public List<long?> NumerosSequentielIntervenantGraduation { get; set; }

        /// <summary>
        /// Liste d'indicateur de demande de courrier
        /// </summary>
        public List<string> IndicateursDemandeCourrier { get; set; }

        /// <summary>
        /// Liste d'indique si le dispensateur reçu paiement pour sa facturation dans la dernière année
        /// </summary>
        public List<string> IndicateursFacturationRecente { get; set; }

        /// <summary>
        /// Liste de date de première spécialité
        /// </summary>
        public List<DateTime?> DatesPremiereSpecialite { get; set; }

        /// <summary>
        /// Liste de date de début de pratique
        /// </summary>
        public List<DateTime?> DatesDebutPratique { get; set; }

        /// <summary>
        /// Liste de nombre d'années d'expérience reconnues pour la pratique hors Québec
        /// </summary>
        public List<double?> NombresAnnneesExperienceHorsQuebec { get; set; }

        /// <summary>
        /// Liste de nombre d'années d'expérience reconnues pour la pratique hors Québec pour spécialiste
        /// </summary>
        public List<double?> NombresAnneesExperienceQuebecSpecialiste { get; set; }

        /// <summary>
        /// Liste d'indique si omni a droit au 5e échelon de l'échelle salariale de tarif horaire
        /// </summary>
        public List<string> DroitsAcquisTarifHoraire { get; set; }

        /// <summary>
        /// Liste de date de mise à jour du dispensateur
        /// </summary>
        public List<DateTime?> DatesMAJDispensateur { get; set; }

        /// <summary>
        /// Liste d'identifiant modificateur du dispensateur
        /// </summary>
        public List<string> IdentifiantsUtilisateurModificateur { get; set; }

        /// <summary>
        /// Liste de nom tronqué de l'individu
        /// </summary>
        public List<string> NomsTronqueIndividu { get; set; }

        /// <summary>
        /// Liste de prénom de l'individu
        /// </summary>
        public List<string> PrenomsIndividu { get; set; }

        /// <summary>
        /// Liste de nom de l'individu
        /// </summary>
        public List<string> NomsIndividu { get; set; }

        /// <summary>
        /// Liste de numéro d'assurance sociale
        /// </summary>
        public List<long?> NumeroAssuranceSocialeIndividu { get; set; }

        /// <summary>
        /// Liste de date de création de l'individu
        /// </summary>
        public List<DateTime?> DatesCreationIndividu { get; set; }

        /// <summary>
        /// Liste d'identifiant créateur de l'individu
        /// </summary>
        public List<string> IdentifiantsUtilisteurCreateurIndividu { get; set; }

        /// <summary>
        /// Liste de langue de l'individu
        /// </summary>
        public List<string> LanguesIndividu { get; set; }

        /// <summary>
        /// Liste de titre civilité
        /// </summary>
        public List<string> TitreCiviliteIndividu { get; set; }

        /// <summary>
        /// Liste de sexe de l'individu
        /// </summary>
        public List<string> SexeIndividu { get; set; }

        /// <summary>
        /// Liste de date de naissance de l'individu
        /// </summary>
        public List<DateTime?> DatesNaissanceIndividu { get; set; }

        /// <summary>
        /// Liste de nom de naissance de l'individu
        /// </summary>
        public List<string> NomsNaissanceIndividu { get; set; }

        /// <summary>
        /// Liste de statut civil de l'individu
        /// </summary>
        public List<string> StatutsCivilIndividu { get; set; }

        /// <summary>
        /// Liste de date de décès de l'individu
        /// </summary>
        public List<DateTime?> DatesDecesIndividu { get; set; }

        /// <summary>
        /// Liste de date de mise à jour de l'individu
        /// </summary>
        public List<DateTime?> DatesModificationIndividu { get; set; }

        /// <summary>
        /// Liste d'identifiant modificateur de l'individu
        /// </summary>
        public List<string> IdentifiantUtilisateurModificateurIndividu { get; set; }

        #endregion

    }
}