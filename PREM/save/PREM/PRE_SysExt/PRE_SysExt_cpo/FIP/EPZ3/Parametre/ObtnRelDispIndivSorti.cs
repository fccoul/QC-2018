#region Imports
using System.Collections.Generic;
using System.Data;
using RAMQ.ClasseBase;
using RAMQ.Attribut;

#endregion

namespace RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3.Parametre
{

    /// <summary> 
    ///  Paramètre de sortie pour obtenir les informations sur la relation dispensateur individu
    /// </summary>
    public class ObtnRelDispIndivSorti : ParamSorti
    {

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <remarks></remarks>
        public ObtnRelDispIndivSorti()
        {
            NumerosSequentielDispensateur = new List<long?>();
            NumerosDispensateur = new List<int?>();
            NumerosSequentielIndividu = new List<long?>();
            NumerosClasseDispensateur = new List<int?>();
            TerritoiresPermis = new List<string>();
            ChiffresPreuveDispensateur = new List<int?>();
            CodesProfession = new List<string>();
            DatesCreationDispensateur = new List<System.DateTime?>();
            IdentifiantsUtilisateurCreateur = new List<string>();
            DatesObtentionPermis = new List<System.DateTime?>();
            DatesInscriptionRamq = new List<System.DateTime?>();
            AnneesGraduation = new List<int?>();
            NumerosSequentielIntervenantGraduation = new List<long?>();
            IndicateursDemandeCourrier = new List<string>();
            IndicateursFacturationRecente = new List<string>();
            DatesPremiereSpecialite = new List<System.DateTime?>();
            DatesDebutPratique = new List<System.DateTime?>();
            NombresAnnneesExperienceHorsQuebec = new List<double?>();
            NombresAnneesExperienceQuebecSpecialiste = new List<double?>();
            DroitsAcquisTarifHoraire = new List<string>();
            DatesMAJDispensateur = new List<System.DateTime?>();
            IdentifiantsUtilisateurModificateur = new List<string>();
            NomsTronqueIndividu = new List<string>();
            PrenomsIndividu = new List<string>();
            NomsIndividu = new List<string>();
            NumeroAssuranceSocialeIndividu = new List<long?>();
            DatesCreationIndividu = new List<System.DateTime?>();
            IdentifiantsUtilisteurCreateurIndividu = new List<string>();
            LanguesIndividu = new List<string>();
            TitreCiviliteIndividu = new List<string>();
            SexeIndividu = new List<string>();
            DatesNaissanceIndividu = new List<System.DateTime?>();
            NomsNaissanceIndividu = new List<string>();
            StatutsCivilIndividu = new List<string>();
            DatesDecesIndividu = new List<System.DateTime?>();
            DatesModificationIndividu = new List<System.DateTime?>();
            IdentifiantUtilisateurModificateurIndividu = new List<string>();
        }
        #endregion

        #region Propriétés publiques

        /// <summary>
        /// Liste de numéro séquentiel de dispensateur
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblNoSeqDisp", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<long?> NumerosSequentielDispensateur { get; set; }

        /// <summary>
        /// Liste de numéro de dispensateur
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblNoDisp", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<int?> NumerosDispensateur { get; set; }

        /// <summary>
        /// Liste de numéro séquentiel d'individu
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblNoSeqIndiv", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<long?> NumerosSequentielIndividu { get; set; }

        /// <summary>
        /// Liste de classe du dispensateur
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblNoClaDisp", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<int?> NumerosClasseDispensateur { get; set; }

        /// <summary>
        /// Liste de territoire de pratique
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblTerriPermi", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<string> TerritoiresPermis { get; set; }

        /// <summary>
        /// Liste de chiffre preuve
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblChifrPrvDisp", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<int?> ChiffresPreuveDispensateur { get; set; }

        /// <summary>
        /// Liste de code de profession
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblCodPrfsn", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<string> CodesProfession { get; set; }

        /// <summary>
        /// Liste de date de création du dispensateur
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblDcDisp", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<System.DateTime?> DatesCreationDispensateur { get; set; }

        /// <summary>
        /// Liste d'identifiant créateur du dispensateur
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblIdUtilCreatDisp", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<string> IdentifiantsUtilisateurCreateur { get; set; }

        /// <summary>
        /// Liste de date d'obtention de permis
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblDatObtenPermiDisp", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<System.DateTime?> DatesObtentionPermis { get; set; }

        /// <summary>
        /// Liste de date d'inscription à la ramq
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblDatInscrRamqDisp", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<System.DateTime?> DatesInscriptionRamq { get; set; }

