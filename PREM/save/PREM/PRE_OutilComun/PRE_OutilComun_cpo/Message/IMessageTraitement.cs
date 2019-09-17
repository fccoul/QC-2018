using RAMQ.ClasseBase;
using RAMQ.Message;
using System.Collections.Generic;

namespace RAMQ.PRE.PRE_OutilComun_cpo
{
    /// <summary>
    /// Interface pour les messages de traitement
    /// </summary>
    public interface IMessageTraitement
    {
        /// <summary>
        /// Permet de résoudre un message de traitement
        /// </summary>
        /// <param name="codeErreur">Code d'erreur</param>
        /// <param name="parametres">Paramètres</param>
        /// <returns>Message de traitement</returns>
        string ResoudreMessageTraitement(string codeErreur, string[] parametres = null);

        /// <summary>
        /// Permet de créer un nouveau message de traitement
        /// </summary>
        /// <param name="codeErreur">Code d'erreur</param>
        /// <param name="parametres">Paramètres</param>
        /// <returns>Message de traitement</returns>
        MsgTrait NouveauMessageTraitement(string codeErreur, string[] parametres = null);
    }
}