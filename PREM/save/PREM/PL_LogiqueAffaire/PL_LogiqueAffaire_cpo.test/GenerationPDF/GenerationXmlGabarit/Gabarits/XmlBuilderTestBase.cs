using System.Collections.Generic;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.test.GenerationPDF.GenerationXmlGabarit.Gabarits
{
    /// <summary> 
    ///  Classe de base pour les essais sur les XML builder
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
	public class XmlBuilderTestBase
    {
        /// <summary>
        /// Créer les priorités
        /// </summary>
        /// <param name="nombrePrioriteACreer">Nombre de priorité</param>
        /// <returns></returns>
        public List<string> CreerPriorites(int nombrePrioriteACreer)
        {
            var priorites = new List<string>();

            int longueur = nombrePrioriteACreer > 0 ? nombrePrioriteACreer : 0;

            for (int i = 0; i < longueur; i++)
            {
                priorites.Add($"Priorite{ i + 1}");
            }

            return priorites;
        }
    }
}