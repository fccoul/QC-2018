using System;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF
{
    /// <summary> 
    ///  Classe pour valider les paramètres obligatoires
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    internal static class ValidateurParametreObligatoire
    {
        /// <summary>
        /// Valide si le paramètre est null
        /// </summary>
        /// <param name="parametre">Paramètre qu'on veut valider si celui-ci est null</param>
        /// <param name="nomParametre">Nom du paramètre à tester</param>
        internal static void ValiderParametreNull(object parametre, string nomParametre)
        {
            if (parametre == null)
            {
                throw new ArgumentNullException($"Le paramètre : {nomParametre} ne peut est null.");
            } 
        }
    }
}