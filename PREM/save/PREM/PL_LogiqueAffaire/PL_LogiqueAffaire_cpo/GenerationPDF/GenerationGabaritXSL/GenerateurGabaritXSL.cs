using System;
using RAMQ.Rapports.RenderX;

namespace RAMQ.PRE.PL_LogiqueAffaire_cpo.GenerationPDF.GenerationGabaritXSL
{
    /// <summary> 
    ///  Classe pour la génération des gabarits XSL
    /// </summary>
    /// <remarks>
    ///  Auteur : Alexis Garon-Michaud <br/>
    ///  Date   : Mars 2017
    /// </remarks>
    public class GenerateurGabaritXSL : IGenerateurGabaritXSL
    {
        private readonly IRenderX _renderX;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="renderX">un instance d'objet de renderX</param>
        public GenerateurGabaritXSL(IRenderX renderX)
        {
            ValidateurParametreObligatoire.ValiderParametreNull(renderX, nameof(renderX));

            _renderX = renderX;
        }

        /// <summary>
        /// Générer un gabarit XSL
        /// </summary>
        /// <param name="cheminGabaritXSL">chemin du gabarit XSL</param>
        /// <param name="fichierXml">Contenu du fichier XML</param>
        /// <returns>Retourne un gabarit XSL</returns>
        public byte[] GenererGabaritXSL(string cheminGabaritXSL, byte[] fichierXml)
        {
            ValiderParametresObligatoires(cheminGabaritXSL, fichierXml);

            return _renderX.FusionnerDocXSLFO(cheminGabaritXSL, fichierXml);
        }

        private void ValiderParametresObligatoires(string cheminGabaritXSL, byte[] fichierXml)
        {
            if (string.IsNullOrEmpty(cheminGabaritXSL))
            {
                throw new ArgumentNullException($"Le chemin du gabarit XSL ne peut être vide dans la variable : {nameof(cheminGabaritXSL)}.");
            }

            if (fichierXml == null)
            {
                throw new ArgumentNullException($"Le contenu XML dans la variable : {nameof(fichierXml)}, ne peut être nul.");
            }
        }
    }
}