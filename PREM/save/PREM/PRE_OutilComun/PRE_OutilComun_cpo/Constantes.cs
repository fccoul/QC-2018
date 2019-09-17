namespace RAMQ.PRE.PRE_OutilComun_cpo
{
    /// <summary>
    /// Classe de constante commune dans le projet PRE
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier<br/>
    ///  Date   : Octobre 2016
    /// <br/>
    /// </remarks>
    public sealed class Constantes
    {
        /// <summary>
        /// Constructeur privé
        /// </summary>
        private Constantes() { }

        /// <summary>
        /// Code d'application
        /// </summary>
        /// <remarks></remarks>
        public const string CodeApplication = nameof(PRE);
       
        /// <summary>
        /// Nom de l'UDL
        /// </summary>
        /// <remarks></remarks>
        public const string NomUDL = "PRE_ORA.udl";

        /// <summary>
        /// Indicateur non
        /// </summary>
        public const string IndicateurNon = "N";

        /// <summary>
        /// Indicateur oui
        /// </summary>
        public const string IndicateurOui = "O";


        /// <summary>
        /// Classe de constante pour les sources de réévaluation
        /// </summary>
        public sealed class SourceReeva
        {
            /// <summary>
            /// Constructeur privé
            /// </summary>
            private SourceReeva() { }

            /// <summary>
            /// Agent
            /// </summary>
            public const int Agent = 1;

            /// <summary>
            /// Traitement
            /// </summary>
            public const int Traitement = 2;

        }

        /// <summary>
        /// Classe de constante pour les catégories de réévaluation
        /// </summary>
        public sealed class CategorieReeva
        {
            /// <summary>
            /// Constructeur privé
            /// </summary>
            private CategorieReeva() { }

            /// <summary>
            /// CodeComplete
            /// </summary>
            public const int CodeComplete = 1;

            /// <summary>
            /// CodePartielle
            /// </summary>
            public const int CodePartielle = 2;

        }

        /// <summary>
        /// Classe de constante pour les traitements
        /// </summary>
        public sealed class Traitements
        {
            /// <summary>
            /// Constructeur privé
            /// </summary>
            private Traitements() { }

            /// <summary>
            /// PLE1
            /// </summary>
            public const string CodePLE1 = "PLE1";

            /// <summary>
            /// PLA1
            /// </summary>
            public const string CodePLA1 = "PLA1";

            /// <summary>
            /// PLA2
            /// </summary>
            public const string CodePLA2 = "PLA2";

            /// <summary>
            /// PLF1
            /// </summary>
            public const string CodePLF1 = "PLF1";
        }

        /// <summary>
        /// Classe de constante pour les lieux géographique
        /// </summary>
        public sealed class LieuxGeographiques
        {
            /// <summary>
            /// Constructeur privé
            /// </summary>
            private LieuxGeographiques() { }

            /// <summary>
            /// Type de regroupement
            /// </summary>
            public const string TypeRegroupement = "PREM";

            /// <summary>
            /// Numéro de document officiel
            /// </summary>
            public const string NumeroDocumentOfficiel = "1177";

            /// <summary>
            /// Région socio-sanitaire
            /// </summary>
            public const string RegionSocioSanitaire = "RSS";
        }

        /// <summary>
        /// Constantes pour les codes de retour
        /// </summary>
        public sealed class CodeRetour
        {
            /// <summary>
            /// Constructeur privé
            /// </summary>
            private CodeRetour() { }

            /// <summary>
            /// Erreur imprévu
            /// </summary>
            public const string E_40758_ErreurImprevu = "40758";

            /// <summary>
            /// Code de retour 8689
            /// </summary>
            public const string E_8689_DateReporterAnterieur = "8689";

            /// <summary>
            /// Code de retour 42918
            /// </summary>
            public const string I_42918_AvisEnCours = "42918";

            /// <summary>
            /// Code de retour 42920
            /// </summary>
            public const string I_42920_AvisNonActif = "42920";

            /// <summary>
            /// Code de retour 41962
            /// </summary>
            public const string Q_41962_PratiquePossible = "41962";

            /// <summary>
            /// Code de retour 41963
            /// </summary>
            public const string E_41963_PratiqueImpossible = "41963";

            /// <summary>
            /// Code de retour 43640
            /// </summary>
            public const string E_43640_CaseCocheEnregistrer = "43640";

            /// <summary>
            /// Code de retour 43638
            /// </summary>
            public const string E_43638_CaseCocheTransmettre = "43638";

            /// <summary>
            /// Code de retour 43641
            /// </summary>
            public const string E_43641_ValidationProfessionnel = "43641";

            /// <summary>
            /// Code de retour 43645
            /// </summary>
            public const string E_43645_ValidationObtentionPermis = "43645";

            /// <summary>
            /// Code de retour 43644
            /// </summary>
            public const string E_43644_ValidationMemeTerritoire = "43644";

            /// <summary>
            /// Code de retour 43639
            /// </summary>
            public const string E_43639_ValidationAvisFuture = "43639";

            /// <summary>
            /// Code de retour 43642
            /// </summary>
            public const string E_43642_DerogationActive = "43642";

            /// <summary>
            /// Code de retour 43643
            /// </summary>
            public const string Q_43643_DerogationActive = "43643";

            /// <summary>
            /// Code de retour 42919
            /// </summary>
            public const string I_42919_DerogationEnCours = "42919";

            /// <summary>
            /// Code de retour 41964
            /// </summary>
            public const string E_41964_DateReporterPlusSixMois = "41964";

            /// <summary>
            /// Code de retour 43959
            /// </summary>
            public const string E_43959_AucuneModification = "43959";

            /// <summary>
            /// Code de retour 147939
            /// </summary>
            public const string E_147939_PasDroits = "147939";

            /// <summary>
            /// Code de retour 41078
            /// </summary>
            public const string E_41078_SaisirValeurContinuer = "41078";

            /// <summary>
            /// Code de retour 147998
            /// </summary>
            public const string E_147998_CocherCaseDerogation = "147998";

            /// <summary>
            /// Code de retour 147999
            /// </summary>
            public const string E_147999_CocherCaseSuspension = "147999";

            /// <summary>
            /// Code de retour 148000
            /// </summary>
            public const string E_148000_CocherCaseDecision = "148000";

            /// <summary>
            /// Code de retour 148001
            /// </summary>
            public const string E_148001_DerogNePeutInsctModif = "148001";

            /// <summary>
            /// Code de retour 148002
            /// </summary>
            public const string E_148002_DatDerogDatObtenPermi = "148002";

            /// <summary>
            /// Code de retour 148003
            /// </summary>
            public const string E_148003_DerogActiveMemeTyp = "148003";

            /// <summary>
            /// Code de retour 148004
            /// </summary>
            public const string E_148004_DerogComtParitRglrs = "148004";

            /// <summary>
            /// Code de retour 148005
            /// </summary>
            public const string E_148005_AvisConfPresMdStaSusp = "148005";

            /// <summary>
            /// Code de retour 148006
            /// </summary>
            public const string Q_148006_MettreFinDerogation = "148006";

            /// <summary>
            /// Code de retour 148007
            /// </summary>
            public const string Q_148007_MettreFinAvisConf = "148007";

            /// <summary>
            /// Code de retour 148008
            /// </summary>
            public const string I_148008_DerogTranmAnnuSucces = "148008";

            /// <summary>
            /// Code de retour 148009
            /// </summary>
            public const string I_148009_NotAvisConfTerriFerme = "148009";

            /// <summary>
            /// Code de retour 148010
            /// </summary>
            public const string I_148010_NotDerogTypeFerme = "148010";

            /// <summary>
            /// Code de retour 148011
            /// </summary>
            public const string E_148011_DatFinSuspSupEgDatDeb = "148011";

            /// <summary>
            /// Code de retour 148012
            /// </summary>
            public const string E_148012_PerSuspPasDepasserAn = "148012";

            /// <summary>
            /// Code de retour 148013
            /// </summary>
            public const string E_148013_ChvmnSuspExist = "148013";

            /// <summary>
            /// Code de retour 148014
            /// </summary>
            public const string E_148014_AjouSuspProlPasPosib = "148014";

            /// <summary>
            /// Code de retour 148015
            /// </summary>
            public const string E_148015_DatSupsPerAvisconf = "148015";

            /// <summary>
            /// Code de retour 148016
            /// </summary>
            public const string I_148016_SuspAvisConfSucces = "148016";

            /// <summary>
            /// Code de retour 148017
            /// </summary>
            public const string E_148017_PasPosibAjouModifSusp = "148017";

            /// <summary>
            /// Code de retour 148018
            /// </summary>
            public const string E_148018_AvisConfProfSantInxst = "148018";

            /// <summary>
            /// Code de retour 148019
            /// </summary>
            public const string E_148019_SuspAvisConfSelecInxst = "148019";

            /// <summary>
            /// Code de retour 148020
            /// </summary>
            public const string E_148020_SuspPeutPasIMAAvisConf = "148020";

            /// <summary>
            /// Code de retour 148021
            /// </summary>
            public const string E_148021_AnnuSupsSuiviProl = "148021";

            /// <summary>
            /// Code de retour 148038
            /// </summary>
            public const string E_148038_DerogProfSantInxst = "148038";

            /// <summary>
            /// Code de retour 148058
            /// </summary>
            public const string E_148058_PasPosibAjouSuspDifrn = "148058";

            /// <summary>
            /// Code de retour 40958
            /// </summary>
            public const string E_40958_ParametrePasValide = "40958";

            /// <summary>
            /// Code de retour 40959
            /// </summary>
            public const string E_40959_ParametreAbsent = "40959";

            /// <summary>
            /// Code de retour 148378
            /// </summary>
            public const string E_148378_AucunRSSChoisi = "148378";

            /// <summary>
            /// Code de retour 43818
            /// </summary>
            public const string I_43818_AucunAvisNonTransmis = "43818";

            /// <summary>
            /// Code de retour 148881
            /// </summary>
            public const string E_148881_DateCoincidePeriodeSuspension = "148881";

            /// <summary>
            /// Code de retour 148882
            /// </summary>
            public const string E_148882_DerogationExistante = "148882";

            /// <summary>
            /// Code de retour 42198
            /// </summary>
            public const string I_42198_MedecinPasSujetAuxRestrictionsRegionPratique = "42198";

            /// <summary>
            /// Code de retour 44038
            /// </summary>
            public const string I_44038_AucunDroitExercerRegionPratique = "44038";

            /// <summary>
            /// Code de retour 148603
            /// </summary>
            public const string I_148603_AucuneReductionRemunerationDossier = "148603";

            /// <summary>
            /// Code de retour 148642
            /// </summary>
            public const string I_148642_LignePeutContenirJourneeRealiserPendantSuspension = "148642";

            /// <summary>
            /// Code de retour 148722
            /// </summary>
            public const string E_148722_MedecinPasSousReponsabiliteUtilisateurConnecter = "148722";

            /// <summary>
            /// Code de retour 148723
            /// </summary>
            public const string I_148723_MedecinJamaisSoumisEntentePREM = "148723";

            /// <summary>
            /// Code de retour 148724
            /// </summary>
            public const string I_148724_MedecinDecederOuSpecialiteDepuis = "148724";


            /// <summary>
            /// Code de retour 149401
            /// </summary>
            public const string I_149401_AucuneAutorisationExercice = "149401";

            /// <summary>
            /// Code de retour 149402
            /// </summary>
            public const string E_149402_CaseConfirmationNonCochePourTransmission = "149402";

            /// <summary>
            /// Code de retour 149403
            /// </summary>
            public const string E_149403_DateFinAutorisationPlusGrandeQueDateDebut = "149403";

            /// <summary>
            /// Code de retour 149404
            /// </summary>
            public const string E_149404_PeriodeAutorisationDepasseUnAn = "149404";

            /// <summary>
            /// Code de retour 149405
            /// </summary>
            public const string E_149405_AutorisationSaisieOuModifie = "149405";

            /// <summary>
            /// Code de retour 149406
            /// </summary>
            public const string E_149406_DateDebutAutorisationEgaleOuPosterieur = "149406";

            /// <summary>
            /// Code de retour 149407
            /// </summary>
            public const string E_149407_AutorisationDejaPresenteDurantResidence = "149407";

            /// <summary>
            /// Code de retour 149408
            /// </summary>
            public const string I_149408_AutorisationPendantResidenceAnnulee = "149408";

            /// <summary>
            /// Code de retour 149409
            /// </summary>
            public const string E_149409_CaseConfirmationNonCochePourAnnuler = "149409";

            /// <summary>
            /// Code de retour 149410
            /// </summary>
            public const string I_149410_AutorisationAnnulee = "149410";

            /// <summary>
            /// Code de retour 149411
            /// </summary>
            public const string E_149411_AvisConformiteExistant = "149411";

            /// <summary>
            /// Code de retour 149412
            /// </summary>
            public const string E_149412_DerogationExistante = "149412";

            /// <summary>
            /// Code de retour 149413
            /// </summary>
            public const string E_149413_AnnulationPlusRecenteAutorisation = "149413";

            /// <summary>
            /// Code de retour 149414
            /// </summary>
            public const string E_149414_ConflitAutorisation = "149414";

            /// <summary>
            /// Code de retour 149415
            /// </summary>
            public const string I_149415_RenouvellementAutorisationTransmise = "149415";

            /// <summary>
            /// Code de retour 149416
            /// </summary>
            public const string E_149416_AutorisationExistantePourPeriodeCouranteComiteParitaire = "149416";

            /// <summary>
            /// Code de retour 149561
            /// </summary>
            public const string E_149561_AutorisationExistantePourPeriodeCouranteDRMG = "149561";

            /// <summary>
            /// Code de retour 149710
            /// </summary>
            public const string I_149710_AvisConformiteEnVigueurDansRegion = "149710";

            /// <summary>
            /// Code de retour 149711
            /// </summary>
            public const string I_149711_AvisConformiteEnVigueurDepuis = "149711";
            /// <summary>
            ///  Code de retour 149061
            /// </summary>
            public const string E_149061_NumeroPratiqueSixCaractereCommenceParUn = "149061";

            /// <summary>
            /// Code de retour 149062
            /// </summary>
            public const string E_149062_NumeroPratiqueSaisieInexistant = "149062";

            /// <summary>
            /// Code de retour 150161
            /// </summary>
            public const string E_150161_ChampAbsentDuService = "150161";

            /// <summary>
            /// Code de retour 150162
            /// </summary>
            public const string E_150162_CodePostalEtCodeLocalAbsent = "150162";

            /// <summary>
            /// Code de retour 150289
            /// </summary>
            public const string E_150289_TailleChampTropGrande = "150289";

            /// <summary>
            /// Code de retour 151044
            /// </summary>
            public const string E_151044_DateDebutSuperieureDateFin = "151044";

            /// <summary>
            /// Code de retour 151078
            /// </summary>
            public const string C_151078_ConfirmationSuppressionDemandeReeval = "151078";

            /// <summary>
            /// Code de retour 151168
            /// </summary>
            public const string I_151168_PeriodeReevaluationDecesSpecialiste = "151168";

            /// <summary>
            /// Code de retour 151442
            /// </summary>
            public const string E_151442_PeriodeReevaluationPrecedeObtnPermis = "151442";

            /// <summary>
            /// Code de retour 151459
            /// </summary>
            public const string E_151459_PeriodeReevaluationPrecedeEntente = "151459";

        }

        /// <summary>
        /// Constantes pour les types d'action possible à faire sur un avis de conformité
        /// </summary>
        public sealed class TypeActionAvisConformite
        {
            /// <summary>
            /// Constructeur privé
            /// </summary>
            private TypeActionAvisConformite() { }

            /// <summary>
            /// Traitement de type Rechercher
            /// </summary>
            public const string Rechercher = "Rechercher";

            /// <summary>
            /// Traitement de type Effacer
            /// </summary>
            public const string Effacer = "Effacer";

        }

        /// <summary>
        /// Constantes pour les statut possible d'un avis de conformité
        /// </summary>
        public sealed class StatutAvisConformite
        {
            private StatutAvisConformite() { }

            /// <summary>
            /// Statut autoriser
            /// </summary>
            public const string StatutAutoriser = "AUT";

            /// <summary>
            /// Statut annuler
            /// </summary>
            public const string StatutAnnuler = "ANN";

            /// <summary>
            /// Statut suspendu
            /// </summary>
            public const string StatutSuspendu = "SUS";

            /// <summary>
            /// Statut terminer
            /// </summary>
            public const string StatutTerminer = "TER";

            /// <summary>
            /// Statut révoquer
            /// </summary>
            public const string StatutRevoquer = "REV";
        }

        /// <summary>
        /// Constantes pour les statut possible d'une dérogation
        /// </summary>
        public sealed class StatutDerogation
        {
            /// <summary>
            /// Statut autoriser
            /// </summary>
            public const string StatutAutoriser = "AUT";

            /// <summary>
            /// Statut annuler
            /// </summary>
            public const string StatutAnnuler = "ANN";

            /// <summary>
            /// Statut terminer
            /// </summary>
            public const string StatutTerminer = "TER";
        }

        /// <summary>
        /// Constantes pour les codes de raison de statut de l'engagement
        /// </summary>
        public sealed class CodeRaisonStatutEngagement
        {
            /// <summary>
            /// 01 - Nouveau médecin débutant en pratique ou nouveau facturant
            /// </summary>
            public const string NouveauMedecinDebutantPratique = "01";
            /// <summary>
            /// 02 - Médecin déjà en pratique désirant obtenir un avis de conformité (Annexe IV)
            /// </summary>
            public const string MedecinDesirantObtenirAvisConformite = "02";

            /// <summary>
            /// 03 - Médecin déjà en pratique de retour d'un territoire éloigné après 3 ans en pratique continue (art. 3.04)
            /// </summary>
            public const string MedecinRetourTerritoireEloignerApres3Ans = "03";

            /// <summary>
            /// 04 - Médecin déjà en pratique de retour d'un territoire en pénurie d'effectif nommé à l'annexe I après 
            /// y avoir exercé 5 ans de façon continue. (art. 3.05)
            /// </summary>
            public const string MedecinRetourTerritoirePenurieEffectif = "04";

            /// <summary>
            /// 05 - Médecin déjà en pratique depuis 20 ans ou plus (art. 3.06)
            /// </summary>
            public const string MedecinDepuis20ans = "05";

            /// <summary>
            /// 06 - Suspension - exerce dans un autre territoire durant des études universitaires ou autre raison
            /// </summary>
            public const string SuspensionExerceAutreTerritoire = "06";

            /// <summary>
            /// 07 - Suspension - fin d'exercice dans le cadre du régime
            /// </summary>
            public const string SuspensionFinExercice = "07";

            /// <summary>
            /// 08 - Prolongation de la suspension pour activités reliées à l'organisation ou dispensation de services médicaux
            /// </summary>
            public const string ProlongationSuspension = "08";

            /// <summary>
            /// 09 - Maintien de l'avis pour pratique exclusive auprès d'une instance à vocation nationale
            /// </summary>
            public const string MantienAvisPratiqueExclusive = "09";

            /// <summary>
            /// 10 - Prolongation du maintien de l'avis pour pratique exclusive auprès d'une instance à vocation nationale
            /// </summary>
            public const string ProlongationMaintienAvisPratiqueExclusive = "10";

            /// <summary>
            /// 11 - Maintien de l'avis pour pratique exclusive en dépannage
            /// </summary>
            public const string MaintienAvisPratiqueExclusiveDepannage = "11";

            /// <summary>
            ///  12 - Prolongation du maintien de l'avis pour pratique exclusive en dépannage
            /// </summary>
            public const string ProlongationMaintienAvisPratiqueExlusiveDepannage = "12";

            /// <summary>
            /// 13 - Décès
            /// </summary>
            public const string Deces = "13";

            /// <summary>
            /// 14 - Nouveau spécialiste
            /// </summary>
            public const string NouveauSpecialistes = "14";

            /// <summary>
            /// 15 - Changement de territoire de pratique
            /// </summary>
            public const string ChangementTerritoirePratique = "15";

            /// <summary>
            /// 16 - Départ du territoire de pratique
            /// </summary>
            public const string DepartTerritoirePratique = "16";

            /// <summary>
            /// 17 - Désistement d'un médecin pour un avis de conformité
            /// </summary>
            public const string DesistementMedecinAvisConformite = "17";

            /// <summary>
            /// 18 - Réactivation d'un médecin pour un avis de conformité
            /// </summary>
            public const string ReactivationMedecinAvisConformite = "18";

            /// <summary>
            /// 19 - Report de la date de début d'un avis de conformité
            /// </summary>
            public const string ReportDateDebutAvisConformite = "19";

            /// <summary>
            /// 20 - Prolongation d'un avis de conformité suite au report de la date de début d'un autre avis de conformité
            /// </summary>
            public const string ProlongationAvisConformiteSuitReportDateDebut = "20";
        }

        /// <summary>
        /// Constantes pour les codes de raison de statut de la dérogation
        /// </summary>
        public sealed class CodeRaisonStatutDerogation
        {
            /// <summary>
            /// 01 - Décès
            /// </summary>
            public const string Deces = "01";

            /// <summary>
            /// 02 - Nouveau spécialiste
            /// </summary>
            public const string NouveauSpecialiste = "02";

            /// <summary>
            /// 03 - Obtention d'un nouvel avis de conformité.
            /// </summary>
            public const string NouvelAvis= "03";

            /// <summary>
            /// 04 - Obtention d'une nouvelle dérogation de type différent.
            /// </summary>
            public const string NouvelleDerogation = "04";

            /// <summary>
            /// 05 - Réactivation d’une dérogation suite à une annulation
            /// </summary>
            public const string ReactivationDerogationSuiteAnnulation = "05";

            /// <summary>
            /// 06 - Prolongation d’une dérogation suite au report de la date de début d’un avis de conformité.
            /// </summary>
            public const string ProlongationDerogationSuiteReportDateDebutAvis = "06";

        }


        /// <summary>
        /// Constantes pour les noms des paramètre de connexion oracle
        /// </summary>
        public sealed class NomParametreConnexionOracle
        {
            private NomParametreConnexionOracle() { }

            /// <summary>
            /// Code application
            /// </summary>
            public const string CodeApplication = "_strCodAppli";

            /// <summary>
            /// Numéro du message d'erreur imprévu
            /// </summary>
            public const string NumeroMessageErreurImprevu = "_strNoMsgErrImprv";

            /// <summary>
            /// Nom du fichier UDL
            /// </summary>
            public const string NomFichierUDL = "_strNomFichUdl";

        }

        /// <summary>
        /// Constantes pour les noms des paramètre de production
        /// </summary>
        public sealed class NomParametreProduction
        {
            private NomParametreProduction() { }

            /// <summary>
            /// DELA_EPURA_DEMA_REEVA 
            /// </summary>
            public const string DELA_EPURA_DEMA_REEVA = "DELA_EPURA_DEMA_REEVA";

            /// <summary>
            /// LIMIT_REEVA_AN 
            /// </summary>
            public const string LIMIT_REEVA_AN = "LIMIT_REEVA_AN";

            /// <summary>
            /// LIMIT_REEVA_TRIM 
            /// </summary>
            public const string LIMIT_REEVA_TRIM = "LIMIT_REEVA_TRIM";

            /// <summary>
            /// PROD_AN 
            /// </summary>
            public const string PROD_AN = "PROD_AN";

            /// <summary>
            /// PROD_AN_APPLI_REDUC 
            /// </summary>
            public const string PROD_AN_APPLI_REDUC = "PROD_AN_APPLI_REDUC";

            /// <summary>
            /// PROD_AN_APPLI_REDUC_REEVA 
            /// </summary>
            public const string PROD_AN_APPLI_REDUC_REEVA = "PROD_AN_APPLI_REDUC_REEVA";

            /// <summary>
            /// PROD_AN_AVIS_REDUC  
            /// </summary>
            public const string PROD_AN_AVIS_REDUC = "PROD_AN_AVIS_REDUC";

            /// <summary>
            /// PROD_TRIM 
            /// </summary>
            public const string PROD_TRIM = "PROD_TRIM";

            /// <summary>
            /// PROD_TRIM_APPLI_REDUC 
            /// </summary>
            public const string PROD_TRIM_APPLI_REDUC = "PROD_TRIM_APPLI_REDUC";

            /// <summary>
            /// PROD_TRIM_APPLI_REDUC_REEVA 
            /// </summary>
            public const string PROD_TRIM_APPLI_REDUC_REEVA = "PROD_TRIM_APPLI_REDUC_REEVA";

            /// <summary>
            /// PROD_TRIM_AVIS_REDUC  
            /// </summary>
            public const string PROD_TRIM_AVIS_REDUC = "PROD_TRIM_AVIS_REDUC";

            /// <summary>
            /// PROD_TRIM_AVIS_REDUC_REEVA 
            /// </summary>
            public const string PROD_TRIM_AVIS_REDUC_REEVA = "PROD_TRIM_AVIS_REDUC_REEVA";

            /// <summary>
            /// TYP_PROD 
            /// </summary>
            public const string TYP_PROD = "TYP_PROD";
        }

        /// <summary>
        /// Constantes pour les descriptions de type d'engagement de pratiques
        /// </summary>
        public sealed class DescriptionTypeEngagement
        {
            private DescriptionTypeEngagement() { }

            /// <summary>
            /// Avis de conformité
            /// </summary>
            public const string TypeAvisConformite = "Avis de conformité";

            /// <summary>
            /// Dérogation
            /// </summary>
            public const string TypeDerogation = "Dérogation";

            /// <summary>
            /// Autorisation
            /// </summary>
            public const string TypeAutorisation = "Autorisation";

            /// <summary>
            /// Absence d'avis
            /// </summary>
            public const string TypeAbsenceAvis = "Absence d’avis";

            /// <summary>
            /// Avis de conformité révoqué
            /// </summary>
            public const string TypeAvisRevoque = "Avis de conformité révoqué";
        }

        /// <summary>
        /// Constantes pour les descriptions de type d'engagement de pratiques
        /// </summary>
        public sealed class TypeEngagement
        {
            private TypeEngagement() { }

            /// <summary>
            /// Avis de conformité
            /// </summary>
            public const string TypeAvisConformite = "AVIS";

            /// <summary>
            /// Dérogation
            /// </summary>
            public const string TypeDerogation = "DEROG";

            /// <summary>
            /// Autorisation
            /// </summary>
            public const string TypeAutorisation = "AUT";

            /// <summary>
            /// Absence d'avis
            /// </summary>
            public const string TypeAbsenceAvis = "ABS";
        }

        /// <summary>
        /// Constantes pour les types de jours
        /// </summary>
        public sealed class TypeMontant
        {
            /// <summary>
            /// Constructeur privé
            /// </summary>
            private TypeMontant() { }

            /// <summary>
            /// Total
            /// </summary>
            public const string Total = "Total";

            /// <summary>
            /// Total Répartition pour Derogation
            /// </summary>
            public const string TotalDerog = "TotalDerog";

            /// <summary>
            /// Total Pratique Exclusive
            /// </summary>
            public const string TotalPratiqueExclusive = "TotalPratiExcl";

            /// <summary>
            /// PremDpnag
            /// </summary>
            public const string PremDpnag = "PremDpnag";

            /// <summary>
            /// PremDpnagLoc
            /// </summary>
            public const string PremDpnagLoc = "PremDpnagLoc";

            /// <summary>
            /// Prem
            /// </summary>
            public const string Prem = "Prem";

            /// <summary>
            /// Dpnag
            /// </summary>
            public const string Dpnag = "Dpnag";

            /// <summary>
            /// IVN
            /// </summary>
            public const string IVN = "IVN";

            /// <summary>
            /// HQ
            /// </summary>
            public const string HQ = "HQ";

            /// <summary>
            /// Localité
            /// </summary>
            public const string Localite = "Localité";

            /// <summary>
            /// IVN
            /// </summary>
            public const string IVNDerog = "IVNDerog";

            /// <summary>
            /// HQ
            /// </summary>
            public const string HQDerog = "HQDerog";

            /// <summary>
            /// Localité
            /// </summary>
            public const string LocaliteDerog = "LocalitéDerog";

            /// <summary>
            /// Avis
            /// </summary>
            public const string Avis = "Avis";

            /// <summary>
            /// Hors-Avis
            /// </summary>
            public const string HorsAvis = "Hors-avis";
        }

        /// <summary>
        /// Constantes pour les paramètres de production
        /// </summary>
        public sealed class IdentifiantPourcentage
        {
            /// <summary>
            /// Constructeur privé
            /// </summary>
            private IdentifiantPourcentage() { }

            /// <summary>
            /// RESPE_AVIS_PRC
            /// </summary>
            public const string RESPE_AVIS_PRC = "SEUIL_RESPE_AVIS_PLB3";

            /// <summary>
            /// RESPE_AVIS_SUSPD_PRC
            /// </summary>
            public const string RESPE_AVIS_SUSPD_PRC = "SEUIL_RESPE_SUSP_PLB3";

            /// <summary>
            /// RESPE_DEROG_PRC
            /// </summary>
            public const string RESPE_DEROG_PRC = "SEUIL_RESPE_DEROG_PLB3";

            /// <summary>
            /// RESPEC_PPR_PRC
            /// </summary>
            public const string RESPEC_PPR_PRC = "SEUIL_RESPE_RPPR_PLB3";
        }

        /// <summary>
        /// Constantes pour les numéros de séquence dans la liste des pourcentages des professionnels
        /// </summary>
        public sealed class NumeroSeqPourcentageProf
        {
            /// <summary>
            /// Constructeur privé
            /// </summary>
            private NumeroSeqPourcentageProf() { }

            /// <summary>
            /// Numéro RESPE_AVIS_PRC
            /// </summary>
            public const int RESPE_AVIS_PRC = 1;

            /// <summary>
            /// Numéro RESPE_DEROG_PRC
            /// </summary>
            public const int RESPE_DEROG_PRC = 2;

            /// <summary>
            /// Numéro RESPE_AVIS_SUSPD_PRC
            /// </summary>
            public const int RESPE_AVIS_SUSPD_PRC = 3;

            /// <summary>
            /// Numéro RESPE_PPR_PRC
            /// </summary>
            public const int RESPE_PPR_PRC = 4;
        }

        /// <summary>
        /// Constantes pour les types de totaux dans la liste de sommaire des professionnels
        /// </summary>
        public sealed class TypeTotauxSommaireProfs
        {
            /// <summary>
            /// Constructeur privé
            /// </summary>
            private TypeTotauxSommaireProfs() { }

            /// <summary>
            /// Type total RSS
            /// </summary>
            public const string RSS = "RSS";

            /// <summary>
            /// Type total Territoire
            /// </summary>
            public const string Territoire = "Terri";

            /// <summary>
            /// Type total Avis
            /// </summary>
            public const string Avis = "Avis";

            /// <summary>
            /// Type total Avis
            /// </summary>
            public const string RPPR = "RPPR";

        }

        /// <summary>
        /// Constantes pour les types de respects de pratique
        /// </summary>
        public sealed class TypeRespectEngag
        {
            /// <summary>
            /// Constructeur privé
            /// </summary>
            private TypeRespectEngag() { }

            /// <summary>
            /// RESPE_AVIS_PRC
            /// </summary>
            public const string RESPE_AVIS = "RESPE_AVIS";

            /// <summary>
            /// RESPE_AVIS_SUSPD_PRC
            /// </summary>
            public const string RESPE_AVIS_SUSPD = "RESPE_AVIS_SUSPD";

            /// <summary>
            /// RESPE_DEROG_PRC
            /// </summary>
            public const string RESPE_DEROG_DPNAG = "RESPE_DEROG_DPNAG";

            /// <summary>
            /// RESPE_DEROG_PRC
            /// </summary>
            public const string RESPE_DEROG_IVN = "RESPE_DEROG_IVN";

            /// <summary>
            /// RESPEC_PPR_PRC
            /// </summary>
            public const string RESPEC_PPR = "RESPEC_PPR";

        }

        /// <summary>
        /// DomaineValeurTypesJours
        /// </summary>
        public sealed class DomaineValeurTypesJours
        {
            /// <summary>
            /// Constructeur privé
            /// </summary>
            private DomaineValeurTypesJours() { }

            /// <summary>
            /// Prem
            /// </summary>
            public const string Prem = "01";

            /// <summary>
            /// Dpnag
            /// </summary>
            public const string Dpnag = "02";

            /// <summary>
            /// IVN
            /// </summary>
            public const string IVN = "03";

            /// <summary>
            /// HQ
            /// </summary>
            public const string HQ = "04";

            /// <summary>
            /// Localité
            /// </summary>
            public const string Localite = "05";

            /// <summary>
            /// Avis
            /// </summary>
            public const string Avis = "Avis";

            /// <summary>
            /// Hors-Avis
            /// </summary>
            public const string HorsAvis = "Hors-avis";

            /// <summary>
            /// PremDpnag
            /// </summary>
            public const string PremDpnag = "PREMDPNAG";

            /// <summary>
            /// PremDpnagLoc
            /// </summary>
            public const string PremDpnagLoc = "PREMDPNAGLOC";

            /// <summary>
            /// PremDpnagLoc
            /// </summary>
            public const string TotalPratiExcl = "TOTALPRATIEXCL";
            
        }

        /// <summary>
        /// Type de dérogation
        /// </summary>
        public sealed class TypeDerogation
        {
            /// <summary>
            /// Type de dérogation en dépannage
            /// </summary>
            public const string Depannage = "DPN";

            /// <summary>
            /// Type de dérogation en instance à vocation national
            /// </summary>
            public const string InstanceVocationNational = "IVN";

        }

    }

}

