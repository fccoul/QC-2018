
namespace RAMQ.PRE.PRE_OutilComun_cpo.Cache
{

    /// <summary> 
    ///  Classe de type ICache(Of T) qui implément l'interface sous forme cache mémoire
    /// </summary>
    public abstract class CacheBase<T> : ICache<T>
    {

        /// <summary>
        /// Ajouter un objet en cache avec la clé déterminée
        /// </summary>
        /// <param name="cle"></param>
        /// <param name="valeur"></param>
        /// <remarks></remarks>
        public abstract void Ajouter(string cle, T valeur);

        /// <summary>
        /// Obtenir la valeur de la cache selon la clé
        /// </summary>
        /// <param name="cle">cle de la cache pour le type d'objet</param>
        /// <returns>objet de la cache ou nothing</returns>
        /// <remarks></remarks>
        public abstract T Obtenir(string cle);

        /// <summary>
        /// Obtenir la liste de valeur selon le type T
        /// </summary>
        /// <returns>List(Of T)</returns>
        /// <remarks></remarks>
        public abstract System.Collections.Generic.List<T> ObtenirList();

        /// <summary>
        /// Supprimer l'objet de la cache
        /// </summary>
        /// <param name="cle"></param>
        /// <remarks></remarks>
        public abstract bool Supprimer(string cle);

        /// <summary>
        /// Supprimer l'ensemble des objets T de la région
        /// </summary>
        /// <remarks></remarks>
        public abstract bool SupprimerRegion();

        /// <summary>
        ///  Formate la clé du cache.
        /// </summary>
        /// <param name="cle"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string FormaterCle(string cle)
        {
            return string.Format("{0}_{1}_{2}", nameof(PRE), typeof(T), cle);
        }

    }
}