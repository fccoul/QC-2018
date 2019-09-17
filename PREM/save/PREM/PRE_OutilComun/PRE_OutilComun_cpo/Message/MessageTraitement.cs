using RAMQ.ClasseBase;
using RAMQ.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RAMQ.PRE.PRE_OutilComun_cpo
{
    /// <summary>
    /// Classe pour les messages de traitement
    /// </summary>
    public class MessageTraitement : IMessageTraitement
    {
        #region Constantes pour les noms de propriétés d'objet MsgTrait

        /// <summary>
        /// Code de sévérité.
        /// </summary>
        public const string CodeSeverite = "CodSev";

        /// <summary>
        /// Code de système.
        /// </summary>
        public const string CodeSysteme = "CodSys";

        /// <summary>
        /// Identifiant du message.
        /// </summary>
        public const string IdMessage = "IdMsg";

        /// <summary>
        /// Texte du message en anglais.
        /// </summary>
        public const string MessageAnglais = "MsgAng";

        /// <summary>
        /// Texte du message en français.
        /// </summary>
        public const string MessageFrancais = "MsgFran";

        /// <summary>
        /// Code de l'application.
        /// </summary>
        public const string CodeApplication = "CodAppli";

        #endregion

        #region Attributs

        private readonly IResolutionMessage _resolutionMessage;

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="resolutionMessage"></param>
        public MessageTraitement(IResolutionMessage resolutionMessage)
        {
            _resolutionMessage = resolutionMessage;
        }

        #endregion

        #region Méthodes publiques

        /// <summary>
        /// Permet de résoudre un message de traitement
        /// </summary>
        /// <param name="codeErreur">Code d'erreur</param>
        /// <param name="parametres">Paramètres</param>
        /// <returns>Message de traitement</returns>
        public string ResoudreMessageTraitement(string codeErreur, string[] parametres = null)
        {
            parametres = parametres ?? new string[] { };

            return _resolutionMessage.ResoudreMessage(Constantes.CodeApplication,
                                                      codeErreur,
                                                      parametres);
        }

        /// <summary>
        /// Permet de créer un nouveau message de traitement
        /// </summary>
        /// <param name="codeErreur">Code d'erreur</param>
        /// <param name="parametres">Paramètres</param>
        /// <returns>Message de traitement</returns>
        public MsgTrait NouveauMessageTraitement(string codeErreur, string[] parametres = null)
        {
            parametres = parametres ?? new string[] { };

            return new MsgTrait(_resolutionMessage,
                                Constantes.CodeApplication,
                                codeErreur,
                                parametres);
        }

        /// <summary>
        ///  Valide que les paramêtres de sorties ne contient pas de message. S'il en contient,
        ///  une exception est lancée.
        /// </summary>
        /// <param name="parametreSortie">Paramêtre de sortie à valider</param>
        /// <param name="messageIgnoner">Liste d'identifiant de message à ignorer</param>
        /// <remarks>Exception de type ApplicationException</remarks>
        [Obsolete("Veuillez utiliser la methode avec ParametreSorti")]
        public static void ValiderMessageTraitement(ParamSorti parametreSortie, params string[] messageIgnoner)
        {
            if (parametreSortie.InfoMsgTrait.Any(x => !messageIgnoner.Contains(x.IdMsg)))
            {
                throw new ApplicationException(parametreSortie.InfoMsgTrait.Where(x => !messageIgnoner.Contains(x.IdMsg)).First().TxtMsgFran);
            }
        }

        /// <summary>
        ///  Valide que les paramêtres de sorties ne contient pas de message. S'il en contient,
        ///  une exception est lancée.
        /// </summary>
        /// <param name="parametreSortie">Paramêtre de sortie à valider</param>
        /// <param name="messageIgnoner">Liste d'identifiant de message à ignorer</param>
        /// <remarks>Exception de type ApplicationException</remarks>
        public static void ValiderMessageTraitement(ParametreSorti parametreSortie, params string[] messageIgnoner)
        {
            if (parametreSortie.InfoMsgTrait.Any(x => !messageIgnoner.Contains(x.IdMsg)))
            {
                throw new ApplicationException(parametreSortie.InfoMsgTrait.Where(x => !messageIgnoner.Contains(x.IdMsg)).First().TxtMsgFran);
            }
        }

        /// <summary>
        /// Obtenir une liste de messages de traitements de type COD1_V4.
        /// </summary>
        /// <typeparam name="T">Type du message de traitement à convertir.</typeparam>
        /// <param name="messagesTraitements">Liste de messages de traitement de type "T".</param>
        /// <returns>Liste de messages de traitement de type COD1_V4.</returns>
        public static IList<MsgTrait> ObtenirMessagesTraitement<T>(IEnumerable<T> messagesTraitements)
        {
            return (from objMsgTrait in messagesTraitements select MapperVersMessageTraitement(messagesTraitements)).ToList();
        }

        /// <summary>
        /// Permet de convertir et d'obtenir, s'il y en a un, le MsgTrait COD1_V4 basé sur l'instance spécifiée.
        /// </summary>
        /// <param name="messageTraitement">Message de traitement.</param>
        public static MsgTrait MapperVersMessageTraitement(object messageTraitement)
        {
            MsgTrait message = null;

            if (messageTraitement != null)
            {
                if (messageTraitement.GetType() == typeof(MsgTrait))
                {
                    message = (MsgTrait)messageTraitement;

                }
                else
                {
                    message = new MsgTrait
                    {
                        CodSever = ObtenirValeurPropriete<string>(messageTraitement, CodeSeverite),
                        CodAppli = ObtenirValeurPropriete<string>(messageTraitement, CodeSysteme),
                        IdMsg = ObtenirValeurPropriete<string>(messageTraitement, IdMessage),
                        TxtMsgAngl = ObtenirValeurPropriete<string>(messageTraitement, MessageAnglais),
                        TxtMsgFran = ObtenirValeurPropriete<string>(messageTraitement, MessageFrancais)
                    };

                    if (string.IsNullOrEmpty(message.CodAppli))
                    {
                        message.CodAppli = ObtenirValeurPropriete<string>(messageTraitement, CodeApplication);
                    }
                }
            }

            return message;
        }

        #endregion

        #region Méthodes privées

        /// <summary>
        /// Permet de récupérer la valeur d'une propriété en fonction de son nom.
        /// </summary>
        /// <typeparam name="T">Le type de la propriété recherchée.</typeparam>
        /// <param name="cible">Objet dans lequel rechercher la propriété.</param>
        /// <param name="nomPropriete">Nom de la propriété à rechercher (peut être partiel).</param>
        /// <returns></returns>
        private static T ObtenirValeurPropriete<T>(object cible, string nomPropriete)
        {
            PropertyInfo objInfo = cible.GetType().GetProperties().FirstOrDefault(p => p.Name.IndexOf(nomPropriete, StringComparison.OrdinalIgnoreCase) >= 0);

            return (T)(objInfo != null ? objInfo.GetValue(cible, null) : ObtenirValeurDefaut<T>());

        }

        /// <summary>
        /// Retourne la valeur par défaut pour un type spécifié.
        /// </summary>
        /// <typeparam name="T">Le type pour lequel obtenir la valeur par défaut.</typeparam>
        /// <returns></returns>
        private static object ObtenirValeurDefaut<T>()
        {

            if (typeof(T) == typeof(string))
            {
                return string.Empty;
            }
#pragma warning disable RAMQ0104 // Règle RAMQ 7.7 : Privilégiez une simple affectation plutôt qu'une déclaration if-else.
            else if (typeof(T).IsPrimitive || typeof(T) == typeof(double))
#pragma warning restore RAMQ0104 // Règle RAMQ 7.7 : Privilégiez une simple affectation plutôt qu'une déclaration if-else.
            {
                return null;
            }
            else
            {
                return Activator.CreateInstance<T>();
            }
        }

        #endregion

    }
}