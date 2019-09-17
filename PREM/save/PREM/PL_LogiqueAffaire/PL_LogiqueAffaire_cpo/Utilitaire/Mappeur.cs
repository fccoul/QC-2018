using RAMQ.Message;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Parametres;
using RAMQ.PRE.PRE_Entites_cpo.DemandeReevaluation.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Entite;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using System.Collections.Generic;
using System.Linq;
using AccesDonneParametre = RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre;
using entiteAbsenceAvis = RAMQ.PRE.PRE_Entites_cpo.AbsencesAvis.Entite;
using entiteAvisConformite = RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Entite;
using entitePlanRegnMdcal = RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Entite;
using OutilsCommun = RAMQ.PRE.PRE_OutilComun_cpo;
using parametreAbsenceAvis = RAMQ.PRE.PRE_Entites_cpo.AbsencesAvis.Parametre;
using parametreAvisConformite = RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre;
using parametreDerogation = RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre;
using parametreEPZ3 = RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3.Parametre;
using parametrePlanRegnMdcal = RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre;
using parametreRapport = RAMQ.PRE.PRE_Entites_cpo.Rapport.Parametre;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.Utilitaire
{
    /// <summary> 
    ///  Mappeur
    /// </summary>
    /// <remarks>
    ///  Auteur : Florent Pollart <br/>
    ///  Date   : Janvier 2017
    /// </remarks>
    internal class Mappeur
    {
        #region Avis de conformité

        /// <summary>
        ///  Map un objet PRE_Entites_cpo.AvisConformite.Parametre.ObtenirLesAvisConformiteEntre en PlanRegnMdcal.Parametre.ObtenirLesAvisConformiteEntre
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
#pragma warning disable RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        static internal void Mapper(parametreAvisConformite.ObtenirLesAvisConformiteEntre source,
                                    ref parametrePlanRegnMdcal.ObtenirLesAvisConformiteEntre cible)
#pragma warning restore RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        {
            cible.CodeRegion = source.CodeRegion;
            cible.DateDebut = source.DateDebut;
            cible.DateFin = source.DateFin;
            cible.DateRecherche = source.DateRecherche;
            cible.IndicateurAttenteTransmission = source.IndicateurAttenteTransmission;
            cible.IndicateurAvisInactive = source.IndicateurAvisInactive;
            cible.NumeroSequentielDispensateur = source.NumeroSequentielDispensateur;
            cible.NumeroSequentielEngagement = source.NumeroSequentielEngagement;
            cible.Tri = source.Tri;
        }

        /// <summary>
        ///  Map un objet PlanRegnMdcal.Parametre.ObtenirLesAvisConformiteSorti en PRE_Entites_cpo.AvisConformite.Parametre.ObtenirLesAvisConformiteSorti
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
#pragma warning disable RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        static internal void Mapper(parametrePlanRegnMdcal.ObtenirLesAvisConformiteSorti source,
                                    ref parametreAvisConformite.ObtenirLesAvisConformiteSorti cible)
