namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.CheminReseauGabarit
{
    /// <summary> 
    ///  Cette classe permet de récupérer le chemin physique
    ///  d'un gabarit sur le réseau.
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public interface ICheminGabarit
    {
        /// <summary>
        /// Obtenir le chemin réseau d'un gabarit selon le type de gabarit
        /// </summary>
        /// <param name="typeGabarit">Type de gabarit</param>
        /// <returns>Retourne le chemin sur le réseau du gabarit selon le type de gaabrit</returns>
        string Obtenir(TypeGabarit typeGabarit);
    }
}