using RAMQ.DomainesValeur;
using RAMQ.PRE.PRE_OutilComun_cpo.Cache;
using System;

namespace RAMQ.PRE.PRE_OutilComun_cpo
{
    /// <summary>
    /// Classe de domaine de valeur
    /// </summary>
    public class DomaineValeur : IDomaineValeur
    {
        #region Nom domaine valeur

        private const string NomDomaineValeurCodeRSS = "CODE RSS";
        private const string NomDomaineValeurTypeDerogation = "TYP_DEROG_PRATI_PROF";
        private const string NomDomaineValeurCodeRaisonStatutEngagement = "COD_RAIS_STA_ENGAG";
        private const string NomDomaineValeurCodeRaisonStatutDerogation = "COD_RAIS_STA_DEROG_PROF";
        private const string NomDomaineValeurCodeSourceDemandeReevaluation = "COD_SRCE_DEM_REEVA";
        private const string NomDomaineValeurCategorieReevaluationPREMQ = "CATG_REEVA_PREMQ";

        private const string NomDomaineValeurCodeRaisonStatutAutorisation = "COD_RAIS_MODIF_AUTOR";

        #endregion

        #region Attributs privées

        private readonly IAccesDomVal _clientAccesDomVal;
        private ICache<DomVal> _clientCache;

        #endregion

        #region Propriétés publiques

        /// <summary>
        /// 
        /// </summary>
        public ICache<DomVal> Cache
        {
            get
            {
                if (_clientCache == null)
                {
                    _clientCache = new MemoireCache<DomVal>(new TimeSpan(1, 0, 0), false);
                }

                return _clientCache;
            }
            set { _clientCache = value; }
        }

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="clientAccesDomVal"></param>
        public DomaineValeur(IAccesDomVal clientAccesDomVal)
        {            
            if (clientAccesDomVal == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nameof(clientAccesDomVal)} ne peut être null.");
            }
            
            _clientAccesDomVal = clientAccesDomVal;
        }

        #endregion

        #region Méthodes Publiques

        /// <summary>
        /// Obtenir le nom RSS dans le domaine de valeur
        /// </summary>
        /// <returns></returns>
        public DomVal ObtenirNomRssDomaineValeur()
        {
            return ObtenirDomaineValeur(NomDomaineValeurCodeRSS);
        }

        /// <summary>
        /// Obtenir le nom du type de dérogation dans le domaine de valeur
        /// </summary>
        /// <returns></returns>
        public DomVal ObtenirNomTypeDerogationDomaineValeur()
        {
            return ObtenirDomaineValeur(NomDomaineValeurTypeDerogation);
        }

        /// <summary>
        /// Permet d'obtenir les descriptions associé aux codes de raison du statut d'engagement
        /// </summary>
        /// <returns>Liste de description des codes de raison du statut d'engagement</returns>
        public DomVal ObtenirDescriptionCodeRaisonStatutEngagement()
        {
            return ObtenirDomaineValeur(NomDomaineValeurCodeRaisonStatutEngagement);
        }

        /// <summary>
        /// Permet d'obtenir les descriptions associé aux codes de raison du statut d'une dérogation
        /// </summary>
        /// <returns>Liste de description des codes de raison du statut de dérogation</returns>
        public DomVal ObtenirDescriptionCodeRaisonStatutDerogation()
        {
            return ObtenirDomaineValeur(NomDomaineValeurCodeRaisonStatutDerogation);
        }

        /// <summary>
        /// Permet d'obtenir les descriptions associées aux codes de source de demandes de réévaluation
        /// </summary>
        /// <returns>Liste de description des codes source de demandes de réévaluation</returns>
        public DomVal ObtenirDescriptionCodeSourceDemandeReevaluation()
        {
            return ObtenirDomaineValeur(NomDomaineValeurCodeSourceDemandeReevaluation);
        }

        /// <summary>
        /// Permet d'obtenir les descriptions associé aux codes de catégorie de demandes de réévaluation
        /// </summary>
        /// <returns>Liste de description des codes de catégorie de demandes de réévaluation</returns>
        public DomVal ObtenirDescriptionCategorieReevaluationPREMQ()
        {
            return ObtenirDomaineValeur(NomDomaineValeurCategorieReevaluationPREMQ);
        }

        /// <summary>
        /// Permet d'obtenir les descriptions associé aux codes de raison du statut d'une autorisation
        /// </summary>
        /// <returns>Liste de description des codes de raison du statut d'une autoristaion</returns>
        public DomVal ObtenirDescriptionCodeRaisonStatutAutorisation()
        {
            return ObtenirDomaineValeur(NomDomaineValeurCodeRaisonStatutAutorisation);
        }

        #endregion

        #region Méthodes Privées

        private DomVal ObtenirDomaineValeur(string nomDomaineValeur)
        {            
            DomVal domVal = Cache.Obtenir(nomDomaineValeur);

            if (domVal == null)
            {
                domVal = _clientAccesDomVal.ObtenirDomVal(nomDomaineValeur);
                Cache.Ajouter(nomDomaineValeur, domVal);
            }

            return domVal;
        }

 
        #endregion
    }
}