#pragma warning restore RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        {
           entiteAvisConformite.AvisConformite avisCible = new entiteAvisConformite.AvisConformite();
            entiteAvisConformite.StatutAvisConformite statutCible = new entiteAvisConformite.StatutAvisConformite();

            cible.InfoMsgTrait = source.InfoMsgTrait;

            foreach (entitePlanRegnMdcal.AvisConformite avis in source.ListeAvisConformite)
            {
                avisCible = new entiteAvisConformite.AvisConformite
                {
                    CodeLieuGeographique = avis.CodeLieuGeographique,
                    CodeRegion = avis.CodeRegion,
                    DateDebutEngagement = avis.DateDebutEngagement,
                    DateFinEngagement = avis.DateFinEngagement,
                    DateHeureOccurence = avis.DateHeureOccurence,
                    DateHeureOccurenceInactive = avis.DateHeureOccurenceInactive,
                    DateHeureOccurenceMAJ = avis.DateHeureOccurenceMAJ,
                    IdentifiantCreation = avis.IdentifiantCreation,
                    IdentifiantMAJ = avis.IdentifiantMAJ,
                    NumeroSequentielDispensateur = avis.NumeroSequentielDispensateur,
                    NumeroSequentielEngagement = avis.NumeroSequentielEngagement,
                    NumeroSequentielRegroupement = avis.NumeroSequentielRegroupement,
                    TypeLieuGeographique = avis.TypeLieuGeographique
                };

                foreach (entitePlanRegnMdcal.StatutAvisConformite statut in source.ListeStatutAvisConformite)
                {
                    if (statut.NumeroSequentielEngagement == avis.NumeroSequentielEngagement)
                    {
                        statutCible = new entiteAvisConformite.StatutAvisConformite
                        {
                            DateDebutStatutEngagement = statut.DateDebutStatutEngagement,
                            DateFinStatutEngagement = statut.DateFinStatutEngagement,
                            DateHeureOccurence = statut.DateHeureOccurence,
                            DateHeureOccurenceInactive = statut.DateHeureOccurenceInactive,
                            DateHeureOccurenceMAJ = statut.DateHeureOccurenceMAJ,
                            IdentifiantCreation = statut.IdentifiantCreation,
                            IdentifiantMAJ = statut.IdentifiantMAJ,
                            IndicateurStatutEngagementAttente = statut.IndicateurStatutEngagementAttente,
                            NumeroSequentielEngagement = statut.NumeroSequentielEngagement,
                            NumeroSequentielStatutEngagement = statut.NumeroSequentielStatutEngagement,
                            StatutEngagement = statut.StatutEngagement
                        };

                        // S'assure que le code de raison de statut respect 2 caractère ex : "02" et non "2"
                        if (!string.IsNullOrEmpty(statut.CodeRaisonStatutEngagement))
                        {
                            statutCible.CodeRaisonStatutEngagement = statut.CodeRaisonStatutEngagement.PadLeft(2, char.Parse("0"));
                        }
                        else
                        {
                            statutCible.CodeRaisonStatutEngagement = statut.CodeRaisonStatutEngagement;
                        }

                        avisCible.ListeStatutAvisConformite.Add(statutCible);
                    }
                }

                cible.ListeAvisConformite.Add(avisCible);
            }
        }

        /// <summary>
        ///  Map un objet PRE_Entites_cpo.AvisConformite.Parametre.ModifierPeriodeAvisEntre
        ///  en PlanRegnMdcal.Parametre.ModifierPeriodeAvisEntre
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
        public static parametrePlanRegnMdcal.ModifierPeriodeAvisEntre Mapper(parametreAvisConformite.ModifierPeriodeAvisEntre source)
        {
            parametrePlanRegnMdcal.ModifierPeriodeAvisEntre cible = new parametrePlanRegnMdcal.ModifierPeriodeAvisEntre();

            cible.CodeRaisonStatut = source.CodeRaisonStatut;
            cible.DateDebutActuelle = source.DateDebutActuelle;
            cible.DateDebutNouvelle = source.DateDebutNouvelle;
            cible.DateFinActuelle = source.DateFinActuelle;
            cible.DateFinNouvelle = source.DateFinNouvelle;
            cible.IdentifiantMAJ = source.IdentifiantMAJ;
            cible.NumeroSequentielEngagement = source.NumeroSequentielEngagement;

            return cible;
        }


        /// <summary>
        ///  Map un objet PlanRegnMdcal.Parametre.ModifierPeriodeAvisSorti en PRE_Entites_cpo.AvisConformite.Parametre.ModifierPeriodeAvisSorti.
        /// </summary>
        /// <Parametre name="source">Objet source.</Parametre>
        /// <Parametre name="cible">Objet cible.</Parametre>
        /// <remarks></remarks>
        public static parametreAvisConformite.ModifierPeriodeAvisSorti Mapper(parametrePlanRegnMdcal.ModifierPeriodeAvisSorti source)
        {
            parametreAvisConformite.ModifierPeriodeAvisSorti cible = new parametreAvisConformite.ModifierPeriodeAvisSorti();

            cible.DateHeureOccurence = source.DateHeureOccurence;
            cible.InfoMsgTrait = source.InfoMsgTrait;

            return cible;
        }

        /// <summary>
        ///  Map un objet PRE_Entites_cpo.AvisConformite.Parametre.ModifierAvisConfEntre
        ///  en PlanRegnMdcal.Parametre.ModifierAvisConformiteEntre
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
        public static parametrePlanRegnMdcal.ModifierAvisConformiteEntre Mapper(parametreAvisConformite.ModifierAvisConfEntre source)
        {
            parametrePlanRegnMdcal.ModifierAvisConformiteEntre cible = new parametrePlanRegnMdcal.ModifierAvisConformiteEntre();

            cible.NumeroSequentielEngagement = source.NumeroSequentielEngagement;
            cible.NumeroSequentielDispensateur = source.NumeroSequentielDispensateur;
            cible.IdentifiantMAJ = source.IdentifiantMAJ;
            cible.TypeLieuGeographique = source.TypeLieuGeographique;
            cible.CodeLieuGeographique = source.CodeLieuGeographique;
            cible.NumeroSequentielRegroupement = source.NumeroSequentielDispensateur;
            cible.CodeRSS = source.CodeRSS;
            cible.DateDebut = source.DateDebut;
            cible.DateFin = source.DateFin;

            return cible;
        }

        /// <summary>
        ///  Map un objet PlanRegnMdcal.Parametre.ModifierAvisConformiteSorti en PRE_Entites_cpo.AvisConformite.Parametre.ModifierAvisConfSorti.
        /// </summary>
        /// <Parametre name="source">Objet source.</Parametre>
        /// <Parametre name="cible">Objet cible.</Parametre>
        /// <remarks></remarks>
        public static parametreAvisConformite.ModifierAvisConfSorti Mapper(parametrePlanRegnMdcal.ModifierAvisConformiteSorti source)
        {
            parametreAvisConformite.ModifierAvisConfSorti cible = new parametreAvisConformite.ModifierAvisConfSorti();

            cible.DateHeureOccurence = source.DateHeureOccurence;
            cible.InfoMsgTrait = source.InfoMsgTrait;

            return cible;
        }

        
        ///  Map un objet PlanRegnMdcal.Parametre.CreerAvisConformiteSorti en PRE_Entites_cpo.AvisConformite.Parametre.CreerAvisConformiteSorti.
        /// </summary>
        /// <Parametre name="source">Objet source.</Parametre>
        /// <Parametre name="cible">Objet cible.</Parametre>
        /// <remarks></remarks>
        public static parametreAvisConformite.CreerAvisConformiteSorti Mapper(parametrePlanRegnMdcal.CreerAvisConformiteSorti source)
        {
            parametreAvisConformite.CreerAvisConformiteSorti cible = new parametreAvisConformite.CreerAvisConformiteSorti();

            cible.DateHeureOccurence = source.DateHeureOccurence;
            cible.NumeroSequentielEngagement = source.NumeroSequentielEngagement;
            cible.InfoMsgTrait = source.InfoMsgTrait;

            return cible;
        }

        /// <summary>
        ///  Map un objet PRE_Entites_cpo.AvisConformite.Parametre.CreerAvisConformiteEntre
        ///  en PlanRegnMdcal.Parametre.CreerAvisConformiteEntre
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
        public static parametrePlanRegnMdcal.CreerAvisConformiteEntre Mapper(parametreAvisConformite.CreerAvisConformiteEntre source)
        {
            parametrePlanRegnMdcal.CreerAvisConformiteEntre cible = new parametrePlanRegnMdcal.CreerAvisConformiteEntre();

            cible.NumeroSequentielDispensateur = source.NumeroSequentielDispensateur;
            cible.CodeRegion = source.CodeRegion;
            cible.DateDebutEngagement = source.DateDebutEngagement;
            cible.DateFinEngagement = source.DateFinEngagement;
            cible.IdentifiantCreation = source.IdentifiantCreation;
            cible.TypeLieuGeographique = source.TypeLieuGeographique;
            cible.CodeLieuGeographique = source.CodeLieuGeographique;             
            cible.NumeroSequentielRegroupement = source.NumeroSequentielRegroupement;
            cible.StatutEngagement = source.StatutEngagement;
            cible.IndicateurStatutEngagementAttente = source.IndicateurStatutEngagementAttente;
            cible.CodeRaisonStatutEngagement = source.CodeRaisonStatutEngagement;

            return cible;
        }
       

        /// <summary>
        ///  Map un objet PRE_Entites_cpo.AvisConformite.Parametre.ModifierAvisConformiteStatutEntre
        ///  en PlanRegnMdcal.Parametre.ModifierAvisConformiteStatutEntre
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
        public static parametrePlanRegnMdcal.ModifierAvisConformiteStatutEntre Mapper(parametreAvisConformite.ModifierAvisConformiteStatutEntre source)
        {
            parametrePlanRegnMdcal.ModifierAvisConformiteStatutEntre cible = new parametrePlanRegnMdcal.ModifierAvisConformiteStatutEntre();

            cible.NumeroSequentielEngagement = source.NumeroSequentielEngagement;
            cible.NumeroSequentielDispensateur = source.NumeroSequentielDispensateur;
            cible.IdentifiantMAJ = source.IdentifiantMAJ;
            cible.TypeLieuGeographique = source.TypeLieuGeographique;
            cible.CodeLieuGeographique = source.CodeLieuGeographique;
            cible.NumeroSequentielRegroupement = source.NumeroSequentielDispensateur;
            cible.IndicateurInactivationOccurence = source.IndicateurInactivationOccurence;
            
            return cible;
        }
        /// <summary>
        ///  Map un objet PlanRegnMdcal.Parametre.ModifierAvisConformiteStatutSorti en PRE_Entites_cpo.AvisConformite.Parametre.ModifierAvisConformiteStatutSorti.
        /// </summary>
        /// <Parametre name="source">Objet source.</Parametre>
        /// <Parametre name="cible">Objet cible.</Parametre>
        /// <remarks></remarks>
        public static parametreAvisConformite.ModifierAvisConformiteStatutSorti Mapper(parametrePlanRegnMdcal.ModifierAvisConformiteStatutSorti source)
        {
            parametreAvisConformite.ModifierAvisConformiteStatutSorti cible = new parametreAvisConformite.ModifierAvisConformiteStatutSorti();

            cible.DateHeureOccurence = source.DateHeureOccurence;             
            foreach (var item in source.InfoMsgTrait)
            {
                var msgTrait = new MsgTrait
                {
                    CodAppli = item.CodAppli,
                    IdMsg = item.CodSever,
                    TxtMsgAngl = item.TxtMsgAngl,
                    TxtMsgFran = item.TxtMsgFran
                };
                cible.InfoMsgTrait.Add(msgTrait);
            }

            return cible;
        }

        //-------------
        /// <summary>
        ///  Map un objet PRE_Entites_cpo.AvisConformite.Parametre.ObtenirStatutsEngagementPratiqueRSSEntre
        ///  en PlanRegnMdcal.Parametre.ObtenirStatutsEngagementPratiqueRSSEntre
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
        public static parametrePlanRegnMdcal.ObtenirStatutsEngagementPratiqueRSSEntre Mapper(parametreAvisConformite.ObtenirStatutsEngagementPratiqueRSSEntre source)
        {
            parametrePlanRegnMdcal.ObtenirStatutsEngagementPratiqueRSSEntre cible = new parametrePlanRegnMdcal.ObtenirStatutsEngagementPratiqueRSSEntre {

                NumeroSequentielStatutEngagement = source.NumeroSequentielStatutEngagement,
            NumeroSequentielEngagement = source.NumeroSequentielEngagement,
            CodeRaisonEngagement = source.CodeRaisonEngagement,
            StatutEngagementTerritoire = source.StatutEngagementTerritoire,
            DateDebutStatutEngagementTerritoire = source.DateDebutStatutEngagementTerritoire,
            DateFinStatutEngagementTerritoire = source.DateFinStatutEngagementTerritoire
        };
            return cible;
        }

        /// <summary>
        ///  Map un objet PlanRegnMdcal.Parametre.ModifierAvisConformiteStatutSorti en PRE_Entites_cpo.AvisConformite.Parametre.ModifierAvisConformiteStatutSorti.
        /// </summary>
        /// <Parametre name="source">Objet source.</Parametre>
        /// <Parametre name="cible">Objet cible.</Parametre>
        /// <remarks></remarks>
        public static parametreAvisConformite.ObtenirStatutsEngagementPratiqueRSSSorti Mapper(parametrePlanRegnMdcal.ObtenirStatutsEngagementPratiqueRSSSorti source)
        {
            parametreAvisConformite.ObtenirStatutsEngagementPratiqueRSSSorti cible = new parametreAvisConformite.ObtenirStatutsEngagementPratiqueRSSSorti();

            List<parametreAvisConformite.StatutEngagementPratiqueRSS> lstItem = new List<parametreAvisConformite.StatutEngagementPratiqueRSS>();
            foreach (var item in source.ListeStatutEngagementPratiqueRSS)
            {
                var statut = new parametreAvisConformite.StatutEngagementPratiqueRSS();
                statut.NumeroSequentielDispensateur = item.NumeroSequentielDispensateur;
                statut.CodeRegion = item.CodeRegion;
                statut.DateDebutEngagement = item.DateDebutEngagement;
                statut.DateFinEngagement = item.DateFinEngagement;
                statut.TypeLieuGeographique = item.TypeLieuGeographique;
                statut.CodeLieuGeographique = item.CodeLieuGeographique;
                statut.NumeroSequentielRegroupement = item.NumeroSequentielRegroupement;
                statut.NumeroSequentielStatutEngagement = item.NumeroSequentielStatutEngagement;
                statut.NumeroSequentielEngagement = item.NumeroSequentielEngagement;
                statut.StatutEngagement = item.StatutEngagement;
                statut.IndicateurStatutEngagementAttente = item.IndicateurStatutEngagementAttente;
                statut.DateHeureOccurence = item.DateHeureOccurence;
                statut.IdentifiantCreation = item.IdentifiantCreation;
                statut.DateDebutStatutEngagement = item.DateDebutStatutEngagement;
                statut.CodeRaisonStatutEngagement = item.CodeRaisonStatutEngagement;
                statut.DateFinStatutEngagement = item.DateFinStatutEngagement;
                statut.DateHeureOccurenceMAJ = item.DateHeureOccurenceMAJ;
                statut.IdentifiantMAJ = item.IdentifiantMAJ;
                statut.DateHeureOccurenceInactive = item.DateHeureOccurenceInactive;

                lstItem.Add(statut);
                 

            }
            cible.ListeStatutEngagementPratiqueRSS=lstItem;

            foreach (var item in source.InfoMsgTrait)
            {
                var msgTrait = new MsgTrait
                {
                    CodAppli = item.CodAppli,
                    IdMsg = item.CodSever,
                    TxtMsgAngl = item.TxtMsgAngl,
                    TxtMsgFran = item.TxtMsgFran
                };
                cible.InfoMsgTrait.Add(msgTrait);
            }

            return cible;
        }
      

        /// <summary>
        ///  Map un objet PRE_Entites_cpo.AvisConformite.Parametre.CreerStatutAvisConformiteEntre en PlanRegnMdcal.Parametre.CreerStatutAvisConformiteEntre
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
#pragma warning disable RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        public static void Mapper(PRE_Entites_cpo.AvisConformite.Parametre.CreerStatutAvisConformiteEntre source,
                                  ref PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.CreerStatutAvisConformiteEntre cible)