        /// <summary>
        /// Liste d'année de graduation
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblAnGradDisp", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<int?> AnneesGraduation { get; set; }

        /// <summary>
        /// Liste de numéro séquentiel identifiant l'intervenant secondaire de type "université"
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblNoSeqIntvnGrad", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<long?> NumerosSequentielIntervenantGraduation { get; set; }

        /// <summary>
        /// Liste d'indicateur de demande de courrier
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblIndDemCouri", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<string> IndicateursDemandeCourrier { get; set; }

        /// <summary>
        /// Liste d'indique si le dispensateur reçu paiement pour sa facturation dans la dernière année
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblIndFactRecen", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<string> IndicateursFacturationRecente { get; set; }

        /// <summary>
        /// Liste de date de première spécialité
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblDatPremSpec", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<System.DateTime?> DatesPremiereSpecialite { get; set; }

        /// <summary>
        /// Liste de date de début de pratique
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblDdPrati", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<System.DateTime?> DatesDebutPratique { get; set; }

        /// <summary>
        /// Liste de nombre d'années d'expérience reconnues pour la pratique hors Québec
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblNbrAnHqGenrl", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<double?> NombresAnnneesExperienceHorsQuebec { get; set; }

        /// <summary>
        /// Liste de nombre d'années d'expérience reconnues pour la pratique hors Québec pour spécialiste
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblNbrAnQcSpec", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<double?> NombresAnneesExperienceQuebecSpecialiste { get; set; }

        /// <summary>
        /// Liste d'indique si omni a droit au 5e échelon de l'échelle salariale de tarif horaire
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblDroitAcqTh", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<string> DroitsAcquisTarifHoraire { get; set; }

        /// <summary>
        /// Liste de date de mise à jour du dispensateur
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblDmDisp", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<System.DateTime?> DatesMAJDispensateur { get; set; }

        /// <summary>
        /// Liste d'identifiant modificateur du dispensateur
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblIdUtilMajDisp", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<string> IdentifiantsUtilisateurModificateur { get; set; }

        /// <summary>
        /// Liste de nom tronqué de l'individu
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblNomTronIndiv", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<string> NomsTronqueIndividu { get; set; }

        /// <summary>
        /// Liste de prénom de l'individu
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblPreIndiv", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<string> PrenomsIndividu { get; set; }

        /// <summary>
        /// Liste de nom de l'individu
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblNomIndiv", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<string> NomsIndividu { get; set; }

        /// <summary>
        /// Liste de numéro d'assurance sociale
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblNasIndiv", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<long?> NumeroAssuranceSocialeIndividu { get; set; }

        /// <summary>
        /// Liste de date de création de l'individu
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblDcIndiv", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<System.DateTime?> DatesCreationIndividu { get; set; }

        /// <summary>
        /// Liste d'identifiant créateur de l'individu
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblIdUtilCreatIndiv", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<string> IdentifiantsUtilisteurCreateurIndividu { get; set; }

        /// <summary>
        /// Liste de langue de l'individu
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblLangIndiv", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<string> LanguesIndividu { get; set; }

        /// <summary>
        /// Liste de titre civilité
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblTitreCivltIndiv", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<string> TitreCiviliteIndividu { get; set; }

        /// <summary>
        /// Liste de sexe de l'individu
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblSexeIndiv", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<string> SexeIndividu { get; set; }

        /// <summary>
        /// Liste de date de naissance de l'individu
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblDatNaissIndiv", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<System.DateTime?> DatesNaissanceIndividu { get; set; }

        /// <summary>
        /// Liste de nom de naissance de l'individu
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblNomNaissIndiv", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<string> NomsNaissanceIndividu { get; set; }

        /// <summary>
        /// Liste de statut civil de l'individu
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblStaCivilIndiv", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<string> StatutsCivilIndividu { get; set; }

        /// <summary>
        /// Liste de date de décès de l'individu
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblDatDecesIndiv", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<System.DateTime?> DatesDecesIndividu { get; set; }

        /// <summary>
        /// Liste de date de mise à jour de l'individu
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblDmIndiv", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<System.DateTime?> DatesModificationIndividu { get; set; }

        /// <summary>
        /// Liste d'identifiant modificateur de l'individu
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [ValeurEntite(ElementName = "pTblIdUtilMajIndiv", Direction = ParameterDirection.Output, TypeSorti = Enumeration.EnumTypeParamSorti.Tableau)]
        public List<string> IdentifiantUtilisateurModificateurIndividu { get; set; }

        #endregion

    }
}

