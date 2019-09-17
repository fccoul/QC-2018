using RAMQ.PRE.PL_LogiqueAffaire_cpo.AvisConformite;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Derogation;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal;
using RAMQ.PRE.PRE_OutilComun_cpo;
using RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
/// <remarks>
/// </remarks>
namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo
{
    public class TraitementDonneesAdmissProf : ITraitementDonneesAdmissProf
    {

        private IPlanRegnMdcal _accesDonneesPRE;
        private IInfoDispCnsul _servDispCnsul;
        private IAvisConformite _avisConformite;
        private IDerogation _derogation;

        /// <summary>
        /// 
        /// </summary>
        public IPlanRegnMdcal AccesDonneesPRE
        {
            get
            {
                return _accesDonneesPRE;
            }

            set
            {
                _accesDonneesPRE = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IInfoDispCnsul AccesSysExt
        {
            get
            {
                return _servDispCnsul;
            }

            set
            {
                _servDispCnsul = value;
            }
        }

        public IAvisConformite AvisConformite
        {
            get
            {
                return _avisConformite;
            }

            set
            {
                _avisConformite = value;
            }
        }

        public IDerogation Derogation
        {
            get
            {
                return _derogation;
            }

            set
            {
                _derogation = value;
            }
        }

        

        /// <summary>
        /// Constructeur de la cpo
        /// </summary>
        /// <param name="accesDonneesPRE"></param>
        /// <param name="servDispCnsul"></param>
        public TraitementDonneesAdmissProf(IPlanRegnMdcal accesDonneesPRE, IInfoDispCnsul servDispCnsul, IAvisConformite avisConformite, IDerogation derogation)
        {
            if (accesDonneesPRE == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(accesDonneesPRE)} ne peut être null.");
            }

            if (servDispCnsul == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(servDispCnsul)} ne peut être null.");
            }

            if (avisConformite == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(avisConformite)} ne peut être null.");
            }

            if (derogation == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(derogation)} ne peut être null.");
            }

            _accesDonneesPRE = accesDonneesPRE;
            _servDispCnsul = servDispCnsul;
            _avisConformite = avisConformite;
            _derogation = derogation;
        }




        public List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> ObtenirListeAvisProf(long noSeqDispensateur, DateTime dateHeureEvenement)
        {
            var paramEntreObtnrAvisConf = new PRE_Entites_cpo.AvisConformite.Parametre.ObtenirLesAvisConformiteEntre()
            {
                NumeroSequentielDispensateur = noSeqDispensateur,
                DateDebut = dateHeureEvenement
            };

            var paramSortiObtnrAvisConformite = AvisConformite.ObtenirLesAvisConformite(paramEntreObtnrAvisConf);

            MessageTraitement.ValiderMessageTraitement(paramSortiObtnrAvisConformite);

            return paramSortiObtnrAvisConformite.ListeAvisConformite;
        }

        public List<PRE_Entites_cpo.Derogation.Entite.Derogation> ObtenirListeDerogationsProf(long noSeqDispensateur, DateTime dateHeureEvenement)
        {
            var paramEntreObtnrDerogations = new PRE_Entites_cpo.Derogation.Parametre.ObtenirDerogationsProfessionnelSanteEntre()
            {
                NumeroSequentielDispensateur = noSeqDispensateur,
                DateDebut = dateHeureEvenement
            };

            var paramSortiObtnrDerogations = Derogation.ObtenirDerogationProfessionnel(paramEntreObtnrDerogations);

            MessageTraitement.ValiderMessageTraitement(paramSortiObtnrDerogations);

            return paramSortiObtnrDerogations.Derogations;
        }

        public List<CoupleIDAvisStatut> ObtenirCouplesIdAvisStatutTermineOuAnnule(List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> listeAvis)
        {
            var listeCouplesIdAvisStatut = new List<CoupleIDAvisStatut>();

            foreach (var avis in listeAvis)
            {
                //Appel au service
                var paramEntreObtnrStaEngagPraRSS = new RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ObtenirStatutsEngagementPratiqueRSSEntre()
                {
                    NumeroSequentielEngagement = avis.NumeroSequentielEngagement,
                    CodeRaisonEngagement = 21
                };

                var paramSortiObtnrAvisConf = AccesDonneesPRE.ObtenirStatutsEngagementPratiqueRSS(paramEntreObtnrStaEngagPraRSS);

                MessageTraitement.ValiderMessageTraitement(paramSortiObtnrAvisConf);



                //On vérifie si l'avis en question possède un statut TERminé ou ANNulé, si oui, on l'ajoute à la liste des avis à traiter
                var coupleIDAvisStatut = new CoupleIDAvisStatut();

                coupleIDAvisStatut.IDAvis = (long)avis.NumeroSequentielEngagement;
                coupleIDAvisStatut.ListeIDStatuts = new List<long>();

                foreach (var statut in paramSortiObtnrAvisConf.ListeStatutEngagementPratiqueRSS)
                {
                    if (statut.StatutEngagement == "TER" || statut.StatutEngagement == "ANN")
                    {
                        coupleIDAvisStatut.ListeIDStatuts.Add((long)statut.NumeroSequentielStatutEngagement);
                    }
                }

                if (coupleIDAvisStatut.ListeIDStatuts.Any())
                {
                    listeCouplesIdAvisStatut.Add(coupleIDAvisStatut);
                }

            }

            return listeCouplesIdAvisStatut;
        }

        public void DesactiverStatutTermineOuAnnuleAvis(List<CoupleIDAvisStatut> listeCouplesIdAvisStatut)
        {
            foreach (var coupleIdAvisStatut in listeCouplesIdAvisStatut)
            {
                foreach (var noSeqStatut in coupleIdAvisStatut.ListeIDStatuts)
                {
                    var paramEntreModifStatutEngagement = new RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ModifierStatutEngagementEntre()
                    {
                        NumeroSequentielEngagement = coupleIdAvisStatut.IDAvis,
                        NumeroSequentielStatutEngagement = noSeqStatut,
                        IdentifiantMAJ = RAMQ.Securite.Principal.Identite.ObtnUtil(System.Web.HttpContext.Current.Request.RequestContext.HttpContext),
                        IndicateurStatutEngagementEnAttente = "O"
                    };

                    var paramSortiModifStatutEngagement = AccesDonneesPRE.ModifierStatutEngagement(paramEntreModifStatutEngagement);

                    MessageTraitement.ValiderMessageTraitement(paramSortiModifStatutEngagement);
                }
            } 
        }

        public List<PRE_Entites_cpo.Derogation.Entite.Derogation> GarderIDDerogationsTermineesAnnuleesRaisonSix(List<PRE_Entites_cpo.Derogation.Entite.Derogation> listeDerogations)
        {
            var listeDerogationsAGarder = new List<PRE_Entites_cpo.Derogation.Entite.Derogation>();

            foreach (var derogation in listeDerogations)
            {
                if (derogation.Statut == "TER" || derogation.Statut == "ANN")
                {
                    listeDerogationsAGarder.Add(derogation);
                }
            }

            return listeDerogations;
        }

        public void ReactiverDerogationsTermineesOuAnnuleesRaisonSix(List<PRE_Entites_cpo.Derogation.Entite.Derogation> listeDerogations, long noSeqDispensateur, DateTime dateHeureEvenement)
        {
            foreach (var derogation in listeDerogations)
            {
                var paramEntreModifDerogation = new RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ModifierDerogationEntre()
                {
                    NumeroSequentiel = derogation.NumeroSequentiel,
                    NumeroSequentielDispensateur = noSeqDispensateur,
                    DateFin = dateHeureEvenement,
                    Statut = "AUT",
                    CodeRaisonStatut = "7"
                };

                var paramSortiModifDerogation = AccesDonneesPRE.ModifierDerogation(paramEntreModifDerogation);

                MessageTraitement.ValiderMessageTraitement(paramSortiModifDerogation);
            }
        }





        public bool VerifierListeAvis(List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> listeAvis)
        {
            return listeAvis.Any();
        }

        public bool VerifierListeDerogations(List<PRE_Entites_cpo.Derogation.Entite.Derogation> listeDerogations)
        {
            return listeDerogations.Any();
        }


        public bool VerifierListesAvisEtDerogations(List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> listeAvis, List<PRE_Entites_cpo.Derogation.Entite.Derogation> listeDerogations)
        {
            return (listeAvis.Any() && listeDerogations.Any());
        }

        public List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> GarderAvisActifs(List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> listeAvis)
        {
            if (listeAvis.Any())
            {
                foreach (var avisEnTraitement in listeAvis)
                {
                    if (avisEnTraitement.DateDebutEngagement <= DateTime.Now && avisEnTraitement.DateFinEngagement >= DateTime.Now)
                    {
                        listeAvis.Add(avisEnTraitement);
                    }
                }
            }
            else
            {
                listeAvis = new List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>();
            }

            return listeAvis;
        }

        public List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> GarderAvisFuturs(List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> listeAvis)
        {
            if (listeAvis.Any())
            {
                foreach (var avisEnTraitement in listeAvis)
                {
                    if (avisEnTraitement.DateDebutEngagement > DateTime.Now && avisEnTraitement.DateFinEngagement > DateTime.Now)
                    {
                        listeAvis.Add(avisEnTraitement);
                    }
                }
            }
            else
            {
                listeAvis = new List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite>();
            }

            return listeAvis;
        }

        public List<PRE_Entites_cpo.Derogation.Entite.Derogation> GarderDerogationActives(List<PRE_Entites_cpo.Derogation.Entite.Derogation> listeDerogations)
        {
            if (listeDerogations.Any())
            {
                foreach (var derogationEnTraitement in listeDerogations)
                {
                    if (derogationEnTraitement.DateDebut <= DateTime.Now && derogationEnTraitement.DateFin >= DateTime.Now)
                    {
                        listeDerogations.Add(derogationEnTraitement);
                    }
                }
            }
            else
            {
                listeDerogations = new List<PRE_Entites_cpo.Derogation.Entite.Derogation>();
            }

            return listeDerogations;
        }

        public List<PRE_Entites_cpo.Derogation.Entite.Derogation> GarderDerogationFutures(List<PRE_Entites_cpo.Derogation.Entite.Derogation> listeDerogations)
        {
            if (listeDerogations.Any())
            {
                foreach (var derogationEnTraitement in listeDerogations)
                {
                    if (derogationEnTraitement.DateDebut > DateTime.Now && derogationEnTraitement.DateFin > DateTime.Now)
                    {
                        listeDerogations.Add(derogationEnTraitement);
                    }
                }
            }
            else
            {
                listeDerogations = new List<PRE_Entites_cpo.Derogation.Entite.Derogation>();
            }

            return listeDerogations;
        }

        public void FermerAvisActifs(List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> listeAvisActifs, DateTime dateHeureEvenement)
        {
            foreach (var avisEnTraitement in listeAvisActifs)
            {
                var dateFinLaPlusRecente = DateTime.MinValue;
                foreach (var statut in avisEnTraitement.ListeStatutAvisConformite)
                {
                    if (statut.DateFinStatutEngagement > dateFinLaPlusRecente)
                    {
                        dateFinLaPlusRecente = (DateTime)statut.DateFinStatutEngagement;
                    }
                }

                var paramEntreModificationAvis = new RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.CreerStatutAvisConformiteEntre()
                {
                    NumeroSequentielEngagement = Convert.ToInt64(avisEnTraitement.NumeroSequentielEngagement),
                    StatutEngagement = "TER",
                    IdentifiantCreation = RAMQ.Securite.Principal.Identite.ObtnUtil(System.Web.HttpContext.Current.Request.RequestContext.HttpContext),
                    DateDebutStatutEngagement = dateHeureEvenement,
                    CodeRaisonStatutEngagement = "21",
                    DateFinStatutEngagement = dateFinLaPlusRecente
                };

                var paramSortiModificationAvis = AccesDonneesPRE.CreerStatutAvisConformite(paramEntreModificationAvis);

                MessageTraitement.ValiderMessageTraitement(paramSortiModificationAvis);
            }
        }

        public void FermerDerogationsActives(List<PRE_Entites_cpo.Derogation.Entite.Derogation> listeDerogationsActives, long noSequentielDispensateur, DateTime dateHeureEvenement)
        {
            foreach (var derogationEnTraitement in listeDerogationsActives)
            {
                var paramEntreModificationDerogation = new RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ModifierDerogationEntre
                {
                    NumeroSequentiel = derogationEnTraitement.NumeroSequentiel,
                    NumeroSequentielDispensateur = noSequentielDispensateur,
                    DateFin = dateHeureEvenement,
                    Statut = "TER",
                    CodeRaisonStatut = "6"
                };

                var paramSortiModificationDerogation = AccesDonneesPRE.ModifierDerogation(paramEntreModificationDerogation);

                MessageTraitement.ValiderMessageTraitement(paramSortiModificationDerogation);
            }
        }

        public void AnnulerAvisFuturs(List<PRE_Entites_cpo.AvisConformite.Entite.AvisConformite> listeAvisFuturs, DateTime dateHeureEvenement)
        {
            foreach (var avisEnTraitement in listeAvisFuturs)
            {
                var dateDebutLaPlusRecente = DateTime.MinValue;
                var dateFinLaPlusRecente = DateTime.MinValue;
                foreach (var statut in avisEnTraitement.ListeStatutAvisConformite)
                {
                    if (statut.DateFinStatutEngagement > dateFinLaPlusRecente)
                    {
                        dateFinLaPlusRecente = (DateTime)statut.DateFinStatutEngagement;
                        dateDebutLaPlusRecente = (DateTime)statut.DateDebutStatutEngagement;
                    }
                }

                var paramEntreModificationAvis = new RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.CreerStatutAvisConformiteEntre()
                {
                    NumeroSequentielEngagement = Convert.ToInt64(avisEnTraitement.NumeroSequentielEngagement),
                    StatutEngagement = "ANN",
                    IdentifiantCreation = RAMQ.Securite.Principal.Identite.ObtnUtil(System.Web.HttpContext.Current.Request.RequestContext.HttpContext),
                    DateDebutStatutEngagement = dateDebutLaPlusRecente,
                    CodeRaisonStatutEngagement = "21",
                    DateFinStatutEngagement = dateFinLaPlusRecente
                };

                var paramSortiModificationAvis = AccesDonneesPRE.CreerStatutAvisConformite(paramEntreModificationAvis);

                MessageTraitement.ValiderMessageTraitement(paramSortiModificationAvis);
            }
        }

        public void AnnulerDerogationsFutures(List<PRE_Entites_cpo.Derogation.Entite.Derogation> listeDerogationsFutures, long noSequentielDispensateur, DateTime dateHeureEvenement)
        {
            foreach (var derogationEnTraitement in listeDerogationsFutures)
            {
                var paramEntreModificationDerogation = new RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ModifierDerogationEntre
                {
                    NumeroSequentiel = derogationEnTraitement.NumeroSequentiel,
                    NumeroSequentielDispensateur = noSequentielDispensateur,
                    DateFin = dateHeureEvenement,
                    Statut = "ANN",
                    CodeRaisonStatut = "6"
                };
                var paramSortiModificationDerogation = AccesDonneesPRE.ModifierDerogation(paramEntreModificationDerogation);

                MessageTraitement.ValiderMessageTraitement(paramSortiModificationDerogation);
            }
        }
    }
}