#pragma warning restore RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        {
            cible.CodeRaisonStatutEngagement = source.CodeRaisonStatutEngagement;
            cible.DateDebutStatutEngagement = source.DateDebutStatutEngagement;
            cible.DateFinStatutEngagement = source.DateFinStatutEngagement;
            cible.IdentifiantCreation = source.IdentifiantCreation;
            cible.NumeroSequentielEngagement = source.NumeroSequentielEngagement;
            cible.StatutEngagement = source.StatutEngagement;
        }


        /// <summary>
        ///  Map un objet PlanRegnMdcal.Parametre.CreerStatutAvisConformiteSorti en PRE_Entites_cpo.AvisConformite.Parametre.CreerStatutAvisConformiteSorti
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
#pragma warning disable RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        public static void Mapper(PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.CreerStatutAvisConformiteSorti source,
                                  ref PRE_Entites_cpo.AvisConformite.Parametre.CreerStatutAvisConformiteSorti cible)
#pragma warning restore RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        {
            cible.DateHeureOccurence = source.DateHeureOccurence;
            cible.InfoMsgTrait = source.InfoMsgTrait;
            cible.NumeroSequentielStatutEngagement = source.NumeroSequentielStatutEngagement;
        }

        /// <summary>
        ///  Map un objet PRE_Entites_cpo.AvisConformite.Parametre.ModifierStatutAvisConformiteEntre en PlanRegnMdcal.Parametre.ModifierStatutAvisConformiteEntre
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
#pragma warning disable RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        public static void Mapper(PRE_Entites_cpo.AvisConformite.Parametre.ModifierStatutEngagementEntre source,
                                  ref PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ModifierStatutEngagementEntre cible)
#pragma warning restore RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        {
            cible.IdentifiantMAJ = source.IdentifiantMAJ;
            cible.DateFinStatutEngagement = source.DateFinStatutEngagement;
            cible.NumeroSequentielEngagement = source.NumeroSequentielEngagement;
            cible.IndicateurStatutEngagementEnAttente = source.IndicateurStatutEngagementEnAttente;
            cible.NumeroSequentielStatutEngagement = source.NumeroSequentielStatutEngagement;
            cible.IndicateurInactivationStatut = source.IndicateurInactivationStatut;
        }

        /// <summary>
        ///  Map un objet PlanRegnMdcal.Parametre.ModifierAvisConformiteStatutSorti en PRE_Entites_cpo.AvisConformite.Parametre.ModifierAvisConformiteSorti
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
#pragma warning disable RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        public static void Mapper(PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ModifierStatutEngagementSorti source,
                                  ref PRE_Entites_cpo.AvisConformite.Parametre.ModifierStatutEngagementSorti cible)
