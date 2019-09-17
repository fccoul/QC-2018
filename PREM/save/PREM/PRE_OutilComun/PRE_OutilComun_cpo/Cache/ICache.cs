using System.Collections.Generic;

namespace RAMQ.PRE.PRE_OutilComun_cpo.Cache
{

    /// <summary> 
    ///  Interface d'implémation d'utilisataire de caching.
    /// </summary>
    public interface ICache<T>
    {

        /// <summary>
        /// Ajouter un objet en cache avec la clé déterminée
        /// </summary>
        /// <param name="cle"></param>
        /// <param name="valeur"></param>
        /// <remarks></remarks>
        void Ajouter(string cle, T valeur);

        /// <summary>
        /// Obtenir la valeur de la cache selon la clé
        /// </summary>
        /// <param name="cle">cle de la cache pour le type d'objet</param>
        /// <returns>objet de la cache ou nothing</returns>
        /// <remarks></remarks>
        T Obtenir(string cle);

        /// <summary>
        /// Obtenir la liste de valeur selon le type T
        /// </summary>
        /// <returns>List(Of T)</returns>
        /// <remarks></remarks>
        List<T> ObtenirList();

        /// <summary>
        /// Supprimer l'objet de la cache
        /// </summary>
        /// <param name="cle"></param>
        /// <remarks></remarks>
        bool Supprimer(string cle);

        /// <summary>
        /// Supprimer l'ensemble des objets T de la région
        /// </summary>
        /// <remarks></remarks>
        bool SupprimerRegion();

    }

}
