#region Imports
using System;
using System.Data;
using System.Linq;
#endregion

namespace RAMQ.PRE.PRE_OutilComun_cpo.Cache
{
    /// <summary> 
    ///  Classe de type ICache(Of T) qui implément l'interface sous forme de cache AppFabrique   
    /// </summary>
    /// <remarks>
    /// Auteur : Sébastien Bourdages <br/>
    /// Date   : 2016-11-29
    /// </remarks>

    public class AppFabricCache<T> : CacheBase<T>
    {

        #region Attributs privés

        private string _codeRegion;

        #endregion

        #region Attributs privés partagés

        private static Etat.Cache _dataCache;

        private static object _synclock = new object();
        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="tempsExpiration">
        ///  Temps avant l'expiration des entrées
        /// </param>
        /// <param name="expirationSliding">
        ///  Indique si l'expiration est « sliding », c'est à dire si le temps avant 
        ///  expiration est réinitialisé à chaques fois que l'éléments est accédé.
        /// </param>
        /// <param name="region">
        /// Région de la cache.
        /// </param>
        /// <remarks></remarks>
        public AppFabricCache(TimeSpan tempsExpiration, bool expirationSliding, string region) : base()
        {
            _codeRegion = region;

            if (_dataCache == null)
            {
                lock (_synclock)
                {
                    if (_dataCache == null)
                    {
                        _dataCache = new Etat.Cache(Constantes.CodeApplication, tempsExpiration, expirationSliding);
                    }
                }

                _dataCache.CreerRegion(_codeRegion);
            }
        }

        #endregion

        #region Méthodes protégés

        /// <summary>
        /// Ajouter un objet en cache avec la clé déterminée
        /// </summary>
        /// <param name="strCle"></param>
        /// <param name="valeur"></param>
        /// <remarks></remarks>
        public override void Ajouter(string strCle, T valeur)
        {
            if ((valeur != null))
            {
                try
                {
                    _dataCache.Enregistrer(FormaterCle(strCle), valeur, _codeRegion);
                }
                catch (Exception ex)
                {
                    Journalisation.JournaliserErreurTechnique(ex, Enumeration.EnumCodSever.Erreur);
                }
            }
        }

        /// <summary>
        /// Obtenir la valeur de la cache selon la clé
        /// </summary>
        /// <param name="strCle">cle de la cache pour le type d'objet</param>
        /// <returns>objet de la cache ou nothing</returns>
        /// <remarks></remarks>
        public override T Obtenir(string strCle)
        {
            try
            {
                return _dataCache.Obtenir<T>(FormaterCle(strCle), _codeRegion);
            }
            catch (Exception ex)
            {
                Journalisation.JournaliserErreurTechnique(ex, Enumeration.EnumCodSever.Erreur);
                return default(T);
            }
        }

        /// <summary>
        /// Obtenir la liste de valeur selon le type T
        /// </summary>
        /// <returns>List(Of T)</returns>
        /// <remarks></remarks>
        public override System.Collections.Generic.List<T> ObtenirList()
        {
            try
            {
                return _dataCache.ObtenirRegion(_codeRegion).Select(x => (T)x.Value).ToList();
            }
            catch (Exception ex)
            {
                Journalisation.JournaliserErreurTechnique(ex, Enumeration.EnumCodSever.Erreur);
                return null;
            }
        }

        /// <summary>
        /// Supprimer l'objet de la cache
        /// </summary>
        /// <param name="strCle"></param>
        /// <remarks></remarks>
        public override bool Supprimer(string strCle)
        {
            try
            {
                return _dataCache.Supprimer(FormaterCle(strCle), _codeRegion);
            }
            catch (Exception ex)
            {
                Journalisation.JournaliserErreurTechnique(ex, Enumeration.EnumCodSever.Erreur);
                return false;
            }
        }

        /// <summary>
        /// Supprimer l'ensemble des objets T de la région
        /// </summary>
        /// <remarks></remarks>
        public override bool SupprimerRegion()
        {
            try
            {
                _dataCache.SupprimerRegion(_codeRegion);
                return _dataCache.CreerRegion(_codeRegion);
            }
            catch (Exception ex)
            {
                Journalisation.JournaliserErreurTechnique(ex, Enumeration.EnumCodSever.Erreur);
                return false;
            }
        }

        #endregion

    }

}
