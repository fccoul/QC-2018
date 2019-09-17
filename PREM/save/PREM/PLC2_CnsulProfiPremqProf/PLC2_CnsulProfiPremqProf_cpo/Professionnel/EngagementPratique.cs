#region Importation
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Admissibilite;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.AvisConformite;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Derogation;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.Professionnel;
using RAMQ.PRE.PL_RegleAffaiComne_cpo.Territoire.Factory;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Entites;
using RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Professionnel.Interface;
using RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Derogation.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.EngagementPratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.LieuGeographique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.PeriodePratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Pratique.Entite;
using RAMQ.PRE.PRE_Entites_cpo.Pratique.Parametre;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Entite;
using RAMQ.PRE.PRE_Entites_cpo.Professionnel.Parametre;
using System;
using System.Collections.Generic;
using System.Linq;
using Entite = RAMQ.PRE.PRE_Entites_cpo.EngagementPratique.Entite;
using EntiteAvisConformite = RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Entite;
using EntiteDerogation = RAMQ.PRE.PRE_Entites_cpo.Derogation.Entite;
using LogiqueAffaireAutorisation = RAMQ.PRE.PL_LogiqueAffaire_cpo.Autorisation;
using LogiqueAffairePrametres = RAMQ.PRE.PL_LogiqueAffaire_cpo.Parametres;
using OutilCommun = RAMQ.PRE.PRE_OutilComun_cpo;
#endregion


namespace RAMQ.PRE.PLC2_CnsulProfiPremqProf_cpo.Professionnel
{
    /// <summary> 
    ///  Classe des engagements de pratiques
    /// </summary>
    /// <remarks>
    ///  Auteur : Jean-Benoit Drouin-Cloutier <br/>
    ///  Date   : Décembre 2016
    /// </remarks>
    public class EngagementPratique : IEngagementPratique
    {
        private static DateTime DateDebutPREM
        {
            get
            {
                DateTime dateDebPREM = new DateTime(2004, 3, 1);
                bool dtPrem = DateTime.TryParse(Constante.DateDebutPREM, out dateDebPREM);
                return dtPrem == true ? dateDebPREM : new DateTime(2004, 3, 1);
                //return new DateTime(2004, 3, 1);
            }
        }
        private static DateTime DatePrecedentDebutPREM
        {
            get
            {
                return DateDebutPREM.AddDays(-1);
            }
        }


        #region Attributs privés

        private List<Entite.EngagementPratique> _avisConformites;
        private List<Entite.EngagementPratique> _avisRevoques;
        private List<Entite.EngagementPratique> _derogations;
        private List<Entite.EngagementPratique> _autorisations;
        private List<Message.MsgTrait> _messageErreurs;
        private bool _estDRMG;
        private readonly IPeriodePratique _periodePratique;
        private readonly IAvisConformite _avisConformite;
        private readonly IObtenirNomTerritoireFactory _obtenirNomTerritoireFactory;
        private readonly IDerogation _derogation;
        private readonly LogiqueAffaireAutorisation.IAutorisation _autorisation;
        private readonly IJourneeFacturation _journeeFacturation;
        private static readonly Random _random = new Random();
        private static readonly object _syncLock = new object();

        private readonly IEngagementAbence _engagementAbence;
        private readonly IRechercherProfessionnel _professionnel;
        private readonly IAdmissibilite _admissibilite;

        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public EngagementPratique(IPeriodePratique periodePratique,
                                  IAvisConformite avisConformite,
                                  IObtenirNomTerritoireFactory nomTerritoireFactory,
                                  IDerogation derogation,
                                  LogiqueAffaireAutorisation.IAutorisation autorisation,
                                  IJourneeFacturation journeeFacturation,
                                  IEngagementAbence engagementAbence,
                                  IRechercherProfessionnel professionnel
                                  , IAdmissibilite admissibilite)
        {

            if (periodePratique == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(periodePratique)} ne peut être null.");
            }

            if (avisConformite == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(avisConformite)} ne peut être null.");
            }

