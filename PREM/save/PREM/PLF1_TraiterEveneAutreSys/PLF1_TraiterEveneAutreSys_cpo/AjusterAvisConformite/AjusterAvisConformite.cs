using RAMQ.Message;
using RAMQ.PRE.PL_LogiqueAffaire_cpo.AvisConformite;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal;
using RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Entite;
using RAMQ.PRE.PRE_Entites_cpo.AvisConformite.Parametre;
using RAMQ.PRE.PRE_OutilComun_cpo;
using RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3;
using RAMQ.PRE.PRE_SysExt_cpo.FIP.EPZ3.Parametre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMQ.PRE.PLF1_TraiterEveneAutreSys_cpo
{
    public class AjusterAvisConformite : IAjusterAvisConformite
    {
        private IPlanRegnMdcal _accesDonneesPRE;
        private IInfoDispCnsul _servDispCnsul;

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

        private IAvisConformite _avisConformite;

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

        /// <summary>
        /// Constructeur de la cpo
        /// </summary>
        /// <param name="accesDonneesPRE"></param>
        /// <param name="servDispCnsul"></param>
        public AjusterAvisConformite(IPlanRegnMdcal accesDonneesPRE, IInfoDispCnsul servDispCnsul, IAvisConformite avisConformite)
        {
            if (accesDonneesPRE == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(accesDonneesPRE)} ne peut être null.");
            }

            if (servDispCnsul == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(servDispCnsul)} ne peut être null.");
            }

            _accesDonneesPRE = accesDonneesPRE;
            _servDispCnsul = servDispCnsul;
            _avisConformite = avisConformite;
        }

        public List<long> ObtenirDispensateursAssociesDeClasseCinq(int indNoSeq)
        {
            ObtnRelDispIndivEntre paramEntreEPZ3 = new ObtnRelDispIndivEntre();
            ObtnRelDispIndivSorti paramSortiEPZ3 = new ObtnRelDispIndivSorti();
            //Appel EPZ3
            paramEntreEPZ3 = new ObtnRelDispIndivEntre();
            paramEntreEPZ3.NumeroSequentielIndividu = indNoSeq;

            paramSortiEPZ3 = AccesSysExt.ObtenirRelDispIndiv(paramEntreEPZ3);
            MessageTraitement.ValiderMessageTraitement(paramSortiEPZ3);

            var listeNumNoSeqMedResidents = new List<long>();

            //On vérifie si des occurences correspondant à la classe 5 sont retrouvées
            for (int i = 0; i < paramSortiEPZ3.NumerosClasseDispensateur.Count; i++)
            {
                if (paramSortiEPZ3.NumerosClasseDispensateur[i].Value == 5)
                {
                    if (paramSortiEPZ3.NumerosSequentielDispensateur.Count >= (i+1) && paramSortiEPZ3.NumerosSequentielDispensateur[i] != null && paramSortiEPZ3.NumerosSequentielDispensateur[i].HasValue)
                    {
                        listeNumNoSeqMedResidents.Add(paramSortiEPZ3.NumerosSequentielDispensateur[i].Value);
                    }
                }
            }

            return listeNumNoSeqMedResidents;
        }

        public virtual PRE_Entites_cpo.AvisConformite.Parametre.ObtenirLesAvisConformiteSorti ObtenirAvisConformite(long noSeqDispensateur)
        {
            var paramEntreObtnrAvisConf = new PRE_Entites_cpo.AvisConformite.Parametre.ObtenirLesAvisConformiteEntre()
            {
                NumeroSequentielDispensateur = noSeqDispensateur
            };

            var paramSortiObtnrAvisConformite = AvisConformite.ObtenirLesAvisConformite(paramEntreObtnrAvisConf);

            MessageTraitement.ValiderMessageTraitement(paramSortiObtnrAvisConformite);

            return paramSortiObtnrAvisConformite;
        }

        /// <summary>
        /// Prend une liste de num_no_seq_disp, obtient ses avis de conformité et détermine ceux à modifier
        /// Les avis à corriger doivent être actifs, posséder un statut "AUT" pour autorisé et être en attente de transmission
        /// </summary>
        /// <param name="listeNumNoSeqMedResidents"></param>
        /// <returns></returns>
        public List<long> ObtenirIDAvisConformiteAModifier(List<long> listeNumNoSeqMedResidents)
        {
            
            var listeIdAvisACorriger = new List<long>();

            for (var i = 0; i <= listeNumNoSeqMedResidents.Count - 1; i++)
            {
                //On obtient ses avis de conformité
                var listeAvisConformite = ObtenirAvisConformite(listeNumNoSeqMedResidents[i]);

                foreach (var avisConformite in listeAvisConformite.ListeAvisConformite)
                {
                    var estActif = false;
                    var estAutorise = false;
                    var estEnAttenteDeTransmission = false;

                    //Initialisation des dates si elles ne sont pas remplies
                    if (avisConformite.DateDebutEngagement == null)
                    {
                        avisConformite.DateDebutEngagement = DateTime.MinValue;
                    }

                    if (avisConformite.DateFinEngagement == null)
                    {
                        avisConformite.DateFinEngagement = DateTime.MaxValue;
                    }

                        foreach (var statut in avisConformite.ListeStatutAvisConformite)
                        {
                            if (statut.DateDebutStatutEngagement == null)
                            {
                                statut.DateDebutStatutEngagement = DateTime.MinValue;
                            }

                            if (statut.DateFinStatutEngagement == null)
                            {
                                statut.DateFinStatutEngagement = DateTime.MaxValue;
                            }

                         
                                if (statut.StatutEngagement == "AUT")
                                {
                                    estAutorise = true;
                                }

                                if (statut.IndicateurStatutEngagementAttente == "O")
                                {
                                    estEnAttenteDeTransmission = true;
                                }
                          

                        }
                   
                        if (estAutorise && estEnAttenteDeTransmission && avisConformite.NumeroSequentielEngagement != null)
                    {
                        listeIdAvisACorriger.Add(Convert.ToInt64(avisConformite.NumeroSequentielEngagement));
                    }

                }

            }

            return listeIdAvisACorriger;
        }

        /// <summary>
        /// Met à jour les avis de conformité corrigés dans la base
        /// </summary>
        /// <param name="noSequentielDispensateur"></param>
        /// <param name="listeIdAvisACorriger"></param>
        public List<MsgTrait> ModifierAvisConformiteACorriger(long noSequentielDispensateur, List<long> listeIdAvisACorriger)
        {
            RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ModifierAvisConformiteStatutEntre paramEntreModifAvis;
            RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ModifierAvisConformiteStatutSorti paramSortiModifAvis;

            var messagesErreurs = new List<MsgTrait>();

            if (noSequentielDispensateur <= 0)
            {
                throw new ArgumentNullException($"Le paramètre {nameof(noSequentielDispensateur)} doit être défini.");
            }

            foreach (var idAvis in listeIdAvisACorriger)
            {
                var identifiant = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                identifiant = identifiant.Substring(identifiant.IndexOf("\\") + 1);
                paramEntreModifAvis = new RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ModifierAvisConformiteStatutEntre
                {
                    IdentifiantMAJ = identifiant,
                    NumeroSequentielDispensateur = noSequentielDispensateur,
                    NumeroSequentielEngagement = idAvis
                };
                paramSortiModifAvis = AccesDonneesPRE.ModifierAvisConformiteStatut(paramEntreModifAvis);

               
                ObtenirLesAvisConformiteEntre objParamEntree = new ObtenirLesAvisConformiteEntre()
                {
                    NumeroSequentielDispensateur = noSequentielDispensateur,
                    NumeroSequentielEngagement = idAvis
                };
                var result = _avisConformite.ObtenirLesAvisConformite(objParamEntree);
                if (result != null && !result.InfoMsgTrait.Any())
                {
                    if (!paramSortiModifAvis.InfoMsgTrait.Any())
                    {
                      var statutAvis= result.ListeAvisConformite[0].ListeStatutAvisConformite.Where(u => u.StatutEngagement == "AUT").FirstOrDefault();
                        ModifierStatutEngagementEntre modifierStatutEngagementEntre = new ModifierStatutEngagementEntre
                        {
                            NumeroSequentielEngagement = idAvis,
                            NumeroSequentielStatutEngagement = statutAvis.NumeroSequentielStatutEngagement.Value,
                            DateFinStatutEngagement = statutAvis.DateFinStatutEngagement,
                            IndicateurStatutEngagementEnAttente = "N",
                            IdentifiantMAJ = "PLF1",
                            IndicateurInactivationStatut = "N"
                        };

                        var modifierStatEngagSorti = _avisConformite.ModifierStatutAvisConformite(modifierStatutEngagementEntre);
                        messagesErreurs.AddRange(modifierStatEngagSorti.InfoMsgTrait);
                        
                    }
                    else
                    {
                        messagesErreurs.AddRange(result.InfoMsgTrait);
                    }
                     
                }
                else
                {
                    messagesErreurs.AddRange(result.InfoMsgTrait);
                }
               
                 
            }
            return messagesErreurs;
        }

        public ParamSortiAjusterAvisConformiteMedResidents VerifierParametresEntree(ParamEntreAjusterAvisConformiteMedResidents informationsDispensateur, RAMQ.Message.IResolutionMessage resolutionMessageTrait = null)
        {
            var retour = new ParamSortiAjusterAvisConformiteMedResidents();
            retour.InfoMsgTrait = new List<Message.MsgTrait>();

            if(resolutionMessageTrait == null)
            {
                resolutionMessageTrait = new RAMQ.Message.ResolutionMessage();
            }

            if (!(informationsDispensateur.DisNoSeq > 0))
            {
                var message = new Message.MsgTrait(resolutionMessageTrait, nameof(PRE), "40958", new string[] 
                    {
                        nameof(informationsDispensateur.DisNoSeq)
                    });
                retour.InfoMsgTrait.Add(message);
            }

            if (!(informationsDispensateur.PvcClaDisp > 0))
            {
                var message = new Message.MsgTrait(resolutionMessageTrait, nameof(PRE), "40958", new string[]
                    {
                        nameof(informationsDispensateur.PvcClaDisp)
                    });
                retour.InfoMsgTrait.Add(message);
            }

            if (!(informationsDispensateur.IndNoSeq > 0))
            {
                var message = new Message.MsgTrait(resolutionMessageTrait, nameof(PRE), "40958", new string[]
                    {
                        nameof(informationsDispensateur.IndNoSeq)
                    });
                retour.InfoMsgTrait.Add(message);
            }

            return retour;
        }

        public bool VerifierSiClasseUne(int noClasseDispensateur)
        {
            return noClasseDispensateur == 1;
        }

        public bool VerifierSiMedResidentPresent(List<long> listeNoDispensateurs)
        {
            return (listeNoDispensateurs != null && listeNoDispensateurs.Count >= 1);
        }

        public bool VerifierSiAvisATraiter(List<long> listeIdAvis)
        {
            return (listeIdAvis != null && listeIdAvis.Count > 0);
        }
    }
}