#pragma warning restore RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        {
            cible.DateHeureOccurence = source.DateHeureOccurence;
            cible.NumeroSequentielStatutEngagement = source.NumeroSequentielStatutEngagement;
            cible.InfoMsgTrait = source.InfoMsgTrait;
        }



        /// <summary>
        ///  Map un objet PRE_Entites_cpo.AvisConformite.Parametre.ModifierRaisFermStatutEngagEntre
        ///  en PlanRegnMdcal.Parametre.ModifierRaisFermStatutEngagEntre
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
        public static parametrePlanRegnMdcal.ModifierRaisFermStatutEngagEntre Mapper(parametreAvisConformite.ModifierRaisFermStatutEngagEntre source)
        {
            parametrePlanRegnMdcal.ModifierRaisFermStatutEngagEntre cible = new parametrePlanRegnMdcal.ModifierRaisFermStatutEngagEntre();        
     
            cible.IdentifiantMAJ = source.IdentifiantMAJ;
            cible.NumeroSequentielStatutEngagement = source.NumeroSequentielStatutEngagement;
            cible.CodeRaisonStatut = source.CodeRaisonStatut;
 

            return cible;
        }


        /// <summary>
        ///  Map un objet PlanRegnMdcal.Parametre.ModifierRaisFermStatutEngagSorti en PRE_Entites_cpo.AvisConformite.Parametre.ModifierRaisFermStatutEngagSorti.
        /// </summary>
        /// <Parametre name="source">Objet source.</Parametre>
        /// <Parametre name="cible">Objet cible.</Parametre>
        /// <remarks></remarks>
        public static parametreAvisConformite.ModifierRaisFermStatutEngagSorti Mapper(parametrePlanRegnMdcal.ModifierRaisFermStatutEngagSorti source)
        {
            parametreAvisConformite.ModifierRaisFermStatutEngagSorti cible = new parametreAvisConformite.ModifierRaisFermStatutEngagSorti();

            cible.DateHeureOccurence = source.DateHeureOccurence;
            cible.InfoMsgTrait = source.InfoMsgTrait;

            return cible;
        }

        #endregion

        #region Dérogation

        /// <summary>
        ///  Map un objet PRE_Entites_cpo.Derogation.Parametre.ObtenirDerogationsProfessionnelSanteEntre en ObtenirLesDerogationsProfessionnelSanteEntre
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
#pragma warning disable RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        static internal void Mapper(PRE_Entites_cpo.Derogation.Parametre.ObtenirDerogationsProfessionnelSanteEntre source,
                                    ref parametrePlanRegnMdcal.ObtenirDerogationsProfessionnelSanteEntre cible)
#pragma warning restore RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        {
            if (cible == null)
            {
                cible = new parametrePlanRegnMdcal.ObtenirDerogationsProfessionnelSanteEntre();
            }

            cible.DateDebut = source.DateDebut;
            cible.DateFin = source.DateFin;
            cible.DateRecherche = source.DateRecherche;
            cible.IndicateurDerogationInactive = source.IndicateurDerogationInactive;
            cible.NumeroSequentielDispensateur = source.NumeroSequentielDispensateur;
            cible.Tri = source.Tri;
        }

        /// <summary>
        ///  Map un objet ObtenirLesDerogationsProfessionnelSanteSorti en PRE_Entites_cpo.Derogation.Parametre.ObtenirDerogationsProfessionnelSanteSorti
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>

#pragma warning disable RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        static internal void Mapper(parametrePlanRegnMdcal.ObtenirDerogationsProfessionnelSanteSorti source,
                                    ref PRE_Entites_cpo.Derogation.Parametre.ObtenirDerogationsProfessionnelSanteSorti cible)
#pragma warning restore RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        {
            if (cible == null)
            {
                cible = new PRE_Entites_cpo.Derogation.Parametre.ObtenirDerogationsProfessionnelSanteSorti();
            }

            cible.InfoMsgTrait = new List<MsgTrait>(source.InfoMsgTrait);
            cible.Derogations = new List<PRE_Entites_cpo.Derogation.Entite.Derogation>(from derogation in source.Derogations
                                                                                       select new PRE_Entites_cpo.Derogation.Entite.Derogation
                                                                                       {
                                                                                           CodeRaisonStatut = derogation.CodeRaisonStatut,
                                                                                           DateDebut = derogation.DateDebut,
                                                                                           DateFin = derogation.DateFin,
                                                                                           DateHeureCreationOccurence = derogation.DateHeureCreationOccurence,
                                                                                           DateHeureInactivationOccurence = derogation.DateHeureInactivationOccurence,
                                                                                           DateRenouvellement = derogation.DateRenouvellement,
                                                                                           IdentifiantCreationOccurence = derogation.IdentifiantCreationOccurence,
                                                                                           IdentifiantInactivationOccurence = derogation.IdentifiantInactivationOccurence,
                                                                                           NumeroSequentiel = derogation.NumeroSequentiel,
                                                                                           Statut = derogation.Statut,
                                                                                           Type = derogation.Type
                                                                                       });

        }

        /// <summary>
        ///  Map un objet PRE_Entites_cpo.Derogation.Parametre.ModifierDerogationEntre
        ///  en ModifierDerogationEntre
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>

#pragma warning disable RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        static internal void Mapper(PRE_Entites_cpo.Derogation.Parametre.ModifierDerogationEntre source, 
                                    ref parametrePlanRegnMdcal.ModifierDerogationEntre cible)
