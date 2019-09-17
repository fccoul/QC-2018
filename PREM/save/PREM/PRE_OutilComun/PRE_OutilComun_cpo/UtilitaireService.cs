#region Imports
using System;
using RAMQ.Extensions;
using RAMQ.ServiceModel;

#endregion

namespace RAMQ.PRE.PRE_OutilComun_cpo
{
    /// <summary>
    /// Classe utilitaire
    /// </summary>
    public sealed class UtilitaireService
    {

        #region Méthodes publiques partagées

        /// <summary>
        ///  Appeler une fonction d'un service
        /// </summary>
        /// <typeparam name="TInterface">Interface générique</typeparam>
        /// <typeparam name="TClient">Client générique</typeparam>
        /// <typeparam name="TSorti">Type de l'objet de sortie</typeparam>
        /// <param name="nomFonction">fonction à appeler</param>
        /// <param name="doitEtreImpersonnaliser">Impersonalisatoin</param>
        /// <param name="typeInfrastructure">Type d'infrastructure</param>
        /// <param name="typeSecurite">Type de sécurité</param>
        /// <param name="nomTerminaison">Nom du point de terminaison</param>
        /// <returns></returns>
        public static TSorti AppelerService<TInterface, TClient, TSorti>(Func<TClient, TSorti> nomFonction, bool doitEtreImpersonnaliser = true, RAMQ.Enumeration.EnumNomInfra typeInfrastructure = Enumeration.EnumNomInfra.INFRA2011, Utilitaire.EnumerateurSecuriteEnveloppe typeSecurite = Utilitaire.EnumerateurSecuriteEnveloppe.SecuriserEnveloppeIntegreWCF, string nomTerminaison = null) where TInterface : class where TClient : ClientBaseRAMQ<TInterface>, TInterface, new()
        {

            TSorti parametreSortie = default(TSorti);
            TClient client = null;

            try
            {
                client = ObtenirClient<TInterface, TClient>(typeSecurite, nomTerminaison);

                if (doitEtreImpersonnaliser && EstDansContxWeb())
                {
                    using (System.Security.Principal.WindowsImpersonationContext objWinContx = System.Web.HttpContext.Current.ObtnNouvContxPrincipal(DefinirInfra(typeInfrastructure)))
                    {
                        parametreSortie = nomFonction(client);
                        objWinContx.Undo();
                    }
                }
                else
                {
                    parametreSortie = nomFonction(client);
                }

            }
            finally
            {
                ClientBaseRAMQ<TInterface> objClienBaseRamq = ConvertirEnClientRamqBase<TInterface, TClient>(client);

                if (objClienBaseRamq != null)
                {
                    objClienBaseRamq.FermerConxn();
                }

                
                Composante.EssayerDispose(client);

            }

            return parametreSortie;

        }

        /// <summary>
        ///  Appeler une méthode d'un service
        /// </summary>
        /// <typeparam name="TInterface">Interface géné</typeparam>
        /// <typeparam name="TClient"></typeparam>
        /// <param name="nomMethode">Méthode à appeler</param>
        /// <param name="doitEtreImpersonnaliser">Boolean pour savoir si on doit impersonnalisé ou non</param>
        /// <param name="typeInfrastructure">Type d'infrastructure</param>
        /// <param name="typeSecurite">Type de sécurité</param>
        /// <param name="nomTerminaison">Nom du point de terminaisons</param>
        public static void AppelerService<TInterface, TClient>(Action<TClient> nomMethode, 
                                                               bool doitEtreImpersonnaliser = true, 
                                                               RAMQ.Enumeration.EnumNomInfra typeInfrastructure = Enumeration.EnumNomInfra.INFRA2011, 
                                                               Utilitaire.EnumerateurSecuriteEnveloppe typeSecurite = Utilitaire.EnumerateurSecuriteEnveloppe.SecuriserEnveloppeIntegreWCF, 
                                                               string nomTerminaison = null) where TInterface : class where TClient : ClientBaseRAMQ<TInterface>, TInterface, new()
        {
            Func<TClient, object> nomFonction = default(Func<TClient, object>);
            nomFonction = (TClient x) =>
            {
                nomMethode(x);
                return null;
            };

            AppelerService<TInterface, TClient, object>(nomFonction, doitEtreImpersonnaliser, typeInfrastructure, typeSecurite, nomTerminaison);
        }

