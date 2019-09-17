using System.Collections.Generic;


namespace RAMQ.PRE.PRE_OutilComun_cpo.Cache
{

    /// <summary> 
    ///  Classe de type ICache(Of T) qui implément l'interface afin de représenter une instance sans cache.
    /// </summary>
    public class NullCache<T> : CacheBase<T>
    {

        /// <summary>
        /// Ajouter un objet en cache avec la clé déterminée
        /// </summary>
        /// <param name="cle"></param>
        /// <param name="valeur"></param>
        /// <remarks></remarks>
        public override void Ajouter(string cle, T valeur)
        {
        }

        /// <summary>
        /// Obtenir la valeur de la cache selon la clé
        /// </summary>
        /// <param name="cle">cle de la cache pour le type d'objet</param>
        /// <returns>objet de la cache ou nothing</returns>
        /// <remarks></remarks>
        public override T Obtenir(string cle)
        {
            return default(T);
        }

        /// <summary>
        /// Supprimer l'objet de la cache
        /// </summary>
        /// <param name="cle"></param>
        /// <remarks></remarks>
        public override bool Supprimer(string cle)
        {
            return true;
        }

        /// <summary>
        /// Supprimer l'ensemble des objets T de la région
        /// </summary>
        /// <remarks></remarks>
        public override bool SupprimerRegion()
        {
            return true;
        }

        /// <summary>
        /// Obtenir la liste de valeur selon le type T
        /// </summary>
        /// <returns>List(Of T)</returns>
        /// <remarks></remarks>
        public override List<T> ObtenirList()
        {
            return new List<T>();
        }

    }
}