#pragma warning restore RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        {
            if (cible == null)
            {
                cible = new parametrePlanRegnMdcal.ModifierDerogationEntre();
            }

            cible.CodeRaisonStatut = source.CodeRaisonStatut;
            cible.DateDebut = source.DateDebut;
            cible.DateFin = source.DateFin;
            cible.DateRenouvellement = source.DateRenouvellement;
            cible.IdentifiantMAJ = source.IdentifiantMAJ;
            cible.NumeroSequentiel = source.NumeroSequentiel;
            cible.NumeroSequentielDispensateur = source.NumeroSequentielDispensateur;
            cible.Statut = source.Statut;
            cible.Type = source.Type;

        }

        /// <summary>
        ///  Map un objet ModifierDerogationSorti
        ///  en PRE_Entites_cpo.Derogation.Parametre.ModifierDerogationSorti
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
#pragma warning disable RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        static internal void Mapper(parametrePlanRegnMdcal.ModifierDerogationSorti source, ref PRE_Entites_cpo.Derogation.Parametre.ModifierDerogationSorti cible)
#pragma warning restore RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        {
            if (cible == null)
            {
                cible = new PRE_Entites_cpo.Derogation.Parametre.ModifierDerogationSorti();
            }

            cible.InfoMsgTrait = new List<Message.MsgTrait>(
                from informationMessageTrait in source.InfoMsgTrait
                select OutilsCommun.MessageTraitement.MapperVersMessageTraitement(informationMessageTrait));

            cible.NouveauNumeroSequentiel = source.NouveauNumeroSequentiel;
        }

        /// <summary>
        ///  Map un objet PRE_Entites_cpo.Derogation.Parametre.ModifierDerogationEntre
        ///  en ModifierDerogationEntre
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
        static internal parametrePlanRegnMdcal.CreerDerogationEntre Mapper(parametreDerogation.CreerDerogationEntre source)
        {
            parametrePlanRegnMdcal.CreerDerogationEntre cible = new parametrePlanRegnMdcal.CreerDerogationEntre();

            cible.NumeroSequentielDispensateur = source.NumeroSequentielDispensateur;
            cible.Type = source.Type;
            cible.CodeRaisonStatutDerogation = source.CodeRaisonStatutDerogation;
            cible.DateDebut = source.DateDebut;
            cible.IdentifiantCreation = source.IdentifiantCreation;

            return cible;
        }

        /// <summary>
        ///  Map un objet ModifierDerogationSorti
        ///  en PRE_Entites_cpo.Derogation.Parametre.ModifierDerogationSorti
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
        static internal parametreDerogation.CreerDerogationSorti Mapper(parametrePlanRegnMdcal.CreerDerogationSorti source)
        {
            parametreDerogation.CreerDerogationSorti cible = new parametreDerogation.CreerDerogationSorti();

            cible.InfoMsgTrait = new List<Message.MsgTrait>(
                from informationMessageTrait in source.InfoMsgTrait
                select OutilsCommun.MessageTraitement.MapperVersMessageTraitement(informationMessageTrait));

            cible.NumeroSequentielDerogation = source.NumeroSequentielDerogation;
            cible.DateHeureCreationOccurence = source.DateHeureCreationOccurence;

            return cible;
        }

        #endregion

        #region Professionnel

        /// <summary>
        ///  Map un objet Professionnel.Parametre.ObtenirDispensateurIndividuEntre en FIP.EPZ3.Parametre.ObtnRelDispIndivEntre
        /// </summary>
        /// <Parametre name="parametreEntre">Objet source</Parametre>
        /// <remarks></remarks>
        static internal parametreEPZ3.ObtnRelDispIndivEntre Mapper(ObtenirDispensateurIndividuEntre intrant)
        {
            var intrantEZP3 = new parametreEPZ3.ObtnRelDispIndivEntre();
            intrantEZP3.DateService = intrant.DateService;
            intrantEZP3.NumeroClasseDispensateur = intrant.NumeroClasseDispensateur;
            intrantEZP3.NumeroDispensateur = intrant.NumeroDispensateur;
            intrantEZP3.NumeroSequentielDispensateur = intrant.NumeroSequentielDispensateur;
            intrantEZP3.NumeroSequentielIndividu = intrant.NumeroSequentielIndividu;

            return intrantEZP3;
        }

        /// <summary>
        ///  Map un objet FIP.EPZ3.Parametre.ObtnRelDispIndivSorti en Professionnel.Parametre.ObtenirDispensateurIndividuSorti
        /// </summary>
        /// <Parametre name="parametreEntreEZP3">Objet source</Parametre>
        /// <remarks></remarks>
        static internal ObtenirDispensateurIndividuSorti Mapper(parametreEPZ3.ObtnRelDispIndivSorti intrantEPZ3)
        {
            var extrant = new ObtenirDispensateurIndividuSorti();
            extrant.AnneesGraduation = intrantEPZ3.AnneesGraduation;
            extrant.ChiffresPreuveDispensateur = intrantEPZ3.ChiffresPreuveDispensateur;
            extrant.CodesProfession = intrantEPZ3.CodesProfession;
            extrant.DatesCreationDispensateur = intrantEPZ3.DatesCreationDispensateur;
            extrant.DatesCreationIndividu = intrantEPZ3.DatesCreationIndividu;
            extrant.DatesDebutPratique = intrantEPZ3.DatesDebutPratique;
            extrant.DatesDecesIndividu = intrantEPZ3.DatesDecesIndividu;
            extrant.DatesInscriptionRamq = intrantEPZ3.DatesInscriptionRamq;
            extrant.DatesMAJDispensateur = intrantEPZ3.DatesMAJDispensateur;
            extrant.DatesModificationIndividu = intrantEPZ3.DatesModificationIndividu;
            extrant.DatesNaissanceIndividu = intrantEPZ3.DatesNaissanceIndividu;
            extrant.DatesObtentionPermis = intrantEPZ3.DatesObtentionPermis;
            extrant.DatesPremiereSpecialite = intrantEPZ3.DatesPremiereSpecialite;
            extrant.DroitsAcquisTarifHoraire = intrantEPZ3.DroitsAcquisTarifHoraire;
            extrant.IdentifiantsUtilisateurCreateur = intrantEPZ3.IdentifiantsUtilisateurCreateur;
            extrant.IdentifiantsUtilisateurModificateur = intrantEPZ3.IdentifiantsUtilisateurModificateur;
            extrant.IdentifiantsUtilisteurCreateurIndividu = intrantEPZ3.IdentifiantsUtilisteurCreateurIndividu;
            extrant.IdentifiantUtilisateurModificateurIndividu = intrantEPZ3.IdentifiantUtilisateurModificateurIndividu;
            extrant.IndicateursDemandeCourrier = intrantEPZ3.IndicateursDemandeCourrier;
            extrant.IndicateursFacturationRecente = intrantEPZ3.IndicateursFacturationRecente;
            extrant.InfoMsgTrait = intrantEPZ3.InfoMsgTrait;
            extrant.LanguesIndividu = intrantEPZ3.LanguesIndividu;
            extrant.NombresAnneesExperienceQuebecSpecialiste = intrantEPZ3.NombresAnneesExperienceQuebecSpecialiste;
            extrant.NombresAnnneesExperienceHorsQuebec = intrantEPZ3.NombresAnnneesExperienceHorsQuebec;
            extrant.NomsIndividu = intrantEPZ3.NomsIndividu;
            extrant.NomsNaissanceIndividu = intrantEPZ3.NomsNaissanceIndividu;
            extrant.NomsTronqueIndividu = intrantEPZ3.NomsTronqueIndividu;
            extrant.NumeroAssuranceSocialeIndividu = intrantEPZ3.NumeroAssuranceSocialeIndividu;
            extrant.NumerosClasseDispensateur = intrantEPZ3.NumerosClasseDispensateur;
            extrant.NumerosDispensateur = intrantEPZ3.NumerosDispensateur;
            extrant.NumerosSequentielDispensateur = intrantEPZ3.NumerosSequentielDispensateur;
            extrant.NumerosSequentielIndividu = intrantEPZ3.NumerosSequentielIndividu;
            extrant.NumerosSequentielIntervenantGraduation = intrantEPZ3.NumerosSequentielIntervenantGraduation;
            extrant.PrenomsIndividu = intrantEPZ3.PrenomsIndividu;
            extrant.SexeIndividu = intrantEPZ3.SexeIndividu;
            extrant.StatutsCivilIndividu = intrantEPZ3.StatutsCivilIndividu;
            extrant.TerritoiresPermis = intrantEPZ3.TerritoiresPermis;
            extrant.TitreCiviliteIndividu = intrantEPZ3.TitreCiviliteIndividu;

            return extrant;
        }

        #endregion

        #region Autorisation



        /// <summary>
        ///  Map un objet PRE_Entites_cpo.Autorisation.Parametre.ModifierAutorisationEntre
        ///  en ModifierAutorisationEntre
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>

#pragma warning disable RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        static internal void Mapper(PRE_Entites_cpo.Autorisation.Parametre.ModifierAutorisationEntre source,
                                    ref parametrePlanRegnMdcal.ModifierAutorisationEntre cible)
