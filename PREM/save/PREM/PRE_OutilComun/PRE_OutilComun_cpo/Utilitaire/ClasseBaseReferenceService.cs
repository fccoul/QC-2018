#region Imports
using System;
using RAMQ.ServiceModel;
#endregion

namespace RAMQ.PRE.PRE_OutilComun_cpo.Utilitaire
{

    /// <summary> 
    ///  Classe de base pour les références de services
    /// </summary>
    public abstract class ClasseBaseReferenceService<TClient, TInterface> where TClient : ClientBaseRAMQ<TInterface>, TInterface, new() where TInterface : class
    {

        #region Private property

        /// <summary>
        ///  Indique si les appels de services doivent être impersonalisés
        /// </summary>

        private readonly bool _doitEtreImpersonnaliser;
        /// <summary>
        /// Type d'infrastructure RAMQ
        /// </summary>

        private readonly Enumeration.EnumNomInfra _typeInfrastructure;
        /// <summary>
        /// Type de sécurité à appliquer sur le service
        /// </summary>

        private readonly EnumerateurSecuriteEnveloppe _typeSecurite;
        /// <summary>
        ///  Nom de la configuration du nom de terminaison
        /// </summary>

        private readonly string _nomTerminaison;
        #endregion

        #region Constructeurs

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doitEtreImpersonnaliser">Indique si l'appel de service doivt être impersonalisé</param>
        /// <param name="typeInfrastructure">Type d'infrastructure dans lequel se trouve le service</param>
        /// <param name="typeSecurite">Type de sécurité à appliquer sur le service</param>
        /// <param name="nomTerminaison">Nom du point de terminaison</param>
        /// <remarks></remarks>
        protected ClasseBaseReferenceService(bool doitEtreImpersonnaliser = true, 
                                             Enumeration.EnumNomInfra typeInfrastructure = Enumeration.EnumNomInfra.INFRA2011, 
                                             EnumerateurSecuriteEnveloppe typeSecurite = EnumerateurSecuriteEnveloppe.SecuriserEnveloppeIntegreWCF, 
                                             string nomTerminaison = null)
        {
            _doitEtreImpersonnaliser = doitEtreImpersonnaliser;
            _typeInfrastructure = typeInfrastructure;
            _typeSecurite = typeSecurite;
            _nomTerminaison = nomTerminaison;
        }

        #endregion

        #region Méthode protégée

        /// <summary>
        /// Appeler une fonction du service
        /// </summary>
        /// <typeparam name="TSorti">Type de l'objet de sortie</typeparam>
        /// <param name="nomFonction">fonction à appeler</param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected TSorti AppelerServ<TSorti>(Func<TClient, TSorti> nomFonction)
        {
            return UtilitaireService.AppelerService<TInterface, TClient, TSorti>(nomFonction, _doitEtreImpersonnaliser, _typeInfrastructure, _typeSecurite, _nomTerminaison);
        }

        /// <summary>
        /// Appeler une méthode du service
        /// </summary>
        /// <param name="nomMethode">Méthode à appeler</param>
        /// <remarks></remarks>
        protected void AppelerServ(Action<TClient> nomMethode)
        {
            UtilitaireService.AppelerService<TInterface, TClient>(nomMethode, _doitEtreImpersonnaliser, _typeInfrastructure, _typeSecurite, _nomTerminaison);
        }

        #endregion

    }
}
