#region Imports
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Caching;
#endregion

namespace RAMQ.PRE.PRE_OutilComun_cpo.Cache
{
    /// <summary> 
    ///  Classe de type ICache(Of T) qui implément l'interface sous forme cache mémoire
    /// </summary>
    public class MemoireCache<T> : CacheBase<T>
    {

        #region Attributs privés partagés 

        private static MemoryCache _dataCache;

        private static object _syncLock = new object();
        #endregion

        #region Attributs privés

        private TimeSpan _tempsExpiration;

        private bool _estExpirationSliding;
        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="estExpirationSliding">
        ///  Temps avant l'expiration des entrées
        /// </param>
        /// <param name="tempsExpiration">
        ///  Indique si l'expiration est « sliding », c'est à dire si le temps avant 
        ///  expiration est réinitialisé à chaques fois que l'éléments est accédé.
        /// </param>
        /// <remarks></remarks>
        public MemoireCache(TimeSpan tempsExpiration, bool estExpirationSliding) : base()
        {

            if (_dataCache == null)
            {
                lock (_syncLock)
                {
                    if (_dataCache == null)
                    {
                        _dataCache = MemoryCache.Default;
                    }
                }
            }

            _tempsExpiration = tempsExpiration;
            _estExpirationSliding = estExpirationSliding;
        }

        #endregion

        #region Méthodes protégés

        /// <summary>
        /// Ajouter un objet en cache avec la clé déterminée
        /// </summary>
        /// <param name="cle"></param>
        /// <param name="valeur"></param>
        /// <remarks></remarks>
        public override void Ajouter(string cle, T valeur)
        {
            CacheItemPolicy objPolicy = ObtenirPolicy();
            _dataCache.Add(FormaterCle(cle), valeur, objPolicy);
        }

        /// <summary>
        /// Obtenir la valeur de la cache selon la clé
        /// </summary>
        /// <param name="cle">cle de la cache pour le type d'objet</param>
        /// <returns>objet de la cache ou nothing</returns>
        /// <remarks></remarks>
        public override T Obtenir(string cle)
        {
            return (T)_dataCache.Get(FormaterCle(cle));
        }

        /// <summary>
        /// Obtenir la liste de valeur selon le type T
        /// </summary>
        /// <returns>List(Of T)</returns>
        /// <remarks></remarks>
        public override System.Collections.Generic.List<T> ObtenirList()
        {
            return _dataCache.Where(x => x.GetType() == typeof(T)).Select(x => (T)x.Value).ToList();
        }

        /// <summary>
        /// Supprimer l'objet de la cache
        /// </summary>
        /// <param name="cle"></param>
        /// <remarks></remarks>
        public override bool Supprimer(string cle)
        {
            return _dataCache.Remove(FormaterCle(cle)) != null;
        }

        /// <summary>
        /// Supprimer l'ensemble des objets T de la région
        /// </summary>
        /// <remarks></remarks>
        public override bool SupprimerRegion()
        {
            IEnumerable<KeyValuePair<string, object>> colctObj = _dataCache.Where(x => x.GetType() == typeof(T));
            foreach (var item in colctObj)
            {
                Supprimer(item.Key);
            }




            return true;
        }

        #endregion

        #region Méthodes privées

        /// <summary>
        ///  Retourne la policy à utiliser lors de l'ajout d'items
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        private CacheItemPolicy ObtenirPolicy()
        {
            CacheItemPolicy objPolicy = new CacheItemPolicy();

            if (_estExpirationSliding)
            {
                objPolicy.SlidingExpiration = _tempsExpiration;
            }
            else
            {
                objPolicy.AbsoluteExpiration = new DateTimeOffset(System.DateTime.Now.Add(_tempsExpiration));
            }

            return objPolicy;
        }

        #endregion

    }

}