#pragma warning restore RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        {
            if (cible == null)
            {
                cible = new parametrePlanRegnMdcal.ModifierAutorisationEntre();
            }
                    
            cible.NumeroSequentiel = source.NumeroSequentiel;
            cible.NumeroSequentielDispensateur = source.NumeroSequentielDispensateur;
            cible.TypeLgeo = source.TypeLgeo;
            cible.CodeLgeo = source.CodeLgeo;                   
            cible.NumeroSeqRegrAdmnLgeo = source.NumeroSeqRegrAdmnLgeo;
            cible.TypeAutor = source.TypeAutor;
            cible.DateDebut = source.DateDebut;
            cible.DateFin = source.DateFin;
            cible.CodRss = source.CodRss;
            cible.CodeRaisonStatut = source.CodeRaisonStatut;
            cible.IdentifiantMAJ = source.IdentifiantMAJ;

        }

        /// <summary>
        ///  Map un objet ModifierAutorisationSorti
        ///  en PRE_Entites_cpo.Autorisation.Parametre.ModifierAutorisationSorti
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
#pragma warning disable RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        static internal void Mapper(parametrePlanRegnMdcal.ModifierAutorisationSorti source, ref PRE_Entites_cpo.Autorisation.Parametre.ModifierAutorisationSorti cible)
#pragma warning restore RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        {
            if (cible == null)
            {
                cible = new PRE_Entites_cpo.Autorisation.Parametre.ModifierAutorisationSorti();
            }

            cible.InfoMsgTrait = source.InfoMsgTrait; 
            cible.NouveauNumeroSequentiel = source.NouveauNumeroSequentiel;
        }

        /// <summary>
        ///  Map un objet PRE_Entites_cpo.Autorisation.Parametre.ObtenirLesAutorisationsProfessionnelEntre en 
        ///  PlanRegnMdcal.Parametre.ObtenirAutorisationsEntre
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <returns>Objet cible</returns>
        public static AccesDonneParametre.ObtenirAutorisationsEntre Mapper(ObtenirLesAutorisationsProfessionnelEntre source)
        {
            return new AccesDonneParametre.ObtenirAutorisationsEntre()
            {
                NumeroSequentielDispensateur = source.NumeroSequentielDispensateur

            };
        }

        /// <summary>
        ///  Map un objet PlanRegnMdcal.Parametre.ObtenirAutorisationsSorti en 
        ///  PRE_Entites_cpo.Autorisation.Parametre.ObtenirLesAutorisationsProfessionnelSorti
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <returns>Objet cible</returns>
        public static ObtenirLesAutorisationsProfessionnelSorti Mapper(AccesDonneParametre.ObtenirAutorisationsSorti source)
        {
            return new ObtenirLesAutorisationsProfessionnelSorti()
            {

                Autorisations = MapperAutorisation(source.Autorisations),
                InfoMsgTrait = source.InfoMsgTrait

            };
        }

        /// <summary>
        /// Permet de mapper un objet PRE_AccesDonne_cpo.PlanRegnMdcal.Entite.Autorisation en
        /// PRE_Entites_cpo.Autorisation.Entite.Autorisation
        /// </summary>
        /// <param name="autorisations">Liste d'entité de travail Autorisation</param>
        /// <returns>Liste d'entité de donnée Autorisation.</returns>
        private static List<Entites.Autorisation> MapperAutorisation(List<entitePlanRegnMdcal.Autorisation> autorisations)
        {
            List<Entites.Autorisation> autorisatonsTravail = new List<Entites.Autorisation>();
            Entites.Autorisation autorisationTravail;

            foreach (entitePlanRegnMdcal.Autorisation autorisationDonnees in autorisations)
            {
                autorisationTravail = new Entites.Autorisation()
                {
                    NumeroSequence = autorisationDonnees.NumeroSequenceAutorisation,
                    NumeroSequenceDispensateur = autorisationDonnees.NumeroSequenceDispensateur,
                    TypeLieuGeographique = autorisationDonnees.TypeLieuGeographique,
                    CodeLieuGeographique = autorisationDonnees.CodeLieuGeographique,
                    NumeroSequenceRegroupementAdministratif = autorisationDonnees.NumeroSequenceRegroupementAdministratif,
                    Type = autorisationDonnees.TypeAutorisation,
                    DateDebut = autorisationDonnees.DateDebut,
                    DateFin = autorisationDonnees.DateFin,
                    DateHeureCreationOccurence = autorisationDonnees.DateHeureCreation,
                    IdentitfiantUtilisateurCreation = autorisationDonnees.IdUtilisateurCreateur,
                    DateHeureInactivation = autorisationDonnees.DateHeureInactivation,
                    IdentifiantUtilisateurInactivation = autorisationDonnees.IdUtilisateurInactivation,
                    CodeRSS =autorisationDonnees.CodeRSS,
                    CodeRaisonStatut=autorisationDonnees.CodeRaisonStatut

                };
            }

            return autorisatonsTravail;

        }

        #endregion

        #region Absences d'avis

        /// <summary>
        ///  Map un objet PRE_Entites_cpo.AbsenceAvis.Parametre.ObtenirListeEngagementsEtAbsencesAvisEntre 
        ///  en PlanRegnMdcal.Parametre.ObtenirListeEngagementsEtAbsencesAvisEntre
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
#pragma warning disable RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        static internal void Mapper(parametreAbsenceAvis.ObtenirListeEngagementsEtAbsencesAvisEntre source,
                                    ref parametrePlanRegnMdcal.ObtenirListeEngagementsEtAbsencesAvisEntre cible)
#pragma warning restore RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        {
            cible.DateDebut = source.DateDebut;
            cible.DateFin = source.DateFin;
            cible.NumeroSequentielDispensateur = source.NumeroSequentielDispensateur;
            cible.TypeListe = source.TypeListe;
        }

        /// <summary>
        ///  Map un objet PlanRegnMdcal.Parametre.ObtenirListeEngagementsEtAbsencesAvisSorti 
        ///  en PRE_Entites_cpo.AbsenceAvis.Parametre.ObtenirListeEngagementsEtAbsencesAvisSorti
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
#pragma warning disable RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        static internal void Mapper(parametrePlanRegnMdcal.ObtenirListeEngagementsEtAbsencesAvisSorti source,
                                    ref parametreAbsenceAvis.ObtenirListeEngagementsEtAbsencesAvisSorti cible)
#pragma warning restore RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        {
            entiteAbsenceAvis.AbsenceAvis absenceAvisCible = new entiteAbsenceAvis.AbsenceAvis();

            cible.InfoMsgTrait = source.InfoMsgTrait;

            foreach (entitePlanRegnMdcal.AbsenceAvis absenceAvis in source.ListeEngagementsEtAbsencesAvis)
            {
                absenceAvisCible = new entiteAbsenceAvis.AbsenceAvis
                {
                    CodeLieuGeographique = absenceAvis.CodeLieuGeographique,
                    CodeRss = absenceAvis.CodeRss,
                    DateDebut = absenceAvis.DateDebut,
                    DateFin = absenceAvis.DateFin,
                    NumeroSeqRegrAdmnLgeo = absenceAvis.NumeroSeqRegrAdmnLgeo,
                    NumeroSequenceDispensateur = absenceAvis.NumeroSequenceDispensateur,
                    NumeroSequentielAutorisation = absenceAvis.NumeroSequentielAutorisation,
                    NumeroSequentielAvis = absenceAvis.NumeroSequentielAvis,
                    NumeroSequentielDerogation = absenceAvis.NumeroSequentielDerogation,
                    Statut = absenceAvis.Statut,
                    TypeDerogation = absenceAvis.TypeDerogation,
                    TypeLieuGeographique = absenceAvis.TypeLieuGeographique
                };

                cible.ListeEngagementsEtAbsencesAvis.Add(absenceAvisCible);
            }
        }

        #endregion

        #region Caractéristique pratique

        /// <summary>
        ///  Map un objet PRE_Entites_cpo.CaracteristiquePratique.Parametre.ObtenirCaracteristiquePratiqueRssEntre en ObtenirCaracteristiquePratiqueRssEntre
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
#pragma warning disable RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        static internal void Mapper(PRE_Entites_cpo.CaracteristiquePratique.Parametre.ObtenirCaracteristiquePratiqueRssEntre source,
                                    ref parametrePlanRegnMdcal.ObtenirCaracteristiquePratiqueRssEntre cible)
