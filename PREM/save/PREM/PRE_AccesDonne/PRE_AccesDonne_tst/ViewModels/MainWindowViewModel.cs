using GalaSoft.MvvmLight.Command;
using RAMQ.PRE.PRE_AccesDonne_cpo.PlanRegnMdcal;
using System;
using System.Linq;

namespace RAMQ.PRE.PRE_AccesDonne_tst.ViewModels
{
    /// <summary>
    /// Modèle de vue de la fenêtre principale.
    /// </summary>
    public class MainWindowViewModel : BaseViewModel
    {
        IPlanRegnMdcal _classeTest;
        public MainWindowViewModel(IPlanRegnMdcal classeTest)
        {
            if (classeTest == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(classeTest)} ne peut être null.");
            }

            _classeTest = classeTest;
        }

        public string TexteLog { get; set; }

        public RelayCommand ActionTesterObtenirVueRepartAvis
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var paramEntre = new PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ObtenirVueJoursFactPratiAvisEntre()
                    {
                    
                    };
                    var retour = _classeTest.ObtenirVueJoursFactPratiAvis(paramEntre);
                    TexteLog += "Exécuté commande: " + "ObtenirVueJoursFactPratiAvis\n";
                    TexteLog += "Résultat:\n";
                    TexteLog += $"{retour.ListeJoursFactParAvis.Count()} lignes retournées.\n";
                    TexteLog += $" Messages trait:\n{string.Join(",", retour.InfoMsgTrait)}\n\n";
                    RaisePropertyChanged(nameof(TexteLog));
                });
            }
        }

        public RelayCommand ActionTesterObtenirVueRepartTerri
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var paramEntre = new PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ObtenirVueJoursFactPratiTerriEntre()
                    {
                        DateServiceDateDebutPerRechr = new DateTime(2028,01,01),
                        DateServiceDateFinPerRechr = new DateTime(2028, 12, 31),
                        NumeroSeqDispensateur = { 1076 }
                    };
                    var retour = _classeTest.ObtenirVueJoursFactPratiTerri(paramEntre);
                    TexteLog += "Exécuté commande: " + "ObtenirVueJoursFactPratiTerri\n";
                    TexteLog += "Résultat:\n";
                    TexteLog += $"{retour.ListeJoursFactParTerri.Count()} lignes retournées.\n";
                    TexteLog += $" Messages trait:\n{string.Join(",", retour.InfoMsgTrait)}\n\n";
                    RaisePropertyChanged(nameof(TexteLog));
                });
            }
        }

        public RelayCommand ActionTesterObtenirVueListeEngagements
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var paramEntre = new PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ObtenirVueListeEngagementsEntre()
                    {
                       NumerosSequenceDispensateur = { 7025,7105 }
                    };
                    var retour = _classeTest.ObtenirVueListeEngagements(paramEntre);
                    TexteLog += "Exécuté commande: " + "ObtenirVueListeEngagements\n";
                    TexteLog += "Résultat:\n";
                    TexteLog += $"{retour.Engagements.Count()} lignes retournées.\n";
                    TexteLog += $" Messages trait:\n{string.Join(",", retour.InfoMsgTrait)}\n\n";
                    RaisePropertyChanged(nameof(TexteLog));
                });
            }
        }

        public RelayCommand ActionTesterObtenirVueRepartRPPR
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var paramEntre = new PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ObtenirVueJoursFactPratiRPPREntre()
                    {

                    };
                    var retour = _classeTest.ObtenirVueJoursFactPratiRPPR(paramEntre);
                    TexteLog += "Exécuté commande: " + "ObtenirVueJoursFactPratiRPPR\n";
                    TexteLog += "Résultat:\n";
                    TexteLog += $"{retour.ListeJoursFactParRPPR.Count()} lignes retournées.\n";
                    TexteLog += $" Messages trait:\n{string.Join(",", retour.InfoMsgTrait)}\n\n";
                    RaisePropertyChanged(nameof(TexteLog));
                });
            }
        }

        public RelayCommand ActionTesterObtenirVueRepartRSS
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var paramEntre = new PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ObtenirVueJoursFactPratiRssEntre()
                    {

                    };
                    var retour = _classeTest.ObtenirVueJoursFactPratiRSS(paramEntre);
                    TexteLog += "Exécuté commande: " + "ObtenirVueJoursFactPratiRSS\n";
                    TexteLog += "Résultat:\n";
                    TexteLog += $"{retour.ListeJoursFactParRss.Count()} lignes retournées.\n";
                    TexteLog += $" Messages trait:\n{string.Join(",", retour.InfoMsgTrait)}\n\n";
                    RaisePropertyChanged(nameof(TexteLog));
                });
            }
        }

        public RelayCommand ActionTesterObtenirVuePeriodesEngagements
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var paramEntre = new PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ObtenirVuePeriodesEngagementsEntre()
                    {
                        
                    };
                    var retour = _classeTest.ObtenirVuePeriodesEngagements(paramEntre);
                    TexteLog += "Exécuté commande: " + "ObtenirVuePeriodesEngagements\n";
                    TexteLog += "Résultat:\n";
                    TexteLog += $"{retour.EngagementsPeriode.Count()} lignes retournées.\n";
                    TexteLog += $" Messages trait:\n{string.Join(",", retour.InfoMsgTrait)}\n\n";
                    RaisePropertyChanged(nameof(TexteLog));
                });
            }
        }

        public RelayCommand ActionTesterObtenirVuePrcntJrfacAvis
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var paramEntre = new PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ObtenirVueListPrctJrfacAvisEntre()
                    {
                        Annee = 2017,
                        CodeRSS = null,
                        SousTerritoire = null
                    };
                    var retour = _classeTest.ObtenirVueListPrctJrfacAvis(paramEntre);
                    TexteLog += "Exécuté commande: " + "ObtenirVueListPrctJrfacAvis\n";
                    TexteLog += "Résultat:\n";
                    TexteLog += $"{retour.LignesRapport.Count()} lignes retournées.\n";
                    TexteLog += $" Messages trait:\n{string.Join(",", retour.InfoMsgTrait)}\n\n";
                    RaisePropertyChanged(nameof(TexteLog));
                });
            }
        }

        public RelayCommand ActionTesterObtenirVuePrcntJrfacDerog
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var paramEntre = new PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ObtenirVueListPrctJrfacDerogEntre()
                    {
                        Annee = 2017,
                        TypePratique = null
                    };
                    var retour = _classeTest.ObtenirVueListPrctJrfacDerog(paramEntre);
                    TexteLog += "Exécuté commande: " + "ObtenirVueListPrctJrfacDerog\n";
                    TexteLog += "Résultat:\n";
                    TexteLog += $"{retour.LignesRapport.Count()} lignes retournées.\n";
                    TexteLog += $" Messages trait:\n{string.Join(",", retour.InfoMsgTrait)}\n\n";
                    RaisePropertyChanged(nameof(TexteLog));
                });
            }
        }

        public RelayCommand ActionTesterObtenirVuePrcntJrfacTerri
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var paramEntre = new PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ObtenirVueListPrctJrfacTerriEntre()
                    {
                        Annee = 2017
                    };
                    var retour = _classeTest.ObtenirVueListPrctJrfacTerri(paramEntre);
                    TexteLog += "Exécuté commande: " + "ObtenirVueListPrctJrfacTerri\n";
                    TexteLog += "Résultat:\n";
                    TexteLog += $"{retour.LignesRapport.Count()} lignes retournées.\n";
                    TexteLog += $" Messages trait:\n{string.Join(",", retour.InfoMsgTrait)}\n\n";
                    RaisePropertyChanged(nameof(TexteLog));
                });
            }
        }

        public RelayCommand ActionTesterObtenirVuePrcntJrfacRPPR
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var paramEntre = new PRE_AccesDonne_cpo.PlanRegnMdcal.Parametre.ObtenirVueListPrctJrfacRPPREntre()
                    {
                        Annee = 2017
                    };
                    var retour = _classeTest.ObtenirVueListPrctJrfacRPPR(paramEntre);
                    TexteLog += "Exécuté commande: " + "ObtenirVueListPrctJrfacRPPR\n";
                    TexteLog += "Résultat:\n";
                    TexteLog += $"{retour.LignesRapport.Count()} lignes retournées.\n";
                    TexteLog += $" Messages trait:\n{string.Join(",", retour.InfoMsgTrait)}\n\n";
                    RaisePropertyChanged(nameof(TexteLog));
                });
            }
        }

    }
}