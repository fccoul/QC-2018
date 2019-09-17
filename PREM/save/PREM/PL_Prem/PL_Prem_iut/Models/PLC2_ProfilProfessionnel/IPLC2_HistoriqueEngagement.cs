using RAMQ.PRE.PRE_Entites_cpo.EngagementPratique.Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using OutilCommun = RAMQ.PRE.PRE_OutilComun_cpo;

namespace RAMQ.PRE.PL_Prem_iut.Models.PLC2_ProfilProfessionnel
{
    /// <summary>
    /// Interface - Modèle de données pour la consultation du profil d'un professionnel 
    /// </summary>
    public interface IPLC2_HistoriqueEngagement
    {
        
        /// <summary>
        /// Liste des raisons des statuts d'avis de conformité d'un médecin omnipraticien
        /// </summary>
        /// <returns>Dictionnaire de domaine de valeurs ayant pour clé la valeur basse </returns>
        Dictionary<string, DomainesValeur.IValeur> ObtenirRaisStatusAvisConf(OutilCommun.IDomaineValeur domaineValeur);


        /// <summary>
        /// Liste des raisons des statuts de la modification, de l'annulation ou de la restitution de l'autorisation PREM d'un médecin omnipraticien.
        /// </summary>
        /// <returns>Dictionnaire de domaine de valeurs ayant pour clé la valeur basse </returns>
        Dictionary<string, DomainesValeur.IValeur> ObtenirRaisStatusAUTOR_PREMQ(OutilCommun.IDomaineValeur domaineValeur);

        /// <summary>
        /// Liste des raisons des statuts de la derogation d'un médecin omnipraticien.
        /// </summary>
        /// <returns>Dictionnaire de domaine de valeurs ayant pour clé la valeur basse </returns>
        Dictionary<string, DomainesValeur.IValeur> ObtenirRaisStatusDerogation(OutilCommun.IDomaineValeur domaineValeur);

     

    }
}