            if (nomTerritoireFactory == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(nomTerritoireFactory)} ne peut être null.");
            }

            if (derogation == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(derogation)} ne peut être null.");
            }

            if (autorisation == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(autorisation)} ne peut être null.");
            }

            if (journeeFacturation == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(journeeFacturation)} ne peut être null.");
            }

            if (engagementAbence == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(engagementAbence)} ne peut être null.");
            }
            if (professionnel == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(professionnel)} ne peut être null.");
            }
            if (admissibilite == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(admissibilite)} ne peut être null.");
            }

            _periodePratique = periodePratique;
            _avisConformite = avisConformite;
            _obtenirNomTerritoireFactory = nomTerritoireFactory;
            _derogation = derogation;
            _autorisation = autorisation;
            _journeeFacturation = journeeFacturation;

            _engagementAbence = engagementAbence;
            _professionnel = professionnel;
            _admissibilite = admissibilite;
        }

        #endregion

        #region Propriétés

        /// <summary>
        /// Liste des avis de conformité
        /// </summary>
        /// <returns></returns>
        public List<Entite.EngagementPratique> AvisConformites
        {
            get
            {
                if (_avisConformites == null)
                {
                    _avisConformites = new List<Entite.EngagementPratique>();
                }
                return _avisConformites;
            }
            set { _avisConformites = value; }
        }

        /// <summary>
        /// Liste des avis de conformité révoqués
        /// </summary>
        /// <returns></returns>
        private List<Entite.EngagementPratique> AvisRevoques
        {
            get
            {
                if (_avisRevoques == null)
                {
                    _avisRevoques = new List<Entite.EngagementPratique>();
                }
                return _avisRevoques;
            }
            set { _avisRevoques = value; }
        }

        /// <summary>
        /// Liste des dérogations d'un professionnel
        /// </summary>
        /// <returns></returns>
        private List<Entite.EngagementPratique> Derogations
        {
            get
            {
                if (_derogations == null)
                {
                    _derogations = new List<Entite.EngagementPratique>();
                }
                return _derogations;
            }
            set { _derogations = value; }
        }

        /// <summary>
        /// Liste des autorisation d'un professionnel
        /// </summary>
        /// <returns></returns>
        private List<Entite.EngagementPratique> Autorisations
        {
            get
            {
                if (_autorisations == null)
                {
                    _autorisations = new List<Entite.EngagementPratique>();
                }
                return _autorisations;
            }
            set { _autorisations = value; }
        }

        /// <summary>
        /// Liste de message d'erreur
        /// </summary>
        /// <returns></returns>
        public List<Message.MsgTrait> MessageErreurs
        {
            get
            {
                if (_messageErreurs == null)
                {
                    _messageErreurs = new List<Message.MsgTrait>();
                }
                return _messageErreurs;
            }
            set { _messageErreurs = value; }
        }

        /// <summary>
        /// Permet de créer un nombre aléatoire
        /// </summary>
        /// <returns></returns>
        public static int CreerNombreAleatoire()
        {
            lock (_syncLock)
            {
                return _random.Next(int.MaxValue);
            }
        }
        #endregion

        #region Méthodes publiques

        /// <summary>
        /// Permet d'obtenir les engagements de pratique du professionnel
        /// </summary>
        /// <param name="intrant">Paramètre d'entré</param>
        /// <returns>Les engagement de pratique d'un professionnel</returns>
        public ObtenirEngagementPratiqueSorti ObtenirLesEngagementsPratiquesProfessionnel(ObtenirEngagementPratiqueEntre intrant)
        {

            ObtenirEngagementPratiqueSorti extrant = null;
            List<Entite.EngagementPratique> engagementPratiqueFusionnes = null;
            DateTime? datePremiereFacturation = null;


            try
            {
                _estDRMG = intrant.EstDRMG;

                extrant = new ObtenirEngagementPratiqueSorti { InfoMsgTrait = new List<Message.MsgTrait>() };

                //Obtenir la période de pratique du professionnel  
                datePremiereFacturation = ObtenirPeriodePratiqueProfessionnel(intrant.NumeroSequenceDispensateur);

                //Obtenir la liste des avis de conformité
                AvisConformites = ObtenirLesAvisConformite(intrant.NumeroSequenceDispensateur);

                //Obtenir les dérogations                
                Derogations = ObtenirDerogations(intrant.NumeroSequenceDispensateur);

                //Obtenir les autorisation du professionnel           
                Autorisations = ObtenirAutorisations(intrant.NumeroSequenceDispensateur);

                //Ajout des avis de conformité à la liste des engagement de pratique du modèle
                engagementPratiqueFusionnes = FusionnerEngagements(datePremiereFacturation);

                // extrant.EngagementPratiques = engagementPratiqueFusionnes;--PRE 040
                extrant.EngagementPratiques = ObtenirEngagementPratiquesFormate(intrant, engagementPratiqueFusionnes);
                extrant.InfoMsgTrait = MessageErreurs;

            }
            catch (Exception)

            {
                throw;
            }

            return extrant;

        }

        /// <summary>
        /// permet de formatter la liste des engagements fusionnés avec les periodes absence et Non participation
        /// </summary>
        /// <param name="intrant"></param>
        /// <param name="engagementPratiqueFusionnes"></param>
        /// <returns></returns>
        public List<Entite.EngagementPratique> ObtenirEngagementPratiquesFormate(ObtenirEngagementPratiqueEntre intrant, List<Entite.EngagementPratique> engagementPratiqueFusionnes)
        {
            var result = new List<Entite.EngagementPratique>();

            var infosPro = _professionnel.ObtenirInformationProfessionnel(new ObtenirDispensateurIndividuEntre { NumeroSequentielDispensateur = intrant.NumeroSequenceDispensateur });
            var periodNonParticipation = ObtenirlesPeriodesNonParticipation(infosPro.NumerosDispensateur[0].Value, 1, DatePrecedentDebutPREM); //-Num disno    
            var admissibiliteFacturer = new List<AdmissibiliteFacturer>();
            foreach (var item in periodNonParticipation)
            {
                admissibiliteFacturer.Add(item);
            }
            var periodNP = new List<Entite.Periode>();
            foreach (var pnp in periodNonParticipation)
            {
                periodNP.Add(new Entite.Periode { DateDebut = pnp.DateDebutAdmissibilite, DateFin = pnp.DateFinAdmissibilite.HasValue ? pnp.DateFinAdmissibilite : new DateTime(2999, 12, 30) });//--pour la comparaison
            }

            Entite.Periode perDebHisto = null;
            if (engagementPratiqueFusionnes.Any(w => w.Description == "Absence d’avis"))
            {
                var engagDebHistoMin = engagementPratiqueFusionnes.Where(w => w.Description == "Absence d’avis").OrderBy(o => o.Periode.DateDebut).FirstOrDefault();
                perDebHisto = engagDebHistoMin.Periode;
            }
            else
            {
                var engagDebHistoMin = engagementPratiqueFusionnes.OrderBy(o => o.Periode.DateDebut).FirstOrDefault();
                perDebHisto = engagDebHistoMin != null && engagDebHistoMin.Historiques.Count() > 0 ? engagDebHistoMin.Historiques.LastOrDefault().Periode : null;
            }

            var resultAbs = ObtenirPeriodesAbs(intrant.NumeroSequenceDispensateur);
            var periodesAbs = new List<Entite.Periode>();
            foreach (var item in resultAbs)
            {
                Entite.Periode per = new Entite.Periode
                {
                    DateDebut = item.DateDebutEngagement
                                                        ,
                    DateFin = !item.DateFinEngagement.HasValue ? (DateTime?)null : item.DateFinEngagement.Value.Year == 2999 ?
                                                        (DateTime?)null : item.DateFinEngagement.Value
                };
                if (!per.DateFin.HasValue)
                {
                    per.DateFin = new DateTime(2999, 12, 30);
                }
                periodesAbs.Add(per);
            }
            periodesAbs = periodesAbs.Where(p => p.DateFin >= DateDebutPREM).ToList();

            if (perDebHisto != null && periodesAbs.Any())
            {
                var dateDebHistEngag = perDebHisto.DateDebut.Value;
                var dateFinHistEngag = perDebHisto.DateFin;

                periodesAbs.OrderBy(u => u.DateDebut);
                periodesAbs.FirstOrDefault().DateDebut = dateFinHistEngag <= periodesAbs.FirstOrDefault().DateFin ? dateDebHistEngag : periodesAbs.FirstOrDefault().DateDebut;
            }


            var engagemenFusionAbs = engagementPratiqueFusionnes.Where(a => a.Description == OutilCommun.Constantes.DescriptionTypeEngagement.TypeAbsenceAvis).ToList();
            var periodesFusionAbs = new List<Entite.Periode>();
            foreach (var item in engagemenFusionAbs)
            {
                Entite.Periode per = item.Periode;
                if (!per.DateFin.HasValue)
                {
                    per.DateFin = new DateTime(2999, 12, 30);
                }
                periodesFusionAbs.Add(per);
            }


            if (periodesAbs.Any())
            {
                var periodAInserer = periodesAbs.Except(periodesFusionAbs, new PeriodeComparer()).ToList();

                if (periodAInserer.Any())
                {
                    foreach (var item in periodAInserer)
                    {
                        engagementPratiqueFusionnes.Add(CreerAbsenseAvis(item.DateDebut.Value, item.DateFin.Value));

                    }


                    #region chevauchement

                    var periodARetirer = periodesFusionAbs.Intersect(periodNP, new PeriodeComparer()).ToList();
                    if (periodARetirer.Any())
                    {
                        foreach (var item in periodARetirer)
                        {

                            var eng = engagemenFusionAbs.Where(w => w.Periode.DateDebut == item.DateDebut && w.Periode.DateFin == item.DateFin).FirstOrDefault();
                            if (eng != null)
                            {
                                engagemenFusionAbs.Remove(eng);
                              
                                var pNP=periodNonParticipation.Where(p => p.DateDebutAdmissibilite == item.DateDebut && p.DateFinAdmissibilite == item.DateFin).FirstOrDefault();
                                if(pNP!=null)
                                {
                                    periodNonParticipation.Remove(pNP);
                                }
                                
                            }
                        }
                    }

              
                    if (engagemenFusionAbs.Any())
                    {
                        var resultChevauchement = ConstruireChevauchementPeriodeAbsEtNonParticipation(engagemenFusionAbs, periodNonParticipation);
                        if (resultChevauchement.SupprimerPeriodeAbs.Any())
                        {
                            foreach (var item in resultChevauchement.SupprimerPeriodeAbs)
                            {
                                engagementPratiqueFusionnes.Remove(item);
                            }
                        }
                        if (resultChevauchement.AjouterPeriodeAbs.Any())
                        {
                            foreach (var item in resultChevauchement.AjouterPeriodeAbs)
                            {
                                engagementPratiqueFusionnes.Add(item);
                            }
                        }
                    }
                                       
                    var extrant = TriEngagements(engagementPratiqueFusionnes, intrant.NumeroSequenceDispensateur,false);
                    result=CasNonParticipationNonTraite(periodNP, periodesFusionAbs, extrant, intrant.NumeroSequenceDispensateur);
                }
                else
                {

                    result= CasNonParticipationNonTraite(periodNP, periodesFusionAbs, engagementPratiqueFusionnes, intrant.NumeroSequenceDispensateur);
                }
            }
            else
            {
                result = CasNonParticipationNonTraite(periodNP, periodesFusionAbs, engagementPratiqueFusionnes, intrant.NumeroSequenceDispensateur);

            }

            #endregion


            #region Change Description Abs -->NPAR

           // ChangeDescriptionAbsence_NonParticipation(intrant, result, periodNonParticipation);
            ChangeDescriptionAbsence_NonParticipation(intrant, result, admissibiliteFacturer);

            #endregion

            result.ForEach(x => { if (x.Periode.DateFin.HasValue && x.Periode.DateFin.Value.Year == 2999) { x.Periode.DateFin = null; } });
            return result;


        }

        List<Entite.EngagementPratique> CasNonParticipationNonTraite(List<Entite.Periode> periodNP, List<Entite.Periode> periodesFusionAbs, List<Entite.EngagementPratique> engagementPratiqueFusionnes, long numeroSequenceDispensateur)
        {
            var per = periodNP.Except(periodesFusionAbs, new PeriodeComparer()).ToList();
            if (per.Any())
            {
                foreach (var item in per)
                {
                    //-Add NonParticipation
                    engagementPratiqueFusionnes.Add(CreerAbsenseAvis(item.DateDebut.Value, item.DateFin.Value));
                }

            }
 
           return TriEngagements(engagementPratiqueFusionnes, numeroSequenceDispensateur,true);
        }

        List<Entite.EngagementPratique> TriEngagements(List<Entite.EngagementPratique> engagementPratiqueFusionnes, long numeroSequenceDispensateur,bool nParNonTraite)
        {
            var comparPeriod = new PerCompare();
            engagementPratiqueFusionnes.ForEach(x => { if (!x.Periode.DateFin.HasValue) { x.Periode.DateFin = new DateTime(2999, 12, 30); } });
            var engagementPratiqueFusionnesTri = engagementPratiqueFusionnes.OrderByDescending(o => o.Periode, comparPeriod).ToList();
            engagementPratiqueFusionnesTri.ForEach(x => { if (x.Periode.DateFin.Value.Year == 2999) { x.Periode.DateFin = null; } });

 
            DateTime datedebutHistoriq= ObtenirDateDebutHistoriqueEngagementAbs(numeroSequenceDispensateur);
            if (engagementPratiqueFusionnesTri.Any() && !nParNonTraite)
            { engagementPratiqueFusionnesTri.Last().Periode.DateDebut = datedebutHistoriq < DateDebutPREM ? DateDebutPREM : datedebutHistoriq; }
         
            return engagementPratiqueFusionnesTri;
        }

        void ChangeDescriptionAbsence_NonParticipation(ObtenirEngagementPratiqueEntre intrant, List<Entite.EngagementPratique> result, List<AdmissibiliteFacturer> periodNonParticipation)
        {
            var lstItemsDescriptionAChanger = new List<Entite.EngagementPratique>();

            if (periodNonParticipation.Any())
            {
                foreach (var np in periodNonParticipation)
                {
                    var itemAChanger = result.Where(r => r.Periode.DateDebut == np.DateDebutAdmissibilite && r.Periode.DateFin == np.DateFinAdmissibilite).FirstOrDefault();
                    if (itemAChanger != null)
                    {
                        lstItemsDescriptionAChanger.Add(itemAChanger);
                    }
                }
                result.ForEach(x => { if (lstItemsDescriptionAChanger.Contains(x)) { x.Description = Constante.TypeNonParticipation; } });
            }
        }

        /// <summary>
        /// Permet d'obtenir les période de pratique d'un professionnel
        /// </summary>
        /// <param name="numeroSequenceDispensateur">Numéro de séquence du dispensateur</param>
        /// <returns>Période de pratique</returns>
        public DateTime? ObtenirPeriodePratiqueProfessionnel(long numeroSequenceDispensateur)
        {

            //Obtenir la période de pratique du professionnel
            var extrant = _periodePratique.ObtenirPeriodePratiqueProfessionnel(new ObtenirPeriodePratiqueProfessionnelEntre
            {
                NumeroSequenceDispensateur = numeroSequenceDispensateur,
                NumeroTypePratique = 1
            });

            if (extrant != null && extrant.InfoMsgTrait.Count > 1)
            {
                AjouterMessageErreur(extrant.InfoMsgTrait);
                throw new Exception("Erreur obtention période de pratique");
            }
            else if (extrant.DatePremiereFacturation.HasValue)
            {
                return extrant.DatePremiereFacturation.Value;
            }

            return null;

        }

        /// <summary>
        /// Permet d'obtenir les dérogations
        /// </summary>
        /// <param name="numeroSequenceDispensateur">Numéro de séquence du dispensateur</param>
        /// <returns>Liste des dérogations</returns>
        public List<Entite.EngagementPratique> ObtenirDerogations(long numeroSequenceDispensateur)
        {
            var extrant = _derogation.ObtenirDerogationProfessionnel(
                new ObtenirDerogationsProfessionnelSanteEntre
                {
                    NumeroSequentielDispensateur = numeroSequenceDispensateur
                });


            var extrantInactif = _derogation.ObtenirDerogationProfessionnel(
                new ObtenirDerogationsProfessionnelSanteEntre
                {
                    NumeroSequentielDispensateur = numeroSequenceDispensateur
                    ,
                    IndicateurDerogationInactive = "O"
                });
            var itemAnn = false;
            extrantInactif.Derogations.ForEach(x => { if (x.Statut == OutilCommun.Constantes.StatutDerogation.StatutAnnuler) { itemAnn = true; } });

            var derogations = new List<Entite.EngagementPratique>();

            //PRE 040 - derogations actives            
            if (extrant != null && extrant.InfoMsgTrait.Count == 0 && !itemAnn)
            {
                foreach (EntiteDerogation.Derogation derogation in extrant.Derogations)
                {
                    derogations.Add(new Entite.EngagementPratique
                    {
                        NumeroSequence = derogation.NumeroSequentiel,
                        CodeRegion = string.Empty,
                        Description = OutilCommun.Constantes.DescriptionTypeEngagement.TypeDerogation,
                        Historiques = ObtenirLesHistoriquesDerogation(derogation, numeroSequenceDispensateur),
                        Periode = new Entite.Periode
                        {
                            DateDebut = derogation.DateDebut,
                            DateFin = derogation.DateFin
                        },
                        Territoire = new Entite.InformationTerritoire(),
                        Type = derogation.Type
                    });
                }


            }
            else if (extrant != null & extrant.InfoMsgTrait.Count > 0)
            {
                AjouterMessageErreur(extrant.InfoMsgTrait);
            }

            // Retourner seulement les dérogations qui n'ont pas de statut "Annuler"
            return derogations.Where(x => !x.Historiques.Any(z => z.Statut == OutilCommun.Constantes.StatutDerogation.StatutAnnuler)).ToList();

        }

        /// <summary>
        /// Permet d'obtenir les avis de conformités
        /// </summary>
        /// <param name="numeroSequenceDispensateur">Numéro de séquence du dispensateur</param>
        /// <returns>Liste des avis de conformités</returns>
        public List<Entite.EngagementPratique> ObtenirLesAvisConformite(long numeroSequenceDispensateur)
        {

            var avisConformites = new List<Entite.EngagementPratique>();
            var historiques = default(List<Entite.Historique>);

            var extrant = _avisConformite.ObtenirLesAvisConformite(
                new ObtenirLesAvisConformiteEntre { NumeroSequentielDispensateur = numeroSequenceDispensateur
                ,IndicateurAttenteTransmission="N" //-PRE 040 ; recuperation des avis émis(transmis)
                });

            if (extrant != null && extrant.InfoMsgTrait.Count > 0)
            {
                // Ne rien faire selon le dossier fonctionnel

            }
            else if (extrant != null && extrant.ListeAvisConformite.Count > 0)
            {

                foreach (EntiteAvisConformite.AvisConformite avis in extrant.ListeAvisConformite)
                {
                    //Obtenir le nom du territoire pour chacun des avis 

                    var nomTerritoire = _obtenirNomTerritoireFactory.Instancier(avis.TypeLieuGeographique).ObtenirNomTerritoire(
                        new ObtenirNomTerritoireEntre
                        {
                            Code = avis.CodeLieuGeographique,
                            DateDebutPratique = avis.DateDebutEngagement,
                            NumeroSequentiel = avis.NumeroSequentielRegroupement,
                            Type = avis.TypeLieuGeographique,
                            CodeRSS = avis.CodeRegion
                        });

                    // Obtention des historique autre que des suspension
                    historiques = ObtenirLesHistoriquesAvisNonSuspendu(avis, new List<Entite.Historique>()).ToList();

                    // Obtention des historique de suspension
                    historiques.AddRange(ObtenirLesHistoriquesAvisSuspendu(avis));

                    // Complétion de l'historique après l'obtention des suspensions
                    historiques = ObtenirLesHistoriquesAvisNonSuspendu(avis, historiques).OrderByDescending(x => x.Periode.DateDebut).ToList();
                    var dateDebEngag = avis.DateDebutEngagement < DateDebutPREM ? DateDebutPREM : avis.DateDebutEngagement;
                    if (historiques.Any())
                    {
                        historiques.LastOrDefault().Periode.DateDebut = dateDebEngag < historiques.LastOrDefault().Periode.DateFin ? dateDebEngag : historiques.LastOrDefault().Periode.DateDebut;
                    }

                    //Création de la liste des engagements de pratique
                    avisConformites.Add(new Entite.EngagementPratique
                    {
                        NumeroSequence = avis.NumeroSequentielEngagement,
                        CodeRegion = avis.CodeRegion,
                        Description = OutilCommun.Constantes.DescriptionTypeEngagement.TypeAvisConformite,
                        Historiques = historiques,
                        Periode = new Entite.Periode
                        {
                            //-PRE040                           
                            DateDebut = dateDebEngag,
                            DateFin = historiques.Where(w => w.Statut == OutilCommun.Constantes.StatutAvisConformite.StatutAutoriser).Any() ? historiques.FirstOrDefault().Periode.DateFin : avis.DateFinEngagement
                        },
                        Territoire = new Entite.InformationTerritoire()
                        {
                            Nom = nomTerritoire.Nom,
                            Type = string.IsNullOrEmpty(nomTerritoire.TypeLieuGeographique) && avis.TypeLieuGeographique == OutilCommun.Constantes.LieuxGeographiques.RegionSocioSanitaire ?
                                    OutilCommun.Constantes.LieuxGeographiques.RegionSocioSanitaire :
                                    nomTerritoire.TypeLieuGeographique,
                            NumeroSequentielRegroupement = avis.NumeroSequentielRegroupement,
                            CodeLieuGeographique = avis.CodeLieuGeographique
                        }
                    });

                }


            }

            // Retourner seulement les avis de conformités qui n'ont pas de statut "Annuler"
            return avisConformites.Where(x => !x.Historiques.Any(z => z.Statut == OutilCommun.Constantes.StatutAvisConformite.StatutAnnuler)).ToList();

        }

        /// <summary>
        /// Permet d'obtenir les autorisations
        /// </summary>
        /// <param name="numeroSequenceDispensateur">Numéro de séquence du dispensateur</param>
        /// <returns>Liste des autorisations</returns>
        public List<Entite.EngagementPratique> ObtenirAutorisations(long numeroSequenceDispensateur)
        {

            var extrant = _autorisation.ObtenirAutorisationPREMQ(
                new LogiqueAffairePrametres.ObtenirLesAutorisationsProfessionnelEntre()
                { NumeroSequentielDispensateur = numeroSequenceDispensateur });

            var autorisations = new List<Entite.EngagementPratique>();

            if (extrant != null & extrant.InfoMsgTrait.Count == 0)
            {
                ObtenirLesAvisRevoques();

                autorisations = new List<Entite.EngagementPratique>(
                    from autorisation in extrant.Autorisations
                    select new Entite.EngagementPratique
                    {
                        NumeroSequence = autorisation.NumeroSequence,
                        CodeRegion = autorisation.CodeLieuGeographique,
                        Description = OutilCommun.Constantes.DescriptionTypeEngagement.TypeAutorisation,
                        Historiques = new List<Entite.Historique>(),
                        Periode = new Entite.Periode
                        {
                            DateDebut = autorisation.DateDebut,
                            DateFin = autorisation.DateFin
                        },
                        Territoire = new Entite.InformationTerritoire()
                    });


            }
            else if (extrant != null & extrant.InfoMsgTrait.Count > 0)
            {
                AjouterMessageErreur(extrant.InfoMsgTrait);
            }

            return autorisations;

        }


        //-25
        /// <summary>
        /// Obtenir les informations sur la relation dispensateur individu
        /// </summary>
        /// <param name="intrant">Les critères de recherche</param>
        /// <returns>Une liste avec les informations des professionnels</returns>
        /// <remarks></remarks>
        public ObtenirDispensateurIndividuSorti ObtenirInformationProfessionnel(ObtenirDispensateurIndividuEntre intrant) => _professionnel.ObtenirInformationProfessionnel(intrant);

        /// <summary>
        /// Permet l'obtention des périodes d'engagement et absences du professionnel de la santé
        /// </summary>
        /// <param name="intrant"></param>
        /// <returns>Liste des engagements et absences d'avis></returns>
        public ObtenirVuePeriodeEngagementSorti ObtenirPeriodeEngagementsAbsenceProfessionnel(ObtenirVuePeriodeEngagementEntre intrant) => _engagementAbence.ObtenirPeriodeEngagementsAbsenceProfessionnel(intrant);

        /// <summary>
        /// Permet d'obtenir les periodes de non participation du medecin omnipraticien
        /// </summary>
        /// <param name="numeroDispensateur"></param>
        /// <param name="numeroClasseDispensateur"></param>
        /// <param name="datePrevue"></param>
        /// <returns></returns>
        public List<AdmissibiliteFacturer> ObtenirlesPeriodesNonParticipation(long numeroDispensateur, int numeroClasseDispensateur, DateTime datePrevue)
        {
            List<AdmissibiliteFacturer> periodesNonParticipation = new List<AdmissibiliteFacturer>();
            var admissibilite = _admissibilite.VerifierAdmissibiliteProfessionnel(new VerifierAdmissibiliteProfessionnelFacturerEntre
            {
                NumeroDispensateur = (int)numeroDispensateur,
                NumeroClasse = numeroClasseDispensateur,
                DateDebutPeriode = datePrevue,
                DateFinPeriode = DateTime.MaxValue
            });

            if (admissibilite != null && admissibilite.PeriodesAdmissibilite.Any())
            {
                periodesNonParticipation = admissibilite.PeriodesAdmissibilite.Where(p => p.StatutAdmissibilite == "NA" && p.CodeRaisonNonAdmissibilite == "NPAR")
                                                                             .OrderBy(o => o.DateDebutAdmissibilite).ToList();
            }
            return periodesNonParticipation;

        }

        /// <summary>
        /// ajout ou suppression de periodes d'absence d'avis dans l'historique
        /// </summary>
        /// <param name="periodesAbs"></param>
        /// <param name="periodesNPAR"></param>
        /// <returns></returns>
        public ChevauchementPeriode ConstruireChevauchementPeriodeAbsEtNonParticipation(List<Entite.EngagementPratique> periodesAbs, List<AdmissibiliteFacturer> periodesNPAR)
        {

            var result = new ChevauchementPeriode();

            //----
            periodesAbs.ForEach(f => { if (f.Periode.DateFin.HasValue && f.Periode.DateFin.Value == new DateTime(2999, 12, 30)) { f.Periode.DateFin = null; } });
            periodesNPAR.ForEach(n => { if (n.DateFinAdmissibilite.HasValue && n.DateFinAdmissibilite.Value == new DateTime(2999, 12, 30)) { n.DateFinAdmissibilite = null; } });
            //----

            foreach (var npar in periodesNPAR)
            {
                var maxdateDebAbs = periodesAbs.Max(m => m.Periode.DateDebut).Value;
                var maxdateFinAbs = periodesAbs.Select(m => m.Periode.DateFin).DefaultIfEmpty().Max();
                var maxItem = periodesAbs.Find(p => p.Periode.DateDebut == maxdateDebAbs);
                foreach (var abs in periodesAbs)
                {

                    if (npar.DateDebutAdmissibilite > abs.Periode.DateDebut.Value)
                    {

                        if (!npar.DateFinAdmissibilite.HasValue && !abs.Periode.DateFin.HasValue)
                        {
                            //-RG2                                
                            //-creation absence avis
                            var absAvis = CreerAbsenseAvis(abs.Periode.DateDebut.Value, npar.DateDebutAdmissibilite.AddDays(-1));
                            result.AjouterPeriodeAbs.Add(absAvis);

                        }

                        //-RG4
                        if (npar.DateFinAdmissibilite.HasValue && !abs.Periode.DateFin.HasValue)
                        {
                            //-creation de deux avis
                            var absAvis1 = CreerAbsenseAvis(abs.Periode.DateDebut.Value, npar.DateDebutAdmissibilite.AddDays(-1));
                            //var absAvis2 = CreerAbsenseAvis(npar.DateFinAdmissibilite.Value.AddDays(1), null);
                            var absAvis2 = CreerAbsenseAvis(npar.DateFinAdmissibilite.Value.AddDays(1), new DateTime(2999, 12, 30));
                            result.AjouterPeriodeAbs.Add(absAvis1);
                            result.AjouterPeriodeAbs.Add(absAvis2);
                        }
                        //-RG
                        if (npar.DateFinAdmissibilite.HasValue && abs.Periode.DateFin.HasValue)
                        {
                            //RG5
                            if (npar.DateFinAdmissibilite > abs.Periode.DateFin.Value && abs.Periode.DateFin.Value == maxdateFinAbs && maxItem.Periode.DateFin.HasValue)
                            {
                                //creation absence avis
                                var absAvis = CreerAbsenseAvis(abs.Periode.DateDebut.Value, npar.DateDebutAdmissibilite.AddDays(-1));
                                result.AjouterPeriodeAbs.Add(absAvis);

                            }
                            //-RG6
                            if (npar.DateFinAdmissibilite < abs.Periode.DateFin.Value)
                            {
                                //-creation de deux avis
                                var absAvis1 = CreerAbsenseAvis(abs.Periode.DateDebut.Value, npar.DateDebutAdmissibilite.AddDays(-1));
                                var absAvis2 = CreerAbsenseAvis(npar.DateFinAdmissibilite.Value.AddDays(1), abs.Periode.DateFin.Value);
                                result.AjouterPeriodeAbs.Add(absAvis1);
                                result.AjouterPeriodeAbs.Add(absAvis2);
                            }
                        }

                        if (!npar.DateFinAdmissibilite.HasValue && abs.Periode.DateFin.HasValue)
                        {

                            //-RG10
                            if (npar.DateDebutAdmissibilite > abs.Periode.DateDebut && maxdateDebAbs == abs.Periode.DateDebut)
                            {
                                //creation absence avis
                                var absAvis = CreerAbsenseAvis(abs.Periode.DateDebut.Value, npar.DateDebutAdmissibilite.AddDays(-1));
                                result.AjouterPeriodeAbs.Add(absAvis);
                            }
                        }

                    }
                    else
                    {

                        if (!npar.DateFinAdmissibilite.HasValue && !abs.Periode.DateFin.HasValue)
                        {
                            ////-RG1
                            if (npar.DateDebutAdmissibilite < abs.Periode.DateDebut.Value)
                            {
                                //-Suprresion de l'avis d'absence
                                result.SupprimerPeriodeAbs.Add(abs);
                            }
                        }

                        //-RG3
                        if (npar.DateDebutAdmissibilite < abs.Periode.DateDebut.Value && npar.DateFinAdmissibilite.HasValue && !abs.Periode.DateFin.HasValue)
                        {
                            //creation absence avis                            
                            var absAvis = CreerAbsenseAvis(npar.DateFinAdmissibilite.Value.AddDays(1), new DateTime(2999, 12, 30));
                            result.AjouterPeriodeAbs.Add(absAvis);
                        }

                        if (npar.DateDebutAdmissibilite < abs.Periode.DateDebut && npar.DateFinAdmissibilite.HasValue && abs.Periode.DateFin.HasValue)
                        {
                            //-RG7
                            if (npar.DateFinAdmissibilite < abs.Periode.DateFin.Value)
                            {
                                //creation absence avis
                                var absAvis = CreerAbsenseAvis(npar.DateFinAdmissibilite.Value.AddDays(1), abs.Periode.DateFin.Value);
                                result.AjouterPeriodeAbs.Add(absAvis);
                            }
                        }

                        //-RG8
                        if (npar.DateDebutAdmissibilite < abs.Periode.DateDebut && abs.Periode.DateFin < npar.DateFinAdmissibilite)
                        {
                            //-Suprresion de l'avis d'absence
                            result.SupprimerPeriodeAbs.Add(abs);
                        }

                        if (!npar.DateFinAdmissibilite.HasValue && abs.Periode.DateFin.HasValue)
                        {
                            //-RG9
                            if (npar.DateDebutAdmissibilite < abs.Periode.DateDebut)
                            {
                                //-Suprresion de l'avis d'absence
                                result.SupprimerPeriodeAbs.Add(abs);
                            }
                        }


                    }
                }
            }
            return result;

        }



        /// <summary>
        /// permet d'obtenir la date de debut dans l'historique d'un avis en particulier
        /// </summary>
        /// <param name="intrantVue"></param>
        /// <param name="statutavis"></param>        
        /// <returns>si true,on charge la date de debut du statut </returns>
       // public bool ObtenirDateDebuthistoriqueDansAvis(ObtenirVuePeriodeEngagementSorti intrantVue,long numeroSequentielDispensateur, EntiteAvisConformite.StatutAvisConformite statutavis)
        public bool ObtenirDateDebuthistoriqueDansAvis(ObtenirVuePeriodeEngagementSorti intrantVue, EntiteAvisConformite.StatutAvisConformite statutavis)
        {
            bool resultat = false;          
            var resultPeriodeEngagementSorti = intrantVue;
            DateTime dtPremVue = new DateTime(2004, 1, 1);
            var lstAbs= resultPeriodeEngagementSorti.EngagementsPeriode.Where(a => a.DateFinEngagement < statutavis.DateDebutStatutEngagement &&
                                                                                   a.DateFinEngagement >= dtPremVue );
            
            resultat =  lstAbs.Any(); 
            return resultat;
        }
            #endregion

                #region Méthodes privées

        private List<Entite.EngagementPratique> FusionnerEngagements(DateTime? datePremiereFacturation)
        {

            var engagementFusionner = new List<Entite.EngagementPratique>();

            engagementFusionner.AddRange(AvisConformites);
            engagementFusionner.AddRange(Derogations);
            engagementFusionner.AddRange(Autorisations);

            engagementFusionner = engagementFusionner.OrderByDescending(x => x.Periode.DateDebut.Value).ToList();

            //Si la date de première facturation obtenue précédemment est antérieure à la date du premier engagement (le plus ancien)
            if (engagementFusionner.Any() &&
                datePremiereFacturation.HasValue &&
                datePremiereFacturation.Value < engagementFusionner.Last().Periode.DateDebut.Value)
            {
                engagementFusionner.Add(new Entite.EngagementPratique
                {
                    NumeroSequence = CreerNombreAleatoire(),
                    CodeRegion = string.Empty,
                    Description = OutilCommun.Constantes.DescriptionTypeEngagement.TypeAbsenceAvis,
                    Historiques = new List<Entite.Historique>(),
                    Periode = new Entite.Periode
                    {
                        DateDebut = datePremiereFacturation.Value,
                        DateFin = engagementFusionner.Last().Periode.DateDebut.Value.AddDays(-1)

                    },
                    Territoire = new Entite.InformationTerritoire()
                });

            }

            var absenceAvisAjoutes = new Dictionary<Entite.EngagementPratique, int>();
            int positionAjout = 0;
            Entite.EngagementPratique engagementCourant = null;
            Entite.EngagementPratique engagementProchain = null;



            for (int i = 0; i <= engagementFusionner.Count - 2; i++) // -2 car on ne doit pas tomber sur la dernière occurrence
            {
                engagementCourant = engagementFusionner[i];
                engagementProchain = engagementFusionner[i + 1];


                if (engagementProchain.Periode.DateFin.HasValue &&
                    engagementProchain.Periode.DateFin.Value.AddDays(1) != engagementCourant.Periode.DateDebut.Value)
                {
                    positionAjout += 1;

                    absenceAvisAjoutes.Add(CreerAbsenseAvis(engagementProchain.Periode.DateFin.Value.AddDays(1),
                                                            engagementCourant.Periode.DateDebut.Value.AddDays(-1)), i + positionAjout);

                }

            }

            foreach (KeyValuePair<Entite.EngagementPratique, int> absenceAvis in absenceAvisAjoutes)
            {
                engagementFusionner.Insert(absenceAvis.Value, absenceAvis.Key);
            }

            // Ajouter une absence d'avis s'il n'y a pas d'engagement actif en cours.
            if (engagementFusionner.Any() &&
                engagementFusionner.First().Periode.DateFin.HasValue &&
                engagementFusionner.First().Periode.DateFin < DateTime.Now)
            {
                engagementFusionner.Insert(0, CreerAbsenseAvis(engagementFusionner.First().Periode.DateFin.Value.AddDays(1), null));
            }


            // Ajouter les avis révoqués à la liste 
            engagementFusionner.AddRange(AvisRevoques);

            if (!engagementFusionner.Any() && datePremiereFacturation.HasValue)
            {
                engagementFusionner.Add(CreerAbsenseAvis(DateDebutPREM, datePremiereFacturation.Value));
            }



            return engagementFusionner;

        }

        private void ObtenirLesAvisRevoques()
        {
            var premierStatut = new Entite.Historique();
            var engagementPratiquesNonRevoques = new List<Entite.EngagementPratique>();

            //Retirer de la liste des avis de conformité retourné, tous les avis 
            //dont le statut le plus récent est « Révoqué »
            foreach (Entite.EngagementPratique engagement in AvisConformites)
            {
                if (engagement.Historiques.Any())
                {
                    premierStatut = engagement.Historiques.OrderByDescending(x => x.Periode.DateDebut).First();
                    if (premierStatut.Statut == "Révoqué")
                    {
                        engagement.Description = OutilCommun.Constantes.DescriptionTypeEngagement.TypeAvisRevoque;
                        engagement.Historiques = new List<Entite.Historique>(); // Permet de ne pas afficher l'historique dans PL_PREM
                        //Ajouter l'avis trouvé à la liste des avis révoqués
                        AvisRevoques.Add(engagement);
                    }
                    else
                    {
                        //Créer une liste temporaire contenant les avis non révoqué
                        engagementPratiquesNonRevoques.Add(engagement);
                    }

                }
                else //-PRE 040 -
                {
                    //Créer une liste temporaire contenant les avis non révoqué
                    engagementPratiquesNonRevoques.Add(engagement);
                }

            }

            //Utiliser la liste temporaire des avis pour mettre à jour la liste des engagements à faire afficher
            AvisConformites = new List<Entite.EngagementPratique>(engagementPratiquesNonRevoques);


        }

        private string ConvertirValeurStatut(string statutEngagement)
        {

            switch (statutEngagement.ToUpper())
            {
                case OutilCommun.Constantes.StatutAvisConformite.StatutAutoriser:
                    return "Autorisé";
                case OutilCommun.Constantes.StatutAvisConformite.StatutSuspendu:
                    return "Suspendu";
                case OutilCommun.Constantes.StatutAvisConformite.StatutTerminer:
                    return "Terminé";
                case OutilCommun.Constantes.StatutAvisConformite.StatutRevoquer:
                    return "Révoqué";
                default:
                    return statutEngagement;
            }

        }

        private Entite.EngagementPratique CreerAbsenseAvis(DateTime dateDebut, DateTime? dateFin)
        {

            return new Entite.EngagementPratique
            {
                NumeroSequence = CreerNombreAleatoire(),
                Description = OutilCommun.Constantes.DescriptionTypeEngagement.TypeAbsenceAvis,
                Periode = new Entite.Periode
                {
                    DateDebut = dateDebut,
                    DateFin = dateFin
                },
                CodeRegion = string.Empty,
                Historiques = new List<Entite.Historique>(),
                Territoire = new Entite.InformationTerritoire()
            };
        }
       

        private IEnumerable<Entite.Historique> ObtenirLesHistoriquesAvisNonSuspendu(EntiteAvisConformite.AvisConformite avis, List<Entite.Historique> historiquesAvecSuspension)
        {


            var historiques = new List<Entite.Historique>();

            if (historiquesAvecSuspension.Any()) //Permet de compléter l'historique après l'ajout des suspension
            {
                historiques = historiquesAvecSuspension.OrderBy(x => x.Periode.DateDebut).ToList();
            }

            if (avis.ListeStatutAvisConformite != null && avis.ListeStatutAvisConformite.Count > 0)
            {
                foreach (var statutAvisConformite in avis.ListeStatutAvisConformite.OrderBy(x => x.DateDebutStatutEngagement))
                {
 
                    var dateDebut = statutAvisConformite.DateDebutStatutEngagement<DateDebutPREM? DateDebutPREM: statutAvisConformite.DateDebutStatutEngagement;

                    var dateFin = statutAvisConformite.DateFinStatutEngagement;

                    for (var datePrem = dateDebut; datePrem <= (dateFin.HasValue ? dateFin.Value : DateTime.Today); datePrem = datePrem.AddDays(1))
                    {
                        if (!historiques.Any(x => x.Periode.DateDebut == datePrem) && !historiques.Any(x => x.Periode.DateFin == dateFin)) //Permet de ne pas ajouter 2 fois le même historique si on utilise la liste "historiquesAvecSuspension" 
                        {
                            if (dateFin.HasValue)
                            {
                                if (datePrem < DateDebutPREM)
                                {
                                    historiques.Add(AjouterHistoriqueAvisConformite(avis, statutAvisConformite, DateDebutPREM));

                                    datePrem = DateDebutPREM;
                                }
                                else if ((historiques.Any() && historiques.Last().Periode.DateFin.HasValue && datePrem == historiques.Last().Periode.DateFin.Value.AddDays(1)) || (!historiques.Any()))
                                {
                                    historiques.Add(AjouterHistoriqueAvisConformite(avis, statutAvisConformite, datePrem));
                                }
                            }
                            else
                            {
                                if (datePrem < DateTime.Today && historiques.Any() && historiques.Last().Periode.DateFin.HasValue && datePrem == historiques.Last().Periode.DateFin.Value.AddDays(1))
                                {
                                    historiques.Add(AjouterHistoriqueAvisConformite(avis, statutAvisConformite, datePrem));
                                }
                                else if (datePrem < DateTime.Today && !historiques.Any())
                                {
                                    historiques.Add(AjouterHistoriqueAvisConformite(avis, statutAvisConformite, datePrem));
                                }
                            }
                        }


                    }
                }
            }

            if (!historiquesAvecSuspension.Any())
            {
                historiques = historiques.Where(x => x.Statut != "Suspendu").ToList();
            }


            return historiques;

        }


        private IEnumerable<Entite.Historique> ObtenirLesHistoriquesDerogation(EntiteDerogation.Derogation derogation, long numeroSequenceDispensateur)
        {
            var historiques = new List<Entite.Historique>();


            var dateFin = derogation.DateFin;

            for (var datePrem = derogation.DateDebut; datePrem <= (dateFin.HasValue ? dateFin.Value : DateTime.Today); datePrem = datePrem.AddDays(1))
            {
                if (dateFin.HasValue)
                {
                    if (datePrem < DateDebutPREM)
                    {
                        historiques.Add(AjouterHistoriqueDerogation(derogation, DateDebutPREM, numeroSequenceDispensateur));

                        datePrem = DateDebutPREM;
                    }
                    else if ((historiques.Any() && historiques.Last().Periode.DateFin.HasValue && datePrem == historiques.Last().Periode.DateFin.Value.AddDays(1)) || (!historiques.Any()))
                    {
                        historiques.Add(AjouterHistoriqueDerogation(derogation, datePrem, numeroSequenceDispensateur));
                    }
                }
                else
                {
                    if (datePrem < DateTime.Today && historiques.Any() && historiques.Last().Periode.DateFin.HasValue && datePrem == historiques.Last().Periode.DateFin.Value.AddDays(1))
                    {
                        historiques.Add(AjouterHistoriqueDerogation(derogation, datePrem, numeroSequenceDispensateur));
                    }
                    else if (datePrem < DateTime.Today && !historiques.Any())
                    {
                        historiques.Add(AjouterHistoriqueDerogation(derogation, datePrem, numeroSequenceDispensateur));
                    }
                }

            }

            historiques = historiques.OrderByDescending(x => x.Periode.DateDebut.Value).ToList();

            if (historiques.Any())
            {
                foreach (var historique in historiques.Where(x => x.Statut == "Terminé"))
                {
                    if (historiques.First() != historique)
                    {
                        historique.Statut = string.Empty;
                        historique.RaisonStatut = string.Empty;
                    }
                }
            }

            return historiques;


        }

        private IEnumerable<Entite.Historique> ObtenirLesHistoriquesAvisSuspendu(EntiteAvisConformite.AvisConformite avis)
        {

            var historiques = default(List<Entite.Historique>);
            var statutsSuspendu = default(List<RespectEngagementProfs>);

            var extrantFacturation = _journeeFacturation.CalculerNombreJourneeFacturation(new CalculerNbrJrFactProfsEntre()
            {
                NumerosSequentielsProfs = new List<long>() { avis.NumeroSequentielDispensateur.Value },
                DateDebut = avis.DateDebutEngagement,
                DateFin = avis.DateFinEngagement,
                ObtenirListeRespectEngag = true,
                ObtenirListeInter = false,
                ObtenirListeIntra = false,
                ObtenirListeRPPR = false
            });


            statutsSuspendu = new List<RespectEngagementProfs>(extrantFacturation.RespectsEngagementProfs
                                                                        .Where(x => x.IdentifiantPourcentage == OutilCommun.Constantes.TypeRespectEngag.RESPE_AVIS_SUSPD));


            historiques = new List<Entite.Historique>(from statutSuspendu in statutsSuspendu
                                                      select new Entite.Historique()
                                                      {
                                                          Periode = new Entite.Periode()
                                                          {
                                                              DateDebut = statutSuspendu.DdEngagement,
                                                              DateFin = statutSuspendu.DfEngagement
                                                          },
                                                          Statut = ConvertirValeurStatut(OutilCommun.Constantes.StatutAvisConformite.StatutSuspendu),
                                                          RaisonStatut = TrouverCodeRaisonStatut(avis.ListeStatutAvisConformite, statutSuspendu.DdEngagement, statutSuspendu.DfEngagement),
                                                          NombreJourEngagement = statutSuspendu.NombreJours,
                                                          PourcentageEffectuer = statutSuspendu.Pourcentage,
                                                          TotalJourFacturer = statutSuspendu.JoursTotal,
                                                          EstNonRespectEntente = statutSuspendu.IndicateurRespectEngag == "O" ? false : true
                                                      });

            return historiques;
        }

        private string TrouverCodeRaisonStatut(List<EntiteAvisConformite.StatutAvisConformite> statuts, DateTime? dateDebut, DateTime? dateFin)
        {
            var statut = statuts.FirstOrDefault(x => (x.DateDebutStatutEngagement <= dateDebut && dateDebut <= x.DateFinStatutEngagement) ||
                                                     (x.DateDebutStatutEngagement <= dateFin && dateFin <= x.DateFinStatutEngagement));

            return statut != null ? statut.CodeRaisonStatutEngagement : string.Empty;
        }

        private Entite.Historique AjouterHistoriqueAvisConformite(EntiteAvisConformite.AvisConformite avis, EntiteAvisConformite.StatutAvisConformite statut, DateTime dateDebut)
        {

            DateTime? dateFinPeriode = default(DateTime?);

            if (avis.DateFinEngagement.HasValue &&
               statut.StatutEngagement == OutilCommun.Constantes.StatutAvisConformite.StatutTerminer &&
               dateDebut == avis.DateFinEngagement.Value.AddDays(1))
            {
                return new Entite.Historique
                {
                    Periode = new Entite.Periode
                    {
                        DateDebut = dateDebut,
                        DateFin = dateFinPeriode
                    },
                    Statut = ConvertirValeurStatut(statut.StatutEngagement),
                    RaisonStatut = statut.CodeRaisonStatutEngagement,
                    NombreJourEngagement = null,
                    TotalJourFacturer = null,
                    PourcentageEffectuer = null,
                    EstNonRespectEntente = false
                };
            }
            else
            {
                dateFinPeriode = DefinirDateFinPREM(dateDebut, statut.DateFinStatutEngagement);

                var extrantFacturation = _journeeFacturation.CalculerNombreJourneeFacturation(new CalculerNbrJrFactProfsEntre()
                {
                    NumerosSequentielsProfs = new List<long>() { avis.NumeroSequentielDispensateur.Value },
                    DateDebut = dateDebut,
                    DateFin = dateFinPeriode,
                    ObtenirListeRespectEngag = true,
                    ObtenirListeInter = false,
                    ObtenirListeIntra = false,
                    ObtenirListeRPPR = false
                });

                //var identifiantPourcentage = string.Empty;



                if (extrantFacturation.InfoMsgTrait.Any())
                {
                    throw new Exception(extrantFacturation.InfoMsgTrait.First().TxtMsgFran);
                }

                //identifiantPourcentage = statut.StatutEngagement == OutilCommun.Constantes.StatutAvisConformite.StatutSuspendu ?
                //                         OutilCommun.Constantes.TypeRespectEngag.RESPE_AVIS_SUSPD :
                //                         OutilCommun.Constantes.TypeRespectEngag.RESPE_AVIS;

                var respectEngagement = extrantFacturation.RespectsEngagementProfs
                                            .FirstOrDefault(x => x.IdentifiantPourcentage == OutilCommun.Constantes.TypeRespectEngag.RESPE_AVIS);

                return new Entite.Historique
                {
                    Periode = new Entite.Periode
                    {
                        DateDebut = dateDebut,
                        DateFin = dateFinPeriode
                    },
                    Statut = ConvertirValeurStatut(statut.StatutEngagement),
                    RaisonStatut = statut.CodeRaisonStatutEngagement,
                    NombreJourEngagement = respectEngagement != null ? respectEngagement.NombreJours : 0,
                    TotalJourFacturer = respectEngagement != null ? respectEngagement.JoursTotal : 0,
                    PourcentageEffectuer = respectEngagement != null ? respectEngagement.Pourcentage : 0,
                    EstNonRespectEntente = respectEngagement.IndicateurRespectEngag == "O" ? false : true
                };

            }

        }

        private Entite.Historique AjouterHistoriqueDerogation(EntiteDerogation.Derogation derogation, DateTime dateDebut, long numeroSequenceDispensateur)
        {
            DateTime? dateFinPeriode = DefinirDateFinPREM(dateDebut, derogation.DateFin);

            var extrantFacturation = _journeeFacturation.CalculerNombreJourneeFacturation(new CalculerNbrJrFactProfsEntre()
            {
                NumerosSequentielsProfs = new List<long>() { numeroSequenceDispensateur },
                DateDebut = dateDebut,
                DateFin = dateFinPeriode,
                ObtenirListeRespectEngag = true,
                ObtenirListeInter = false,
                ObtenirListeRPPR = false,
                ObtenirListeIntra = false
            });


            if (extrantFacturation.InfoMsgTrait.Any())
            {
                throw new Exception(extrantFacturation.InfoMsgTrait.First().TxtMsgFran);
            }


            var respectEngagement = default(PRE_Entites_cpo.Pratique.Entite.RespectEngagementProfs);

            if (derogation.Type == OutilCommun.Constantes.TypeDerogation.InstanceVocationNational)
            {
                respectEngagement = extrantFacturation.RespectsEngagementProfs.FirstOrDefault(x => x.IdentifiantPourcentage == OutilCommun.Constantes.TypeRespectEngag.RESPE_DEROG_IVN);
            }
            else if (derogation.Type == OutilCommun.Constantes.TypeDerogation.Depannage)
            {
                respectEngagement = extrantFacturation.RespectsEngagementProfs.FirstOrDefault(x => x.IdentifiantPourcentage == OutilCommun.Constantes.TypeRespectEngag.RESPE_DEROG_DPNAG);
            }


            return new Entite.Historique
            {
                Periode = new Entite.Periode
                {
                    DateDebut = dateDebut,
                    DateFin = DefinirDateFinPREM(dateDebut, derogation.DateFin)
                },
                Statut = ConvertirValeurStatut(derogation.Statut),
                RaisonStatut = derogation.CodeRaisonStatut,
                NombreJourEngagement = respectEngagement != null ? respectEngagement.NombreJours : 0,
                TotalJourFacturer = respectEngagement != null ? respectEngagement.JoursTotal : 0,
                PourcentageEffectuer = respectEngagement != null ? respectEngagement.Pourcentage : 0,
                EstNonRespectEntente = respectEngagement.IndicateurRespectEngag == "O" ? false : true
            };


        }

        private DateTime? DefinirDateFinPREM(DateTime dateDebut, DateTime? dateFin)
        {

            // Si la date de début de la période se situe entre le 1 mars et le 31 décembre de l'année actuel de la date de début
            // alors rechercher la date de fin avec une année de plus sinon garder l'année actuel de la date de début
            var dateFinPremSelonAnnee =
            (dateDebut >= new DateTime(dateDebut.Year, 3, 1)) && (dateDebut <= new DateTime(dateDebut.Year, 12, 31)) ?
            ObtenirDateFinPREMSelonAnne(dateDebut.Year + 1) :
            ObtenirDateFinPREMSelonAnne(dateDebut.Year);

            if (dateFin.HasValue)
            {

                if (dateFin.Value > dateFinPremSelonAnnee)
                {
                    return dateFinPremSelonAnnee;
                }
                else
                {
                    return dateFin;
                }

            }
            else if (dateFinPremSelonAnnee <= DateTime.Today)
            {
                return dateFinPremSelonAnnee;
            }
            else
            {
                return null;
            }

        }

        private static DateTime ObtenirDateFinPREMSelonAnne(int annee)
        {
            return DateTime.IsLeapYear(annee) ? new DateTime(annee, 2, 29) : new DateTime(annee, 2, 28);
        }

        private bool ValiderEngagementSituerDansAnneePREM(EntiteAvisConformite.StatutAvisConformite statutAvisConformite,
                                                          DateTime dateDebutAnneePREM,
                                                          DateTime dateFinAnneePREM)
        {
            if (dateDebutAnneePREM <= statutAvisConformite.DateDebutStatutEngagement && statutAvisConformite.DateDebutStatutEngagement <= dateFinAnneePREM &&
                dateDebutAnneePREM <= statutAvisConformite.DateFinStatutEngagement.Value && statutAvisConformite.DateFinStatutEngagement.Value <= dateFinAnneePREM)
            {
                return true;
            }

            return false;
        }




        /// <summary>
        /// Permet d'obtenir la date de debut de l'historique d'engagement du medecin omnipraticien en cas d'abscence
        /// </summary>
        /// <param name="numseqDispensateur"></param>
        /// <returns></returns>
        public DateTime ObtenirDateDebutHistoriqueEngagementAbs(long numseqDispensateur)
        {
            var dateDebHistorique = DateDebutPREM;
            var historique = CreerParametreHistorique(numseqDispensateur);
            DateTime dateOtentionPermis = historique.InformationProfessionnel.DatesObtentionPermis[0].Value;
            DateTime? datePremFacturation = historique.DatePremiereFacturation.HasValue ? historique.DatePremiereFacturation.Value : (DateTime?)null;
            DateTime? dateDebPremEngagement = historique.PeriodeEngagementsAbsence.EngagementsPeriode.Where(u => u.Type != "ABS").Min(u => u.DateDebutEngagement);

            if (datePremFacturation.HasValue && dateDebPremEngagement.HasValue)
            {
                if (datePremFacturation.Value < dateDebPremEngagement.Value)
                {
                    return datePremFacturation.Value < dateDebHistorique ? dateDebHistorique : datePremFacturation.Value;
                }
                if (datePremFacturation.Value > dateDebPremEngagement.Value && dateDebPremEngagement.Value > dateOtentionPermis)
                {
                    return dateOtentionPermis < dateDebHistorique ? dateDebHistorique : dateOtentionPermis;
                }
            }

            if (dateDebPremEngagement.HasValue && !datePremFacturation.HasValue)
            {
                return dateOtentionPermis < dateDebHistorique ? dateDebHistorique : dateOtentionPermis;
            }

            if (!dateDebPremEngagement.HasValue && datePremFacturation.HasValue)
            {
                return datePremFacturation.Value < dateDebHistorique ? dateDebHistorique : datePremFacturation.Value;
            }
            if (!dateDebPremEngagement.HasValue && !datePremFacturation.HasValue)
            {
                return dateOtentionPermis < dateDebHistorique ? dateDebHistorique : dateOtentionPermis;
            }

            return dateOtentionPermis < dateDebHistorique ? dateDebHistorique : dateOtentionPermis;
        }

        HistoriqueEngagement CreerParametreHistorique(long numseqDispensateur)
        {
            //-liste engagements et abs
            ObtenirVuePeriodeEngagementEntre obtenirVuePeriodeEngagementEntre = new ObtenirVuePeriodeEngagementEntre();
            obtenirVuePeriodeEngagementEntre.NumerosSequenceDispensateur.Add(numseqDispensateur);

            var resultPeriodeEngagementSorti = ObtenirPeriodeEngagementsAbsenceProfessionnel(obtenirVuePeriodeEngagementEntre);

            //-Adte 1ère facturation
            ObtenirPeriodePratiqueProfessionnelEntre obtenirPeriodePratiqueProfessionnelEntre = new ObtenirPeriodePratiqueProfessionnelEntre
            {
                NumeroSequenceDispensateur = numseqDispensateur,
                NumeroTypePratique = 1
            };
            var resultPeriodePratiqueProfSorti = ObtenirPeriodePratiqueProfessionnel(numseqDispensateur);
            //-date obtention Permis
            ObtenirDispensateurIndividuEntre obtenirDispensateurIndividuEntre = new ObtenirDispensateurIndividuEntre
            {
                NumeroSequentielDispensateur = numseqDispensateur
            };
            var resultDispensateurIndividuSorti = ObtenirInformationProfessionnel(obtenirDispensateurIndividuEntre);

            return new HistoriqueEngagement
            {
                PeriodeEngagementsAbsence = resultPeriodeEngagementSorti,
                DatePremiereFacturation = resultPeriodePratiqueProfSorti.HasValue ? resultPeriodePratiqueProfSorti.Value : (DateTime?)null,
                InformationProfessionnel = resultDispensateurIndividuSorti
            };


        }

        private List<EngagementPeriode> ObtenirPeriodesAbs(long numeroDispensateur) => CreerParametreHistorique(numeroDispensateur).PeriodeEngagementsAbsence
                                                                                                                                   .EngagementsPeriode.Where(w => w.Type == "ABS")
                                                                                                                                   .ToList();
        #endregion

        #region Message d'erreur

        private void AjouterMessageErreur(IList<Message.MsgTrait> messages)
        {
            MessageErreurs.AddRange(messages);
        }

        #endregion

    }
}