        #endregion

        #region Méthodes privées

        /// <summary>
        ///  Création et configuration du client
        /// </summary>
        /// <param name="typeSecurite">Type de sécurité à appliquer au client</param>
        /// <param name="nomTerminaison">
        ///  Nom de la configuration du point de terminaison (endpoint)</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private static TClient ObtenirClient<TInterface, TClient>(Utilitaire.EnumerateurSecuriteEnveloppe typeSecurite, string nomTerminaison) where TInterface : class where TClient : ClientBaseRAMQ<TInterface>, TInterface, new()
        {
            TClient client = default(TClient);

            //Définir le client, en appliquant le binding et l'adresse

            client = nomTerminaison != null ? Activator.CreateInstance(typeof(TClient), nomTerminaison) as TClient : Activator.CreateInstance(typeof(TClient)) as TClient;

            if (client == null)
            {
                throw new InvalidCastException("Impossible de créer le client.");
            }

            //Définir l'interface
            ClientBaseRAMQ<TInterface> interfaceClient = ConvertirEnClientRamqBase<TInterface, TClient>(client);

            if (interfaceClient == null)
            {
                throw new InvalidCastException("Impossible de créer le client de base RAMQ.");
            }

            SecuriseEnveloppe(ref interfaceClient, typeSecurite);

            return interfaceClient as TClient;

        }

        /// <summary>
        /// Convertir un client en client de base RAMQ
        /// </summary>
        /// <param name="client">Client</param>
        /// <returns></returns>
        /// <remarks></remarks>
        private static ClientBaseRAMQ<TInterface> ConvertirEnClientRamqBase<TInterface, TClient>(TClient client) where TInterface : class where TClient : ClientBaseRAMQ<TInterface>, TInterface, new()
        {
            return client as ClientBaseRAMQ<TInterface>;
        }

#pragma warning disable RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
                                /// <summary>
                                /// Sécurisé enveloppe
                                /// </summary>
                                /// <param name="client">Client</param>
                                /// <param name="typeSecurite">type de sécurité</param>
                                /// <remarks></remarks>
        private static void SecuriseEnveloppe<TIClient>(ref ClientBaseRAMQ<TIClient> client, Utilitaire.EnumerateurSecuriteEnveloppe typeSecurite) where TIClient : class
#pragma warning restore RAMQ0101 // Règle RAMQ 7.8 : L'utilisation du mot clé 'ref' ou 'out' n'est pas recommandé.
        {
            switch (typeSecurite)
            {
                case Utilitaire.EnumerateurSecuriteEnveloppe.SecuriserEnveloppe:
                    client.SecuriserEnveloppe();
                    break;
                case Utilitaire.EnumerateurSecuriteEnveloppe.SecuriserEnveloppeIntegre:
                    client.SecuriserEnveloppeIntegre();
                    break;
                case Utilitaire.EnumerateurSecuriteEnveloppe.SecuriserEnveloppeIntegreWCF:
                    client.SecuriserEnveloppeIntegreWCF();
                    break;
            }
        }

        /// <summary>
        /// Définir l'infrastructure de l'appel
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        private static string DefinirInfra(RAMQ.Enumeration.EnumNomInfra typeInfrastructure)
        {
            const string Infrastructure2011 = "INFRA2011";
            const string InfrastructureCisel = "CISEL";

            string infrastructure = string.Empty;

            switch (typeInfrastructure)
            {
                case Enumeration.EnumNomInfra.CISEL:
                    infrastructure = InfrastructureCisel;
                    break;
                case Enumeration.EnumNomInfra.INFRA2011:
                    infrastructure = Infrastructure2011;
                    break;
            }

            return infrastructure;
        }

        /// <summary>
        /// Défini si nous sommes dans un contexte web
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        private static bool EstDansContxWeb()
        {
            return System.Web.HttpContext.Current != null;
        }

        #endregion

    }
}