#pragma warning restore RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        {
            if (cible == null)
            {
                cible = new parametrePlanRegnMdcal.ObtenirCaracteristiquePratiqueRssEntre();
            }

            cible.CaracteristiquePratique = source.CaracteristiquePratique;
            cible.CodeRss = source.CodeRss;
            cible.DateDeDebut = source.DateDeDebut;
            cible.DateDeFin = source.DateDeFin;
        }

        /// <summary>
        ///  Map un objet ObtenirCaracteristiquePratiqueRssSorti en PRE_Entites_cpo.CaracteristiquePratique.Parametre.ObtenirCaracteristiquePratiqueRssSorti
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>

#pragma warning disable RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        static internal void Mapper(parametrePlanRegnMdcal.ObtenirCaracteristiquePratiqueRssSorti source,
                                    ref PRE_Entites_cpo.CaracteristiquePratique.Parametre.ObtenirCaracteristiquePratiqueRssSorti cible)
#pragma warning restore RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        {
            if (cible == null)
            {
                cible = new PRE_Entites_cpo.CaracteristiquePratique.Parametre.ObtenirCaracteristiquePratiqueRssSorti();
            }

            cible.InfoMsgTrait = new List<MsgTrait>(source.InfoMsgTrait);
            cible.CaracteristiquesPratique = new List<PRE_Entites_cpo.CaracteristiquePratique.Entite.CaracteristiquePratique>
                (from caracteristique in source.CaracteristiquesPratique
                select new PRE_Entites_cpo.CaracteristiquePratique.Entite.CaracteristiquePratique
                {
                    CodeRss = caracteristique.CodeRss,
                    DateDebut = caracteristique.DateDebut,
                    DateCreation = caracteristique.DateCreation,
                    DateFin = caracteristique.DateFin,
                    TypeCaracteristiquePratique = caracteristique.TypeCaracteristiquePratique
                });

        }


        /// <summary>
        ///  Map un objet PRE_Entites_cpo.Professionnel.Parametre.ObtenirPeriodePratiqueProfessionnelEntre en PRE_SysExt_cpo.FIP.EPZ3.Parametre.ObtenirPeriodePratiqueProfessionnelEntre
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
        static internal void Mapper(PRE_Entites_cpo.Professionnel.Parametre.ObtenirInfoPerslDispEntre source,
                                    ref PRE_SysExt_cpo.FIP.EPZ3.Parametre.ObtenirInfoPerslDispEntre cible)
        {
            if (cible == null)
            {
                cible = new PRE_SysExt_cpo.FIP.EPZ3.Parametre.ObtenirInfoPerslDispEntre();
            }

            cible.NomDispensateur = source.NomDispensateur;
            cible.PrenomDispensateur = source.PrenomDispensateur;

            foreach (var numeroEtClasse in source.NumerosEtClassesDispensateurs)
            {
                cible.ClassesDispensateur.Add(numeroEtClasse.ClasseDispensateur != null ? numeroEtClasse.ClasseDispensateur : null);
                cible.NumerosDispensateur.Add(numeroEtClasse.NumeroDispensateur != null ? numeroEtClasse.NumeroDispensateur : null);
            }

        }

        /// <summary>
        ///  Map un objet PRE_SysExt_cpo.FIP.EPZ3.Parametre.ObtenirInfoPerslDispSorti en PRE_Entites_cpo.Professionnel.Parametre.ObtenirInfoPerslDispSorti
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
        static internal void Mapper(PRE_SysExt_cpo.FIP.EPZ3.Parametre.ObtenirInfoPerslDispSorti source,
                                    ref PRE_Entites_cpo.Professionnel.Parametre.ObtenirInfoPerslDispSorti cible)
        {
            if (cible == null)
            {
                cible = new PRE_Entites_cpo.Professionnel.Parametre.ObtenirInfoPerslDispSorti();
            }

            if (cible.InfoMsgTrait == null)
            {
                cible.InfoMsgTrait = new List<Message.MsgTrait>();
            }

            cible.InfoMsgTrait = source.InfoMsgTrait;

            if (source.ClassesDispensateur != null)
            {
                for (int i = 0; i < source.ClassesDispensateur.Count() - 1; i++)
                {
                    cible.InformationsPersonnellesDisp.Add(new PRE_Entites_cpo.Professionnel.Entite.InfoPersonnelleslDisp()
                    {
                        ClasseDispensateur = source.ClassesDispensateur[i],
                        CodeDeProfession = source.CodesDeProfession[i],
                        DateDebutSpec = source.DatesDebutSpec[i],
                        DateDeces = source.DatesDeces[i],
                        DateObtentionPermis = source.DatesObtentionPermis[i],
                        NomDisp = source.NomsDisp[i],
                        NumeroDispensateur = source.NumerosDispensateur[i],
                        NumeroSeqDisp = source.NumerosSeqDisp[i],
                        PrenomDisp = source.PrenomsDisp[i]
                    });
                }
            }
        }

        #endregion

        #region Rapports

        /// <summary>
        ///  Map un objet PlanRegnMdcal.Parametre.ObtenirJoursFactPratiAvisSorti en 
        ///  PRE_Entites_cpo.Rapport.Entite.LigneRapportRepartInterRegionPrati
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <returns>Objet cible</returns>
        public static parametrePlanRegnMdcal.ObtenirVueJoursFactPratiAvisEntre Mapper(parametreRapport.ParamObtnrRappRepartInterRegionPrati source)
        {
            return new parametrePlanRegnMdcal.ObtenirVueJoursFactPratiAvisEntre()
            {
                
            };
        }


        #endregion

        #region Demande de réévaluation


        /// <summary>
        ///  Map un objet PRE_Entites_cpo.DemandeReevaluation.Parametre.ObtenirDemandeReevaluationEntre
        ///  en PlanRegnMdcal.Parametre.ObtenirListeDemReevaEntre 
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
        static internal AccesDonneParametre.ObtenirListeDemReevaEntre Mapper(ObtenirDemandeReevaluationEntre source)
        {
            return new AccesDonneParametre.ObtenirListeDemReevaEntre()
            {
                NumeroCategorieReeva = source.CategorieDemande,
                CodeSourceDemandeReeva = source.CodeSourceDemande,
                DateDebutPeriodeReeva = source.DateDebutRech,
                DateFinPeriodeReeva = source.DateFinRech,
                IndOccActive = source.IndicateurActive,
                NumeroSequentielDemandeReeva = source.NumeroSequentielDemande,
                NumeroSequentielDispensateur = source.NumeroSequentielDispensateur
            };
            
        }

        /// <summary>
        ///  Map un objet PlanRegnMdcal.Parametre.ObtenirListeDemReevaSorti 
        ///  en PRE_Entites_cpo.DemandeReevaluation.Parametre.ObtenirDemandeReevaluationSorti
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
        static internal ObtenirDemandeReevaluationSorti Mapper(parametrePlanRegnMdcal.ObtenirListeDemReevaSorti source)
        {
            var cible = new ObtenirDemandeReevaluationSorti();
            cible.InfoMsgTrait = source.InfoMsgTrait;

            foreach (entitePlanRegnMdcal.DemandeReeva demReeva in source.DemandesReeva)
            {
                cible.ListeDemandeReevaluation.Add(new PRE_Entites_cpo.DemandeReevaluation.Entite.DemandeReevaluation() {
                    CategorieDemande = demReeva.CategorieReeva,
                    CodeSourceDemande = demReeva.CodeSourceDemReeva,
                    DateDebutReeva = demReeva.DateDebutReeva,
                    DateFinReeva = demReeva.DateFinReeva,
                    DateHeureInact = demReeva.DateInact,
                    DateHeureOccurence = demReeva.DateHeureCreation,
                    IdentifiantCreation = demReeva.IdentifiantCreation,
                    IdentifiantInact = demReeva.IdentifiantInact,
                    NumeroSequentielDemande = demReeva.NumeroSequentielDemReeva,
                    NumeroSequentielDispensateur = demReeva.NumeroSequentielDispensateur               
                });
            }

            return cible;
        }


        /// <summary>
        ///  Map un objet PlanRegnMdcal.Parametre.ModifierDemReevaPREMEntre 
        ///  en PRE_Entites_cpo.DemandeReevaluation.Parametre.ModifierDemandeReevaluationEntre
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
        static internal AccesDonneParametre.ModifierDemReevaPREMEntre Mapper(ModifierDemandeReevaluationEntre source)
        {
            return new AccesDonneParametre.ModifierDemReevaPREMEntre()
            {
                DatDebutReeva = source.DateDebutReeva,
                DatFinReeva = source.DateFinReeva,
                IdentifiantUtilisateur = source.IdentifiantMAJ,
                NumeroSequentielDemReeva = source.NumeroSequentielDemande

            };
        }

        /// <summary>
        ///  Map un objet PlanRegnMdcal.Parametre.ModifierDemReevaPREMSorti 
        ///  en PRE_Entites_cpo.DemandeReevaluation.Parametre.ModifierDemandeReevaluationSorti
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
        static internal ModifierDemandeReevaluationSorti Mapper(parametrePlanRegnMdcal.ModifierDemReevaPREMSorti source)
        {
            return new ModifierDemandeReevaluationSorti()
            {
                InfoMsgTrait = source.InfoMsgTrait,
                DateMAJOcc = source.DateHeureMAJOccurence
            };
        }

        /// <summary>
        ///  Map un objet PRE_Entites_cpo.DemandeReevaluation.Parametre.ModifierDemandeReevaluationEntre
        ///  en PlanRegnMdcal.Parametre.ModifierDemReevaPREMEntre 
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
        static internal AccesDonneParametre.AnnulerDemandeReevaPREMQEntre Mapper(AnnulerDemandeReevaluationEntre source)
        {
            return new AccesDonneParametre.AnnulerDemandeReevaPREMQEntre()
            {
                IdentifiantUtilisateur = source.IdentifiantInact,
                NumeroSequentielDemReeva = source.NumeroSequentielDemande
            };
        }

        /// <summary>
        ///  Map un objet PlanRegnMdcal.Parametre.AnnulerDemandeReevaPREMQSorti 
        ///  en PRE_Entites_cpo.DemandeReevaluation.Parametre.AnnulerDemandeReevaluationSorti
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
        static internal AnnulerDemandeReevaluationSorti Mapper(parametrePlanRegnMdcal.AnnulerDemandeReevaPREMQSorti source)
        {
            return new AnnulerDemandeReevaluationSorti()
            {
                InfoMsgTrait = source.InfoMsgTrait
            };
        }


        /// <summary>
        ///  Map un objet PRE_Entites_cpo.DemandeReevaluation.Parametre.CreerDemandeReevaluationEntre
        ///  en PlanRegnMdcal.Parametre.CreerDemReevaPREMEntre 
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
        static internal AccesDonneParametre.CreerDemReevaPREMEntre Mapper(CreerDemandeReevaluationEntre source)
        {
            return new AccesDonneParametre.CreerDemReevaPREMEntre()
            {
                NumeroCategorieReeva = source.CategorieDemande,
                CodeSourceDemande = source.CodeSourceDemande,
                DatDebutReeva = source.DateDebutReeva,
                DatFinReeva = source.DateFinReeva,
                IdentifiantUtilisateur = source.IdentifiantOcc,
                NumeroSequentielDisp = source.NumeroSequentielDispensateur
            };
        }

        /// <summary>
        ///  Map un objet PlanRegnMdcal.Parametre.CreerDemReevaPREMSorti 
        ///  en PRE_Entites_cpo.DemandeReevaluation.Parametre.CreerDemandeReevaluationSorti
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
        static internal CreerDemandeReevaluationSorti Mapper(parametrePlanRegnMdcal.CreerDemReevaPREMSorti source)
        {
            return new CreerDemandeReevaluationSorti()
            {
                InfoMsgTrait = source.InfoMsgTrait
            };
        }

        #endregion

        #region Vue Engagements - Absence

        /// <summary>
        ///  Map un objet PRE_Entites_cpo.Professionel.Parametre.ObtenirVuePeriodeEngagementEntre
        ///  en AccesDonneParametre.ObtenirVuePeriodesEngagementsEntre
        /// </summary>
        /// <Parametre name="source">Objet source</Parametre>
        /// <Parametre name="cible">Objet cible</Parametre>
        /// <remarks></remarks>
        public static AccesDonneParametre.ObtenirVuePeriodesEngagementsEntre Mapper(ObtenirVuePeriodeEngagementEntre source)
        {
            AccesDonneParametre.ObtenirVuePeriodesEngagementsEntre cible = new PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ObtenirVuePeriodesEngagementsEntre();

            cible.NumerosSequenceDispensateur = source.NumerosSequenceDispensateur;             
            cible.Type  = source.Type;

            return cible;
        }
        /// <summary>
        ///  Map un objet AccesDonneParametre.ObtenirVuePeriodesEngagementsSorti en PRE_Entites_cpo.Professionel.Parametre.ObtenirVuePeriodeEngagementSorti.
        /// </summary>
        /// <Parametre name="source">Objet source.</Parametre>
        /// <Parametre name="cible">Objet cible.</Parametre>
        /// <remarks></remarks>
        public static ObtenirVuePeriodeEngagementSorti Mapper(AccesDonneParametre.ObtenirVuePeriodesEngagementsSorti source)
        {
            ObtenirVuePeriodeEngagementSorti cible = new ObtenirVuePeriodeEngagementSorti();
            foreach (var item in source.EngagementsPeriode)
            {
                EngagementPeriode engag = new EngagementPeriode
                {
                    DateDebutEngagement = item.DateDebutEngagement,
                    DateFinEngagement = item.DateFinEngagement,
                    NumeroSequenceDisp = item.NumeroSequenceDisp,
                    Type = item.Type
                };
                cible.EngagementsPeriode.Add(engag);
            }

            foreach (var item in source.InfoMsgTrait)
            {
                var msgTrait=new MsgTrait
                {
                    CodAppli=item.CodAppli,
                    IdMsg=item.CodSever,
                    TxtMsgAngl=item.TxtMsgAngl,
                    TxtMsgFran=item.TxtMsgFran
                };
                cible.InfoMsgTrait.Add(msgTrait);
            }
 
           
            return cible;
        }
        #endregion

    }
}