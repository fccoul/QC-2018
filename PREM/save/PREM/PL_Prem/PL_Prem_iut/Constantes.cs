namespace RAMQ.PRE.PL_Prem_iut
{

    /// <summary> 
    ///  Classe de constantes
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Octobre 2016
    /// </remarks>
    public sealed class Constantes
    {
        private Constantes() { }
        
        /// <summary>
        /// Nom des colonne du tableau des engagements de pratique
        /// </summary>
        public const string NomColonneTableauEngagementPratique = "Période;Statut;Raison du statut;Nombre de jours selon l'engagement;Total des jours admissibles;Pourcentage effectué";

        /// <summary>
        /// Nom des rangées du tableau de pratique exclusive
        /// </summary>
        public const string NomRangeeTableauPratiqueExclusive = "Mars;Avril;Mai;Juin;Juillet;Août;Septembre;Octobre;Novembre;Décembre;Janvier;Février";

        /// <summary>
        /// Clé pour le nombre d'avis en attente
        /// </summary>
        public const string CleNombreAvisAttente = "NombreAvisEnAttente";

        /// <summary>
        /// Clé pour les messages d'erreur de la page d'erreur
        /// </summary>
        public const string CleMessagesErreur = "MessagesErreur";

        /// <summary>
        /// Classe listant les constantes en lien au Type de profil
        /// </summary>
        public class TypeProfil
        {
            /// <summary>
            /// Type DRMG
            /// </summary>
            public const string DRMG = "DRMG";

            /// <summary>
            /// Type Comité paritaire
            /// </summary>
            public const string ComiteParitaire = "Comité paritaire";
        }

        /// <summary>
        /// Classe listant les constantes en lien au Type de profil
        /// </summary>
        public class ZoneExec
        {
            /// <summary>
            /// Clée du machine.config contenant la zone d'exécution
            /// </summary>
            public const string CleZoneExec = "ZoneExec";

            /// <summary>
            /// Valeur de la zone d'exécution de présentation externe
            /// </summary>
            public const string ZoneExecPrsenXtrnt = "PrsenXtrnt";

            /// <summary>
            /// Valeur de la zone d'exécution de présentation interne
            /// </summary>
            public const string ZoneExecPrsenNtrnt = "PrsenNtrnt";

        }

        internal sealed class NomAction
        {
            private NomAction() { }

            internal sealed class PLA1
            {
                private PLA1() { }

                internal const string Transmettre = "PLA1_Transmettre";
                internal const string Enregistrer = "PLA1_Enregistrer";
                internal const string Confirmation = "PLA1_Confirmation";
                internal const string Modifier = "PLA1_Modifier";
                internal const string ModifierAttente = "PLA1_ModifierAttente";
                internal const string Attente = "PLA1_Attente";
                internal const string ValidationAvisEnCours = "PLA1_ValidationAvisEnCours";
            }

            internal sealed class PLA2
            {
                private PLA2() { }

                internal const string TransmettreDerogation = "PLA2_TransmettreDerogation";
                internal const string ConfirmationDerogation = "PLA2_ConfirmationDerogation";
                internal const string AjouterModifierAnnulerSuspension = "PLA2_AjouterModifierAnnulerSuspension";
                internal const string AnnulerDerogation = "PLA2_AnnulerDerogation";
                internal const string ConfirmationSuspension = "PLA2_ConfirmationSuspension";
                internal const string GererSuspension = "PLA2_GererSuspension";
            }

            internal sealed class PLA5
            {
                private PLA5() { }

                internal const string AjouterAutorisation = "PLA5_AjouterAutorisation";
            }


            internal sealed class PLC1
            {
                private PLC1() { }

                internal const string RapportAbsenceAvis = "PLC1_AbsenceAvis";
                internal const string RapportAvisConfActifsParTerri = "PLC1_AvisConfActifsParTerri";
                internal const string RapportAvisConfTermines = "PLC1_AvisConfTermines";
                internal const string RapportDerogPratiExclu = "PLC1_DerogPratiExclu";
                internal const string RapportNonRespectAvisConf = "PLC1_NonRespectAvisConf";
                internal const string RapportExerNonAutoRPPR = "PLC1_ExerNonAutoRPPR";
                internal const string RapportNouvMedSansAvisConf = "PLC1_NouvMedSansAvisConf";
                internal const string RapportRepartInterRegionPrati = "PLC1_RepartInterRegionPrati";
                internal const string RapportObtenirTerritoires = "ObtenirTerritoires";

                internal const string RapportPdf = "_Pdf";
                internal const string RapportXml = "_Xml";

                internal const int AnneeDebutRapportsPREM = 2004;
            }

            internal sealed class PLA9
            {
                private PLA9() { }

                internal const string Accueil = "PLA9_Accueil";
            }

        }

        internal sealed class NomControlleur
        {
            private NomControlleur() { }

            internal const string AvisConformite = "AvisConformite";
            internal const string DecisionAvisConformite = "DecisionAvisConformite";
            internal const string Autorisation = "Autorisation";
            internal const string Accueil = "Accueil";
            internal const string ProfilProfessionnel = "ProfilProfessionnel";
        }

        internal sealed class MessageErreur
        {
            private MessageErreur() { }

            internal const string ChampObligatoire = "Le champs est obligatoire.";
        }
    }
}